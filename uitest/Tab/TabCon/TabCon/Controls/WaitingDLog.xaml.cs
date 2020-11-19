using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;

namespace TabCon.Controls {
	/// <summary>
	/// WaitingDLog.xaml の相互作用ロジック
	/// </summary>
	public partial class WaitingDLog : Window {
		public WaitingDLog()
		{
			string TAG = "WaitingDLog";
			string dbMsg = "";
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void SetMes(string Msg)
		{
			string TAG = "SetMes";
			string dbMsg = "";
			try {
				Progress_msg_tb.Content = Msg;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			Util.MyErrorLog(TAG, dbMsg, err);
		}
	}
}
