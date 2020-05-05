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
	public partial class GoogleDriveBrouser : Form {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public Form1 mainForm;

		public GoogleDriveBrouser()
		{
			string TAG = "GoogleDriveBrouser";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
				InitializeComponent();
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
			string TAG = "Conect2DriveAsync";
			string dbMsg = "[GoogleDriveBrouser]";
			try {
		//		String retStr = await GAuthUtil.DriveAuthentication("drive_service_acount.json", "token.json");
				String retStr = await GAuthUtil.DriveAuthentication("oauth_drive.json", "token.json");
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
					string UserId = Constant.MyDriveCredential.UserId;
					dbMsg += ",UserId=" + UserId;
					Constant.MyTokenType = Constant.MyDriveCredential.Token.TokenType;
					Constant.MyRefreshToken = Constant.MyDriveCredential.Token.RefreshToken;
					Constant.MyAccessToken = Constant.MyDriveCredential.Token.RefreshToken;

					dbMsg += "\r\nTokenType=" + Constant.MyTokenType;
					dbMsg += "\r\nRefreshToken=" + Constant.MyRefreshToken;
					dbMsg += "\r\nAccessToken=" + Constant.MyAccessToken;
					MyLog(TAG, dbMsg);
					if (isListUp) {
						GoogleFolderListUp();
					}
				}
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
				Constant.GDriveFiles = GDriveUtil.GDFileListUp();
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
						if (file.Parents != null) {
							String PId = file.Parents[0];
							String fMimeType = file.MimeType;
							DateTime fModifiedTime = (DateTime)file.ModifiedTime;
							if (fName.Equals(Constant.TopFolderName)) {
								//最上位にするフォルダと
								Constant.TopFolderID = fId;
								Constant.RootFolderID = PId;
					//			info_lb.Text = fName;                                           //照合が合っているか確認の為
							} else if (fMimeType.Equals("application/vnd.google-apps.folder")) {
								Constant.GDriveFolders.Add(fId, file);                                           //最上位以外のフォルダを格納
							}
						}
					}
					dbMsg += "[top=" + Constant.TopFolderID + "]";
					dbMsg += "[root=" + Constant.RootFolderID + "]";
					dbMsg += ",folders" + Constant.GDriveFolders.Count() + "件";
					int nodeCount = 0;
					pass_tv.Nodes.Clear();                    //viewを初期化して
					pass_tv.BeginUpdate();                    //	更新開始
/*
					foreach (var folder in Constant.GDriveFolders) {
						dbMsg += "\r\nfolder=" + folder.Key;
						dbMsg += ":" + folder.Value.Name;
						dbMsg += ":" + folder.Value.Parents[0];
						if (folder.Value.Parents[0].Equals(Constant.TopFolderID)) {
							pass_tv.Nodes.Add(folder.Value.Name);
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
										pass_tv.Nodes[nodeCount].Nodes.Add(fName + pass_tv + fModifiedTime + "       \t\t\t: " + file.Size);
									}
								}
							}
							nodeCount++;
						} else {
							dbMsg += ">>除外";
						}
					}
					*/
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
