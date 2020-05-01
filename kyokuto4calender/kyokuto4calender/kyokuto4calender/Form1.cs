using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyokuto4calender {
	public partial class Form1 : Form {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleUtil GUtil = new GoogleUtil();

		Edit editForm;
		private string receiveData = "";

		public Form1()
		{
			string TAG = "Form1";
			string dbMsg = "[Form1]";
			try {
				InitializeComponent();
				editForm = new Edit();
				editForm.mainForm = this;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}

		}

		private void edit_bt_Click(object sender, EventArgs e)
		{
			string TAG = "edit_bt_Click";
			string dbMsg = "[Form1]";
			try {
				if(editForm == null) {
					dbMsg = "Editを再生成";
					editForm = new Edit();
					editForm.mainForm = this;
				}
				editForm.Show();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}

		}
		public string ReceiveData {
			set {
				receiveData = value;
				receiveData_lv.Text = receiveData;
			}
			get {
				return receiveData;
			}
		}

		////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg);
		}

		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

	}
}
