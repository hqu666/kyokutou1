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

namespace TabCon {
	/// <summary>
	/// Child_Window.xaml の相互作用ロジック
	/// 
	/// Child_Page クラスと同じ読み出し方をしても「ルート要素は、ナビゲーションに対して無効です。'」というエラーになる
	/// </summary>
	public partial class Child_Window : Window {

		public ViewTabControl MW;

		public Child_Window()
		{
			InitializeComponent();
		}

		private void CwindowCloss_bt_Click(object sender, RoutedEventArgs e)
		{
			MW.DrelTabItem();
		}
	}
}
