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
		public string cureentPassName = "";									 //現在のパス名
		public IList<string> fullNames = new List<string>();            //PC内ファイルリスト
		public  string GoogleDriveMime_Folder = Constant.GoogleDriveMime_Folder;

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
		/// TreeViewを完全に消してからドライブ情報の再読込み
		/// 遷移直後の初期書込みとGoogleドライブへのファイル登録/削除操作後
		/// </summary>
		/// <param name="parentFolder">開いておく階層：省略すればTopへ</param>
		public void ResetTree(string parentFolder = null)
		{
			string TAG = "ResetTree";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				pass_tv.Nodes.Clear();
				GoogleFolderListUp(Constant.RootFolderName);
				dbMsg = "," + parentFolder;
				if (parentFolder == null) {
					parentFolder = Constant.TopFolderName;
					dbMsg = ">>" + parentFolder;
				}

				cureentPassName = SetPassLabel(parentFolder);
				dbMsg += ">現在の選択>" + cureentPassName;
				pass_tv.ExpandAll();
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
				dbMsg += "," + passName;
				TreeNodeSelect(passName);															//指定したノードを選択して
		//		pass_tv.Select();
				//string strSelectedNode = pass_tv.SelectedNode.Text;
				//dbMsg += strSelectedNode + "を選択中";
				string fullPath = pass_tv.SelectedNode.FullPath;                  // 選択されたノードを取得
				dbMsg += ">>" + fullPath;
				pass_name_lb.Text = Constant.RootFolderName + "\\" + fullPath;
				rStr = pass_name_lb.Text;
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
			string TAG = "pass_name_lb_Click";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				TreeNode selected = pass_tv.SelectedNode;
				string strSelectedNode = selected.Text;                  // 選択されたノードを取得
				dbMsg += strSelectedNode + "を選択中";
				TreeNode parent = selected.Parent;
				dbMsg += ">>" + parent.Text + ">>";
				pass_tv.SelectedNode= parent;
				selected = pass_tv.SelectedNode;
				strSelectedNode = selected.Text;                  // 選択されたノードを取得
				dbMsg += strSelectedNode + "に移動";
				cureentPassName = SetPassLabel(strSelectedNode);
				dbMsg += ">現在の選択>" + cureentPassName;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}

		}

		/// <summary>
		/// treeViewへGoogleDriveの登録状態表示
		/// 描画後はlistViewの描画に
		/// </summary>
		/// <param name="folderName"></param>
		public void GoogleFolderListUp(string folderName)
		{
			string TAG = "GoogleFolderListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {

				dbMsg += folderName + "を開き";
				if(0 < pass_tv.Nodes.Count) {
					TreeNodeSelect(folderName);                                                           //親ノードを選択して
					string parentNode = pass_tv.SelectedNode.FullPath;                  // 選択されたノードを取得
					dbMsg += parentNode + "に配置したい";
				}else{
					dbMsg +=  "最上位に配意したい";
				}

				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => {
					return GDriveUtil.GDFileListUp(folderName, true);
				});
				rFolders.Wait();
				IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(rFolders.Result);
				TreeNode targetNode = new TreeNode();
				TreeNode node = new TreeNode();
				if (GDriveFolders != null) {          // && 0< GDriveFolders.Count  だと件数が取れてない
					dbMsg += ",サブフォルダ" + GDriveFolders.Count + "件";
					// ドライブ一覧を走査してツリーに追加
					foreach (Google.Apis.Drive.v3.Data.File folder in GDriveFolders) {
						string mFolderName = folder.Name;
						dbMsg += ",\r\n" + mFolderName ;
						// 新規ノード作成
						// プラスボタンを表示するため空のノードを追加しておく
						node = new TreeNode(mFolderName);
						node.Nodes.Add(new TreeNode());
						pass_tv.Nodes.Add(node);
						if (@folderName.Equals(@mFolderName)) {
							targetNode = node;
							dbMsg += ",\r\n最終選択=" + targetNode.Text;
						}
					}
					dbMsg += ",\r\n" + pass_tv.Nodes.Count + "件";
					//	pass_tv.Sort();		//渡された配列がソートされていなければ使用；List()メソッドでlistRequest.OrderBy = "name";を指定済みなので不要化
					pass_tv.EndUpdate();
					//		pass_tv.ExpandAll();                  // すべてのノードを展開する;ノードごとにPassTvBeforeExpandが発生する
					//	GoogleFileListUp(folderName);	//pass_tv_AfterSelectから呼ぶ
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
		/// 選択したノードの内容を開く前に追記する」
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		private void PassTvBeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			string TAG = "PassTvBeforeExpand";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				TreeNode node = e.Node;
				String path = node.Text;
				dbMsg += "選択：" + path;
				AddChildNood( node);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		public void AddChildNood(TreeNode node)
		{
			string TAG = "AddChildNood";
			string dbMsg = "[GoogleDriveBrouser]";
			String path = node.Text;
			dbMsg += "選択：" + path;
			node.Nodes.Clear();
			try {
				Task<IList<Google.Apis.Drive.v3.Data.File>> folderTask = Task.Run(() => {
					return GDriveUtil.GDFileListUp(path, true);
				});
				folderTask.Wait();
				IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(folderTask.Result);
				foreach (Google.Apis.Drive.v3.Data.File di in GDriveFolders) {
					string folderName = di.Name;
					dbMsg += "\r\n" + folderName;
					TreeNode child = new TreeNode(folderName);
					child.Nodes.Add(new TreeNode());
					node.Nodes.Add(child);
				}
				SetPassLabel(path);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		public void AddChild2Node(TreeNode parentNode , String addFolder)
		{
			string TAG = "AddChild2Node";
			string dbMsg = "[GoogleDriveBrouser]";
			dbMsg += parentNode.Text + " に " + addFolder +"を追加";
			parentNode.Nodes.Clear();
			try {
				Task<IList<Google.Apis.Drive.v3.Data.File>> folderTask = Task.Run(() => {
					return GDriveUtil.GDFileListUp(@addFolder, true);
				});
				folderTask.Wait();
				IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(folderTask.Result);
				dbMsg += " ,取得 " + GDriveFolders.Count + "件"; 
				TreeNodeSelect(parentNode.Text);                                                           //親ノードを選択して

				foreach (Google.Apis.Drive.v3.Data.File di in GDriveFolders) {
					string folderName = di.Name;
					dbMsg += "\r\n" + folderName;
					TreeNode child = new TreeNode(@folderName);
					child.Nodes.Add(new TreeNode());
					parentNode.Nodes.Add(child);
				}
				//		pass_tv.EndUpdate();
				cureentPassName = SetPassLabel(@addFolder);
				dbMsg += ">現在の選択>" + cureentPassName;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 渡されたリストを指定したノードの子ノードに追加する
		/// </summary>
		/// <param name="parentNode"></param>
		/// <param name="addFolder"></param>
		public void AddList2Node(string parentName, IList<Google.Apis.Drive.v3.Data.File> GDriveFolders)
		{
			string TAG = "AddList2Node";
			string dbMsg = "[GoogleDriveBrouser]";
			dbMsg += parentName + " に " + GDriveFolders.Count + "件追加";
			try {
				TreeNode parentNode = TreeNodeSelect(parentName);
				parentNode.Nodes.Clear();
				dbMsg += "," + parentNode.Text + " を選択";
				foreach (Google.Apis.Drive.v3.Data.File di in GDriveFolders) {
					string folderName = di.Name;
					dbMsg += "\r\n" + folderName;
					TreeNode child = new TreeNode(@folderName);
					child.Nodes.Add(new TreeNode());
					parentNode.Nodes.Add(child);
				}
				pass_tv.EndUpdate();
				//cureentPassName = SetPassLabel(@addFolder);
				//dbMsg += ">現在の選択>" + cureentPassName;
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
			string TAG = "pass_tv_AfterSelect";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				string folderName = e.Node.Text;
				dbMsg += folderName;
				MyLog(TAG, dbMsg);
				GoogleFileListUp(folderName);
				SetPassLabel(folderName);
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
					dbMsg += "フォルダに" + Constant.GDriveFolderMembers.Count + "件";
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
					//			file_list_Lv.Items.Clear();					// ListViewコントロールのデータをすべて消去
					IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>();
					foreach (Google.Apis.Drive.v3.Data.File fileItem in Constant.GDriveFolderMembers) {
						string fNmae = fileItem.Name.ToString();
						dbMsg += "\r\n" + fNmae;
						string fSize = fileItem.Size.ToString();
						dbMsg += "," + fSize;
						string fModifiedTime = fileItem.ModifiedTime.ToString();
						dbMsg += "," + fModifiedTime;
						// ListViewコントロールにデータを追加
						string[] item1 = { fNmae, fSize, fModifiedTime };
						file_list_Lv.Items.Add(new ListViewItem(item1));
						//フォルダが有れば記録
						if(fileItem.MimeType == GoogleDriveMime_Folder) {
							GDriveFolders.Add(fileItem);
						}
					}
					int GDriveFoldersCount = GDriveFolders.Count;
					dbMsg += "、フォルダ" + GDriveFoldersCount +"件";
					if(0< GDriveFoldersCount) {
						AddList2Node(pFolder, GDriveFolders);	//treeにサブフォルダー追記
					}

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
		private void file_list_Lv_DoubleClick(object sender, EventArgs e)
		{
			string TAG = "file_list_Lv_DoubleClick";
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
					dbMsg += ">>フォルダ" + focusedName + "を開く";

					//string fullpass = pass_name_lb.Text; が正常値になっているとは限らない
					TreeNode rNode = SrachNodeList(focusedName);
					string tFullPass = rNode.FullPath;
					string[] passse = tFullPass.Split('\\');
					string cPass = passse[passse.Length - 1];
					string pPass = passse[passse.Length - 2];
					dbMsg += ",pPass=" + pPass + ",pPass=" + pPass;

					pass_tv.Focus();				//フォーカスをtreeに移す

					TreeNode nowSelectedNode = pass_tv.SelectedNode;
					dbMsg += ":" + nowSelectedNode.Text + "を選択中";
					GoogleFileListUp(focusedName);
					SetPassLabel(focusedName);
					MyLog(TAG, dbMsg);
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
							string fId = Constant.GDriveSelectedFiles[Constant.GDriveSelectedFiles.Count - 1].Id;
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

		/// <summary>
		/// 標準ダイアログから送信ファイル選択
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void file_open_bt_Click(object sender, EventArgs e)
		{
			string TAG = "file_open_bt_Click";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				//複数のファイルを選択できるようにする
				openFDialog.Multiselect = true;
				DialogResult dr = openFDialog.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK) {
					string[] files = openFDialog.FileNames;
					dbMsg += "選択：" + files.Length + "件";

					//選択したファイルが有るフォルダ内のファイルのみ
			//		LFUtil.ListUpFolderFiles(openFDialog);
		//			string[] files = (string[])Constant.selectFiles;

					SendFileListUp(files);
				}
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
				SendFileListUp(files);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 送信元ファイルとフォルダのリストアップ
		/// </summary>
		/// <param name="files"></param>
		private void SendFileListUp(string[] files)
		{
			string TAG = "SendFileListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
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
					Constant.sendFiles = new List<Constant.LocalFile>();             //送信元PCのファイルリスト
					Constant.selectFiles = new List<string>();                 //送信元PCのファイルリスト
					////フォルダとファイルの格納
					List<string> orgNames = new List<string>(files);            //渡されたファイル名リストからサブフォルダ検索用配列作成
					fileCount = orgNames.Count();
					dbMsg += ",渡されたのは" + fileCount + "件";
					IList<string> fullNames = new List<string>();            //PC内作業用ファイルリスト
					foreach (string item in orgNames) {
						dbMsg += "\r\n" + fullNames.Count + ")" + item;
						bool isDirectory = System.IO.File.GetAttributes(@item).HasFlag(System.IO.FileAttributes.Directory);
						//フォルダが渡されたらその中
						if (isDirectory) {
						string[] flFilses = System.IO.Directory.GetFiles(@item, "*", System.IO.SearchOption.AllDirectories);
							foreach (string flFilse in flFilses) {
								dbMsg += "\r\n" + fullNames.Count + ")" + flFilse;
								fullNames.Add(flFilse);
							}
						}else{																																								//ファイルなら
							fullNames.Add(item);																																	//そのまま追加
						}
					}
					dbMsg += "\r\n正常終了";
					fileCount = fullNames.Count();
					dbMsg += ">ファイルだけで>" + fileCount + "件";

					////フォルダとファイルの格納
					Constant.sendFiles = new List<Constant.LocalFile>();             //送信元PCのファイルリスト
					string b_folderPass = "";
					foreach (string rStr in fullNames) {
						dbMsg += "\r\n" + Constant.sendFiles.Count + ")" + rStr;
						string fileName = System.IO.Path.GetFileName(@rStr);
						dbMsg += "::" + fileName;
						string parentPsss = System.IO.Path.GetDirectoryName(@rStr);      //一つ上までのフルパス
						dbMsg += ",一つ上のフォルダ名=" + parentPsss;
						bool isDirectory = System.IO.Directory.Exists(@rStr);
						string parentName = System.IO.Path.GetFileName(parentPsss);
						dbMsg += ",parentName=" + parentName;

						//直上のフォルダ名が変わったらフォルダ作成
						if (!@parentPsss.Equals(@b_folderPass)) {
							b_folderPass = parentPsss;
							Constant.LocalFile localFolder = new Constant.LocalFile();
							dbMsg += ":フォルダ:" + parentName;
							localFolder.name = parentName;
							string parentparentPsss = System.IO.Path.GetDirectoryName(@parentPsss);
							dbMsg += ">もう一つ上>" + parentparentPsss;
							localFolder.fullPass = parentparentPsss;
							string parentparentName = System.IO.Path.GetFileName(@parentparentPsss);
							dbMsg += ",parentName=" + parentparentName;
							localFolder.parent = parentparentName;
							localFolder.isFolder = true;
							Constant.sendFiles.Add(localFolder);
							dbMsg += "\r\n" + Constant.sendFiles.Count + ")" + rStr;
							msgStr += "\r\n" + parentName + "に";
						}
						dbMsg += ":ファイル;" + fileName;
						Constant.LocalFile localFile = new Constant.LocalFile();
						localFile.fullPass = rStr;
						localFile.name = fileName;
						localFile.parent = parentName;
						localFile.isFolder = false;
						Constant.sendFiles.Add(localFile);
						msgStr +=  fileName + ",";
					}
					buttns = MessageBoxButtons.OKCancel;
					icon = MessageBoxIcon.Information;
				}
				if (Constant.debugNow) {
					foreach (Constant.LocalFile sFile in Constant.sendFiles) {
						dbMsg += "\r\n" + sFile.parent + "に" + sFile.name + ":" + sFile.isFolder + ":" + sFile.fullPass;
					}
				}
				msgStr += "\r\nを登録します";
				DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
				dbMsg += ",result=" + result;
				if (result == DialogResult.OK) {        //「はい」が選択された時
					dbMsg += ">>" + Constant.selectFiles.Count + "件を送信";
					MyLog(TAG, dbMsg);
					GFilePut();                            //送信
				}else{
					MyLog(TAG, dbMsg);
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		public IList<string> GetAllISendtems(IList<string> orgNames)
		{
			string TAG = "GetAllISendtems";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				IList<string> fullNames = new List<string>();            //PC内ファイルリスト
				foreach (string item in orgNames) {
					dbMsg += "\r\n" + fullNames.Count + ")" + item;
					fullNames.Add(item);
					bool isDirectory = System.IO.File.GetAttributes(item).HasFlag(System.IO.FileAttributes.Directory);
					if (isDirectory) {
						string[] flFilses = System.IO.Directory.GetFiles(item, "*", System.IO.SearchOption.AllDirectories);
						foreach (string flFilse in flFilses) {
							dbMsg += "\r\n" + fullNames.Count + ")" + flFilse;
							fullNames.Add(item);
						}
					}
				}
				dbMsg += "\r\n正常終了" ;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
				throw new NotImplementedException();
			}
			return fullNames;
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
				string displayFolder = "";
				String titolStr = Constant.ApplicationName;
				String msgStr = "送信するファイルを選択して下さい";
				MessageBoxButtons buttns = MessageBoxButtons.OK;
				MessageBoxIcon icon = MessageBoxIcon.Warning;
				MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;

				if (Constant.sendFiles == null) {     //Constant.MakeFolderName == null || 
					DialogResult result1 = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result1;
					return;
				}

				int sendFilesCount = Constant.sendFiles.Count;
				dbMsg += "送信ファイル数＝" + sendFilesCount + "件";

				ProgressDialog pd = new ProgressDialog();
				//ダイアログのタイトルを設定
				pd.Title = "Googleドライブに登録";
				//プログレスバーの最小値を設定
				pd.Minimum = 0;
				//プログレスバーの最大値を設定
				pd.Maximum = sendFilesCount;
				//プログレスバーの初期値を設定
				pd.Value = 0;

				//進行状況ダイアログを表示する
				pd.Show(this);

				Constant.LocalFile topF = Constant.sendFiles.First();
				Constant.MakeFolderName = topF.name;
				dbMsg += "書込むフォルダ＝" + Constant.MakeFolderName;
				displayFolder = Constant.MakeFolderName;
				if (Constant.MakeFolderName.Equals(Constant.TopFolderName)) {
					topF = Constant.sendFiles[1];
					Constant.MakeFolderName = topF.name;
					dbMsg += ">>" + Constant.MakeFolderName;
				}
				Task<string> newFolder = Task.Run(() => {
					return  GDriveUtil.CreateFolder(Constant.MakeFolderName, Constant.TopFolderID, Constant.RootFolderID);
				});
				try {
					newFolder.Wait();
				} catch (AggregateException ae) {
					MyErrorLog(TAG, dbMsg + "でエラー発生;" + ae);
				}
				string parentId = newFolder.Result;
				dbMsg += ">parent>" ;
				if (parentId == null) {
					 msgStr = "フォルダを作成できませんでした。\r\nもう一度書込むファイルをドロップしてください";
					 icon = MessageBoxIcon.Exclamation;
					DialogResult result2 = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += msgStr + ",result=" + result2;
				} else {
					dbMsg += "[" + parentId + "]" + Constant.MakeFolderName + "に" + Constant.sendFiles.Count() + "件を登録";
					int pdValue = 0;
					pd.Message =  "";
					foreach (Constant.LocalFile sFile in Constant.sendFiles) {
						//プログレスバーの値を変更する
						pd.Value = pdValue;
						string pName = sFile.parent;
						//メッセージを変更する
						pd.Message += sFile.name + "を送信...";

						//キャンセルされた時はループを抜ける
						if (pd.Canceled){
							break;
						}

						bool isFolder = sFile.isFolder ;
						if (isFolder){
							dbMsg += "\r\nフォルダ作成";
						}else{
							dbMsg += "\r\nファイル書き込み";
						}
						Task<string> pFile= Task.Run(() => {
							return GDriveUtil.FindByName(pName);
						});
						try {
							pFile.Wait();
						} catch (AggregateException ae) {
							MyErrorLog(TAG, dbMsg + "でエラー発生;" + ae);
						}
						string pId = pFile.Result;
						if(pId == null) {
							pId = Constant.TopFolderID;
							dbMsg += "＞追加フォルダ";
							Task<string> pFolder = Task.Run(() => {
								return GDriveUtil.CreateFolder(pName, pId, Constant.RootFolderID);
							});
							try {
								pFolder.Wait();
							} catch (AggregateException ae) {
								MyErrorLog(TAG, dbMsg + "でエラー発生;" + ae);
								pd.Message +=  ":エラー発生:" + ae;
							}
							pId = pFolder.Result;

						} else {
							dbMsg += "＞既存フォルダ";
						}

						dbMsg += "["  + pId  + "]" + pName;
						displayFolder = pName;
						string sFileName = sFile.name;
						dbMsg += "に" + sFileName;
						string fullName = sFile.fullPass;
						dbMsg += ">>" + fullName;
						if(sFile.isFolder) {
							Task<string> pFolder = Task.Run(() => {
								return GDriveUtil.FindByName(sFile.parent);
							});
							pFolder.Wait();
							string parentFolderId = pFolder.Result;
							dbMsg += "[" + parentFolderId +"]" + sFile.parent + "の下に";
							Task<string> wrfolder = Task.Run(() => {
								return GDriveUtil.CreateFolder(sFileName, parentFolderId );
							});
							wrfolder.Wait();
							String wrfileId = wrfolder.Result;
							dbMsg += ">作成>[" + wrfileId + "]";
							pd.Message += sFile.parent + "の中に作成\r\n";
						} else {
							Task<string> wrfile = Task.Run(() => {
								return GDriveUtil.UploadFile(sFileName, fullName, pId);
							});
							wrfile.Wait();
							String wrfileId = wrfile.Result;
							dbMsg += ">作成>[" + wrfileId + "]";
							pd.Message += sFile.parent + "の中に登録\r\n";
						}
						pdValue++;
					}
				}
				dbMsg += "\r\n表示フォルダ＝" + displayFolder;
				ResetTree(displayFolder);
				GoogleFileListUp(displayFolder);
				//	SetPassLabel(displayFolder);	
				
				//ダイアログを閉じる
				pd.Close();
				msgStr = "終了しました";
				 icon = MessageBoxIcon.Information;
				DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
				dbMsg += ",result=" + result;
				if (result == DialogResult.OK) {        //「はい」が選択された時
					//cureentPassName = SetPassLabel(displayFolder);
					//dbMsg += ">現在の選択>" + cureentPassName;

				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 削除メニューを選択
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DelTSMenuItem_Click(object sender, EventArgs e)
		{
			string TAG = "DelTSMenuItem_Click";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				DeletItem();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void DeletItem()
		{
			string TAG = "DeletItem";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				String titolStr = Constant.ApplicationName;
				String msgStr =  "";
				MessageBoxButtons buttns = MessageBoxButtons.OKCancel;
				MessageBoxIcon icon = MessageBoxIcon.Warning;
				MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
				int focusedIndex = file_list_Lv.FocusedItem.Index;         //先頭0の選択位置：：Positionは座標
				dbMsg += ",focused[" + focusedIndex;
				Google.Apis.Drive.v3.Data.File focusedFiles = Constant.GDriveFolderMembers[focusedIndex];
				string focusedName = focusedFiles.Name;
				dbMsg += "]" + focusedName;
				bool isFolder = true;
				string focusedFilesMimeType = focusedFiles.MimeType;
				dbMsg += ",MimeType=" + focusedFilesMimeType;
				if (focusedFilesMimeType.Equals("application/vnd.google-apps.folder")) {
					dbMsg += ">>フォルダ" + focusedName + "を削除";
				} else {
					dbMsg += ">>ファイル" + focusedName + "を削除";
					isFolder = false;
				}
				msgStr = focusedName + "を削除しますか";
				DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
				dbMsg += ",result=" + result;
				if (result == DialogResult.OK) {        //「はい」が選択された時
					Task<string> delItem = Task.Run(() => {
						return GDriveUtil.DelteItem(focusedName);
					});
					try {
						// 例外をキャッチする場合には、Waitメソッドを実施している部分をtry...catchでくくります。
						// 例外が発生すると、AggregateExceptionにラップされてスローされます。
						delItem.Wait();
					} catch (AggregateException ae) {
						MyErrorLog(TAG, dbMsg + "でエラー発生;" + ae);
					}
					string deltId = delItem.Result;
					dbMsg += ">削除>" + deltId;
					if(deltId != null) {
						msgStr = focusedName + "を削除しました";
						icon = MessageBoxIcon.Information;
					}else{
						msgStr = focusedName + "を削除する事が出来ませんでした。";
						icon = MessageBoxIcon.Information;
					}
					buttns = MessageBoxButtons.OK;
					DialogResult result2 = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
				}
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

		//TreeView//////////////////////////////////////////////////
		public struct TreeNodeMember{
			public string text;
			public TreeNode node;

			public TreeNodeMember(string text, TreeNode node)
			{
				this.text = text;
				this.node = node;
			}
		}
		public  IList<TreeNodeMember> treeNodeList = new List<TreeNodeMember>() ;             //ツリービューの内容

		/// <summary>
		/// TreeViewに登録されているノードをリストアップする
		/// </summary>
		/// <param name="treeNode"></param>
		private void TreeViewNodeListUp(TreeNode treeNode)
		{
			string TAG = "TreeViewNodeListUp";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				dbMsg += "," + treeNode.Text;			// ":" + treeNode.FullPath.ToString();
				if(! treeNode.Text.Equals("")) {
					TreeNodeMember treeNodeMember = new TreeNodeMember();
					treeNodeMember.text = treeNode.Text;
					treeNodeMember.node = treeNode;
					treeNodeList.Add(treeNodeMember);
				}
				foreach (TreeNode tn in treeNode.Nodes) {
					TreeViewNodeListUp(tn);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// treeViewの元データを検索
		/// </summary>
		/// <param name="folderName"></param>
		/// <returns>該当するNodeを返す</returns>
		private TreeNode SrachNodeList(string folderName)
		{
			string TAG = "SrachNodeList";
			string dbMsg = "[GoogleDriveBrouser]";
			TreeNode retNode=null;
			try {
				dbMsg += "," + folderName;           // ":" + treeNode.FullPath.ToString();
				if(0<treeNodeList.Count) {
					foreach (TreeNodeMember treeNodeMember in treeNodeList) {
						string rText = treeNodeMember.text;
						if(rText.Equals(folderName)) {
							retNode = treeNodeMember.node;          //
							break;
						}
					}

				}
				dbMsg += ">>" + retNode;           // ":" + treeNode.FullPath.ToString();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return retNode;
		}

		/// <summary>
		/// 指定したノードを選択状態にする
		/// </summary>
		/// <param name="folderName"></param>
		public TreeNode TreeNodeSelect(string folderName)
		{
			string TAG = "TreeNodeSelect";
			string dbMsg = "[GoogleDriveBrouser]";
			TreeNode targetNode = new TreeNode();
			try {
				TreeNodeCollection nodes = pass_tv.Nodes;
				treeNodeList = new List<TreeNodeMember>();             //ツリービューの内容
				foreach (TreeNode rNode in nodes) {
					TreeViewNodeListUp(rNode);
				}
				dbMsg += "現在のTree" + treeNodeList.Count + "件から" + folderName + "を検索";
				foreach (TreeNodeMember member in treeNodeList) {
					dbMsg += "\r\n" + member.text;
					dbMsg += ":" + member.node.FullPath;
					if (folderName.Equals(member.text)) {
						targetNode = member.node;
						break;
					}
				}
				dbMsg += "\r\n>>最終選択=" + targetNode.Text;
				pass_tv.SelectedNode = targetNode;
				pass_tv.Focus();            //これがないと、クリックされた所にフォーカスが移ったままになってしまう
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
			return targetNode;
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

 パスからファイル名、拡張子、ディレクトリ名、ルートディレクトリ名等の情報を取得する
		https://dobon.net/vb/dotnet/file/pathclass.html
 */
