using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KGSample
{
    /// <summary>
    /// GoogleDriveBrouser.xaml の相互作用ロジック
    /// </summary>
    public partial class GoogleDriveBrouser : MetroWindow {
		public GEventEdit editView;
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public IList<string> passList = new List<string>();
		public string cureentPassName = "";                                  //現在のパス名
		public IList<string> fullNames = new List<string>();            //PC内ファイルリスト
		public string GoogleDriveMime_Folder = Constant.GoogleDriveMime_Folder;

		//ColumnHeader columnName = new ColumnHeader();
		//ColumnHeader columnType = new ColumnHeader();
		//ColumnHeader columnData = new ColumnHeader();
		public GoogleDriveBrouser()
        {
			string TAG = "GoogleDriveBrouser";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
        }

		/// <summary>
		/// 指定されたフォルダの内容情報を取得
		/// </summary>
		internal void ResetTree(string parentFolderName = null)
		{
			string TAG = "ResetTree";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				////		pass_tv.Nodes.Clear();
				// GoogleFolderListUp(Constant.RootFolderName);
				//if (GDriveFolders != null) {          // && 0< GDriveFolders.Count  だと件数が取れてない
				//	dbMsg += ",サブフォルダ" + GDriveFolders.Count + "件";
				//	Google.Apis.Drive.v3.Data.File pFolder = GDriveFolders.First();
				//	dbMsg += "," + pFolder.Name ;
				//	cureentPassName = SetPassLabel(pFolder);

				//	//parentFolder = Constant.TopFolderName;
				//	//dbMsg = ">>" + parentFolder;
				//}

				dbMsg += ">現在の選択>" + cureentPassName;
				//	pass_tv.ExpandAll();	これが有るとループして全ノード書き出さないと終わらない
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// パスラベルの書き換え
		/// nullを与えればリストから削除
		/// </summary>
		/// <param name="passName"></param>
		public string SetPassLabel(Google.Apis.Drive.v3.Data.File parentFolder)
		{
			string TAG = "SetPassLabel";
			string dbMsg = "[GoogleDriveBrouser]";
			string rStr = "";
			try {
				dbMsg += "," + parentFolder.Name;
				//親になるパネルを作る
				StackPanel psp = new StackPanel();
				psp.Orientation = Orientation.Horizontal;
				psp.Margin = new Thickness(-5);

				//ボタンに見える部分
				Button bt = new Button();
				//ファイルの表示名
				bt.Content = parentFolder.Name;
				bt.Click += pass_name_bt_Click;
				bt.DataContext = parentFolder;
				//		bt.Style = FindResource("bt-attachment") as System.Windows.Style;
				//横並べ
				//StackPanel sp = new StackPanel();
				//sp.Orientation = Orientation.Horizontal;
				//sp.Margin = new Thickness(-5);
				////アイコン
				//string iconLink = attachment.IconLink;
				//dbMsg += "  ,iconLink= " + iconLink;
				//Image img = new Image();
				//img.Source = new BitmapImage(new Uri(iconLink));
				//img.Height = 10;
				//img.Width = 10;
				//sp.Children.Add(img);
				////ファイルの表示名
				//Label lb = new Label();
				//lb.Content = title;
				////格納
				//sp.Children.Add(lb);
				//bt.Content = sp;
				psp.Children.Add(bt);
				////削除ボタン
				//Button dbt = new Button();
				//dbt.Click += Del_Attachment_bt_Click;
				//dbt.DataContext = attachment;
				//dbt.Style = FindResource("bt-dell") as System.Windows.Style;
				//psp.Children.Add(dbt);

				//ファイルの表示名
				Label lb = new Label();
				lb.Content = "▲";
				lb.Style = FindResource("lb-r-try") as System.Windows.Style;
				psp.Children.Add(lb);
				//XAMLへ格納;
				pass_sp.Children.Add(psp);

				//TreeNodeSelect(passName);                                                           //指定したノードを選択して
				//string fullPath = pass_tv.SelectedNode.FullPath;                  // 選択されたノードを取得
				//dbMsg += ">>" + fullPath;
				//pass_name_lb.Text = Constant.RootFolderName + "\\" + fullPath;
				//rStr = pass_name_lb.Text;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return rStr;
		}

		private void pass_name_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "pass_name_bt_Click";
			string dbMsg = "[GoogleDriveBrouser]";
			IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>();
			try {
				Button bt = sender as Button;
				Google.Apis.Drive.v3.Data.File taregetFolder = bt.DataContext as Google.Apis.Drive.v3.Data.File;
				dbMsg += "選択されたフォルダ=" + taregetFolder.Name;
				GoogleFileListUp(taregetFolder.Name);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
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
			IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>();
			try {

				dbMsg += folderName + "を開き";
				//if (0 < pass_tv.Nodes.Count) {
				//	TreeNodeSelect(folderName);                                                           //親ノードを選択して
				//	string parentNode = pass_tv.SelectedNode.FullPath;                  // 選択されたノードを取得
				//	dbMsg += parentNode + "に配置したい";
				//} else {
				//	dbMsg += "最上位に配意したい";
				//}
				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => {
					return GDriveUtil.GDFileListUp(folderName, true);
				});
				rFolders.Wait();
				GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(rFolders.Result);
				//TreeNode targetNode = new TreeNode();
				//TreeNode node = new TreeNode();
				if (GDriveFolders != null) {          // && 0< GDriveFolders.Count  だと件数が取れてない
					dbMsg += ",サブフォルダ" + GDriveFolders.Count + "件";
					// ドライブ一覧を走査してツリーに追加
					foreach (Google.Apis.Drive.v3.Data.File folder in GDriveFolders) {
						string mFolderName = folder.Name;
						dbMsg += ",\r\n" + mFolderName;
						// 新規ノード作成
						// プラスボタンを表示するため空のノードを追加しておく
						//node = new TreeNode(mFolderName);
						//node.Nodes.Add(new TreeNode());
						//pass_tv.Nodes.Add(node);
						//if (@folderName.Equals(@mFolderName)) {
						//	targetNode = node;
						//	dbMsg += ",\r\n最終選択=" + targetNode.Text;
						//}
					}
					//dbMsg += ",\r\n" + pass_tv.Nodes.Count + "件";
					////	pass_tv.Sort();		//渡された配列がソートされていなければ使用；List()メソッドでlistRequest.OrderBy = "name";を指定済みなので不要化
					//pass_tv.EndUpdate();
					cureentPassName = SetPassLabel(GDriveFolders.First());
				} else {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					String msgStr = "送信先ドライブには未だファイルが登録されていません";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
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
				//file_list_lv.Clear();                                                           //listViewの書込み初期化
				Constant.GDriveFolderMembers = null;
				Constant.GDriveFolderMembers = GDriveUtil.GDFileListUp(pFolder, false);
				if (Constant.GDriveFolderMembers != null) {
					dbMsg += "フォルダに" + Constant.GDriveFolderMembers.Count + "件";
					// ListViewコントロールのプロパティを設定
					//file_list_lv.FullRowSelect = true;
					//file_list_lv.GridLines = true;
					//file_list_lv.Sorting = SortOrder.Ascending;
					//file_list_lv.View = View.Details;

					// 列（コラム）ヘッダの作成
					//columnName = new ColumnHeader();
					//columnType = new ColumnHeader();
					//columnData = new ColumnHeader();
					//columnName.Text = "名前";
					//columnName.Width = 245;
					//columnType.Text = "サイズ";
					//columnType.Width = 70;
					//columnData.Text = "更新日";
					//columnData.Width = 120;
					//ColumnHeader[] colHeaderRegValue = { this.columnName, this.columnType, this.columnData };
					//file_list_lv.Columns.AddRange(colHeaderRegValue);
					//			file_list_lv.Items.Clear();					// ListViewコントロールのデータをすべて消去
					IList<Google.Apis.Drive.v3.Data.File> GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>();
					ObservableCollection<GFile> GDriveFiles = new ObservableCollection<GFile>();
					foreach (Google.Apis.Drive.v3.Data.File fileItem in Constant.GDriveFolderMembers) {
						string fNmae = fileItem.Name.ToString();
						dbMsg += "\r\n" + fNmae;
						string fSize = fileItem.Size.ToString();
						dbMsg += "," + fSize;
						string fModifiedTime = fileItem.ModifiedTime.ToString();
						dbMsg += "," + fModifiedTime;
						string fMimeType = fileItem.MimeType;
						dbMsg += "," + fMimeType;
						// ListViewコントロールにデータを追加
						GDriveFiles.Add(new GFile { Name = fNmae, Size = fSize, ModifiedTime = fModifiedTime, MimeType = fMimeType });
						////フォルダが有れば記録
						if (fMimeType == GoogleDriveMime_Folder) {
							GDriveFolders.Add(fileItem);
						}
					}
					dbMsg += "、合計" + GDriveFiles + "件";
					//XAMLへ
					file_list_lv.DataContext = GDriveFiles;
					int GDriveFoldersCount = GDriveFolders.Count;
					dbMsg += "中フォルダ" + GDriveFoldersCount + "件";
					//if (0 < GDriveFoldersCount) {
					//	AddList2Node(pFolder, GDriveFolders);   //treeにサブフォルダー追記
					//}
					//TreeNode rNode = SrachNodeList(pFolder);
					//dbMsg += "、最終" + rNode.Text + "を選択";
				} else {
					dbMsg += "このフォルダはファイルなどが登録されていません";
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ファイルリスト選択後
		/// フォルダならその階層に降りて内容表示
		/// ファイルなら選択リストを作成して呼出し元に戻る
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void file_list_lv_DoubleClick(object sender, EventArgs e)
		{
			string TAG = "file_list_lv_DoubleClick";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				//int focusedIndex = file_list_lv.FocusedItem.Index;         //先頭0の選択位置：：Positionは座標
				//dbMsg += ",focused[" + focusedIndex;
				//Google.Apis.Drive.v3.Data.File focusedFiles = Constant.GDriveFolderMembers[focusedIndex];
				//string focusedName = focusedFiles.Name;
				//dbMsg += "]" + focusedName;
				//string focusedFilesMimeType = focusedFiles.MimeType;
				//dbMsg += ",MimeType=" + focusedFilesMimeType;
				//if (focusedFilesMimeType.Equals(GoogleDriveMime_Folder)) {
				//	dbMsg += ">>フォルダ" + focusedName + "を開く";

				//	//string fullpass = pass_name_lb.Text; が正常値になっているとは限らない
				//	TreeNode rNode = SrachNodeList(focusedName);
				//	string tFullPass = rNode.FullPath;
				//	string[] passse = tFullPass.Split('\\');
				//	string cPass = passse[passse.Length - 1];
				//	string pPass = passse[passse.Length - 2];
				//	dbMsg += ",pPass=" + pPass + ",pPass=" + pPass;

				//	pass_tv.Focus();                //フォーカスをtreeに移す

				//	TreeNode nowSelectedNode = pass_tv.SelectedNode;
				//	dbMsg += ":" + nowSelectedNode.Text + "を選択中";
				//	GoogleFileListUp(focusedName);
				//	SetPassLabel(focusedName);
				//	MyLog(TAG, dbMsg);
				//} else {
				//	dbMsg += ">>ファイル" + focusedName + "を送る";
				//	if (Constant.GDriveSelectedFiles == null) {
				//		Constant.GDriveSelectedFiles = new List<Google.Apis.Drive.v3.Data.File>();
				//	}
				//	if (file_list_lv.SelectedItems.Count >= 1) {
				//		//選択されているリストの情報を出力する
				//		foreach (ListViewItem item in file_list_lv.SelectedItems) {
				//			int selectedIndex = item.Index;
				//			dbMsg += "\r\nselected=" + selectedIndex;
				//			Constant.GDriveSelectedFiles.Add(Constant.GDriveFolderMembers[selectedIndex]);
				//			string fId = Constant.GDriveSelectedFiles[Constant.GDriveSelectedFiles.Count - 1].Id;
				//			dbMsg += "[" + fId;
				//			string fName = Constant.GDriveSelectedFiles[Constant.GDriveSelectedFiles.Count - 1].Name;
				//			dbMsg += "]" + fName;
				//		}
				//	} else {
				//		dbMsg += "選択されていません";
				//	}
				//	dbMsg += "\r\n選択結果=" + Constant.GDriveSelectedFiles.Count + "件";
				//	MyLog(TAG, dbMsg);
				//	mainForm.FileListUp();
				//	QuitMe();
				//}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
	
		private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string TAG = "Window_Closing";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// このフォームを閉じる
		/// ※this.Close();だと再表示でクラッシュするのでthis.Visible = false;でこのオブジェクトを破棄させない
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				if (editView != null) {
					editView.driveView = null;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			this.Close();
		}

		public class GFile {
			public string Name { get; set; }
			public string Size { get; set; }
			public string ModifiedTime { get; set; }
			public string MimeType { get; set; }
		}
		//public class GDFtList {
		//	// バインディングの指定先プロパティ
		//	public ObservableCollection<GFile> Data { get; }

		//	// コンストラクタ(データ入力)
		//	public GDFtList()
		//	{
		//		Data = new ObservableCollection<GFile> {

		//			};
		//	}
		//}
		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		)
		{
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}

	}
}
