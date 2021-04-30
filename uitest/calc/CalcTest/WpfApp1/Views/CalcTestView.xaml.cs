using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Views {
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
			string TAG = "ThisLoaded";
			string dbMsg = "";
			try {

				//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
				VM.MyView = this;
				int CalcVer = Properties.Settings.Default.CalcVer;
				dbMsg += ",摘要Ver=" +( CalcVer+1);
				if (CalcVer < 0) {
					CalcVer = 0;
				}
				if (0 == CalcVer) {
					dbMsg += ":Ver,1";
					this.SecFuncPanel.Visibility = Visibility.Collapsed;
					Properties.Settings.Default.IsPO = false;
					Properties.Settings.Default.Save();
				} else {
					dbMsg += ":Ver,2";
					this.SecFuncPanel.Visibility = Visibility.Visible;
					bool? IsPO = Properties.Settings.Default.IsPO;
					dbMsg += ",摘要Ver=" + IsPO;
					if (IsPO != null) {
						IsPoCK.IsChecked = IsPO;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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
			Properties.Settings.Default.CalcTextFontSize = TB.Text;
			Properties.Settings.Default.Save();
		}

		private void CalcTexWidth_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			Bt2Tbox.Width = int.Parse(TB.Text);
			Properties.Settings.Default.CalcTexWidth = TB.Text;
			Properties.Settings.Default.Save();
		}

		private void CalcTextShow_TextChanged(object sender, TextChangedEventArgs e) {
			string TAG = "CalcTextShow_TextChanged";
			string dbMsg = "";
			try {
				if (CalcTextShowX.Text.Equals("")) { return; }
				if (CalcTextShowY.Text.Equals("")) { return; }
				CalcCallBt.ShowX = double.Parse(CalcTextShowX.Text);
				CalcCallBt.ShowY = double.Parse(CalcTextShowY.Text);
				dbMsg = "(" + CalcTextShowX.Text + "," + CalcTextShowY.Text + ")";
				//Properties.Settings.Default.CalcTextShowX = CalcTextShowX.Text;
				//Properties.Settings.Default.CalcTextShowY = CalcTextShowY.Text;
				//Properties.Settings.Default.Save();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void CalcTextDLogTitol_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			CalcCallBt.ViewTitle = TB.Text;
			Properties.Settings.Default.CalcTextDLogTitol = TB.Text;
			Properties.Settings.Default.Save();
		}

		private void CalcDLogWidth_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			Properties.Settings.Default.CalcWindowWidthStr = TB.Text;
			Properties.Settings.Default.Save();
		}

		private void CalcDLogHight_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			Properties.Settings.Default.CalcWindowHeightStr = TB.Text;
			Properties.Settings.Default.Save();
		}
		private void CalcVerComb_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			string TAG = "CalcVerComb_SelectionChanged";
			string dbMsg = "";
			try {
				ComboBox CB = sender as ComboBox;
				if(CB == null) {
					dbMsg += "未選択";
				} else{
					int SelectedIndex = CB.SelectedIndex;
					dbMsg = "[" + SelectedIndex +"]";
					CalcCallBt.CalcVer = SelectedIndex;
					Properties.Settings.Default.CalcVer = SelectedIndex;
					Properties.Settings.Default.Save();
					if(0==SelectedIndex ) {
						dbMsg += "Ver,1";
						this.SecFuncPanel.Visibility = Visibility.Collapsed;
						Properties.Settings.Default.IsPO = false;
						Properties.Settings.Default.Save();
					} else {
						dbMsg += "Ver,2";
						this.SecFuncPanel.Visibility = Visibility.Visible;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		private void IsPoCK_Click(object sender, RoutedEventArgs e) {
			string TAG = "IsPoCK_Click";
			string dbMsg = "";
			try {
				CheckBox CB = sender as CheckBox;
				if (CB == null) {
					dbMsg = "未選択";
				} else {
					bool isCK = (bool)CB.IsChecked;
					dbMsg = "IsPO=" + isCK;
					CalcCallBt.IsPO = isCK;
					Properties.Settings.Default.IsPO = isCK;
					Properties.Settings.Default.Save();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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

	}
}

