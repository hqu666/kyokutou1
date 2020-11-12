using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Infragistics.Controls.Schedules;
using Livet;
using Livet.Commands;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Google.Apis.Drive.v3.Data;
using MySql.Data.MySqlClient;

using TabCon.Models;
using Task = System.Threading.Tasks.Task;

namespace TabCon.ViewModels {
	public class X_2ViewModel : ViewModel {
		public string titolStr = "【スケジュール登録】";
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		//public GoogleAuth authWindow;
		//public GCalender mainView;
		//public GoogleDriveBrouser driveView;
		//public WebWindow webWindow;

		public t_events tEvents;
		public t_project_bases tProject;
		//public IList<GAttachFile> sendFiles = new List<GAttachFile>();
		///// <summary>
		///// 添付ファイル　モデル
		///// </summary>
		//private AttachmentDataCollection attachmentDataCollection;


		/// <summary>
		/// このページで編集するEvent
		/// </summary>
		private Google.Apis.Calendar.v3.Data.Event taregetEvent { set; get; }
		/// <summary>
		/// 週別/日別区分
		/// </summary>
		public string weekDisplayMode { get; set; }

		public Views.X_2 MyView { get; set; }
		public ViewModels.MainViewModel RootViewModel { get; set; }
		public Controls.X_1_Control Control { get; set; }
		/// <summary>
		/// イベント種別
		/// </summary>
		public Dictionary<string, string> EventComboSource { get; set; }
		public IList<string> EventComboSelectedItem { get; set; }
		public Int32 EventComboSelectedIndex { get; set; }

		//表示対象年月
		public DateTime SelectedDateTime;
		/// <summary>
		/// 表示対象年月
		/// </summary>
		public string CurrentDate { get; set; }

		/// <summary>
		/// 予定配列
		/// </summary>
		public ObservableCollection<t_events> Events { get; set; }

		public MySQL_Util MySQLUtil;

		public X_2ViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try {
				dbMsg += ",weekDisplayMode=" + weekDisplayMode;
				EventComboSource = new Dictionary<string, string>()
				{
					{ "1", "案件イベント" },
					{ "2", "工程イベント" },
					{ "3", "通常イベント" },
				};
				EventComboSelectedIndex = 0;
				RaisePropertyChanged();
				MyView.FontSize = Constant.MyFontSize;
				this.taregetEvent = taregetEvent;
				//this.tEvents = tEvents;
				//this.tProject = tProject;
				dbMsg += "  ,案件= " + tEvents.t_project_base_id;

				EventWrite(taregetEvent, tEvents);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// イベント選択
		/// </summary>
		#region EventComboSelectedValueChanged
		private string _EventComboSelectedValue;

		public event ListChangedEventHandler ListChanged;

		public string EventComboSelectedValue {
			get {
				return _EventComboSelectedValue;
			}
			set {
				if (value == _EventComboSelectedValue)
					return;

				_EventComboSelectedValue = value;
				RaisePropertyChanged();
				if (value != null) {
					string msgStr = EventComboSource[value].ToString() + "が選択されました";
					//			MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);

					//		ReadTable(value);
				}
			}
		}
		#endregion

		/// <summary>
		/// 開始直後、対象イベントの設定内容を読取りViewを初期構成
		/// </summary>
		/// <param name="taregetEvent"></param>
		public void EventWrite(Google.Apis.Calendar.v3.Data.Event taregetEvent, t_events tEvents)
		{
			string TAG = "EventWrite";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += "HtmlLink=" + taregetEvent.HtmlLink;
				MyView.htmlLink_lb.Text = taregetEvent.HtmlLink;
				dbMsg += "taregetEvent=" + taregetEvent.Summary;
				MyView.titol_tv.Text = taregetEvent.Summary;
				SetDate(taregetEvent);
				SetDaylong(taregetEvent);
				if (taregetEvent.Location != null) {
					MyView.location_tb.Text = taregetEvent.Location;
				}

				SetColor(tEvents.event_bg_color);                             //taregetEvent.ColorId
				SetAttachments(taregetEvent.Attachments);
				SetDescription(taregetEvent);
				taregetEvent.Location = tEvents.event_place;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 開始・終了の日時設定
		/// </summary>
		/// <param name="taregetEvent"></param>
		private void SetDate(Google.Apis.Calendar.v3.Data.Event eventItem)
		{
			string TAG = "SetDate";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += "," + tEvents.event_date_start + " " + tEvents.event_time_start;
				TimeSpan nonTS = new TimeSpan(0, 0, 0);
				dbMsg += ",TimeSpan未設定=" + nonTS;
				DateTime now = DateTime.Now;
				DateTime originalSDT = GCalendarUtil.EventDateTime2DT(eventItem.OriginalStartTime);
				dbMsg += ",OriginalStartTime=" + originalSDT;
				if (now == originalSDT) {
					dbMsg += ">>現在時刻";
				}
				DateTime startDT = GCalendarUtil.EventDateTime2DT(eventItem.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(eventItem.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += "," + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				MyView.start_date_dp.SelectedDate = tEvents.event_date_start;
				int selectedHours = (int)tEvents.event_time_start;
				int selectedMinutes = 0;
				int selectedSeconds = 0;
				TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		MyView.start_time_tp.SetMyTimeSpan(selectedTime);
				dbMsg += "～" + tEvents.event_date_end + " " + tEvents.event_time_end;
				MyView.end_date_dp.SelectedDate = tEvents.event_date_end;
				selectedHours = (int)tEvents.event_time_end;
				selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		MyView.end_time_tp.SetMyTimeSpan(selectedTime);
				if (tEvents.event_is_daylong == true) {
					dbMsg += ">終日>";
					//MyView.start_time_tp.Visibility = System.Windows.Visibility.Hidden;
					//MyView.end_time_tp.Visibility = System.Windows.Visibility.Hidden;
				}
				if (startDTT == nonTS) {
					//start_time_tp.Visibility = System.Windows.Visibility.Hidden;
				}
				//MyView.end_time_tp.SetMyTimeSpan(endDTT);
				if (endDTT == nonTS) {
					//MyView.end_time_tp.Visibility = System.Windows.Visibility.Hidden;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 開始日変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Start_date_dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "Start_date_dp_SelectedDateChanged";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += ",元の設定：" + tEvents.event_date_start;
				DatePicker dp = sender as DatePicker;
				DateTime selectedDate = dp.SelectedDate.Value.Date;     //時刻は00:00
				tEvents.event_date_start = selectedDate;
				dbMsg += ">>" + tEvents.event_date_start;
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;

				string selectedDateStr = String.Format("{0:yyyy-MM-dd}", selectedDate);
				dbMsg += ",selected=" + selectedDateStr;
				string startDTStr = String.Format("{0:yyyy-MM-dd}", startDT);
				if (!selectedDateStr.Equals(startDTStr)) {
					dbMsg += ">>変更";
					if (MyView.daylong_cb.IsChecked.Value) {
						dbMsg += ">>終日";
						taregetEvent.Start.Date = selectedDateStr;
					} else {
						selectedDate = selectedDate.Add(startDTT);
						dbMsg += ",登録＝" + selectedDate;
						taregetEvent.Start.DateTime = selectedDate;
						taregetEvent.Start.Date = null;                     //終日ではない事のフラグ
					}
				}
				if (taregetEvent.OriginalStartTime.DateTime == null) {
					taregetEvent.OriginalStartTime.DateTime = taregetEvent.Start.DateTime;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 開始時刻変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// 
		//private void Start_time_tp_SelectedTimeChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	string TAG = "Start_time_tp_SelectedTimeChanged";
		//	string dbMsg = "[GEventEdit]";
		//	try {
		//		dbMsg += ",元の設定：" + tEvents.event_time_start;
		//		DatePicker dp = sender as DatePicker;
		//		MyView.TimePic tp = sender as TimePic;
		//		TimeSpan selectedTS = tp.selectedTS;
		//		int selectedHours = selectedTS.Hours;
		//		int selectedMinutes = selectedTS.Minutes;
		//		int selectedSeconds = selectedTS.Seconds;
		//		TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		dbMsg += ",開始時刻=" + selectedTime;
		//		tEvents.event_time_start = (int)selectedHours;
		//		dbMsg += ">>" + tEvents.event_time_start;
		//		DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
		//		TimeSpan startDTT = startDT.TimeOfDay;
		//		DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
		//		TimeSpan endDTT = endDT.TimeOfDay;
		//		dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
		//		TimeSpan duration = endDT - startDT;
		//		dbMsg += ",所要時間=" + duration;

		//		//TimePic tp = sender as TimePic;
		//		//TimeSpan selectedTS = tp.selectedTS;
		//		//int selectedHours = selectedTS.Hours;
		//		//int selectedMinutes = selectedTS.Minutes;
		//		//int selectedSeconds = selectedTS.Seconds;
		//		//TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		//dbMsg += ",開始時刻=" + selectedTime;
		//		//if (!selectedTime.Equals(startDTT)) {
		//		//	DateTime startDTDate = startDT.Date;
		//		//	dbMsg += ",startDTDate=" + startDTDate;
		//		//	startDT = startDTDate.Add(selectedTime);
		//		//	dbMsg += ">登録>" + startDT;
		//		taregetEvent.Start.DateTime = startDT;
		//		//	//終了側の変更
		//		//	//taregetEvent.End.DateTime = startDT.Add(duration);
		//		//	//dbMsg += ">end>" + taregetEvent.End.DateTime;
		//		//	//end_time_tp.SelectedTime = taregetEvent.End.DateTime.Value.TimeOfDay;
		//		//	//end_date_dp.SelectedDate = taregetEvent.End.DateTime.Value.Date;
		//		taregetEvent.Start.Date = null;                     //終日ではない事のフラグ
		//															//}
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}

		/// <summary>
		/// 終了時刻変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void End_time_tp_SelectedTimeChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	string TAG = "End_time_tp_SelectedTimeChanged";
		//	string dbMsg = "[GEventEdit]";
		//	try {
		//		dbMsg += ",元の設定：" + tEvents.event_time_end;
		//		DatePicker dp = sender as DatePicker;
		//		TimePic tp = sender as TimePic;
		//		TimeSpan selectedTS = tp.selectedTS;
		//		int selectedHours = selectedTS.Hours;
		//		int selectedMinutes = selectedTS.Minutes;
		//		int selectedSeconds = selectedTS.Seconds;
		//		TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		dbMsg += ",開始時刻=" + selectedTime;
		//		tEvents.event_time_end = (int)selectedHours;
		//		dbMsg += ">>" + tEvents.event_time_end;
		//		DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
		//		TimeSpan startDTT = startDT.TimeOfDay;
		//		DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
		//		TimeSpan endDTT = endDT.TimeOfDay;
		//		dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
		//		TimeSpan duration = endDT - startDT;
		//		dbMsg += ",所要時間=" + duration;

		//		//TimePic tp = sender as TimePic;
		//		//TimeSpan selectedTS = tp.selectedTS;
		//		//int selectedHours = selectedTS.Hours;
		//		//int selectedMinutes = selectedTS.Minutes;
		//		//int selectedSeconds = selectedTS.Seconds;
		//		//TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
		//		dbMsg += ",終了時刻=" + selectedTime;
		//		if (!selectedTime.Equals(endDTT)) {
		//			DateTime endDTDate = endDT.Date;
		//			dbMsg += ",endDTDate=" + endDTDate;
		//			endDT = endDTDate.Add(selectedTime);
		//			dbMsg += ">登録>" + endDT;
		//			taregetEvent.End.DateTime = endDT;
		//			//終了側の変更
		//			//taregetEvent.End.DateTime = startDT.Add(duration);
		//			//dbMsg += ">end>" + taregetEvent.End.DateTime;
		//			//end_time_tp.SelectedTime = taregetEvent.End.DateTime.Value.TimeOfDay;
		//			//end_date_dp.SelectedDate = taregetEvent.End.DateTime.Value.Date;
		//			taregetEvent.End.Date = null;                     //終日ではない事のフラグ
		//		}
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}

		/// <summary>
		/// 終了日変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void End_date_dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "End_date_dp_SelectedDateChanged";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += ",元の設定：" + tEvents.event_date_end;
				DatePicker dp = sender as DatePicker;
				DateTime selectedDate = dp.SelectedDate.Value.Date;     //時刻は00:00
				tEvents.event_date_end = selectedDate;
				dbMsg += ">>" + tEvents.event_date_end;

				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;

				//datepicker dp = sender as datepicker;
				//datetime selecteddate = dp.selecteddate.value.date;     //時刻は00:00
				//string selecteddatestr = string.format("{0:yyyy-mm-dd}", selecteddate);
				//dbmsg += ",終了日=" + selecteddatestr;
				//string startdtstr = string.format("{0:yyyy-mm-dd}", startdt);
				//if (!selecteddatestr.equals(startdtstr)) {
				//	dbmsg += ">>変更";
				//	if (daylong_cb.ischecked.value) {
				//		dbmsg += ">>終日";
				//		taregetevent.end.date = selecteddatestr;
				//	} else {
				//		selecteddate = selecteddate.add(enddtt);
				//		dbmsg += ",登録＝" + selecteddate;
				//taregetevent.end.datetime = selecteddate;
				//		taregetevent.end.date = null;                     //終日ではない事のフラグ
				//	}
				//	//int endint = gcalendarutil.eventdatetime2int(taregetevent.end);
				//	//int startint =gcalendarutil.eventdatetime2int(taregetevent.start);
				//	//if (endint < startint) {
				//	//	dbmsg += ">終了日以降になっている>";
				//	//	taregetevent.start.datetime = selecteddate.add(-duration);
				//	//	dbmsg += taregetevent.start.datetime;
				//	//	start_date_dp.selecteddate = taregetevent.start.datetime.value.date;
				//	//}
				//	}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 終日
		/// </summary>
		/// <param name="eventItem"></param>
		private void SetDaylong(Google.Apis.Calendar.v3.Data.Event taregetEvent)
		{
			string TAG = "SetDate";
			string dbMsg = "[GEventEdit]";
			try {
				string startDate = taregetEvent.Start.Date;
				if (startDate != null) {
					dbMsg += "startDate=" + startDate;
					MyView.daylong_cb.IsChecked = true;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 終日の選択変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Daylong_cb_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Daylong_cb_Checked";
			string dbMsg = "[GEventEdit]";
			try {
				TimeSpan nonTS = new TimeSpan(0, 0, 0);
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;

				CheckBox cb = sender as CheckBox;
				bool isChecked = cb.IsChecked.Value;
				dbMsg += "IsChecked=" + isChecked;
				tEvents.event_is_daylong = isChecked;

				if (isChecked) {
					//		//trueからfaleseに変わったらDateを記入
					dbMsg += ">終日>";
					//	tEvents.event_is_daylong = true;
					string StartDTStr = String.Format("{0:yyyy-MM-dd}", startDT);
					taregetEvent.Start.Date = StartDTStr;
					taregetEvent.Start.DateTime = null;
					dbMsg += "開始=" + StartDTStr + "(" + GCalendarUtil.EventDateTime2DT(taregetEvent.Start) + ")";
					string endDTStr = String.Format("{0:yyyy-MM-dd}", endDT);
					taregetEvent.End.Date = endDTStr;
					taregetEvent.End.DateTime = null;
					//MyView.start_time_tp.Visibility = System.Windows.Visibility.Hidden;
					//MyView.end_time_tp.Visibility = System.Windows.Visibility.Hidden;
				} else {
					//	tEvents.event_is_daylong = false;
					//		//aleseからtruefに変わったらDateTimeを記入
					dbMsg += ">時刻指定>" + tEvents.event_time_start + "～" + tEvents.event_time_end;
					taregetEvent.Start.Date = null;
					if (startDTT == nonTS) {
						DateTime nowDT = DateTime.Now;
						TimeSpan nowDTT = nowDT.TimeOfDay;
						startDT = startDT.Add(nowDTT);
						dbMsg += ">>" + startDT;
					}
					taregetEvent.Start.DateTime = startDT;
					dbMsg += "開始=" + GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
					taregetEvent.End.Date = null;
					if (nonTS < duration) {
						endDT = startDT.Add(duration);
					} else {
						endDT = startDT.Add(new TimeSpan(1, 0, 0));
					}
					taregetEvent.End.DateTime = endDT;
					dbMsg += "～終了=" + GCalendarUtil.EventDateTime2DT(taregetEvent.End);
					//start_time_tp.Visibility = System.Windows.Visibility.Visible;
					//end_time_tp.Visibility = System.Windows.Visibility.Visible;
					startDTT = startDT.TimeOfDay;
					//start_time_tp.SetMyTimeSpan(startDTT);
					endDTT = endDT.TimeOfDay;
					//end_time_tp.SetMyTimeSpan(endDTT);
				}
				MyView.start_date_dp.SelectedDate = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				MyView.end_date_dp.SelectedDate = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// カラー設定
		/// </summary>
		/// <param name="colorID"></param>
		private void SetColor(string colorID)
		{
			string TAG = "SetColor";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += "colorID=" + colorID;
				if (colorID == null) {
					colorID = "7";
				}
				if (Constant.googleEventColor == null) {
					GCalendarUtil.setGoogleEventColor();
					dbMsg += ">>" + colorID;
				}
				dbMsg += "googleEventColor=" + Constant.googleEventColor.Count + "色";
				Constant.GoogleEventColor colorInfo = Constant.googleEventColor[int.Parse(colorID)];
				//		Color_lb.Foreground = new SolidColorBrush(colorInfo.rgb);
				int serectIndex = 0;
				int nowCount = 0;
				foreach (Constant.GoogleEventColor color in Constant.googleEventColor) {
					dbMsg += "\r\n" + color.id + ")" + color.name + "," + color.rgb;
					//ファイルの表示名color情報をラベルに格納して
					Label lb = new Label();
					lb.Content = color.name;
					lb.Background = new SolidColorBrush(color.rgb);
					lb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
					lb.DataContext = color;
					//規定色をリストアイテムに格納
					MyView.color_cb.Items.Add(lb);
					if (color.id.Equals(colorID)) {
						//指定されたインデックスと一致したらコンボボックス上のインデックスを記録し
						serectIndex = nowCount;
						//タイトル入力枠に着色
						MyView.titol_tv.Background = new SolidColorBrush(color.rgb);
						MyView.color_cb.Background = new SolidColorBrush(color.rgb);
					}
					nowCount++;
				}
				Label lbe = new Label();
				lbe.Content = "その他...";
				//規定色をリストアイテムに格納
				MyView.color_cb.Items.Add(lbe);

				dbMsg += ",serectIndex=" + serectIndex;
				MyView.color_cb.SelectedIndex = serectIndex;

				if (serectIndex == 0) {      //規定色でなく
					if (colorID.Contains('#')) {      //カラーコード指定なら：https://www.ipentec.com/document/csharp-htmlcolor-to-color
						System.Drawing.Color ccolor = System.Drawing.ColorTranslator.FromHtml(colorID);
						MyView.titol_tv.Background = new SolidColorBrush(Color.FromRgb(ccolor.R, ccolor.G, ccolor.B));
						taregetEvent.ColorId = "6";
					} else {
						taregetEvent.ColorId = colorID;
					}
				}
				MyView.titol_tv.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// カラー選択後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Color_cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "Color_cb_SelectionChanged";
			string dbMsg = "[GEventEdit]";
			try {
				//※　作成時も発生する
				dbMsg += ",event_bg_color=" + tEvents.event_bg_color;

				ComboBox cb = sender as ComboBox;
				int serectIndex = cb.SelectedIndex;
				dbMsg += ",serectIndex=" + serectIndex;
				//Label selectedItem = cb.SelectedItem as Label;
				//Constant.GoogleEventColor colorObj = new Constant.GoogleEventColor();
				//colorObj = selectedItem.DataContext;
				Constant.GoogleEventColor color = Constant.googleEventColor[serectIndex];
				dbMsg += "," + color.id + ")" + color.name + "," + color.rgb;
				//	System.Drawing.Color ccolor = System.Drawing.ColorTranslator.FromHtml(colorID);
				MyView.titol_tv.Background = new SolidColorBrush(color.rgb);
				if (serectIndex < cb.Items.Count) {              //
					tEvents.event_bg_color = (serectIndex + 1).ToString();
				} else {
					tEvents.event_bg_color = (color.rgb).ToString();
				}
				dbMsg += ">>" + tEvents.event_bg_color;
				//if(taregetEvent != null) {
				//	if (!taregetEvent.ColorId.Equals(color.id)) {
				//		//			color_cb.Background = new SolidColorBrush(color.rgb);
				//		taregetEvent.ColorId = color.id;
				//	}
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}

		/// <summary>
		/// 渡されたイベントのDescriptionを各フィールドに切り分ける
		/// </summary>
		/// <param name="taregetEvent"></param>
		private void SetDescription(Google.Apis.Calendar.v3.Data.Event taregetEvent)
		{
			string TAG = "SetDescription";
			string dbMsg = "[GEventEdit]";
			try {
				//MyView.order_tb.Text = tProject.order_number;                                                          //受注No
				//MyView.management_number_tb.Text = tProject.management_number;                    //管理番号
				//MyView.customer_tb.Text = tProject.supplier_name;                                              //得意先
				MyView.memo_tb.Text = tEvents.event_memo;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Momo_tb_LostFocus(object sender, RoutedEventArgs e)
		{
			string TAG = "Momo_tb_LostFocus";
			string dbMsg = "[GEventEdit]";
			try {
				MyLog(TAG, dbMsg);
				WriteDescription();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 登録するDescriptionの作成
		/// </summary>
		private void WriteDescription()
		{
			string TAG = "WriteDescription";
			string dbMsg = "[GEventEdit]";
			try {
				string description = "<table><tbody>";
				description += "<tr><td>受注No</td>" + "<td> : " + MyView.order_tb.Text + "</td></tr>";
				description += "<tr><td>管理番号</td>" + "<td> : " + MyView.management_number_tb.Text + "</td></tr>";
				description += "<tr><td>得意先</td>" + "<td> : " + MyView.customer_tb.Text + "</td></tr>";
				description += "</tbody ></table><br>";         //<pre>" + momo_tb.Text+ "</pre>";
				dbMsg += ",description=" + description;
				this.taregetEvent.Description = description;
				string htmlStr = @"<html lang=""jp"" xmlns =""http://www.w3.org/1999/xhtml"">";
				htmlStr += @"<head><meta charset=""utf-8"" /><title></title></head><body>";
				htmlStr += @description;
				htmlStr += "</body></html>";
				//		description_wb.NavigateToString(htmlStr);

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ファイルのドロップ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Attachments_sp_Drop(object sender, DragEventArgs e)
		{
			string TAG = "Attachments_sp_Drop";
			string dbMsg = "[GEventEdit]";
			try {
				if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
					Controls.WaitingDLog progressWindow = new Controls.WaitingDLog();
					progressWindow.Show();

					Constant.GDriveFiles = new List<Google.Apis.Drive.v3.Data.File>();
					Constant.GDriveFiles = GDriveUtil.GDAllFolderListUp();
					int fCount = Constant.GDriveFiles.Count;
					dbMsg += " , " + fCount + " フォルダ登録";
					if (0 < fCount) {
						dbMsg += "[" + Constant.GDriveFiles.First().Id + " ]" + Constant.GDriveFiles.First().Name + " ;Parents;" + Constant.GDriveFiles.First().Parents[0] + " ;DriveId;" + Constant.GDriveFiles.First().DriveId;
						dbMsg += "～[" + Constant.GDriveFiles.Last().Id + " ]" + Constant.GDriveFiles.Last().Name + " ;Parents;" + Constant.GDriveFiles.First().Parents[0] + " ;DriveId;" + Constant.GDriveFiles.First().DriveId;
					}
					//仮処理；最初に拾えたファイルのParentsをdriveIdとする
					Constant.DriveId = Constant.GDriveFiles.First().Parents[0];
					Task<File> rootRes = Task<File>.Run(() => {
						dbMsg += "  ,ルート= " + Constant.RootFolderName;
						return GDriveUtil.CreateFolder(Constant.RootFolderName, Constant.DriveId);
					});
					rootRes.Wait();
					string rootFolderId = rootRes.Result.Id;
					dbMsg += "[" + rootFolderId + "] ";
					Task<File> topRes = Task<File>.Run(() => {
						dbMsg += ",top=" + Constant.AriadneEventAnken;
						return GDriveUtil.CreateFolder(Constant.AriadneEventAnken, rootFolderId);
					});
					topRes.Wait();
					string topFolderId = topRes.Result.Id;
					dbMsg += "[" + topFolderId + "] ";

					//			dbMsg += "  、イベント：案件[" + Constant.AriadneAnkenFolderId + "] に ";
					Task<File> rr = Task<File>.Run(() => {
						tProject = new t_project_bases();
						dbMsg += "  ,案件= " + tProject.project_manage_code;
						return GDriveUtil.CreateFolder(tProject.project_manage_code, topFolderId);
					});
					rr.Wait();
					//Task.WaitAll(rootRes,topRes, rr);
					string itemFolderId = rr.Result.Id;
					dbMsg += "[ " + itemFolderId + "]を作成";              //出来ていない
																		// Note that you can have more than one file.
					string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
					var file = files[0];
					string rFile = file.ToString();
					dbMsg += "  ,rFile= " + rFile;
					dbMsg += "  ,file= " + file.ToString();
					string[] strs = rFile.Split('\\');
					string name = strs[strs.Length - 1];
					dbMsg += ",name=" + name;
					string parent = strs[strs.Length - 2];
					dbMsg += ",parent=" + parent;
					//直上のフォルダ
					rr = Task<string>.Run(() => {
						return GDriveUtil.CreateFolder(parent, itemFolderId);
					});
					rr.Wait();
					string parentFolderId = rr.Result.Id;
					dbMsg += "[ " + parentFolderId + "]";
					string fileId = PutInFoldrFile(rFile, itemFolderId, taregetEvent);

					dbMsg += ">>作成= " + fileId;
					Google.Apis.Drive.v3.Data.File fileItem = GDriveUtil.FindByNameParent(name, parent);
					if (fileItem == null) {
						dbMsg += "登録なし";
					} else {
						string gFileId = fileItem.Id;
						dbMsg += "[" + gFileId + "]";
					}
					AttachmentsFromDrive(fileItem);
					progressWindow.Close();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ファイルのドロップ領域のクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Attachments_sp_MouseUp(object sender, MouseButtonEventArgs e)
		{
			string TAG = "Attachments_sp_MouseUp";
			string dbMsg = "[GEventEdit]";
			try {
				//		ShowDriveBrouser();
				ShowGoogleDrive();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}

		/// <summary>
		/// WebViewでGoogleドライブを開く
		/// </summary>
		private void ShowGoogleDrive()
		{
			string TAG = "ShowGoogleDrive";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += ". " + Constant.RootFolderURL;
				string DriveURL = Constant.RootFolderURL;
				dbMsg += "DriveURL=" + DriveURL;
				//if (webWindow == null) {
				//	dbMsg += "webでGoogleDriveを表示";
				//	webWindow = new WebWindow();
				//	webWindow.eventEdit = this;
				//	webWindow.Show();
				//	webWindow.SetMyURL(new Uri(@DriveURL));
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// XAMLのDriveBrouserを表示
		/// </summary>
		private void ShowDriveBrouser()
		{
			string TAG = "ShowDriveBrouser";
			string dbMsg = "[GEventEdit]";
			try {
				//if (driveView == null) {
				//	dbMsg += "GoogleDriveBrouserを再生成";
				//	driveView = new GoogleDriveBrouser();
				//	driveView.editView = this;
				//	driveView.Show();
				//	//	driveView.GoogleFolderListUp(Constant.TopFolderName);
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// 添付ファイル配列の書き写し
		/// </summary>
		/// <param name="attachments"></param>
		private void SetAttachments(IList<Google.Apis.Calendar.v3.Data.EventAttachment> attachments)
		{
			string TAG = "SetAttachments";
			string dbMsg = "[GEventEdit]";
			try {
				//attachmentDataCollection = new AttachmentDataCollection();
				//if (attachments != null) {
				//	dbMsg += ",Attachments" + attachments.Count + "件";
				//	if (0 < attachments.Count) {
				//		Controls.WaitingDLog progressWindow = new Controls.WaitingDLog();
				//		progressWindow.Show();
				//		//Task.Run(() => {

				//		foreach (Google.Apis.Calendar.v3.Data.EventAttachment attachment in attachments) {
				//			dbMsg += ",Title=" + attachment.Title;
				//			//				progressWindow.Dispatcher.Invoke(new Action(() => progressWindow.SetMsg(attachment.Title)));
				//			AddAttachmentst(attachment);
				//		}
				//		//}).ContinueWith(task => {
				//		progressWindow.Close();
				//		//}, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
				//	}
				//}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付ファイルの選択
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Attachments_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "Attachments_SelectionChanged";
			string dbMsg = "[GEventEdit]";
			try {
				//var selectedData = this.Attachments_dg.SelectedItem as AttachmentData;
				//if (selectedData == null) {
				//	dbMsg += "データ取得失敗";
				//} else {
				//	dbMsg += ",Title=" + selectedData.Title;
				//	dbMsg += ",FileId= " + selectedData.FileId;
				//	dbMsg += ",FileUrl= " + selectedData.FileUrl;
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付解除ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Release_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Release_Click";
			string dbMsg = "[GEventEdit]";
			try {
				//var selectedData = this.Attachments_dg.SelectedItem as AttachmentData;
				//if (selectedData == null) {
				//	dbMsg += "データ取得失敗";
				//} else {
				//	dbMsg += ",Title=" + selectedData.Title;
				//	string delFileId = selectedData.FileId;
				//	dbMsg += ",FileId= " + delFileId;
				//	dbMsg += ",FileUrl= " + selectedData.FileUrl;
				//	int delIndex = AttachmentRelease(delFileId, false);
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void RemoveAt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "RemoveAt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				//var selectedData = this.Attachments_dg.SelectedItem as AttachmentData;
				//if (selectedData == null) {
				//	dbMsg += "データ取得失敗";
				//} else {
				//	dbMsg += ",Title=" + selectedData.Title;
				//	string delFileId = selectedData.FileId;
				//	dbMsg += ",FileId= " + delFileId;
				//	dbMsg += ",FileUrl= " + selectedData.FileUrl;
				//	int delIndex = AttachmentRelease(delFileId, true);
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付ファイルの解除処理
		/// </summary>
		/// <param name="delFileId">解除対象</param>
		/// <param name="isDel">削除</param>
		private int AttachmentRelease(string delFileId, bool isDel)
		{
			string TAG = "AttachmentRelease";
			string dbMsg = "[GEventEdit]";
			int delIndex = -1;
			try {
				////string delFileId = delAttachment.FileId;
				////dbMsg += "  ,Del;Title=" + delAttachment.Title + "  ,Id=" + delAttachment.FileId;
				//dbMsg += "  ,Id=" + delFileId + ")";
				//IList<Google.Apis.Calendar.v3.Data.EventAttachment> attachments = this.taregetEvent.Attachments;
				//dbMsg += "Attachments" + attachments.Count + "件";
				//string title = "";
				//if (-1 < attachmentDataCollection.Count) {
				//	delIndex = 0;
				//	foreach (AttachmentData attachment in attachmentDataCollection) {
				//		title = attachment.Title;
				//		string fileId = attachment.FileId;
				//		dbMsg += "\r\n" + delIndex + ")" + title + ",fileId=" + fileId;
				//		if (fileId.Equals(delFileId)) {
				//			break;
				//		}
				//		delIndex++;
				//	}
				//	dbMsg += ",delIndex=" + delIndex;
				//	attachmentDataCollection.RemoveAt(delIndex);
				//	dbMsg += ">削除：添付>" + attachmentDataCollection.Count + "件";
				//}
				//this.Attachments_dg.Items.Refresh();
				//int cCount = attachmentDataCollection.Count;
				//if (isDel) {
				//	String titolStr = Constant.ApplicationName;
				//	String msgStr = title + "を削除しますか？：";
				//	MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
				//	dbMsg += ",result=" + result;
				//	if (result == MessageBoxResult.Yes) {

				//	}
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
			return delIndex;
		}

		/// <summary>
		/// GoogleDriveで選択したファイルを添付する
		/// ①PutItemEventFile
		/// ②GoogleDriveBrouser.File_list_lv_MouseDoubleClickでファイルだった場合
		/// </summary>
		/// <param name="fileItem"></param>
		public void AttachmentsFromDrive(Google.Apis.Drive.v3.Data.File fileItem)
		{
			string TAG = "AttachmentsFromDrive";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += ",[fileId=" + fileItem.Id + "]";
				foreach (Google.Apis.Calendar.v3.Data.EventAttachment cf in taregetEvent.Attachments) {
					if (cf.FileId.Equals(fileItem.Id)) {
						return;
					}
				}
				Google.Apis.Calendar.v3.Data.EventAttachment attachment = new Google.Apis.Calendar.v3.Data.EventAttachment();
				attachment.Title = fileItem.Name;
				dbMsg += "," + attachment.Title;
				attachment.FileId = fileItem.Id;
				dbMsg += ",fileUrl= " + attachment.FileUrl;
				if (fileItem.WebContentLink != null) {
					attachment.FileUrl = fileItem.WebContentLink;
				} else {
					//プレビューwebへ
					attachment.FileUrl = @"https://drive.google.com/file/d/" + fileItem.Id + "/view?usp=drive_web";
					dbMsg += ">>" + attachment.FileUrl;
				}
				attachment.ETag = fileItem.ETag;
				dbMsg += ",eTag= " + attachment.ETag;

				dbMsg += "  ,mimeType=" + fileItem.MimeType;
				if (fileItem.IconLink != null) {
					attachment.MimeType = fileItem.MimeType;
				} else {
					if (attachment.Title.Contains(".xls")) {
						attachment.MimeType = @"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					} else if (attachment.Title.Contains(".doc")) {
						attachment.MimeType = @"application/vnd.openxmlformats-officedocument.wordprocessingml.document";
					} else if (attachment.Title.Contains(".ppt")) {
						attachment.MimeType = @"application/vnd.openxmlformats-officedocument.presentationml.presentation";
					} else if (attachment.Title.Contains(".pdf")) {
						attachment.MimeType = @"application/pdf";
					}
					dbMsg += ">>" + attachment.MimeType;
				}

				dbMsg += "  ,iconLink= " + fileItem.IconLink;
				if (fileItem.IconLink != null) {
					attachment.IconLink = fileItem.IconLink;
				} else {
					attachment.IconLink = @"https://ssl.gstatic.com/docs/doclist/images/icon_10_generic_list.png";
					if (attachment.Title.Contains(".xls")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
					} else if (attachment.Title.Contains(".doc")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/vnd.openxmlformats-officedocument.wordprocessingml.document";
					} else if (attachment.Title.Contains(".ppt")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/vnd.openxmlformats-officedocument.presentationml.presentation";
					} else if (attachment.Title.Contains(".pdf")) {
						attachment.IconLink = @"https://drive-thirdparty.googleusercontent.com/16/type/application/pdf";
					}
					dbMsg += ">>" + attachment.IconLink;
				}
				dbMsg += "  ,attachments= " + this.taregetEvent.Attachments.Count + "件";
				taregetEvent.Attachments.Add(attachment);
				dbMsg += " >> " + taregetEvent.Attachments.Count + "件";
				MyLog(TAG, dbMsg);
				AddAttachmentst(attachment);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}



		/// <summary>
		/// 添付ファイルのリストアイテム化	（ボタン化）
		/// </summary>
		/// <param name="attachment"></param>
		private void AddAttachmentst(Google.Apis.Calendar.v3.Data.EventAttachment attachment)
		{
			string TAG = "AddAttachmentst";
			string dbMsg = "[GEventEdit]";
			try {
				//string title = attachment.Title;
				//string fileId = attachment.FileId;
				//string fileUrl = attachment.FileUrl;
				//dbMsg += "," + title + ",fileId=" + fileId + ",fileUrl= " + fileUrl;
				//string mimeType = attachment.MimeType;
				//string eTag = attachment.ETag;
				//dbMsg += "  ,mimeType=" + mimeType + ",eTag= " + eTag;

				//if (attachmentDataCollection.Count < 1) {
				//	dbMsg += "  ,作成";
				//	attachmentDataCollection = new AttachmentDataCollection();
				//}
				//AttachmentData attachmentData = new AttachmentData();
				//attachmentData.Title = title;
				//attachmentData.FileId = fileId;
				//attachmentData.FileUrl = fileUrl;
				//attachmentData.MimeType = mimeType;
				//attachmentData.IconLink = attachment.IconLink;
				//attachmentData.ETag = attachment.ETag;

				////var queries = new List<string>() { $"id = '{ fileId }'" };           //	 , $"id = '{ fileId }'"
				////Task<File> rr = Task<File>.Run(() => {
				////		//SearchFilter filter = SearchFilter.NONE;
				////		//queries.Add(filter.ToQuery());
				////		return GoogleDriveUtil.FindFile(queries);
				////});
				////rr.Wait();
				////if (rr != null) {
				////		File fInfo = rr.Result;
				//File fInfo = GDriveUtil.FindById(fileId);
				//if (fInfo != null) {
				//	dbMsg += "  ,ModifiedTime=" + fInfo.ModifiedTime;
				//	attachmentData.Modifi = String.Format("{0:yyyy/MM/dd hh:mm}", fInfo.ModifiedTime);
				//	dbMsg += "  >>" + attachmentData.Modifi;
				//	long? fSIze = fInfo.Size;
				//	dbMsg += "  ,fSIze=" + fSIze;
				//	attachmentData.Size = fSIze + "KB";
				//	if (0 < fSIze) {
				//		attachmentData.Size = Math.Round(double.Parse(fSIze.ToString()) / 1000, 3) + "KB";
				//	} else if (999 < fSIze) {
				//		attachmentData.Size = Math.Round(double.Parse(fSIze.ToString()) / 1000, 0) + "KB";
				//	} else if (999999 < fSIze) {
				//		attachmentData.Size = Math.Round(double.Parse(fSIze.ToString()) / 1000000, 0) + "MB";
				//	}
				//}
				////	}
				//attachmentDataCollection.Add(attachmentData);

				//// データをそのままセットする
				//this.Attachments_dg.DataContext = attachmentDataCollection;
				////更新時はこれが必須
				//this.Attachments_dg.Items.Refresh();

				//int cCount = attachmentDataCollection.Count;
				//attachments_count_lb.Content = cCount.ToString();

				/*			
							//親になるパネルを作る
							StackPanel psp = new StackPanel();
							psp.Orientation = Orientation.Horizontal;
							psp.Margin = new Thickness(-5);

							//ボタンに見える部分
							Button bt = new Button();
							bt.Click += Attachment_bt_Click;
							bt.DataContext = fileUrl;
							bt.Style = FindResource("bt-attachment") as System.Windows.Style;
							//横並べ
							StackPanel sp = new StackPanel();
							sp.Orientation = Orientation.Horizontal;
							sp.Margin = new Thickness(-5);
							//アイコン
							string iconLink = attachment.IconLink;
							dbMsg += "  ,iconLink= " + iconLink;
							Image img = new Image();
							img.Source = new BitmapImage(new Uri("Resources/file.png", UriKind.Relative));
							if (iconLink == null) {
								if(mimeType.Equals(Constant.GoogleDriveMime_Folder)) {
									img.Source = new BitmapImage(new Uri("Resources/folder.png", UriKind.Relative));
								}
							} else{
								img.Source = new BitmapImage(new Uri(iconLink));
							}
							img.Height = 10;
							img.Width = 10;
							sp.Children.Add(img);
							//ファイルの表示名
							Label lb = new Label();
							lb.Content = title;
							lb.Margin = new Thickness(-5);
							//格納
							sp.Children.Add(lb);
							bt.Content = sp;
							psp.Children.Add(bt);
							//削除ボタン
							Button dbt = new Button();
							dbt.Click += Del_Attachment_bt_Click;
							dbt.DataContext = attachment;
							dbt.Style = FindResource("bt-dell") as System.Windows.Style;
							psp.Children.Add(dbt);
							//XAMLへ格納;
						attachments_sp.Children.Add(psp);
						*/
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付ファイルボタンの解除ボタンのクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Del_Attachment_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Del_Attachment_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				Button bt = sender as Button;
				Google.Apis.Calendar.v3.Data.EventAttachment delAttachment = bt.DataContext as Google.Apis.Calendar.v3.Data.EventAttachment;
				string delFileId = delAttachment.FileId;
				dbMsg += "  ,Del;Title=" + delAttachment.Title + "  ,Id=" + delAttachment.FileId;
				int delIndex = AttachmentRelease(delFileId, false);
				if (0 < delIndex) {
					////	//添付表示も削除
					//attachments_sp.Children.RemoveAt(delIndex);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// 添付ファイルの取得処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Attachment_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Attachment_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				Button bt = sender as Button;
				string taregetUrl = bt.DataContext as string;
				dbMsg += "  ,taregetUrl=" + taregetUrl;
				//デフォルトのブラウザで開く
				System.Diagnostics.Process.Start(taregetUrl);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// 添付ボタンのクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Attach_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Attach_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				ShowDriveBrouser();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 保存ボタンクリック
		/// 案件に関連するファイルを一通りGoogleDriveへ登録する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Save_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Save_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += ",元の設定：" + tEvents.event_date_start + "(" + tEvents.event_time_start + ")～" + tEvents.event_date_end + "(" + tEvents.event_time_end + ")[" + tEvents.event_is_daylong + "]";

				DateTime endDT = new DateTime(tEvents.event_date_end.Year, tEvents.event_date_end.Month, tEvents.event_date_end.Day, (int)tEvents.event_time_end, 0, 0);          //GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				DateTime startDT = new DateTime(tEvents.event_date_start.Year, tEvents.event_date_start.Month, tEvents.event_date_start.Day, (int)tEvents.event_time_start, 0, 0);          // GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				dbMsg += ",>>：" + startDT + "～" + endDT;
				//long endLong = GCalendarUtil.EventDateTime2Long(taregetEvent.End);
				//long starLong = GCalendarUtil.EventDateTime2Long(taregetEvent.Start);
				if (endDT < startDT) {
					dbMsg += ">終了日以降になっている>";
					TimeSpan startDTT = startDT.TimeOfDay;
					TimeSpan endDTT = endDT.TimeOfDay;
					dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
					String titolStr = Constant.ApplicationName;
					String msgStr = "	開始：" + startDT;
					msgStr += "	\r\n終了：" + endDT;
					msgStr += "	開始日時が終了日時以降に設定されています。\r\n修正して下さい。";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
					return;
				}
				string retLink = "";
				string parentFolderName = tProject.project_manage_code;             // this.selectedAriadneData.ItemNumber;
																					//案件などAriadneEventfフォルダ直下に案件別フォルダを作成もしくは既存IDの取得
				string itermFolderName = tProject.project_manage_code;                  //this.selectedAriadneData.ItemNumber;
				Task<File> rr = Task<File>.Run(() => {
					return GDriveUtil.CreateFolder(itermFolderName, Constant.AriadneAnkenFolderId);
				});
				rr.Wait();
				string itemFolderId = rr.Result.Id;
				dbMsg += ",案件直下の案件名フォルダ[" + itemFolderId + "]";
				rr = System.Threading.Tasks.Task.Run(() => {
					return GDriveUtil.CreateFolder(itermFolderName, Constant.AriadneKouteiFolderId);
				});
				rr.Wait();
				string processFolderId = rr.Result.Id;
				dbMsg += ",工程名フォルダ[" + processFolderId + "]";
				rr = Task.Run(() => {
					return GDriveUtil.CreateFolder(itermFolderName, Constant.AriadneOtherFolderId);
				});
				rr.Wait();
				string otherFolderId = rr.Result.Id;
				dbMsg += ",一般名フォルダ[" + otherFolderId + "]";



				retLink = GCalendarUtil.AddEventInfo(taregetEvent, this.tEvents);
				dbMsg += ",retLink=" + retLink;
				//イベントテーブルに書き込み/////////////////////////////////////////////////////////////////////////////////////// retLink != null||
				if (!retLink.Equals("")) {
					string[] delimiter = { "eid=" };
					string[] idStrs = retLink.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
					string prefix = idStrs[0];
					string suffix = idStrs[1];
					tEvents.google_id = suffix;
				}
				tEvents.updated_at = DateTime.Now;

				//using (var context = new EventEntities()) {
				//	// Addした段階ではSql文はDBに発行されない
				//	dbMsg += ",：" + tEvents.event_date_start + "(" + tEvents.event_time_start + ")～" + tEvents.event_date_end + "(" + tEvents.event_time_end + ")" + tEvents.event_title;
				//	dbMsg += ",google_id=" + tEvents.google_id + " ,modifier_on=" + tEvents.modifier_on;
				//	context.t_events.Add(tEvents);
				//	// SaveChangesが呼び出された段階で初めてInsert文が発行される
				//	context.SaveChanges();
				//}
				dbMsg += ",ConnectionString=" + Constant.ConnectionString;
				using (MySqlConnection mySqlConnection = new MySqlConnection(Constant.ConnectionString)) {
					// コマンドを作成
					MySqlCommand cmd = new MySqlCommand("insert into t_events values (" +
														"@m_contract_id,@t_project_base_id,@event_type,@event_date_start,@event_time_start,@event_date_end,@event_time_end,@event_is_daylong," +
														"@event_title,@event_place,@event_memo,@event_status,@google_id,@event_bg_color,@event_font_color,@modifier_on" +
												 ")", mySqlConnection);
					//MySqlCommand cmd = new MySqlCommand("insert into t_event (m_contract_id,t_project_base_id,event_type,event_date_start,event_time_start,event_date_end,event_time_end," +
					//									"event_is_daylong,event_title,event_place,event_memo,event_status,google_id,event_bg_color,event_font_color,modifier_on" +
					//									") values (" +
					//									"@m_contract_id,@t_project_base_id,@event_type,@event_date_start,@event_time_start,@event_date_end,@event_time_end," +
					//									"@event_is_daylong,@event_title,@event_place,@event_memo,@event_status,@google_id,@event_bg_color,@event_font_color,@modifier_on" +
					//							 ")", mySqlConnection);
					// パラメータ設定
					//;MySql.Data.MySqlClient.MySqlException (0x80004005): Column count doesn't match value count at row 1
					//指定したテーブル内のカラム数とそれに与えるVALUEの数が一致しない
					//tEvents.event_time_end = 0;
					//tEvents.event_is_daylong = true;
					//dbMsg += ",event_time_end=" + tEvents.event_time_end + " ,_is_daylong=" + tEvents.event_is_daylong;
					cmd.Parameters.Add(new MySqlParameter("@m_contract_id", tEvents.m_contract_id));
					cmd.Parameters.Add(new MySqlParameter("@t_project_base_id", tEvents.t_project_base_id));
					cmd.Parameters.Add(new MySqlParameter("@event_type", tEvents.event_type));
					cmd.Parameters.Add(new MySqlParameter("@event_date_start", tEvents.event_date_start));
					cmd.Parameters.Add(new MySqlParameter("@event_time_start", tEvents.event_time_start));
					cmd.Parameters.Add(new MySqlParameter("@event_date_end", tEvents.event_date_end));
					cmd.Parameters.Add(new MySqlParameter("@event_time_end", tEvents.event_time_end));
					cmd.Parameters.Add(new MySqlParameter("@event_is_daylong", tEvents.event_is_daylong));
					cmd.Parameters.Add(new MySqlParameter("@event_title", tEvents.event_title));
					cmd.Parameters.Add(new MySqlParameter("@event_place", tEvents.event_place));
					cmd.Parameters.Add(new MySqlParameter("@event_memo", tEvents.event_memo));
					cmd.Parameters.Add(new MySqlParameter("@event_status", tEvents.event_status));
					cmd.Parameters.Add(new MySqlParameter("@google_id", tEvents.google_id));
					cmd.Parameters.Add(new MySqlParameter("@event_bg_color", tEvents.event_bg_color));
					cmd.Parameters.Add(new MySqlParameter("@event_font_color", tEvents.event_font_color));
					cmd.Parameters.Add(new MySqlParameter("@modifier_on", DateTime.Now));
					MySqlCommand cmd2 = new MySqlCommand("SELECT LAST_INSERT_ID()", mySqlConnection);
					try {
						// オープン
						cmd.Connection.Open();
						// 実行
						cmd.ExecuteNonQuery();
						// 更新IDを取得
						var id = cmd2.ExecuteScalar();
						dbMsg += ",更新ID=" + id;
						// クローズ
						cmd.Connection.Close();
					} catch (SqlException ex) {
						// 例外処理
						MessageBox.Show("例外発生:" + ex.Message);
					}
				}

				MyLog(TAG, dbMsg);
				if (retLink != null) {
					if (!retLink.Equals("")) {
						ExecuteRes(retLink);
						//						QuitToWeb(retLink);
					}
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 伝票番号フォルダの下にファイル保存する
		/// </summary>
		/// <param name="fullPass"></param>
		/// <param name="eventFolderID"></param>
		/// <returns></returns>
		private string PutInFoldrFile(string fullPass, string eventFolderID, Google.Apis.Calendar.v3.Data.Event taregetEvent)
		{
			string TAG = "PutItemEventFile";
			string dbMsg = "[GEventEdit]";
			string retFileID = null;
			try {
				dbMsg += "イベント[" + eventFolderID + "]  ";
				string eventIDStr = String.Format("yyyyMMddhhmm", taregetEvent.Start.DateTime);
				dbMsg += eventIDStr;
				dbMsg += "に " + fullPass + "を作成";

				string[] strs = fullPass.Split('\\');
				string name = strs[strs.Length - 1];
				dbMsg += "　,name=" + name;
				string parent = strs[strs.Length - 2];
				dbMsg += "　,parent=" + parent;
				//伝票名のフォルダ
				Task<File> rr = Task<File>.Run(() => {
					return GDriveUtil.CreateFolder(parent, eventFolderID);
				});
				rr.Wait();
				string numberFolderId = rr.Result.Id;
				dbMsg += ",伝票番号フォルダ[" + numberFolderId + "]";
				retFileID = GDriveUtil.UploadFile(name, fullPass, numberFolderId);
				dbMsg += ",登録[" + retFileID + "]";
				//添付ファイルに追加
				File savedFile = GDriveUtil.FindById(retFileID);
				AttachmentsFromDrive(savedFile);
				dbMsg += ",Attachments=" + taregetEvent.Attachments.Count() + "件";

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retFileID;
		}

		/// <summary>
		/// 新規イベント作成
		/// </summary>
		/// <returns></returns>
		private string WriteEvent()
		{
			string TAG = "WriteEvent";
			string dbMsg = "[GEventEdit]";
			string retLink = "";
			try {
				string startDT = taregetEvent.Start.DateTime.ToString();
				dbMsg += ")" + startDT;
				string endDT = taregetEvent.End.DateTime.ToString();
				dbMsg += "～" + endDT;
				if (String.IsNullOrEmpty(startDT)) {
					startDT = taregetEvent.Start.Date;
				}
				string Summary = taregetEvent.Summary;
				dbMsg += "," + Summary;
				string eDescription = taregetEvent.Description;
				dbMsg += ",Description=" + eDescription + "を新規登録";
				retLink = GCalendarUtil.InsertGEvents(taregetEvent);
				dbMsg += "\r\nretLink" + retLink;
				MyLog(TAG, dbMsg);
				ExecuteRes(retLink);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retLink;
		}

		/// <summary>
		/// Descriptionに添付ファイルのリンクを追加してEventを更新
		/// </summary>
		private string ReWriteEvent()
		{
			string TAG = "ReWriteEvent";
			string dbMsg = "[GEventEdit]";
			string retLink = "";
			try {
				//int selectedIndex = event_lv.FocusedItem.Index;         //先頭0の選択位置：：Positionは座標
				//dbMsg += ",Index=" + selectedIndex;
				//Constant.eventItem = new Google.Apis.Calendar.v3.Data.Event();
				//Constant.eventItem = Constant.GCalenderEvent[selectedIndex];
				string startDT = taregetEvent.Start.DateTime.ToString();
				dbMsg += ")" + startDT;
				string endDT = taregetEvent.End.DateTime.ToString();
				dbMsg += "～" + endDT;
				if (String.IsNullOrEmpty(startDT)) {
					startDT = taregetEvent.Start.Date;
				}
				string Summary = taregetEvent.Summary;
				dbMsg += "," + Summary;
				string eDescription = taregetEvent.Description;
				dbMsg += ",Description=" + eDescription;
				retLink = GCalendarUtil.UpDateGEvents(taregetEvent);
				dbMsg += "\r\nretLink" + retLink;
				MyLog(TAG, dbMsg);
				ExecuteRes(retLink);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retLink;
		}

		/// <summary>
		/// 書込み・更新結果をwebで見せる
		/// 現在未使用
		/// </summary>
		/// <param name="targetUrl"></param>
		private void QuitToWeb(string targetUrl)
		{
			string TAG = "QuitToWeb";
			string dbMsg = "[GoogleAuth]";
			try {
				dbMsg += ",targetUrl= " + targetUrl;

				string UserId = Constant.MyCalendarCredential.UserId;
				dbMsg += " ,UserId=" + UserId;
				MyLog(TAG, dbMsg);
				Constant.WebStratUrl = Constant.CalenderOtherView + "month?pli=1";
				//特定日の指定は　/month/2020/9/1?pli=1
				//		dbMsg += ",CalenderURL=" + Constant.WebStratUrl;
				//if (webWindow == null) {
				//	dbMsg += "一日リストを生成";
				//	webWindow = new WebWindow();
				//	webWindow.authWindow = null;
				//	webWindow.mainView = mainView;
				//	webWindow.Show();
				//	webWindow.SetMyURL(new Uri(targetUrl));
				//}
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 書込み・更新結果をダイアログで見せてから元のVieへ
		/// </summary>
		/// <param name="targetUrl"></param>
		private void ExecuteRes(string retLink)
		{
			string TAG = "ExecuteRes";
			string dbMsg = "[GEventEdit]";
			try {
				if (retLink != null) {
					//				if (retLink.Contains("https://www.google.com/calendar/event")) {
					String titolStr = Constant.ApplicationName;
					DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
					DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
					String msgStr = startDT + "～" + endDT;
					msgStr += "	\r\n" + taregetEvent.Summary;
					msgStr += "	を登録しました";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
					string ym = String.Format("{0:yyyyMM}", startDT);
					msgStr += "	,ym=" + ym;
					//MonthInfo monthInfo = new MonthInfo(ym);
					//mainView.CreateCalendar(monthInfo);
					dbMsg += msgStr;
					QuitMe();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// イベント削除ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Del_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Del_bt_Click";
			string dbMsg = "[GEventEdit]";
			string retLink = taregetEvent.HtmlLink;
			try {
				String titolStr = Constant.ApplicationName;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				String msgStr = startDT + "～" + endDT;
				msgStr += "	\r\n" + taregetEvent.Summary;
				msgStr += "	を削除しました";

				GCalendarUtil.DeleteGEvents(taregetEvent);

				MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				dbMsg += ",result=" + result;
				string ym = String.Format("{0:yyyyMM}", startDT);
				msgStr += "	,ym=" + ym;
				//MonthInfo monthInfo = new MonthInfo(ym);
				//mainView.CreateCalendar(monthInfo);
				dbMsg += msgStr;
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// キャンセルボタンのクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Cancel_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Cancel_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Back_bt_Click(object sender, EventArgs e)
		{
			string TAG = "back_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				QuitMe();
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

		/// <summary>
		/// このフォームを閉じる
		/// ※this.Close();だと再表示でクラッシュするのでthis.Visible = false;でこのオブジェクトを破棄させない
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[GEventEdit]";
			try {
				//if (mainView != null) {
				//	mainView.editView = null;
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			MyView.Close();
		}

		//戻し/////////////////////////////////////////////////////////////////////////
		public ViewModelCommand BackDate {
			get { return new Livet.Commands.ViewModelCommand(DateBack); }
		}
		/// <summary>
		/// 戻る
		/// </summary>
		public void DateBack()
		{
			string TAG = "DateBack";
			string dbMsg = "";
			try {
				if (weekDisplayMode.Equals("Week")) {
					SelectedDateTime = SelectedDateTime.AddDays(-7);
				} else {
					SelectedDateTime = SelectedDateTime.AddDays(-1);
				}
				dbMsg += SelectedDateTime + "に戻す";
				CurrentDate = String.Format("{0:yyyy年MM月dd日}", SelectedDateTime);
				dbMsg += ">>" + CurrentDate;
				RaisePropertyChanged("CurrentDate");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//////////////////////////////////////////////////登録//
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[X_2ViewModel]" + dbMsg;
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[X_2ViewModel]" + dbMsg;
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

	}
}