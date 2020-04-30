using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyokuto1sample {
	public partial class Form1 : Form {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleUtil GUtil = new GoogleUtil();

		public  string selectedItemText = "";
		public string selectedItemId= "";
		public static string ItemsSeparator = "                          \t\t\t\t: ";

		public Form1()
		{
			string TAG = "Form1";
			string dbMsg = "[Form1]";
			try {
				InitializeComponent();
		//		MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string TAG = "Form1_Load";
			string dbMsg = "[Form1]";
			try {
				Conect2DriveAsync(true);
	//			MyLog(TAG, dbMsg);
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
			//	String retStr = await GAuthUtil.Authentication("credentials0429.json", "token.json");   //.NET Quickstart>>認証されない
				String retStr = await GAuthUtil.Authentication("client1sampl.json", "token.json");
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
					if(isListUp) {
						GoogleFileListUp();
					}
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// treeViewへGoogleDriveの登録状態表示
		/// </summary>
		public void GoogleFileListUp()
		{
			string TAG = "GoogleFileSarch";
			string dbMsg = "[Form1]";
			try {
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
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 選択された時点でアイテムを保持
		/// nameとid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Tree_AfterSelect(object sender,System.Windows.Forms.TreeViewEventArgs e)
		{
			string TAG = "Tree_AfterSelect";
			string dbMsg = "[Form1]";
			try {
				selectedItemText = e.Node.Text;
				dbMsg += ",selectedItemText=" + selectedItemText;
				string[] del = { ItemsSeparator };
				string[] arr = selectedItemText.Split(del, StringSplitOptions.None);
				selectedItemText = arr[0];
				dbMsg += ">>" + selectedItemText;
				//idの取得は/////
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// コンテキストメニューで削除を選んだ場合
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void FileContexit_Click(object sender, EventArgs e)
		{
			string TAG = "FileContexit_Click";
			string dbMsg = "[Form1]";
			try {
				System.Windows.Forms.ToolStripMenuItem item = (System.Windows.Forms.ToolStripMenuItem)sender;
				String titolStr = Constant.ApplicationName;
				String msgStr = selectedItemText + " を削除しますか";
				MessageBoxButtons buttns = MessageBoxButtons.YesNo;
				MessageBoxIcon icon = MessageBoxIcon.Question;
				MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
				DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
				dbMsg += ",result=" + result;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		/// <summary>
		/// 更新ボタンのクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Update_bt_Click(object sender, EventArgs e)
		{
			string TAG = "Update_bt_Click";
			string dbMsg = "[Form1]";
			try {
				if(Constant.MyCredential == null || Constant.MyDriveService == null) {
					String titolStr = Constant.ApplicationName;
					String msgStr = "まだ接続されていません";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
				Conect2DriveAsync(true);
				//		GoogleFileListUp();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}
		//https://stackoverrun.com/ja/q/10041674	//////////////////////////////////////////

		//////////////////////////////////////////   https://stackoverrun.com/ja/q/10041674	   //
		/// <summary>
		/// ファイル選択ダイアログをボタンで表示させる場合
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Serect_bt_Click(object sender, EventArgs e)
		{
			string TAG = "Serect_bt_Click";
			string dbMsg = "[Form1]";
			try {
				DialogResult dr = openFileDialog1.ShowDialog();
				if (dr == System.Windows.Forms.DialogResult.OK) {
					LFUtil.ListUpFolderFiles(openFileDialog1);
					int fCount = 0;
					foreach (string str in Constant.selectFiles) {
						string fileName = Path.GetFileName(@str);
						Constant.selectFiles[fCount] = fileName;
						fCount++;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}
		
		/// <summary>
		/// ドロップされたファイルの処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormMain_DragDrop(object sender, DragEventArgs e)
		{
			string TAG = "FormMain_DragDrop";
			string dbMsg = "[Form1]";
			try {
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
				int fileCount = files.Length;
				dbMsg += fileCount + "件" ;
				String titolStr = Constant.ApplicationName;
				String msgStr = "ファイルを取得できませんでした。\r\n" +
											"もう一度、送信したいファイルをドロップしてください";
				MessageBoxButtons buttns = MessageBoxButtons.OK;
				MessageBoxIcon icon = MessageBoxIcon.Warning;
				MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
				if (0< fileCount) {
					msgStr = "";
					Constant.MakeFolderName = "";
					Constant.selectFiles = new string[fileCount];
					for (int i = 0; i < files.Length; i++) {
						string rStr = files[i];
						if(Constant.MakeFolderName.Equals("")) {
							Constant.MakeFolderName = LFUtil.GetPearentPass(rStr, Constant.TopFolderName);
							msgStr += Constant.TopFolderName + "の" + Constant.MakeFolderName + "に\r\n";
						}
						string fileName = LFUtil.GetFileNameExt(rStr);
						dbMsg += "\r\n" + i+ ")" + fileName ;
						Constant.selectFiles[i] = fileName;
						msgStr += fileName + "\r\n";
					}
					buttns = MessageBoxButtons.OKCancel;
					icon = MessageBoxIcon.Information;
				}
				if(1 == Constant.selectFiles.Count()) {
					Constant.MakeFolderName = Constant.selectFiles[0];
						msgStr = Constant.TopFolderName + "に\r\n" + Constant.MakeFolderName + " を作成します";
				}else{
					msgStr += "\r\nを登録します";
				}
				DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
				dbMsg += ",result=" + result;
				if (result == DialogResult.OK) {        //「はい」が選択された時
					dbMsg += ">>送信";
					GFilePutAsync();							//送信
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		private void FormMain_DragEnter(object sender, DragEventArgs e)
		{
			string TAG = "FormMain_DragEnter";
			string dbMsg = "[Form1]";
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

		////送信ボタン;保留
		//private void Send_bt_Click(object sender, EventArgs e)
		//{
		//	string TAG = "Send_bt_Click";
		//	string dbMsg = "[Form1]";
		//	try {
		//		GFilePutAsync();
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
		//	}
		//}

		/// <summary>
		/// GoogleDriveへ書き込み
		/// System.io.FileでPCのローカルファイルを読み出すのでGoogleDriveクラスと分離
		/// </summary>
		//　
		public async void GFilePutAsync()
		{
			string TAG = "GFilePutAsync";
			string dbMsg = "[Form1]";
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
				Conect2DriveAsync(false);
				Task<string> newFolder = Task<string>.Run(() => GUtil.CreateFolder(Constant.MakeFolderName, Constant.TopFolderID, Constant.RootFolderID));
			//	var newFolder = GUtil.CreateFolder(Constant.MakeFolderName, Constant.TopFolderID, Constant.RootFolderID);  //フォルダを作る
				string parentId = newFolder.Result;    //Constant.WriteFolderID;
				dbMsg += ">>[" +  parentId + "]";           // newFolder.Result + "；" ++ newFolder.Name;
				if (parentId == null) {
					String titolStr = Constant.ApplicationName;
					String msgStr = "フォルダを作成できませんでした。\r\nもう一度書込むファイルをドロップしてください";
					MessageBoxButtons buttns = MessageBoxButtons.OK;
					MessageBoxIcon icon = MessageBoxIcon.Exclamation;
					MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button1;
					DialogResult result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
					dbMsg += ",result=" + result;
				} else {
					dbMsg += "、" + Constant.selectFiles.Count() + "件";
					foreach (string str in Constant.selectFiles) {
						dbMsg += "\r\n" + str;
						string fullName = System.IO.Path.Combine(Constant.LocalPass, str);
						dbMsg += ">>" + fullName;
						Task<string> wrfile = Task.Run(() =>  GUtil.UploadFile(fullName, parentId));
				//		var wrfile = await GUtil.UploadFile(fullName, parentId);
						String wrfileId = wrfile.Result;
						dbMsg += ">>[" + wrfileId + "]" ;
					}
				}
				MyLog(TAG, dbMsg);
				GoogleFileListUp();						//更新状態を再描画
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

		private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{

		}
	}


	/*
	 画面に表示されているデータに対して、自分のPCにあるファイルを添付するのですが、
	 それがサーバ上ではなく、Googleドライブのフォルダと関連付けて、そこにアップをするというイメージです。
例えば、画面に表示されている案件情報（管理番号：PR0001）にファイルを添付したい場合は、
Googleドライブ上に「KSクラウド/案件/PR0001」と言うフォルダを作って、クライアントの画面上にそのフォルダの中身を表示します。
そこに添付したいファイルをドラッグ＆ドロップしたら、Googleドライブ上にも同期をされてアップされると言った感じです。
Windows用のGoogleドライブアプリをインストールしたら、エクスプローラーに追加されるので、そのイメージが近いです。
	 


	 */

}
