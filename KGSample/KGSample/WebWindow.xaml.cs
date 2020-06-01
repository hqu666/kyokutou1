using System;
using System.Windows;
using System.Windows.Controls;

namespace KGSample {
	/// <summary>
	/// WebWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class WebWindow :Window {
	
		public GCalender mainView;

		/// <summary>
		/// このページで表示するwebページのURL
		/// </summary>
		public Uri TaregetURL { set; get; }

		public WebWindow(Uri taregetURL)
		{
			string TAG = "WebWindow";
			string dbMsg = "[WebWindow]";
			try {
				InitializeComponent();

				dbMsg += "taregetURL=" + taregetURL;
				TaregetURL = taregetURL;
				url_tb.Text= taregetURL.ToString();
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
				TaregetURL = new Uri(urlTbText, UriKind.Absolute);
				web_wb.Navigate(TaregetURL);

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
