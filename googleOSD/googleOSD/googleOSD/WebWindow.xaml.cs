using System;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace GoogleOSD {
	/// <summary>
	/// WebWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class WebWindow : Window {
		public GoogleAuth authWindow;
		public GCalender mainView;
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();
		public string b_UrlStr;
		public DateTime timeCurrent = DateTime.Now;

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
		//		this.WindowState = WindowState.Maximized;
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
		/// カレンダー（予定リスト）まで戻ったら
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Go_back_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Go_back_bt_Click";
			string dbMsg = "[WebWindow]";
			try {
				dbMsg += ",CanGoBack" + this.web_wb.CanGoBack;
				if (this.web_wb.CanGoBack){
					dbMsg += ",戻る";
					this.web_wb.GoBack();
				}else if(GCalendarUtil.IsGoogleCalender(this.web_wb.Source.ToString()) ||
							Constant.DriveStratUrl.Equals(this.web_wb.Source.ToString())) {
					dbMsg += ">>終わる";
					QuitMe();
				}
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
				if (this.web_wb.CanGoForward) {
					this.web_wb.GoForward();
				}
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
				if (urlTbText.Equals(TaregetURL)) {            //手入力された場合だけ			の条件設定ができるまで封鎖
//					web_wb.Navigate(TaregetURL);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 新しいコンテンツに移動する前
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void Web_wb_NavigationStarting(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlNavigationStartingEventArgs args)
		{
			string TAG = "NavigationStarting";
			string dbMsg = "[WebWindow]";//WebWindow
			try {
				WebView wv = sender as WebView;
				if(wv != null) {
					dbMsg += ",sender.Source=　" + wv.Source;
				}
				dbMsg += ",args.Uri=　" + args.Uri;
				string documentTitle = web_wb.DocumentTitle.ToString();
				dbMsg += ",documentTitle=" + documentTitle;
				if (web_wb.DocumentTitle != null) {
					this.Title = web_wb.DocumentTitle;
				}
				string source = @web_wb.Source.ToString();
				dbMsg += ",Source=　" + source;
				//if (source.Contains("eventedit")) {
				//	dbMsg += "　　>>編集へ";
				//	MakeEvent(source, @b_UrlStr);
				//} else if (status_sp.IsVisible) {				this.web_wb.GoForward();

				//	dbMsg += "　　>>削除ボタンを隠す";
				//	status_sp.Visibility = Visibility.Hidden;
				//}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		/// <summary>
		/// 新しいコンテンツの読み込みを開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Web_wb_ContentLoading(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlContentLoadingEventArgs args)
		{
			string TAG = "ContentLoading";
			string dbMsg = "[WebWindow]";//WebWindow
			try {
				WebView wv = sender as WebView;
				if (wv != null) {
					string wvSource = @wv.Source.ToString();
					dbMsg += ",sender.Source=　" + wvSource;
				}
				string source = args.Uri.ToString();
				dbMsg += " ,args.Uri=　" + source;
				url_tb.Text = source;
				if (source.Contains("eventedit")) {
					dbMsg += "　　>>編集へ";
					MakeEvent(source, @b_UrlStr);
				} else if (status_sp.IsVisible) {
					dbMsg += "　　>>削除ボタンを隠す";
					status_sp.Visibility = Visibility.Hidden;
				}
				string source2 = @web_wb.Source.ToString();
				dbMsg += "	,Source=　" + source2;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 現在の HTML のコンテンツの解析を完了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Web_wb_DOMContentLoaded(object sender, Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT.WebViewControlDOMContentLoadedEventArgs args)
		{
			string TAG = "DOMContentLoaded";
			string dbMsg = "[WebWindow]";//WebWindow
			try {
				WebView wv = sender as WebView;
				if (wv != null) {
					dbMsg += ",sender.Source=　" + wv.Source;
				}
				dbMsg += " ,args.Uri=　" + args.Uri;
				string source = @web_wb.Source.ToString();
				dbMsg += ",Source=　" + source;
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
			string TAG = "NavigationCompleted";
			string dbMsg = "[WebWindow]";
			try {
				WebView wv = sender as WebView;
				if (wv != null) {
					dbMsg += ",sender.Source=　" + wv.Source;
				}
				dbMsg += " ,args.Uri=　" + args.Uri;
				if (!args.IsSuccess) {
					// エラー発生
					string errMsg = args.WebErrorStatus.ToString();
					int errCode = (int)args.WebErrorStatus;
					string msg = string.Format("サーバ側エラー：{0}（{1}）", errMsg, errCode);
					dbMsg += msg;
					//	await new Windows.UI.Popups.MessageDialog(msg).ShowAsync();
				}
				b_UrlStr = @web_wb.Source.ToString();
				dbMsg += ",b_UrlStr=   " + b_UrlStr;
				timeCurrent = GCalendarUtil.GoogleWebCurentDate(b_UrlStr);
				dbMsg += "     ,timeCurrent=" + timeCurrent;
				if (web_wb.DocumentTitle != null) {
					this.Title = web_wb.DocumentTitle;
				}
				dbMsg += "　 ,CanGoBack=" + web_wb.CanGoBack;
		//		go_back_bt.IsEnabled = web_wb.CanGoBack;
				dbMsg += ",CanGoForward=" + web_wb.CanGoForward;
	//			fowerd_bt.IsEnabled = web_wb.CanGoForward;
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

		/// <summary>
		/// 選択された予定へ
		/// </summary>
		/// <param name="HtmlLink"></param>
		/// <param name="CurrentUrl"></param>
		private void MakeEvent(string HtmlLink, string CurrentUrl)
		{
			string TAG = "MakeEvent";
			string dbMsg = "[WebWindow]";
			try {
				dbMsg += ",timeCurrent= 　" + timeCurrent;
				DateTime timeMin = timeCurrent.AddMonths(-1);
				DateTime timeMax = timeCurrent.AddMonths(1);
				if (GCalendarUtil.IsGoogleCalender(CurrentUrl)) {
					if (CurrentUrl.Contains("r/year")) {
						timeMin = new DateTime(timeCurrent.Year, 1, 1);
						timeMax = timeMin.AddYears(1);
					} else if (CurrentUrl.Contains("r/month")) {
						timeMin = new DateTime(timeCurrent.Year, timeCurrent.Month, 1);
						timeMax = timeMin.AddMonths(1);
					} else if (CurrentUrl.Contains("r/week")) {
						timeMin = new DateTime(timeCurrent.Year, timeCurrent.Month, 1);
						timeMax = timeMin.AddDays(7);
					} else if (CurrentUrl.Contains("r/day")) {
						timeMin = timeCurrent.AddDays(-1);
						timeMax = timeMin.AddDays(1);
					} else if (CurrentUrl.Contains("r/agenda")) {
						timeMin = timeCurrent.AddDays(-1);
						timeMax = timeMin.AddMonths(1);
					}
					dbMsg += " ,対象期間=" + timeMin + "～" + timeMax;
					dbMsg += ",Source= 　" + HtmlLink;
					Google.Apis.Calendar.v3.Data.Event rEvent = GCalendarUtil.Pram2GEvents("HtmlLink", HtmlLink, timeMin, timeMax);
					dbMsg += "  ,rEvent=" + rEvent.Id;


					status_sp.Visibility = Visibility.Visible;
					dbMsg += "　削除ボタンを表示";
				}
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

Web ビュー	https://docs.microsoft.com/ja-jp/windows/uwp/design/controls-and-patterns/web-view
	 */

}
