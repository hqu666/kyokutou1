using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Infragistics.Controls.Schedules;
using Livet;
using Livet.Commands;

namespace TabCon.ViewModels
{
	public class X_1_4ViewModel : ViewModel {
		public string titolStr = "【スケジュール】リスト表示";
		/// <summary>
		/// 週別/日別区分
		/// </summary>
		public string weekDisplayMode { get; set; }

		public Views.X_1_4 MyView { get; set; }
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
		/// Viewの高さ
		/// </summary>
		public double vHeight { get; set; }
		/// <summary>
		/// Viewを格納するGridの高さ
		/// </summary>
		public double rHeight { get; set; }


		/// <summary>
		/// 予定配列
		/// </summary>
		public ObservableCollection<Appointment> appointments { get; set; }               //AppointmentItemsSource
																						  //public ObservableCollection<Task> tasks { get; set; }               //TaskItemsSource
																						  //public ObservableCollection<Resource> journals { get; set; }               //JournalItemsSource
																						  /// <summary>
																						  /// カレンダ作成の仮ID
																						  /// </summary>
		public string ApOwResourceId = "own1";
		public string ApOwCalendarId = "cal1";

		public MySQL_Util MySQLUtil;

		public X_1_4ViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try {
				dbMsg += ",weekDisplayMode=" + weekDisplayMode;
				dbMsg += ",ApOwResourceId=" + ApOwResourceId + ",ApOwCalendarId=" + ApOwCalendarId;
				EventComboSource = new Dictionary<string, string>()
				{
					{ "0", "すべて" },
					{ "1", "案件イベント" },
					{ "2", "工程イベント" },
					{ "3", "通常イベント" },
				};
				EventComboSelectedIndex = 0;
				vHeight = 860;              //FHDの高さでView外スクロールが出なくなる高さ
				RaisePropertyChanged(); //	"dataManager"
				ToDaySet();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void ReSizeView()
		{
			string TAG = "ReSizeView";
			string dbMsg = "";
			try {
				if (MyView != null) {
					dbMsg += "グリッド" + MyView.RenderSize.Height;
					//if(200< rHeight) {
					//	vHeight = rHeight - 10;
					//}else{
					vHeight = MyView.RenderSize.Height;
					dbMsg += "、View" + vHeight;
					RaisePropertyChanged(); //	"dataManager"
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}


		/// <summary>
		/// カレンダ作成
		/// </summary>
		public void CalenderWrite()
		{
			string TAG = "CalenderWrite";
			string dbMsg = "";
			try {
				ReSizeView();
				DateTime cStart = new DateTime(SelectedDateTime.Year, SelectedDateTime.Month, 1);
				DateTime cEnd = cStart.AddMonths(1).AddSeconds(-1);
				dbMsg += cStart + "～" + cEnd;

				//リソースとカレンダー
				ObservableCollection<Resource> resources = new ObservableCollection<Resource>();

				//1タブ分のデータ//5.リソースとカレンダーをコードビハインドに作成します。///////////////////
				//仮名で作成する
				Resource resAmanda = new Resource() { Id = ApOwResourceId, Name = "Amanda" };
				resources.Add(resAmanda);
				ObservableCollection<ResourceCalendar> calendars = new ObservableCollection<ResourceCalendar>();
				ResourceCalendar calAmanda = new ResourceCalendar() {
					Id = ApOwCalendarId,
					OwningResourceId = ApOwResourceId
				};

				calendars.Add(calAmanda);
				//XAMLプロパティのCalendarDisplayMode="Merged"でタブを表示させない
				//6.その中に 予定のリストを作成//5///////////////////
				ListScheduleDataConnector dataConnector = new ListScheduleDataConnector();
				appointments = WriteEvent(dataConnector);
				//XamMonthView　は　VisibleDates?
				dbMsg += ",appointments=" + appointments.Count + "件";
				//7.コードビハインドを使用して ListScheduleDataConnector を追加//6///////////////////
				//			ListScheduleDataConnector dataConnector = new ListScheduleDataConnector();
				dataConnector.ResourceItemsSource = resources;
				dataConnector.ResourceCalendarItemsSource = calendars;
				dataConnector.AppointmentItemsSource = appointments;
				//dataConnector.JournalItemsSource = journals;

				//9.カレンダー グループを作成し、初期カレンダーを設定////7//8はXAML
				dataManager = new XamScheduleDataManager();
				dataManager.DataConnector = dataConnector;
				//追加//////////
				dataManager.CurrentUserId = ApOwResourceId;
				//表示範囲を一月分に限定する//////////
				ScheduleSettings cSettings = new ScheduleSettings();
				cSettings.MinDate = cStart;
				cSettings.MaxDate = cEnd;
				//			cSettings.AppointmentSettings.IsAddViaClickToAddEnabled = true;
				dataManager.Settings = cSettings;
				///////////////////////////////////////追加//
				CalendarGroupCollection calGroups = dataManager.CalendarGroups;
				CalendarGroup calGroup = new CalendarGroup();
				calGroup.InitialCalendarIds = ApOwResourceId + "[" + ApOwCalendarId + "]";                     ///"own1[cal1]";
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
		public ObservableCollection<Appointment> WriteEvent(ListScheduleDataConnector dataConnector)
		{
			string TAG = "WriteEvent";
			string dbMsg = "";
			try {
				dbMsg += "" + SelectedDateTime;
				//予定取得///////////////////////////////////////////
				appointments = new ObservableCollection<Appointment>();
				ActivityCategoryCollection activityCategoryCollection = new ActivityCategoryCollection();
				//MySQLUtil = new MySQL_Util();
				//if (MySQLUtil.MySqlConnection()){
				//	ObservableCollection<object> rTable = MySQLUtil.ReadTable( "t_events");
				//	ObservableCollection<Models.t_events> tEvents = new ObservableCollection<Models.t_events>();

				//	MySQLUtil.DisConnect();
				//}
				//実データが無ければテストデータ作成
				if (appointments.Count < 1) {
					int AppointmentCount = 1;
					DateTime dt = DateTime.Now;
					// タイムゾーンはこのスニペットで設定しないため、日付をグリニッジ標準時へ変換します
					DateTime StartDT = DateTime.Today.AddHours(SelectedDateTime.Hour).ToUniversalTime();
					DateTime EndDT = StartDT.AddHours(1).AddMinutes(30);
					// Infragistics.Controls.Schedules のメタデータ
					for (AppointmentCount = 1; AppointmentCount < 10; AppointmentCount++) {
						dbMsg += "[" + AppointmentCount + "]" + StartDT + "～" + EndDT;
						string categoryName = "TestCategory" + AppointmentCount;
						//背景色
						ColorConverter cc = new ColorConverter();
						int rCode = AppointmentCount * 20;
						if (255 < rCode) {
							rCode = rCode % 255;
						}
						string rStr = rCode.ToString("X");
						if (rStr.Length < 2) {
							rStr = 0 + rStr;
						}
						int gCode = rCode * AppointmentCount;
						if (255 < gCode) {
							gCode = gCode % 255;
						}
						string gStr = gCode.ToString("X");
						if (gStr.Length < 2) {
							gStr = 0 + gStr;
						}
						int bCode = gCode * AppointmentCount;
						if (255 < bCode) {
							bCode = bCode % 255;
						}
						string bStr = bCode.ToString("X");
						if (bStr.Length < 2) {
							bStr = 0 + bStr;
						}
						Color color = (Color)cc.ConvertFrom("#FF" + rStr + gStr + bStr);
						dbMsg += ",color=" + color;
						ActivityCategory activityCategory = new ActivityCategory() {
							CategoryName = categoryName,
							Description = "表示データが無い場合のテストデータ",
							Color = color
						};
						activityCategoryCollection.Add(activityCategory);
						Appointment app1 = new Appointment() {
							Id = "t" + AppointmentCount,
							OwningResourceId = ApOwResourceId,
							OwningCalendarId = ApOwCalendarId,
							Subject = AppointmentCount + "つ目のタイトル",
							Description = AppointmentCount + "つ目の詳細",
							Location = "場所は第" + AppointmentCount + "会議室",
							Categories = categoryName,
							StartTimeZoneId = "Tokyo Standard Time",
							EndTimeZoneId = "Tokyo Standard Time",
							Start = StartDT,
							End = EndDT,
							LastModifiedTime = DateTime.Now
						};
						appointments.Add(app1);
						//次の日時設定
						if (8 == AppointmentCount) {
							StartDT = SelectedDateTime.AddMonths(-1);
							EndDT = StartDT.AddMonths(2);
						} else if (6 == AppointmentCount) {
							StartDT = SelectedDateTime.AddDays(-4);
							EndDT = StartDT.AddDays(8);
						} else if (4 == AppointmentCount) {
							StartDT = SelectedDateTime.AddDays(-1);
							EndDT = StartDT.AddDays(2);
						} else {
							StartDT = StartDT.AddHours(1);
							EndDT = StartDT.AddHours(1).AddMinutes(30);
						}
					}
				}
				//	IsTimeZoneNeutral=false,		//trueでStart/Endが標準時（-9時間）になる
				dataConnector.ActivityCategoryItemsSource = activityCategoryCollection;
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
					string msgStr = EventComboSource[value].ToString() + "が選択されました";
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
			string dbMsg = "";
			try {
				SelectedDateTime = DateTime.Now;
				dbMsg += "今日は" + SelectedDateTime;
				CurrentDate = String.Format("{0:yyyy年MM月dd日}", SelectedDateTime);
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
			string dbMsg = "";
			try {
				if (weekDisplayMode.Equals("Week")) {
					SelectedDateTime = SelectedDateTime.AddDays(7);
				} else {
					SelectedDateTime = SelectedDateTime.AddDays(1);
				}
				dbMsg += SelectedDateTime + "に進める";
				CurrentDate = String.Format("{0:yyyy年MM月dd日}", SelectedDateTime);
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
			string dbMsg = "";
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
			dbMsg = "[X_1_4ViewModel]" + dbMsg;
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[X_1_4ViewModel]" + dbMsg;
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