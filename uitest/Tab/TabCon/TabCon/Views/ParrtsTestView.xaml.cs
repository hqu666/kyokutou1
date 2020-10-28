using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TabCon.Views {
	/// <summary>
	/// ParrtsTestView.xaml の相互作用ロジック
	/// </summary>
	public partial class ParrtsTestView : Page {
		public ViewModels.ParrtsTestViewModel VM;

		public ParrtsTestView()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.ParrtsTestViewModel();
			this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
			VM.MyView = this;
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
