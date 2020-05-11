using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;

namespace kyokuto4calender {
	class GoogleDriveUtil {


		/// <summary>
		/// 指定されたフォルダ以下の全フォルダ取得
		/// passTreeに使用
		/// </summary>
		/// <param name="pFolder"></param>
		/// <returns></returns>
		public IList<Google.Apis.Drive.v3.Data.File> GDFolderListUp()
		{
			string TAG = "GDFolderListUp";
			string dbMsg = "[GoogleDriveUtil]";
			string pFolder = Constant.RootFolderName;
			IList<Google.Apis.Drive.v3.Data.File> retList = null;
			try {
	//			Constant.CurrentFolder = pFolder;
				// フォルダIDの取得
				FilesResource.ListRequest listRequest = Constant.MyDriveService.Files.List();
				listRequest.PageSize = 1;   // 取得するフォルダの条件をクエリ構文で指定
				listRequest.Q = "(name = '" + pFolder + "') and (mimeType = 'application/vnd.google-apps.folder') and (trashed = false)";
				listRequest.Fields = "nextPageToken, files(id)";

				var folderId = listRequest.Execute().Files.First().Id;
				dbMsg += "[" + folderId + "]" + pFolder;
				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => GDFolderListUpAsyncBody( pFolder));
				IList<Google.Apis.Drive.v3.Data.File> pFolders = rFolders.Result;
				if (pFolders != null && pFolders.Count > 0) {
					dbMsg += "の直下に" + pFolders.Count + "件" ;
					foreach (var folder in pFolders) {
						retList.Add(folder);
						string folderName = folder.Name;
						dbMsg += "\r\n" + retList.Count + ")" + folderName;
						Task<IList<Google.Apis.Drive.v3.Data.File>> rr = Task.Run(() => GDFolderListUpAsyncBody(folderName));
						IList<Google.Apis.Drive.v3.Data.File> rrFolders = rr.Result;
					}
				} else {
					dbMsg += "の直下にフォルダは有りません";
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retList;
		}

		public async Task<IList<File>> GDFolderListUpAsyncBody(string pFolder)
		{
			string TAG = "GDFolderListUpAsyncBody";
			string dbMsg = "[GoogleDriveUtil]";
			IList<Google.Apis.Drive.v3.Data.File> retList = new List<Google.Apis.Drive.v3.Data.File> ();
			try {
				dbMsg += ",pFolder=" + pFolder;
				Constant.CurrentFolder = pFolder;
				// フォルダIDの取得
				FilesResource.ListRequest listRequest = Constant.MyDriveService.Files.List();
				listRequest.PageSize = 1;   // 取得するフォルダの条件をクエリ構文で指定
				listRequest.Q = "(name = '" + pFolder + "') and (mimeType = 'application/vnd.google-apps.folder') and (trashed = false)";
				listRequest.Fields = "nextPageToken, files(id)";

				var folderId = listRequest.Execute().Files.First().Id;
				dbMsg += "[" + folderId + "]";
				// フォルダの内容
				listRequest = Constant.MyDriveService.Files.List();
				listRequest.PageSize = 12;                      //返される共有ドライブの最大数。許容値は1〜100です。（デフォルト：10）
																//※19で表示されなくなった
				listRequest.Q = $"('{folderId}' in parents) and (trashed = false) and (mimeType = 'application/vnd.google-apps.folder')";
				listRequest.OrderBy = "name";
				listRequest.Fields = "nextPageToken, files(id, name,modifiedTime,size,parents,trashed, mimeType,webContentLink)";
				FileList ret = await listRequest.ExecuteAsync();
				if (ret != null) {
					int fCount = ret.Files.Count();
					if (0 < fCount ) {
						dbMsg += "の直下に" + fCount + "件";
						foreach (var folder in ret.Files) {
							string folderName = folder.Name;
							dbMsg += "\r\n" + retList.Count + ")" + folderName;
							retList.Add(folder);
							//Task<IList<File>> rr = GDFolderListUpAsyncBody(folderName);
							//if(rr == null) {
							//	return retList;
							//}
							////Task<IList<Google.Apis.Drive.v3.Data.File>> rr = Task.Run(() => GDFolderListUpAsyncBody(folderName));
							////IList<Google.Apis.Drive.v3.Data.File> rrFolders = rr.Result;

						}
					} else {
						dbMsg += "の直下にフォルダは有りません";
			//			return retList;
					}
				}
				dbMsg = ">>" + retList.Count() + "件";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retList;
		}

		/// <summary>
		/// 対象フォルダ内の登録状況表示
		/// </summary>
		/// <returns></returns>
		public IList<Google.Apis.Drive.v3.Data.File> GDFileListUp(string pFolder ,bool isOnlyFolder)
		{
			string TAG = "GDFileListUp";
			string dbMsg = "[GoogleDriveUtil]";
			IList<Google.Apis.Drive.v3.Data.File> retList = null;
			try {
				dbMsg += ",pFolder=" + pFolder;
				Constant.CurrentFolder = pFolder;
				// フォルダIDの取得
				FilesResource.ListRequest listRequest = Constant.MyDriveService.Files.List();
				listRequest.PageSize = 1;   // 取得するフォルダの条件をクエリ構文で指定
				listRequest.Q = "(name = '" + pFolder + "') and (mimeType = 'application/vnd.google-apps.folder') and (trashed = false)";
				listRequest.Fields = "nextPageToken, files(id)";
				var folderId = listRequest.Execute().Files.First().Id;
				dbMsg += "[" + folderId + "]";
				// フォルダの内容
				listRequest = Constant.MyDriveService.Files.List();
				listRequest.PageSize = 12;                      //返される共有ドライブの最大数。許容値は1〜100です。（デフォルト：10）
																//※19で表示されなくなった
				listRequest.Q = $"('{folderId}' in parents) and (trashed = false)";
				if (isOnlyFolder) {
					listRequest.Q += " and (mimeType = 'application/vnd.google-apps.folder')";
				}
				listRequest.OrderBy = "name";
				listRequest.Fields = "nextPageToken, files(id, name,modifiedTime,size,parents,trashed, mimeType,webContentLink)";
				IList<Google.Apis.Drive.v3.Data.File> ret = listRequest.Execute().Files;
				if (ret != null) {
					retList = ret;
					dbMsg = "," + retList.Count() + "件";
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retList;
		}

		/// <summary>
		/// フォルダを作り、IDを返す
		/// 既に同名フォルダが有ればIDを返す
		/// </summary>
		/// <param name="name">表示される名前</param>
		/// <param name="parentFolderId">作成する位置</param>
		/// <param name="driveId">できれば指定</param>
		/// <returns>作成したフォルダのID</returns>
		public async Task<string> CreateFolder(string name, string parentFolderId = null, string driveId = null)
		{
			string TAG = "CreateFolder";
			string dbMsg = "[GoogleDriveUtil]";
			string retStr = null;
			File newFolder = new File();
			try {
				dbMsg += "[" + driveId + "][" + parentFolderId + "]" + name;
				Task<string> folder = Task<string>.Run(() => FindByName(name, SearchFilter.FOLDER));
				string folderId = folder.Result;
				//	var folder = await FindByName(name, SearchFilter.FOLDER);
				if (folderId == null) {
					File meta = new File();
					meta.Name = name;
					meta.MimeType = "application/vnd.google-apps.folder";
					if (parentFolderId == null || parentFolderId.Equals("")) {
						folder = Task<string>.Run(() => FindByName(Constant.TopFolderName, SearchFilter.FOLDER));
						parentFolderId = folder.Result;
						dbMsg += ",parentFolder[" + parentFolderId + "]"+ Constant.TopFolderName  + "を作成";
					}else{

					}
					meta.Parents = new List<string> { parentFolderId }; //特定のフォルダのサブフォルダ
					dbMsg += ",meta=" + meta.Parents[0];
					var request = Constant.MyDriveService.Files.Create(meta);
					dbMsg += ",request=" + request.MethodName;
					newFolder = await request.ExecuteAsync();
					retStr = newFolder.Id;
					dbMsg += ">>[" + retStr + "]" + newFolder.Name;
				} else {
					retStr = folderId;
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
		/// <param name="fileName">単独のファイル名</param>
		/// <param name="filePath">PC上のフルパス</param>
		/// <param name="parentId">書込み先のフォルダID</param>
		/// <returns>作成したファイルのID</returns>
		public string UploadFile(string fileName, string filePath, string parentId)
		{
			string TAG = "UploadFile";
			string dbMsg = "[GoogleDriveUtil]";
			string retStr = null;
			try {
				//検索して同じファイルが無い事を確認
				File rParent = FindById(parentId);
				string parentName = rParent.Name;
				dbMsg += "[" + parentName + "]" + fileName + "(" + filePath + ")";
				Task<File> tFile = Task<string>.Run(() => {
					return FindByNameParent(fileName, parentName);
				});
				tFile.Wait();
				File targetF = tFile.Result;
				string fileId = targetF.Id;
				if (fileId != null) {
					dbMsg += ",削除[" + fileId + "]";
					//		File rfile = FindById(fileId);
					//bool isFolder = false;
					//if (targetF.MimeType.Equals("application/vnd.google-apps.folder")) {
					//	dbMsg += ">>フォルダ";
					//	isFolder = true;
					//} else {
					//	dbMsg += ">>ファイル";
					//}
					var result = DelteItem(fileId);
					dbMsg += ",result=" + result.Result;
				}
					LocalFileUtil LFUtil = new LocalFileUtil();
					String MimeStr = LFUtil.GetMimeType(filePath);
					dbMsg += ",Mime=" + MimeStr;
					var meta = new File() {
						Name = System.IO.Path.GetFileName(filePath),
						MimeType = MimeStr,
						Parents = new List<string> { parentId }
					};
					using (var stream = new System.IO.FileStream(filePath, System.IO.FileMode.Open)) {
						// Create:新規追加
						var request = Constant.MyDriveService.Files.Create(meta, stream, MimeStr);
						//			var uploadProgress = await request.UploadAsync();
						Task<Google.Apis.Upload.IUploadProgress> uploadProgress = Task.Run(() => {
							return request.UploadAsync();
						});
						uploadProgress.Wait();
						var rFile = request.ResponseBody;                           //作成結果が格納され戻される
						retStr = rFile.Id;
						dbMsg += ">作成したファイルID>" + retStr;
						MyLog(TAG, dbMsg);
						return retStr;
					}

			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
			}
		}

		/// <summary>
		/// 指定されたIDのファイルを削除する
		/// </summary>
		/// <param name="fileId"></param>
		/// <returns></returns>
		public async Task<string> DelteItem(string fileId)
		{
			string TAG = "DelteItem";
			string dbMsg = "[GoogleUtil]";
			string retStr = null;
			try {
				//dbMsg += itemName;
				//Task<string> tFile = Task<string>.Run(() => {
				//	if (isFolder) {
				//		return FindByName(itemName, SearchFilter.FOLDER);
				//	} else {
				//		return FindByName(itemName, SearchFilter.FILE);
				//	}
				//});
				//tFile.Wait();
				//string fileId = tFile.Result;
				dbMsg += fileId;
				Google.Apis.Drive.v3.FilesResource.DeleteRequest request = Constant.MyDriveService.Files.Delete(fileId);
				retStr = await request.ExecuteAsync();
				//Task<Google.Apis.Requests.ClientServiceRequest> csRequest = Task.Run(() => {
				//	return request.Execute();
				//});
				//csRequest.Wait();
				//var rFile = request.ResponseBody;                           //作成結果が格納され戻される
				//retStr = rFile.Id;
				dbMsg += ">削除したファイルID>" + retStr;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retStr;
		}

		/// <summary>
		/// 検索対象の名称と親フォルダの名称で検索
		/// </summary>
		/// <param name="name"></param>
		/// <param name="parentName"></param>
		/// <param name="isFolder">検索対象の種類</param>
		/// <returns>Google.Apis.Drive.v3.Data.File</returns>
		public File FindByNameParent(string name, string parentName)
		{
			string TAG = "FindByNameParent";
			string dbMsg = "[GoogleUtil]";
			File retFile = null;
			try {
				dbMsg = "[" + parentName + "]" + name ;
				IList<File> retList = GDFileListUp(parentName, false);
				dbMsg += ">該当＞" + retList.Count + "件";
				foreach (File rItem in retList) {
					string itemName = rItem.Name;
					string mimeType = rItem.MimeType;
					dbMsg += "\r\n" + itemName + ")" + mimeType;
					if(@itemName.Equals(@name)) {
						//if(isFolder && mimeType.Equals("application/vnd.google-apps.folder")) {
						retFile = rItem;
						dbMsg += ">＞的中";
						break;
						//}
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retFile;
		}


		/// <summary>
		/// フォルダもしくはファイル名称で検索
		/// </summary>
		/// <param name="name"></param>
		/// <param name="filter"></param>
		/// <returns>Task<File></returns>
		public async Task<string> FindByName(string name, SearchFilter filter = SearchFilter.NONE)
		{
			string TAG = "FindByName";
			string dbMsg = "[GoogleUtil]";
			string retStr = null;
			File retFile = null;
			try {
				dbMsg = "name=" + name;
				var queries = new List<string>() { $"name = '{ name }'" };
				if (filter != SearchFilter.NONE) queries.Add(filter.ToQuery());
				retFile = await FindFile(queries);
				retStr = retFile.Id;
				dbMsg = ">>[" + retStr + "]";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retStr;
		}

		/// <summary>
		/// idに該当するファイル・フォルダの名称を返す
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public File FindById(string id)
		{
			string TAG = "FindById";
			string dbMsg = "[GoogleDriveUtil]";
			string retStr = null;
				File retFile = null;
			try {
				dbMsg += "[id=" + id + "]";
				retFile = Constant.MyDriveService.Files.Get(id).Execute();
				retStr = retFile.Name;
				dbMsg += retStr;
				dbMsg += ">>[" + retStr + "]";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retFile;
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
				Constant.MyDriveService = new DriveService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyDriveCredential,
					ApplicationName = Constant.ApplicationName,
				});

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
Google Drive APIv3リファレンス	 https://developers.google.com/drive/api/v3/reference/files
https://www.apps-gcp.com/google-deive-api-v2-to-v3-4points/
 */
