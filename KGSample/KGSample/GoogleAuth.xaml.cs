using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KGSample {
	/// <summary>
	/// GoogleAuth.xaml の相互作用ロジック
	/// </summary>
	public partial class GoogleAuth : Window {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public WebWindow webWindow;

		public GoogleAuth()
		{
			InitializeComponent();
		}

		private void Json_read_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Json_read_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				// ダイアログのインスタンスを生成
				var dialog = new OpenFileDialog();

				// ファイルの種類を設定
				dialog.Filter = "テキストファイル (*.json)|*.json|全てのファイル (*.*)|*.*";
				// ダイアログを表示する
				DialogResult res = dialog.ShowDialog();
				int rCount = dialog.FileNames.Count();
				dbMsg += "," + rCount + "件";
				if (0< rCount) {
					// 選択されたファイル名 (ファイルパス) をメッセージボックスに表示
					foreach (String fileOne in dialog.FileNames) {
						string JsonFileName = fileOne.ToString();
						dbMsg += "\r\n" + JsonFileName;
						LogInProcrce(JsonFileName);
						//複数選ばれても一件目で強制的に処理開始
						break;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		private void Log_in_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Log_in_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void LogInProcrce(string JsonFileName)
		{
			string TAG = "LogInProcrce";
			string dbMsg = "[GoogleAuth]";
			try {
				dbMsg += ",JsonFileName=" + JsonFileName;
				String retStr = GAuthUtil.Authentication(JsonFileName, "token.json");           //"drive_calender.json"
				dbMsg += ",retStr=" + retStr;
				if (retStr.Equals("")) {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					String msgStr = "認証されませんでした。\r\n更新ボタンをクリックして下さい";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
				} else {
					string UserId = Constant.MyCalendarCredential.UserId;
					dbMsg += ",UserId=" + UserId;
					MyLog(TAG, dbMsg);
					//if (isListUp) {
					//	DrowToday();
					//}
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// ログアウト処理
		/// アウトでアプリケーション終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Log_out_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Log_out_bt_Click";
			string dbMsg = "[GoogleAuth]";
			try {
				String titolStr = Constant.ApplicationName;
				String msgStr = "ログアウトしますか？";
				MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
				dbMsg += ",result=" + result;
				if(result.Equals(System.Windows.MessageBoxResult.OK)) {
					msgStr = "お疲れ様でした。";
					 result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Information);
					if (result.Equals(System.Windows.MessageBoxResult.OK)) {
			//			this.Close();
					}
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
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

		////////////////////////////////////////////////////

	}
}
