using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Windows.Shapes;

using Microsoft.Web.WebView2.Core;

using Google.Apis.Drive.v3.Data;
using Infragistics.Controls.Schedules;
using Livet;
using Livet.Commands;
using Livet.Messaging.Windows;
using Livet.EventListeners;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3;
using Google.Apis.Util.Store;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Google.Apis.Services;

using TabCon.Models;
using TabCon.Enums;
using Task = System.Threading.Tasks.Task;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace TabCon.ViewModels {
	public class W_1ViewModel : ViewModel {
		public string titolStr = "【Googleドライブフォルダ内ファイル一覧】";
		private Uri _TargetURI;
		/// <summary>
		/// 遷移先URL
		/// </summary>
		public Uri TargetURI {
			get {
				return _TargetURI;
			}
			set {
				string TAG = "TargetURI.set";
				string dbMsg = "";
				try {
					dbMsg += ">>遷移先URL=  " + value;
					if (value == _TargetURI)
						return;
					_TargetURI = value;
		//			RaisePropertyChanged("TargetURI");
					MyLog(TAG, dbMsg);
				} catch (Exception er) {
					MyErrorLog(TAG, dbMsg, er);
				}
			}
		}
		private string _TargetURLStr;
		/// <summary>
		/// 遷移先URL文字列
		/// </summary>
		public string TargetURLStr {
			get {
				return _TargetURLStr;
			}
			set {
				string TAG = "TargetURLStr.set";
				string dbMsg = "";
				try {
					dbMsg += ">>遷移先URL=  " + value;
					if (value == _TargetURLStr)
						return;
						_TargetURLStr = value;
						TargetURI = new Uri(value);
						RaisePropertyChanged("TargetURI");
					MyLog(TAG, dbMsg);
				} catch (Exception er) {
					MyErrorLog(TAG, dbMsg, er);
				}
			}
		}
	
		/// <summary>
		/// 操作パネルの表示
		/// </summary>
		public string TopPanelVisibility { set; get; }
		/// <summary>
		/// 現在遷移中
		/// </summary>
		bool _isNavigating = false;
		/// <summary>
		/// 遷移上限から外れた場合の戻し先
		/// </summary>
		public string RedirectUrl = "";

		public W_1ViewModel()
		{
			TopPanelVisibility = "Hidden";
			RaisePropertyChanged("TopPanelVisibility");
			Initialize();
		}

		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try {
				RedirectUrl = "";
				TargetURLStr = Constant.WebStratUrl;
				RaisePropertyChanged("TargetURLStr");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		#region Webエレメントの読み込み終了
		//private ViewModelCommand _WebLoaded;
		//public ViewModelCommand WebLoaded {
		//	get {
		//		if (_WebLoaded == null) {
		//			_WebLoaded = new ViewModelCommand(LoadedWebView);
		//		}
		//		return _WebLoaded;
		//	}
		//}

		/// <summary>
		/// エレメントの読み込み終了
		/// </summary>
		public void LoadedWebView()
		{
			string TAG = "LoadedWebView";
			string dbMsg = "";
			try {
				TopPanelVisibility = "Visible";
				RaisePropertyChanged("TopPanelVisibility");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		#endregion

		#region 接続先変更イベント
		//private ViewModelCommand _ChangedSource;
		//public ViewModelCommand ChangedSource {
		//	get {
		//		if (_ChangedSource == null) {
		//			_ChangedSource = new ViewModelCommand(SourceChanged);
		//		}
		//		return _ChangedSource;
		//	}
		//}

		public void SourceChanged()
		{
			string TAG = "SourceChanged";
			string dbMsg = "";
			try {
				dbMsg += "TargetURI=" + TargetURI;
				if (CanGoto(TargetURI.ToString())) {
					_isNavigating = true;
					RequeryCommands();
				} else if (!RedirectUrl.Equals("")) {
					dbMsg += ";RedirectUrl=  " + RedirectUrl;
					TargetURLStr = RedirectUrl;
					RaisePropertyChanged("TargetURLStr");
					TargetURI = new Uri(TargetURLStr);
					RaisePropertyChanged("TargetURI");
				} else {
					TargetURLStr = Constant.WebStratUrl;
					RaisePropertyChanged("TargetURLStr");
					TargetURI = new Uri(TargetURLStr);
					RaisePropertyChanged("TargetURI");
				}
				dbMsg += ">>" + TargetURLStr;
				RaisePropertyChanged();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private bool CanGoto(string checkUrl)
		{
			string TAG = "CanGoto";
			string dbMsg = "";
			bool retBool = true;
			try {
				List<string> GoogleDriveFolderNames = new List<string>();
				dbMsg += "checkUrl=  " + checkUrl;
				dbMsg += ";DriveId=  " + Constant.WebStratUrl;
				if (!checkUrl.StartsWith(@"https://drive.google.com/drive/u/0/folders")) {
					dbMsg += "::googleDriveではない ";
					retBool = false;
				}
				if (retBool) {
					if (Constant.GDriveFolders == null) {
						Constant.GDriveFolders = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();
					}
					int FoldersCount = Constant.GDriveFiles.Count();
					dbMsg += ";FoldersCount=  " + FoldersCount + "件";
					if (GoogleDriveFolderNames.Count < 1) {
						//GoogleDriveUtil GDU = new GoogleDriveUtil();
						//GoogleDriveFolders = GDU.GDFolderListUp(DriveId);
						//FoldersCount = GoogleDriveFolders.Count();
						//dbMsg += ">>" + FoldersCount + "件";
						//			GoogleDriveFolderNames = new List<string>();
						//12/18；取敢えずファイルで確認
						foreach (Google.Apis.Drive.v3.Data.File forlder in Constant.GDriveFiles) {
							GoogleDriveFolderNames.Add(@"https://drive.google.com/drive/u/0/folders/" + forlder.Id);
						}
						dbMsg += ">>" + GoogleDriveFolderNames.Count + "件";
					}
					if (GoogleDriveFolderNames.IndexOf(checkUrl) < 0) {
						dbMsg += "::該当フォルダ無し";
						retBool = false;
					}
				}
				dbMsg += ">retBool= " + retBool;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retBool;
		}
		#endregion

		#region コンテンツ読込み終了イベント
		//private ViewModelCommand _CompletedNavigation;
		//public ViewModelCommand CompletedNavigation {
		//	get {
		//		if (_CompletedNavigation == null) {
		//			_CompletedNavigation = new ViewModelCommand(NavigationCompleted);
		//		}
		//		return _CompletedNavigation;
		//	}
		//}

		/// <summary>
		/// リダイレクト先を設定する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void NavigationCompleted()
		{
			string TAG = "NavigationCompleted";
			string dbMsg = "";
			try {
				dbMsg += "RedirectUrl=" + RedirectUrl;
				RedirectUrl = TargetURLStr;
				_isNavigating = false;
				RequeryCommands();
				dbMsg += ">>" + RedirectUrl;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		#endregion

		#region ホームボタンクリック
		private ViewModelCommand _HomeBTCommand;
		public ViewModelCommand HomeBTCommand {
			get {
				if (_HomeBTCommand == null) {
					_HomeBTCommand = new ViewModelCommand(HomeBTClick);
				}
				return _HomeBTCommand;
			}
		}

		private void HomeBTClick()
		{
			string TAG = "HomeBTClick";
			string dbMsg = "";
			try {
				dbMsg += ",TargetURLStr=" + TargetURLStr;
				TargetURLStr = @"https://www.yahoo.co.jp/";
				RaisePropertyChanged("TargetURLStr");
				dbMsg += ">>" + TargetURLStr;
				RequeryCommands();
				MyLog(TAG, dbMsg);
				RaisePropertyChanged();

			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		#endregion


		//Livet Messenger用///////////////////////
		void RequeryCommands()
		{
			// Seems like there should be a way to bind CanExecute directly to a bool property
			// so that the binding can take care keeping CanExecute up-to-date when the property's
			// value changes, but apparently there isn't.  Instead we listen for the WebView events
			// which signal that one of the underlying bool properties might have changed and
			// bluntly tell all commands to re-check their CanExecute status.
			//
			// Another way to trigger this re-check would be to create our own bool dependency
			// properties on this class, bind them to the underlying properties, and implement a
			// PropertyChangedCallback on them.  That arguably more directly binds the status of
			// the commands to the WebView's state, but at the cost of having an extraneous
			// dependency property sitting around for each underlying property, which doesn't seem
			// worth it, especially given that the WebView API explicitly documents which events
			// signal the property value changes.
			CommandManager.InvalidateRequerySuggested();
		}   //////////////////////////////////////////////////////////////////////////////////////////
		new public void Dispose()
		{
			// 基本クラスのDispose()でCompositeDisposableに登録されたイベントを解放する。
			base.Dispose();
			Dispose(true);
		}
		///////////////////////Livet Messenger用//
		public static void MyLog(string TAG, string dbMsg)
		{
			dbMsg = "[W_1ViewModel ]" + dbMsg;
			//dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			dbMsg = "[W_1ViewModel ]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		)
		{
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}
	}
}

/*
 https://docs.microsoft.com/ja-jp/microsoft-edge/webview2/gettingstarted/wpf
 */
