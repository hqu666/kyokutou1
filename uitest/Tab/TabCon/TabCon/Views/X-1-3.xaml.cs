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
	/// X_1_3.xaml の相互作用ロジック
	/// </summary>
	public partial class X_1_3 : Page {
		public ViewModels.X_1_3ViewModel VM;
		public X_1_3()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.X_1_3ViewModel();
			this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			VM.MyView = this;
			//((ViewModels.MySQLBaseViewModel)this.DataContext).MyView = this;
		}


	}
}
