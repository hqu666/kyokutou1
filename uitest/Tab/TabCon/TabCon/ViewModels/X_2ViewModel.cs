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
using TabCon.Models;

namespace TabCon.ViewModels {
	public class X_2ViewModel : ViewModel {
		public string titolStr = "【スケジュール登録】";
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
				RaisePropertyChanged(); //	"dataManager"
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