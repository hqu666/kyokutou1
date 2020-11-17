using System;
using System.Windows;
using System.Windows.Controls;

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
			VM.MyView = this;
			//	VM.Control = ControlPanel;
			//		MyCalendar.Height = this.Height- ControlPanel.Height-10;
		}

		private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "DataGrid_SelectionChanged";
			string dbMsg = "";
			try {
				DataGrid DG = sender as DataGrid;
				VM.TargetEvent = (Models.t_events)DG.SelectedItem;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}

		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[X_1_4]" + dbMsg;
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			dbMsg = "[X_1_4]" + dbMsg;
			Util.MyErrorLog(TAG, dbMsg, err);
		}

	}
}
