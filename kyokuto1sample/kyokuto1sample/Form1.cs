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

namespace kyokuto1sample
{
	public partial class Form1 : Form
	{
		static string[] Scopes = { DriveService.Scope.DriveReadonly };
		static string ApplicationName = "kyokuto1sample";
		//	クライアント ID					1015531776934-6lgfgndk2o2lp5iu29ddaabqrfn1ibp2.apps.googleusercontent.com
		// クライアント シークレット	A_rjdDTUrpxgWbPTDDUMq_7K
		// 自分の API キー						AIzaSyBgQfaxlfQXP32-W8rRmGfj8nDf8vlSCxs
		public DriveService service ;        // Drive API service
		public String parentFolderId;
		public IList<Google.Apis.Drive.v3.Data.File> files;
	
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}
		//接続ボタン
		private void Conect_bt_Click(object sender, EventArgs e)
		{
			UserCredential credential;

			using (FileStream stream =
				new FileStream( "client1sampl.json", FileMode.Open, FileAccess.Read )) {
				string credPath = "token.json";
				credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load( stream ).Secrets,
					Scopes,
					"user",
					CancellationToken.None,
					new FileDataStore( credPath, true ) ).Result;
			}

			// Drive API serviceを作成
			service = new DriveService( new BaseClientService.Initializer() {
				HttpClientInitializer = credential,
				ApplicationName = ApplicationName,
			} );

			//GDFileListUpAsync();

			// リクエストパラメータの定義	https://qiita.com/nori0__/items/dd5bbbf0b09ad58e40be
			FilesResource.ListRequest listRequest = service.Files.List();
			listRequest.PageSize = 10;      //返される共有ドライブの最大数。許容値は1〜100です。（デフォルト：10）
			listRequest.Q = "trashed = false"; // 名前が file.txt に一致, ゴミ箱は検索しない
			listRequest.Fields = "nextPageToken, files(id, name, createdTime, mimeType,	modifiedTime,parents,trashed,size)";
			files = listRequest.Execute().Files;            // ドライブ内容のリストアップ

			if (files != null && files.Count > 0) {
				// フォルダIDの取得	;一行目にはフォルダ名/二行目以降はファイル情報
				parentFolderId = files.First().Id;
				String folderName = files.First().Name;
				info_lb.Text = folderName;
				drives_tb.Text = "";
				foreach (var file in files) {
					//GDInf( file );
					String fMimeType = file.MimeType;
					String fName = file.Name;
					DateTime fModifiedTime =  ( DateTime ) file.ModifiedTime;
			//		String fInfo = "::" + file.ModifiedByMe.ToString() + "," + file.ModifiedTime.ToString() + "," + file.Trashed.ToString() + "," + file.Size;
					if (fMimeType.Equals( "application/vnd.google-apps.folder" )) {
					} else if (fMimeType.Equals( "application/vnd.android.package-archive" )) {
					} else if (file.Trashed == true) {
					} else if (file.Size == null) {
					} else {
						long fSize = ( long ) file.Size;
						drives_tb.Text += fName  + "\t\t\t: " + fModifiedTime + " \t \t: " + fSize + " \r\n";
					}
					//var absP = AbsPath( file );
					//drives_tb.Text += AbsPath( file ) + " \r\n" + " \r\n";
				}

				drives_tb.Text += " \r\n";
				foreach (var file in files) {           //サブフォルダ
					String fMimeType = file.MimeType;
					String fName = file.Name;
					if (fMimeType.Equals( "application/vnd.google-apps.folder" )) {
						if (fName.Equals( "MPChartExample" )) {
						} else if (fName.Equals( folderName )) {
						} else {
							String fInfo = file.MimeType + "::;" + file.Name;
							drives_tb.Text += fName + " \r\n ";
						}
					}
				}
			} else {
				drives_tb.Text = "送信先ドライブには未だファイルが登録されていません";
			}
			
		}

		public async void GDFileListUpAsync()
		{
			string nextPageToken = null;
			drives_tb.Text = " ";
			do {
				FilesResource.ListRequest request = service.Files.List();
				request.PageToken = nextPageToken;
				request.Q = "trashed = false"; // 名前が file.txt に一致, ゴミ箱は検索しない
				request.Fields = "nextPageToken, files(id, name)";
				var result = await request.ExecuteAsync();
				if (result.Files.Count > 0)
					drives_tb.Text += result.Files[0] + " \r\n";
				nextPageToken = result.NextPageToken;
			} while (!string.IsNullOrEmpty( nextPageToken ));
		}

		public void GDInf(Google.Apis.Drive.v3.Data.File file)
		{
				String fMimeType = file.MimeType;
				String fName = file.Name;
				//String fInfo = "::" + file.ModifiedByMe.ToString() + "," + file.ModifiedTime.ToString() + "," + file.Trashed.ToString() + "," + file.Size;

				if (fMimeType.Equals( "application/vnd.google-apps.folder" )) {
					//GDInf( file );
				} else if (fMimeType.Equals( "application/vnd.android.package-archive" )) {
				} else {
					drives_tb.Text += fName + " \r\n";
				}

				//var absP = AbsPath( file );
				//drives_tb.Text += AbsPath( file ) + " \r\n" + " \r\n";

		}
		/**
		 常に　Kind ; folder,drive , file.GetType() ：Google.Apis.Drive.v3.Data.File
		取得できない　Trashed , TrashedTime , Parents
			 
		 */

		//https://stackoverrun.com/ja/q/10041674	//////////////////////////////////////////
		/*
	static Dictionary<string, Google.Apis.Drive.v3.Data.File> files = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();

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
				if (files.ContainsKey( id )) {
					return files[id];
				}

				// Fetch file from drive
				var request = service.Files.Get( id );
				request.Fields = "name,parents";
				var parent = request.Execute();

				// Save in cache
				files[id] = parent;

				return parent;
			}
				*/
		//////////////////////////////////////////   https://stackoverrun.com/ja/q/10041674	   //

		public String MakeFolderName = null;
		public String[] selectFiles = null;

		//ファイル選択ボタン
		private void Serect_bt_Click(object sender, EventArgs e)
		{
			DialogResult dr = openFileDialog1.ShowDialog();
			if (dr == System.Windows.Forms.DialogResult.OK) {
				String FolderPath = System.IO.Path.GetDirectoryName( openFileDialog1.FileName );
				System.IO.DirectoryInfo dirInfo = System.IO.Directory.GetParent( openFileDialog1.FileName );
				MakeFolderName = dirInfo.Name;
				pass_lv.Text = MakeFolderName;
				selectFiles = Directory.GetFiles( @FolderPath, "*" );
	//			foreach (string str in selectFiles) {
	//				string filePath = Path.GetFileName( @str );
	//				fileNames = fileNames.a;
	//			}
				files_tb.Text = "";
				foreach (string str in selectFiles) {
					string fileName = Path.GetFileName( @str );
					files_tb.Text += fileName + "\r\n";
				}
			}
		}
		//		files_lb.Text = files_lb.Text + "\r\n" + "\r\n" + (selectFiles.Count().ToString) + "件";


		//送信ボタン
		private void Send_bt_Click(object sender, EventArgs e)
		{
			GFilePutAsync();
		}

		public async void GFilePutAsync()
		{
			if(MakeFolderName == null || selectFiles == null) {
				files_tb.Text = "送信するファイルを選択して下さい";
				return;
			}
			if(info_lb.Text.Equals( "まずは接続ボタンをクリックして下さい" )){
				files_tb.Text = "接続ボタンをクリックしてGoogleドライブに接続して下さい";
				return;
			}

			/*https://karlsnautr.blogspot.com/2013/01/cgoogle-drive.html	*/
			//フォルダを作る
			Google.Apis.Drive.v3.Data.File folder = new Google.Apis.Drive.v3.Data.File();
			folder.Name = MakeFolderName;
			folder.Description = "my folder description";
			//フォルダなのでMimeTypeはこれ
			folder.MimeType = "application/vnd.google-apps.folder";
			//アップロード
			folder.Parents = new List<string> { parentFolderId }; // 特定のフォルダのサブフォルダとして作成する場合
			var request = service.Files.Create( folder );
			request.Fields = "id, name"; // ただ作るだけならこの行不要
			var file = await request.ExecuteAsync();


		/*
						Console.WriteLine("folder id : " + file.Id);

						foreach (string str in selectFiles) {
							//ファイルのひな形を作る感じ
							Google.Apis.Drive.v3.Data.File body = new Google.Apis.Drive.v3.Data.File();
							string fileName = Path.GetFileName( @str );
							body.Name = fileName;
							body.Description = "A test document";
							body.MimeType = "text/plain";                       // MimeMapping.GetMimeMapping( fileName );
							if (fileName.Contains( ".xls" )) {
								body.MimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
							} else if (fileName.Contains( ".ppt" )) {
								body.MimeType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
							} else if(fileName.Contains( ".doc" )) {
								body.MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
							} else if (fileName.Contains( ".pdf" )) {
								body.MimeType = "application / pdf";
							}
							//	https://webbibouroku.com/Blog/Article/asp-mimetype

							//ファイルの中身を書き込む…？
							byte[] byteArray = System.IO.File.ReadAllBytes( fileName );
							System.IO.MemoryStream stream = new System.IO.MemoryStream( byteArray );

							//アップロードする
							FilesResource.InsertMediaUpload request =service.Files.Insert( body, stream, body.MimeType );
							request.Upload();

							//アップロードされたファイルのIdを取得しておく
							Google.Apis.Drive.v3.Data.File file = request.ResponseBody;
							Console.WriteLine( "File id: " + file.Id );

							*/
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
