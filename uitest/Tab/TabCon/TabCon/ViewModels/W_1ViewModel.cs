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
		/// <summary>
		/// 遷移先URL
		/// </summary>
		public Uri TargetURI { set; get; }
		public string TargetURLStr { set; get; }
		
		public W_1ViewModel()
		{
			TargetURLStr = @"https://www.yahoo.co.jp/";
			RaisePropertyChanged("TargetURLStr");
			Initialize();
		}
		/// <summary>
		/// WebViewで指定したURLのページを開く
		/// </summary>
		/// <param name="_targetURLStr"></param>
		//public W_1ViewModel(string _targetURLStr)
		//{
		//	TargetURLStr = _targetURLStr;
		//	Initialize();
		//}

		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try {
				dbMsg += ",TargetURLStr= " + TargetURLStr;
				TargetURI = new Uri("https://www.yahoo.co.jp/");
				RaisePropertyChanged("TargetURI");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		//Livet Messenger用///////////////////////
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
