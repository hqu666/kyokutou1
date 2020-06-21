using System;
using System.Threading.Tasks;
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
		public bool IsEventEdit = false;								//編集中

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
							Constant.WebStratUrl.Equals(this.web_wb.Source.ToString())) {
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
				if(GCalendarUtil.IsGoogleCalender(source) && IsEventEdit) {
					//	if (GCalendarUtil.IsGoogleEvent(source)) {
					//		if (GCalendarUtil.IsEventEditEnd(source)) {
					dbMsg += "　編集から戻り";
					String yearMonth = args.Uri.AbsolutePath;
					dbMsg += ",yearMonth=" + yearMonth;
					string[] strs = yearMonth.Split('/');
					DateTime dt = new DateTime(int.Parse(strs[strs.Length - 3]), int.Parse(strs[strs.Length - 2]), int.Parse(strs[strs.Length - 1]));
					yearMonth =String.Format("{0:yyyyMM}", dt);
					MonthInfo monthInfo = new MonthInfo(yearMonth);
					//カレンダーを更新
					mainView.CreateCalendar(monthInfo);
					//webを閉じる
					QuitMe();
					//		}
					//}
				}else{
					url_tb.Text = source;
					if (source.Contains("eventedit")) {
						/*
						 htmlの中にdata-eid=　が有れば
						 読み込ませる時は
						  var content = fileManager.Read("help.html"); // Manually read the content of html file
						webView.NavigateToString(content);
						 */
						dbMsg += "　　>>編集へ";
						IsEventEdit = true;                                //編集中
				//		MakeEvent(source, @b_UrlStr);
					} else if (status_sp.IsVisible) {
						dbMsg += "　　>>削除ボタンを隠す";
						status_sp.Visibility = Visibility.Hidden;
					}
					string source2 = @web_wb.Source.ToString();
					dbMsg += "	,Source=　" + source2;
				}
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
		/// EventIdをURLから検索
		/// 
		/// ボタン外のクリックでも新規作成されても
		/// </summary>
		/// <param name="HtmlLink"></param>
		/// <param name="CurrentUrl"></param>
		private void MakeEvent(string HtmlLink, string CurrentUrl)
		{
			string TAG = "MakeEvent";
			string dbMsg = "[WebWindow]";
			try {
				status_sp.Visibility = Visibility.Visible;
				dbMsg += "　削除ボタンを表示";
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
					
					/*
					<div class="JPdR6b e5Emjc kydeve e6NAn" jscontroller="RsXxRc"
					jsaction="IpSVtb:TvD9Pc;fEN2Ze:xzS4ub;frq95c:LNeFm;cFpp9e:J9oOtd; 
					click:H8nU8b; mouseup:H8nU8b; keydown:I481le; keypress:Kr2w4b; blur:O22p3e; 
					focus:H8nU8b;Z2AmMb:b50fGb;arGABd:aqzPVe;rcuQ6b:BPlul; 
					contextmenu:nbwkDe;h4C2te:MvKmtd;fXDjj:LzIuXe;" role="menu" tabindex="0" jsname="mg9Pef" 
					jsshadow="" 
					data-eid="M2ppcWYwNzlkM2Rka2RvaXVnNWw3ZzRqbGFfMjAyMDA3MTRUMDQwMDAwWiBoa3V3YXVhbWFAbQ" 
					data-back-to-cancel="false" style="position: absolute; max-width: 192px; left: 576px; top: 762px; max-height: 115px;"><div class="XvhY1d" jsaction="mousedown:p8EH2c; touchstart:p8EH2c;" style="max-width: 192px; max-height: 115px;"><div class="JAPqpe K0NPx" style="width: auto; height: auto; min-width: auto;"><span jsslot="" class="z80M1 PeCuse" jsaction="click:o6ZaF(preventDefault=true); mousedown:lAhnzb; mouseup:Osgxgf; mouseenter:SKyDAe; mouseleave:xq3APb;touchstart:jJiBRc; touchmove:kZeBdd; touchend:VfAz8(preventMouseEvents=true)" jsname="j7LFlb" aria-label="削除" role="menuitem" tabindex="-1"><div class="aBBjbd MbhUzd" jsname="ksKsZd"></div><div class="PCdOIb Ce1Y1c" aria-hidden="true"><span class="DPvwYc WcqLNe" aria-hidden="true"></span></div><div class="uyYuVb oJeWuf" jsname="BTRoxd"><div class="jO7h3c">削除</div></div></span><div class="kCtYwe ugNmBf" role="separator"></div><div jsname="j7LFlb" jsaction="focus:RZmiOe" jscontroller="VaW6vf"></div><div class="a63c9c ztKZ3d" jscontroller="CoDNrf" data-colors-per-row="6"><div><div class="ZeXxJd"><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#D50000" style="background-color: #D50000" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="69" tabindex="0" aria-label="トマトを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="トマト" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#E67C73" style="background-color: #E67C73" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="68" tabindex="0" aria-label="フラミンゴを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="フラミンゴ" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#F4511E" style="background-color: #F4511E" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="70" tabindex="0" aria-label="ミカンを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="ミカン" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#F6BF26" style="background-color: #F6BF26" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="78" tabindex="0" aria-label="バナナを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc eO2Zfd" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="バナナ" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#33B679" style="background-color: #33B679" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="79" tabindex="0" aria-label="セージを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="セージ" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#0B8043" style="background-color: #0B8043" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="74" tabindex="0" aria-label="バジルを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="バジル" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div></div><div class="ZeXxJd"><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#039BE5" style="background-color: #039BE5" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="-1" tabindex="0" aria-label="ピーコックを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="ピーコック" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#3F51B5" style="background-color: #3F51B5" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="82" tabindex="0" aria-label="ブルーベリーを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="ブルーベリー" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#7986CB" style="background-color: #7986CB" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="83" tabindex="0" aria-label="ラベンダーを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="ラベンダー" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#8E24AA" style="background-color: #8E24AA" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="89" tabindex="0" aria-label="ブドウを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="ブドウ" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div><div class="azQ4Lc pka1xd " jsname="Ly0WL" data-color="#616161" style="background-color: #616161" jsaction="click:rhcxd; keydown:Hq2uPe; focus:htbtNd;" data-color-index="85" tabindex="0" aria-label="グラファイトを予定の色に設定" role="menuitem"><span class="DPvwYc rXgejc" aria-hidden="true"></span><div class="WdtDhe" aria-hidden="true" jscontroller="BwYvd" jsaction="focus: eGiyHb;mouseenter: eGiyHb; touchstart: eGiyHb;" data-text="グラファイト" data-tooltip-position="top" data-tooltip-vertical-offset="0" data-tooltip-horizontal-offset="0" data-tooltip-only-if-necessary="false"></div></div></div></div></div><div jsname="j7LFlb" jsaction="focus:AN1NLe" jscontroller="VaW6vf"></div></div></div></div>
					 */
					Google.Apis.Calendar.v3.Data.Event rEvent = GCalendarUtil.Pram2GEvents("HtmlLink", HtmlLink, timeMin, timeMax);
					//Task<Google.Apis.Calendar.v3.Data.Event> idRequest = Task.Run(() => {
					//	return GCalendarUtil.Pram2GEvents("HtmlLink", HtmlLink, timeMin, timeMax);
					//});
					//idRequest.Wait();
					//Google.Apis.Calendar.v3.Data.Event rEvent = idRequest.Result;                           //作成結果が格納され戻される
					//if(rEvent.Start == null) {
					//	// return様のダミーEventなら消す
					//	rEvent = null;
					//}

					if (rEvent != null) {
						dbMsg += "  ,rEvent=" + rEvent.Id;
						dbMsg += " ; " + rEvent.Summary;
						//対象予定に情報
						Task<string> evRequest = Task.Run(() => {
							return GCalendarUtil.ModifyingEvent(rEvent, timeCurrent);
						});
						evRequest.Wait();
						string TaregetURL = evRequest.Result;                           //作成結果が格納され戻される
						if (TaregetURL != null) {
							dbMsg += " >>" + TaregetURL;
							//if (!TaregetURL.Equals("")) {
							//	web_wb.Navigate(TaregetURL);
							//}
						}
					}else{
						dbMsg += " >>Refresh";
						web_wb.Refresh();
					}
					
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
