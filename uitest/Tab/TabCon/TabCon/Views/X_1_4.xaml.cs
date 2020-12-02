using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Infragistics.Windows.DataPresenter;


namespace TabCon.Views {
	/// <summary>
	/// X_1_4.xaml の相互作用ロジック
	/// </summary>
	public partial class X_1_4 : Page
    {
		public ViewModels.X_1_4ViewModel VM;
		public X_1_4()
        {
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.X_1_4ViewModel();
			this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			//ICollectionView cv = CollectionViewSource.GetDefaultView(dt);
			//cv.GroupDescriptions.Add(newPropertyGroupDescription("City"));
			//Hotels.ItemsSource = cv;

			VM.MyView = this;
		//	this.MainXDG.FieldSettings.MergedCellMode = MergedCellMode.Always;
			//	VM.Control = ControlPanel;
			//		MyCalendar.Height = this.Height- ControlPanel.Height-10;
		}

		//private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		//{
		//	string TAG = "DataGrid_SelectionChanged";
		//	string dbMsg = "";
		//	try {
		//		DataGrid DG = sender as DataGrid;
		//		VM.TargetEvent = (Models.t_events)DG.SelectedItem;
		//		dbMsg += "" + VM.TargetEvent.event_date_start + "～" + VM.TargetEvent.event_date_end ;
		//		dbMsg += ":" + VM.TargetEvent.event_title;
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}

		private void DataGrid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			string TAG = "DataGrid_MouseLeftButtonUp";
			string dbMsg = "";
			try {
				DataGrid DG = sender as DataGrid;
				VM.TargetEvent = (Models.t_events)DG.SelectedItem;
				dbMsg += "" + VM.TargetEvent.event_date_start + "～" + VM.TargetEvent.event_date_end;
				dbMsg += ":" + VM.TargetEvent.event_title;
				if (VM.CanEdit()) {
					VM.Edit();
				}else{
					dbMsg += "遷移条件満たせず";
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}


		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			Util.MyErrorLog(TAG, dbMsg, err);
		}
	}
}
