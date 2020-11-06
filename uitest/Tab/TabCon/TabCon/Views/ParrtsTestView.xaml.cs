using Infragistics.Controls.Editors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using TabCon.Controls;

namespace TabCon.Views {
	/// <summary>
	/// ParrtsTestView.xaml の相互作用ロジック
	/// </summary>
	public partial class ParrtsTestView : Page {
		public ViewModels.ParrtsTestViewModel VM;

		public ParrtsTestView()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.ParrtsTestViewModel();
			this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
			VM.MyView = this;
		}

		/// <summary>
		/// このView上の表示調整
		/// サンプルなのでコードビハインドで対処
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcTextFontSize_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox TB = sender as TextBox;
			Bt2Tbox.FontSize = double.Parse(TB.Text);
			CalcCallBt.MinWidth = double.Parse(CalcTextFontSize.Text) * 1.4;
		}

		private void CalcTexWidth_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox TB = sender as TextBox;
			Bt2Tbox.Width = double.Parse(TB.Text);
		}

		private void CalcTextDLogTitol_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox TB = sender as TextBox;
			CalcCallBt.ViewTitle = TB.Text;
		}

		///文字色判定//////////////////////////////////////////////
		/// <summary>
		/// 閾値変更
		/// ※TextChangedはリソース読込み前に発生するので参照するobjectがNullになっている
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ColorSampleLimit_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			// System.NullReferenceException'対策
			if (ColorSampleBackground != null) {
		//		Color color = ColorSampleBackground.Color;
				string colorcode = ColorSampleBackground.Text;
				if (6 < colorcode.Length) {
					double number;
					if (double.TryParse(ColorSampleLimit.Text, out number)) {
						int limit = int.Parse(ColorSampleLimit.Text);
						if (1 < limit && limit < 256) {
							ForegroundBW(colorcode, limit);
						} else {
							String msgStr = "閾値は1～255までの範囲を指定して下さい\r\n";
							msgStr += ColorSampleLimit.Text;
							msgStr += "\r\n修正をお願いします";
							String titolStr = "電卓表示フィールド";
							MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
							return;
						}
					} else {
						String msgStr = "数値以外が入力されています\r\n";
						msgStr += ColorSampleLimit.Text;
						msgStr += "\r\n修正をお願いします";
						String titolStr = "電卓表示フィールド";
						MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
						return;
					}
				}
			}
		}

		private void ColorSampleBackground_TextChanged(object sender, TextChangedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			// System.NullReferenceException'対策
			if (ColorSampleBackground != null) {
				string colorcode = ColorSampleBackground.Text;
				if (6 < colorcode.Length) {
					double number;
					if (double.TryParse(ColorSampleLimit.Text, out number)) {
						int limit = int.Parse(ColorSampleLimit.Text);
						if (6 < limit && limit < 256) {
							ForegroundBW(colorcode, limit);
						} else {
							String msgStr = "閾値は1～255までの範囲を指定して下さい\r\n";
							msgStr += ColorSampleLimit.Text;
							msgStr += "\r\n修正をお願いします";
							String titolStr = "電卓表示フィールド";
							MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
							return;
						}
					} else {
						String msgStr = "数値以外が入力されています\r\n";
						msgStr += ColorSampleLimit.Text;
						msgStr += "\r\n修正をお願いします";
						String titolStr = "電卓表示フィールド";
						MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
						return;
					}
				}
			}
		}
		private void XamColorPicker_SelectedColorChanged(object sender, Infragistics.Controls.Editors.SelectedColorChangedEventArgs e)
		{
			XamColorPicker XCP = sender as XamColorPicker;
			// System.NullReferenceException'対策
			if (xamColorPicker != null) {
				Color? selectedColor = XCP.SelectedColor;
				string colorcode = selectedColor.ToString();
				ColorSampleBackground.Text = colorcode;
			}
		}
		/// <summary>
		/// 背景に応じて文字色の白黒を切り替える
		/// </summary>
		private void ForegroundBW(string colorcode, int limit)
		{
			if(ColorSampleLavel != null && ColorSampleTB !=null) {
				int r = int.Parse(colorcode.Substring(3, 2), NumberStyles.HexNumber);
				int g = int.Parse(colorcode.Substring(5, 2), NumberStyles.HexNumber);
				int b = int.Parse(colorcode.Substring(7, 2), NumberStyles.HexNumber);
				Color col = Color.FromArgb(255, (byte)r, (byte)g, (byte)b);
				if (colorcode.Length == 6) {
				} else {
					int a = int.Parse(colorcode.Substring(1, 2), NumberStyles.HexNumber);
					col = Color.FromArgb((byte)r, (byte)g, (byte)b, (byte)a);
				}
				ColorSampleLavel.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));
				ColorSampleTB.Background = new SolidColorBrush(Color.FromRgb((byte)r, (byte)g, (byte)b));

				int Judgment = ((r * 299) + (g * 587) + (b * 114)) / 1000;
				ColorSampleJudg.Content = Judgment.ToString();
				if (Judgment < limit) {
					ColorSampleTB.Foreground = Brushes.White;
					ColorSampleTB.Text = "白文字";
					ColorSampleLavel.Foreground = Brushes.White;
					ColorSampleLavel.Content = "白文字";
				} else {
					ColorSampleTB.Foreground = Brushes.Black;
					ColorSampleTB.Text = "黒文字";
					ColorSampleLavel.Foreground = Brushes.Black;
					ColorSampleLavel.Content = "黒文字";
				}
			}
		}
		public static void MyLog(string TAG, string dbMsg)
		{
#if DEBUG
			Console.WriteLine(TAG + "[ParrtsTestView]" + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			Console.WriteLine(TAG + "[ParrtsTestView]" + dbMsg + "でエラー発生;" + err);
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
