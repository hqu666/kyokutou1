﻿using System;
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
		//public static string[] AllScopes = { DriveService.Scope.DriveFile,
		//															DriveService.Scope.DriveAppdata,			//追加
		//															DriveService.Scope.Drive,
		//															CalendarService.Scope.Calendar,
		//															CalendarService.Scope.CalendarEvents
		//													};

		public static UserCredential MyCalendarCredential;
		public static CalendarService MyCalendarService; 
		public static UserCredential MyDriveCredential;
		public static DriveService MyDriveService;   

		public static IList<Google.Apis.Calendar.v3.Data.Event> GCalenderEvent;//カレンダーの予定
		public static Google.Apis.Calendar.v3.Data.Event eventItem;
		public static string CalenderSummary = "abcbdffghaiklnm@gmail.com";   //Googleアカウント

		public static string RootFolderName = "KSクラウド";            //保存先サーバのルートフォルダ
		public static string RootFolderID = "";   
		public static string TopFolderName = "案件";                                        //	最上位フォルダ KSクラウド
		public static string TopFolderID = "";
		public static string LocalPass = "";            //送信元フォルダ

		public static String parentFolderId;
		public static IList<Google.Apis.Drive.v3.Data.File> GDriveFiles;
		public static IDictionary<string, Google.Apis.Drive.v3.Data.File> GDriveFolders;
		public static IList<Google.Apis.Drive.v3.Data.File> GDriveFolderMembers;
		public static IList<Google.Apis.Drive.v3.Data.File> GDriveSelectedFiles;
		public static string MakeFolderName = null;
		public static string CurrentFolder = "";            //現在の対象フォルダ
		public static string[] selectFiles = null;
	}
}
