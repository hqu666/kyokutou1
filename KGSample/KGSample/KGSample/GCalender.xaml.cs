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
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;

namespace KGSample {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// cbYearMonthで該当年月を保持
	/// </summary>
	public partial class GCalender : MetroWindow {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		private Rectangle selectedRec;
		private System.Windows.Style selectedRecStyle;

		private string selectYM = "";
		private string b_selectYM = "";


		public GCalender()
		{
			string TAG = "GCalender";
			string dbMsg = "[GCalender]";
			try {
				InitializeComponent();
				Conect2Calender( true);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 接続
		/// </summary>
		/// <param name="isListUp"></param>
		private void Conect2Calender(Boolean isListUp)
		{
			string TAG = "Conect2Calender";
			string dbMsg = "[GCalender]";
			try {
				String retStr = GAuthUtil.Authentication("drive_calender.json", "token.json");
				dbMsg += ",retStr=" + retStr;
				if (retStr.Equals("")) {
					//メッセージボックスを表示する
					String titolStr = Constant.ApplicationName;
					String msgStr = "認証されませんでした。\r\n更新ボタンをクリックして下さい";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
				} else {
					string UserId = Constant.MyCalendarCredential.UserId;
					dbMsg += ",UserId=" + UserId;
					MyLog(TAG, dbMsg);
					if (isListUp) {
						DrowToday();
					}
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// treeViewへEventの登録状態表示
		/// </summary>
		public IList<Google.Apis.Calendar.v3.Data.Event> EventListUp(DateTime timeMin, DateTime timeMax)
		{
			string TAG = "EventListUp";
			string dbMsg = "[GCalender]";
			IList<Google.Apis.Calendar.v3.Data.Event> GCalenderEvent =new List<Google.Apis.Calendar.v3.Data.Event>();
			try {
				String titolStr = Constant.ApplicationName;
				String msgStr = "";
				GCalenderEvent = GCalendarUtil.GEventsListUp(timeMin, timeMax);
				if (GCalenderEvent != null) {
					dbMsg += GCalenderEvent.Count + "件";

					if (0 <GCalenderEvent.Count) {
						foreach (Google.Apis.Calendar.v3.Data.Event eventItem in GCalenderEvent) {
							string startDT = eventItem.Start.DateTime.ToString();
							dbMsg += "\r\n" + startDT;
							string endDT = eventItem.End.DateTime.ToString();
							dbMsg += "～" + endDT;
							if (String.IsNullOrEmpty(startDT)) {
								startDT = eventItem.Start.Date;
							}
							string Summary = eventItem.Summary;
							dbMsg += "," + Summary;
						}

					} else {
						msgStr = "カレンダーには未だ予定が登録されていません";
					}
				} else {
					msgStr = "カレンダーの情報を取得できませんでした";
				}
				if (!msgStr.Equals("")) {
					dbMsg += ",msgStr=" + msgStr;
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return GCalenderEvent;
		}



		/// <summary>
		/// 本日ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Today_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Today_bt_Click";
			string dbMsg = "[GCalender]";
			try {
				DrowToday();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void DrowToday()
		{
			string TAG = "DrowToday";
			string dbMsg = "[GCalender]";
			try {
				DateTime now = DateTime.Now;
				YearMonthComboMake(now);
				CreateCalendar(this.cbYearMonth.SelectedItem as MonthInfo);

				string selectName = "R" + String.Format("{0:yyyyMMdd}", now);       //数字になるものは名前にならない
				dbMsg += ":rselectNameec=" + selectName;
		//		Rectangle.
		//		this.s.FindName(selectName, Rectangle) as Rectangle;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 選択されている年月から半年戻す
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Back_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Back_bt_Click";
			string dbMsg = "[GCalender]";
			try {
				dbMsg += "、selectYM=" + selectYM;
				string yStr = selectYM.Substring(0, 4);
				string mStr = selectYM.Substring(4, 2);
				dbMsg += "、" + yStr + "年" + mStr + "月";
				DateTime setDate = new DateTime(int.Parse(yStr), int.Parse(mStr), 1).AddMonths(-6);
				dbMsg += "、setDate=" + setDate;
				//await Task.Delay(1000);
				YearMonthComboMake(setDate);
				CreateCalendar(this.cbYearMonth.SelectedItem as MonthInfo);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 選択されている年月から半年送る
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Next_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "BacNext_bt_Clickk_bt_Click";
			string dbMsg = "[GCalender]";
			try {
				dbMsg += "、selectYM=" + selectYM;
				string yStr = selectYM.Substring(0, 4);
				string mStr = selectYM.Substring(4, 2);
				dbMsg += "、" + yStr + "年" + mStr + "月";
				DateTime setDate = new DateTime(int.Parse(yStr), int.Parse(mStr), 1).AddMonths(6);
				dbMsg += "、setDate=" + setDate;
				//await Task.Delay(1000);
				YearMonthComboMake(setDate);
				CreateCalendar(this.cbYearMonth.SelectedItem as MonthInfo);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 年月選択コンボボックスを生成する
		/// </summary>
		/// <param name="targetYM">DateTime</param>
		private void YearMonthComboMake(DateTime targetYM)
		{
			string TAG = "YearMonthComboMake";
			string dbMsg = "[GCalender]";
			try {
				dbMsg += "、" + targetYM;
				List<MonthInfo> list = new List<MonthInfo>();
				DateTime dt = targetYM.AddMonths(-5);
				for (int i = 0; i < 12; i++) {
					list.Add(new MonthInfo(String.Format("{0:yyyyMM}", dt)));
					dt = dt.AddMonths(1);
				}
				this.cbYearMonth.ItemsSource = list;
				this.cbYearMonth.DisplayMemberPath = "YearMonthWithKanji";
				this.cbYearMonth.SelectedIndex = 5;                         //SelectionChangedが発生してしまうのでCreateCalendarでトラップ
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 年月コンボの選択変更イベントハンドラー.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbYearMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "cbYearMonth_SelectionChanged";
			string dbMsg = "[GCalender]";
			try {
				MonthInfo selectItem = (cbYearMonth.SelectedItem as MonthInfo);
				if(selectItem.YearMonth != null) {
					selectYM = selectItem.YearMonth;
					dbMsg += "、" + selectYM;
					CreateCalendar(cbYearMonth.SelectedItem as MonthInfo);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void MetroWindow_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			string TAG = "MetroWindow_SizeChanged";
			string dbMsg = "[GCalender]";
			try {
				CreateCalendar(cbYearMonth.SelectedItem as MonthInfo);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 指定された年月のカレンダーを作成
		/// </summary>
		/// <param name="monthInfo"></param>
		private string CreateCalendar(MonthInfo monthInfo)
		{
			string TAG = "createCalendar";
			string dbMsg = "[GCalender]";
			string retStr = null;
			try {
				dbMsg += "," + monthInfo.YearMonth;
				if (monthInfo.YearMonth.Equals(b_selectYM)) {
					dbMsg += ">>同月";
				} else {
					Application.Current.MainWindow = this;
					double windowWidth = Application.Current.MainWindow.Width;
					double windowHeight = Application.Current.MainWindow.Height;
					dbMsg += "window[" + windowWidth + "×" + windowHeight + "]";

					CalendarContainer.Children.Clear();

					// グループボックス
					GroupBox calendarGroup1 = new GroupBox();
					//		calendarGroup1.Header = monthInfo.YearMonthWithKanji;		//カレンダーの左上に当月を書き込む
					calendarGroup1.Style = FindResource("gp-normal") as System.Windows.Style;

					// グリッド
					Grid calendarGrid1 = new Grid();
					calendarGrid1.Style = FindResource("grid-calendar") as System.Windows.Style;
					double windowMarginTop = 150;
					double windowMarginLeft = 20;
					double windowMarginRight = 30;
					double windowMarginBottom = 10;
					dbMsg += "、Margin← " + windowMarginLeft + "  ↑ " + windowMarginTop + "  ⇒  " + windowMarginRight + " ↓" + windowMarginBottom;
					double CalendarWidth = windowWidth - (windowMarginLeft + windowMarginRight);
					double CalendarHight = windowHeight - (windowMarginTop + windowMarginBottom);
					dbMsg += ">>Calendar[" + CalendarWidth + "×" + CalendarHight + "]";
					calendarGrid1.Width = CalendarWidth;
					calendarGrid1.Height = CalendarHight;

					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20) });
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

					// 曜日を記入	グリッド枠線
					Rectangle border = new Rectangle();
					border.Style = FindResource("rec-border") as System.Windows.Style;
					calendarGrid1.Children.Add(border);
					for (int col = 0; col < 7; col++) {
						Rectangle week = new Rectangle();
						if (col == 0) {
							week.Style = FindResource("rec-week-sun") as System.Windows.Style;
						} else if (col == 6) {
							week.Style = FindResource("rec-week-sat") as System.Windows.Style;
						} else {
							week.Style = FindResource("rec-week-mf") as System.Windows.Style;
						}
						week.SetValue(Grid.ColumnProperty, col);
						calendarGrid1.Children.Add(week);
						Label lbWeek = new Label();
						lbWeek.Style = FindResource("lb-week") as System.Windows.Style;
						lbWeek.Content = ("日月火水木金土").Substring(col, 1);
						lbWeek.SetValue(Grid.ColumnProperty, col);
						calendarGrid1.Children.Add(lbWeek);
					}
					// ヘッダ行下線
					Rectangle underlining = new Rectangle();
					underlining.Style = FindResource("rec-underlining") as System.Windows.Style;
					calendarGrid1.Children.Add(underlining);
					// グループボックスにグリッドを追加
					calendarGroup1.Content = calendarGrid1;
					CalendarContainer.Children.Add(calendarGroup1);
					// 当月の月初を取得
					DateTime firstDate = new DateTime(int.Parse(monthInfo.getYear()), int.Parse(monthInfo.getMonth()), 1);
					// 曜日番号の取得
					int dayOfWeek = (int)firstDate.DayOfWeek;
					// 月末を取得
					int lastDay = firstDate.AddMonths(1).AddDays(-1).Day;
					dbMsg += "\r\n今月" + firstDate + "(" + dayOfWeek + ")～" + lastDay;
					int lMonthBack = -dayOfWeek;
					int llManthStartDay = firstDate.AddDays(lMonthBack).Day;
					dbMsg += "\r\n先月" + -lMonthBack + "日戻して" + llManthStartDay + "日から";
					DateTime lastDate = new DateTime(int.Parse(monthInfo.getYear()), int.Parse(monthInfo.getMonth()), lastDay);
					int lastDayOfWeek = (int)lastDate.DayOfWeek;
					int nMonthLastday = 6 - lastDayOfWeek;
					int nMonthFowerd = lastDay + nMonthLastday;
					dbMsg += "\r\n次月" + nMonthLastday + "日まで,カウントは" + nMonthFowerd + "まで";
					DateTime timeMin = firstDate.AddMonths(-1);			//	default(DateTime);
					DateTime timeMax = firstDate.AddMonths(1);         //default(DateTime);
					IList<Google.Apis.Calendar.v3.Data.Event> GCalenderEvent = EventListUp( timeMin,  timeMax);
					dbMsg += "\r\nEvent" + GCalenderEvent.Count + "件";
					// 1日から月末まを走査
					for (int dayCount = lMonthBack; dayCount < nMonthFowerd; dayCount++) {
						int day = firstDate.AddDays(dayCount).Day;
						int index = (dayCount) + dayOfWeek;
						int x = index % 7;
						int y = index / 7;
						dbMsg += "\r\n(" + dayCount + ")" + day + "日:セル位置[" + index + "](" + x + " .  " + y + ")";
						DateTime carentDate = firstDate.AddDays(dayCount);
						dbMsg += ":" + carentDate;
						// テキストブロックを生成してグリッドに追加
						var tb = new TextBlock();
						tb.Text = string.Format("{0}", day);
						// 土日は文字色を変更する
						if (x == 0) {
							dbMsg += "(日)";
							tb.Style = FindResource("txb-date-sun") as System.Windows.Style;
						} else if (x == 6) {
							dbMsg += "(土)";
							tb.Style = FindResource("txb-date-sat") as System.Windows.Style;
						} else {
							tb.Style = FindResource("txb-date") as System.Windows.Style;
						}
						calendarGrid1.Children.Add(tb);
						tb.SetValue(Grid.ColumnProperty, x);
						tb.SetValue(Grid.RowProperty, y + 1);

						// 四角形を生成してグリッドに追加
						// セルの枠線などを表示し、イベントをハンドリングする用
						var rec = new Rectangle();
						DateInfo dt = new DateInfo(String.Format("{0:yyyyMM}", carentDate), string.Format("{0:00}", day));
						rec.DataContext = dt;
						// 土曜日の枠線を調整
						if (x == 6) {
							rec.Style = FindResource("rec-date-sat") as System.Windows.Style;
						} else {
							rec.Style = FindResource("rec-date") as System .Windows.Style;
						}
						//月中でなければ
						if (dayCount < 0 || lastDay <= dayCount) {
							rec.Style = FindResource("rec-date-outside") as System.Windows.Style;
						}

						string setName = "R"+ String.Format("{0:yyyyMMdd}", carentDate);		//数字になるものは名前にならない
						dbMsg += ":setName:" + setName;
						this.RegisterName(setName, rec);                        //	rec.Name = setName では設定できない
						dbMsg += ":rec:" + rec.Name;

						// イベント設定
						rec.MouseLeftButtonDown += date_MouseLeftButtonDown;
						calendarGrid1.Children.Add(rec);
						rec.SetValue(Grid.ColumnProperty, x);
						rec.SetValue(Grid.RowProperty, y + 1);
					}
				}
				b_selectYM = monthInfo.YearMonth;
				retStr = monthInfo.YearMonth;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retStr;
		}

		/// <summary>
		/// セル（日）をクリックした際のイベントハンドラ.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void date_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			string TAG = "date_MouseLeftButtonDown";
			string dbMsg = "[GCalender]";
			try {
				// 既に選択されたセルがある場合はスタイルを戻す
				if (selectedRec != null) {
					selectedRec.Style = selectedRecStyle;
				}
				// 選択されたセルの取得
				Rectangle rec = sender as Rectangle;
				// 選択セルの保持
				selectedRec = rec;
				selectedRecStyle = rec.Style;
				// 選択時のスタイルに変更
				rec.Style = FindResource("rec-date-selected") as System.Windows.Style;
				// ラベルに日付をセット
				dbMsg += "、" + rec.DataContext;
				lbSelectedDate.Content = (rec.DataContext as DateInfo).getYearMonthDayWithKanji();
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
																		){
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}

	}
}
/*
 【WPF】自作カレンダー　その２（動的生成）		https://www.doraxdora.com/blog/2017/10/16/post-2779/
 */
