using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Windows.Shapes;
using Google.Apis.Drive.v3.Data;
using Infragistics.Controls.Schedules;
using Livet;
using Livet.Commands;
using Livet.Messaging.Windows;
using Livet.EventListeners;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Google.Apis.Services;

using TabCon.Models;
using TabCon.Enums;
using Task = System.Threading.Tasks.Task;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace TabCon.ViewModels {
	public class Z_1_4ViewModel : ViewModel  {
		public string titolStr = "【Googleアカウント認証】";
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();
		MySQL_Util MySQLUtil;
		/// <summary>
		/// 操作対象テーブル:Googleアカウント認証テーブル
		/// </summary>
		public string TargetTableName = "m_google_account";
		/// <summary>
		/// GoogleAccountテーブルレコード
		/// </summary>
		public m_google_account OneAccount;
		//ObservableCollection<m_google_account> GoogleAccount;

		/// <summary>
		/// 契約ID
		/// </summary>
		public int contractId = 1;

		/// <summary>
		/// 使用許諾を受けるAPIのリスト
		/// </summary>
		public static string[] AllScopes = { DriveService.Scope.DriveFile,
																	DriveService.Scope.DriveAppdata,
																	DriveService.Scope.Drive,
																	CalendarService.Scope.Calendar,
																	CalendarService.Scope.CalendarEvents
															};
		/// <summary>
		/// 接続ボタン表示
		/// </summary>
		public string ConnectVisibility { set; get; }
		/// <summary>
		/// 解除ボタン表示
		/// </summary>
		public string CancelVisibility { set; get; }

		/// <summary>
		/// このページで編集するEvent
		/// </summary>
		private Google.Apis.Calendar.v3.Data.Event taregetEvent { set; get; }

		public Views.Z_1_4 MyView { get; set; }
		public ViewModels.MainViewModel RootViewModel { get; set; }


		/// <summary>
		/// ViewからのDataContext設定用
		/// </summary>
		public Z_1_4ViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try {
				OneAccount = new m_google_account();
				CS_Util Util = new CS_Util();
				//Googleアカウント認証テーブルを読み込む///////////////////////////////////////////
				MySQLUtil = new MySQL_Util();
				if (MySQLUtil.MySqlConnection()) {
					//接続文字列作成
					Constant.ConnectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}",
																	Constant.Server, Constant.Database, Constant.Uid, Constant.Pwd);
					using (MySqlConnection mySqlConnection = new MySqlConnection(Constant.ConnectionString)) {
						mySqlConnection.Open();
						using (MySqlCommand command = mySqlConnection.CreateCommand()) {
							command.Connection = mySqlConnection;
							command.CommandText = $"SELECT * FROM " + TargetTableName + " WHERE m_contract_id= " + contractId;
							dbMsg += ",CommandText=" + command.CommandText;
							using (MySqlDataReader reader = command.ExecuteReader()) {
								//int RecordCount = reader.;
								//dbMsg += "," + RecordCount + "レコード";
								int FieldCount = reader.FieldCount;
								dbMsg += "," + FieldCount + "項目";
								//一行づつデータを読み取りモデルに書込む
								while (reader.Read()) {
									for (int i = 0; i < FieldCount; i++) {
										string rName = reader.GetName(i);
										string rType = reader.GetFieldType(i).Name;
										dbMsg += "\r\n(" + i + ")" + rName + ",rType=" + rType;
										var rVar = reader.GetValue(i);
										dbMsg += ",rVar=" + rVar;
										if (rVar == null || rVar.Equals("") || reader.IsDBNull(i)) {
											dbMsg += ">>スキップ";
										} else if (rName.Equals("id")) {
											OneAccount.id = (int)rVar;
										} else if (rName.Equals("m_contract_id")) {
											OneAccount.m_contract_id = (int)rVar;				//契約ID
										} else if (rName.Equals("google_account")) {
											OneAccount.google_account = (string)rVar;       //Googleアカウント :@gmail.comのアカウント
										} else if (rName.Equals("client_id")) {
											OneAccount.client_id = (string)rVar;				//GoogleクライアントID :GoogleAPIが使用するアカウント相当情報
										} else if (rName.Equals("client_secret")) {
											OneAccount.client_secret = (string)rVar;         //Googleクライアントシークレット :上記のパスワード相当相当
										} else if (rName.Equals("project_id")) {
											OneAccount.project_id = (string)rVar;				//GoogleプロジェクトID :GoogleAPIの登録先名
										} else if (rName.Equals("calender_id")) {
											OneAccount.calender_id = (string)rVar;			//カレンダID
										} else if (rName.Equals("drive_id")) {
											OneAccount.drive_id = (string)rVar;				//ドライブID
										}
										dbMsg += ">>読取";
									}
								}
							}
						}
					}
					MySQLUtil.DisConnect();
				}else{
					dbMsg += ">>DB接続失敗" ;
				}
				MyLog(TAG, dbMsg);
				ConnectVisibility = "Visible";
				CancelVisibility = "Hidden"; 
				RaisePropertyChanged();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// OAuthのJSONファイルを読む
		/// Modelに格納して
		/// </summary>
		private void JsonRead()
		{
			string TAG = "JsonRead";
			string dbMsg = "[GoogleAuth]";
			try {
				// ダイアログのインスタンスを生成
				OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
				dialog.Title = "Googleコンソールで取得したJSONファイルを選択して下さい";
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
							//JSONからMODELへ転記////////////////////////////////////////////
							dbMsg += "\r\nclient_id= " + gOAuthModel.client_id;
							OneAccount.client_id = gOAuthModel.client_id;
							dbMsg += " \r\nclient_secret= " + gOAuthModel.client_secret;
							OneAccount.client_secret = gOAuthModel.client_secret;
							dbMsg += "\r\nproject_id= " + gOAuthModel.project_id;
							OneAccount.project_id = gOAuthModel.project_id;
							dbMsg += "\r\nauth_uri= " + gOAuthModel.auth_uri;
							OneAccount.auth_uri = gOAuthModel.auth_uri;
							dbMsg += "\r\ntoken_uri= " + gOAuthModel.token_uri;
							OneAccount.token_uri = gOAuthModel.token_uri;
							dbMsg += "\r\nauth_provider_x509_cert_url= " + gOAuthModel.auth_provider_x509_cert_url + "\r\n";
							OneAccount.auth_provider_x509_cert_url = gOAuthModel.auth_provider_x509_cert_url;
							///テーブルに書込む////////////////////JSONからMODELへ転記//
							using (MySqlConnection mySqlConnection = new MySqlConnection(Constant.ConnectionString)) {
						//		mySqlConnection.Open();
								// コマンドを作成
								string CommandStr = "insert into " + TargetTableName;
								CommandStr += " values(@id, @m_contract_id, @google_account, @client_id, @client_secret, @project_id, " +
																				"@calender_id, @drive_id, @created_user, @created_at , " +
																				" @updated_user, @updated_at , @deleted_at  )";
								if (0< OneAccount.id) {
									CommandStr = "update " + TargetTableName + " set " +
																			"client_id = @client_id" +
																			" , client_secret = @client_secret" +
																			" , project_id = @project_id" +
																			" , updated_user = @updated_user" +
																			" , updated_at = @updated_at" +
																			" where id = @id";
								}

								MySqlCommand cmd =new MySqlCommand(CommandStr, mySqlConnection);
								// パラメータ設定
								cmd.Parameters.Add(
									new MySqlParameter("id", OneAccount.id));
								//cmd.Parameters.Add(
								//	new MySqlParameter("m_contract_id", OneAccount.m_contract_id));
								//cmd.Parameters.Add(
								//	new MySqlParameter("google_account", OneAccount.google_account));
								cmd.Parameters.Add(
									new MySqlParameter("client_id", gOAuthModel.client_id));
								cmd.Parameters.Add(
									new MySqlParameter("client_secret", gOAuthModel.client_secret));
								cmd.Parameters.Add(
									new MySqlParameter("project_id", gOAuthModel.project_id));
								//**ログインユーザーに要書き換え*********************//
								cmd.Parameters.Add(
									new MySqlParameter("updated_user", OneAccount.m_contract_id));
								//*********************ログインユーザーに要書き換え**//
								cmd.Parameters.Add(
									new MySqlParameter("updated_at", DateTime.Now));
								// オープン
								cmd.Connection.Open();
								// 実行
								cmd.ExecuteNonQuery();
								// クローズ
								cmd.Connection.Close();
								dbMsg += " >>書き込み終了";
								ConnectBody();
							}
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
		/// UserCredentialを作成する
		/// 初回アクセス時に使用するAPIをScopesで申請する
		/// </summary>
		/// <returns>UserCredential</returns>
		private async Task<UserCredential> MakeAllCredentialAsync()
		{
			string TAG = "MakeAllCredentialAsync";
			string dbMsg = "";
			UserCredential userCedential = null;
			try {
				ClientSecrets clientSecrets = new ClientSecrets();
				dbMsg += ",clientId=" + OneAccount.client_id;
				clientSecrets.ClientId = OneAccount.client_id;
				dbMsg += ",clientSecret=" + OneAccount.client_secret;
				clientSecrets.ClientSecret = OneAccount.client_secret;
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



		//////////////////////////////////////////////////登録//
		#region CancelCommand　　接続
		private ViewModelCommand _ConnectCommand;

		public ViewModelCommand ConnectCommand {
			get {
				if (_ConnectCommand == null) {
					_ConnectCommand = new ViewModelCommand(Connect);
				}
				return _ConnectCommand;
			}
		}

		/// <summary>
		/// 接続前の状況確認
		/// </summary>
		public void Connect()
		{
			string TAG = "Connect";
			string dbMsg = "";
			try {
				dbMsg += ",client_id=" + OneAccount.client_id;
				if (OneAccount.client_id == null || OneAccount.client_id.Equals("")) {
					dbMsg += ",JsonReadへ";
					JsonRead();
				} else {
					dbMsg += ",接続へ";
					ConnectBody();
				}
				Constant.RootFolderID = GDriveUtil.MakeAriadneGoogleFolder();
				if (Constant.RootFolderID.Equals("")) {
					dbMsg += ">フォルダ作成>失敗";
				} else {
					dbMsg += "[" + Constant.RootFolderID + "]" + Constant.RootFolderName;
				}
				MyLog(TAG, dbMsg);
				Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 接続開始
		/// </summary>
		public void ConnectBody()
		{
			string TAG = "ConnectBody";
			string dbMsg = "";
			try {
				dbMsg += ",client_id=" + OneAccount.client_id;
				Controls.WaitingDLog progressWindow = new Controls.WaitingDLog();
				progressWindow.Show();
				progressWindow.SetMes("Googleサービス接続中...");
				Task<UserCredential> userCredential = Task.Run(() => {
					return MakeAllCredentialAsync();
				});
				userCredential.Wait();

				progressWindow.Close();

				Constant.MyDriveCredential = userCredential.Result;                           //作成結果が格納され戻される
				if (Constant.MyDriveCredential == null) {
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

				ConnectVisibility = "Hidden";
				RaisePropertyChanged("ConnectVisibility");
				CancelVisibility = "Visible";
				RaisePropertyChanged("CancelVisibility");
				Constant.RootFolderID = GDriveUtil.MakeAriadneGoogleFolder();
				if (Constant.RootFolderID.Equals("")) {
					dbMsg += ">フォルダ作成>失敗";
				} else {
					dbMsg += "[" + Constant.RootFolderID + "]" + Constant.RootFolderName;
				}
				MyLog(TAG, dbMsg);
				Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		#endregion

		#region CancelCommand　　解除
		private ViewModelCommand _CancelCommand;

		public ViewModelCommand CancelCommand {
			get {
				if (_CancelCommand == null) {
					_CancelCommand = new ViewModelCommand(Cancel);
				}
				return _CancelCommand;
			}
		}

		public void Cancel()
		{
			string TAG = "Cancel";
			string dbMsg = "";
			try {
				dbMsg += ";Token" + Constant.MyDriveCredential.Token.ToString();
				Constant.MyDriveService = null;
				Constant.MyCalendarService = null;
				dbMsg += "\r\n>>" + Constant.MyDriveCredential.Token.ToString();
				MyLog(TAG, dbMsg);
				ConnectVisibility = "Visible";
				RaisePropertyChanged("ConnectVisibility");
				CancelVisibility = "Hidden";
				RaisePropertyChanged("CancelVisibility");
				RaisePropertyChanged();
		//		Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}
		#endregion

		//Livet Messenger用///////////////////////
		new public void Dispose()
		{
			// 基本クラスのDispose()でCompositeDisposableに登録されたイベントを解放する。
			base.Dispose();
			Dispose(true);
		}
		///////////////////////Livet Messenger用//
		public static void MyLog(string TAG, string dbMsg)
		{
			dbMsg = "[" + MethodBase.GetCurrentMethod().Module.Name+ "]" + dbMsg;
			//dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
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

	}
}