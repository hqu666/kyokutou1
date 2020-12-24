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
	///締日用の日付け入力パレット（モダール）
	///　DependencyPropertyでのデータ送受信に参照エラーが出るのでコードビハインド間のクラス参照で対応
	/// </summary>
	public partial class SuppliersClosingDatesWindow : Window {
		/// <summary>
		/// 呼出し元クラス
		/// </summary>
		public SuppliersClosingDateControl OwnerControl;
		///以下の様なDependencyも紹介されている//////////////////////////////////
		/// <summary>
		/// 結果の書き出し先
		/// </summary>
		//public TextBox TargetTB {
		//	get { return (TextBox)GetValue(TargetTextBoxtProperty); }
		//	set { SetValue(TargetTextBoxtProperty, value); }
		//}
		//public static readonly DependencyProperty TargetTextBoxtProperty =DependencyProperty.Register("TargetTB", 
		//		typeof(TextBox), 
		//		typeof(SuppliersClosingDatesWindow), 
		//		new PropertyMetadata(default(TextBox))
		//	);
		//public int SelectedInt {
		//	get { return (int)GetValue(SCDWProperty); }
		//	set { SetValue(SCDWProperty, value); }
		//}
		//public static readonly DependencyProperty SCDWProperty =
		//	DependencyProperty.Register(
		//		"SelectedInt",
		//		typeof(int),
		//		typeof(SuppliersClosingDateControl),
		//		new PropertyMetadata(
		//			0,
		//			new PropertyChangedCallback((sender, e) => {
		//				(sender as SuppliersClosingDatesWindow).OnMyPropertyChanged(sender, e);
		//			}))
		//		);
		//private void OnMyPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		//{
		//	int chInt=int.Parse(e.NewValue.ToString());
		//}

		//public ICommand MyCommand {
		//	get { return (ICommand)GetValue(MyCommandProperty); }
		//	set { SetValue(MyCommandProperty, value); }
		//}
		//public static readonly DependencyProperty MyCommandProperty =
		//	DependencyProperty.Register(
		//		"MyCommand",                    // プロパティ名
		//		typeof(ICommand),               // プロパティの型
		//		typeof(SuppliersClosingDatesWindow),      // プロパティを所有する型＝このクラスの名前
		//		new PropertyMetadata(null)   // 初期値
		//		); 

		/// <summary>
		/// 表示文字
		/// </summary>
		public string DisplayStr { get; set; }

		/// <summary>
		///締日用の日付け入力パレット（モダール）
		/// </summary
		public SuppliersClosingDatesWindow()
		{
			InitializeComponent();
			this.Loaded += this_loaded;
		}
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			Point pt = OwnerControl.ShowPanelBT.PointToScreen(new Point(0.0d, 0.0d));
			this.Left = pt.X + 15;
			this.Top = pt.Y-2;
			//if(0<(double)BaceGrid.ActualWidth) {
			//	this.Width = this.BaceGrid.ActualWidth + 10;
			//	this.Height = this.BaceGrid.ActualHeight + 10;
			//}
			//Point xpt = XEndBT.PointFromScreen(new Point(0.0d, 0.0d));
			//Point ypt = YEndBT.PointFromScreen(new Point(0.0d, 0.0d));
			DisplayStr = OwnerControl.SetValTB.Text;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button BT = sender as Button;
			DisplayStr = (string)BT.Content;
			OwnerControl.SetValTB.Text = DisplayStr;
			int SelectedInt = int.Parse(DisplayStr);
			OwnerControl.DisplaySet(SelectedInt);
			this.Close();
		}
	}
}
