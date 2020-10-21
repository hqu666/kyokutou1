﻿using Livet;
using Livet.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace TabCon.ViewModels {
	public class ParrtsTestViewModel : ViewModel {
		public string titolStr = "カスタムパーツテスト";

		public Views.ParrtsTestView MyView { get; set; }
		public ViewModels.MainViewModel RootViewModel { get; set; }

		public string CalcResult { get; set; }

		public ParrtsTestViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			CalcResult = "電卓の計算結果をここに表示します";
		}

		//電卓/////////////////////////////////////////////////////////////////////////
		public ViewModelCommand ShowCalc {
			get { return new Livet.Commands.ViewModelCommand(CalcShow); }
		}
		/// <summary>
		/// Googleカレンダーに反映
		/// </summary>
		public void CalcShow()
		{
			string TAG = "CalcShow";
			string dbMsg = "[MySQLBase]";
			try {
				Controls.CS_CalculatorControl calculatorControl = new Controls.CS_CalculatorControl();

				Window window = new Window {
					Title = "電卓で計算",
					Content = calculatorControl,
					ResizeMode = ResizeMode.NoResize
				};
				window.Width = 300;
				window.Height = 350;
				window.Topmost = true;
				//		window.RaiseEvent
				window.ShowDialog();
				window.Closed += new EventHandler(window_Closed);
				//			CalcResult = "電卓で計算しました";

				RaisePropertyChanged("CalcResult");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void window_Closed(object sender, EventArgs e)
		{
			string TAG = "window_Closed";
			string dbMsg = "[MySQLBase]";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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