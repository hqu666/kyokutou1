﻿using System;
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

		public IList<Google.Apis.Drive.v3.Data.File> GDFileListUp()
		{
			string TAG = "GDFileListUp";
			string dbMsg = "[GoogleUtil]";
			IList<Google.Apis.Drive.v3.Data.File> retList = null;
			try {
				// リクエストパラメータの定義	https://qiita.com/nori0__/items/dd5bbbf0b09ad58e40be
				FilesResource.ListRequest listRequest = Constant.MyDriveService.Files.List();
				listRequest.PageSize = 10;      //返される共有ドライブの最大数。許容値は1〜100です。（デフォルト：10）
				listRequest.Q = "trashed = false"; // 名前が file.txt に一致, ゴミ箱は検索しない
				listRequest.Fields = "nextPageToken, files(id, name, createdTime, mimeType,	modifiedTime,parents,trashed,size)";
				//		GDriveFiles.Clear();						//newが使えない？
				retList = listRequest.Execute().Files;            // ドライブ内容のリストアップ
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retList;
		}

		//フォルダを作る
		public async Task<File> CreateFolder(string name, string parentFolderId = null, string driveId = null)
		{
			string TAG = "CreateFolder";
			string dbMsg = "[GoogleUtil]";
			File newFolder = new File();
			try {
				dbMsg += "[" + driveId + "][" + parentFolderId + "]" + name;
				File meta = new File();
				meta.Name = name;
				meta.MimeType = "application/vnd.google-apps.folder";
				if (driveId != null) meta.DriveId = driveId;
				if (parentFolderId != null) meta.Parents = new List<string> { parentFolderId };
				dbMsg += ",meta=" + meta.Parents[0];
				var request = Constant.MyDriveService.Files.Create(meta);
				request.Fields = "id, name";
				dbMsg += ",request=" + request.MethodName;
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

		public async Task<File> UploadFile(string filePath, string parentId)
		{
			string TAG = "UploadFile";
			string dbMsg = "[GoogleUtil]";
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
					var result = await request.UploadAsync();
					return request.Body;
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				return null;
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

}
/*
 https://toconakis.tech/google-drive-rest-api-v3-for-android/
 https://csharp.hotexamples.com/examples/Google.Apis.Drive.v3.Data/File/-/php-file-class-examples.html
 
 
 
 */
