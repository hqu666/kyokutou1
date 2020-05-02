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
		GoogleUtil GUtil = new GoogleUtil();

		Edit editForm;
		private string receiveData = "";

		public Form1()
		{
			string TAG = "Form1";
			string dbMsg = "[Form1]";
			try {
				InitializeComponent();
				editForm = new Edit();
				editForm.mainForm = this;
				Conect2DriveAsync(true);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 接続
		/// </summary>
		/// <param name="isListUp"></param>
		private async void Conect2DriveAsync(Boolean isListUp)
		{
			string TAG = "Conect2Drive";
			string dbMsg = "[Form1]";
			try {
				String retStr = await GAuthUtil.Authentication("calender_oauth.json", "token.json");
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
					string UserId = Constant.MyCredential.UserId;
					dbMsg += ",UserId=" + UserId;
					Constant.MyTokenType = Constant.MyCredential.Token.TokenType;
					Constant.MyRefreshToken = Constant.MyCredential.Token.RefreshToken;
					Constant.MyAccessToken = Constant.MyCredential.Token.RefreshToken;

					dbMsg += "\r\nTokenType=" + Constant.MyTokenType;
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
				GCalendarUtil.GEventsListUp();
			/*
				Constant.GDriveFiles = GUtil.GDFileListUp();
				Constant.GDriveFolders = new Dictionary<string, Google.Apis.Drive.v3.Data.File>();

				if (Constant.GDriveFiles != null && Constant.GDriveFiles.Count > 0) {
					// フォルダIDの取得	;一行目にはフォルダ名/二行目以降はファイル情報
					Constant.parentFolderId = Constant.GDriveFiles.First().Id;
					String folderName = Constant.GDriveFiles.First().Name;
					//フォルダ階層の取得
					foreach (var file in Constant.GDriveFiles) {
						String fName = file.Name;
						String fId = file.Id;
						if (file.Parents != null) {
							String PId = file.Parents[0];
							String fMimeType = file.MimeType;
							DateTime fModifiedTime = (DateTime)file.ModifiedTime;
							if (fName.Equals(Constant.TopFolderName)) {
								//最上位にするフォルダと
								Constant.TopFolderID = fId;
								Constant.RootFolderID = PId;
								info_lb.Text = fName;                                           //照合が合っているか確認の為
							} else if (fMimeType.Equals("application/vnd.google-apps.folder")) {
								Constant.GDriveFolders.Add(fId, file);                                           //最上位以外のフォルダを格納
							}
						}
					}
					dbMsg += "[top=" + Constant.TopFolderID + "]";
					dbMsg += "[root=" + Constant.RootFolderID + "]";
					dbMsg += ",folders" + Constant.GDriveFolders.Count() + "件";
					int nodeCount = 0;
					google_drive_tree.Nodes.Clear();                    //viewを初期化して
					google_drive_tree.BeginUpdate();                    //	更新開始
					foreach (var folder in Constant.GDriveFolders) {
						dbMsg += "\r\nfolder=" + folder.Key;
						dbMsg += ":" + folder.Value.Name;
						dbMsg += ":" + folder.Value.Parents[0];
						if (folder.Value.Parents[0].Equals(Constant.TopFolderID)) {
							google_drive_tree.Nodes.Add(folder.Value.Name);
							foreach (var file in Constant.GDriveFiles) {
								String PId = file.Parents[0];
								if (folder.Key.Equals(PId)) {
									String fName = file.Name;
									String fId = file.Id;
									String fMimeType = file.MimeType;

									if (fMimeType.Equals("application/vnd.google-apps.folder")) {
									} else if (fMimeType.Equals("application/vnd.android.package-archive")) {
									} else if (file.Trashed == true) {
									} else if (file.Size == null) {
									} else {
										DateTime fModifiedTime = (DateTime)file.ModifiedTime;
										long fSize = (long)file.Size;
										google_drive_tree.Nodes[nodeCount].Nodes.Add(fName + ItemsSeparator + fModifiedTime + "       \t\t\t: " + file.Size);
									}
								}
							}
							nodeCount++;
						} else {
							dbMsg += ">>除外";
						}
					}
					google_drive_tree.EndUpdate();
					google_drive_tree.ExpandAll();                  // すべてのノードを展開する
				} else {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					String msgStr = "送信先ドライブには未だファイルが登録されていません";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				}]
				*/
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
		public string ReceiveData {
			set {
				receiveData = value;
				receiveData_lv.Text = receiveData;
			}
			get {
				return receiveData;
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

		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}

	}
}
/*
 .NET Quickstart		https://developers.google.com/calendar/quickstart/dotnet
 
 
 */
