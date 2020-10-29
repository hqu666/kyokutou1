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
		/// 結果の書き出し先フィールド
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
		/// ダイアログタイトル
		/// </summary>
		public string ViewTitle {
			get { return (string)GetValue(ViewTitleProperty); }
			set { SetValue(ViewTitleProperty, value); }
		}
		public static readonly DependencyProperty ViewTitleProperty =
			DependencyProperty.Register("ViewTitle", typeof(string), typeof(CalculatorButton), new PropertyMetadata(default(string)));

		public Key OperatKey;

		/// <summary>
		/// このクラスの起点
		/// </summary>
		public CalculatorButton()
		{
			InitializeComponent();
			this.Loaded += This_loaded;
		}
		//リソースの読込みが終わったら
		private void This_loaded(object sender, RoutedEventArgs e)
		{
			string TAG = "this_loaded";
			string dbMsg = "[CalculatorButtun]";
			try {
				calculatorControl = new CS_CalculatorControl();
				calculatorControl.TargetTextBox = this.TargetTextBox;

				TargetTextBox.KeyDown += new KeyEventHandler(TFKeyDown);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 結果の書き出し先フィールド四則演算子が入力されたら
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TFKeyDown(object sender, KeyEventArgs e)
		{
			string TAG = "TFKeyDown";
			string dbMsg = "[CalculatorButtun]";
			try {
				TextBox TF = sender as TextBox;
				Key key = e.Key;
				dbMsg += "key=" + key.ToString();
				switch (key) {
					case Key.Add:
					case Key.OemPlus:
					case Key.Subtract:
					case Key.OemMinus:
					case Key.Divide:
					case Key.Multiply:
						OperatKey = key;
						CalcBT_Click(new object(), new RoutedEventArgs());
						break;
					default:
						break;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// 電卓をダイアログで表示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcBT_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "CalcBT_Click";
			string dbMsg = "[CalculatorButtun]";
			try {
				//Windowを生成；タイトルの初期値は書き戻し先のフィールド名
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
				calculatorControl.CalcWindow = CalcWindow;
				calculatorControl.OperatKey = this.OperatKey;
				Nullable<bool> dialogResult = CalcWindow.ShowDialog();
				dbMsg += ",dialogResult=" + dialogResult;

				MyLog(TAG, dbMsg);
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

	}

}
