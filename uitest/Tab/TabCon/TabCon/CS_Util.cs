using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TabCon {
	class CS_Util {

		/// <summary>
		/// カラーコードの文字列をSystem.Windows.MediaのColorに変換する
		/// </summary>
		/// 
		public Color ColorStr2Color(string colorcode)
		{
			string TAG = "IsForegroundWhite";
			string dbMsg = "[CS_Util]";
			Color col= Color.FromArgb(255, (byte)0, (byte)0, (byte)0);
			try {
				int redInt = int.Parse(colorcode.Substring(1, 2), NumberStyles.HexNumber);
				int greenInt = int.Parse(colorcode.Substring(3, 2), NumberStyles.HexNumber);
				int blueInt = int.Parse(colorcode.Substring(5, 2), NumberStyles.HexNumber);
				col = Color.FromArgb(255, (byte)redInt, (byte)greenInt, (byte)blueInt);
				if (colorcode.Length == 6) {
					dbMsg += ",r=" + redInt + ",g=" + greenInt + ",b=" + blueInt;
				} else {
					dbMsg += ">ARGB>";
					int alphaInt = int.Parse(colorcode.Substring(1, 2), NumberStyles.HexNumber);
					dbMsg += ",alpha=" + alphaInt;
					redInt = int.Parse(colorcode.Substring(3, 2), NumberStyles.HexNumber);
					greenInt = int.Parse(colorcode.Substring(5, 2), NumberStyles.HexNumber);
					blueInt = int.Parse(colorcode.Substring(7, 2), NumberStyles.HexNumber);
					dbMsg += ",r=" + redInt + ",g=" + greenInt + ",b=" + blueInt;
					col = Color.FromArgb((byte)alphaInt,(byte)redInt, (byte)greenInt, (byte)blueInt);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return col;
		}

		/// <summary>
		/// 背景色に応じて文字色が白で良ければTrueを返す
		/// </summary>
		/// <param name="colorcode"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		public bool IsForegroundWhite(string colorcode, int limit = 128)
		{
			string TAG = "IsForegroundWhite";
			string dbMsg = "[CS_Util]";
			bool retBool = false;
			try {
				int redInt = int.Parse(colorcode.Substring(1, 2), NumberStyles.HexNumber);
				int greenInt = int.Parse(colorcode.Substring(3, 2), NumberStyles.HexNumber);
				int blueInt = int.Parse(colorcode.Substring(5, 2), NumberStyles.HexNumber);
		//		Color col = Color.FromArgb(255, (byte)redInt, (byte)greenInt, (byte)blueInt);
				if (colorcode.Length == 6) {
					dbMsg += ",r=" + redInt + ",g=" + greenInt + ",b=" + blueInt;
				} else {
					dbMsg += ">ARGB>" ;
					int alphaInt = int.Parse(colorcode.Substring(1, 2), NumberStyles.HexNumber);
					dbMsg += ",alpha=" + alphaInt;
					redInt = int.Parse(colorcode.Substring(3, 2), NumberStyles.HexNumber);
					greenInt = int.Parse(colorcode.Substring(5, 2), NumberStyles.HexNumber);
					blueInt = int.Parse(colorcode.Substring(7, 2), NumberStyles.HexNumber);
					dbMsg += ",r=" + redInt + ",g=" + greenInt + ",b=" + blueInt;
		//			col = Color.FromArgb((byte)redInt, (byte)greenInt, (byte)blueInt, (byte)alphaInt);
				}

				int Judgment = ((redInt * 299) + (greenInt * 587) + (blueInt * 114)) / 1000;
				dbMsg += ",Judg=" + Judgment;
				dbMsg += " : " + limit;
				if (Judgment < limit) {
					retBool = true;
				}
				dbMsg += ">>" + retBool;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retBool;
		}
		//反映例
		//ColorSampleLavel.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
		//ColorSampleLavel.Foreground = Brushes.White;
		//			ColorSampleLavel.Content = "白文字";
		//ColorSampleTB.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
		//ColorSampleTB.Foreground = Brushes.White;
		//ColorSampleTB.Text = "白文字";

		/// <summary>
		/// デバッグログ
		/// 出荷時は　debugNow　をfalseに
		/// </summary>
		/// <param name="TAG"></param>
		/// <param name="dbMsg"></param>
		public void MyLog(String TAG, String dbMsg)
		{
#if DEBUG
				Constant.debugNow = false;
#endif

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

		public MessageBoxResult MessageShowWPF(String msgStr,
																				String titolStr = null,
																				MessageBoxButton buttns = MessageBoxButton.OK,
																				MessageBoxImage icon = MessageBoxImage.None
																				)
		{
			String TAG = "MessageShowWPF";
			String dbMsg = "開始";
			MessageBoxResult result = 0;
			try {
				dbMsg = "titolStr=" + titolStr;
				dbMsg += "mggStr=" + msgStr;
				//メッセージボックスを表示する		https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.messagebox?view=netcore-3.1
				if (titolStr == null) {
					result = MessageBox.Show(msgStr);
				} else if (icon == MessageBoxImage.None) {
					result = MessageBox.Show(msgStr, titolStr, buttns);
				} else {
					result = MessageBox.Show(msgStr, titolStr, buttns, icon);
				}
				dbMsg += ",result=" + result;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyLog(TAG, dbMsg + "で" + er.ToString());
			}
			return result;
		}

		/// <summary>
		/// ダイアログ表示
		/// </summary>
		/// <param name="titolStr">タイトル</param>
		/// <param name="msgStr">メッセージ</param>
		/// 		/// http://furuya02.hatenablog.com/entry/20140426/1398477869
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
