using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;

/**
 * このアプリケーションでさせる定数と変数
 * 
 * 
 * ****/
namespace kyokuto1sample
{
	class Constant
	{
		public static string ApplicationName = "kyokuto1sample";                                        //	アプリケーション名
		public static string TopFolderName = "KSクラウド";                                        //	最上位フォルダ
		public static string TopFolderID = "";
		public static string RootFolderID = "";            //保存先サーバのルートフォルダID

		public static UserCredential MyCredential;
		public static DriveService MyDriveService;        // Drive API service
		public static String parentFolderId;
		public static IList<Google.Apis.Drive.v3.Data.File> GDriveFiles;
		public static IDictionary<string, Google.Apis.Drive.v3.Data.File> GDriveFolders;
		public static string[] DriveScopes = { DriveService.Scope.DriveFile };
		//DriveService.Scope.Drive,
		//					 DriveService.Scope.DriveAppdata,
		//						 DriveService.Scope.DrivePhotosReadonly,

		//			DriveService.Scope.DriveScripts,		//追加

		//	削除			DriveService.Scope.DriveMetadataReadonly,
		//									DriveService.Scope.DriveReadonly,
		//static string[] writescopes = {
		//					driveservice.scope.drive,
		//					 driveservice.scope.driveappdata,
		//				 driveservice.scope.drivefile
		//		//			driveservice.scope.drivescripts		//追加
		//					};
		public static string APIKey = "AIzaSyBgQfaxlfQXP32-W8rRmGfj8nDf8vlSCxs";
		public static string CliantId = "1015531776934-6lgfgndk2o2lp5iu29ddaabqrfn1ibp2.apps.googleusercontent.com";    //クライアント ID
		public static string CliantSeacret = "u-eNFbgl4c9yM2fMkusalRfG";    //クライアント シークレット
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
