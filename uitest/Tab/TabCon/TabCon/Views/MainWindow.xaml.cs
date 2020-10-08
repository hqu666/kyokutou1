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
using TabCon.ViewModels;

namespace TabCon.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
		public MainWindow()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			ViewModels.MainViewModel VM = new ViewModels.MainViewModel();
			//VM.MenuTree = this.MenuTree;
			//VM.InfoLavel = InfoLavel;
			// Window_Loaded, Window_Activated,Window_Initialized,Window_GotFocusなどどのタイミングでも割り付ける事ができなかった

			this.DataContext = VM;

		}

	}
}
