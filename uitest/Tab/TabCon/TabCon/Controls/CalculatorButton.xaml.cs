using Livet;
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
	/// クリックするとダイヤログで電卓を表示するボタン
	/// </summary>
	public partial class CalculatorButton : UserControl {

		/// <summary>
		/// 結果の書き出し先
		/// </summary>
		public TextBox TargetTextBox {
			get { return (TextBox)GetValue(TargetTextBoxtProperty); }
			set { SetValue(TargetTextBoxtProperty, value); }
		}
		public static readonly DependencyProperty TargetTextBoxtProperty =
			DependencyProperty.Register("TargetTextBox", typeof(TextBox), typeof(CalculatorButton), new PropertyMetadata(default(TextBox)));
		/// <summary>
		/// 電卓クラス
		/// </summary>
		public CS_CalculatorControl calculatorControl ;
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
		public string ViewTitle {
			get { return (string)GetValue(ViewTitleProperty); }
			set { SetValue(ViewTitleProperty, value); }
		}
		public static readonly DependencyProperty ViewTitleProperty =
			DependencyProperty.Register("ViewTitle", typeof(string), typeof(CalculatorButton), new PropertyMetadata(default(string)));


		public CalculatorButton()
		{
			InitializeComponent();

			//ViewとViewModelの紐付け
			//VM = new CalculatorButtonViewModel();
			//this.DataContext = VM;
			this.Loaded += This_loaded;
		}
		//リソースの読込みが終わったら
		private void This_loaded(object sender, RoutedEventArgs e)
		{
			string TAG = "this_loaded";
			string dbMsg = "[CalculatorButtun]";
			try {
				//VM.MyView = this;
				//dbMsg += ",TargetTextBoxName=" + TargetTextBoxName;
				//VM.TargetTextBox = TargetTextBox;

				calculatorControl = new CS_CalculatorControl();
				calculatorControl.rootBT = this;
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void CalcBT_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "CalcBT_Click";
			string dbMsg = "[CalculatorButtun]";
			try {
				CalcText = TargetTextBox.Text;
				dbMsg += ",元の書込み=" + CalcText;
				calculatorControl.InputStr += (string)CalcText;
				calculatorControl.CalcProcess.Text = calculatorControl.InputStr;
				//Windowを生成して
				CalcWindow = new Window {
					Title = TargetTextBox.Name,
					Content = calculatorControl,
					ResizeMode = ResizeMode.NoResize
				};
				//書き込み先フィールドの左やや下に表示する
				Point pt = TargetTextBox.PointToScreen(new Point(0.0d, 0.0d));
				CalcWindow.Left = pt.X + 20;
				CalcWindow.Top = pt.Y + 30;
				CalcWindow.Topmost = true;
				dbMsg += "(" + CalcWindow.Left + " , " + CalcWindow.Top + ")";
				CalcWindow.Width = 300;
				CalcWindow.Height = 400;
				dbMsg += "[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
				dbMsg += ",ViewTitol=" + ViewTitle;

				if (!ViewTitle.Equals("")) {
					CalcWindow.Title = ViewTitle;
				}
				Nullable<bool> dialogResult = CalcWindow.ShowDialog();

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// ダイアログを終了させたい処から呼んで、外部からダイアログを閉じる
		/// </summary>
		public void CalcWindowCloss()
		{
			string TAG = "CalcWindowCloss";
			string dbMsg = "[CalculatorButtun]";
			try {
				if (CalcWindow.IsLoaded) {
					string resurlStr = calculatorControl.ProcessVal.ToString();
					dbMsg += ",resurlStr=" + resurlStr;
					TargetTextBox.Text = resurlStr;
					MyLog(TAG, dbMsg);
					CalcWindow.Close();
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

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
