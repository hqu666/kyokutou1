using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3.Data;

namespace kyokuto4calender {
	class Constant {
		//認証情報/API キー
		public static string ApplicationName = "kyokuto4";                                        //	アプリケーション名
		public static string APIKey = "AIzaSyAnJ-QXa9dqQr644u7jn_3-sxSr3XL_z60";
		//OAuth 2.0 クライアント ID
		public static string CliantId = "912719822179-n9hvcs7tr9pqgn8mns7pdl5njo54gpe1.apps.googleusercontent.com";    //クライアント ID
		public static string CliantSeacret = "aGVZ_mfTKJq8WFf5spDOOiHi";    //クライアント シークレット

		////認証情報/API キー
		//public static string ApplicationName = "kyokuto4calender";                                        //	アプリケーション名
		//public static string APIKey = "AIzaSyDrVJJaHe6MFnL1zeRRVp71vQG9OQfb-vw";
		////OAuth 2.0 クライアント ID
		//public static string CliantId = "1015531776934-tcehh91kdtcj3s346c242j2a6ooij26f.apps.googleusercontent.com";    //クライアント ID
		//public static string CliantSeacret = "eWi7voZh5xWvcqeDiUkwdTLX";    //クライアント シークレット
		//0502	
		//public static string CliantId = "468394297775-okt0nb474ol5drnheustvokj22iu2p2l.apps.googleusercontent.com";    //クライアント ID
		//public static string CliantSeacret = "kb8Jn4oNRKDiaIcnC2GVJxP0";    //クライアント シークレット
		//サービス アカウント
		//112521590140634372048	?
		//9cf88695ae37cd3dd57c3755e43b6a87fe465959	?
		// 111680048736455529877
		public static UserCredential MyCalendarCredential;
		public static CalendarService MyCalendarService;        // Drive API service
		
		public static IList<Google.Apis.Calendar.v3.Data.Event> GCalenderEvent;//カレンダーの予定
		public static Google.Apis.Calendar.v3.Data.Event eventItem;
		public static string CalenderSummary = "abcbdffghaiklnm@gmail.com";   //Googleアカウント

		public static string TopFolderName = "案件";                                        //	最上位フォルダ KSクラウド
		public static string TopFolderID = "";
		public static string RootFolderID = "";            //保存先サーバのルートフォルダID
		public static string LocalPass = "";            //送信元フォルダ

		public static string DriveApplicationName = "kyokuto1sample";                                        //	アプリケーション名
		public static string DriveAPIKey = "AIzaSyBgQfaxlfQXP32-W8rRmGfj8nDf8vlSCxs";
		//OAuth 2.0 クライアント ID
		public static string DrivrCliantId = "1015531776934-6lgfgndk2o2lp5iu29ddaabqrfn1ibp2.apps.googleusercontent.com";    //クライアント ID
		public static string DriveCliantSeacret = "u-eNFbgl4c9yM2fMkusalRfG";    //クライアント シークレット
																				 //public static string DriveApplicationName = "kyokuto_drive";                                        //	アプリケーション名
																				 //public static string DriveAPIKey = "AIzaSyCy_Md_FoEpWJw_69n0j-gjryEBjQwSgYM";
																				 //OAuth 2.0 クライアント ID
		//public static string DrivrCliantId = "1015531776934-86u2uakrilbc06icrquf1fkda9bqhbdl.apps.googleusercontent.com";    //クライアント ID
		//public static string DriveCliantSeacret = "rLdSo_9RjDY4sAaRuP9aeSNS";    //クライアント シークレット
		public static UserCredential MyDriveCredential;
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
		public static string[] AllScopes = { DriveService.Scope.DriveFile,
																	DriveService.Scope.DriveAppdata,			//追加
																	DriveService.Scope.Drive,
																	CalendarService.Scope.Calendar,
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
