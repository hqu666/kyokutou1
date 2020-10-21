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
	/// CS_CalculatorControl.xaml の相互作用ロジック
	/// </summary>
	public partial class CS_CalculatorControl : UserControl {

		public CalculatorTextBox rootView;
		public double ProcessVal = 0.0;
		public string BeforeVal = "";
		public bool isDecimal = false;
		public string BeforeOperation ="";
		public IList<double> BeforeVals ;


		public CS_CalculatorControl()
		{
			InitializeComponent();
			Initialize();
			CalcProcess.IsReadOnly = true;
		}

		public void Initialize()
		{
			ProcessVal = 0.0;
			BeforeVal = "";
			isDecimal = false;
			BeforeOperation = "";
			BeforeVals = new List<double>();
			CalcResult.Content = "";
			CalcOperation.Content = "";
			CalcProcess.Text = "0";
			CalcProcess.Focus();
		}

		public void MyCallBack()
		{
			if(!CalcResult.Content.Equals("")) {
				rootView.CalcTB.Text = (string)CalcResult.Content;
			}
		}

		private void ClearFunc()
		{
			if (0 < BeforeVal.Length) {
				BeforeVal = BeforeVal.Substring(0, BeforeVal.Length - 1);
				CalcProcess.Text = BeforeVal;
			}
			//if(0<BeforeVals.Count) {
			//	if (BeforeOperation.Equals("Plus")) {
			//		ProcessVal -= BeforeVals[BeforeVals.Count - 1];
			//	} else if (BeforeOperation.Equals("Minus")) {
			//		ProcessVal += BeforeVals[BeforeVals.Count - 1];
			//	} else if (BeforeOperation.Equals("Asterisk")) {
			//		ProcessVal /= BeforeVals[BeforeVals.Count - 1];
			//	} else if (BeforeOperation.Equals("Slash")) {
			//		ProcessVal *= BeforeVals[BeforeVals.Count - 1];
			//	}
			//	BeforeVals.RemoveAt(BeforeVals.Count - 1);
			//}
		}

		private void EnterFunc()
		{
			if(CalcOperation.Content.Equals("")) {

				MyCallBack();
				rootView.CalcWindowCloss();
			} else{
				if (BeforeOperation.Equals("Plus")) {
					ProcessVal += BeforeVals[BeforeVals.Count - 1];
				} else if (BeforeOperation.Equals("Minus")) {
					ProcessVal -= BeforeVals[BeforeVals.Count - 1];
				} else if (BeforeOperation.Equals("Asterisk")) {
					ProcessVal *= BeforeVals[BeforeVals.Count - 1];
				} else if (BeforeOperation.Equals("Slash")) {
					ProcessVal /= BeforeVals[BeforeVals.Count - 1];
				}
				CalcResult.Content = ProcessVal.ToString();
				CalcOperation.Content = "";
				CalcProcess.Text = "0";
			}
		}

		/// <summary>
		/// 除算
		/// </summary>
		private void DivideFunc()
		{
			BeforeOperation = "Slash";
			//割る値が有る
			if (!BeforeVal.Equals("")) {
				BeforeVals.Add(Double.Parse(BeforeVal));
				//割られる値が有る；0除算にならない
				if (ProcessVal != 0) {
				//割り算を既に指定されている
					if (CalcOperation.Content.Equals("÷")) {
						ProcessVal /= BeforeVals[BeforeVals.Count - 1];
					}
				} else {
					//	MessageBox.Show("0は除算できません");
					ProcessVal = BeforeVals[BeforeVals.Count - 1];
				}
				CalcResult.Content = ProcessVal.ToString();
				CalcOperation.Content = "÷";
				BeforeVal = "";
				CalcProcess.Text = BeforeVal;
			}
		}
		/// <summary>
		/// 積算
		/// </summary>
		private void MultiplyFunc()
		{
			BeforeOperation = "Asterisk";
			if (!BeforeVal.Equals("")) {
				BeforeVals.Add(Double.Parse(BeforeVal));
				if (ProcessVal != 0) {
					ProcessVal *= BeforeVals[BeforeVals.Count - 1];
				} else {
					ProcessVal = BeforeVals[BeforeVals.Count - 1];
				}
				CalcResult.Content = ProcessVal.ToString();
				CalcOperation.Content = "×";
				BeforeVal = "";
				CalcProcess.Text = BeforeVal;
			}
		}
		/// <summary>
		/// 減算
		/// </summary>
		private void MinusFunc()
		{
			BeforeOperation = "Minus";
			if (!BeforeVal.Equals("")) {
				BeforeVals.Add(Double.Parse(BeforeVal));
				if (ProcessVal != 0) {
					ProcessVal -= BeforeVals[BeforeVals.Count - 1];
				} else {
					ProcessVal = BeforeVals[BeforeVals.Count - 1];
				}
				CalcResult.Content = ProcessVal.ToString();
				CalcOperation.Content = "―";
				BeforeVal = "";
				CalcProcess.Text = BeforeVal;
			}
		}
		/// <summary>
		/// 加算
		/// </summary>
		private void PlusFunc()
		{
			BeforeOperation = "Plus";
			if (!BeforeVal.Equals("")) {
				BeforeVals.Add(Double.Parse(BeforeVal));
				if (ProcessVal != 0) {
					ProcessVal += BeforeVals[BeforeVals.Count - 1];
				} else {
					ProcessVal = BeforeVals[BeforeVals.Count - 1];
				}
				CalcResult.Content = ProcessVal.ToString();
				CalcOperation.Content = "＋";
				BeforeVal = "";
				CalcProcess.Text = BeforeVal;
			}
		}
		/// <summary>
		/// 小数点
		/// </summary>
		private void DecimalFunc()
		{
			isDecimal = true;
			BeforeVal += ".";
			CalcProcess.Text = BeforeVal;
		}
		private void PlusBt_Click(object sender, RoutedEventArgs e)
		{
			PlusFunc();
		}
		private void MinusBt_Click(object sender, RoutedEventArgs e)
		{
			MinusFunc();
		}
		private void AsteriskBt_Click(object sender, RoutedEventArgs e)
		{
			MultiplyFunc();
		}
		private void SlashBt_Click(object sender, RoutedEventArgs e)
		{
			DivideFunc();
		}
		private void EnterBt_Click(object sender, RoutedEventArgs e)
		{
			EnterFunc();
		}
		private void ClearBt_Click(object sender, RoutedEventArgs e)
		{
			ClearFunc();
		}
		private void ClearAllBt_Click(object sender, RoutedEventArgs e)
		{
			Initialize();
		}

		private void PeriodBt_Click(object sender, RoutedEventArgs e)
		{
			DecimalFunc();
		}
		private void ZeroBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "0";
			CalcProcess.Text = BeforeVal;
		}
		private void OneBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "1";
			CalcProcess.Text = BeforeVal;
		}
		private void TwoBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "2";
			CalcProcess.Text = BeforeVal;
		}
		private void ThreeBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "3";
			CalcProcess.Text = BeforeVal;
		}
		private void FourBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "4";
			CalcProcess.Text = BeforeVal;
		}
		private void FiveBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "5";
			CalcProcess.Text = BeforeVal;
		}
		private void SixBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "6";
			CalcProcess.Text = BeforeVal;
		}
		private void SevenBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "7";
			CalcProcess.Text = BeforeVal;
		}
		private void EightBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "8";
			CalcProcess.Text = BeforeVal;
		}
		private void NineBt_Click(object sender, RoutedEventArgs e)
		{
			BeforeVal += "9";
			CalcProcess.Text = BeforeVal;
		}

		private void UserControl_KeyDown(object sender, KeyEventArgs e)
		{
			var key = e.Key;
			switch (key) {
				case Key.NumPad1:
				case Key.D1:
					BeforeVal += "1";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad2:
				case Key.D2:
					BeforeVal += "2";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad3:
				case Key.D3:
					BeforeVal += "3";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad4:
				case Key.D4:
					BeforeVal += "4";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad5:
				case Key.D5:
					BeforeVal += "5";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad6:
				case Key.D6:
					BeforeVal += "6";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad7:
				case Key.D7:
					BeforeVal += "7";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad8:
				case Key.D8:
					BeforeVal += "8";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad9:
				case Key.D9:
					BeforeVal += "9";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.NumPad0:
				case Key.D0:
					BeforeVal += "0";
					CalcProcess.Text = BeforeVal;
					break;
				case Key.Decimal:
					DecimalFunc();
					break;
				case Key.Add:
					PlusFunc();
					break;
				case Key.Subtract:
					MinusFunc();
					break;
				case Key.Multiply:
					MultiplyFunc();
					break;
				case Key.Divide:
					DivideFunc();
					break;
				case Key.Back:
					ClearFunc();
					break;
				case Key.Delete:
					Initialize();
					break;
				case Key.Enter:
					EnterFunc();
					break;
			}
			CalcProcess.Focus();
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			MyCallBack();
		}


		//private void CalcProcess_TextChanged(object sender, TextChangedEventArgs e)
		//{
		//	BeforeVal = CalcProcess.Text;
		//}
		//private void CalcProcess_SelectionChanged(object sender, RoutedEventArgs e)
		//{
		//	BeforeVal = CalcProcess.Text;
		//}


	}
}
