﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace KGSample {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// cbYearMonthで該当年月を保持
	/// </summary>
	public partial class GCalender : Window {
		LocalFileUtil LFUtil = new LocalFileUtil();
		GoogleAuthUtil GAuthUtil = new GoogleAuthUtil();
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public GEventEdit editView;
		public GEventDayList dayListView;
		public WebWindow webWindow;

		private Rectangle selectedRec;
		private System.Windows.Style selectedRecStyle;

		private string selectYM = "";
		private string b_selectYM = "";
		private string taregetURL = null;


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
				b_selectYM = "";            //要サイズ修正
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

					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });	//日
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });	//月
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });	//火
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });	//水
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });	//木
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });	//金
					calendarGrid1.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });	//土
					calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(25) });                                          //曜日記入行
					int manthWeek = 6;			//一月の表示に使う行数
					int dayRow = 5;				//行数一日に使う行数
					for (int rCount = 0; rCount < (manthWeek*dayRow); rCount++) {
						calendarGrid1.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
					}

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
					DateTime timeMin = firstDate.AddMonths(-1);
					DateTime timeMax = firstDate.AddMonths(2); 
					IList<Google.Apis.Calendar.v3.Data.Event> GCalenderEvent = EventListUp( timeMin,  timeMax);
					dbMsg += "\r\nEvent" + GCalenderEvent.Count + "件";
					IList<EventSpan> eventSpanList = new List<EventSpan>();		//記載中の複数の日に渡るスケジュール

					// 1日から月末まを走査
					for (int dayCount = lMonthBack; dayCount < nMonthFowerd; dayCount++) {
						int day = firstDate.AddDays(dayCount).Day;
						int index = (dayCount) + dayOfWeek;
						int x = index % 7;
						int y = index / 7 * dayRow;
						dbMsg += "\r\n(" + dayCount + ")" + day + "日:セル位置[" + index + "](" + x + "." + y + ")";
						int weekTop = y; 
						int weekBottom = y + dayRow ;
						dbMsg += "～" + weekBottom;
						DateTime carentDate = firstDate.AddDays(dayCount);
						string carentDateStr = String.Format("{0:yyyyMMdd}", carentDate); 
						dbMsg += "carentDateStr=" + carentDateStr;
						DateInfo dt = new DateInfo(String.Format("{0:yyyyMM}", carentDate), string.Format("{0:00}", day));
						int eventStartRow = y+2;                  //タイトル行直下
						dbMsg += "," + eventStartRow + "行目からスケジュールの書き込み開始";
						int carentDateInt = int.Parse(carentDateStr);

						// テキストブロックを生成してStackPanelの一番上に追加
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

						//string setName = "R"+ String.Format("{0:yyyyMMdd}", carentDate);		//数字になるものは名前にならない
						//dbMsg += ":setName:" + setName;
						//this.RegisterName(setName, rec);                        //	rec.Name = setName では設定できない
						//dbMsg += ":rec:" + rec.Name;
						// イベント設定
						rec.MouseLeftButtonDown += date_MouseLeftButtonDown;
						rec.MouseDown += Date_MouseDown;
						calendarGrid1.Children.Add(rec);
						rec.SetValue(Grid.ColumnProperty, x);
						rec.SetValue(Grid.RowProperty, y + 1);

						y++;
						/////スケジュール////////////////////////////////////////////////////
						IList<int> writeSkip = new List<int>();
						bool isRemove = false;

						if (0 < GCalenderEvent.Count) {
							IList<Google.Apis.Calendar.v3.Data.Event> TodayEvent = new List<Google.Apis.Calendar.v3.Data.Event>();
	
							if (0 < eventSpanList.Count) {
								dbMsg += "\r\n複数日" + eventSpanList.Count + "件";
								EventSpan delSpan = new EventSpan();
								foreach (EventSpan eventSpan in eventSpanList) {
									int eventSpanRow = eventSpan.row;
									int eventSpanEndDate = eventSpan.endDateInt;
									string eventSpanSummary = eventSpan.eventItem.Summary;
									dbMsg += "\r\n(" + eventSpanRow + ")" + eventSpanEndDate + "まで" + eventSpanSummary;
									if (eventSpanEndDate < carentDateInt) {
										delSpan = eventSpan;
										isRemove = true;
										break;
									} else {
										if (eventSpanRow == eventStartRow) {
											eventStartRow++;
											dbMsg += ">>スケジュールの書き込み開始" + eventStartRow + "行目から";
										} else {
											writeSkip.Add(eventStartRow);
										}
									}
								}
								if (isRemove) {
									eventSpanList.Remove(delSpan);
									dbMsg += "を削除>>" + eventSpanList.Count + "件";
								}
							}

							IList<Google.Apis.Calendar.v3.Data.Event> onedayEvent = new List<Google.Apis.Calendar.v3.Data.Event>();
							IList<Google.Apis.Calendar.v3.Data.Event> passesEvent = new List<Google.Apis.Calendar.v3.Data.Event>();

							if (x == 0) {																			//日曜日に
								if (0 < eventSpanList.Count) {											//前の週からの継続を確認して
									dbMsg += "," + eventSpanList.Count + "件残り";
									foreach (EventSpan eventSpan in eventSpanList) {
										dbMsg += "," + eventSpan.eventItem.Summary ;
										passesEvent.Add(eventSpan.eventItem);				//日曜日のリストに追加
									}
									dbMsg += "," + passesEvent.Count + "件から開始";
								}
								eventSpanList = new List<EventSpan>();
							}
							//本日Eventの抽出	※終日・複数日のStartはDateTimeが無い。単日はDateがない
							dbMsg += ".GCalenderEvent" + GCalenderEvent.Count + "件";
							foreach (Google.Apis.Calendar.v3.Data.Event todayItem in GCalenderEvent) {
								string startStr = GCalendarUtil.EventDateTime2Str(todayItem.Start);
								if (startStr.Equals(carentDateStr)) {
										TodayEvent.Add(todayItem);
									}
							}
							dbMsg += "中" + carentDateStr + "のスケジュールは" + TodayEvent.Count + "件";
							if (0<TodayEvent.Count ||
								(0< passesEvent.Count && x == 0)) {
								//単日と複数の日付にまたがるEventを分ける
								foreach (Google.Apis.Calendar.v3.Data.Event todayItem in TodayEvent) {
									//※翌日以降に続く事の判定
									int startInt = GCalendarUtil.EventDate2Int(todayItem.Start);
									int endInt = GCalendarUtil.EventDate2Int(todayItem.End);
									//if (endInt == startInt) {
									//※Googleの判定方法		todayItem.Start.Date == null ||
									if (endInt == startInt) {
										onedayEvent.Add(todayItem);
									}else{
										passesEvent.Add(todayItem);
									}
								}

								if(0<passesEvent.Count) {
									dbMsg += "\r\n複数の日" + passesEvent.Count + "件";
									foreach (Google.Apis.Calendar.v3.Data.Event eventItem in passesEvent) {
										//TodayEvent.Add(eventItem);
										string startStr = GCalendarUtil.EventDateTime2Str(eventItem.Start);
										string endStr = GCalendarUtil.EventDateTime2Str(eventItem.End);
										string colorId = eventItem.ColorId;
										dbMsg += "\r\n" + startStr + "～" + endStr + "、colorId=" + colorId;
										string Summary = eventItem.Summary;
										dbMsg += "  ," + Summary;
										string ContentStr = "";
										int startInt = GCalendarUtil.EventDate2Int(eventItem.Start);
										int endInt = GCalendarUtil.EventDate2Int(eventItem.End);
										if (eventItem.End.DateTime == null) {
											endInt--;
											dbMsg += ">>" + endInt;
										}
										int passesDays = endInt - startInt +1;
										dbMsg += "," + passesDays + "日に渡る";
										if (eventItem.Start.DateTime == null) {
											dbMsg += "：終日・連日：";
											ContentStr = Summary + " : " + eventItem.End.Date + "まで";
										} else {
											dbMsg += "：単日：";
											string startTimeStr = String.Format("{0:HH:mm}", eventItem.Start.DateTime);
											string endTimeStr = String.Format("{0:HH:mm}", eventItem.End.DateTime);
											dbMsg += ", " + startTimeStr + "～" + endTimeStr;
											ContentStr = startTimeStr + "～" + endTimeStr + " : " + Summary; ;
										}

										//if(0< writeSkip.Count) {
										//	foreach (int skipRow in writeSkip) {
										//		if(eventStartRow== skipRow) {
										//			eventStartRow++;
										//			dbMsg += "書き込み開始" + eventStartRow + "行目に" ;
										//		}
										//	}
										//}
										Button bt = new Button();
										bt.Content = ContentStr;
										bt.Click += Event_bt_Click;
										bt.DataContext = eventItem;
										Color BGColor = GCalendarUtil.ColorId2RGB(eventItem.ColorId);
										bt.Background = new SolidColorBrush(BGColor);
										bt.Style = FindResource("bt-event-passes") as System.Windows.Style;
										if(6<passesDays) {
											passesDays=passesDays % 7 + 1;
											dbMsg += "今週分" + passesDays + "日";
										}
										if (0 < passesDays) {
											dbMsg += ",前日から" + passesDays + "日残り";
											switch (passesDays) {
												case 2:
													bt.Style = FindResource("bt-event-two") as System.Windows.Style;
													break;
												case 3:
													bt.Style = FindResource("bt-event-three") as System.Windows.Style;
													break;
												case 4:
													bt.Style = FindResource("bt-event-four") as System.Windows.Style;
													break;
												case 5:
													bt.Style = FindResource("bt-event-five") as System.Windows.Style;
													break;
												case 6:
													bt.Style = FindResource("bt-event-six") as System.Windows.Style;
													break;
												case 7:
													bt.Style = FindResource("bt-event-seven") as System.Windows.Style;
													break;
											}

											EventSpan eventSpan = new EventSpan();
											eventSpan.row = eventStartRow;
											eventSpan.endDateInt = endInt;
											eventSpan.eventItem = eventItem;
											eventSpanList.Add(eventSpan);
											dbMsg += ",eventSpanList" + eventSpanList.Count + "件目";
										}
										calendarGrid1.Children.Add(bt);
										bt.SetValue(Grid.ColumnProperty, x);
										bt.SetValue(Grid.RowProperty, eventStartRow);
										eventStartRow++;
									}
								}

								int onedayEventCount = onedayEvent.Count;
								if (0 < onedayEventCount) {
									dbMsg += "\r\n単日" + onedayEventCount + "件";
									dbMsg += "、ここまで" + eventStartRow + "行";
									int wRow =  eventStartRow - weekTop;
									dbMsg += "、書き込めるのは" + wRow +"行";
									//if (onedayEventCount <= wRow) {
									//	dbMsg += "、ボタンで配置";
									int remeinRow = onedayEventCount;
									foreach (Google.Apis.Calendar.v3.Data.Event eventItem in onedayEvent) {
										string startTimeStr = "";
										string startStr = GCalendarUtil.EventDateTime2Str(eventItem.Start);
										string endStr = GCalendarUtil.EventDateTime2Str(eventItem.End);
										string colorId = eventItem.ColorId;
										dbMsg += "\r\n" + startStr + "～" + endStr + "、colorId=" + colorId;
										string Summary = eventItem.Summary;
										dbMsg += "  ," + Summary;
										string ContentStr = Summary;
										if (eventItem.Start.DateTime == null) {
										} else {
											startTimeStr = String.Format("{0:HH:mm}", eventItem.Start.DateTime);
											string endTimeStr = String.Format("{0:HH:mm}", eventItem.End.DateTime);
											dbMsg += ", " + startTimeStr + "～" + endTimeStr;
											ContentStr = startTimeStr + " " + Summary;
										}
										if(  eventStartRow < weekBottom) {
											tb = new TextBlock();
											tb.Style = FindResource("txb-event-one") as System.Windows.Style;
											tb.Text = "●";
											Color BGColor = GCalendarUtil.ColorId2RGB(eventItem.ColorId);
											tb.Foreground = new SolidColorBrush(BGColor);
											calendarGrid1.Children.Add(tb);
											tb.SetValue(Grid.ColumnProperty, x);
											tb.SetValue(Grid.RowProperty, eventStartRow);

											Button bt = new Button();
											bt.Content = ContentStr;
											bt.Click += Event_bt_Click;
											bt.DataContext = eventItem;
											taregetURL =  eventItem.HtmlLink;
											bt.Style = FindResource("bt-event-one") as System.Windows.Style;
											calendarGrid1.Children.Add(bt);
											bt.SetValue(Grid.ColumnProperty, x);
											bt.SetValue(Grid.RowProperty, eventStartRow);
											eventStartRow++;
											remeinRow--;
										} else {
											Button bt = new Button();
											bt.Content = "その他" + remeinRow + "件";
											bt.DataContext = startStr;
											bt.Click += Other_bt_Click;
											bt.Style = FindResource("bt-event-other") as System.Windows.Style;
											calendarGrid1.Children.Add(bt);
											bt.SetValue(Grid.ColumnProperty, x);
											bt.SetValue(Grid.RowProperty, eventStartRow);
											break;
										}
									}
								}
							}
						}
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
		/// 新規スケジュール作成
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Date_MouseDown(object sender, MouseButtonEventArgs e)
		{
			string TAG = "Date_MouseDown";
			string dbMsg = "[GCalender]";
			try {
				Rectangle rec = sender as Rectangle;
				Google.Apis.Calendar.v3.Data.Event taregetEvent = new Google.Apis.Calendar.v3.Data.Event();

				//作成直後はNullなので生成が必要
				taregetEvent.Start = new Google.Apis.Calendar.v3.Data.EventDateTime();
				taregetEvent.End = new Google.Apis.Calendar.v3.Data.EventDateTime();
				taregetEvent.OriginalStartTime = new Google.Apis.Calendar.v3.Data.EventDateTime();
				taregetEvent.Attendees = new List<Google.Apis.Calendar.v3.Data.EventAttendee>();
				taregetEvent.Attachments = new List<Google.Apis.Calendar.v3.Data.EventAttachment>();
	//			taregetEvent.Reminders = new List<Google.Apis.Calendar.v3.Data.RemindersData>();
		
				//Eventにセットできる項目
				taregetEvent.Summary = "新規案件対応会議";
				dbMsg += "taregetEvent=" + taregetEvent.Summary;
				DateTime startDT = (rec.DataContext as DateInfo).GetDateTime();
				DateTime now = DateTime.Now;
				TimeSpan nowTime = new TimeSpan(now.Hour, 0, 0);
				startDT=startDT.Add(nowTime);
				dbMsg += "startDT=" + startDT;
				taregetEvent.Start.DateTime = startDT;
				dbMsg += "Start=" + taregetEvent.Start.DateTime;
				taregetEvent.End.DateTime = startDT.AddHours(1);
				dbMsg += "～" + taregetEvent.End.DateTime;
				taregetEvent.Description ="添付ファイルを参照できる様、準備して参加をお願いします。";
				dbMsg += ",Description=" + taregetEvent.Description;
				//Eventに無い項目
				Constant.orderNumber = "abc987654321DEF";                  //受注No（参照項目）
				Constant.managementNumber = "987654321";     //管理番号（参照項目）
				Constant.customerName = "(株)TEST建設";             //得意先（参照項目）
				if (editView == null) {
					dbMsg += "Editを再生成";
					editView = new GEventEdit(taregetEvent);
					editView.mainView = this;
					editView.Show();
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
				dbMsg += "、" + rec.DataContext;
				lbSelectedDate.Content = (rec.DataContext as DateInfo).getYearMonthDayWithKanji();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// スケジュール個々の編集画面へ遷移する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Event_bt_Click(object sender, EventArgs e)
		{
			string TAG = "Event_bt_Click";
			string dbMsg = "[GCalender]";
			try {
				// 選択されたセルの取得
				Button bt = sender as Button;
				Google.Apis.Calendar.v3.Data.Event taregetEvent = bt.DataContext as Google.Apis.Calendar.v3.Data.Event;
				dbMsg += "taregetEvent=" + taregetEvent.Summary;
				//Eventに無い項目
				Constant.orderNumber = "abc987654321DEF";                  //受注No（参照項目）
				Constant.managementNumber = "987654321";     //管理番号（参照項目）
				Constant.customerName = "(株)TEST建設";             //得意先（参照項目）
				if (editView == null) {
					dbMsg += "Editを再生成";
					editView = new GEventEdit(taregetEvent);
					editView.mainView = this;
					editView.Show();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Other_bt_Click(object sender, EventArgs e)
		{
			string TAG = "Other_bt_Click";
			string dbMsg = "[GCalender]";
			try {
				if (dayListView == null) {
					dbMsg = "一日表示を再生成";
					dayListView = new GEventDayList();
					dayListView.mainView = this;
				}
				MyLog(TAG, dbMsg);
				dayListView.Show();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 一日リストへ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Button_Click";
			string dbMsg = "[GCalender]";
			try {
				dbMsg += "taregetURL=" + taregetURL;
				if (webWindow == null) {
					dbMsg += "一日リストを生成";
					webWindow = new WebWindow(new Uri(taregetURL));
					webWindow.mainView = this;
					webWindow.Show();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// 連日予定の終了状況管理
		/// </summary>
		public class EventSpan {
		/// <summary>
		/// 日付の直下を1行目にした行番号
		/// </summary>
			public int row { get; set; }
			/// <summary>
			/// 終了日
			/// </summary>
			public int endDateInt { get; set; }
			/// <summary>
			/// 対象スケジュール
			/// </summary>
			public Google.Apis.Calendar.v3.Data.Event eventItem { get; set; }
		}


		public class GEvent {
			public string color { get; set; }
			public string start { get; set; }
			public string summary { get; set; }
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
calendar  v3		https://developers.google.com/resources/api-libraries/documentation/calendar/v3/csharp/latest/classGoogle_1_1Apis_1_1Calendar_1_1v3_1_1Data_1_1Event.html#ac23c0f6e9cd8f8eff44dbe1694143279	

 */