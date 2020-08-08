using System;
using System.Windows;


namespace GoogleOSD {
	/// <summary>
	/// ProgressDialog.xaml の相互作用ロジック
	/// </summary>
	public partial class ProgressDialog : Window {

		public ProgressDialog(string ProgressMsg = null)
		{
			string TAG = "ProgressDialog";
			string dbMsg = "[ProgressDialog]";
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void SetMsg(string ProgressMsg)
		{
			string TAG = "SetMsg";
			string dbMsg = "[ProgressDialog]";
			try {
				dbMsg += " ,ProgressMsg= " + ProgressMsg;
				Progress_msg_tb.Content = ProgressMsg;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}
	}
}
