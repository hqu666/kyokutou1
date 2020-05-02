using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace kyokuto4calender {
	class Constant {
		public static string ApplicationName = "kyokuto4calender";                                        //	アプリケーション名
		public static string APIKey = "AIzaSyDwuP2n683t_BGjmpHfioyf_ZYI-0vkfz0";
		public static string CliantId = "1015531776934-tcehh91kdtcj3s346c242j2a6ooij26f.apps.googleusercontent.com";    //クライアント ID
		public static string CliantSeacret = "eWi7voZh5xWvcqeDiUkwdTLX";    //クライアント シークレット
																			//0502	
																			//public static string CliantId = "468394297775-okt0nb474ol5drnheustvokj22iu2p2l.apps.googleusercontent.com";    //クライアント ID
																			//public static string CliantSeacret = "kb8Jn4oNRKDiaIcnC2GVJxP0";    //クライアント シークレット

		public static string TopFolderName = "案件";                                        //	最上位フォルダ KSクラウド
		public static string TopFolderID = "";
		public static string RootFolderID = "";            //保存先サーバのルートフォルダID
		public static string LocalPass = "";            //送信元フォルダ

		public static UserCredential MyCredential;
		public static CalendarService MyCalendarService;        // Drive API service
		public static IList<Google.Apis.Calendar.v3.Data.Event> GCalenderEvent;//カレンダーの予定

		public static DriveService MyDriveService;        // Drive API service
		public static String parentFolderId;
		public static IList<Google.Apis.Drive.v3.Data.File> GDriveFiles;
		public static IDictionary<string, Google.Apis.Drive.v3.Data.File> GDriveFolders;
		public static string[] DriveScopes = { DriveService.Scope.DriveFile,
																	DriveService.Scope.DriveAppdata,			//追加
																	DriveService.Scope.Drive
															};
		public static string[] CalenderScopes = { CalendarService.Scope.Calendar,
																	CalendarService.Scope.CalendarEvents
															};
		public static string MyTokenType = "";
		public static string MyRefreshToken = "";
		public static string MyAccessToken = "";
		public static string ProjectId = "kyokuto-1";       //	必要？
		public static string ServiceAcountEmail = "hkuwayama@kyokuto-1.iam.gserviceaccount.com";       //	必要？
		public static string ServiceAcountEmailID = "c7501858467a3f670e9c8266be2be7e1c3e25949";       //	必要？

		public static string MakeFolderName = null;
		public static string[] selectFiles = null;
	}
}
