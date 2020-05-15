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
	/// </summary>
	public partial class GCalender : MetroWindow {
		private Rectangle selectedRec;
		private System.Windows.Style selectedRecStyle;

		public GCalender()
		{
			string TAG = "GCalender";
			string dbMsg = "[GCalender]";
			try {
				InitializeComponent();

				// 前月から6カ月分のリストを作成し、当月を選択させる
				List<MonthInfo> list = new List<MonthInfo>();
				DateTime now = DateTime.Now;
				DateTime dt = now.AddMonths(-1);
				for (int i = 0; i < 6; i++) {
					list.Add(new MonthInfo(String.Format("{0:yyyyMM}", dt)));
					dt = dt.AddMonths(1);
				}
				this.cbYearMonth.ItemsSource = list;
				this.cbYearMonth.DisplayMemberPath = "YearMonthWithKanji";
				this.cbYearMonth.SelectedIndex = 1;

				createCalendar(this.cbYearMonth.SelectedItem as MonthInfo);
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
				createCalendar(cbYearMonth.SelectedItem as MonthInfo);
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
				createCalendar(cbYearMonth.SelectedItem as MonthInfo);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 指定された年月のカレンダーを作成
		/// </summary>
		/// <param name="monthInfo"></param>
		private void createCalendar(MonthInfo monthInfo)
		{
			string TAG = "createCalendar";
			string dbMsg = "[GCalender]";
			try {
				Application.Current.MainWindow = this;
				double windowWidth = Application.Current.MainWindow.Width;
				double windowHeight = Application.Current.MainWindow.Height;
				dbMsg = "window[" + windowWidth + "×" + windowHeight + "]";

				CalendarContainer.Children.Clear();

				// グループボックス
				GroupBox calendarGroup1 = new GroupBox();
				calendarGroup1.Header = monthInfo.YearMonthWithKanji;
				calendarGroup1.Style = FindResource("gp-normal") as System.Windows.Style;

				// グリッド
				Grid calendarGrid1 = new Grid();
				calendarGrid1.Style = FindResource("grid-calendar") as System.Windows.Style;
				double windowMarginTop = 140;
				double windowMarginLeft = 20;
				double windowMarginRight = 30;
				double windowMarginBottom = 10;
				dbMsg = "、Margin← " + windowMarginLeft + "  ↑ " + windowMarginTop + "  ⇒  " + windowMarginRight + " ↓" + windowMarginBottom;
				double CalendarWidth = windowWidth - (windowMarginLeft + windowMarginRight);
				double CalendarHight = windowHeight - (windowMarginTop + windowMarginBottom);
				dbMsg = ">>Calendar[" + CalendarWidth + "×" + CalendarHight + "]";
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

				// グリッド枠線
				Rectangle border = new Rectangle();
				border.Style = FindResource("rec-border") as System.Windows.Style;
				calendarGrid1.Children.Add(border);
				for (int col = 0; col < 7; col++) {
					Rectangle week = new Rectangle();
					if(col == 0) {
						week.Style =  FindResource("rec-week-sun") as System.Windows.Style;
					}else if(col == 6) {
						week.Style = FindResource("rec-week-sat") as System.Windows.Style;
					}
					//	week.Style = (col == 6) ? FindResource("rec-week-sat") as System.Windows.Style : FindResource("rec-week-mf") as System.Windows.Style;
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
				var firstDate = new DateTime(int.Parse(monthInfo.getYear()), int.Parse(monthInfo.getMonth()), 1);
				// 曜日番号の取得
				int dayOfWeek = (int)firstDate.DayOfWeek;
				// 月末を取得
				int lastDay = firstDate.AddMonths(1).AddDays(-1).Day;
				// 1日から月末までを走査
				for (int day = 1; day <= lastDay; day++) {
					// セル位置
					int index = (day - 1) + dayOfWeek;
					// 横位置
					int x = index % 7;
					// 縦位置
					int y = index / 7;
					// テキストブロックを生成してグリッドに追加
					var tb = new TextBlock();
					tb.Text = string.Format("{0}", day);
					// 土日は文字色を変更する
					if (x == 0) {
						tb.Style = FindResource("txb-date-sun") as System.Windows.Style;
					} else if (x == 6) {
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
					DateInfo dt = new DateInfo(monthInfo.YearMonth, string.Format("{0:00}", day));
					rec.DataContext = dt;
					// 枠線を調整
					rec.Style = (x == 6) ? FindResource("rec-date-sat") as System.Windows.Style : FindResource("rec-date") as System.Windows.Style;
					// イベント設定
					rec.MouseLeftButtonDown += date_MouseLeftButtonDown;
					calendarGrid1.Children.Add(rec);
					rec.SetValue(Grid.ColumnProperty, x);
					rec.SetValue(Grid.RowProperty, y + 1);

				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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

	}
}
/*
 【WPF】自作カレンダー　その２（動的生成）		https://www.doraxdora.com/blog/2017/10/16/post-2779/
 */
