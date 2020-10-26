﻿using System;
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

namespace CS_Calculator {
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
		public int FieldWidth { get; set; }
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
			Initialize();
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
				CalcTB.FontSize = (int)FieldFontSize;
				dbMsg += ",FieldWidth=" + FieldWidth;
				CalcTB.Width = (int)FieldWidth + 20;
				dbMsg += ",ViewTitle=" + ViewTitle;
				CalcText = CalcTB.Text;
				dbMsg += ",元の書込み=" + CalcText;
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
				Calculator calculatorControl = new Calculator();
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
				CalcWindow.Height = 350;
				dbMsg += "[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
				CalcWindow.FontSize = FieldFontSize;
				dbMsg += ",FontSize" + CalcWindow.FontSize;
				dbMsg += ",ViewTitol=" + ViewTitle;

				if (!ViewTitle.Equals("")) {
					CalcWindow.Title = ViewTitle;
				}
				CalcWindow.ShowDialog();

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		public void CalcWindowCloss()
		{
			if (CalcWindow.IsLoaded) {
				CalcWindow.Close();
			}
		}

		//////////////////////////////////////////////////電卓//
		public static void MyLog(string TAG, string dbMsg)
		{
			Console.WriteLine(TAG + " : " + dbMsg);
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