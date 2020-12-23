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

namespace TabCon.Controls {
	/// <summary>
	///締日用のカスタムコントロール
	/// </summary>
	public partial class SuppliersClosingDatesControl : UserControl {
		public TextBox TargetTextBox {
			get { return (TextBox)GetValue(TargetTextBoxtProperty); }
			set { SetValue(TargetTextBoxtProperty, value); }
		}
		public static readonly DependencyProperty TargetTextBoxtProperty =
			DependencyProperty.Register("TargetTextBox", typeof(TextBox), 
														typeof(SuppliersClosingDatesControl), 
														new PropertyMetadata(default(TextBox)));


		public SuppliersClosingDatesControl()
		{
			InitializeComponent();
			SetValTB.Text = (string)TargetTextBox.Text;
		}

		public void MyCallBack()
		{
	//		string rText = (string)CalcResult.Content;
			TargetTextBox.Text = (string)SetValTB.Text;
	//		CalcWindow.Close();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			SuppliersClosingDatesWindow View = new SuppliersClosingDatesWindow();
			View.ShowDialog();
		}

		/// <summary>
		/// クローズボックスなどで強制的にUnloadされた場合
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			MyCallBack();
		}
	}
}
