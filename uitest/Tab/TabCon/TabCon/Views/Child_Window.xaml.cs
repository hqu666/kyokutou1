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
	/// Child_Window.xaml の相互作用ロジック
	/// </summary>
	public partial class Child_Window : Window {
		public ViewTabControl TC;
		public Child_Window()
		{
			InitializeComponent();
		}

		private void CwindowCloss_bt_Click(object sender, RoutedEventArgs e)
		{
			TC.DrelTabItem();
		}

	}
}
