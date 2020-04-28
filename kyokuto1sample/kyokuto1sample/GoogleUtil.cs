using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace kyokuto1sample {
	class GoogleUtil {
		public String parentFolderId;
		public IList<Google.Apis.Drive.v3.Data.File> GDriveFiles;
		public IDictionary<string, Google.Apis.Drive.v3.Data.File> GDriveFolders;

		public void GoogleFileListUp()
		{
			string TAG = "GoogleFileSarch";
			string dbMsg = "[GoogleUtil]";
			try {
			/*
				// リクエストパラメータの定義	https://qiita.com/nori0__/items/dd5bbbf0b09ad58e40be
				FilesResource.ListRequest listRequest = Constant.MyDriveService.Files.List();
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
							info_lb.Text = fName;                                           //照合が合っているか確認の為
						} else if (fMimeType.Equals("application/vnd.google-apps.folder")) {
							GDriveFolders.Add(fId, file);                                           //最上位以外のフォルダを格納
						}
					}
					dbMsg += "[top=" + Constant.TopFolderID + "]";
					dbMsg += "[root=" + Constant.RootFolderID + "]";
					dbMsg += ",folders" + GDriveFolders.Count() + "件";
					int nodeCount = 0;
					google_drive_tree.Nodes.Clear();                    //viewを初期化して
					google_drive_tree.BeginUpdate();                    //	更新開始
					foreach (var folder in GDriveFolders) {
						dbMsg += "\r\nfolder=" + folder.Key;
						dbMsg += ":" + folder.Value.Name;
						dbMsg += ":" + folder.Value.Parents[0];
						if (folder.Value.Parents[0].Equals(Constant.TopFolderID)) {
							google_drive_tree.Nodes.Add(folder.Value.Name);
							foreach (var file in GDriveFiles) {
								String PId = file.Parents[0];
								if (folder.Key.Equals(PId)) {
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
						} else {
							dbMsg += ">>除外";
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
				*/
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		//フォルダを作る
		public  async Task<File> CreateFolder(string name, string parentFolderId = null)
		{
			string TAG = "CreateFolder";
			string dbMsg = "[GoogleUtil]";
			File newFolder = new File();
			try {
				dbMsg += "[" + parentFolderId + "]" + name;
				File meta = new File();
				meta.Name = name;
				meta.MimeType = "application/vnd.google-apps.folder";
				if (parentFolderId != null) meta.Parents = new List<string> { parentFolderId };
				var request = Constant.MyDriveService.Files.Create(meta);
				request.Fields = "id, name";
				newFolder = await request.ExecuteAsync();
				//	The service drive has thrown an exception: Google.GoogleApiException: Google.Apis.Requests.RequestError
				//	Insufficient Permission: Request had insufficient authentication scopes. [403]
				dbMsg += ">>[" + newFolder.Id + "]" + newFolder.Name;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return newFolder;
		}

		////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg);
		}
	}

}
