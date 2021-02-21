using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CS_Calculator
{
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
		/// 表示位置
		/// </summary>
		public Double ShowX {
			get { return (Double)GetValue(ShowXProperty); }
			set { SetValue(ShowXProperty, value); }
		}
		public static readonly DependencyProperty ShowXProperty =
			DependencyProperty.Register("ShowX", typeof(Double), typeof(CalculatorButton), new PropertyMetadata(default(Double)));
	
		public Double ShowY {
			get { return (Double)GetValue(ShowYProperty); }
			set { SetValue(ShowYProperty, value); }
		}
		public static readonly DependencyProperty ShowYProperty =
			DependencyProperty.Register("ShowY", typeof(Double), typeof(CalculatorButton), new PropertyMetadata(default(Double)));

		/// <summary>
		/// ウインドウ幅
		/// </summary>
		public Double CalcWindowWidth {
			get { return (Double)GetValue(CalcWindowWidthProperty); }
			set { SetValue(CalcWindowWidthProperty, value); }
		}
		public static readonly DependencyProperty CalcWindowWidthProperty =
			DependencyProperty.Register("CalcWindowWidth", typeof(Double), typeof(CalculatorButton), new PropertyMetadata(default(Double)));

		public Double CalcWindowHeight {
			get { return (Double)GetValue(CalcWindowHeightProperty); }
			set { SetValue(CalcWindowHeightProperty, value); }
		}
		public static readonly DependencyProperty CalcWindowHeightProperty =
			DependencyProperty.Register("CalcWindowHeight", typeof(Double), typeof(CalculatorButton), new PropertyMetadata(default(Double)));

		/// <summary>
		/// ダイアログタイトル
		/// </summary>
		public string ViewTitle {
			get { return (string)GetValue(ViewTitleProperty); }
			set { SetValue(ViewTitleProperty, value); }
		}
		public static readonly DependencyProperty ViewTitleProperty =
			DependencyProperty.Register("ViewTitle", typeof(string), typeof(CalculatorButton), new PropertyMetadata(default(string)));


		/// <summary>
		/// 電卓クラス
		/// </summary>
		public CS_CalculatorControl calculatorControl;
		/// <summary>
		/// 電卓を表示しているウィンドウ
		/// </summary>
		public Window CalcWindow;

		public Key OperatKey;

		/// <summary>
		/// このクラスの起点
		/// </summary>
		public CalculatorButton()
		{
			InitializeComponent();
			if(CalcWindowWidth == 0) {
					CalcWindowWidth = 180;
			}
			if (CalcWindowHeight == 0) {
				CalcWindowHeight = 250;
			}
			this.Loaded += This_loaded;
		}
		//リソースの読込みが終わったら
		private void This_loaded(object sender, RoutedEventArgs e)
		{
			string TAG = "this_loaded";
			string dbMsg = "";
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
			string dbMsg = "";
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
						if (Key.D0 <= key && key <= Key.D9) {
							dbMsg += "=最上列";
						} else if (Key.NumPad0 <= key && key <= Key.NumPad9) {
							dbMsg += "=Numパッド";
						} else if (Key.Decimal == key) {
							dbMsg += "=小数点";
						} else if (Key.Return == key) {
							dbMsg += "=Return";
						} else {
							String msgStr = "数値以外(" + key.ToString() + ")が入力されました";
							String titolStr = "電卓表示フィールド";
							MessageShowWPF(msgStr, titolStr);
						}
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
			string dbMsg = "";
			try {
				double number;
				if (double.TryParse(TargetTextBox.Text, out number)) {
					dbMsg += ",入力の変換結果=" + number;
				} else if (TargetTextBox.Text.Equals("")) {
				} else {
					String msgStr = "数値以外が入力されています\r\n";
					msgStr += TargetTextBox.Text;
					msgStr += "\r\n修正をお願いします";
					String titolStr = "電卓表示フィールド";
					MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}
				if (TargetTextBox != null) {
					ViewTitle = "TextBox:" + TargetTextBox.Name;
				}
				Point pt = TargetTextBox.PointToScreen(new Point(0.0d, 0.0d));
				//表示位置
				if (0 == ShowX){
					//指定が無ければ書き込み先フィールドの左やや下に表示する
					ShowX = pt.X + 20;
				}else{
					//指定された位置に表示
					ShowX = ShowX;
				}
				if ( 0== ShowY){
					//指定が無ければ書き込み先フィールドの左やや下に表示する
					ShowY = pt.Y + 30;
				}else{
					//指定された位置に表示
					ShowY = ShowY;
				}
				//Windowを生成；タイトルの初期値は書き戻し先のフィールド名
				Window CalcWindow = new Window {                           //Windowを生成
					Title = ViewTitle,
					Width = CalcWindowWidth,
					Height = CalcWindowHeight,
					Left = ShowX,
					Top = ShowY,
					Content = calculatorControl,
					ResizeMode = ResizeMode.NoResize,
					Topmost = true
				};
				dbMsg += ">>(" + CalcWindow.Left + " , " + CalcWindow.Top + ")[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
				calculatorControl.CalcWindow = CalcWindow;              //dllからクローズなどのwindow制御を行う
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
			Console.WriteLine(TAG + "[CS_Calculator:CalculatorButtun]" + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			Console.WriteLine(TAG + "[CS_Calculator:CalculatorButtun]" + dbMsg + "でエラー発生;" + err);
		}


		public MessageBoxResult MessageShowWPF(String msgStr,
																				String titolStr = null,
																				MessageBoxButton buttns = MessageBoxButton.OK,
																				MessageBoxImage icon = MessageBoxImage.None
																				)
		{
			String TAG = "MessageShowWPF";
			String dbMsg = "開始";
			MessageBoxResult result = 0;
			try {
				dbMsg = "titolStr=" + titolStr;
				dbMsg += "mggStr=" + msgStr;
				//メッセージボックスを表示する		https://docs.microsoft.com/ja-jp/dotnet/api/system.windows.messagebox?view=netcore-3.1
				if (titolStr == null) {
					result = MessageBox.Show(msgStr);
				} else if (icon == MessageBoxImage.None) {
					result = MessageBox.Show(msgStr, titolStr, buttns);
				} else {
					result = MessageBox.Show(msgStr, titolStr, buttns, icon);
				}
				dbMsg += ",result=" + result;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyLog(TAG, dbMsg + "で" + er.ToString());
			}
			return result;
		}


	}

}
