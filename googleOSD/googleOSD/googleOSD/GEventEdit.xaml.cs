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
using Google.Apis.Drive.v3.Data;

namespace GoogleOSD {
	/// <summary>
	/// GEventEdit.xaml の相互作用ロジック
	/// </summary>
	public partial class GEventEdit : Window {
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();
		GoogleDriveUtil GDriveUtil = new GoogleDriveUtil();

		public GoogleAuth authWindow;
		public GCalender mainView;
		public GoogleDriveBrouser driveView;
		public WebWindow webWindow;

		public AriadneData selectedAriadneData;
		public IList<GAttachFile> sendFiles = new List<GAttachFile>();

		/// <summary>
		/// このページで編集するEvent
		/// </summary>
		private Google.Apis.Calendar.v3.Data.Event taregetEvent { set; get; }

		/// <summary>
		/// この画面の開始
		/// </summary>
		/// <param name="taregetEvent"></param>
		public GEventEdit(Google.Apis.Calendar.v3.Data.Event taregetEvent  ,AriadneData selectedAriadneData)
		{
			string TAG = "GEventEdit";
			string dbMsg = "[GEventEdit]";
			try {
				InitializeComponent();
				this.FontSize = Constant.MyFontSize;
				this.taregetEvent = taregetEvent;
				this.selectedAriadneData = selectedAriadneData;
				EventWrite(taregetEvent, selectedAriadneData);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 開始直後、対象イベントの設定内容を読取りViewを初期構成
		/// </summary>
		/// <param name="taregetEvent"></param>
		public void EventWrite(Google.Apis.Calendar.v3.Data.Event taregetEvent, AriadneData selectedAriadneData)
		{
			string TAG = "EventWrite";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg += "HtmlLink=" + taregetEvent.HtmlLink;
				htmlLink_lb.Text = taregetEvent.HtmlLink;
				dbMsg += "taregetEvent=" + taregetEvent.Summary;
				titol_tv.Text = taregetEvent.Summary;
				SetDate(taregetEvent);
				//if(taregetEvent.OriginalStartTime !=null) {
				//	time_zone_lb.Content += taregetEvent.OriginalStartTime.TimeZone;
				//}
				SetDaylong(taregetEvent);
				/*
				<ComboBox Name="kurikaesi_cb" Margin="10,0,0,0" >
	*/
				if (taregetEvent.Location != null) {
					location_tb.Text = taregetEvent.Location;
				}
				/*
						<!--通知  / ゲスト-->
				*/
				//if(taregetEvent.Organizer!=null) {
				//	email_lb.Content = taregetEvent.Organizer.Email;
				//}

				/*
				<Label Grid.Row="8" Grid.Column="0"   
										Content="予定" 
									/>
						<StackPanel Grid.Row="8" Grid.Column="1"   Orientation="Horizontal"
												 Margin="0,0,5,0" >
							<ComboBox Name="yotei_cb" SelectedIndex="1" >
								<Button Content="予定あり"/>
								<Button Content="予定なし"/>
							</ComboBox>
							<ComboBox Name="koukai_cb" SelectedIndex="1" >
								<Button Content="デフォルトの公開設定"/>
								<Button Content="公開"/>
								<Button Content="非公開"/>
							</ComboBox>
							<Label Name="koukai" Content="デフォルトの公開予定" Margin="0,0,0,0" />
						</StackPanel>
				*/
				SetColor(taregetEvent.ColorId);
				SetAttachments(taregetEvent.Attachments , selectedAriadneData);
				SetDescription(taregetEvent);
				/*
		   AnyoneCanAddSelf	null	bool?
▶ 列ビュー		
◢ Attendees	Count = 4	System.Collections.Generic.IList<Google.Apis.Calendar.v3.Data.EventAttendee> {System.Collections.Generic.List<Google.Apis.Calendar.v3.Data.EventAttendee>}
◢ [0]	{Google.Apis.Calendar.v3.Data.EventAttendee}	Google.Apis.Calendar.v3.Data.EventAttendee
AdditionalGuests	null	int?
Comment	null	string
DisplayName	null	string
ETag	null	string
Id	null	string
Optional	null	bool?
Organizer	null	bool?
Resource	null	bool?
ResponseStatus	"needsAction"	string
Self	null	bool?
▶ [1]	{Google.Apis.Calendar.v3.Data.EventAttendee}	Google.Apis.Calendar.v3.Data.EventAttendee
▶ [2]	{Google.Apis.Calendar.v3.Data.EventAttendee}	Google.Apis.Calendar.v3.Data.EventAttendee
▶ [3]	{Google.Apis.Calendar.v3.Data.EventAttendee}	Google.Apis.Calendar.v3.Data.EventAttendee
▶ 列ビュー		
AttendeesOmitted	null	bool?
ConferenceData	null	Google.Apis.Calendar.v3.Data.ConferenceData
▶ Created	{2020/05/02 10:58:35}	System.DateTime?
CreatedRaw	"2020-05-02T01:58:35.000Z"	string
▶ Creator	{Google.Apis.Calendar.v3.Data.Event.CreatorData}	Google.Apis.Calendar.v3.Data.Event.CreatorData
ETag	"\"3180052441811000\""	string
ExtendedProperties	null	Google.Apis.Calendar.v3.Data.Event.ExtendedPropertiesData
Gadget	null	Google.Apis.Calendar.v3.Data.Event.GadgetData
GuestsCanInviteOthers	null	bool?
GuestsCanModify	null	bool?
GuestsCanSeeOtherGuests	null	bool?
HangoutLink	null	string
ICalUID	"5q8qbifpcm5j7skslte8u0hute@google.com"	string
Id	"5q8qbifpcm5j7skslte8u0hute_20200506T010000Z"	string
Kind	"calendar#event"	string
Locked	null	bool?
◢ Organizer	{Google.Apis.Calendar.v3.Data.Event.OrganizerData}	Google.Apis.Calendar.v3.Data.Event.OrganizerData
DisplayName	null	string
Email	"hkuwauama@gmail.com"	string
Id	null	string
Self	TRUE	bool?
Method	"popup"	string
Minutes	60	int?
◢ [1]	{Google.Apis.Calendar.v3.Data.EventReminder}	Google.Apis.Calendar.v3.Data.EventReminder
ETag	null	string
Method	"email"	string
Minutes	1440	int?
▶ 列ビュー		
UseDefault	FALSE	bool?
Sequence	5	int?
Source	null	Google.Apis.Calendar.v3.Data.Event.SourceData
Status	"confirmed"	string
Transparency	null	string
▶ Updated	{2020/05/21 11:12:09}	System.DateTime?
UpdatedRaw	"2020-05-21T02:12:09.700Z"	string
Visibility	null	string

				 */
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
				TimeSpan nonTS = new TimeSpan(0, 0, 0);
				dbMsg += ",TimeSpan未設定=" + nonTS;
				DateTime now =DateTime.Now;
				DateTime originalSDT = GCalendarUtil.EventDateTime2DT(eventItem.OriginalStartTime);
				dbMsg += ",OriginalStartTime=" + originalSDT;
				if(now== originalSDT) {
					dbMsg += ">>現在時刻" ;
				}
				DateTime startDT = GCalendarUtil.EventDateTime2DT(eventItem.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(eventItem.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += "," + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT  + ")" ;
				start_date_dp.SelectedDate = startDT;
				start_time_tp.SetMyTimeSpan(startDTT);
				if (startDTT == nonTS) {
					start_time_tp.Visibility = System.Windows.Visibility.Hidden;
				}
				end_time_tp.SetMyTimeSpan(endDTT);
				if (endDTT == nonTS) {
					end_time_tp.Visibility = System.Windows.Visibility.Hidden;
				}
				end_date_dp.SelectedDate = endDT;
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
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;
	
				DatePicker dp = sender as DatePicker;
				DateTime selectedDate = dp.SelectedDate.Value.Date;     //時刻は00:00
				string selectedDateStr = String.Format("{0:yyyy-MM-dd}", selectedDate);
				dbMsg += ",開始日=" + selectedDateStr;
				string startDTStr = String.Format("{0:yyyy-MM-dd}", startDT);
				if (!selectedDateStr.Equals(startDTStr)) {
					dbMsg += ">>変更";
					if (daylong_cb.IsChecked.Value) {
						dbMsg += ">>終日";
						taregetEvent.Start.Date = selectedDateStr;
					}else{
						selectedDate=selectedDate.Add(startDTT);
						dbMsg += ",登録＝"+ selectedDate;
						taregetEvent.Start.DateTime = selectedDate;
						taregetEvent.Start.Date = null;						//終日ではない事のフラグ
					}
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
		private void Start_time_tp_SelectedTimeChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "Start_time_tp_SelectedTimeChanged";
			string dbMsg = "[GEventEdit]";
			try {
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;

				TimePic tp = sender as TimePic;
				TimeSpan selectedTS = tp.selectedTS;
				int selectedHours = selectedTS.Hours;
				int selectedMinutes = selectedTS.Minutes;
				int selectedSeconds = selectedTS.Seconds;
				TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
				dbMsg += ",開始時刻=" + selectedTime;
					if (!selectedTime.Equals(startDTT)) {
						DateTime startDTDate = startDT.Date;
						dbMsg += ",startDTDate=" + startDTDate;
						startDT = startDTDate.Add(selectedTime);
						dbMsg += ">登録>" + startDT;
						taregetEvent.Start.DateTime = startDT;
						//終了側の変更
						//taregetEvent.End.DateTime = startDT.Add(duration);
						//dbMsg += ">end>" + taregetEvent.End.DateTime;
						//end_time_tp.SelectedTime = taregetEvent.End.DateTime.Value.TimeOfDay;
						//end_date_dp.SelectedDate = taregetEvent.End.DateTime.Value.Date;
						taregetEvent.Start.Date = null;                     //終日ではない事のフラグ
					}
					MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 終了時刻変更後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void End_time_tp_SelectedTimeChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "End_time_tp_SelectedTimeChanged";
			string dbMsg = "[GEventEdit]";
			try {
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;

				TimePic tp = sender as TimePic;
				TimeSpan selectedTS = tp.selectedTS;
				int selectedHours = selectedTS.Hours;
				int selectedMinutes = selectedTS.Minutes;
				int selectedSeconds = selectedTS.Seconds;
				TimeSpan selectedTime = new TimeSpan(selectedHours, selectedMinutes, selectedSeconds);
				dbMsg += ",終了時刻=" + selectedTime;
				if (!selectedTime.Equals(endDTT)) {
					DateTime endDTDate = endDT.Date;
					dbMsg += ",endDTDate=" + endDTDate;
					endDT = endDTDate.Add(selectedTime);
					dbMsg += ">登録>" + endDT;
					taregetEvent.Start.DateTime = endDT;
					//終了側の変更
					//taregetEvent.End.DateTime = startDT.Add(duration);
					//dbMsg += ">end>" + taregetEvent.End.DateTime;
					//end_time_tp.SelectedTime = taregetEvent.End.DateTime.Value.TimeOfDay;
					//end_date_dp.SelectedDate = taregetEvent.End.DateTime.Value.Date;
					taregetEvent.End.Date = null;                     //終日ではない事のフラグ
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

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
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				TimeSpan startDTT = startDT.TimeOfDay;
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End); 
				TimeSpan endDTT = endDT.TimeOfDay;
				dbMsg += ",元の設定：" + startDT + "(" + startDTT + ")～" + endDT + "(" + endDTT + ")";
				TimeSpan duration = endDT - startDT;
				dbMsg += ",所要時間=" + duration;
	
				DatePicker dp = sender as DatePicker;
				DateTime selectedDate = dp.SelectedDate.Value.Date;     //時刻は00:00
				string selectedDateStr = String.Format("{0:yyyy-MM-dd}", selectedDate);
				dbMsg += ",終了日=" + selectedDateStr;
				string StartDTStr = String.Format("{0:yyyy-MM-dd}", startDT);
				if (!selectedDateStr.Equals(StartDTStr)) {
					dbMsg += ">>変更";
					if (daylong_cb.IsChecked.Value) {
						dbMsg += ">>終日";
						taregetEvent.End.Date = selectedDateStr;
					} else {
						selectedDate = selectedDate.Add(endDTT);
						dbMsg += ",登録＝" + selectedDate;
						taregetEvent.End.DateTime = selectedDate;
						taregetEvent.End.Date = null;                     //終日ではない事のフラグ
					}
					//int endInt = GCalendarUtil.EventDateTime2Int(taregetEvent.End);
					//int startInt =GCalendarUtil.EventDateTime2Int(taregetEvent.Start);
					//if (endInt < startInt) {
					//	dbMsg += ">終了日以降になっている>";
					//	taregetEvent.Start.DateTime = selectedDate.Add(-duration);
					//	dbMsg += taregetEvent.Start.DateTime;
					//	start_date_dp.SelectedDate = taregetEvent.Start.DateTime.Value.Date;
					//}
				}
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
				if(startDate != null) {
					dbMsg += "startDate="+ startDate;
					daylong_cb.IsChecked=true;
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
				if(isChecked) {
					//trueからfaleseに変わったらDateを記入
					dbMsg += ">終日>";
					string StartDTStr = String.Format("{0:yyyy-MM-dd}", startDT);
					taregetEvent.Start.Date = StartDTStr;
					taregetEvent.Start.DateTime = null;
					dbMsg += "開始="+ StartDTStr +"(" + GCalendarUtil.EventDateTime2DT(taregetEvent.Start) +")";
					string endDTStr = String.Format("{0:yyyy-MM-dd}", endDT);
					taregetEvent.End.Date = endDTStr;
					taregetEvent.End.DateTime = null;
					start_time_tp.Visibility = System.Windows.Visibility.Hidden;
					end_time_tp.Visibility = System.Windows.Visibility.Hidden;
				} else {
					//aleseからtruefに変わったらDateTimeを記入
					dbMsg += ">時刻指定>";
					taregetEvent.Start.Date = null;
					if(startDTT== nonTS) {
						DateTime nowDT = DateTime.Now;
						TimeSpan nowDTT = nowDT.TimeOfDay;
						startDT = startDT.Add(nowDTT);
						dbMsg += ">>"+ startDT;
					}
					taregetEvent.Start.DateTime = startDT;
					dbMsg += "開始="  + GCalendarUtil.EventDateTime2DT(taregetEvent.Start) ;
					taregetEvent.End.Date = null;
					if(nonTS < duration) {
						endDT = startDT.Add(duration);
					}else{
						endDT = startDT.Add(new TimeSpan(1, 0, 0));
					}
					taregetEvent.End.DateTime = endDT;
					dbMsg += "～終了=" + GCalendarUtil.EventDateTime2DT(taregetEvent.End);
					start_time_tp.Visibility = System.Windows.Visibility.Visible;
					end_time_tp.Visibility = System.Windows.Visibility.Visible;
					startDTT = startDT.TimeOfDay;
			//		start_time_tp.SelectedTime = startDTT;
					start_time_tp.SetMyTimeSpan(startDTT);
					endDTT = endDT.TimeOfDay;
			//		end_time_tp.SelectedTime = endDTT;
					end_time_tp.SetMyTimeSpan(endDTT);
				}
				start_date_dp.SelectedDate = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				end_date_dp.SelectedDate = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
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
				if(colorID==null) {
					colorID = "7";
				}
				if (Constant.googleEventColor == null) {
					GCalendarUtil.setGoogleEventColor();
					dbMsg += ">>" + colorID;
				}
				dbMsg += "googleEventColor=" + Constant.googleEventColor.Count+"色";
				Constant.GoogleEventColor colorInfo = Constant.googleEventColor[int.Parse(colorID)];
				Color_lb.Foreground = new SolidColorBrush(colorInfo.rgb);
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
					//リストアイテムに格納
					color_cb.Items.Add(lb);
					if (color.id.Equals(colorID)) {
						serectIndex = nowCount;
						color_cb.Background = new SolidColorBrush(color.rgb);
						color_cb.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
					}
					nowCount++;
				}
				dbMsg += ",serectIndex=" + serectIndex;
				color_cb.SelectedIndex = serectIndex;
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
				ComboBox cb = sender as ComboBox;
				int serectIndex = cb.SelectedIndex;
				dbMsg += ",serectIndex=" + serectIndex;
				//Label selectedItem = cb.SelectedItem as Label;
				//Constant.GoogleEventColor colorObj = new Constant.GoogleEventColor();
				//colorObj = selectedItem.DataContext;
				Constant.GoogleEventColor color = Constant.googleEventColor[serectIndex];
				dbMsg += "," + color.id + ")" + color.name + "," + color.rgb;
				if(taregetEvent != null) {
					if (!taregetEvent.ColorId.Equals(color.id)) {
						//			color_cb.Background = new SolidColorBrush(color.rgb);
						taregetEvent.ColorId = color.id;
					}
				}
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
				order_tb.Text = Constant.orderNumber;                                               //受注No
				management_number_tb.Text = Constant.managementNumber;           //管理番号
				customer_tb.Text = Constant.customerName;                                       //得意先
				string description = taregetEvent.Description;

				string htmlStr = @"<html lang=""jp"" xmlns =""http://www.w3.org/1999/xhtml"">";
				htmlStr += @"<head><meta charset=""utf-8"" /><title></title></head><body>";
				htmlStr += @description;
				htmlStr += "</body></html>";
				dbMsg = ",htmlStr="+ htmlStr;
		//		description_wb.NavigateToString(htmlStr);

				string memoStr = description;
				if (description.Contains( "</table>" )) {
					string[] delimiter = { "</table>" };
					string[] memoStrs = description.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
					memoStr = memoStrs[1];
				}
		//		momo_tb.Text = memoStr;
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
				description+= "<tr><td>受注No</td>" + "<td> : "+order_tb.Text + "</td></tr>";
				description += "<tr><td>管理番号</td>" + "<td> : " + management_number_tb.Text + "</td></tr>";
				description += "<tr><td>得意先</td>" + "<td> : " + customer_tb.Text + "</td></tr>";
				description += "</tbody ></table><br>";			//<pre>" + momo_tb.Text+ "</pre>";
				dbMsg += ",description="+ description;
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
					// Note that you can have more than one file.
					string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
					var file = files[0];
					string rFile = file.ToString();
					dbMsg += "  ,file= " + file.ToString();
					string[] strs = rFile.Split('\\');
					string name = strs[strs.Length - 1];
					dbMsg += ",name=" + name;
					string parent = strs[strs.Length - 2];
					dbMsg += ",parent=" + parent;
					Google.Apis.Drive.v3.Data.File gFile = GDriveUtil.FindByNameParent(name, parent);
					if (gFile == null) {
						dbMsg += "登録なし";
					} else {
						string gFileId = gFile.Id;
						dbMsg += "[" + gFileId + "]";
					}

				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// 添付ファイル
		/// </summary>
		/// <param name="attachments"></param>
		private void SetAttachments(IList<Google.Apis.Calendar.v3.Data.EventAttachment> attachments , AriadneData selectedAriadneData)
		{
			string TAG = "SetAttachments";
			string dbMsg = "[GEventEdit]";
			try {
				if (attachments != null) {
					dbMsg += "Attachments" + attachments.Count + "件";
					if (0 < attachments.Count) {
						foreach (Google.Apis.Calendar.v3.Data.EventAttachment attachment in attachments) {
							AddAttachmentst(attachment);
						}
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
	
		/// <summary>
		/// GoogleDriveで選択したファイルを添付する
		/// </summary>
		/// <param name="fileItem"></param>
		public void AttachmentsFromDrive(Google.Apis.Drive.v3.Data.File fileItem)
		{
			string TAG = "AttachmentsFromDrive";
			string dbMsg = "[GEventEdit]";
			try {
				Google.Apis.Calendar.v3.Data.EventAttachment attachment = new Google.Apis.Calendar.v3.Data.EventAttachment();
				attachment.Title = fileItem.Name;
				attachment.FileId = fileItem.Id;
				attachment.FileUrl = fileItem.WebContentLink;
				dbMsg += "," + attachment.Title + ",fileId=" + attachment.FileId + ",fileUrl= " + attachment.FileUrl;
				attachment.MimeType = fileItem.MimeType;
				attachment.ETag = fileItem.MimeType;
				dbMsg += "  ,mimeType=" + attachment.MimeType + ",eTag= " + attachment.ETag;
				dbMsg += "  ,iconLink= " + attachment.IconLink;
				dbMsg += "  ,attachments= " + this.taregetEvent.Attachments.Count+"件";
				this.taregetEvent.Attachments.Add(attachment);
				dbMsg += " >> " +this. taregetEvent.Attachments.Count + "件";
				MyLog(TAG, dbMsg);
				AddAttachmentst(attachment);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付ファイルのボタン化
		/// </summary>
		/// <param name="attachment"></param>
		private void AddAttachmentst(Google.Apis.Calendar.v3.Data.EventAttachment attachment)
		{
			string TAG = "AddAttachmentst";
			string dbMsg = "[GEventEdit]";
			try {
						string title = attachment.Title;
						string fileId = attachment.FileId;
						string fileUrl = attachment.FileUrl;
						dbMsg += "\r\n" + title + ",fileId=" + fileId + ",fileUrl= " + fileUrl;
						string mimeType = attachment.MimeType;
						string eTag = attachment.ETag;
						dbMsg += "  ,mimeType=" + mimeType + ",eTag= " + eTag;
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
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 添付解除
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
				IList<Google.Apis.Calendar.v3.Data.EventAttachment> attachments = this.taregetEvent.Attachments;
				dbMsg += "Attachments" + attachments.Count + "件";
				int delIndex = 0;
				if (0 < attachments.Count) {
					foreach (Google.Apis.Calendar.v3.Data.EventAttachment attachment in attachments) {
						string title = attachment.Title;
						string fileId = attachment.FileId;
						dbMsg += "\r\n" + delIndex + ")" + title + ",fileId=" + fileId;
						if(fileId.Equals(delFileId)) {
							break;
						}
						delIndex++;
					}
					dbMsg += ",delIndex=" + delIndex;
					attachments.RemoveAt(delIndex);
					dbMsg += ">削除：添付>" +attachments.Count + "件";
					//添付表示も削除
					attachments_sp.Children.RemoveAt(delIndex);
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
				dbMsg += "  ,taregetUrl=" + taregetUrl ;
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
				if (driveView == null) {
					dbMsg += "GoogleDriveBrouserを再生成";
					driveView = new GoogleDriveBrouser();
					driveView.editView = this;
					driveView.Show();
					driveView.GoogleFolderListUp(Constant.TopFolderName);
				}
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
				DateTime endDT = GCalendarUtil.EventDateTime2DT(taregetEvent.End);
				DateTime startDT = GCalendarUtil.EventDateTime2DT(taregetEvent.Start);
				dbMsg += ",元の設定：" + startDT + "～" + endDT;
				long endLong = GCalendarUtil.EventDateTime2Long(taregetEvent.End);
				long starLong = GCalendarUtil.EventDateTime2Long(taregetEvent.Start);
				if (endLong < starLong) {
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
				string parentFolderName = this.selectedAriadneData.ItemNumber;
				//案件などAriadneEvent直下の
				string itermFolderName = this.selectedAriadneData.ItemNumber;
				Task<string> rr = Task.Run(() => {
					return GDriveUtil.CreateFolder(itermFolderName, Constant.AriadneAnkenFolderId);
				});
				rr.Wait();
				string itemFolderId = rr.Result; 
				dbMsg += ",案件直下の案件名フォルダ[" + itemFolderId + "]";
				rr = Task.Run(() => {
					return GDriveUtil.CreateFolder(itermFolderName, Constant.AriadneKouteiFolderId);
				});
				rr.Wait();
				string processFolderId = rr.Result;
				dbMsg += ",工程名フォルダ[" + processFolderId + "]";
				rr = Task.Run(() => {
					return GDriveUtil.CreateFolder(itermFolderName, Constant.AriadneOtherFolderId);
				});
				rr.Wait();
				string otherFolderId = rr.Result;
				dbMsg += ",一般名フォルダ[" + otherFolderId + "]";

				if (this.selectedAriadneData.EstimationPCPass != null) {
					dbMsg += ",見積ファイル有り" ;
					this.selectedAriadneData.EstimationGoogleFileID = PutInFoldrFile(this.selectedAriadneData.EstimationPCPass, itemFolderId);
					dbMsg += "[" + this.selectedAriadneData.EstimationGoogleFileID +"]";
					//EstimationGoogleFileID = "MI20060006";              // 見積ファイルのGoogleDriveID
				} else {
					this.selectedAriadneData.EstimationGoogleFileID = null;
				}
				if (this.selectedAriadneData.OrderPCPass != null) {
					dbMsg += ",受注ファイル有り";
					this.selectedAriadneData.OrderGoogleFileID = PutInFoldrFile(this.selectedAriadneData.OrderPCPass, itemFolderId);
					dbMsg += "[" + this.selectedAriadneData.EstimationGoogleFileID + "]";
					//.OrderGoogleFileID = "JU20060007";              // 受注ファイルのGoogleDriveID
				} else {
					this.selectedAriadneData.OrderGoogleFileID = null;
				}
				if (this.selectedAriadneData.SalesPCPass != null) {
					dbMsg += ",売上ファイル有り";
					this.selectedAriadneData.SalesGoogleFileID = PutInFoldrFile(this.selectedAriadneData.SalesPCPass, itemFolderId);
					dbMsg += "[" + this.selectedAriadneData.EstimationGoogleFileID + "]";
					//.SalesGoogleFileID = "UR20060004";              //売上ファイルのGoogleDriveID
				} else {
					this.selectedAriadneData.SalesGoogleFileID = null;
				}
				if (this.selectedAriadneData.RequestPCPass != null) {
					dbMsg += ",請求ファイル有り";
					this.selectedAriadneData.RequestGoogleFileID = PutInFoldrFile(this.selectedAriadneData.RequestPCPass, itemFolderId);
					dbMsg += "[" + this.selectedAriadneData.EstimationGoogleFileID + "]";
					//RequestPCPass = "";              //請求ファイルのPC保存位置
				} else {
					this.selectedAriadneData.RequestGoogleFileID = null;
				}
				if (this.selectedAriadneData.ReceiptPCPass != null) {
					dbMsg += ",入金ファイル有り";
					this.selectedAriadneData.ReceipttGoogleFileID = PutInFoldrFile(this.selectedAriadneData.ReceiptPCPass, itemFolderId);
					dbMsg += "[" + this.selectedAriadneData.ReceipttGoogleFileID + "]";
					//ReceipttGoogleFileID = "NY20060001";              //入金ファイルのGoogleDriveID
				} else {
					this.selectedAriadneData.ReceipttGoogleFileID = null;
				}
				if (this.selectedAriadneData.ToOrderPCPass != null) {
					dbMsg += ",資材発注ファイル有り";
					this.selectedAriadneData.ToOrderGoogleFileID = PutInFoldrFile(this.selectedAriadneData.ToOrderPCPass, processFolderId);
					dbMsg += "[" + this.selectedAriadneData.ToOrderGoogleFileID + "]";
					//ToOrderGoogleFileID = "HA20060001";              //発注ファイルのGoogleDriveID
				} else {
					this.selectedAriadneData.ToOrderGoogleFileID = null;
				}
				if (this.selectedAriadneData.StockPCPass != null) {
					dbMsg += ",荷・工事消込ファイル有り";
					this.selectedAriadneData.StockGoogleFileID = PutInFoldrFile(this.selectedAriadneData.StockPCPass, processFolderId);
					dbMsg += "[" + this.selectedAriadneData.ToOrderGoogleFileID + "]";
					//StockGoogleFileID = "SI20060001";              // 入荷・工事消込ファイルのGoogleDriveID
				} else {
					this.selectedAriadneData.StockGoogleFileID = null;
				}
				dbMsg += ",対象ファイル" + sendFiles.Count + "件";
				this.selectedAriadneData.sendFiles = sendFiles;
				retLink = GCalendarUtil.AddEventInfo(taregetEvent, this.selectedAriadneData);
				dbMsg += ",retLink=" + retLink;
				MyLog(TAG, dbMsg);
				if (retLink != null) {
					if (!retLink.Equals("")) {
						QuitToWeb(retLink);
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
		private string PutInFoldrFile(string fullPass,string eventFolderID)
		{
			string TAG = "PutItemEventFile";
			string dbMsg = "[GEventEdit]";
			string retFileID = null;
			try {
				dbMsg +=  eventFolderID + " に " + fullPass;
				//retFileID = GDriveUtil.AriadneDataPut(fullPass, parentFolderName, parentFolderID);
				//dbMsg += "[" + retFileID + "]";
				//bool isFolder = false;
				string[] strs = fullPass.Split('\\');
				string name = strs[strs.Length - 1];
				dbMsg += ",name=" + name;
				string parent = strs[strs.Length - 2];
				dbMsg += ",parent=" + parent;
				Task<string> rr = Task.Run(() => {
					return GDriveUtil.CreateFolder(parent, eventFolderID);
				});
				rr.Wait();
				string numberFolderId = rr.Result;
				dbMsg += ",伝票番号フォルダ[" + numberFolderId + "]";
				retFileID = GDriveUtil.UploadFile(name, fullPass, numberFolderId);
				dbMsg += ",登録[" + retFileID + "]";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retFileID;
		}



		private string AddSendFile(string fullPass , string  parentFolderName, string parentFolderID)
		{
			string TAG = "AddSendFile";
			string dbMsg = "[GEventEdit]";
			string retFileID = null;
			try {
				dbMsg += " , " + fullPass ;
				retFileID=GDriveUtil.AriadneDataPut(fullPass,  parentFolderName, parentFolderID);
				dbMsg += "[" + retFileID + "]";
				bool isFolder = false;
				string[] strs = fullPass.Split('\\');
				string name = strs[strs.Length - 1];
				dbMsg += ",name=" + name;
				string parent = strs[strs.Length - 2];
				dbMsg += ",parent=" + parent;
				GAttachFile gAttachFile = new GAttachFile(fullPass, retFileID, name, parent, isFolder);
				sendFiles.Add(gAttachFile);

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
				dbMsg += ",Description=" + eDescription +"を新規登録";
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
				//if (eDescription == null) {
				//	eDescription = "";
				//} else {
				//	eDescription += "</br>";
				//}
				dbMsg += ",Description=" + eDescription;
				//if (Constant.GDriveSelectedFiles != null) {
				//	dbMsg += ",添付⁼" + Constant.GDriveSelectedFiles.Count + "件";
				//	if (0 < Constant.GDriveSelectedFiles.Count) {
				//		if (eDescription.Contains("添付ファイル")) {
				//			eDescription += "<table>";
				//		} else {
				//			eDescription += "添付ファイル</br><table>";
				//		}
				//		foreach (Google.Apis.Drive.v3.Data.File fileItem in Constant.GDriveSelectedFiles) {
				//			string fId = fileItem.Id;
				//			dbMsg += "\r\n" + fId;
				//			string ParentsID = fileItem.Parents[0];
				//			dbMsg += "[Parents=" + ParentsID;
				//			Google.Apis.Drive.v3.Data.File rFile = GDriveUtil.FindById(ParentsID);
				//			string ParentsName = rFile.Name;
				//			dbMsg += "]" + ParentsName;
				//			string fName = fileItem.Name.ToString();
				//			dbMsg += "," + fName;
				//			string fLink = fileItem.WebContentLink.ToString();
				//			dbMsg += "," + fLink;
				//			eDescription += "<tr>";
				//			eDescription += "<td>" + ParentsName + "</td>";
				//			eDescription += "<td  style=\"padding: 10px 10px; \"><a href=\"" + fLink + "\">" + fName + "</a></td>";
				//			eDescription += "</tr>";
				//		}
				//		eDescription += "</table>";
				//		dbMsg += ",Description=\r\n" + eDescription;
				//		Constant.eventItem.Description = eDescription;
				retLink = GCalendarUtil.UpDateGEvents(taregetEvent);
				dbMsg += "\r\nretLink" + retLink;
				//		try {
				//			System.Diagnostics.Process.Start(retLink);              //webで表示
				//		} catch (
				//			   System.ComponentModel.Win32Exception noBrowser) {
				//			if (noBrowser.ErrorCode == -2147467259)
				//				MessageBox.Show(noBrowser.Message);
				//		} catch (System.Exception other) {
				//			MessageBox.Show(other.Message);
				//		}

				//	} else {
				//		dbMsg += "添付するファイルが登録されていません";
				//	}
				//} else {
				//	dbMsg += "添付するファイルの情報を取得できませんでした";
				//}
				MyLog(TAG, dbMsg);
				ExecuteRes(retLink);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retLink;
		}

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
				if (webWindow == null) {
					dbMsg += "一日リストを生成";
					webWindow = new WebWindow();
					webWindow.authWindow = null;
					webWindow.mainView = mainView;
					webWindow.Show();
					webWindow.SetMyURL(new Uri(targetUrl));
				}
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}



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
					QuitMe();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 削除ボタンクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Del_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Del_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
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
				if (mainView != null) {
					mainView.editView = null;
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

	}
}