using System;
using System.Windows;
using Livet;
using Livet.Commands;
using CS_Calculator;
using System.Windows.Controls;

namespace WpfApp1.ViewModels {
	public class ParrtsTestViewModel : ViewModel {
		public string titolStr = "カスタムパーツテスト";

		public Views.ParrtsTestView MyView { get; set; }
		//	public ViewModels.MainViewModel RootViewModel { get; set; }
		public TextBox TargetTextBox { get; set; }
		
		/// <summary>
		/// 結果表示フィールド値
		/// </summary>
		public string CalcResult { get; set; }
		/// <summary>
		/// ダイアログタイトル
		/// </summary>
		public string CalcTextDLogTitol { get; set; }
		/// <summary>
		/// 幅
		/// </summary>
		public string CalcTexWidth { get; set; }
		/// <summary>
		/// フォントサイズ
		/// </summary>
		public string CalcTextFontSize { get; set; }

		public ParrtsTestViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			CalcTextDLogTitol = "電卓を表示するフィールドから";
			CalcTexWidth = "200";
			CalcTextFontSize = "18";
			CalcResult = "0123456789";
			RaisePropertyChanged();

			//	MyView.CalcTextSammple.CalcText = "1234567890"; だと
			//System.NullReferenceException: 'オブジェクト参照がオブジェクト インスタンスに設定されていません。'
			//abCon.ViewModels.ParrtsTestViewModel.MyView.get が null を返しました。
		}

		//電卓/////////////////////////////////////////////////////////////////////////
		public ViewModelCommand ShowCalc {
			get { return new Livet.Commands.ViewModelCommand(CalcShow); }
		}
		/// <summary>
		/// 電卓表示
		/// </summary>
		public void CalcShow()
		{
			string TAG = "CalcShow";
			string dbMsg = "[ParrtsTestViewModel]";
			try {
				CS_CalculatorControl calculatorControl = new CS_CalculatorControl();

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
				//CalcResult = MyView.CalcTextSammple.CalcTB.Text;
				RaisePropertyChanged("CalcResult");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void window_Closed(object sender, EventArgs e)
		{
			string TAG = "window_Closed";
			string dbMsg = "[ParrtsTestViewModel]";
			try {
				CalcResult = TargetTextBox.Text;
				dbMsg = ",CalcResult=" + CalcResult;
				RaisePropertyChanged("CalcResult");
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
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

