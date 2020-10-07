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
	/// ChildPageView.xaml の相互作用ロジック
	/// </summary>
	public partial class ChildPageView : Page {

		public ChildPageView()
		{
			InitializeComponent();
			//DataContextは呼出し元で設定
			//			this.DataContext = new ViewModels.ChildPageViewModel();
		}
	}
}
