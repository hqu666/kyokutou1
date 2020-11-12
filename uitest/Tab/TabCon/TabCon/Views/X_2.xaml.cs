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
using System.Windows.Shapes;

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
		}

	}
}
