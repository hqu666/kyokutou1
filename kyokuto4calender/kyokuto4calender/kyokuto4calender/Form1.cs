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
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		GoogleDriveBrouser gdBrouser;
		Edit editForm;

		ColumnHeader columnName = new ColumnHeader();
		ColumnHeader columnType = new ColumnHeader();
		ColumnHeader columnData = new ColumnHeader();
		ColumnHeader columnParent = new ColumnHeader();
		ColumnHeader columnFName = new ColumnHeader();

		/// <summary>
		/// 起動
		/// </summary>
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
		/// treeViewへEventの登録状態表示
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
						columnData.Width = 240;
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
		/// EventのDescriptionに添付ファイルを埋め込む
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void event_lv_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string TAG = "event_lv_MouseDoubleClick";
			string dbMsg = "[Form1]";
			try {
				ReWriteEvent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// Descriptionに添付ファイルのリンクを追加してEventを更新
		/// </summary>
		private void ReWriteEvent()
		{
			string TAG = "ReWriteEvent";
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
				string eDescription = Constant.eventItem.Description;
				if (eDescription == null) {
					eDescription = "";
				} else {
					eDescription += "</br>";
				}
				dbMsg += ",Description=" + eDescription;
				if (Constant.GDriveSelectedFiles != null) {
					dbMsg += ",添付⁼" + Constant.GDriveSelectedFiles.Count + "件";
					if (0 < Constant.GDriveSelectedFiles.Count) {
						if (eDescription.Contains("添付ファイル")) {
							eDescription += "<table>";
						} else {
							eDescription += "添付ファイル</br><table>";
						}
						foreach (Google.Apis.Drive.v3.Data.File fileItem in Constant.GDriveSelectedFiles) {
							string fId = fileItem.Id;
							dbMsg += "\r\n" + fId;
							string ParentsID = fileItem.Parents[0];
							dbMsg += "[Parents=" + ParentsID;
							string ParentsName = GDriveUtil.FindById(ParentsID);
							dbMsg += "]" + ParentsName;
							string fName = fileItem.Name.ToString();
							dbMsg += "," + fName;
							string fLink = fileItem.WebContentLink.ToString();
							dbMsg += "," + fLink;
							eDescription += "<tr>";
							eDescription += "<td>" + ParentsName + "</td>";
							eDescription += "<td  style=\"padding: 10px 10px; \"><a href=\"" + fLink + "\">" + fName + "</a></td>";
							eDescription += "</tr>";
						}
						eDescription += "</table>";
						dbMsg += ",Description=\r\n" + eDescription;
						Constant.eventItem.Description = eDescription;
						string retLink = GCalendarUtil.UpDateGEvents();
						dbMsg += "\r\nretLink" + retLink;
						try {
							System.Diagnostics.Process.Start(retLink);				//webで表示
						} catch (
							   System.ComponentModel.Win32Exception noBrowser) {
							if (noBrowser.ErrorCode == -2147467259)
								MessageBox.Show(noBrowser.Message);
						} catch (System.Exception other) {
							MessageBox.Show(other.Message);
						}

					} else {
						dbMsg += "添付するファイルが登録されていません";
					}
				} else {
					dbMsg += "添付するファイルの情報を取得できませんでした";
				}

				MyLog(TAG, dbMsg);
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
		/// 添付ファイル選択ボタンのクリック
		/// ファイルブラウザに遷移し、選択されたファイルを記録する
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
				gdBrouser.ResetTree();
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

		/// <summary>
		/// 選択されたファイルのリストアップ
		/// </summary>
		public void FileListUp()
		{
			string TAG = "FileListUp";
			string dbMsg = "[Form1]";
			try {
				String titolStr = Constant.ApplicationName;
				String msgStr = "";
				attach_file_lv.Items.Clear();
				attach_file_lv.Clear();
				if (Constant.GDriveSelectedFiles != null) {
					int fileCount = Constant.GDriveSelectedFiles.Count;
					file_count_lv.Text = fileCount.ToString();
					dbMsg += fileCount + "件";
					if (0 < Constant.GDriveSelectedFiles.Count) {
						// ListViewコントロールのプロパティを設定
						attach_file_lv.FullRowSelect = true;
						attach_file_lv.GridLines = true;
						attach_file_lv.Sorting = SortOrder.Ascending;
						attach_file_lv.View = View.Details;

						// 列（コラム）ヘッダの作成
						columnParent = new ColumnHeader();
						columnFName = new ColumnHeader();
						columnParent.Text = "フォルダ";
						columnParent.Width = 110;
						columnFName.Text = "ファイル";
						columnFName.Width = 110;
						ColumnHeader[] colHeaderRegValue = { this.columnParent, this.columnFName };
						attach_file_lv.Columns.AddRange(colHeaderRegValue);

						attach_file_lv.Sorting = SortOrder.Ascending;
						foreach (var fileItem in Constant.GDriveSelectedFiles) {
							string ParentsID = fileItem.Parents[0];
							dbMsg += "\r\n[Parents=" + ParentsID;
							string ParentsName = GDriveUtil.FindById(ParentsID);
							dbMsg += "]" + ParentsName;
							string fName = fileItem.Name.ToString();
							dbMsg += "," + fName;
							// ListViewコントロールにデータを追加します。
							string[] item1 = { ParentsName, fName };
							attach_file_lv.Items.Add(new ListViewItem(item1));
						}
					} else {
						msgStr = "添付するファイルが登録されていません";
					}
				} else {
					msgStr = "添付するファイルの情報を取得できませんでした";
				}
				if (!msgStr.Equals("")) {
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
		/// 選択したファイルを解除する
		/// 
		/// GDriveSelectedFilesはGoogleDriveBrouser.file_list_Lv_MouseUpで追記する時に生成されていなければ、そこでも再生成される
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void serected_clear_bt_Click(object sender, EventArgs e)
		{
			string TAG = "serected_clear_bt_Click";
			string dbMsg = "[Form1]";
			try {
				if (Constant.GDriveSelectedFiles != null) {
					dbMsg += Constant.GDriveSelectedFiles.Count + "件";
					Constant.GDriveSelectedFiles = new List<Google.Apis.Drive.v3.Data.File>();
					Constant.GDriveSelectedFiles.Clear();
					dbMsg += ">>" + Constant.GDriveSelectedFiles.Count + "件";
					attach_file_lv.Clear();
					int fileCount = Constant.GDriveSelectedFiles.Count;
					file_count_lv.Text = fileCount.ToString();
					dbMsg += ">>" + fileCount + "件";

				}
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
