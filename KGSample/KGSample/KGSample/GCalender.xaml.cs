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
	/// GCalender.xaml の相互作用ロジック
	/// </summary>
	public partial class GCalender : MetroWindow {
		CS_Util Util = new CS_Util();

		//LocalFileUtil LFUtil = new LocalFileUtil();
		//GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		//GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		//GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();
		private Rectangle selectedRec;

		public GCalender()
		{
			string TAG = "GCalender";
			string dbMsg = "[GCalender]";
			try {
				InitializeComponent();
				DateTime taregetDate = DateTime.Now;
				dbMsg += "今日は" + String.Format("{0:yyyy年MM月}", taregetDate);
				Util.MyLog(TAG, dbMsg);
				MakeCalender(taregetDate);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void MakeCalender(DateTime taregetDate)
		{
			string TAG = "MakeCalender";
			string dbMsg = "[GCalender]";
			try {
				dbMsg += "対象年月" + String.Format("{0:yyyy年MM月}", taregetDate);

				CalendarGropu1.Header = String.Format("{0:yyyy年MM月}", taregetDate);

				// 当月の月初を取得
				var firstDate = new DateTime(DateTime.Now.Year, taregetDate.Month, 1);
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

					// 土日は文字色を変更する
					Color color = Colors.Black;
					if (x == 0) {
						color = Colors.Red;
					} else if (x == 6) {
						color = Colors.Blue;
					}

					// テキストブロックを生成してグリッドに追加
					var tb = new TextBlock() {
						Text = string.Format("{0}", day),
						FontSize = 12,
						Foreground = new SolidColorBrush(color),
						Padding = new Thickness(0, 10, 10, 0),
						HorizontalAlignment = HorizontalAlignment.Right,
						VerticalAlignment = VerticalAlignment.Top
					};
					this.CalendarGrid.Children.Add(tb);
					tb.SetValue(Grid.ColumnProperty, x);
					tb.SetValue(Grid.RowProperty, y + 1);

					// 四角形を生成してグリッドに追加
					// セルの枠線などを表示し、イベントをハンドリングする用
					var rec = new Rectangle();
					rec.HorizontalAlignment = HorizontalAlignment.Stretch;
					rec.VerticalAlignment = VerticalAlignment.Stretch;
					// 背景色を設定しないとイベントを検知できないらしいので透過色を設定
					rec.Fill = Brushes.Transparent;
					// 枠線を調整
					rec.Margin = (x == 6) ? new Thickness(0.0, -1.0, 0.0, 0.0) : new Thickness(0.0, -1.0, -1.0, 0.0);
					// イベント設定
					rec.MouseLeftButtonDown += date_MouseLeftButtonDown;
					this.CalendarGrid.Children.Add(rec);
					rec.SetValue(Grid.ColumnProperty, x);
					rec.SetValue(Grid.RowProperty, y + 1);
				}
				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// セル（日）をクリックした際のイベントハンドラ.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void date_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			string TAG = "date_MouseLeftButtonDown";
			string dbMsg = "[GCalender]";
			try {
				// 既に選択されたセルがある場合は初期化
				if (selectedRec != null) {
					selectedRec.StrokeDashArray = null;
					selectedRec.StrokeThickness = 0;
				}

				// 枠線に点線をセット
				Rectangle rec = sender as Rectangle;
				rec.Stroke = Brushes.Black;
				DoubleCollection dbc = new DoubleCollection();
				dbc.Add(1);
				dbc.Add(1);
				rec.StrokeDashArray = dbc;
				rec.StrokeThickness = 1;

				// 選択セルの保持
				selectedRec = rec; Util.MyLog(TAG, dbMsg);
				Util.MyLog(TAG, dbMsg);
			} catch (Exception er) {
				Util.MyErrorLog(TAG, dbMsg, er);
			}
		}
	}
}



/*
 【WPF】自作カレンダー　その１（とりあえず当月を表示）https://www.doraxdora.com/blog/2017/10/15/post-2760/
 */
