using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using System.IO;
using GoogleOSD.Properties;
using System.Collections.Generic;
using System.Reflection;
//using System.Text.Json;

namespace GoogleOSD {
	/// <summary>
	/// GoogleAuth.xaml の相互作用ロジック
	/// </summary>
	public partial class GoogleAuth : Window {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public WebWindow webWindow;
		public GCalender calenderWindow;

		/// <summary>
		/// 使用許諾を受けるAPIのリスト
		/// </summary>
		public static string[] AllScopes = { DriveService.Scope.DriveFile,
																	DriveService.Scope.DriveAppdata,			//追加
																	DriveService.Scope.Drive,
																	CalendarService.Scope.Calendar,
																	CalendarService.Scope.CalendarEvents
															};

		public GoogleAuth()
		{
			InitializeComponent();
			ReadSetting();
		}

		private void ReadSetting()
		{
			string TAG = "ReadSetting";
			string dbMsg = "[GoogleAuth]";
			try {
				Settings MySettings = Settings.Default;
				dbMsg += ",Settings=" + MySettings.Context.Count + "件";
				company_id_tb.Text = MySettings.companyId;
				user_name_tb.Text = MySettings.companyName;
				Google_Acount_tb.Text = MySettings.googleAcount;
				Google_Password_tb.Text = MySettings.googlePassWord;
				GOAuthModel gOAuthModel = new GOAuthModel(
																		MySettings.clientId,
																		MySettings.clientSecret,
																		MySettings.projectId,
																		MySettings.authUri,
																		MySettings.tokenUri,
																		MySettings.auth_providerX509CertUrl
															);
				if (gOAuthModel.client_id==null || gOAuthModel.client_id.Equals("")){ 
					dbMsg += ",JsonReadへ";
					JsonRead();
				}else{
					dbMsg += ",接続へ";
					//	LogInProcrce(gOAuthModel);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ファイルで認証情報読込み
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Json_read_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Json_read_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				JsonRead();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// OAuthのJSONファイルを読む
		/// </summary>
		private void JsonRead() {
			string TAG = "JsonRead";
			string dbMsg = "[GoogleAuth]";
			try {
				// ダイアログのインスタンスを生成
				var dialog = new OpenFileDialog();

				// ファイルの種類を設定
				dialog.Filter = "テキストファイル (*.json)|*.json|全てのファイル (*.*)|*.*";
				// ダイアログを表示する
				DialogResult res = dialog.ShowDialog();
				int rCount = dialog.FileNames.Count();
				dbMsg += "," + rCount + "件";
				if (0 < rCount) {
					// 選択されたファイル名 (ファイルパス) をメッセージボックスに表示
					foreach (String fileOne in dialog.FileNames) {
						string jsonPath = fileOne.ToString();
						dbMsg += "\r\n" + jsonPath;
						dbMsg += ",jsonPath=" + jsonPath;

						using (System.IO.FileStream stream = new System.IO.FileStream(jsonPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
							//読込んだファイルを文字列に変換
							StreamReader sr = new StreamReader(stream);
							string rStr = sr.ReadToEnd();
							sr.Close();
							dbMsg += ",rStr=" + rStr;
							var deserialized = JsonConvert.DeserializeObject<GOAuthModel>(rStr);
							Settings MySettings = Settings.Default;
							MySettings.clientId = deserialized.client_id;
							MySettings.clientSecret = deserialized.client_secret;
							MySettings.projectId = deserialized.project_id;
							MySettings.authUri = deserialized.auth_uri;
							MySettings.tokenUri = deserialized.token_uri;
							MySettings.auth_providerX509CertUrl = deserialized.auth_provider_x509_cert_url;
							MyLog(TAG, dbMsg);
							//(ユーザーフォルダー)\AppData\Local\CompanyName\ProgramName_xxxx\Version\user.config に保存
							MySettings.Save();
							ReadSetting();
						}
						//Task<UserCredential> userCredential = Task.Run(() => {
						//	return GetAllCredential(jsonPath, "token.json");
						//});
						//userCredential.Wait();
						//Constant.MyDriveCredential = userCredential.Result;                           //作成結果が格納され戻される


						//			LogInProcrce(jsonPath);
						//複数選ばれても一件目で強制的に処理開始
						break;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// UserCredentialを作成する
		/// 初回アクセス時に使用するAPIをScopesで申請する
		/// </summary>
		/// <param name="jsonPath">読込むjsonファイルのURL</param>
		/// <param name="tokenFolderPath"></param>
		/// <returns>UserCredential</returns>
		static Task<UserCredential> GetAllCredential(string jsonPath, string tokenFolderPath)
		{
			//string TAG = "GetAllCredential";
			//string dbMsg = "[GoogleAuthUtil]";
			//dbMsg += ",jsonPath=" + jsonPath;
			using (var stream = new System.IO.FileStream(jsonPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
				return GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					AllScopes,
					"user",
					CancellationToken.None,
					new FileDataStore(tokenFolderPath, true));
			}
		}



		private void Log_in_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Log_in_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ログイン実働
		/// </summary>
		/// <param name="JsonFileName"></param>
		private void LogInProcrce(string JsonFileName)
		{
			string TAG = "LogInProcrce";
			string dbMsg = "[GoogleAuth]";
			try {
				dbMsg += ",JsonFileName=" + JsonFileName;
				String retStr = GAuthUtil.Authentication(JsonFileName, "token.json");           //"drive_calender.json"
				dbMsg += ",retStr=" + retStr;
				if (retStr.Equals("")) {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					String msgStr = "認証されませんでした。\r\n更新ボタンをクリックして下さい";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
				} else {
					string UserId = Constant.MyCalendarCredential.UserId;
					dbMsg += ",UserId=" + UserId;
					MyLog(TAG, dbMsg);
					//if (calenderWindow == null) {
					//	dbMsg += "＞＞カレンダへ";
					//	GCalender calenderWindow = new GCalender();
					//	calenderWindow.authWindow = this;
					//	calenderWindow.Show();
					//}
					string CalenderURL = Constant.CalenderOtherView +  "month?pli=1"; 
					//特定日の指定は　/month/2020/9/1?pli=1
					dbMsg += ",CalenderURL=" + CalenderURL;
					if (webWindow == null) {
						dbMsg += "一日リストを生成";
						webWindow = new WebWindow();
						webWindow.authWindow = this;
						webWindow.Show();
						webWindow.SetMyURL(new Uri(CalenderURL));
					}
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// ログアウト処理
		/// アウトでアプリケーション終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Log_out_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Log_out_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				String titolStr = Constant.ApplicationName;
				String msgStr = "ログアウトしますか？";
				MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
				dbMsg += ",result=" + result;
				if(result.Equals(System.Windows.MessageBoxResult.OK)) {
					msgStr = "お疲れ様でした。";
					 result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Information);
					if (result.Equals(System.Windows.MessageBoxResult.OK)) {
			//			this.Close();
					}
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		)
		{
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}

		////////////////////////////////////////////////////

	}
}
