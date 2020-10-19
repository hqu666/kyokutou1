using Livet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
			//EventComboSelectedIndex = (0).ToString();
			//RaisePropertyChanged("EventComboSelectedIndex");

			SelectedDateTime = DateTime.Now;
			CurrentDate = String.Format("yyyy年MM月", SelectedDateTime);
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
