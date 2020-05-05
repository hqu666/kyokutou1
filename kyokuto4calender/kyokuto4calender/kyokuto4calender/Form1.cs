﻿using System;
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
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		GoogleDriveBrouser gdBrouser;
		Edit editForm;
	//	private string receiveData = "";

		ColumnHeader columnName = new ColumnHeader();
		ColumnHeader columnType = new ColumnHeader();
		ColumnHeader columnData = new ColumnHeader();

		public Form1()
		{
			string TAG = "Form1";
			string dbMsg = "[Form1]";
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
				Conect2CalenderAsync(true);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 接続
		/// </summary>
		/// <param name="isListUp"></param>
		private async void Conect2CalenderAsync(Boolean isListUp)
		{
			string TAG = "Conect2CalenderAsync";
			string dbMsg = "[Form1]";
			try {
				String retStr = await GAuthUtil.Authentication("drive_calender.json", "token.json");
				dbMsg += ",retStr=" + retStr;
				if (retStr.Equals("")) {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					String msgStr = "認証されませんでした。\r\n更新ボタンをクリックして下さい";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				} else {
					string UserId = Constant.MyCalendarCredential.UserId;
					dbMsg += ",UserId=" + UserId;
					Constant.MyTokenType = Constant.MyCalendarCredential.Token.TokenType;
					Constant.MyRefreshToken = Constant.MyCalendarCredential.Token.RefreshToken;
					Constant.MyAccessToken = Constant.MyCalendarCredential.Token.AccessToken;

					dbMsg += "\r\nMyCalendar::TokenType=" + Constant.MyTokenType;
					dbMsg += "\r\nRefreshToken=" + Constant.MyRefreshToken;
					dbMsg += "\r\nAccessToken=" + Constant.MyAccessToken;
					MyLog(TAG, dbMsg);
					if (isListUp) {
						EventListUp();
					}
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// treeViewへGoogleDriveの登録状態表示
		/// </summary>
		public void EventListUp()
		{
			string TAG = "EventListUp";
			string dbMsg = "[Form1]";
			try {
				String titolStr = Constant.ApplicationName;
				String msgStr = "";

				Constant.GCalenderEvent = GCalendarUtil.GEventsListUp();
				if (Constant.GCalenderEvent != null ) {
					dbMsg += Constant.GCalenderEvent.Count + "件";

					if ( 0 < Constant.GCalenderEvent.Count) {
						// ListViewコントロールのプロパティを設定
						event_lv.FullRowSelect = true;
						event_lv.GridLines = true;
						event_lv.Sorting = SortOrder.Ascending;
						event_lv.View = View.Details;


						// 列（コラム）ヘッダの作成
						columnName = new ColumnHeader();
						columnType = new ColumnHeader();
						 columnData = new ColumnHeader();
						columnName.Text = "開始";
						columnName.Width = 120;
						columnType.Text = "終了";
						columnType.Width = 120;
						columnData.Text = "タイトル";
						columnData.Width = 200;
						ColumnHeader[] colHeaderRegValue = { this.columnName, this.columnType, this.columnData };
						event_lv.Columns.AddRange(colHeaderRegValue);
						// ListViewコントロールのデータをすべて消去します。
						event_lv.Items.Clear();
						foreach (var eventItem in Constant.GCalenderEvent) {
							string startDT = eventItem.Start.DateTime.ToString();
							dbMsg += "\r\n" + startDT;
							string endDT = eventItem.End.DateTime.ToString();
							dbMsg += "～" + endDT;
							if (String.IsNullOrEmpty(startDT)) {
								startDT = eventItem.Start.Date;
							}
							string Summary = eventItem.Summary;
							dbMsg += "," + Summary;
							// ListViewコントロールにデータを追加します。
							string[] item1 = { startDT, endDT, Summary };
							event_lv.Items.Add(new ListViewItem(item1));
						}
					} else{
					msgStr = "カレンダーには未だ予定が登録されていません";
					}
				} else {
					msgStr = "カレンダーの情報を取得できませんでした";
				}
				if(! msgStr.Equals("")) {
					dbMsg += ",msgStr=" + msgStr;
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					//メッセージボックスを表示する
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// リストアイテムのダブルクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void event_lv_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string TAG = "event_lv_MouseDoubleClick";
			string dbMsg = "[Form1]";
			try {
				int selectedIndex = event_lv.FocusedItem.Index;         //先頭0の選択位置：：Positionは座標
				dbMsg += ",Index=" + selectedIndex;
				Constant.eventItem = new Google.Apis.Calendar.v3.Data.Event();
				Constant.eventItem = Constant.GCalenderEvent[selectedIndex];
				string startDT = Constant.eventItem.Start.DateTime.ToString();
				dbMsg += ")" + startDT;
				string endDT = Constant.eventItem.End.DateTime.ToString();
				dbMsg += "～" + endDT;
				if (String.IsNullOrEmpty(startDT)) {
					startDT = Constant.eventItem.Start.Date;
				}
				string Summary = Constant.eventItem.Summary;
				dbMsg += "," + Summary;
				if (editForm == null) {
					dbMsg = "Editを再生成";
					editForm = new Edit();
					editForm.mainForm = this;
				}
				editForm.eventItem = new Google.Apis.Calendar.v3.Data.Event();
				editForm.eventItem = Constant.eventItem;
				MyLog(TAG, dbMsg);
				editForm.Show();
				editForm.SetEditData();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		/// <summary>
		/// リストのダブルクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void event_lv_SelectedIndexChanged(object sender, EventArgs e)
		{
			string TAG = "event_lv_SelectedIndexChanged";
			string dbMsg = "[Form1]";
			try {
				//int selectedIndex = event_lv.FocusedItem.Index;         //先頭0の選択位置：：Positionは座標
				//dbMsg += ",Index=" + selectedIndex  ;
				//Google.Apis.Calendar.v3.Data.Event eventItem = Constant.GCalenderEvent[selectedIndex];
				//string startDT = eventItem.Start.DateTime.ToString();
				//dbMsg += ")" + startDT;
				//string endDT = eventItem.End.DateTime.ToString();
				//dbMsg += "～" + endDT;
				//if (String.IsNullOrEmpty(startDT)) {
				//	startDT = eventItem.Start.Date;
				//}
				//string Summary = eventItem.Summary;
				//dbMsg += "," + Summary;

				//if (editForm == null) {
				//	dbMsg = "Editを再生成";
				//	editForm = new Edit();
				//	editForm.mainForm = this;
				//}
				//editForm.eventItem = eventItem;
				//editForm.Show();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 現場マスタの添付ファイルパス
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void master_folder_url_bt_Click(object sender, EventArgs e)
		{
			string TAG = "master_folder_url_bt_Click";
			string dbMsg = "[Form1]";
			try {
				if (gdBrouser == null) {
					dbMsg = "GoogleDriveBrouserを生成";
					gdBrouser = new GoogleDriveBrouser();
					gdBrouser.mainForm = this;
				}
				gdBrouser.Show();
				gdBrouser.GoogleFolderListUp();
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

		/// <summary>
		/// カレンダークリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void event_mc_DateChanged(object sender, DateRangeEventArgs e)
		{
			string TAG = "event_mc_DateChanged";
			string dbMsg = "[Form1]";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
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
/*
 .NET Quickstart		https://developers.google.com/calendar/quickstart/dotnet
 
 
 */
