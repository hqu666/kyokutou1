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

	/// <summary>
	/// 使用許諾を受けるAPIのリスト
	/// </summary>
		public static string[] AllScopes = { DriveService.Scope.DriveFile,
																	DriveService.Scope.DriveAppdata,			//追加
																	DriveService.Scope.Drive,
																	CalendarService.Scope.Calendar,
																	CalendarService.Scope.CalendarEvents
															};

		/// <summary>
		/// 認証情報と各サービスを作成する
		/// </summary>
		/// <param name="jsonPath">読込むjsonファイルのURL</param>
		/// <param name="tokenFolderPath"></param>
		/// <returns>正常に認証されればOKの文字が返る</returns>
		public async Task<string> Authentication(string jsonPath, string tokenFolderPath)
		{
			string TAG = "Authentication";
			string dbMsg = "[GoogleAuthUtil]";
			string retStr = "";
			try {
				dbMsg += ",jsonPath=" + jsonPath;
				Constant.MyDriveCredential = await GetAllCredential(jsonPath, tokenFolderPath);
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
				retStr = "OK";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retStr;
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
			string TAG = "GetAllCredential";
			string dbMsg = "[GoogleAuthUtil]";
			dbMsg += ",jsonPath=" + jsonPath;
			MyLog(TAG, dbMsg);
			using (var stream = new System.IO.FileStream(jsonPath, System.IO.FileMode.Open, System.IO.FileAccess.Read)) {
				return GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					AllScopes,
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
