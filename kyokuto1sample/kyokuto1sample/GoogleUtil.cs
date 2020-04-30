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

		/// <summary>
		/// GoogleDriveの登録状況表示
		/// </summary>
		/// <returns></returns>
		public IList<Google.Apis.Drive.v3.Data.File> GDFileListUp()
		{
			string TAG = "GDFileListUp";
			string dbMsg = "[GoogleUtil]";
			IList<Google.Apis.Drive.v3.Data.File> retList = null;
			try {
				// リクエストパラメータの定義	https://qiita.com/nori0__/items/dd5bbbf0b09ad58e40be
				FilesResource.ListRequest listRequest = Constant.MyDriveService.Files.List();
				listRequest.PageSize = 12;						//返される共有ドライブの最大数。許容値は1〜100です。（デフォルト：10）
																				//※19で表示されなくなった
				listRequest.Q = "trashed = false";			// ゴミ箱は検索しない
				listRequest.Fields = "nextPageToken, files(id, name, createdTime, mimeType,modifiedTime,parents,trashed,size)";
				//		GDriveFiles.Clear();						//newが使えない？
				retList = listRequest.Execute().Files;            // ドライブ内容のリストアップ
				dbMsg = "," + retList.Count() +  "件";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retList;
		}

		/// <summary>
		/// フォルダを作る
		/// </summary>
		/// <param name="name">表示される名前</param>
		/// <param name="parentFolderId">作成する位置</param>
		/// <param name="driveId">できれば指定</param>
		/// <returns>作成したフォルダのID</returns>
		public async Task<string> CreateFolder(string name, string parentFolderId = null, string driveId = null)
		{
			string TAG = "CreateFolder";
			string dbMsg = "[GoogleUtil]";
			string retStr = null;
			File newFolder = new File();
			try {
				dbMsg += "[" + driveId + "][" + parentFolderId + "]" + name;
				var folder = await FindByName(name, SearchFilter.FOLDER);
				if(folder == null) {
					File meta = new File();
					meta.Name = name;
					meta.MimeType = "application/vnd.google-apps.folder";
					//			if (driveId != null) meta.DriveId = driveId;
					if (parentFolderId != null) meta.Parents = new List<string> { parentFolderId };
					dbMsg += ",meta=" + meta.Parents[0];
					var request = Constant.MyDriveService.Files.Create(meta);
					request.Fields = "id, name";
					dbMsg += ",request=" + request.MethodName;
					newFolder = await request.ExecuteAsync();
					retStr = newFolder.Id;
					dbMsg += ">>[" + retStr + "]" + newFolder.Name;
				}else{
					retStr = folder.Id;
					dbMsg += ">既存>[" + retStr + "]" + newFolder.Name;
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
			}
			return retStr;
		}

		/// <summary>
		/// ファイルを一つ登録する
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="parentId"></param>
		/// <returns></returns>
		public async Task<string> UploadFile(string filePath, string parentId)
		{
			string TAG = "UploadFile";
			string dbMsg = "[GoogleUtil]";
			string retStr = null;
			File newFile = new File();
			try {
				dbMsg += "[" + parentId + "]" + filePath;
				LocalFileUtil LFUtil = new LocalFileUtil();
				String MimeStr = LFUtil.GetMimeType(filePath);
				dbMsg += ",Mime=" + MimeStr;
				var meta = new File() {
					Name = System.IO.Path.GetFileName(filePath),
					MimeType = MimeStr,
					Parents = new List<string> { parentId }
				};
				using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open)) {
					// 新規追加
					var request = Constant.MyDriveService.Files.Create(meta, stream, MimeStr);
					request.Fields = "id, name";
					newFile = (File)await request.UploadAsync();
					retStr = newFile.Id;            //※作成したファイルID
					dbMsg += ">>" + retStr;
					MyLog(TAG, dbMsg);
					return retStr;
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
			}
		}

		public async Task<File> DelteItem(string itemName)
		{
			string TAG = "DelteItem";
			string dbMsg = "[GoogleUtil]";
			try {
				dbMsg += itemName;
				string fileId = "";

				if(fileId.Equals("")) {
					return null;
				}else{
					var request = Constant.MyDriveService.Files.Delete(fileId);
					var result = await request.ExecuteAsync();
				}
				MyLog(TAG, dbMsg);
				return null;
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
			}
		}

		/// <summary>
		/// フォルダもしくはファイル名称で検索
		/// </summary>
		/// <param name="name"></param>
		/// <param name="filter"></param>
		/// <returns></returns>
		public static async Task<File> FindByName(string name, SearchFilter filter = SearchFilter.NONE)
		{
			string TAG = "FindByName";
			string dbMsg = "[GoogleUtil]";
			File newFolder = new File();
			try {
				dbMsg = "name=" + name;
				var queries = new List<string>() { $"name = '{ name }'" };
				if (filter != SearchFilter.NONE) queries.Add(filter.ToQuery());
				MyLog(TAG, dbMsg);
				return await FindFile(queries);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
			}
		}

		/// <summary>
		/// ファイルを一件検索する
		/// </summary>
		/// <param name="queries"></param>
		/// <returns></returns>
		public static async Task<File> FindFile(List<string> queries)
		{
			string TAG = "FindFile";
			string dbMsg = "[GoogleUtil]";
			File newFolder = new File();
			try {
				dbMsg = "queries=" + queries.ToString();
				var result = await FindFilesCore(queries);
				MyLog(TAG, dbMsg);
				return (result.Count > 0) ? result[0] : null;
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
			}
		}

		/// <summary>
		/// リストで渡されたファイルを検索する
		/// </summary>
		/// <param name="queries"></param>
		/// <param name="fileFields"></param>
		/// <returns>List<File></returns>
		public static async Task<List<File>> FindFiles(List<string> queries, string fileFields)
		{
			string TAG = "FindFiles";
			string dbMsg = "[GoogleUtil]";
			try {
				dbMsg = "queries=" + queries.ToString();
				dbMsg = "fileFields=" + fileFields;
				MyLog(TAG, dbMsg);
				return await FindFilesCore(queries, $"nextPageToken, files({fileFields})");
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
			}
		}

		/// <summary>
		/// ファイル検索の本体
		/// </summary>
		/// <param name="queries"></param>
		/// <param name="fields"></param>
		/// <returns></returns>
		static async Task<List<File>> FindFilesCore(List<string> queries, string fields = "nextPageToken, files(id, name)")
		{
			string TAG = "FindFilesCore";
			string dbMsg = "[GoogleUtil]";
			try {
				dbMsg = "queries=" + queries.ToString();
				dbMsg = "fields=" + fields;
				string nextPageToken = null;
				queries.Add("trashed = false");

				do {
					FilesResource.ListRequest request = Constant.MyDriveService.Files.List();
					request.PageToken = nextPageToken;
					request.Q = queries.ToQuery();
					request.Fields = fields;
					var result = await request.ExecuteAsync();
					if (result.Files.Count > 0) return result.Files.ToList();
					nextPageToken = result.NextPageToken;
				} while (!string.IsNullOrEmpty(nextPageToken));
				MyLog(TAG, dbMsg);
				return new List<File>();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return new List<File>();
			}

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

	//	https://github.com/iwatuki/JuscoBot から
	public enum SearchFilter {
		/// <summary>フィルターなし</summary>
		NONE,
		/// <summary>フォルダのみ</summary>
		FOLDER,
		/// <summary>ファイルのみ</summary>
		FILE,
	}

	internal static class GoogleDriveQueryExt {
		public const string IGNORE_TRASH = "trashed = false";

		static List<string> queries = new List<string> {
			null,
			"mimeType = 'application/vnd.google-apps.folder'", // フォルダのみ
			"mimeType != 'application/vnd.google-apps.folder'", // ファイルのみ
		};

		public static string ToQuery(this SearchFilter type)
		{
			return queries[(int)type];
		}

		public static string ToQuery(this List<string> queries)
		{
			//while(queries.Contains("")) queries.Remove("");
			//while (queries.Contains(null)) queries.Remove(null);
			return string.Join(" and ", queries);
		}
	}

}
/*
 https://toconakis.tech/google-drive-rest-api-v3-for-android/
 https://csharp.hotexamples.com/examples/Google.Apis.Drive.v3.Data/File/-/php-file-class-examples.html
.NET Quickstart		 https://developers.google.com/drive/api/v3/quickstart/dotnet
 
 
 */
