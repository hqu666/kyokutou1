using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace kyokuto4calender {
	class GoogleAuthUtil {
		//認証情報を作る
		public async Task<string> Authentication(string jsonPath, string tokenFolderPath)
		{
			string TAG = "Authentication";
			string dbMsg = "[GoogleAuthUtil]";
			string retStr = "";
			try {
				dbMsg += ",jsonPath=" + jsonPath;
				Constant.MyCalendarCredential = await GetCalendarCredential(jsonPath, tokenFolderPath);
				Constant.MyCalendarService = new CalendarService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyCalendarCredential,
					ApplicationName = Constant.ApplicationName,
					ApiKey = Constant.APIKey,                                           //追加
				});
				dbMsg += ",MyCalendarService:ApiKey=" + Constant.MyCalendarService.ApiKey;
				Constant.MyDriveCredential = await GetDriveCredential(jsonPath, tokenFolderPath);
				Constant.MyDriveService = new DriveService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyDriveCredential,
					ApplicationName = Constant.ApplicationName,
					ApiKey = Constant.APIKey,                                           //追加
				});
				dbMsg += ",MyDriveService:ApiKey=" + Constant.MyDriveService.ApiKey;
				retStr = "OK";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retStr;
		}

		// Serviceを作る
		static Task<UserCredential> GetCalendarCredential(string jsonPath, string tokenFolderPath)
		{
			string TAG = "GetUserCredential";
			string dbMsg = "[GoogleAuthUtil]";
			dbMsg += ",jsonPath=" + jsonPath;
			MyLog(TAG, dbMsg);
			using (var stream = new System.IO.FileStream(jsonPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
				return GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Constant.CalenderScopes,
					"user",
					CancellationToken.None,
					new FileDataStore(tokenFolderPath, true));
			}
		}

		public async Task<string> DriveAuthentication(string jsonPath, string tokenFolderPath)
		{
			string TAG = "DriveAuthentication";
			string dbMsg = "[GoogleAuthUtil]";
			string retStr = "";
			try {
				dbMsg += ",jsonPath=" + jsonPath;
				Constant.MyDriveCredential = await GetDriveCredential(jsonPath, tokenFolderPath);
				Constant.MyDriveService = new DriveService(new BaseClientService.Initializer() {
					HttpClientInitializer = Constant.MyDriveCredential,
					ApplicationName = Constant.DriveApplicationName,
					ApiKey = Constant.DriveAPIKey,                                           //追加
				});
				dbMsg += ",MyDriveService:ApiKey=" + Constant.MyDriveService.ApiKey;
				retStr = "OK";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retStr;
		}

		// DriveServiceを作る
		static Task<UserCredential> GetDriveCredential(string jsonPath, string tokenFolderPath)
		{
			using (var stream = new System.IO.FileStream(jsonPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
				return GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					Constant.DriveScopes,
					"user",
					CancellationToken.None,
					new FileDataStore(tokenFolderPath, true));
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
