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
		//		GoogleFolderListUpAsync();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}
		public void ResetTree()
		{
			string TAG = "ResetTree";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				pass_tv.Nodes.Clear();
				GoogleFolderListUp(Constant.RootFolderName);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		/// <summary>
		/// treeViewへGoogleDriveの登録状態表示
		/// </summary>
		public void GoogleFolderListUp(string folderName)
		{
			string TAG = "GoogleFolderListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
			//	Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => GDriveUtil.GDFolderListUpAsyncBody(folderName));
				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => GDriveUtil.GDFileListUp(folderName,true));
				IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(rFolders.Result);

				dbMsg += ",GDriveFolders=" + GDriveFolders.Count + "件";

				if (GDriveFolders != null && GDriveFolders.Count > 0) {
					// ドライブ一覧を走査してツリーに追加
					foreach (Google.Apis.Drive.v3.Data.File folder in GDriveFolders) {
						// 新規ノード作成
						// プラスボタンを表示するため空のノードを追加しておく
						TreeNode node = new TreeNode(folder.Name);
						node.Nodes.Add(new TreeNode());
						pass_tv.Nodes.Add(node);
					}
					pass_tv.Sort();
					pass_tv.EndUpdate();
					//			pass_tv.ExpandAll();                  // すべてのノードを展開する
					GoogleFileListUp(GDriveFolders.Last().Name);
					//		 SetListItem(GDriveFolders.Last().Name);
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
		/// リストビューの項目を設定します.
		/// </summary>
		private  void SetListItem(String filePath)
		{
			string TAG = "SetListItem";
			string dbMsg = "[GoogleDriveBrouser]";
			// リストビューのヘッダーを設定
			file_list_Lv.View = View.Details;
			file_list_Lv.Clear();
			file_list_Lv.Columns.Add("名前");
			file_list_Lv.Columns.Add("更新日時");
			file_list_Lv.Columns.Add("サイズ");

			try {
				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => GDriveUtil.GDFolderListUpAsyncBody(Constant.RootFolderName));
				IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(rFolders.Result);
				dbMsg += "\r\nフォルダ一覧" + GDriveFolders.Count + "件";
				foreach (Google.Apis.Drive.v3.Data.File di in GDriveFolders) {
					string folderName = di.Name;
					dbMsg += "\r\n" + folderName;
					string modifiedTime = String.Format("{0:yyyy/MM/dd HH:mm:ss}", di.ModifiedTime);
					dbMsg += "," + modifiedTime;
					ListViewItem item = new ListViewItem(folderName);
					item.SubItems.Add(modifiedTime);
					item.SubItems.Add("");
					file_list_Lv.Items.Add(item);
				}
				 Constant.GDriveFolderMembers = new List<Google.Apis.Drive.v3.Data.File>(GDriveUtil.GDFileListUp(filePath, false));
				dbMsg += "\r\nファイル一覧" + Constant.GDriveFolderMembers.Count + "件";
				foreach (Google.Apis.Drive.v3.Data.File file in Constant.GDriveFolderMembers) {
					string filerName = file.Name;
					dbMsg += "\r\n" + filerName;
					ListViewItem item = new ListViewItem(filerName);
					item.SubItems.Add(String.Format("{0:yyyy/MM/dd HH:mm:ss}", file.ModifiedTime));
					item.SubItems.Add(file.Size.ToString());
					file_list_Lv.Items.Add(item);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			// 列幅を自動調整
	//		file_list_Lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
		}

		/// <summary>
		/// ノードを開く前
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		private  void PassTvBeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			string TAG = "PassTvBeforeExpand";
			string dbMsg = "[GoogleDriveBrouser]";

			TreeNode node = e.Node;
			String path = node.Text;
			dbMsg += path;
			node.Nodes.Clear();
			try {
				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => GDriveUtil.GDFileListUp(path,true));
				IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(rFolders.Result);
				foreach (Google.Apis.Drive.v3.Data.File di in GDriveFolders) {
					string folderName = di.Name;
					dbMsg += "\r\n" + folderName;
					TreeNode child = new TreeNode(folderName);
					child.Nodes.Add(new TreeNode());
					node.Nodes.Add(child);
				}
	//			node.TreeView.Sort();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// ノードクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void  PassTvNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			string TAG = "PassTvNodeMouseClick";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				string folderName = e.Node.Text;
				dbMsg += folderName;
				MyLog(TAG, dbMsg);
				GoogleFileListUp(folderName);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		/// <summary>
		/// 選択されたフォルダの中身を表示
		/// </summary>
		/// 
		public void GoogleFileListUp(string pFolder)
		{
			string TAG = "GoogleFileListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				dbMsg = "," + pFolder;
				file_list_Lv.Clear();															//listViewの書込み初期化
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
					columnName.Width = 250;
					columnType.Text = "サイズ";
					columnType.Width = 70;
					columnData.Text = "更新日";
					columnData.Width = 120;
					ColumnHeader[] colHeaderRegValue = { this.columnName, this.columnType, this.columnData };
					file_list_Lv.Columns.AddRange(colHeaderRegValue);
					// ListViewコントロールのデータをすべて消去します。
		//			file_list_Lv.Items.Clear();
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
					// 列幅を自動調整
					file_list_Lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				} else {
					dbMsg += "このフォルダはファイルなどが登録されていません";
				}
				MyLog(TAG, dbMsg);
	//			GoogleFolderListUpAsync();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// ファイルリスト選択後
		/// フォルダならその階層に降りて内容表示
		/// ファイルなら選択リストを作成して呼出し元に戻る
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void file_list_Lv_MouseUp(object sender, MouseEventArgs e)
		{
			string TAG = "file_list_Lv_MouseUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				int focusedIndex = file_list_Lv.FocusedItem.Index;         //先頭0の選択位置：：Positionは座標
				dbMsg += ",focused=" + focusedIndex;
				Google.Apis.Drive.v3.Data.File focusedFiles = Constant.GDriveFolderMembers[focusedIndex];
				string focusedName = focusedFiles.Name;
				dbMsg += ",Name=" + focusedName;
				string focusedFilesMimeType = focusedFiles.MimeType;
				dbMsg += ",MimeType=" + focusedFilesMimeType;
				if (focusedFilesMimeType.Equals("application/vnd.google-apps.folder")) {
					dbMsg += ">>フォルダ";
					GoogleFileListUp(focusedName);
					MyLog(TAG, dbMsg);
				} else {
					dbMsg += ">>ファイル";
					if(Constant.GDriveSelectedFiles == null) {
						Constant.GDriveSelectedFiles = new List<Google.Apis.Drive.v3.Data.File>();
					}
					if (file_list_Lv.SelectedItems.Count >= 1) {
						//選択されているリストの情報を出力する
						foreach (ListViewItem item in file_list_Lv.SelectedItems) {
					//		MessageBox.Show(item.Text + " " + item.SubItems[1].Text + " " + item.SubItems[2].Text);
							int selectedIndex = item.Index;
							dbMsg += "\r\nselected=" + selectedIndex;
							Constant.GDriveSelectedFiles.Add(Constant.GDriveFolderMembers[selectedIndex]);
							string fId = Constant.GDriveSelectedFiles[Constant.GDriveSelectedFiles.Count-1].Id;
							dbMsg += "[" + fId;
							string fName = Constant.GDriveSelectedFiles[Constant.GDriveSelectedFiles.Count - 1].Name;
							dbMsg += "]" + fName;
						}
					} else {
						dbMsg += "選択されていません";
					}
					mainForm.FileListUp();
					QuitMe();
					dbMsg += "\r\n選択結果=" + Constant.GDriveSelectedFiles.Count + "件";
					MyLog(TAG, dbMsg);
				}
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

/*
 TreeView と ListView でエクスプローラーのような画面を作成してみた		https://www.doraxdora.com/blog/2018/01/30/post-3801/
 */
