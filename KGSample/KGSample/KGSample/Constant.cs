﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3.Data;

namespace KGSample {
	class Constant {
		public static bool debugNow = true;
		public static bool errorCheckNow = true;

		//認証情報/API キー
		public static string ApplicationName = "kyokuto4";                                        //	アプリケーション名
		public static string APIKey = "AIzaSyAnJ-QXa9dqQr644u7jn_3-sxSr3XL_z60";
		//OAuth 2.0 クライアント ID
		public static string CliantId = "912719822179-n9hvcs7tr9pqgn8mns7pdl5njo54gpe1.apps.googleusercontent.com";    //クライアント ID
		public static string CliantSeacret = "aGVZ_mfTKJq8WFf5spDOOiHi";    //クライアント シークレット

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
		public static string MakeFolderName = null;         //作成するファイルの格納フォルダ
		public static String parentFolderId;
		public static string LocalPass = "";            //送信元PCフォルダ

		public static IList<Google.Apis.Drive.v3.Data.File> GDriveFiles;
		public static IDictionary<string, Google.Apis.Drive.v3.Data.File> GDriveFolders;
		public static IList<Google.Apis.Drive.v3.Data.File> GDriveFolderMembers;
		public static IList<Google.Apis.Drive.v3.Data.File> GDriveSelectedFiles;
		public static string GoogleDriveMime_Folder = "application/vnd.google-apps.folder";
		public static string CurrentFolder = "";                    //現在の対象フォルダ

		/// <summary>
		/// GoogleのIDで定義されたEventColor
		/// </summary>
		public struct GoogleEventColor {
			public string id;
			public string name;
			public System.Windows.Media.Color rgb;  //= System.Windows.Media.Color.FromRgb(0x00, 0xFF, 0x00);

			public GoogleEventColor(string id, string name, System.Windows.Media.Color rgb)
			{
				this.id = id;
				this.name = name;
				this.rgb = rgb;
			}
		}
		public static IList<GoogleEventColor> googleEventColor;

		/// <summary>
		/// 受注No　:　GoogleEventに無い追加項目
		/// </summary>
		public static string orderNumber = "";
		/// <summary>
		/// 管理番号　:　GoogleEventに無い追加項目
		/// </summary>
		public static string managementNumber = "";
		/// <summary>
		/// 得意先　:　GoogleEventに無い追加項目
		/// </summary>
		public static string customerName =""; 

		/// <summary>
		/// PCのファイル管理
		/// </summary>
		public struct LocalFile {
			public string fullPass;
			public string name;
			public string parent;
			public bool isFolder;

			public LocalFile(string fullPass, string name, string parent, bool isFolder)
			{
				this.fullPass = fullPass;
				this.name = name;
				this.parent = parent;
				this.isFolder = isFolder;
			}
		}
		public static IList<LocalFile> sendFiles = null;             //送信元PCのファイルリスト

		public static IList<string> selectFiles = null;             //送信元PCのファイルリスト
	}
}

/*
 このアプリに必要なパッケージ
 MahApps.Metro
 パッケージマネージャコンソールから
Install-Package Google.Apis.Drive.v3
Install-Package Google.Apis.Calendar.v3 
 */
