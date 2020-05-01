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
	public partial class Edit : Form {
		public Form1 mainForm;
		private string sendData = "";
		private string titolStr = "";


		public Edit()
		{
			string TAG = "Edit";
			string dbMsg = "[Edit]";
			try {
				InitializeComponent();
				titolStr = titol_tb.Text;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void titolbt_TextChanged(object sender, EventArgs e)
		{
			string TAG = "titolbt_TextChanged";
			string dbMsg = "[Edit]";
			try {
				titolStr = titol_tb.Text;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void back_bt_Click(object sender, EventArgs e)
		{
			string TAG = "back_bt_Click";
			string dbMsg = "[Edit]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void Edit_FormClosing(object sender, FormClosingEventArgs e)
		{
			string TAG = "back_bt_Click";
			string dbMsg = "[Edit]";
			try {
				e.Cancel = true;				//このオブジェクトを破棄させない(1)
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[Edit]";
			try {

				dbMsg += "titolStr=" + titolStr;
				if (mainForm != null) {
					mainForm.ReceiveData = titolStr;
					this.Visible = false;//このオブジェクトを破棄させない(2);this.Close();だと再表示でクラッシュする
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		public string TitolStr {
			set {
				titolStr = value;
				titol_tb.Text = titolStr;
			}
			get {
				return titolStr;
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

	}
}
