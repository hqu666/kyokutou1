using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Drive.v3;
using Google.Apis.Calendar.v3.Data;

namespace kyokuto4calender {
	public partial class GoogleDriveBrouser : Form {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public Form1 mainForm;

		ColumnHeader columnName = new ColumnHeader();
		ColumnHeader columnType = new ColumnHeader();
		ColumnHeader columnData = new ColumnHeader();

		public GoogleDriveBrouser()
		{
			string TAG = "GoogleDriveBrouser";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				InitializeComponent();
		//		Conect2DriveAsync(true);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// treeViewへGoogleDriveの登録状態表示
		/// </summary>
		public void GoogleFolderListUp()
		{
			string TAG = "GoogleFolderListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				Constant.GDriveFiles =null;
				Constant.GDriveFiles = GDriveUtil.GDFileListUp(Constant.RootFolderName, true);
				Constant.GDriveFolders = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();
				dbMsg += ",GDriveFiles=" + Constant.GDriveFiles.Count + "件";

				if (Constant.GDriveFiles != null && Constant.GDriveFiles.Count > 0) {
					// フォルダIDの取得	;一行目にはフォルダ名/二行目以降はファイル情報
					Constant.parentFolderId = Constant.GDriveFiles.First().Id;
					String folderName = Constant.GDriveFiles.First().Name;
					//フォルダ階層の取得
					foreach (var file in Constant.GDriveFiles) {
						String fName = file.Name;
						String fId = file.Id;
						//	if (file.Parents != null) {
						//		String PId = file.Parents[0];
						//		String fMimeType = file.MimeType;
						//		DateTime fModifiedTime = (DateTime)file.ModifiedTime;
						//		if (fName.Equals(Constant.TopFolderName)) {
						//			//最上位にするフォルダと
						//			Constant.TopFolderID = fId;
						//			Constant.RootFolderID = PId;
						////			info_lb.Text = fName;                                           //照合が合っているか確認の為
						//		} else
					//	if (fMimeType.Equals("application/vnd.google-apps.folder")) {
							Constant.GDriveFolders.Add(fId, file);                                           //最上位以外のフォルダを格納
					//	}
																										 //	}
					}
					dbMsg += "[top=" + Constant.TopFolderID + "]";
					dbMsg += "[root=" + Constant.RootFolderID + "]";
					dbMsg += ",folders" + Constant.GDriveFolders.Count() + "件";
					int nodeCount = 0;
					pass_tv.Nodes.Clear();                    //viewを初期化して
					pass_tv.BeginUpdate();                    //	更新開始

					foreach (var folder in Constant.GDriveFolders) {
						dbMsg += "\r\nfolder=" + folder.Key;
						dbMsg += ":" + folder.Value.Name;
						dbMsg += ":" + folder.Value.Parents[0];
						pass_tv.Nodes.Add(folder.Value.Name);
						foreach (var file in Constant.GDriveFiles) {
							String PId = file.Parents[0];
							if (folder.Key.Equals(PId)) {
								String fName = file.Name;
								String fId = file.Id;
								String fMimeType = file.MimeType;
							}
						}
						nodeCount++;
					}
					pass_tv.EndUpdate();
					pass_tv.ExpandAll();                  // すべてのノードを展開する
				} else {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					String msgStr = "送信先ドライブには未だファイルが登録されていません";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// クリックされたフォルダの中身を表示
		/// </summary>
		public void GoogleFileListUp(string pFolder)
		{
			string TAG = "GoogleFileListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				dbMsg = "," + pFolder;
				Constant.GDriveFolderMembers = null;
				Constant.GDriveFolderMembers = GDriveUtil.GDFileListUp(pFolder, false);
				if (Constant.GDriveFolderMembers != null) {
					dbMsg = "," + Constant.GDriveFolderMembers.Count + "件";
					// ListViewコントロールのプロパティを設定
					file_list_Lv.FullRowSelect = true;
					file_list_Lv.GridLines = true;
					file_list_Lv.Sorting = SortOrder.Ascending;
					file_list_Lv.View = View.Details;

					// 列（コラム）ヘッダの作成
					columnName = new ColumnHeader();
					columnType = new ColumnHeader();
					columnData = new ColumnHeader();
					columnName.Text = "名前";
					columnName.Width = 200;
					columnType.Text = "サイズ";
					columnType.Width = 120;
					columnData.Text = "更新日";
					columnData.Width = 120;
					ColumnHeader[] colHeaderRegValue = { this.columnName, this.columnType, this.columnData };
					file_list_Lv.Columns.AddRange(colHeaderRegValue);
					// ListViewコントロールのデータをすべて消去します。
					file_list_Lv.Items.Clear();
					foreach (var fileItem in Constant.GDriveFolderMembers) {
						string fNmae = fileItem.Name.ToString();
						dbMsg += "\r\n" + fNmae;
						string fSize = fileItem.Size.ToString();
						dbMsg += "," + fSize;
						//if (String.IsNullOrEmpty(startDT)) {
						//	startDT = fileItem.Start.Date;
						//}
						string fModifiedTime = fileItem.ModifiedTime.ToString();
						dbMsg += "," + fModifiedTime;
						// ListViewコントロールにデータを追加します。
						string[] item1 = { fNmae, fSize, fModifiedTime };
						file_list_Lv.Items.Add(new ListViewItem(item1));
					}
				} else {
					dbMsg += "このフォルダはファイルなどが登録されていません";
				}
				GoogleFolderListUp();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// ファイルリストアイテムのダブルクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void file_list_LV_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			string TAG = "file_list_LV_MouseDoubleClick";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void GoogleDriveBrouser_FormClosing(object sender, FormClosingEventArgs e){ 
			string TAG = "GoogleDriveBrouser_FormClosing";
			string dbMsg = "[Edit]";
			try {
				e.Cancel = true;                //このオブジェクトを破棄させない(1)
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
			private void QuitMe(){
			string TAG = "QuitMe";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				if (mainForm != null) {
					this.Visible = false;//このオブジェクトを破棄させない(2);this.Close();だと再表示でクラッシュする
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
