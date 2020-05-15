using System;

namespace KGSample {
	class CS_Util {
		/// <summary>
		/// デバッグログ
		/// 出荷時は　debugNow　をfalseに
		/// </summary>
		/// <param name="TAG"></param>
		/// <param name="dbMsg"></param>
		public void MyLog(String TAG, String dbMsg)
		{
			if (Constant.debugNow) {
				Console.WriteLine(TAG + " : " + dbMsg);
				//System.Diagnostics.Trace.WriteLine(TAG + " : " + dbMsg);
				//System.Diagnostics.Debug.WriteLine(TAG + " : " + dbMsg);
			}
		}

		public void MyErrorLog(String TAG, String dbMsg, Exception err)
		{
			if (Constant.errorCheckNow) {
				//					Xamarin.Forms.Internals.Log.Warning(TAG, dbMsg);
				Console.WriteLine(TAG + " : " + dbMsg + "でエラー発生;" + err);
			}
		}

		///// <summary>
		///// ダイアログ表示
		///// </summary>
		///// <param name="titolStr">タイトル</param>
		///// <param name="msgStr">メッセージ</param>
		///// 		/// http://furuya02.hatenablog.com/entry/20140426/1398477869

		/// <summary>
		/// 
		/// </summary>
		/// <param name="titolStr"></param>
		/// <param name="msgStr"></param>
		/// <param name="buttns">MessageBoxButtons.OKCancel</param>
		/// <param name="icon">MessageBoxIcon.Exclamation</param>
		/// <param name="defaultButton">MessageBoxDefaultButton.Button2</param>
		/// <returns></returns>
		//public DialogResult MessageShow(String titolStr, String msgStr, MessageBoxButtons buttns, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
		//{
		//	String TAG = "MessageShow";
		//	String dbMsg = "開始";
		//	DialogResult result = 0;
		//	try {
		//		dbMsg = "titolStr=" + titolStr;
		//		dbMsg += "mggStr=" + msgStr;

		//		//メッセージボックスを表示する
		//		result = MessageBox.Show(msgStr, titolStr, buttns, icon, defaultButton);
		//		dbMsg += ",result=" + result;
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyLog(TAG, dbMsg + "で" + er.ToString());
		//	}
		//	return result;
		//}
	}
}
