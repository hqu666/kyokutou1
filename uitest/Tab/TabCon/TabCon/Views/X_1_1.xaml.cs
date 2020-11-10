using System.Windows;
using System.Windows.Controls;

namespace TabCon.Views {
	/// <summary>
	/// X_1_1;日別/週別スケジュール
	/// </summary>
	public partial class X_1_1 : Page {
		public ViewModels.X_1_1ViewModel VM;

		public X_1_1()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.X_1_1ViewModel();
			this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			VM.MyView = this;
			//	VM.Control = ControlPanel;
		}

	}
}
