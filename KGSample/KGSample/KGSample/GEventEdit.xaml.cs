﻿using System;
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

		public GCalender mainView;

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
				/*
			<DatePicker Name="start_date_dp"
			<Mah:TimePicker  Name="start_time_tp" 
			<Mah:TimePicker  Name="end_time_tp" />
			<DatePicker Name="end_date_dp"
			*/
				if(taregetEvent.OriginalStartTime !=null) {
					time_zone_lb.Content += taregetEvent.OriginalStartTime.TimeZone;
				}
				/*
				<CheckBox Name="syuujitu_c" Content="終日" HorizontalAlignment="Left" VerticalAlignment="Top"/>
				<ComboBox Name="kurikaesi_cb" Margin="10,0,0,0" >
	*/
				location_tb.Text = taregetEvent.Location;
				/*
						<!--通知  / ゲスト-->
				*/
				email_lb.Content = taregetEvent.Organizer.Email;

				/*
							<ComboBox Name="color_cb" Width="120">
								<ListBoxItem/>
							</ComboBox>
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
				SetAttachments(taregetEvent.Attachments);
				description_tb.Text = taregetEvent.Description;
				//Description	"<a href=\"https://drive.google.com/file/d/1wuvk9-uufN87mH3Huw4VhfnJz98hG0KA/view?usp=sharing\">https://drive.google.com/file/d/1wuvk9-uufN87mH3Huw4VhfnJz98hG0KA/view?usp=sharing</a><br>予定議事<br><ol><li>今期予算確認<br></li><li>各課進捗報告</li></ol><br>下記の添付ファイルを各自参照できる様、持参して下さい。<table><tbody><tr><td>PR0003</td><td><a href=\"https://drive.google.com/uc?id=10NTpRCN5xwCIvIT-qeAUZx6T4cM2eyGY&export=download\">PR0003.txt</a></td></tr><tr><td>PR0001</td><td><a href=\"https://drive.google.com/uc?id=1-qsqVlHH1bfaMVJwCeBLHoXlIGpSTrjP&export=download\">PR0001.pptx</a></td></tr><tr><td>PR0003</td><td><a href=\"https://drive.google.com/uc?id=11fP9Krj48m_za3Z5IAVxEFpFQRWjLRU6&export=download\">PR0003.xlsx</a></td></tr></tbody></table><br><a href=\"https://drive.google.com/file/d/1wuvk9-uufN87mH3Huw4VhfnJz98hG0KA/view?usp=drive_web\"><span></span><span></span></a>"	string

				/*		
						<Label Grid.Row="10" Grid.Column="0"   
									Content="添付" HorizontalAlignment="Right"   />
						<Label Grid.Row="10"  Grid.Column="1"  Grid.ColumnSpan="4" Name="drive" Content="親フォルダ" HorizontalAlignment="Left"  Margin="0,0,0,0" VerticalAlignment="Top" />
						<StackPanel Grid.Row="10" Grid.Column="1"  Grid.RowSpan="2" Orientation="Horizontal"
												 Margin="5,0,5,0" >
							<TreeView Width="200" Height="200" Margin="0,0,0,0" />
							<ListBox Width="200"  Height="200" Margin="8,0,0,0"
												 Name="dfile_lb"/>
						</StackPanel>
						<StackPanel Grid.Row="10" Grid.Column="3"  Grid.RowSpan="2" Orientation="Horizontal"
												 Margin="5,0,5,0" >
							<ListBox Name="attach_lb" HorizontalAlignment="Left"  VerticalAlignment="Stretch" 				 
								 */

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
ColorId	null	string
ConferenceData	null	Google.Apis.Calendar.v3.Data.ConferenceData
▶ Created	{2020/05/02 10:58:35}	System.DateTime?
CreatedRaw	"2020-05-02T01:58:35.000Z"	string
▶ Creator	{Google.Apis.Calendar.v3.Data.Event.CreatorData}	Google.Apis.Calendar.v3.Data.Event.CreatorData
ETag	"\"3180052441811000\""	string
◢ End	{Google.Apis.Calendar.v3.Data.EventDateTime}	Google.Apis.Calendar.v3.Data.EventDateTime
Date	null	string
◢ DateTime	{2020/05/06 12:00:00}	System.DateTime?
▶ Date	{2020/05/06 0:00:00}	System.DateTime
Day	6	int
DayOfWeek	Wednesday	System.DayOfWeek
DayOfYear	127	int
Hour	12	int
InternalKind	9.22337E+18	ulong
InternalTicks	6.37244E+17	long
Kind	Local	System.DateTimeKind
Millisecond	0	int
Minute	0	int
Month	5	int
Second	0	int
Ticks	6.37244E+17	long
▶ TimeOfDay	{12:00:00}	System.TimeSpan
Year	2020	int
dateData	9.86062E+18	ulong
▶ 静的メンバー		
DateTimeRaw	"2020-05-06T12:00:00+09:00"	string
ETag	null	string
EndTimeUnspecified	null	bool?
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
◢ Start	{Google.Apis.Calendar.v3.Data.EventDateTime}	Google.Apis.Calendar.v3.Data.EventDateTime
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
◢ TimeOfDay	{10:00:00}	System.TimeSpan
Days	0	int
Hours	10	int
Milliseconds	0	int
Minutes	0	int
Seconds	0	int
Ticks	3.6E+11	long
TotalDays	0.416666667	double
TotalHours	10	double
TotalMilliseconds	36000000	double
TotalMinutes	600	double
TotalSeconds	36000	double
_ticks	3.6E+11	long
▶ 静的メンバー		
Year	2020	int
dateData	9.86062E+18	ulong
▶ 静的メンバー		
DateTimeRaw	"2020-05-06T10:00:00+09:00"	string
ETag	null	string
TimeZone	"Asia/Tokyo"	string
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
		/// 添付ファイルの表示
		/// </summary>
		private void SetAttachments(IList<Google.Apis.Calendar.v3.Data.EventAttachment> attachments)
		{
			string TAG = "SetAttachments";
			string dbMsg = "[GEventEdit]";
			try {
				dbMsg+= "Attachments" + attachments.Count +"件";
				if(0< attachments.Count) {
					foreach (Google.Apis.Calendar.v3.Data.EventAttachment attachment in attachments) {
						string title = attachment.Title;
						string fileId = attachment.FileId;
						string fileUrl = attachment.FileUrl;
						dbMsg += "\r\n" + title + ",fileId="+ fileId + ",fileUrl= " + fileUrl;
						string mimeType = attachment.MimeType;
						string eTag = attachment.ETag;
						dbMsg +=  "  ,mimeType=" + mimeType + ",eTag= " + eTag;
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
						StackPanel sp=new StackPanel();
						sp.Orientation= Orientation.Horizontal;
						sp.Margin = new Thickness(-5);
						//アイコン
						string iconLink = attachment.IconLink;
						dbMsg += "  ,iconLink= " + iconLink;
						Image img = new Image();
						img.Source = new BitmapImage(new Uri(iconLink));
						img.Height = 10;
						img.Width = 10;
						sp.Children.Add(img);
						//ファイルの表示名
						Label lb = new Label();
						lb.Content = title;
						//格納
						sp.Children.Add(lb);
						bt.Content=sp;
						psp.Children.Add(bt);
						//削除ボタン
						Button dbt = new Button();
						dbt.Click += Del_Attachment_bt_Click;
						dbt.DataContext = fileUrl;
						dbt.Style = FindResource("bt-dell") as System.Windows.Style;
						psp.Children.Add(dbt);

						//XAMLへ格納;
						attachments_sp.Children.Add(psp);
					}
				}
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
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// 添付ファイル種億
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