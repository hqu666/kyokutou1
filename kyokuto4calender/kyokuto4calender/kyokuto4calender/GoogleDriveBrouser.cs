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
using System.Threading;

namespace kyokuto4calender {
	public partial class GoogleDriveBrouser : Form {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public Form1 mainForm;
		public IList<string> passList = new List<string>();
		public string cureentPassName = "";				//現在のパス名

		ColumnHeader columnName = new ColumnHeader();
		ColumnHeader columnType = new ColumnHeader();
		ColumnHeader columnData = new ColumnHeader();

		public GoogleDriveBrouser()
		{
			string TAG = "GoogleDriveBrouser";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 遷移直後の初期書込み
		/// </summary>
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
		/// パスラベルの書き換え
		/// nullを与えればリストから削除
		/// </summary>
		/// <param name="passName"></param>
		public string SetPassLabel(string passName)
		{
			string TAG = "SetPassLabel";
			string dbMsg = "[GoogleDriveBrouser]";
			string rStr = "";
			try {
				Thread.Sleep(1);
				string strSelectedNode;
				strSelectedNode = pass_tv.SelectedNode.Text;                  // 選択されたノードを取得
				dbMsg += strSelectedNode + "を選択中";
				string fullPath = pass_tv.SelectedNode.FullPath;
				dbMsg += ">>" + fullPath ;
				pass_name_lb.Text = fullPath;
				rStr = strSelectedNode;
				/*
int lCount = passList.Count();
dbMsg += lCount+ "階層";
if (passName.Equals(Constant.TopFolderName) && 1 < lCount) {
return passName;
}else if(2 < lCount) {
passList.RemoveAt(passList.Count - 1);
}
if (passName == null) {
dbMsg += "削除";
if(1< passList.Count) {
passList.RemoveAt(passList.Count - 1);
}else{
dbMsg += "不能";
}
} else{
dbMsg += passName + "を追加";
passList.Add(passName);
}
string folderStrs = "";
foreach (string passN in passList) {
folderStrs += "/" + passN;
rStr = passN;
}
dbMsg += ","+ rStr;
pass_name_lb.Text = folderStrs;
if (passName.Equals(Constant.RootFolderName)) {
SetPassLabel(Constant.TopFolderName);
}
*/
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return rStr;
		}

		/// <summary>
		/// 上の階層に戻す
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pass_name_lb_Click(object sender, EventArgs e)
		{
			cureentPassName = SetPassLabel(null);
		}

		/// <summary>
		/// treeViewへGoogleDriveの登録状態表示
		/// </summary>
		public void GoogleFolderListUp(string folderName)
		{
			string TAG = "GoogleFolderListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				dbMsg += folderName + "を開く";
				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => {
					return GDriveUtil.GDFileListUp(folderName, true);
				});
				rFolders.Wait();
				IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(rFolders.Result);
				if (GDriveFolders != null && GDriveFolders.Count > 0) {
					dbMsg += ",中に" + GDriveFolders.Count + "件";
					// ドライブ一覧を走査してツリーに追加
					foreach (Google.Apis.Drive.v3.Data.File folder in GDriveFolders) {
						string mFolderName = folder.Name;
						dbMsg += ",\r\n" + mFolderName ;
						// 新規ノード作成
						// プラスボタンを表示するため空のノードを追加しておく
						TreeNode node = new TreeNode(mFolderName);
						node.Nodes.Add(new TreeNode());
						pass_tv.Nodes.Add(node);
						pass_tv.SelectedNode = node;			//最後のノードが選択される
					}
				//	pass_tv.Sort();		//渡された配列がソートされていなければ
					pass_tv.EndUpdate();
				//	pass_tv.Select=folderName;
					//			pass_tv.ExpandAll();                  // すべてのノードを展開する
					GoogleFileListUp(folderName);
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
				pass_name_lb.Text = Constant.RootFolderName + "\\" + pass_tv.SelectedNode.FullPath;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// ノードが選択された後
		/// pass_tv_MouseUpやPassTvNodeMouseClickではSelectedNodeが取れない
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pass_tv_AfterSelect(object sender, TreeViewEventArgs e)
		{
			string TAG = "PassTvNodeMouseClick";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				string folderName = e.Node.Text;
				//TreeNode selectedNode = pass_tv.SelectedNode;
				//string folderName = selectedNode.Text;
				dbMsg += folderName;
				MyLog(TAG, dbMsg);
				GoogleFileListUp(folderName);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		/// <summary>
		/// ListViewに選択されたフォルダの中身を表示
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
					columnName.Width = 245;
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
					//		file_list_Lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);					// 列幅を自動調整
					cureentPassName = SetPassLabel(pFolder);
				} else {
					dbMsg += "このフォルダはファイルなどが登録されていません";
				}
				MyLog(TAG, dbMsg);
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
				dbMsg += ",focused[" + focusedIndex;
				Google.Apis.Drive.v3.Data.File focusedFiles = Constant.GDriveFolderMembers[focusedIndex];
				string focusedName = focusedFiles.Name;
				dbMsg += "]" + focusedName;
				string focusedFilesMimeType = focusedFiles.MimeType;
				dbMsg += ",MimeType=" + focusedFilesMimeType;
				if (focusedFilesMimeType.Equals("application/vnd.google-apps.folder")) {
					dbMsg += ">>フォルダ" + focusedName + "を開く" ;
					MyLog(TAG, dbMsg);
					GoogleFileListUp(focusedName);
				} else {
					dbMsg += ">>ファイル" + focusedName + "を送る";
					if (Constant.GDriveSelectedFiles == null) {
						Constant.GDriveSelectedFiles = new List<Google.Apis.Drive.v3.Data.File>();
					}
					if (file_list_Lv.SelectedItems.Count >= 1) {
						//選択されているリストの情報を出力する
						foreach (ListViewItem item in file_list_Lv.SelectedItems) {
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
					dbMsg += "\r\n選択結果=" + Constant.GDriveSelectedFiles.Count + "件";
					MyLog(TAG, dbMsg);
					mainForm.FileListUp();
					QuitMe();
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void file_open_bt_Click(object sender, EventArgs e)
		{
			string TAG = "file_open_bt_Click";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				//複数のファイルを選択できるようにする
				openFDialog.Multiselect = true;
				DialogResult dr = openFDialog.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK) {
					LFUtil.ListUpFolderFiles(openFDialog);
					int fCount = 0;
					foreach (string str in Constant.selectFiles) {
						string fileName = System.IO.Path.GetFileName(@str);
						dbMsg += "\r\n" + fileName;
						Constant.selectFiles[fCount] = fileName;
						fCount++;
					}
				}
				GFilePut();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// ファイルをドロップ終了時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void file_list_Lv_DragEnter(object sender, DragEventArgs e)
		{
			string TAG = "file_list_Lv_DragEnter";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
					e.Effect = DragDropEffects.All;
				} else {
					e.Effect = DragDropEffects.None;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// ファイルをドロップ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void file_list_Lv_DragDrop(object sender, DragEventArgs e)
		{
			string TAG = "file_list_Lv_DragDrop";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
				int fileCount = files.Length;
				dbMsg += fileCount + "件";

				String titolStr = Constant.ApplicationName;
				String msgStr = "ファイルを取得できませんでした。\r\n" +
											"もう一度、送信したいファイルをドロップしてください";
				MessageBoxButtons buttns = MessageBoxButtons.OK;
				MessageBoxIcon icon = MessageBoxIcon.Warning;
				MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
				if (0 < fileCount) {
					msgStr = "";
					Constant.MakeFolderName = "";
					Constant.selectFiles = new string[fileCount];
					for (int i = 0; i < files.Length; i++) {
						string rStr = files[i];
						if (Constant.MakeFolderName.Equals("")) {
							Constant.MakeFolderName = LFUtil.GetPearentPass(rStr, Constant.TopFolderName);
							msgStr += Constant.TopFolderName + "の" + Constant.MakeFolderName + "に\r\n";
						}
						string fileName = LFUtil.GetFileNameExt(rStr);
						dbMsg += "\r\n" + i + ")" + fileName;
						Constant.selectFiles[i] = fileName;
						msgStr += fileName + "\r\n";
					}
					buttns = MessageBoxButtons.OKCancel;
					icon = MessageBoxIcon.Information;
				}
				//	if (1 == Constant.selectFiles.Count()) {
				////		Constant.MakeFolderName = Constant.selectFiles[0];
				//		msgStr = Constant.TopFolderName + "に\r\n" + Constant.MakeFolderName + msgStr + " を作成します";
				//	} else {
				msgStr += "\r\nを登録します";
				//	}
				DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
				dbMsg += ",result=" + result;
				if (result == DialogResult.OK) {        //「はい」が選択された時
					dbMsg += ">>送信";
					GFilePut();                            //送信
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}


		/// <summary>
		/// GoogleDriveへ書き込み
		/// System.io.FileでPCのローカルファイルを読み出すのでGoogleDriveクラスと分離
		/// </summary>
		public void GFilePut()
		{
			string TAG = "GFilePut";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				dbMsg += "書込むフォルダ＝" + Constant.MakeFolderName;
				if (Constant.MakeFolderName == null || Constant.selectFiles == null) {
					String titolStr = Constant.ApplicationName;
					String msgStr = "送信するファイルを選択して下さい";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Warning;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
					return;
				}
				///		await Conect2DriveAsync(false);

				Task<string> newFolder = Task.Run(() => {
					return  GDriveUtil.CreateFolder(Constant.MakeFolderName, Constant.TopFolderID, Constant.RootFolderID);
				});
				try {
					// 例外をキャッチする場合には、Waitメソッドを実施している部分をtry...catchでくくります。
					// 例外が発生すると、AggregateExceptionにラップされてスローされます。
					newFolder.Wait();
				} catch (AggregateException ae) {
					MyErrorLog(TAG, dbMsg + "でエラー発生;" + ae);
				}
				string parentId = newFolder.Result;
				dbMsg += ">parent>" ;
				if (parentId == null) {
					String titolStr = Constant.ApplicationName;
					String msgStr = "フォルダを作成できませんでした。\r\nもう一度書込むファイルをドロップしてください";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += msgStr + ",result=" + result;
				} else {
					dbMsg += "[" + parentId + "]に" + Constant.selectFiles.Count() + "件";
					foreach (string str in Constant.selectFiles) {
						dbMsg += "\r\n" + str;
						string fullName = System.IO.Path.Combine(Constant.LocalPass, str);
						dbMsg += ">>" + fullName;
						Task<string> wrfile = Task.Run(() => {
							return GDriveUtil.UploadFile(str, fullName, parentId);
						});
						wrfile.Wait();
						String wrfileId = wrfile.Result;
						dbMsg += ">作成>[" + wrfileId + "]";
					}
			}
				MyLog(TAG, dbMsg);
				GoogleFolderListUp(Constant.MakeFolderName);                     //更新状態を再描画
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
