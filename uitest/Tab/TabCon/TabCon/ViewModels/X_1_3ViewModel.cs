using Infragistics.Controls.Schedules;
using Livet;
using Livet.Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TabCon.ViewModels {
	public class X_1_3ViewModel : ViewModel {
		public string titolStr = "【スケジュール】月別表示";

		public Views.X_1_3 MyView { get; set; }
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
		/// XamMonthViewへBindingするカレンダの全内容
		/// </summary>
		public XamScheduleDataManager dataManager { get; set; }
		//public　ListScheduleDataConnector dataConnector { get; set; }
		//public ObservableCollection<Resource> resources { get; set; }               //System.Collections.IEnumerable    ListScheduleDataConnector.ResourceItemsSource
		//public ObservableCollection<ResourceCalendar> calendars { get; set; }               //ResourceCalendarItemsSource
		public XamMonthView cView { get; set; }

		/// <summary>
		/// 予定配列
		/// </summary>
		public ObservableCollection<Appointment> appointments { get; set; }               //AppointmentItemsSource
																						  //public ObservableCollection<Task> tasks { get; set; }               //TaskItemsSource
																						  //public ObservableCollection<Resource> journals { get; set; }               //JournalItemsSource
		/// <summary>
		/// カレンダ作成の仮ID
		/// </summary>
		public string AppointmentOwningResourceId = "own1";
		public string AppointmentOwningCalendarId = "cal1";

		public MySQL_Util MySQLUtil;

		public X_1_3ViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			EventComboSource = new Dictionary<string, string>()
			{
				{ "0", "すべて" },
				{ "1", "案件イベント" },
				{ "2", "工程イベント" },
				{ "3", "通常イベント" },
			};
			EventComboSelectedIndex = 0;
			RaisePropertyChanged(); //	"dataManager"
			ToDaySet();
		}

		/// <summary>
		/// カレンダ作成
		/// </summary>
		public void CalenderWrite() {
			string TAG = "CalenderWrite";
			string dbMsg = "[MySQLBase]";
			try {
				DateTime cStart = new DateTime(SelectedDateTime.Year, SelectedDateTime.Month, 1);
				DateTime cEnd = cStart.AddMonths(1).AddSeconds(-1);
				dbMsg += cStart + "～" + cEnd;

				//リソースとカレンダー
				ObservableCollection<Resource> resources = new ObservableCollection<Resource>();

				//1タブ分のデータ//5.リソースとカレンダーをコードビハインドに作成します。///////////////////
				//仮名で作成する
				Resource resAmanda = new Resource() { Id = AppointmentOwningResourceId, Name = "Amanda" };
				resources.Add(resAmanda);
				ObservableCollection<ResourceCalendar> calendars = new ObservableCollection<ResourceCalendar>();
				ResourceCalendar calAmanda = new ResourceCalendar() {
					Id = AppointmentOwningCalendarId,
					OwningResourceId = AppointmentOwningResourceId
				};

				calendars.Add(calAmanda);
				//XAMLプロパティのCalendarDisplayMode="Merged"でタブを表示させない
				//6.その中に 予定のリストを作成//5///////////////////
				appointments = WriteEvent(calAmanda, resAmanda);
				//XamMonthView　は　VisibleDates?
				dbMsg += ",appointments=" + appointments.Count + "件";
				//7.コードビハインドを使用して ListScheduleDataConnector を追加//6///////////////////
				ListScheduleDataConnector　dataConnector = new ListScheduleDataConnector();
				dataConnector.ResourceItemsSource = resources;
				dataConnector.ResourceCalendarItemsSource = calendars;
				dataConnector.AppointmentItemsSource = appointments;
				//dataConnector.JournalItemsSource = journals;

				//9.カレンダー グループを作成し、初期カレンダーを設定////7//8はXAML
				dataManager = new XamScheduleDataManager();
				dataManager.DataConnector = dataConnector;
				//追加//////////
				dataManager.CurrentUserId = AppointmentOwningResourceId;
				//表示範囲を一月分に限定する//////////
				ScheduleSettings cSettings = new ScheduleSettings();
				cSettings.MinDate = cStart;
				cSettings.MaxDate = cEnd;
				dataManager.Settings = cSettings;
				///////////////////////////////////////追加//
				CalendarGroupCollection calGroups = dataManager.CalendarGroups;
				CalendarGroup calGroup = new CalendarGroup();
				calGroup.InitialCalendarIds = AppointmentOwningResourceId + "[" + AppointmentOwningCalendarId + "]";                     ///"own1[cal1]";
				calGroups.Add(calGroup);
				dbMsg += ",CurrentUserId=" + dataManager.CurrentUserId;
				////10.コードビハインドでGirid（PageRoot）にコントロールを生成する場合//////9//
				//XamMonthView cView = new XamMonthView();
				//cView.DataManager = dataManager;
				////MyView.PageRoot.Children.Add(cView);

				RaisePropertyChanged(); //	"dataManager"
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 予定作成
		/// </summary>
		/// <returns></returns>
		public ObservableCollection<Appointment> WriteEvent(ResourceCalendar RCalendar, Resource resource)
		{
			string TAG = "WriteEvent";
			string dbMsg = "[MySQLBase]";
			try {
				//予定取得///////////////////////////////////////////
	//			int AppointmentCount = 1;
				DateTime dt = DateTime.Now;
				// タイムゾーンはこのスニペットで設定しないため、日付をグリニッジ標準時へ変換します
				DateTime StartDT = DateTime.Today.AddHours(dt.Hour).ToUniversalTime();
				DateTime EndDT = StartDT.AddHours(1).AddMinutes(30);

				//MySQLUtil = new MySQL_Util();
				//if (MySQLUtil.MySqlConnection()){
				//	ObservableCollection<object> rTable = MySQLUtil.ReadTable( "t_events");
				//	ObservableCollection<Models.t_events> tEvents = new ObservableCollection<Models.t_events>();

				//	MySQLUtil.DisConnect();
				//}


				// Infragistics.Controls.Schedules のメタデータ
				appointments = new ObservableCollection<Appointment>();
				for (int AppointmentCount = 1; AppointmentCount < 4; AppointmentCount++) {
					dbMsg += "[" + AppointmentCount + "]" + StartDT + "～" + EndDT;
					Appointment app1 = new Appointment() {
						Id = "t" + AppointmentCount,
						OwningResourceId = AppointmentOwningResourceId,
						OwningCalendarId = AppointmentOwningCalendarId,
						Subject = "Test" + AppointmentCount,
						Description = "My first appointment",
						IsVisible = true,

						Start = StartDT,
						End = EndDT
						// タイムゾーンはこのスニペットで設定しないため、
						// 日付をグリニッジ標準時へ変換します
						//Start = DateTime.Today.AddHours(9).AddMinutes(12).ToUniversalTime(),
						//End = DateTime.Today.AddHours(11).AddMinutes(42).ToUniversalTime()

					};
					appointments.Add(app1);
					StartDT = StartDT.AddHours(1);
					EndDT = StartDT.AddHours(1).AddMinutes(30);
				}
				/*
					OwningCalendar = RCalendar,
					OwningResource = resource,
					OriginalOccurrenceStart = StartDT,
					OriginalOccurrenceEnd = EndDT,
					LastModifiedTime = dt
					
					
					-		AppointmentItemsSource	Count = 2	System.Collections.IEnumerable {System.Collections.ObjectModel.ObservableCollection<Infragistics.Controls.Schedules.Appointment>}
				-		[0]	Id="t1", Range={2020/11/09 0:12:00}-{2020/11/09 2:42:00}, OwningResourceId="own1", OwningCalendarId="cal1", Description="My first appointment", DataItem=null	Infragistics.Controls.Schedules.Appointment
						
						Categories	null	string

						EndTimeZoneId	null	string
						Error	null	Infragistics.DataErrorInfo
						HasListeners	false	bool

						IsLocked	null	bool?
						IsOccurrence	false	bool
						IsOccurrenceDeleted	false	bool
						IsRecurrenceRoot	false	bool
						IsTimeZoneNeutral	false	bool
						IsVariance	false	bool
						IsVisibleResolved	true	bool
						Location	null	string

						MaxOccurrenceDateTime	null	System.DateTime?

				+		Metadata	{Infragistics.Controls.Schedules.DictionaryMetadataPropertyValueStore}	Infragistics.Controls.Schedules.MetadataPropertyValueStore {Infragistics.Controls.Schedules.DictionaryMetadataPropertyValueStore}

						Recurrence	null	Infragistics.Controls.Schedules.RecurrenceBase
						RecurrenceVersion	0	int
						Reminder	null	Infragistics.Controls.Schedules.Reminder
						ReminderEnabled	false	bool
				+		ReminderInterval	{00:00:00}	System.TimeSpan
						RootActivity	null	Infragistics.Controls.Schedules.ActivityBase
						RootActivityId	null	string

						StartTimeZoneId	null	string
						VariantProperties	0	long

				 */
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return appointments;
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
					string msgStr = EventComboSource[ value ].ToString()+  "が選択されました";
		//			MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);

					//		ReadTable(value);
				}
			}
		}
		#endregion

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
			string dbMsg = "[MySQLBase]";
			try {
				SelectedDateTime = SelectedDateTime.AddMonths(-1);
				dbMsg += SelectedDateTime + "に戻す";
				CurrentDate = String.Format("{0:yyyy年MM月}", SelectedDateTime);
				dbMsg += ">>" + CurrentDate;
				RaisePropertyChanged("CurrentDate");
				CalenderWrite();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		//本日/////////////////////////////////////////////////////////////////////////
		public ViewModelCommand SetToDay {
			get { return new Livet.Commands.ViewModelCommand(ToDaySet); }
		}
		/// <summary>
		/// 本日に指定
		/// </summary>
		public void ToDaySet()
		{
			string TAG = "ToDaySet";
			string dbMsg = "[MySQLBase]";
			try {
				SelectedDateTime = DateTime.Now;
				dbMsg += "今日は" + SelectedDateTime;
				CurrentDate = String.Format("{0:yyyy年MM月}", SelectedDateTime);
				dbMsg += ">>" + CurrentDate;
				RaisePropertyChanged("CurrentDate");
				CalenderWrite();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//進める/////////////////////////////////////////////////////////////////////////
		public ViewModelCommand SendDate {
			get { return new Livet.Commands.ViewModelCommand(DateSend); }
		}
		/// <summary>
		/// 進める
		/// </summary>
		public void DateSend()
		{
			string TAG = "DateSend";
			string dbMsg = "[MySQLBase]";
			try {
				SelectedDateTime = SelectedDateTime.AddMonths(1);
				dbMsg += SelectedDateTime + "に進める";
				CurrentDate = String.Format("{0:yyyy年MM月}", SelectedDateTime);
				dbMsg += ">>" + CurrentDate;
				RaisePropertyChanged("CurrentDate");
				CalenderWrite();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//登録/////////////////////////////////////////////////////////////////////////
		public ViewModelCommand RegistrationEvent {
			get { return new Livet.Commands.ViewModelCommand(EventRegistration); }
		}
		/// <summary>
		/// Googleカレンダーに反映
		/// </summary>
		public void EventRegistration()
		{
			string TAG = "EventRegistration";
			string dbMsg = "[MySQLBase]";
			try {

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//////////////////////////////////////////////////登録//
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
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
