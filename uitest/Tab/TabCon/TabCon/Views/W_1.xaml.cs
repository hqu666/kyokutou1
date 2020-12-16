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
	/// W_1.xaml の相互作用ロジック
	/// </summary>
	public partial class W_1 : Page {
		public W_1()
		{
			InitializeComponent();
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			Uri uri = new Uri(@"https://www.yahoo.co.jp/");
	//		this.webView.Navigate("https://www.yahoo.co.jp/");
			//	VM.Control = ControlPanel;
			//		MyCalendar.Height = this.Height- ControlPanel.Height-10;
		}

	}
}
