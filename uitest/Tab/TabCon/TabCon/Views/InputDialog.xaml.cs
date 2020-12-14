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
	/// InputDialog.xaml の相互作用ロジック
	/// </summary>
	public partial class InputDialog : UserControl {
		public ViewModels.InputDialogViewModel VM;
		public InputDialog()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			//VM = new ViewModels.InputDialogViewModel();
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
