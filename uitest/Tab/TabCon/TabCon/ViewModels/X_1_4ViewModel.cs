﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Infragistics.Controls.Schedules;
using Livet;
using Livet.Commands;
using TabCon.Models;

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
		/// イベントが有る日の配列
		/// </summary>
		public ObservableCollection<ADay> EDays { get; set; }

		/// <summary>
		/// 予定配列
		/// </summary>
		public ObservableCollection<t_events> Events { get; set; }  

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
			//	ReSizeView();
				DateTime cStart = new DateTime(SelectedDateTime.Year, SelectedDateTime.Month, 1);
				DateTime cEnd = cStart.AddMonths(1).AddSeconds(-1);
				dbMsg += cStart + "～" + cEnd;
				Events=WriteEvent();
				ObservableCollection<t_events> orderedByStart =
					new ObservableCollection<t_events>(
							 Events.OrderBy(rec => rec.event_date_start)
										.ThenBy(rec => rec.event_time_start)
										.ThenBy(rec => rec.event_date_end)
							);
				DateTime tDate = orderedByStart.First().event_date_start;
				EDays = new  ObservableCollection<ADay>();
				List<string>summarys = new List<string>();
				ObservableCollection<t_events> dEvents = new ObservableCollection<t_events>();
				ADay aDay = new ADay(tDate, summarys, dEvents);
				foreach (t_events ev in orderedByStart) {
					if (tDate < ev.event_date_start) {          // && 0< dEvents.Count
						dbMsg +=":開始"+ tDate + ">>" + ev.event_date_start + ":" + EDays + "件";
						aDay = new ADay(tDate, summarys, dEvents);
						EDays.Add(aDay);
						summarys = new List<string>();
						dEvents = new ObservableCollection<t_events>();
					}
					tDate = ev.event_date_start;
					dEvents.Add(ev);
					summarys.Add(ev.summary);
				}
				 aDay = new ADay(tDate, summarys, dEvents);
				EDays.Add(aDay);

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
		public ObservableCollection<Models.t_events> WriteEvent()
		{
			string TAG = "WriteEvent";
			string dbMsg = "";
			try {
				dbMsg += "" + SelectedDateTime;
				//予定取得///////////////////////////////////////////
				Events = new ObservableCollection<Models.t_events>();
				ActivityCategoryCollection activityCategoryCollection = new ActivityCategoryCollection();
				MySQLUtil = new MySQL_Util();
				if (MySQLUtil.MySqlConnection()) {
					ObservableCollection<object> rTable = MySQLUtil.ReadTable("t_events");
					if(rTable != null) {
						dbMsg += "rTable" + rTable.Count + "件";
					}

					MySQLUtil.DisConnect();
				}
				//実データが少なければテストデータ作成
				if (Events.Count < 10) {
					int EventCount = Events.Count+1;
					int endCount = EventCount + 10;
					DateTime dt = DateTime.Now;
					// タイムゾーンはこのスニペットで設定しないため、日付をグリニッジ標準時へ変換します
					DateTime StartDT = DateTime.Today.AddHours(SelectedDateTime.Hour).ToUniversalTime();
					DateTime EndDT = StartDT.AddHours(1).AddMinutes(30);
					// Infragistics.Controls.Schedules のメタデータ
					for (EventCount = Events.Count + 1; EventCount < endCount; EventCount++) {
						dbMsg += "\r\n[" + EventCount + "]" + StartDT + "～" + EndDT;
						Models.t_events OneEvent = new Models.t_events();
						OneEvent.id = 99990 + EventCount;
						OneEvent.event_title = "Test" + EventCount;         //タイトル
						OneEvent.event_date_start =StartDT.Date;            //開始日
						OneEvent.event_time_start = StartDT.Hour;           //開始時刻
						OneEvent.event_date_end = EndDT.Date;               //終了日
						OneEvent.event_time_end = EndDT.Hour;               //終了時刻
						OneEvent.event_is_daylong =false;                           //終日
						if (OneEvent.event_date_start < OneEvent.event_date_end) {
							OneEvent.event_is_daylong = true;
							OneEvent.event_time_start = 0;           //開始時刻
							OneEvent.event_time_end = 23;               //終了時刻
						}
						OneEvent.event_place = "第" + EventCount + "会議室";                           //場所
						OneEvent.event_memo =  EventCount + "つ目のメモ";                           //メモ
						OneEvent.google_id = "";                           //GoogleイベントID:未登録は空白文字
						OneEvent.event_status = 1;                           //ステータス
						OneEvent.event_type = 1;                           //イベント種別

						string summary = "終日";
						if (!OneEvent.event_is_daylong) {
							summary = OneEvent.event_time_start + "～" + OneEvent.event_time_end;
						}
						summary += ": " + OneEvent.event_title + " : " + OneEvent.event_place + " : " + OneEvent.event_memo;
						OneEvent.summary = summary;
						//背景色
						ColorConverter cc = new ColorConverter();
						int rCode = EventCount * 20;
						if (255 < rCode) {
							rCode = rCode % 255;
						}
						string rStr = rCode.ToString("X");
						if (rStr.Length < 2) {
							rStr = 0 + rStr;
						}
						int gCode = rCode * EventCount;
						if (255 < gCode) {
							gCode = gCode % 255;
						}
						string gStr = gCode.ToString("X");
						if (gStr.Length < 2) {
							gStr = 0 + gStr;
						}
						int bCode = gCode * EventCount;
						if (255 < bCode) {
							bCode = bCode % 255;
						}
						string bStr = bCode.ToString("X");
						if (bStr.Length < 2) {
							bStr = 0 + bStr;
						}
						Color color = (Color)cc.ConvertFrom("#FF" + rStr + gStr + bStr);
						dbMsg += ",color=" + color;
						OneEvent.event_bg_color = color.ToString();                           //背景色
						CS_Util Util = new CS_Util();
						if (Util.IsForegroundWhite(OneEvent.event_bg_color)) {
							dbMsg += "に白文字";
							OneEvent.event_font_color = Brushes.White.ToString();  
						}else{
							dbMsg += "に黒文字";
							OneEvent.event_font_color = Brushes.Black.ToString();
						}
						//1レコード追加
						Events.Add(OneEvent);
						//次の日時設定
						if (8 == EventCount) {
							StartDT = SelectedDateTime.AddMonths(-1);
							EndDT = StartDT.AddMonths(2);
						} else if (6 == EventCount) {
							StartDT = SelectedDateTime.AddDays(-4);
							EndDT = StartDT.AddDays(8);
						} else if (4 == EventCount) {
							StartDT = SelectedDateTime.AddDays(-1);
							EndDT = StartDT.AddDays(2);
						} else {
							StartDT = StartDT.AddHours(1);
							EndDT = StartDT.AddHours(1).AddMinutes(30);
						}
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return Events;
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
		
		/// <summary>
		/// 一日分の箱
		/// </summary>
		public class ADay {
			/// <summary>
			/// 対象日
			/// </summary>
			public DateTime date { get; }
			/// <summary>
			/// 表示する要約
			/// </summary>
			public List<string> summarys { get; }

			public ObservableCollection<t_events> events { get; set; }
			/// <summary>
			/// 一日分の箱
			/// </summary>
			public ADay(DateTime _date, List<string> _summarys , ObservableCollection<t_events> _events)
			{
				this.date = _date;
				this.summarys = _summarys;
				this.events = _events;
			}
		}
	}
}