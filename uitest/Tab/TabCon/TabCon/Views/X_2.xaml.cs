using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Controls.Button;
using DataFormats = System.Windows.DataFormats;
using DragDropEffects = System.Windows.DragDropEffects;
using DragEventArgs = System.Windows.DragEventArgs;
using DragEventHandler = System.Windows.DragEventHandler;

namespace TabCon.Views {
	/// <summary>
	/// X_2.xaml の相互作用ロジック
	/// </summary>
	public partial class X_2 : Window {
		public ViewModels.X_2ViewModel VM;
		public string NowSelectedPath = "C:";
		public X_2()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.X_2ViewModel();
			this.DataContext = VM;
			this.AllowDrop = true;
			//Attachments_wp.AllowDrop = true;
			//Attachments_wp.AddHandler(WrapPanel.DragOverEvent, new DragEventHandler(WPDragOver), true);
			//Attachments_wp.AddHandler(WrapPanel.DropEvent, new DragEventHandler(WPDrop), true);

			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			//	VM.MyView = this;
			//	VM.Control = ControlPanel;
			//		MyCalendar.Height = this.Height- ControlPanel.Height-10;
		}

		///// <summary>
		///// ここからVMを呼ぶとAttachmentsListが0件になっている
		///// </summary>
		///// <param name="sender"></param>
		///// <param name="e"></param>
		//private void CloseBT_Click(object sender, RoutedEventArgs e)
		//{
		//	string TAG = "CloseBT_Click";
		//	string dbMsg = "";
		//	try {
		//		Button BT = sender as Button;
		//		int index = int.Parse( BT.CommandParameter.ToString());
		//		dbMsg += "index=" + index;
		//		VM.DelFileIndex = index;
		//		//		VM.DellAttachFile(index);
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}

		private void WPDragOver(object sender, DragEventArgs e)
		{
			string TAG = "WPDragOver";
			string dbMsg = "";
			try {
				DropActivat(e);
				// マウスポインタを変更する。
				dbMsg += ",FileDrop=" + (e.Data.GetDataPresent(DataFormats.FileDrop));
				if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
					e.Effects = DragDropEffects.All;
				} else {
					e.Effects = DragDropEffects.None;
				}
				e.Handled = false;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}

		private void WPDrop(object sender, DragEventArgs e)
		{
			string TAG = "WPDragOver";
			string dbMsg = "";
			try {
				DropActivat(e);
				dbMsg += ",FileDrop=" + (e.Data.GetDataPresent(DataFormats.FileDrop));
				if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
					// TextBoxの中身をクリアする。
					//		tb.Text = string.Empty;
					// ドロップしたファイル名を全部取得する。
					string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
					//		tb.Text = filenames[0];
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ファイルのドロップ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Attachments_sp_Drop(object sender, DragEventArgs e)
		{
			string TAG = "Attachments_sp_Drop";
			string dbMsg = "";
			try {
				if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
					Controls.WaitingDLog progressWindow = new Controls.WaitingDLog();
					progressWindow.Show();

					//Constant.GDriveFiles = new List<Google.Apis.Drive.v3.Data.File>();
					//Constant.GDriveFiles = GDriveUtil.GDAllFolderListUp();
					//int fCount = Constant.GDriveFiles.Count;
					//dbMsg += " , " + fCount + " フォルダ登録";
					//if (0 < fCount) {
					//	dbMsg += "[" + Constant.GDriveFiles.First().Id + " ]" + Constant.GDriveFiles.First().Name + " ;Parents;" + Constant.GDriveFiles.First().Parents[0] + " ;DriveId;" + Constant.GDriveFiles.First().DriveId;
					//	dbMsg += "～[" + Constant.GDriveFiles.Last().Id + " ]" + Constant.GDriveFiles.Last().Name + " ;Parents;" + Constant.GDriveFiles.First().Parents[0] + " ;DriveId;" + Constant.GDriveFiles.First().DriveId;
					//}
					////仮処理；最初に拾えたファイルのParentsをdriveIdとする
					//Constant.DriveId = Constant.GDriveFiles.First().Parents[0];
					//Task<File> rootRes = Task<File>.Run(() => {
					//	dbMsg += "  ,ルート= " + Constant.RootFolderName;
					//	return GDriveUtil.CreateFolder(Constant.RootFolderName, Constant.DriveId);
					//});
					//rootRes.Wait();
					//string rootFolderId = rootRes.Result.Id;
					//dbMsg += "[" + rootFolderId + "] ";
					//Task<File> topRes = Task<File>.Run(() => {
					//	dbMsg += ",top=" + Constant.AriadneEventAnken;
					//	return GDriveUtil.CreateFolder(Constant.AriadneEventAnken, rootFolderId);
					//});
					//topRes.Wait();
					//string topFolderId = topRes.Result.Id;
					//dbMsg += "[" + topFolderId + "] ";

					////			dbMsg += "  、イベント：案件[" + Constant.AriadneAnkenFolderId + "] に ";
					//Task<File> rr = Task<File>.Run(() => {
					//	t_project_base tProject = new t_project_base();

					//	dbMsg += "  ,案件= " + tProject.project_manage_code;
					//	return GDriveUtil.CreateFolder(tProject.project_manage_code, topFolderId);
					//});
					//rr.Wait();
					////Task.WaitAll(rootRes,topRes, rr);
					//string itemFolderId = rr.Result.Id;
					//dbMsg += "[ " + itemFolderId + "]を作成";              //出来ていない
					//													// Note that you can have more than one file.
					//string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
					//var file = files[0];
					//string rFile = file.ToString();
					//dbMsg += "  ,rFile= " + rFile;
					//dbMsg += "  ,file= " + file.ToString();
					//string[] strs = rFile.Split('\\');
					//string name = strs[strs.Length - 1];
					//dbMsg += ",name=" + name;
					//string parent = strs[strs.Length - 2];
					//dbMsg += ",parent=" + parent;
					////直上のフォルダ
					//rr = Task<string>.Run(() => {
					//	return GDriveUtil.CreateFolder(parent, itemFolderId);
					//});
					//rr.Wait();
					//string parentFolderId = rr.Result.Id;
					//dbMsg += "[ " + parentFolderId + "]";
					//string fileId = PutInFoldrFile(rFile, itemFolderId, taregetEvent);

					//dbMsg += ">>作成= " + fileId;
					//Google.Apis.Drive.v3.Data.File fileItem = GDriveUtil.FindByNameParent(name, parent);
					//if (fileItem == null) {
					//	dbMsg += "登録なし";
					//} else {
					//	string gFileId = fileItem.Id;
					//	dbMsg += "[" + gFileId + "]";
					//}
					//AttachmentsFromDrive(fileItem);
					//progressWindow.Close();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void DropActivat(DragEventArgs e)
		{
			string TAG = "DropActivat";
			string dbMsg = "";
			try {
				dbMsg += "DataPresent:" + e.Data.GetDataPresent(DataFormats.FileDrop); ;
				e.Effects = DragDropEffects.All;
				e.Handled = true;       //
				dbMsg += ">>" + e.Data.GetDataPresent(DataFormats.FileDrop); ;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		//参照　https://www.peliphilo.net/archives/2306

		/// <summary>
		/// ウインドウ内にドラッグの発生を感知した時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			string TAG = "Window_PreviewDragOver";
			string dbMsg = "";
			try {
				DropActivat(e);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		private void Window_PreviewDragEnter(object sender, DragEventArgs e)
		{
			string TAG = "Window_PreviewDragEnter";
			string dbMsg = "";
			try {
				DropActivat(e);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void WPMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			string TAG = "WPMouseLeftButtonUp";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		private void Attachments_wp_DragEnter(object sender, System.Windows.DragEventArgs e)
		{
			string TAG = "Attachments_wp_DragEnter";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		private void Attachments_wp_DragLeave(object sender, DragEventArgs e)
		{
			string TAG = "Attachments_wp_DragLeave";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Attachments_wp_DragOver(object sender, DragEventArgs e)
		{
			string TAG = "Attachments_wp_DragOver";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Del_bt_Click(object sender, RoutedEventArgs e)
		{

		}


		/// ///////////////////////////////////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
			dbMsg = "[" + MethodBase.GetCurrentMethod().Module.Name + "]" + dbMsg;
			//dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
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
