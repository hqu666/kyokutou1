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

namespace TabCon.Controls {
	/// <summary>
	/// SuppliersClosingDatesWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class SuppliersClosingDatesWindow : Window {
		public string retStr;

		public SuppliersClosingDatesWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button BT = sender as Button;
			retStr = (string)BT.Content;
		}
	}
}
