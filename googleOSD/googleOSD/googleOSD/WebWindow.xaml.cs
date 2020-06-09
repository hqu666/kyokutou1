using System;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace GoogleOSD {
	/// <summary>
	/// WebWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class WebWindow :Window {
		public GoogleAuth authWindow;
		public GCalender mainView;

		/// <summary>
		/// このページで表示するwebページのURL
		/// </summary>
		public Uri TaregetURL { set; get; }

		public WebWindow()
		{
			string TAG = "WebWindow";
			string dbMsg = "[WebWindow]";
			try {
				InitializeComponent();
				this.FontSize = Constant.MyFontSize;
				// タイトルバーと境界線を表示しない場合は
		//		this.WindowStyle = WindowStyle.None;
				// 最大化表示
				this.WindowState = WindowState.Maximized;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// この画面が表示された後で、他クラスからURLを与える
		/// </summary>
		/// <param name="taregetURL"></param>
		public void SetMyURL(Uri taregetURL)
		{
			string TAG = "SetMyURL";
			string dbMsg = "[WebWindow]";
			try {
				dbMsg += "taregetURL=" + taregetURL;
				TaregetURL = taregetURL;
				web_wb.Navigate(TaregetURL);

			//	url_tb.Text = taregetURL.ToString();    //TextChangedが発生する
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 戻るボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Go_back_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Go_back_bt_Click";
			string dbMsg = "[WebWindow]";
			try {
				dbMsg += ",CanGoBack" + this.web_wb.CanGoBack;
				this.web_wb.GoBack();
				dbMsg += ",戻る";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 進むボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Fowerd_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Fowerd_bt_Click";
			string dbMsg = "[WebWindow]";
			try {
				dbMsg += ",CanGoForward" + this.web_wb.CanGoForward;
				this.web_wb.GoForward();
				dbMsg += ",進む";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 更新ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Refresh_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Refresh_bt_Click";
			string dbMsg = "[WebWindow]";
			try {
				this.web_wb.Refresh();
				dbMsg += ",更新";
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
		private void Url_tb_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{
			string TAG = "Url_tb_TextChanged";
			string dbMsg = "[WebWindow]";
			try {
				string urlTbText = url_tb.Text;
				dbMsg += ",urlTbText=" + urlTbText;
				dbMsg += ",TaregetURL=" + TaregetURL;
				if ( urlTbText.Equals(TaregetURL)) {            //! urlTbText.Equals("")||
																//	TaregetURL = new Uri(urlTbText, UriKind.Absolute);
					web_wb.Navigate(TaregetURL);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Web_wb_NavigationStarting(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationStartingEventArgs args)
		{
			string TAG = "Web_wb_NavigationStarting";
			string dbMsg = "[WebWindow]";
			try {
				WebView wv = sender as WebView;
				string documentTitle = web_wb.DocumentTitle.ToString();
				dbMsg += ",documentTitle=" + documentTitle;
				if (web_wb.DocumentTitle != null) {
					this.Title = web_wb.DocumentTitle;
				}
				dbMsg += ",CanGoBack=" + web_wb.CanGoBack;
				go_back_bt.IsEnabled = web_wb.CanGoBack;
				dbMsg += ",CanGoForward=" + web_wb.CanGoForward;
				fowerd_bt.IsEnabled = web_wb.CanGoForward;
				string source = @web_wb.Source.ToString();
				dbMsg += ",Source=　" + source;
				if (source.Contains("eventedit")) {
					dbMsg += "　　>>編集へ" ;
					MakeEvent(source);
				}else if(status_sp.IsVisible) {
					dbMsg += "　　>>削除ボタンを隠す";
					status_sp.Visibility = Visibility.Hidden;
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// 読込み後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void Web_wb_NavigationCompleted(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationCompletedEventArgs args)
		{
			string TAG = "Web_wb_NavigationCompleted";
			string dbMsg = "[WebWindow]";
			try {
				WebView wv = sender as WebView;
				if (!args.IsSuccess) {
					// エラー発生
					string errMsg = args.WebErrorStatus.ToString();
					int errCode = (int)args.WebErrorStatus;
					string msg = string.Format("サーバ側エラー：{0}（{1}）", errMsg, errCode);
					dbMsg += msg;
					//	await new Windows.UI.Popups.MessageDialog(msg).ShowAsync();
				}
		//		//	if(wv != null) {
		//		//		string documentTitle = wv.DocumentTitle;
		//		dbMsg += ",documentTitle=" + web_wb.DocumentTitle;
		//			if (web_wb.DocumentTitle != null) {
		//				this.Title = web_wb.DocumentTitle;
		//			}
		//			dbMsg += ",Source= " + web_wb.Source;
		////			url_tb.Text = @web_wb.Source;
		//			dbMsg += "　 ,CanGoBack=" + web_wb.CanGoBack;
		//			dbMsg += ",CanGoForward=" + web_wb.CanGoForward;
		////		}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		private void Web_wb_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			string TAG = "Web_wb_MouseUp";
			string dbMsg = "[WebWindow]";
			try {
				Button bt = sender as Button;

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
			string dbMsg = "[WebWindow]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// このフォームを閉じる
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[WebWindow]";
			try {
				if (mainView != null) {
					mainView.webWindow = null;
				}
				if (authWindow != null) {
					authWindow.webWindow = null;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			this.Close();
		}

		////////////////////////////////////////////////////
		private void MakeEvent(string source)
		{
			string TAG = "MakeEvent";
			string dbMsg = "[WebWindow]";
			try {
				dbMsg += ",Source= 　" + source;
				status_sp.Visibility=Visibility.Visible;
				dbMsg += "　削除ボタンを表示" ;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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
	WebbrowserクラスはIE7相当で動作する
	WPFの場合
	https://docs.microsoft.com/en-us/windows/communitytoolkit/controls/wpf-winforms/webview
	①パッケージマネージャで　
	Install-Package Microsoft.Toolkit.Wpf.UI.Controls.WebView -Version 6.0.1　でEdge相当のWebViewに変更する
	②Visualstudio再起動
	③using Microsoft.Toolkit.Wpf.UI.Controls;
		C:\Users\hkuwayama\.nuget\packages\microsoft.toolkit.wpf.ui.controls.webview\6.0.1\lib\netcoreapp3.0に
		Microsoft.Toolkit.Wpf.UI.Controls.WebView.dll　がインストールされる
	④Nugetの設定を変更してPackageReferenceを使う
			Must use PackageReference対策	

	 */

}
