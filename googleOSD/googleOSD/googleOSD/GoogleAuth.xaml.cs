using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using System.IO;
using GoogleOSD.Properties;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Google.Apis.Services;
using System.Collections.Generic;

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
			Constant.ConnectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Constant.Server, Constant.Database, Constant.Uid, Constant.Pwd);
		}

		/// <summary>
		/// 設定ファイルの読み込み
		/// OAuthのJSONを読み取って取っていなければ読込みへ
		/// </summary>
		private void ReadSetting()
		{
			string TAG = "ReadSetting";
			string dbMsg = "[GoogleAuth]";
			try {
				Settings MySettings = Settings.Default;
				dbMsg += ",Settings=" + MySettings.Context.Count + "件";
	// DB			MySettings.AriadneDataFolder = null;
				if (MySettings.AriadneDataFolder == null || MySettings.AriadneDataFolder.Equals("")) {
					Constant.AriadneDataFolder =  AriadneFolderRead();
				}else{
					Constant.AriadneDataFolder = MySettings.AriadneDataFolder;
				}
				dbMsg += ",AriadneDataFolder=" + Constant.AriadneDataFolder;

				//	Json読込みのテスト時は以下の二行で読込みリセット
				//	MySettings.clientId = null;
				//MySettings.Save();

				company_id_tb.Text = MySettings.companyId;
				user_name_tb.Text = MySettings.companyName;
				Google_Acount_tb.Text = MySettings.googleAcount;
				Google_Password_tb.Text = MySettings.googlePassWord;
				dbMsg += ",Settings=" + MySettings.clientId ;
				if (MySettings.clientId==null || MySettings.clientId.Equals("")){ 
					dbMsg += ",JsonReadへ";
					JsonRead();
				}else{
					dbMsg += ",接続へ";

					Controls.WaitingDLog progressWindow = new Controls.WaitingDLog();
					progressWindow.Show();
					progressWindow.SetMes("Googleサービス接続中...");
					Task<UserCredential> userCredential = Task.Run(() => {
						return MakeAllCredentialAsync();
					});
					userCredential.Wait();

					progressWindow.Close();

					Constant.MyDriveCredential = userCredential.Result;                           //作成結果が格納され戻される
					if (Constant.MyDriveCredential==null) {
						//メッセージボックスを表示する
						String titolStr = Constant.ApplicationName;
						String msgStr = "認証されませんでした。\r\n更新ボタンをクリックして下さい";
						MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
						dbMsg += ",result=" + result;
					} else {
						dbMsg += "\r\nAccessToken=" + Constant.MyDriveCredential.Token.AccessToken;
						dbMsg += "\r\nRefreshToken=" + Constant.MyDriveCredential.Token.RefreshToken;
						Constant.MyDriveService = new DriveService(new BaseClientService.Initializer() {
							HttpClientInitializer = Constant.MyDriveCredential,
							ApplicationName = Constant.ApplicationName,
						});
						dbMsg += ",MyDriveService:ApiKey=" + Constant.MyDriveService.ApiKey;
						Constant.MyCalendarCredential = Constant.MyDriveCredential;
						Constant.MyCalendarService = new CalendarService(new BaseClientService.Initializer() {
							HttpClientInitializer = Constant.MyCalendarCredential,
							ApplicationName = Constant.ApplicationName,
						});
						dbMsg += ",MyCalendarService:ApiKey=" + Constant.MyCalendarService.ApiKey;
					}
				}
				Constant.RootFolderID = GDriveUtil.MakeAriadneGoogleFolder();
				if (Constant.RootFolderID.Equals("")) {
					dbMsg += ">フォルダ作成>失敗";
				} else {
					dbMsg += "[" + Constant.RootFolderID + "]" + Constant.RootFolderName;
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ファイルで認証情報読込む
		/// 初回とOAuth更新時に使用
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
							GOAuthModel gOAuthModel = JsonConvert.DeserializeObject<GOAuthModel>(rStr);
							Settings MySettings = Settings.Default;
							dbMsg += ",client_id=" + gOAuthModel.client_id;
												MySettings.clientId = gOAuthModel.client_id;
												dbMsg += ",client_secret=" + gOAuthModel.client_secret;
												MySettings.clientSecret = gOAuthModel.client_secret;
												MySettings.projectId = gOAuthModel.project_id;
												MySettings.authUri = gOAuthModel.auth_uri;
												MySettings.tokenUri = gOAuthModel.token_uri;
												MySettings.auth_providerX509CertUrl = gOAuthModel.auth_provider_x509_cert_url;
							MyLog(TAG, dbMsg);
							//(ユーザーフォルダー)\AppData\Local\CompanyName\ProgramName_xxxx\Version\user.config に保存
							MySettings.Save();
							ReadSetting();
						}
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
		/// Ariadneの生成ファイルフォルダの位置を読み出す
		/// </summary>
		private string AriadneFolderRead()
		{
			string TAG = "AriadneFolderRead";
			string dbMsg = "[GoogleAuth]";
			string retStr = "";
			try {
				// フォルダー参照ダイアログのインスタンスを生成
				var dialog = new System.Windows.Forms.FolderBrowserDialog();

				// 説明文を設定
				dialog.Description = "Ariadneで作成したフォルダーを選択してください。";

				// ダイアログを表示
				if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
					// 選択されたフォルダーパスをメッセージボックスに表示
					Settings MySettings = Settings.Default;
					retStr = dialog.SelectedPath;
					MySettings.AriadneDataFolder = retStr;
					dbMsg += ",MySettings.AriadneDataFolder=" + MySettings.AriadneDataFolder;
					MySettings.Save();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retStr;
		}



		/// <summary>
		/// UserCredentialを作成する
		/// 初回アクセス時に使用するAPIをScopesで申請する
		/// </summary>
		/// <returns>UserCredential</returns>
		private async Task<UserCredential> MakeAllCredentialAsync()
		{
			string TAG = "MakeAllCredentialAsync";
			string dbMsg = "[GoogleAuthUtil]";
			UserCredential userCedential=null;
			try {
				ClientSecrets clientSecrets = new ClientSecrets();
				Settings MySettings = Settings.Default;
				dbMsg += ",clientId=" + MySettings.clientId;
				clientSecrets.ClientId = MySettings.clientId;
				dbMsg += ",clientSecret=" + MySettings.clientSecret;
				clientSecrets.ClientSecret = MySettings.clientSecret;
				//there are different scopes, which you can find here https://cloud.google.com/storage/docs/authentication
				//	var scopes = new[] { @"https://www.googleapis.com/auth/devstorage.full_control" };
				CancellationTokenSource cts = new CancellationTokenSource();
				userCedential = await GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets, AllScopes, "yourGoogle@email", cts.Token);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return userCedential;
		}

		/// <summary>
		/// webでカレンダーへ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Log_in_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Log_in_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				string UserId = Constant.MyCalendarCredential.UserId;
				dbMsg += ",UserId=" + UserId;
				MyLog(TAG, dbMsg);
				string CalenderURL = Constant.CalenderOtherView + "month?pli=1";
				//特定日の指定は　/month/2020/9/1?pli=1
				dbMsg += ",CalenderURL=" + CalenderURL;
				if (calenderWindow == null) {
					dbMsg += "＞＞カレンダへ";
					GCalender calenderWindow = new GCalender();
					calenderWindow.authWindow = this;
					calenderWindow.Show();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Web_calender_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Web_calender_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				string UserId = Constant.MyCalendarCredential.UserId;
				dbMsg += ",UserId=" + UserId;
				MyLog(TAG, dbMsg);
				Constant.WebStratUrl = Constant.CalenderOtherView + "month?pli=1";
				//特定日の指定は　/month/2020/9/1?pli=1
				dbMsg += ",CalenderURL=" + Constant.WebStratUrl;
				if (webWindow == null) {
					dbMsg += "一日リストを生成";
					webWindow = new WebWindow();
					webWindow.authWindow = this;
					webWindow.Show();
					webWindow.SetMyURL(new Uri(Constant.WebStratUrl));
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// webでGoogleDriveへ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Web_drive_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Web_drive_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				string UserId = Constant.MyDriveCredential.UserId;
				dbMsg += ",UserId=" + UserId;
				MyLog(TAG, dbMsg);
				Constant.WebStratUrl = Constant.DriveOtherView;
				Google.Apis.Drive.v3.Data.File folder = GDriveUtil.FindByNameParent(Constant.TopFolderName, Constant.RootFolderName);
				Constant.WebStratUrl += folder.Id;
				dbMsg += ",DriveURL=" + Constant.WebStratUrl;
				if (webWindow == null) {
					dbMsg += "案件フォルダへ";
					webWindow = new WebWindow();
					webWindow.authWindow = this;
					webWindow.Show();
					webWindow.SetMyURL(new Uri(Constant.WebStratUrl));
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// ログアウト処理
		/// アウトでアプリケーション終了
		/// Googleのログアウト処理は調査中
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
						this.Close();
					}
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void my_sql_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "my_sql_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				//			if (webWindow == null) {
				//				dbMsg += "案件フォルダへ";
				MySQLBase mySQLBase = new MySQLBase();
				//		webWindow.authWindow = this;
				mySQLBase.Show();
			//		webWindow.SetMyURL(new Uri(Constant.WebStratUrl));
	//			}
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
