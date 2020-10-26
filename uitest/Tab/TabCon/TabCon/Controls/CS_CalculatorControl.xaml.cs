using Livet.Commands;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TabCon.Controls {
	/// <summary>
	/// CS_CalculatorControl.xaml の相互作用ロジック
	/// </summary>
	public partial class CS_CalculatorControl : UserControl {

		public CalculatorTextBox rootView;
		/// <summary>
		/// 計算結果
		/// </summary>
		public double ProcessVal = 0.0;
		/// <summary>
		/// キーボードもしくはボタンクリックで入力される値
		/// </summary>
		public string InputStr = "";
		/// <summary>
		/// 入力確定値の配列
		/// </summary>
		public IList<double> BeforeVals;
		/// <summary>
		/// 小数点以下の処理が必要
		/// </summary>
		public bool isDecimal = false;
		/// <summary>
		/// 直前の演算
		/// </summary>
		public string BeforeOperation ="";
		/// <summary>
		/// 入力した演算子
		/// </summary>
		public string NowOperation = "";

		/// <summary>
		/// 最初の入力か
		/// </summary>
		private bool IsBegin = true;
		/// <summary>
		/// 表示直後のコメント
		/// </summary>
//		private static string ProcessStartComment2 = "CA(Delete)で全消去";

		public CS_CalculatorControl()
		{
			InitializeComponent();
			Initialize();
			CalcProcess.Text = "ProcessStartComment2";
			CalcProcess.IsReadOnly = true;
		//	this.KeyPreview = True	Formのみ？
			//var window = Window.GetWindow(this);
			//window.KeyDown += HandleKeyPress;
		}

		public void Initialize()
		{
			ProcessVal = 0.0;
			InputStr = "";
			isDecimal = false;
			BeforeOperation = "";
			BeforeVals = new List<double>();
			CalcResult.Content = "";
			CalcOperation.Content = "";
			CalcMemo.Content = "";
			CalcProcess.Text = "";
			CalcProcess.Focus();
			IsBegin = true;
		}

		public ViewModelCommand ClearClick {
			get { return new Livet.Commands.ViewModelCommand(ClearFunc); }
		}
		private void ClearFunc()
		{
			string ProssesStr = CalcMemo.Content.ToString();
			if (0 < InputStr.Length) {
				InputStr = InputStr.Substring(0, InputStr.Length - 1);
				CalcProcess.Text = InputStr;
			}else{
				if (0 < BeforeVals.Count) {
					//最後の確定入力を逆算
					double LastInput = BeforeVals[BeforeVals.Count - 1];
					string LastOperatier = NowOperation;
					string Operatier = NowOperation;
					///最後の確定入力を消去
					BeforeVals.RemoveAt(BeforeVals.Count - 1);
					if (0 < BeforeVals.Count) {
						InputStr = BeforeVals[BeforeVals.Count - 1].ToString();
						CalcProcess.Text = InputStr;

						for (int DelCount = ProssesStr.Length - 1; 0 < DelCount; DelCount--) {
							ProssesStr = ProssesStr.Substring(0, DelCount);
							CalcMemo.Content = ProssesStr;
							if (ProssesStr.EndsWith("＋") || ProssesStr.EndsWith("－") || ProssesStr.EndsWith("×") || ProssesStr.EndsWith("÷")
							) {
								Operatier = ProssesStr.Substring(DelCount -1);
								LastOperatier = Operatier;
								NowOperation = Operatier;
								if(1< ProssesStr.Length) {
									for (int i = ProssesStr.Length - 1; 0 < i; i--) {
										string testStr = ProssesStr.Substring(0, i);
										if (testStr.EndsWith("＋") || testStr.EndsWith("－") || testStr.EndsWith("×") || testStr.EndsWith("÷")
										) {
											Operatier = testStr.Substring(i - 1);
											BeforeOperation = Operatier;
											CalcOperation.Content = Operatier;
											break;
										}
									}
								}else{
									BeforeOperation = "";
								}
								break;
							}
						}
					}
					if (1 < BeforeVals.Count) {
					//確定値の残り2つまでは逆算
						Operatier = LastOperatier;
						if (!Operatier.Equals("")) {
							if (Operatier.Equals("＋")) {
								ProcessVal -= LastInput;
							} else if (Operatier.Equals("－")) {
								ProcessVal += LastInput;
							} else if (Operatier.Equals("×")) {
								//	if (ProcessVal != 0) {
								ProcessVal /= LastInput;
								//		}
							} else if (Operatier.Equals("÷")) {
								ProcessVal *= LastInput;
							}
							CalcResult.Content = ProcessVal;
						}
					}else if(0 < BeforeVals.Count) {
						//最後の確定値になった時に演算情報リセット
						Operatier = "";
						BeforeOperation = Operatier;
						NowOperation = Operatier;
						CalcOperation.Content = Operatier;
					} else if (0 == BeforeVals.Count) {
						//確定値がなくなれば初期化
						Initialize();
					}
				}
			}

		}

		private void EnterFunc()
		{
		//	if(CalcOperation.Content.Equals("")) {
			if(InputStr.Equals("")) {               //1 < BeforeVals.Count  || 
				//演算した経過が有れば終了
				MyCallBack();
				rootView.CalcWindowCloss();
			}else if(IsContinuation()) {
				//			//無ければ入力の有無を確認して継続
				ProcessedFunc("");
	//			ProcessVal = BeforeVals[BeforeVals.Count - 1];
	//			SetResult("");
	////			}
			} else {
				ProcessedFunc(BeforeOperation);
			}
		}
	
		/// <summary>
		/// 最初の入力ではない
		/// 各演算開始前に最初の入力値か否かを返す
		/// </summary>
		/// <returns></returns>
		public bool IsContinuation()
		{
			bool retBool = false;
			if (!InputStr.Equals("")) {
				//演算値が有れば配列格納
				BeforeVals.Add(Double.Parse(InputStr));
				if (IsBegin) {
					IsBegin = false;
				}else{
					retBool = true;
				}
			}
			return retBool;
		}

		/// <summary>
		/// 演算結果を表示し、次の入力を待つ
		/// </summary>
		/// <param name="OperationStr"></param>
		public void SetResult(string OperationStr)
		{
			CalcResult.Content = ProcessVal.ToString();
			if(!InputStr.Equals("")) {
				if (CalcMemo.Content.Equals("")) {
					CalcMemo.Content += "=" + InputStr;
				} else {
					CalcMemo.Content += OperationStr + InputStr;
				}
			}
			InputStr = "";
			CalcProcess.Text = InputStr;
		}

		/// <summary>
		/// 演算子キーが押された時点で前の演算を処理して、値の入力を待つ
		/// </summary>
		private void ProcessedFunc(string NextOperation)
		{
			if (!InputStr.Equals("")) {
				//演算値が有れば配列格納
				BeforeVals.Add(Double.Parse(InputStr));
				if (BeforeOperation.Equals("") || IsBegin) {
					//演算子が無ければそのまま格納
					ProcessVal = BeforeVals[BeforeVals.Count - 1];
					IsBegin = false;
				} else{
					//演算子が有れば演算
					if (BeforeOperation.Equals("＋")) {
						ProcessVal += BeforeVals[BeforeVals.Count - 1];
					} else if (BeforeOperation.Equals("－")) {
						ProcessVal -= BeforeVals[BeforeVals.Count - 1];
					} else if (BeforeOperation.Equals("×")) {
						ProcessVal *= BeforeVals[BeforeVals.Count - 1];
					} else if (BeforeOperation.Equals("÷")) {
						if(ProcessVal !=0) {
							ProcessVal /= BeforeVals[BeforeVals.Count - 1];
						}
					}
				}
				SetResult(BeforeOperation);
				CalcOperation.Content = NextOperation;
			} else {
				//演算値が無ければ入力する値の演算区分だけを記入
				CalcOperation.Content = NextOperation;
			}
			BeforeOperation = NextOperation;
		}


		/// <summary>
		/// 除算
		/// </summary>
		private void DivideFunc()
		{
			//if (IsBegin) {
			//	if (!InputStr.Equals("")) {
			//		//演算値が有れば配列格納
			//		BeforeVals.Add(Double.Parse(InputStr));
			//		ProcessVal = BeforeVals[BeforeVals.Count - 1];
			//	}
			//} else 
			if (!IsBegin &&ProcessVal == 0) {
				MessageBox.Show("割られる値が0になっています。0は除算できません");
			} else if(InputStr.Equals("")) {
				MessageBox.Show("割る値が0になっています。0は除算できません");
			} else{
				string NextOperation = "÷";
				ProcessedFunc(NextOperation);
			}
		}

		/// <summary>
		/// 積算
		/// </summary>
		private void MultiplyFunc()
		{
			string NextOperation = "×";
			ProcessedFunc(NextOperation);
		}
		/// <summary>
		/// 減算
		/// </summary>
		private void MinusFunc()
		{
			string NextOperation = "－";
			ProcessedFunc(NextOperation);
		}
		/// <summary>
		/// 加算
		/// </summary>
		private void PlusFunc()
		{
			string NextOperation = "＋";
			ProcessedFunc(NextOperation);
		}
		/// <summary>
		/// 小数点
		/// </summary>
		private void DecimalFunc()
		{
			isDecimal = true;
			InputStr += ".";
			CalcProcess.Text = InputStr;
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
			InputStr += "0";
			CalcProcess.Text = InputStr;
		}
		private void OneBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "1";
			CalcProcess.Text = InputStr;
		}
		private void TwoBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "2";
			CalcProcess.Text = InputStr;
		}
		private void ThreeBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "3";
			CalcProcess.Text = InputStr;
		}
		private void FourBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "4";
			CalcProcess.Text = InputStr;
		}
		private void FiveBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "5";
			CalcProcess.Text = InputStr;
		}
		private void SixBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "6";
			CalcProcess.Text = InputStr;
		}
		private void SevenBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "7";
			CalcProcess.Text = InputStr;
		}
		private void EightBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "8";
			CalcProcess.Text = InputStr;
		}
		private void NineBt_Click(object sender, RoutedEventArgs e)
		{
			InputStr += "9";
			CalcProcess.Text = InputStr;
		}

	
		public void MyCallBack()
		{
			if (!CalcResult.Content.Equals("")) {
				rootView.CalcTB.Text = (string)CalcResult.Content;
			}
		}

		private void UserControl_Unloaded(object sender, RoutedEventArgs e)
		{
			MyCallBack();
		}

		/// <summary>
		/// 通常のキーダウンイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserControl_KeyDown(object sender, KeyEventArgs e)
		{
			Key key = e.Key;
			switch (key) {
				case Key.NumPad1:
				case Key.D1:
					OneBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad2:
				case Key.D2:
					TwoBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad3:
				case Key.D3:
					ThreeBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad4:
				case Key.D4:
					FourBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad5:
				case Key.D5:
					FiveBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad6:
				case Key.D6:
					SixBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad7:
				case Key.D7:
					SevenBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad8:
				case Key.D8:
					EightBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad9:
				case Key.D9:
					NineBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.NumPad0:
				case Key.D0:
					ZeroBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.Decimal:
					PeriodBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.Add:
					PlusBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.Subtract:
					MinusBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.Multiply:
					AsteriskBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.Divide:
					SlashBt_Click(new object(), new RoutedEventArgs());
					break;
				case Key.Enter:
					EnterBt_Click(new object(), new RoutedEventArgs());
					break;
			}
			CalcProcess.Focus();
		}

		/// <summary>
		/// BackSpace,Delete,Fキーはここ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Back) {
				ClearBt_Click(new object(), new RoutedEventArgs());
			}else if (e.Key == Key.Delete) {
				ClearAllBt_Click(new object(), new RoutedEventArgs());
			}
		}

	}
}
