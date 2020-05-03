﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;
using System.Web;

using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace kyokuto4calender {
	public partial class Edit : Form {
		public Form1 mainForm;
		public Google.Apis.Calendar.v3.Data.Event eventItem = null;


		public Edit()
		{
			string TAG = "Edit";
			string dbMsg = "[Edit]";
			try {
				InitializeComponent();
				eventItem = new Google.Apis.Calendar.v3.Data.Event();
				SetEditData();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 既存データの書込み
		/// </summary>
		public void SetEditData()
		{
			string TAG = "SetEditData";
			string dbMsg = "[Edit]";
			try {
				//this.eventItem = new Google.Apis.Calendar.v3.Data.Event();
				//this.eventItem = Constant.eventItem;

				//string startDT = eventItem.Start.DateTime.ToString();
				//dbMsg += ")" + startDT;
				//string endDT = eventItem.End.DateTime.ToString();
				//dbMsg += "～" + endDT;
				//if (String.IsNullOrEmpty(startDT)) {
				//	startDT = eventItem.Start.Date;
				//}

				owner_adress_lb.Text = Constant.CalenderSummary;        //Eventsのフィールド
				//string Summary = eventItem.Summary;
				//dbMsg += "," + Summary;
				summary_tb.Text = Constant.eventItem.Summary;
				start_dtp.Value = Constant.eventItem.Start.DateTime.Value;
				end_dtp.Value = Constant.eventItem.End.DateTime.Value;
				location_tb.Text = Constant.eventItem.Location;
				string description = eventItem.Description;
				dbMsg += "," + description ;
				description_tb.Text = description;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// webで編集
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void send_web_bt_Click(object sender, EventArgs e)
		{
			string TAG = "send_web_bt_Click";
			string dbMsg = "[Edit]";
			try {
				string htmlLink = Constant.eventItem.HtmlLink ;
			//	htmlLink +=  "?sf=true";//=が%3Dに化けるので編集画面に入れない
				dbMsg += ",htmlLink=" + htmlLink;
				try {
					System.Diagnostics.Process.Start(htmlLink);
				} catch (
					   System.ComponentModel.Win32Exception noBrowser) {
					if (noBrowser.ErrorCode == -2147467259)
						MessageBox.Show(noBrowser.Message);
				} catch (System.Exception other) {
					MessageBox.Show(other.Message);
				}
				MyLog(TAG, dbMsg);
				QuitMe();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 削除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void delat_bt_Click(object sender, EventArgs e)
		{

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

		/// <summary>
		/// このフォームを閉じる
		/// ※this.Close();だと再表示でクラッシュするのでthis.Visible = false;でこのオブジェクトを破棄させない
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[Edit]";
			try {
				if (mainForm != null) {
					this.Visible = false;//このオブジェクトを破棄させない(2);this.Close();だと再表示でクラッシュする
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		public Google.Apis.Calendar.v3.Data.Event EventItem {
			set {
				eventItem = value;
			}
			get {
				return eventItem;
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
