using System;
using System.Collections.Generic;
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
using mshtml;
using Microsoft.Win32;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices;

namespace KGSample {
	/// <summary>
	/// WebWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class WebWindow :Window {
	
		public GCalender mainView;

		/// <summary>
		/// このページで表示するwebページのURL
		/// </summary>
		public Uri taregetURL { set; get; }

		public WebWindow(Uri taregetURL)
		{
			string TAG = "WebWindow";
			string dbMsg = "[WebWindow]";
			try {
				InitializeComponent();

				// WebbrowserのIEバージョンを指定		http://kitunechan.hatenablog.jp/entry/2018/03/29/165019
		//		using (var key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION")) {
		//			key.SetValue(filename, 11001, RegistryValueKind.DWord);
		////org			key.SetValue(filename, 11001, RegistryValueKind.DWord);
		//		}

				//// ローカルのファイル読み込みを有効にする
				//using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BLOCK_LMZ_SCRIPT")) {
				//	key.SetValue(filename, 0, RegistryValueKind.DWord);
				//}

				//// タッチ機能を有効にする
				//using (var key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_NINPUT_LEGACYMODE")) {
				//	key.SetValue(filename, 0, RegistryValueKind.DWord);
				//}


				dbMsg += "taregetURL=" + taregetURL;
				url_tb.Text= taregetURL.ToString();
	//			web_wb.IsScriptEnabled = true;
				web_wb.Navigate(taregetURL);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// URL書き換え
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Url_tb_TextChanged(object sender, TextChangedEventArgs e)
		{
			string TAG = "Url_tb_TextChanged";
			string dbMsg = "[GEventEdit]";
			try {
				string urlTbText = url_tb.Text;
				dbMsg += "urlTbText=" + urlTbText;
				taregetURL = new Uri(urlTbText, UriKind.Absolute);
				web_wb.Navigate(taregetURL);

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// WPFでクローズボックスなど、ウインドウを閉じる時に発生するイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string TAG = "Window_Closing";
			string dbMsg = "[GEventEdit]";
			try {
				//				e.Cancel = true;                //このオブジェクトを破棄させない(1)
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// このフォームを閉じる
		/// ※this.Close();だと再表示でクラッシュするのでthis.Visible = false;でこのオブジェクトを破棄させない
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[GEventEdit]";
			try {
				if (mainView != null) {
					mainView.webWindow = null;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			this.Close();
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

		public static implicit operator WebWindow(GEventEdit v)
		{
			throw new NotImplementedException();
		}
	}

	/*
	 WebbrowserクラスはIE7相当で動作します
	 WebBrowser コントロールで使われている Internet Explorerを最新のバージョンに変更する方法
	 https://www.ipentec.com/document/csharp-change-webbrower-control-internet-explorer-version

	①Win+Rを押してregeditと入力、確定します。
	②HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl にアクセスします。
		FeatureControl キーが存在しない場合は新規に作ってください。 
	③FeatureControl 以下に FEATURE_BROWSER_EMULATION キーを作成します。
		1)FEATURE_BROWSER_EMULATION に
		2)名前: [目的のブラウザの実行ファイル名] , データ: 0x2328(10進数で11001) としてDword値を作成します。
				(例: 名前: donut.exe , データ: 0x00002328)
	④FeatureControl 以下に FEATURE_USE_LEGACY_JSCRIPT キーを作成します。
		1)FEATURE_USE_LEGACY_JSCRIPT に
		2)名前: [目的のブラウザの実行ファイル名] , データ: 0x0 としてDword値を作成します。
			(例: 名前: donut.exe , データ: 0x00000000)

where is IHTMLScriptElement?
	https://stackoverflow.com/questions/5216194/where-is-ihtmlscriptelement/5216255#5216255

	 */

}
