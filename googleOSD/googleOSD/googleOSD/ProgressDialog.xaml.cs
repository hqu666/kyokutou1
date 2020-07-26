using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
				dbMsg += " ,ProgressMsg= " + ProgressMsg;
				Progress_msg_tb.Text = ProgressMsg;
				//		dbMsg += " ,[" + retFileID + "]" + targetFileName;
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
