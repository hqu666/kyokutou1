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
using MahApps.Metro.Controls;

namespace KGSample {
	/// <summary>
	/// GEventEdit.xaml の相互作用ロジック
	/// </summary>
	public partial class GEventEdit : MetroWindow {
		GoogleCalendarUtil GCalendarUtil = new GoogleCalendarUtil();

		public GCalender mainView;
		public GoogleDriveBrouser driveView;

		/// <summary>
		/// このページで編集するEvent
		/// </summary>
		//public Uri taregetURL { set; get; }
		private Google.Apis.Calendar.v3.Data.Event taregetEvent { set; get; }

		public GEventEdit(Google.Apis.Calendar.v3.Data.Event taregetEvent)
		{
			string TAG = "GEventEdit";
			string dbMsg = "[GEventEdit]";
			try {
				InitializeComponent();
				this.taregetEvent = taregetEvent;
				EventWrite(taregetEvent);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void EventWrite(Google.Apis.Calendar.v3.Data.Event taregetEvent)
		{
			string TAG = "EventWrite";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg = "HtmlLink=" + taregetEvent.HtmlLink;
				htmlLink_lb.Text = taregetEvent.HtmlLink;
				dbMsg = "taregetEvent=" + taregetEvent.Summary;
				titol_tv.Text = taregetEvent.Summary;
				SetDate(taregetEvent);
				if(taregetEvent.OriginalStartTime !=null) {
					time_zone_lb.Content += taregetEvent.OriginalStartTime.TimeZone;
				}
				SetDaylong(taregetEvent);
				/*
				<ComboBox Name="kurikaesi_cb" Margin="10,0,0,0" >
	*/
				location_tb.Text = taregetEvent.Location;
				/*
						<!--通知  / ゲスト-->
				*/
				email_lb.Content = taregetEvent.Organizer.Email;

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


						<Label Grid.Row="9" Grid.Column="0"   Content="詳細" HorizontalAlignment="Right"  Margin="0,0,0,0" VerticalAlignment="Top" />
				*/
				SetColor(taregetEvent.ColorId);
				SetAttachments(taregetEvent.Attachments);
				description_tb.Text = taregetEvent.Description;
				//Description	"<a href=\"https://drive.google.com/file/d/1wuvk9-uufN87mH3Huw4VhfnJz98hG0KA/view?usp=sharing\">https://drive.google.com/file/d/1wuvk9-uufN87mH3Huw4VhfnJz98hG0KA/view?usp=sharing</a><br>予定議事<br><ol><li>今期予算確認<br></li><li>各課進捗報告</li></ol><br>下記の添付ファイルを各自参照できる様、持参して下さい。<table><tbody><tr><td>PR0003</td><td><a href=\"https://drive.google.com/uc?id=10NTpRCN5xwCIvIT-qeAUZx6T4cM2eyGY&export=download\">PR0003.txt</a></td></tr><tr><td>PR0001</td><td><a href=\"https://drive.google.com/uc?id=1-qsqVlHH1bfaMVJwCeBLHoXlIGpSTrjP&export=download\">PR0001.pptx</a></td></tr><tr><td>PR0003</td><td><a href=\"https://drive.google.com/uc?id=11fP9Krj48m_za3Z5IAVxEFpFQRWjLRU6&export=download\">PR0003.xlsx</a></td></tr></tbody></table><br><a href=\"https://drive.google.com/file/d/1wuvk9-uufN87mH3Huw4VhfnJz98hG0KA/view?usp=drive_web\"><span></span><span></span></a>"	string

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
◢ OriginalStartTime	{Google.Apis.Calendar.v3.Data.EventDateTime}	Google.Apis.Calendar.v3.Data.EventDateTime
Date	null	string
◢ DateTime	{2020/05/06 10:00:00}	System.DateTime?
▶ Date	{2020/05/06 0:00:00}	System.DateTime
Day	6	int
DayOfWeek	Wednesday	System.DayOfWeek
DayOfYear	127	int
Hour	10	int
InternalKind	9.22337E+18	ulong
InternalTicks	6.37244E+17	long
Kind	Local	System.DateTimeKind
Millisecond	0	int
Minute	0	int
Month	5	int
Second	0	int
Ticks	6.37244E+17	long
▶ TimeOfDay	{10:00:00}	System.TimeSpan
Year	2020	int
dateData	9.86062E+18	ulong
▶ 静的メンバー		
DateTimeRaw	"2020-05-06T10:00:00+09:00"	string
ETag	null	string
TimeZone	"Asia/Tokyo"	string
PrivateCopy	null	bool?
Recurrence	null	System.Collections.Generic.IList<string>
RecurringEventId	"5q8qbifpcm5j7skslte8u0hute"	string
◢ Reminders	{Google.Apis.Calendar.v3.Data.Event.RemindersData}	Google.Apis.Calendar.v3.Data.Event.RemindersData
◢ Overrides	Count = 2	System.Collections.Generic.IList<Google.Apis.Calendar.v3.Data.EventReminder> {System.Collections.Generic.List<Google.Apis.Calendar.v3.Data.EventReminder>}
◢ [0]	{Google.Apis.Calendar.v3.Data.EventReminder}	Google.Apis.Calendar.v3.Data.EventReminder
ETag	null	string
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
				start_time_tp.SelectedTime = startDTT;
				if(startDTT == nonTS) {
					start_time_tp.Visibility = System.Windows.Visibility.Hidden;
				}
				end_time_tp.SelectedTime = endDTT;
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
				DatePicker dp = sender as DatePicker;
				dbMsg += ",開始日=" + dp.SelectedDate;
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
		private void Start_time_tp_SelectedTimeChanged(object sender, TimePickerBaseSelectionChangedEventArgs<TimeSpan?> e)
		{
			string TAG = "Start_time_tp_SelectedTimeChanged";
			string dbMsg = "[GEventEdit]";
			try {
				TimePicker tp = sender as TimePicker;
				dbMsg += ",開始時刻=" + tp.SelectedTime;
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
		private void End_time_tp_SelectedTimeChanged(object sender, TimePickerBaseSelectionChangedEventArgs<TimeSpan?> e)
		{
			string TAG = "End_time_tp_SelectedTimeChanged";
			string dbMsg = "[GEventEdit]";
			try {
				TimePicker tp = sender as TimePicker;
				dbMsg += ",終了時刻=" + tp.SelectedTime;
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
				DatePicker dp = sender as DatePicker;
				dbMsg += ",終了日=" + dp.SelectedDate;
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
		private void Daylong_cb_Checked(object sender, RoutedEventArgs e)
		{
			string TAG = "Daylong_cb_Checked";
			string dbMsg = "[GEventEdit]";
			try {
				CheckBox cb = sender as CheckBox;
				dbMsg += "IsChecked=" + cb.IsChecked;
				//trueからfaleseに変わったらDateを記入
				//aleseからtruefに変わったらDateTimeを記入

				//string startDate = taregetEvent.Start.Date;
				//if (startDate != null) {
				//	daylong_cb.IsChecked = true;
				//}
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
				int serectIndex = 0;
				int nowCount = 0;
				foreach(Constant.GoogleEventColor color in Constant.googleEventColor) {
					dbMsg += "\r\n" + color.id +")" + color.name+ "," + color.rgb;
					//ファイルの表示名color情報をラベルに格納して
					Label lb = new Label();
					lb.Content = color.name;
					lb.Background = new SolidColorBrush(color.rgb);
					lb.Foreground = new SolidColorBrush(Color.FromRgb(255,255,255));
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
				if(! taregetEvent.ColorId.Equals(color.id)){
					color_cb.Background = new SolidColorBrush(color.rgb);
					taregetEvent.ColorId = color.id;
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
		private void SetAttachments(IList<Google.Apis.Calendar.v3.Data.EventAttachment> attachments)
		{
			string TAG = "SetAttachments";
			string dbMsg = "[GEventEdit]";
			try {
				if(attachments != null) {
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
		private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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