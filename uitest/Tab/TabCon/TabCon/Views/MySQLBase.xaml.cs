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
	/// MySQLBase.xaml の相互作用ロジック
	/// </summary>
	public partial class MySQLBase : Page {

		ViewModels.MySQLBaseViewModel VM;
		public MySQLBase()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.MySQLBaseViewModel();
			this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			VM.MyView = this;
			//((ViewModels.MySQLBaseViewModel)this.DataContext).MyView = this;
		}

		///// <summary>
		///// テーブル選択
		///// </summary>
		///// <param name="sender"></param>
		///// <param name="e"></param>

		//private void Table_combo_SelectionChanged(object sender, SelectionChangedEventArgs e){ 
		//	string TAG = "Table_combo_SelectionChanged";
		//	string dbMsg = "[MySQLBase]";
		//	try {
		//		ComboBox combo = sender as ComboBox;
		//		int selectedIndex = combo.SelectedIndex;
		//		dbMsg += "[" + selectedIndex + "]";
		//		string selectedTableName = combo.SelectedValue.ToString();
		//		dbMsg += selectedTableName;
		//		VM.ReadTable(selectedTableName);
		//	} catch (Exception er) {
		//		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}
	}
}