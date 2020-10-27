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
		/// <summary>
		/// フィールドに表示される値
		/// </summary>
		public string CalcText { get; set; }
		/// <summary>
		/// フィールドのフォントサイズ
		/// </summary>
		public string FieldFontSize { get; set; }
		/// <summary>
		/// フィールドの幅
		/// </summary>
		public string FieldWidth { get; set; }
		/// <summary>
		/// ダイアログタイトル
		/// </summary>
		public string ViewTitle { get; set; }

		public CalculatorTextBox()
		{
			InitializeComponent();
			ViewTitle = "";
			this.Loaded += this_loaded;
		}
		//リソースの読込みが終わったら
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			string TAG = "this_loaded";
			string dbMsg = "[CalculatorTextBox]";
			try {
				dbMsg += ",元の書込み=" + CalcText;
				//初期値を渡された場合
				int i = 0;
				if (int.TryParse(CalcText, out i)){
					CalcTB.Text = CalcText;
				}else{
					dbMsg += ">>数値以外を指定" ;
				}
				MyLog(TAG, dbMsg);
				Initialize();
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// パラメータを取得して、このコントローラのリソースを調整
		/// </summary>
		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "[CalculatorTextBox]";
			try {
				dbMsg += ",FieldFontSize=" + FieldFontSize;
				CalcTB.FontSize = (int.Parse(FieldFontSize));
				dbMsg += ",FieldWidth=" + FieldWidth;
				CalcTB.Width = (int.Parse(FieldWidth)) +20;
				dbMsg += ",ViewTitle=" + ViewTitle;
				int i = 0;
				if (int.TryParse(CalcTB.Text, out i)) {
					CalcText = CalcTB.Text;
				} else {
					dbMsg += ">>数値以外を指定";
				}
				double rHeight = CalcTB.ActualHeight;
				dbMsg += ",高さ=" + rHeight;
				//高さが拾えないのでフォントサイズ+40％でボタン幅を確保
				CalcBT.Width = int.Parse(FieldFontSize)*1.4;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 電卓アイコンボタン押下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcBT_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "CalcBT_Click";
			string dbMsg = "[CalculatorTextBox]";
			try {
				Controls.CS_CalculatorControl calculatorControl = new Controls.CS_CalculatorControl();
				calculatorControl.rootView = this;
				CalcText = CalcTB.Text;
				dbMsg += ",元の書込み=" + CalcText;
				calculatorControl.InputStr += (string)CalcText;
				calculatorControl.CalcProcess.Text = calculatorControl.InputStr;

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
				CalcWindow.Height = 400;
				dbMsg += "[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
				CalcWindow.FontSize = int.Parse(FieldFontSize);
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
			if(CalcWindow.IsLoaded) {
				CalcWindow.Close();
			}
		}

		//////////////////////////////////////////////////電卓//
		public static void MyLog(string TAG, string dbMsg)
		{
#if DEBUG
				Console.WriteLine(TAG + " : " + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			Console.WriteLine(TAG + " : " + dbMsg + "でエラー発生;" + err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		)
		{
			MessageBoxResult result = 0;
			if (titolStr == null) {
				result = MessageBox.Show(msgStr);
			} else if (icon == MessageBoxImage.None) {
				result = MessageBox.Show(msgStr, titolStr, buttns);
			} else {
				result = MessageBox.Show(msgStr, titolStr, buttns, icon);
			}
			return result;
		}


	}
}
