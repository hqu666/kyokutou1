using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace kyokuto1sample {
	public partial class Form1 : Form {
		public UserCredential MyCredential;
		public DriveService MyDriveService;        // Drive API service
		public IList<Google.Apis.Drive.v3.Data.File> GDriveFiles;
		public IDictionary<string, Google.Apis.Drive.v3.Data.File> GDriveFolders;
		static string[] MyScopes = {DriveService.Scope.DriveFile,
							DriveService.Scope.Drive,
							 DriveService.Scope.DriveAppdata,
							//		  DriveService.Scope.DriveMetadataReadonly,
								  DriveService.Scope.DriveReadonly,
							DriveService.Scope.DriveScripts
							};

		public String parentFolderId;
		public Form1()
		{
			string TAG = "Form1";
			string dbMsg = "[Form1]";
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string TAG = "Form1_Load";
			string dbMsg = "[Form1]";
			try {
				Conect2Drive();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		// 接続
		private void Conect2Drive()
		{
			string TAG = "Conect2Drive";
			string dbMsg = "[Form1]";
			try {
				using (FileStream stream =
					new FileStream("client1sampl.json", FileMode.Open, FileAccess.Read)) {
					string credPath = "token.json";
					MyCredential = GoogleWebAuthorizationBroker.AuthorizeAsync(
						GoogleClientSecrets.Load(stream).Secrets,
						MyScopes,
						"user",
						CancellationToken.None,
						new FileDataStore(credPath, true)).Result;
				}
				string UserId = MyCredential.UserId;          //"usre"
				dbMsg += ",UserId=" + UserId;

				// Drive API serviceを作成
				MyDriveService = new DriveService(new BaseClientService.Initializer() {
					HttpClientInitializer = MyCredential,
					ApplicationName = Constant.ApplicationName,
					ApiKey = Constant.APIKey,
				});
				MyLog(TAG, dbMsg);
				GoogleFileListUp();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		// 更新ボタン
		private void Update_bt_Click(object sender, EventArgs e)
		{
			string TAG = "Update_bt_Click";
			string dbMsg = "[Form1]";
			try {
				if(MyCredential == null || MyDriveService == null) {
					String titolStr = Constant.ApplicationName;
					String msgStr = "まだ接続されていません";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
				GoogleFileListUp();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void GoogleFileListUp()
		{
			string TAG = "GoogleFileSarch";
			string dbMsg = "[Form1]";
			try {
				// リクエストパラメータの定義	https://qiita.com/nori0__/items/dd5bbbf0b09ad58e40be
				FilesResource.ListRequest listRequest = MyDriveService.Files.List();
				listRequest.PageSize = 10;      //返される共有ドライブの最大数。許容値は1〜100です。（デフォルト：10）
				listRequest.Q = "trashed = false"; // 名前が file.txt に一致, ゴミ箱は検索しない
				listRequest.Fields = "nextPageToken, files(id, name, createdTime, mimeType,	modifiedTime,parents,trashed,size)";
				//		GDriveFiles.Clear();						//newが使えない？
						GDriveFiles = listRequest.Execute().Files;            // ドライブ内容のリストアップ
				GDriveFolders = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();

				if (GDriveFiles != null && GDriveFiles.Count > 0) {
					// フォルダIDの取得	;一行目にはフォルダ名/二行目以降はファイル情報
					parentFolderId = GDriveFiles.First().Id;
					String folderName = GDriveFiles.First().Name;
					//フォルダ階層の取得
					foreach (var file in GDriveFiles) {
						String fName = file.Name;
						String fId = file.Id;
						String PId = file.Parents[0];
						String fMimeType = file.MimeType;
						DateTime fModifiedTime = (DateTime)file.ModifiedTime;
						if (fName.Equals(Constant.TopFolderName)) {
							//最上位にするフォルダと
							Constant.TopFolderID = fId;
							Constant.RootFolderID = PId;
							info_lb.Text = fName;											//照合が合っているか確認の為
						} else if(fMimeType.Equals("application/vnd.google-apps.folder")) {
							GDriveFolders.Add(fId, file);											//最上位以外のフォルダを格納
						}
					}
					dbMsg += "[top=" + Constant.TopFolderID + "]";
					dbMsg += "[root=" + Constant.RootFolderID + "]";
					dbMsg += ",folders" + GDriveFolders.Count() + "件";
					int nodeCount = 0;
					google_drive_tree.Nodes.Clear();					//viewを初期化して
					google_drive_tree.BeginUpdate();					//	更新開始
					foreach (var folder in GDriveFolders) {
						dbMsg += "\r\nfolder=" + folder.Key;
						dbMsg += ":" + folder.Value.Name;
						dbMsg += ":" + folder.Value.Parents[0];
						if (folder.Value.Parents[0].Equals(Constant.TopFolderID)) {
							google_drive_tree.Nodes.Add(folder.Value.Name);
							foreach (var file in GDriveFiles) {
								String PId = file.Parents[0];
								if(folder.Key.Equals(PId)) {
									String fName = file.Name;
									String fId = file.Id;
									String fMimeType = file.MimeType;

									if (fMimeType.Equals("application/vnd.google-apps.folder")) {
									} else if (fMimeType.Equals("application/vnd.android.package-archive")) {
									} else if (file.Trashed == true) {
									} else if (file.Size == null) {
									} else {
										DateTime fModifiedTime = (DateTime)file.ModifiedTime;
										long fSize = (long)file.Size;
										google_drive_tree.Nodes[nodeCount].Nodes.Add(fName + "                          \t\t\t\t: " + fModifiedTime + "       \t\t\t: " + file.Size);
									}
								}
							}
							nodeCount++;
						} else{
							dbMsg += ">>除外" ;
						}
					}
					google_drive_tree.EndUpdate();
				} else {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					 String msgStr = "送信先ドライブには未だファイルが登録されていません";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		//https://stackoverrun.com/ja/q/10041674	//////////////////////////////////////////
		/*
	static Dictionary<string, Google.Apis.Drive.v3.Data.File> GDriveFiles = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();

			private static object AbsPath(Google.Apis.Drive.v3.Data.File file)
			{
				var name = file.Name;
				if(file.Parents != null) {
					if (file.Parents.Count() == 0) {
						return name;
					}
				}else{
					return name;
				}

				var path = new List<string>();

				while (true) {
					var parent = GetParent( file.Parents[0] );

					// Stop when we find the root dir
					if (parent.Parents == null || parent.Parents.Count() == 0) {
						break;
					}

					path.Insert( 0, parent.Name );
					file = parent;
				}

				path.Add( name );
				return path.Aggregate( (current, next) => Path.Combine( current, next ) );
			}

			private static Google.Apis.Drive.v3.Data.File GetParent(string id)
			{
				// Check cache
				if (GDriveFiles.ContainsKey( id )) {
					return GDriveFiles[id];
				}

				// Fetch file from drive
				var request = MyDriveService.Files.Get( id );
				request.Fields = "name,parents";
				var parent = request.Execute();

				// Save in cache
				GDriveFiles[id] = parent;

				return parent;
			}
				*/
		//////////////////////////////////////////   https://stackoverrun.com/ja/q/10041674	   //
		public String MakeFolderName = null;
		public String[] selectFiles = null;

		//ファイル選択ボタン
		private void Serect_bt_Click(object sender, EventArgs e)
		{
			string TAG = "Serect_bt_Click";
			string dbMsg = "[Form1]";
			try {
				DialogResult dr = openFileDialog1.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK) {
					String FolderPath = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
					System.IO.DirectoryInfo dirInfo = System.IO.Directory.GetParent(openFileDialog1.FileName);
					MakeFolderName = dirInfo.Name;
					pass_lv.Text = MakeFolderName;
					selectFiles = Directory.GetFiles(@FolderPath, "*");
					//			foreach (string str in selectFiles) {
					//				string filePath = Path.GetFileName( @str );
					//				fileNames = fileNames.a;
					//			}
					files_tb.Text = "";
					foreach (string str in selectFiles) {
						string fileName = Path.GetFileName(@str);
						files_tb.Text += fileName + "\r\n";
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}
		//		files_lb.Text = files_lb.Text + "\r\n" + "\r\n" + (selectFiles.Count().ToString) + "件";

		//送信ボタン
		private void Send_bt_Click(object sender, EventArgs e)
		{
			string TAG = "Send_bt_Click";
			string dbMsg = "[Form1]";
			try {
				GFilePutAsync();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		public async void GFilePutAsync()
		{
			string TAG = "GFilePutAsync";
			string dbMsg = "[Form1]";
			try {
				dbMsg += "書込むフォルダ＝" + MakeFolderName;
				if (MakeFolderName == null || selectFiles == null) {
					files_tb.Text = "送信するファイルを選択して下さい";
					return;
				}
				if (info_lb.Text.Equals("まずは接続ボタンをクリックして下さい")) {
					files_tb.Text = "接続ボタンをクリックしてGoogleドライブに接続して下さい";
					return;
				}
				/*		https://karlsnautr.blogspot.com/2013/01/cgoogle-drive.html	*/
				
				//フォルダを作る
				Google.Apis.Drive.v3.Data.File wrFolder = new Google.Apis.Drive.v3.Data.File();
				wrFolder.Name = MakeFolderName;
				wrFolder.Description = "極東産機案件";
				//フォルダなのでMimeTypeはこれ
				wrFolder.MimeType = "application/vnd.google-apps.folder";
				dbMsg += "、DriveId=" + Constant.RootFolderID;
				wrFolder.DriveId = Constant.RootFolderID;
				//アップロード
				wrFolder.Parents = new List<string> { Constant.TopFolderID }; // 特定のフォルダのサブフォルダとして作成する場合
				var wrRequest = MyDriveService.Files.Create(wrFolder);
				wrRequest.Fields = "id, name";                      // ただ作るだけならこの行不要,,v2ではTitle
				dbMsg += ",wrRequest=" + wrRequest.MethodName;
				//		MyDriveService.Files.Insert(wrFolder).Fetch();		v2の場合
				//var newFolder = wrRequest.Execute();
				var newFolder = await wrRequest.ExecuteAsync();
				dbMsg += ">>[" + newFolder.Id + "]" + newFolder.Name;

				//	The service drive has thrown an exception: Google.GoogleApiException: Google.Apis.Requests.RequestError
				//	Insufficient Permission: Request had insufficient authentication scopes. [403]
				
				dbMsg += "、" + selectFiles.Count() + "件";
				foreach (string str in selectFiles) {
					dbMsg += "\r\n" + str;

					//ファイルのひな形を作る感じ
					Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
					string fileName = Path.GetFileName(@str);
					body.Name = fileName;
					body.Description = "A test document";
					body.MimeType = "text/plain";                       // MimeMapping.GetMimeMapping( fileName );
					if (fileName.Contains(".xls")) {
						body.MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					} else if (fileName.Contains(".ppt")) {
						body.MimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
					} else if (fileName.Contains(".doc")) {
						body.MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
					} else if (fileName.Contains(".pdf")) {
						body.MimeType = "application / pdf";
					}
					//	https://webbibouroku.com/Blog/Article/asp-mimetype
					var fileMetadata = new Google.Apis.Drive.v3.Data.File() {
						Name = fileName
					};
					FilesResource.CreateMediaUpload request;
					using (var stream = new System.IO.FileStream(body.MimeType, System.IO.FileMode.Open)) {
						request = MyDriveService.Files.Create(fileMetadata, stream, body.MimeType);
						request.Fields = "id";
						request.Upload();
					}
					//System.IO.DirectoryNotFoundException: パス 'H:\develop\testBuild\kyokuto1sample\kyokuto1sample\bin\Debug\text\plain' の一部が見つかりませんでした。
					var wrfile = request.ResponseBody;
					String wrfileId = wrfile.Id;
					dbMsg += ">>[" + wrfileId + "]" + wrfile.Name;
					////ファイルの中身を書き込む…？
					//byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
					//System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

					////アップロードする
					//FilesResource.InsertMediaUpload request = MyDriveService.Files.Insert(body, stream, body.MimeType);
					//request.Upload();

					////アップロードされたファイルのIdを取得しておく
					//Google.Apis.Drive.v3.Data.File file = request.ResponseBody;
					//Console.WriteLine("File id: " + file.Id);
				}
				MyLog(TAG, dbMsg);
				GoogleFileListUp();						//更新状態を再描画
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}
		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg);

		}
	}


	/*
	 画面に表示されているデータに対して、自分のPCにあるファイルを添付するのですが、
	 それがサーバ上ではなく、Googleドライブのフォルダと関連付けて、そこにアップをするというイメージです。
例えば、画面に表示されている案件情報（管理番号：PR0001）にファイルを添付したい場合は、
Googleドライブ上に「KSクラウド/案件/PR0001」と言うフォルダを作って、クライアントの画面上にそのフォルダの中身を表示します。
そこに添付したいファイルをドラッグ＆ドロップしたら、Googleドライブ上にも同期をされてアップされると言った感じです。
Windows用のGoogleドライブアプリをインストールしたら、エクスプローラーに追加されるので、そのイメージが近いです。
	 

		AppProperties	null	System.Collections.Generic.IDictionary<string, string>
		Capabilities	null	Google.Apis.Drive.v3.Data.File.CapabilitiesData
		ContentHints	null	Google.Apis.Drive.v3.Data.File.ContentHintsData
		CopyRequiresWriterPermission	null	bool?
+		CreatedTime	{2020/04/23 9:35:45}	System.DateTime?
		CreatedTimeRaw	"2020-04-23T00:35:45.391Z"	string
		Description	null	string
		DriveId	null	string
		ETag	null	string
		ExplicitlyTrashed	null	bool?
		ExportLinks	null	System.Collections.Generic.IDictionary<string, string>
		FileExtension	null	string
		FolderColorRgb	null	string
		FullFileExtension	null	string
		HasAugmentedPermissions	null	bool?
		HasThumbnail	null	bool?
		HeadRevisionId	null	string
		IconLink	null	string
		Id	"1ufcBIbtN8OhA3Ho6mODw5MVS90u7O8QD"	string
		ImageMediaMetadata	null	Google.Apis.Drive.v3.Data.File.ImageMediaMetadataData
		IsAppAuthorized	null	bool?
		Kind	null	string
		LastModifyingUser	null	Google.Apis.Drive.v3.Data.User
		Md5Checksum	null	string
		MimeType	"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"	string
		ModifiedByMe	null	bool?
		ModifiedByMeTime	null	System.DateTime?
		ModifiedByMeTimeRaw	null	string
+		ModifiedTime	{2020/04/22 15:53:21}	System.DateTime?
		ModifiedTimeRaw	"2020-04-22T06:53:21.000Z"	string
		Name	"Googleドライブ連携.xlsx"	string
		OriginalFilename	null	string
		OwnedByMe	null	bool?
		Owners	null	System.Collections.Generic.IList<Google.Apis.Drive.v3.Data.User>
		Parents	null	System.Collections.Generic.IList<string>
		PermissionIds	null	System.Collections.Generic.IList<string>
		Permissions	null	System.Collections.Generic.IList<Google.Apis.Drive.v3.Data.Permission>
		Properties	null	System.Collections.Generic.IDictionary<string, string>
		QuotaBytesUsed	null	long?
		Shared	null	bool?
		SharedWithMeTime	null	System.DateTime?
		SharedWithMeTimeRaw	null	string
		SharingUser	null	Google.Apis.Drive.v3.Data.User
		ShortcutDetails	null	Google.Apis.Drive.v3.Data.File.ShortcutDetailsData
		Size	null	long?
		Spaces	null	System.Collections.Generic.IList<string>
		Starred	null	bool?
		TeamDriveId	null	string
		ThumbnailLink	null	string
		ThumbnailVersion	null	long?
		Trashed	false	bool?
		TrashedTime	null	System.DateTime?
		TrashedTimeRaw	null	string
		TrashingUser	null	Google.Apis.Drive.v3.Data.User
		Version	null	long?
		VideoMediaMetadata	null	Google.Apis.Drive.v3.Data.File.VideoMediaMetadataData
		ViewedByMe	null	bool?
		ViewedByMeTime	null	System.DateTime?
		ViewedByMeTimeRaw	null	string
		ViewersCanCopyContent	null	bool?
		WebContentLink	null	string
		WebViewLink	null	string
		WritersCanShare	null	bool?



	 */

}
