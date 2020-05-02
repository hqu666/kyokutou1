using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace kyokuto4calender {
	public partial class Edit : Form {
		public Form1 mainForm;
		public Google.Apis.Calendar.v3.Data.Event eventItem = null;

		private string sendData = "";
		private string titolStr = "";


		public Edit()
		{
			string TAG = "Edit";
			string dbMsg = "[Edit]";
			try {
				InitializeComponent();
				SetEditData();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 既存データの書込み
		/// </summary>
		private void SetEditData()
		{
			string TAG = "SetEditData";
			string dbMsg = "[Edit]";
			try {
				string startDT = eventItem.Start.DateTime.ToString();
				dbMsg += ")" + startDT;
				string endDT = eventItem.End.DateTime.ToString();
				dbMsg += "～" + endDT;
				if (String.IsNullOrEmpty(startDT)) {
					startDT = eventItem.Start.Date;
				}
				string Summary = eventItem.Summary;
				dbMsg += "," + Summary;


				summary_tb.Text = eventItem.Summary;
				start_dtp.Value = eventItem.Start.DateTime.Value;
				end_dtp.Value = eventItem.End.DateTime.Value;
				location_tb.Text = eventItem.Location;
				description_tb.Text = eventItem.Location;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		//private void titolbt_TextChanged(object sender, EventArgs e)
		//{

		//}

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

		/// <summary>
		/// このフォームを閉じる
		/// ※this.Close();だと再表示でクラッシュするのでthis.Visible = false;でこのオブジェクトを破棄させない
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[Edit]";
			try {
				dbMsg += "titolStr=" + titolStr;
				if (mainForm != null) {
					this.Visible = false;//このオブジェクトを破棄させない(2);this.Close();だと再表示でクラッシュする
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		//public string TitolStr {
		//	set {
		//		titolStr = value;
		//		summary_tb.Text = titolStr;
		//	}
		//	get {
		//		return titolStr;
		//	}
		//}
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
