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
    public partial class GoogleDriveBrouser : Window {
		public GEventEdit editView;
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public IList<Google.Apis.Drive.v3.Data.File> passList = new List<Google.Apis.Drive.v3.Data.File>();
		public string cureentPassName = "";                                  //現在のパス名
		public IList<string> fullNames = new List<string>();            //PC内ファイルリスト
		public string GoogleDriveMime_Folder = Constant.GoogleDriveMime_Folder;
		public GoogleDriveBrouser()
        {
			string TAG = "GoogleDriveBrouser";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				InitializeComponent();
				this.FontSize = Constant.MyFontSize;
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
				//セパレータ代わりの▲
				Label lb = new Label();
				lb.Style = FindResource("lb-l-try") as System.Windows.Style;
				psp.Children.Add(lb);
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

				//XAMLへ格納;
				pass_sp.Children.Add(psp);

				//TreeNodeSelect(passName);                                                           //指定したノードを選択して
				//string fullPath = pass_tv.SelectedNode.FullPath;                  // 選択されたノードを取得
				//dbMsg += ">>" + fullPath;
				//pass_name_lb.Text = Constant.RootFolderName + "\\" + fullPath;
				//rStr = pass_name_lb.Text;
				GoogleFileListUp(parentFolder.Name);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return rStr;
		}

		/// <summary>
		/// 上の階層に戻す処理
		/// </summary>
		/// <param name="targetID"></param>
		private void DelPassLabel(string targetID)
		{
			string TAG = "DelPassLabel";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				int delIndex = pass_sp.Children.Count;
				dbMsg += "pass_spへの登録" + delIndex + "件";
				int passListCount = passList.Count;
				dbMsg += "passList" + passListCount + "件";
				if (0 < passListCount) {
					for (int i = passListCount; 0< i ; i--) {
						dbMsg += "\r\n" + i + ")" ;
						Google.Apis.Drive.v3.Data.File pass = passList[i-1];
						string passId = pass.Id;
						dbMsg += "[" + passId ;
						string passName = pass.Name;
						dbMsg += "]" + passName;
						if(passId.Equals(targetID)) {
							delIndex = i;
							break;
						}
					}
					dbMsg += ",delIndex=" + delIndex;
					for (int i = passListCount; delIndex< i ; i--) {
						dbMsg += ">削除：添付>" + i + ")";
						pass_sp.Children.RemoveAt(i);
						passList.RemoveAt(i-1);
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
		}

		private void pass_name_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "pass_name_bt_Click";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				Button bt = sender as Button;
				Google.Apis.Drive.v3.Data.File taregetFolder = bt.DataContext as Google.Apis.Drive.v3.Data.File;
				dbMsg += "選択されたフォルダ=" + taregetFolder.Name;
				DelPassLabel(taregetFolder.Id);
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
				Task<IList<Google.Apis.Drive.v3.Data.File>> rFolders = Task.Run(() => {
					return GDriveUtil.GDFileListUp(folderName, false);
				});
				rFolders.Wait();
				GDriveFolders = new List<Google.Apis.Drive.v3.Data.File>(rFolders.Result);
				if (GDriveFolders != null) {          // && 0< GDriveFolders.Count  だと件数が取れてない
					dbMsg += ",サブフォルダ" + GDriveFolders.Count + "件";
					IList<string> parents = GDriveFolders.First().Parents;
					string parentsId = parents.First();
					dbMsg += ",parents[" + parentsId + "件";
					Google.Apis.Drive.v3.Data.File parentIdFolder = GDriveUtil.FindById(parentsId);
					passList.Add(parentIdFolder);
					cureentPassName = SetPassLabel(parentIdFolder);
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
				Constant.GDriveFolderMembers = null;
				Constant.GDriveFolderMembers = GDriveUtil.GDFileListUp(pFolder, false);
				if (Constant.GDriveFolderMembers != null) {
					dbMsg += "フォルダに" + Constant.GDriveFolderMembers.Count + "件";
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
						GDriveFiles.Add(new GFile { Name = fNmae, Size = fSize, ModifiedTime = fModifiedTime, MimeType = fMimeType ,File= fileItem });
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
		private void File_list_lv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string TAG = "File_list_lv_MouseDoubleClick";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				ListView lv = sender as ListView;
				int focusedIndex = lv.SelectedIndex;	
				dbMsg += ",focused[" + focusedIndex;
				GFile selectedItem = lv.SelectedItem as GFile;
				Google.Apis.Drive.v3.Data.File focusedFiles = selectedItem.File;
				string focusedName = focusedFiles.Name;
				dbMsg += "]" + focusedName;
				string focusedFilesMimeType = focusedFiles.MimeType;
				dbMsg += ",MimeType=" + focusedFilesMimeType;
				if (focusedFilesMimeType.Equals(GoogleDriveMime_Folder)) {
					dbMsg += ">>フォルダ" + focusedName + "を開く";
					GoogleFolderListUp(focusedFiles.Name);
					MyLog(TAG, dbMsg);
				} else {
					dbMsg += ">>ファイル" + focusedName + "を送る";
					if (Constant.GDriveSelectedFiles == null) {
						Constant.GDriveSelectedFiles = new List<Google.Apis.Drive.v3.Data.File>();
					}
					if (0< file_list_lv.SelectedItems.Count ) {
						dbMsg += "\r\n選択結果=" + focusedFiles.Name;
						MyLog(TAG, dbMsg);
						editView.AttachmentsFromDrive(focusedFiles);
						QuitMe();
					} else {
						dbMsg += "選択されていません";
						MyLog(TAG, dbMsg);
					}
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
	
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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

		/// <summary>
		/// ListViewに格納するための置き換えクラス
		/// </summary>
		public class GFile {
			public string Name { get; set; }
			public string Size { get; set; }
			public string ModifiedTime { get; set; }
			public string MimeType { get; set; }
			public Google.Apis.Drive.v3.Data.File File { get; set; }
		}
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
