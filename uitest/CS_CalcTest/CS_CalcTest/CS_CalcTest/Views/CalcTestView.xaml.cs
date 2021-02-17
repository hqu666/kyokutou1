using System;
using System.Windows;
using System.Windows.Controls;

namespace CS_CalcTest.Views {
	/// <summary>
	/// ParrtsTestView.xaml の相互作用ロジック
	/// </summary>
	public partial class CalcTestView : Window {

		public ViewModels.CalcTestViewModel VM;

		public CalcTestView()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.CalcTestViewModel();
			this.DataContext = VM;
			this.Loaded += ThisLoaded;
		}
		private void ThisLoaded(object sender, RoutedEventArgs e)
		{
			//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
			VM.MyView = this;
		}

		private void MyDGContextMenu_Click(object sender, RoutedEventArgs e) {
			string TAG = "MyDGContextMenu_Click";
			string dbMsg = "";
			try {
		//		DataGrid DG = MyDG;                      //(DataGrid)sender;
		//		DG.Focus();
		//		// 行番号(0起算)
		//		int rowIndex = DG.Items.IndexOf(DG.CurrentItem);
		//		// 列番号(0起算)
		//		int columnIndex = DG.CurrentCell.Column.DisplayIndex;
		//		dbMsg += "[" + rowIndex + " , " + columnIndex + "]";
		//		TextBlock targetTextBlock = (TextBlock)DG.Columns[columnIndex].GetCellContent(DG.SelectedItem);
		//		string orgVal = targetTextBlock.Text;
		//		dbMsg += orgVal;
		//		var result = 0;
		//		if (int.TryParse(orgVal, out result)) {
		//			dbMsg += "は数値で" + result;
		//			CS_CalculatorControl calculatorControl = new CS_CalculatorControl();
		////			calculatorControl.TargetTextBlock = targetTextBlock;

		//			//Windowを生成；タイトルの初期値は書き戻し先のフィールド名
		//			Window CalcWindow = new Window {
		//									Title = targetTextBlock.Name,
		//									Content = calculatorControl,
		//									ResizeMode = ResizeMode.NoResize
		//								};
		//			Point pt = targetTextBlock.PointToScreen(new Point(0.0d, 0.0d));
		//			//表示位置
		//			Double ShowX = 0;
		//			if (CalcTextShowX.Text != "") {
		//				ShowX = Double.Parse(CalcTextShowX.Text);
		//			}
		//			Double ShowY = 0;
		//			if (CalcTextShowY.Text != "") {
		//				ShowY = Double.Parse(CalcTextShowY.Text);
		//			}
		//			dbMsg += ",指定座標[" + ShowX + "," + ShowY + "]";
		//			if (0 == ShowX) {
		//				//指定が無ければ書き込み先フィールドの左やや下に表示する
		//				CalcWindow.Left = pt.X + 20;
		//			} else {
		//				//指定された位置に表示
		//				CalcWindow.Left = ShowX;
		//			}
		//			if (0 == ShowY) {
		//				//指定が無ければ書き込み先フィールドの左やや下に表示する
		//				CalcWindow.Top = pt.Y + 30;
		//			} else {
		//				//指定された位置に表示
		//				CalcWindow.Top = ShowY;
		//			}
		//			dbMsg += ">>[" + ShowX + "," + ShowY + "]";
		//			CalcWindow.Topmost = true;
		//			dbMsg += "(" + CalcWindow.Left + " , " + CalcWindow.Top + ")";
		//			CalcWindow.Width = 300;
		//			CalcWindow.Height = 400;
		//			dbMsg += "[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
		//			string ViewTitle = "データグリッド" + DG.Name + "の"+ (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目";

		//			dbMsg += ",ViewTitol=" + ViewTitle;

		//			if (!ViewTitle.Equals("")) {
		//				CalcWindow.Title = ViewTitle;
		//			}
		//			calculatorControl.CalcWindow = CalcWindow;
		//			calculatorControl.InputStr = result.ToString();

		//			//		calculatorControl.OperatKey = this.OperatKey;
		//			Nullable<bool> dialogResult = CalcWindow.ShowDialog();
		//			dbMsg += ",dialogResult=" + dialogResult;

		//		} else {
		//			String titolStr = "データグリッド" + DG.Name + "でコンテキストメニューで選択したアイテム";
		//			String msgStr = (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目（" + orgVal + "）は数値ではありません";
		//			msgStr += "\r\n電卓は数値を入力するセルでご利用ください";
		//			MessageShowWPF( msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
		//		}


				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void MyGSGridContextMenu_Click(object sender, System.EventArgs e) {
			MessageBox.Show("You chose color.");
		}

		/// <summary>
		/// このView上の表示調整
		/// サンプルなのでコードビハインドで対処
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcTextFontSize_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			Bt2Tbox.FontSize = int.Parse(TB.Text);
			CalcCallBt.MinWidth = int.Parse(CalcTextFontSize.Text) * 1.4;
		}

		private void CalcTexWidth_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			Bt2Tbox.Width = int.Parse(TB.Text);
		}

		private void CalcTextShow_TextChanged(object sender, TextChangedEventArgs e) {
			if (CalcTextShowX.Text.Equals("")) { return; }
			if (CalcTextShowY.Text.Equals("")) { return; }
			CalcCallBt.ShowX = double.Parse(CalcTextShowX.Text);
			CalcCallBt.ShowY = double.Parse(CalcTextShowY.Text);
		}

		private void CalcTextDLogTitol_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			CalcCallBt.ViewTitle = TB.Text;
		}

		////////////////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg) {
#if DEBUG
			Console.WriteLine(TAG + "[CalcTestView]" + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err) {
			Console.WriteLine(TAG + "[CalcTestView]" + dbMsg + "でエラー発生;" + err);
		}


		public MessageBoxResult MessageShowWPF(String msgStr,
																				String titolStr = null,
																				MessageBoxButton buttns = MessageBoxButton.OK,
																				MessageBoxImage icon = MessageBoxImage.None
																				) {
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

		/*
		private class Product {
			///<summary>
			///製品名
			///</summary>
			private string _Name;
			public string Name {
				get => _Name;
				set {
					if (_Name == value)
						return;
					_Name = value;
				}
			}
			private int _Price;
			public int Price {
				get => _Price;
				set {
					if (_Price == value)
						return;
					_Price = value;
				}
			}

			private int _Tax;
			public int Tax {
				get => _Tax;
				set {
					if (_Tax == value)
						return;
					_Tax = value;
				}
			}


		}
		*/
	}
}

