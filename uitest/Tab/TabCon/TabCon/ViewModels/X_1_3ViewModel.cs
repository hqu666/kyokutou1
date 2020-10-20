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
		public string EventComboSelectedIndex { get; set; }

		//表示対象年月
		public DateTime SelectedDateTime;
		/// <summary>
		/// 表示対象年月
		/// </summary>
		public string CurrentDate { get; set; }

		public XamScheduleDataManager dataManager { get; set; }
		public　ListScheduleDataConnector dataConnector { get; set; }
		public ObservableCollection<Resource> resources { get; set; }               //System.Collections.IEnumerable    ListScheduleDataConnector.ResourceItemsSource
		public ObservableCollection<ResourceCalendar> calendars { get; set; }               //ResourceCalendarItemsSource
		public ObservableCollection<Appointment> appointments { get; set; }               //AppointmentItemsSource
																						  //public ObservableCollection<Task> tasks { get; set; }               //TaskItemsSource
																						  //public ObservableCollection<Resource> journals { get; set; }               //JournalItemsSource




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
			ToDaySet();
			CalenderWrite();
		}

		public void CalenderWrite() {
			string TAG = "CalenderWrite";
			string dbMsg = "[MySQLBase]";
			try {
				//リソースとカレンダー
				resources = new ObservableCollection<Resource>();

				Resource resAmanda = new Resource() { Id = "own1", Name = "Amanda" };
				resources.Add(resAmanda);

				calendars = new ObservableCollection<ResourceCalendar>();
				ResourceCalendar calAmanda = new ResourceCalendar() {
					Id = "cal1",
					OwningResourceId = "own1"
				};
				calendars.Add(calAmanda);
				appointments = WriteEvent();


				dataConnector =new ListScheduleDataConnector();
				dataConnector.ResourceItemsSource = resources;
				dataConnector.ResourceCalendarItemsSource = calendars;
				dataConnector.AppointmentItemsSource = appointments;
				 //カレンダー グループを作成し、初期カレンダーを設定
				 dataManager = new XamScheduleDataManager();
				dataManager.DataConnector = dataConnector;
				CalendarGroupCollection calGroups = dataManager.CalendarGroups;
				CalendarGroup calGroup = new CalendarGroup();
				calGroup.InitialCalendarIds = "own1[cal1]";
				calGroups.Add(calGroup);
				/**
				 * 
//最後にコントロールを生成する場合は
XamDayView dayView = new XamDayView();
dayView.DataManager = dataManager;
this.PageRoot.Children.Add(dayView);
*/
				RaisePropertyChanged();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public ObservableCollection<Appointment> WriteEvent()
		{
			string TAG = "WriteEvent";
			string dbMsg = "[MySQLBase]";
			try {

				//予定作成///////////////////////////////////////////
				appointments = new ObservableCollection<Appointment>();
				Appointment app1 = new Appointment() {
					Id = "t1",
					OwningResourceId = "own1",
					OwningCalendarId = "cal1",
					Subject = "Appointment 1",
					Description = "My first appointment",
					// タイムゾーンはこのスニペットで設定しないため、
					// 日付をグリニッジ標準時へ変換します
					Start = DateTime.Today.AddHours(9).AddMinutes(12).ToUniversalTime(),
					End = DateTime.Today.AddHours(11).AddMinutes(42).ToUniversalTime()
				};
				appointments.Add(app1);
				Appointment app2 = new Appointment() {
					Id = "t2",
					OwningResourceId = "own1",
					OwningCalendarId = "cal1",
					Subject = "Appointment 2",
					Description = "My second appointment",
					// タイムゾーンはこのスニペットで設定しないため、
					// 日付をグリニッジ標準時へ変換します
					Start = DateTime.Today.AddHours(10).AddMinutes(12).ToUniversalTime(),
					End = DateTime.Today.AddHours(11).AddMinutes(42).ToUniversalTime()
				};
				appointments.Add(app2);

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
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);

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

		//////////////////////////////////////////////////キャンセル//
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
