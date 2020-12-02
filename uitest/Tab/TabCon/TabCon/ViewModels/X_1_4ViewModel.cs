using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;
using MySql.Data.MySqlClient;
using TabCon.Models;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace TabCon.ViewModels
{
	public class X_1_4ViewModel : ViewModel {
		public string titolStr = "【スケジュール】リスト表示";
		public MySQL_Util MySQLUtil;
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
		/// Viewの高さ
		/// </summary>
		public double vHeight { get; set; }
		/// <summary>
		/// Viewを格納するGridの高さ
		/// </summary>
		public double DateColWidth { get; set; }

		/// <summary>
		/// イベントが有る日の配列
		/// </summary>
		public ObservableCollection<ADay> EDays { get; set; }
		/// <summary>
		/// 選択された日
		/// </summary>
		public ADay TatagetDay{ get; set; }
		/// <summary>
		/// 開始日順の対象イベント配列
		/// </summary>
		public ObservableCollection<t_events> OrderedByStart { get; set; }
		public int selectedDateIndex { set; get; }

		public int selectedIndex { set; get; }

		#region TargetEvent変更通知プロパティ
		private t_events _TargetEvent;
		/// <summary>
		/// 操作対象の予定
		/// </summary>
		public t_events TargetEvent {
			get { return _TargetEvent; }
			set {
				if (_TargetEvent == value)
					return;
				_TargetEvent = value;
				RaisePropertyChanged("TargetEvent");
				//if(_TargetEvent != null) {
				//	Edit();
				//}
			}
		}
		#endregion

		/// <summary>
		/// ローディングダイアログクラス
		/// </summary>
		public Controls.WaitingDLog waitingDLog ;

		/// <summary>
		/// スケジュールリスト：ここからスタート
		/// </summary>
		public X_1_4ViewModel()
		{
			DateColWidth = 200.0;
			Initialize();
			//			DoubleClickCommand = CreateCommand(param => MyDoubleClickCommand(param));WPF用 ViewModelの基底クラス
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
			string TAG = MethodBase.GetCurrentMethod().Name;
			string dbMsg = "";
			try {
				waitingDLog = new Controls.WaitingDLog();
				waitingDLog.Show(); //.ShowDialog(); だとこのオブジェクトは別のスレッドに所有されているため、呼び出しスレッドはこのオブジェクトにアクセスできません。
									//waitingDLog=wDLog.Result;  だと　呼び出しスレッドは、多数の UI コンポーネントが必要としているため、STA である必要があります。
									//	waitingDLog.ShowDialog();  // Show() にするとWaitingCircleが回らない
									//						///////////WindowにユーザーコントロールをWindowに読み込む方法//
									// this.EDays = CalenderWriteBody(waitingDLog);
				Task<ObservableCollection<ADay>> EDays = Task.Run(() => {
					//waitingDLog.Dispatcher.Invoke((Action)(() => {
					//	waitingDLog.ShowDialog();  // Show() にするとWaitingCircleが回らない
					//}));　だと表示もされない
					//waitingDLog.ShowDialog(); だとこのオブジェクトは別のスレッドに所有されているため、呼び出しスレッドはこのオブジェクトにアクセスできません。
					return CalenderWriteBody(waitingDLog);
				});
				EDays.Wait();

				//waitingDLog.Close();
				waitingDLog.QuitMe();
				waitingDLog = null;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// カレンダ作成本体
		/// </summary>
		private ObservableCollection<ADay> CalenderWriteBody(Controls.WaitingDLog waitingDLog)
		{
			//
			string TAG = MethodBase.GetCurrentMethod().Name;
			string dbMsg = "";
			EDays = new ObservableCollection<ADay>();
			try {
				DateTime cStart = new DateTime(SelectedDateTime.Year, SelectedDateTime.Month, 1);
				DateTime cEnd = cStart.AddMonths(1).AddSeconds(-1);
				string msgStr = cStart + "～" + cEnd + "の予定を読み出しています"; ;
				dbMsg += msgStr;
				waitingDLog.SetMes(msgStr);
				//Application.Current.Dispatcher.Invoke(new System.Action(() => this.waitingDLog.SetMes(msgStr)));
				ObservableCollection<t_events> Events = WriteEvent();
				msgStr = Events.Count + "件の予定が有りました";

				//	Application.Current.Dispatcher.Invoke(new System.Action(() => waitingDLog.SetMes(msgStr)));
				//対象期間中の予定を開始日時が早いものから配列化
				OrderedByStart =
					new ObservableCollection<t_events>(
							 Events.OrderBy(rec => rec.event_date_start)
										.ThenBy(rec => rec.event_time_start)
										.ThenBy(rec => rec.event_date_end)
							);
				//日毎にまとめる
				DateTime tDate = OrderedByStart.First().event_date_start;
				List<string> summarys = new List<string>();
				ObservableCollection<t_events> dEvents = new ObservableCollection<t_events>();
				ADay aDay = new ADay(tDate, summarys, dEvents, this);
				int cIndex = 0;

				foreach (t_events ev in OrderedByStart) {
					if (tDate < ev.event_date_start) {          // && 0< dEvents.Count
						msgStr = ":開始" + tDate + ">>" + ev.event_date_start + ":" + EDays.Count + "件";
						//				Application.Current.Dispatcher.Invoke(new System.Action(() => waitingDLog.SetMes(msgStr)));
						dbMsg += msgStr;
						aDay = new ADay(tDate, summarys, dEvents, this);
						EDays.Add(aDay);
						summarys = new List<string>();
						dEvents = new ObservableCollection<t_events>();
						cIndex=0;
					}
					tDate = ev.event_date_start;
					ev.childIndex = cIndex;
					cIndex++;
					dEvents.Add(ev);
					summarys.Add(ev.summary);
				}
				aDay = new ADay(tDate, summarys, dEvents, this);
				EDays.Add(aDay);
				dbMsg += ",DateColWidth=" + DateColWidth;
				RaisePropertyChanged(); //	"dataManager"
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return EDays;
		}

		/// <summary>
		/// 予定作成
		/// </summary>
		/// <returns></returns>
		public ObservableCollection<Models.t_events> WriteEvent()
		{
			string TAG = MethodBase.GetCurrentMethod().Name;
			string dbMsg = "";
			ObservableCollection<t_events> Events = new ObservableCollection<t_events>();
			try {
				dbMsg += "" + SelectedDateTime;
				CS_Util Util = new CS_Util();
				//予定取得///////////////////////////////////////////
	//			ActivityCategoryCollection activityCategoryCollection = new ActivityCategoryCollection();
				MySQLUtil = new MySQL_Util();
				if (MySQLUtil.MySqlConnection()) {
					//ObservableCollection<object> rTable = MySQLUtil.ReadTable("t_events");
					//if(rTable != null) {
					//	dbMsg += "rTable" + rTable.Count + "件";
					//}

					using (MySqlConnection mySqlConnection = new MySqlConnection(Constant.ConnectionString)) {
						mySqlConnection.Open();
						using (MySqlCommand command = mySqlConnection.CreateCommand()) {
							command.CommandText = $"SELECT * FROM {"t_events"}";
							using (MySqlDataReader reader = command.ExecuteReader()) {
								//int RecordCount = reader.;
								//dbMsg += "," + RecordCount + "レコード";
								int FieldCount = reader.FieldCount;
								dbMsg += "," + FieldCount + "項目";

								//一行づつデータを読み取りモデルに書込む
								while (reader.Read()) {
									t_events OneEvent = new t_events();
									for (int i = 0; i < FieldCount; i++) {
										string rName = reader.GetName(i);
										string rType = reader.GetFieldType(i).Name;
										dbMsg += "\r\n(" + i + ")" + rName + ",rType=" + rType;
										var rVar = reader.GetValue(i);
										dbMsg += ",rVar=" + rVar;
										if (rVar == null || rVar.Equals("") || reader.IsDBNull(i)) {
											dbMsg += ">>スキップ" ;
										} else if (rName.Equals("id")) {
											OneEvent.id = (int)rVar;
										}else if(rName.Equals("event_title")) {
											OneEvent.event_title = (string)rVar;         //タイトル
										} else if (rName.Equals("event_date_start")) {
											OneEvent.event_date_start = (DateTime)rVar;              //開始日
										} else if (rName.Equals("event_time_start")) {
											OneEvent.event_time_start = (int)rVar;           //開始時刻
										} else if (rName.Equals("event_date_end")) {
											OneEvent.event_date_end = (DateTime)rVar;                  //終了日
										} else if (rName.Equals("event_time_end")) {
											OneEvent.event_time_end = (int)rVar;             //終了時刻
										} else if (rName.Equals("event_is_daylong")) {
											OneEvent.event_is_daylong = (bool)rVar;                       //終日
										} else if (rName.Equals("event_place")) {
											OneEvent.event_place = (string)rVar;                           //場所
										} else if (rName.Equals("event_memo")) {
											OneEvent.event_memo = (string)rVar;                              //メモ
										} else if (rName.Equals("google_id")) {
											OneEvent.google_id = (string)rVar;                        //GoogleイベントID:未登録は空白文字
										} else if (rName.Equals("event_status")) {
											OneEvent.event_status = (int)rVar;                       //ステータス
										} else if (rName.Equals("event_type")) {
											OneEvent.event_type = (SByte)rVar;                           //イベント種別
										} else if (rName.Equals("event_bg_color")) {
											OneEvent.event_bg_color = (string)rVar;                       //背景色
										}
										dbMsg += ">>読取";
										//	}
									}
									//string rCol = OneEvent.event_bg_color;
									//if (rCol == null || rCol.Equals("")) {
										if (Util.IsForegroundWhite(OneEvent.event_bg_color)) {
											dbMsg += "に白文字";
											OneEvent.event_font_color = Brushes.White.ToString();
										} else {
											dbMsg += "に黒文字";
											OneEvent.event_font_color = Brushes.Black.ToString();
										}
									//} else {
									//	dbMsg += "背景未指定";
									//}
									if (OneEvent.event_date_start < OneEvent.event_date_end) {
										OneEvent.event_is_daylong = true;
										OneEvent.event_time_start = 0;           //開始時刻
										OneEvent.event_time_end = 23;               //終了時刻
									}
									string summary = "";
									if (!OneEvent.event_is_daylong) {
										summary = OneEvent.event_time_start + "～" + OneEvent.event_time_end;
									}else{
										summary += "～" + String.Format("{0:yyyy/MM/dd}", OneEvent.event_date_end);
									}
									summary += ": " + OneEvent.event_title + " : " + OneEvent.event_place + " : " + OneEvent.event_memo;
									OneEvent.summary = summary;
					//				OneEvent.isSetect = false;
									Events.Add(OneEvent);
								}
							}
						}
					}
					int rCount = Events.Count;
					dbMsg += ",Events=" + rCount + "件";
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
						OneEvent.id = -1;
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
						OneEvent.event_type = 3;                           //イベント種別:通常イベント

						string summary = "";
						if (!OneEvent.event_is_daylong) {
							summary = OneEvent.event_time_start + "～" + OneEvent.event_time_end;
						} else {
							summary += "～" + String.Format("{0:yyyy/MM/dd}", OneEvent.event_date_end);
						}
						summary += ": " + OneEvent.event_title + " : " + OneEvent.event_place + " : " + OneEvent.event_memo;
						OneEvent.summary = summary;
			//			OneEvent.isSetect = false;
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

		//レコードクリック/////////////////////////////////////////////////////////////////////////
		#region EditCommand
		private ViewModelCommand _EditCommand;

		public ViewModelCommand EditCommand {
			get {
				string TAG = "EditCommand";
				string dbMsg = "";
				try {
					if (_EditCommand == null) {
						dbMsg += ">>起動時";
						_EditCommand = new ViewModelCommand(Edit, CanEdit);
					}else{
						if(this.TargetEvent != null) {
							dbMsg += this.TargetEvent.ToString();
						}else{
							dbMsg += ">>選択行無し";
						}
					}
					MyLog(TAG, dbMsg);
				} catch (Exception er) {
					MyErrorLog(TAG, dbMsg, er);
				}
				return _EditCommand;
			}
		}

		/// <summary>
		/// 選択されたアイテムが有るか？
		/// 無ければここで処理終了
		/// </summary>
		/// <returns></returns>
		public bool CanEdit()
		{
			string TAG = "EditCommand";
			string dbMsg = "";
			bool retBool = true;
			try {
		//		dbMsg += "[" + selectedDateIndex + "]";
				if (this.TargetEvent != null) {
					dbMsg += "、選択日＝" + TargetEvent.event_date_start;
				}
			//	dbMsg += "[selectedIndex＝" + selectedIndex + "]";
				if (this.TargetEvent == null) {
					dbMsg += ">>処理対象取得できず";
					retBool = false;
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retBool;
		}

		public void Edit()
		{
			string TAG = "Edit";
			string dbMsg = "";
			try {
				using (var vm = new X_2ViewModel(this.TargetEvent)) {
					Messenger.Raise(new TransitionMessage(vm, "EditCommand"));
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}
		#endregion //public ICommand DoubleClickCommand { get; private set; }
		/////////////////////////////////////////////////////////////////////////レコードクリック//

		/// <summary>
		/// イベント選択
		/// </summary>
		#region EventComboSelectedValueChanged
		private string _EventComboSelectedValue;
		public string EventComboSelectedValue {
			get {
				return _EventComboSelectedValue;
			}
			set {
				if (value == _EventComboSelectedValue)
					return;

				_EventComboSelectedValue = value;
				RaisePropertyChanged();
				//if (value != null) {
				//	string msgStr = EventComboSource[value].ToString() + "が選択されました";
				//	MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				//}
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
				//if (weekDisplayMode.Equals("Week")) {
				//	SelectedDateTime = SelectedDateTime.AddDays(-7);
				//} else {
				//	SelectedDateTime = SelectedDateTime.AddDays(-1);
				//}
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
				//if (weekDisplayMode.Equals("Week")) {
				//	SelectedDateTime = SelectedDateTime.AddDays(7);
				//} else {
				//	SelectedDateTime = SelectedDateTime.AddDays(1);
				//}
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



		//Livet Messenger用///////////////////////
		new public void Dispose()
		{
			// 基本クラスのDispose()でCompositeDisposableに登録されたイベントを解放する。
			base.Dispose();
			Dispose(true);
		}
		//////////////////////////////////////////////////登録//
		public static void MyLog(string TAG, string dbMsg)
		{
			dbMsg = "[X_1_4ViewModel]" + dbMsg;
			//TabCon.exe = MethodBase.GetCurrentMethod().Module.Name
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			dbMsg = "[X_1_4ViewModel]" + dbMsg;
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
		
		/// <summary>
		/// 一日分の箱
		/// </summary>
		public class ADay {
			X_1_4ViewModel rootClass;
			/// <summary>
			/// 対象日
			/// </summary>
			public DateTime date { get; }
			/// <summary>
			/// 表示する要約
			/// </summary>
			public List<string> summarys { get; }

			public ObservableCollection<t_events> events { get; set; }

			private int _selectedIndex { set; get; }
			/// <summary>
			/// DataGrid上の選択インデックス
			/// </summary>
			public int selectedIndex {
				get { return _selectedIndex; }
				set {
					if (_selectedIndex == value)
						return;
					_selectedIndex = value;
					rootClass.selectedIndex = value;
					//			RaisePropertyChanged("selectedIndex");
				}
			}

			public bool _IsChecked;
			/// <summary>
			/// リスト先頭のチェック
			/// </summary>
			public bool IsChecked {
				get { return _IsChecked; }
				set {
					if (_IsChecked == value)
						return;

					_IsChecked = value;
				}
			}

			/// <summary>
			/// 一日分の箱
			/// </summary>
			public ADay(DateTime _date, List<string> _summarys , ObservableCollection<t_events> _events , X_1_4ViewModel _rootClass)
			{
				this.date = _date;
				this.summarys = _summarys;
				this.events = _events;
				this.rootClass = _rootClass;
			}

			//public t_events _TargetEvent;
			///// <summary>
			///// 操作対象の予定
			///// </summary>
			//public t_events TargetEvent {
			//	get { return _TargetEvent; }
			//	set {
			//		if (_TargetEvent == value)
			//			return;
			//		_TargetEvent = new t_events();
			//		_TargetEvent = value;
			//		rootClass.TargetEvent = value;
			//		//			rootClass.RaisePropertyChanged("TargetEvent");
			//	}
			//}


		}
	}
}