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
	/// CalculatorTextBox.xaml の相互作用ロジック
	/// </summary>
	public partial class CalculatorTextBox : UserControl {
		/// <summary>
		/// 電卓を表示しているウィンドウ
		/// </summary>
		public Window CalcWindow;
		public string CalcText { get; set; }
		public int FieldFontSize { get; set; }
		public string ViewTitle { get; set; }

		public CalculatorTextBox()
		{
			InitializeComponent();
			ViewTitle = "";
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			Initialize();
		}
		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "[CalculatorTextBox]";
			try {
				dbMsg += ",FieldFontSize=" + FieldFontSize;
				CalcText = CalcTB.Text;
				dbMsg += ",元の書込み=" + CalcText;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void CalcBT_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "CalcBT_Click";
			string dbMsg = "[CalculatorTextBox]";
			try {
				Controls.CS_CalculatorControl calculatorControl = new Controls.CS_CalculatorControl();
				calculatorControl.rootView = this;
				CalcText = CalcTB.Text;
				dbMsg += ",元の書込み=" + CalcText;
				calculatorControl.BeforeVal += (string)CalcText;
				calculatorControl.CalcProcess.Text = calculatorControl.BeforeVal;

				CalcWindow = new Window {
					Title = CalcTB.Name,
					Content = calculatorControl,
					ResizeMode = ResizeMode.NoResize
				};
				Point pt = CalcTB.PointToScreen(new Point(0.0d, 0.0d));
				CalcWindow.Left = pt.X + 20;
				CalcWindow.Top = pt.Y + 20;
				CalcWindow.Topmost = true;
				dbMsg += "(" + CalcWindow.Left + " , " + CalcWindow.Top + ")";
				CalcWindow.Width = 300;
				CalcWindow.Height = 350;
				dbMsg += "[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
				CalcWindow.FontSize = FieldFontSize;
				dbMsg += ",FontSize" + CalcWindow.FontSize;
				dbMsg += ",ViewTitol=" + ViewTitle;

				if(! ViewTitle.Equals("")){
					CalcWindow.Title = ViewTitle;
				}
				CalcWindow.ShowDialog();

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public  void CalcWindowCloss()
		{
			CalcWindow.Close();
		}

		//////////////////////////////////////////////////電卓//
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		)
		{
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}

	}
}
