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
	/// Child_Page.xaml の相互作用ロジック
	/// </summary>
	public partial class Child_Page : Page {
		public ViewTabControl MW;

		public Child_Page()
		{
			InitializeComponent();
		}

		private void CPageCloss_bt_Click(object sender, RoutedEventArgs e)
		{
			MW.DrelTabItem();
		}
	}
}
