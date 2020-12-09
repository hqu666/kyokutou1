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
	/// Z_1_4.xaml の相互作用ロジック
	/// </summary>
	public partial class Z_1_4 : Page {
		public ViewModels.Z_1_4ViewModel VM;
		public Z_1_4()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			//VM = new ViewModels.Z_1_4ViewModel();
			//this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			//	VM.MyView = this;
			//	this.MainXDG.FieldSettings.MergedCellMode = MergedCellMode.Always;
			//	VM.Control = ControlPanel;
			//		MyCalendar.Height = this.Height- ControlPanel.Height-10;
		}
	}
}
