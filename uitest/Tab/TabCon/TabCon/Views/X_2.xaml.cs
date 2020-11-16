using System.Windows;
using System.Windows.Controls;

namespace TabCon.Views {
	/// <summary>
	/// X_2.xaml の相互作用ロジック
	/// </summary>
	public partial class X_2 : Window {
		public ViewModels.X_2ViewModel VM;
		public X_2()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.X_2ViewModel();
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


	}
}
