using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Views {
	/// <summary>
	/// ParrtsTestView.xaml の相互作用ロジック
	/// </summary>
	public partial class ParrtsTestView : Window {

		public ViewModels.ParrtsTestViewModel VM;

		public ParrtsTestView()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.ParrtsTestViewModel();
			this.DataContext = VM;
			this.Loaded += ThisLoaded;
		}
		private void ThisLoaded(object sender, RoutedEventArgs e)
		{
			//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
			//VM.MyView = this;
		}

		/// <summary>
		/// このView上の表示調整
		/// サンプルなのでコードビハインドで対処
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcTextFontSize_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox TB = sender as TextBox;
			Bt2Tbox.FontSize = int.Parse(TB.Text);
			CalcCallBt.MinWidth = int.Parse(CalcTextFontSize.Text) * 1.4;
		}

		private void CalcTexWidth_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox TB = sender as TextBox;
			Bt2Tbox.Width = int.Parse(TB.Text);
		}

		private void CalcTextDLogTitol_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox TB = sender as TextBox;
			CalcCallBt.ViewTitle = TB.Text;
		}

	}
}

