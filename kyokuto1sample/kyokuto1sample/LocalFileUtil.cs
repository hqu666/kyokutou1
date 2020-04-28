using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kyokuto1sample {
	class LocalFileUtil {
		public String MakeFolderName = null;

		// OpenFileDialogで選択されたファイルのある全ファイル名を返す
		public void ListUpFolderFiles(System.Windows.Forms.OpenFileDialog ofDialog)
		{
			string TAG = "Serect_bt_Click";
			string dbMsg = "[LocalFileUtil]";
//			String[] selectFiles = null;
			try {
				String FolderPath = System.IO.Path.GetDirectoryName(ofDialog.FileName);
				System.IO.DirectoryInfo dirInfo = System.IO.Directory.GetParent(ofDialog.FileName);
				Constant.MakeFolderName = dirInfo.Name;
				Constant.selectFiles = Directory.GetFiles(@FolderPath, "*");
				dbMsg += Constant.selectFiles.Count() + "件";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg + "でエラー発生;" + er);
			}
		}

		public string GetMimeType(string fileName)
		{
			string mimeType = "application/unknown";
			string ext = System.IO.Path.GetExtension(fileName).ToLower();
			Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
			if (regKey != null && regKey.GetValue("Content Type") != null)
				mimeType = regKey.GetValue("Content Type").ToString();
			return mimeType;
		}

		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg);
		}

	}
}
