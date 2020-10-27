using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Livet;
using Livet.Commands;

namespace CS_Calculator {
	/// <summary>
	/// CS_CalculatorControl.xaml の相互作用ロジック
	/// </summary>
	public partial class CS_CalculatorControl : UserControl {
		//public CS_CalculatorViewModel VM;
		/// <summary>
		/// 呼出しボタン
		/// </summary>
		public CalculatorButton rootBT;

	//	public CalculatorTextBox rootView;
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
		public IList<BeforeVal> BeforeVals;
		/// <summary>
		/// 小数点以下の処理が必要
		/// </summary>
		public bool isDecimal = false;
		/// <summary>
		/// 直前の演算
		/// </summary>
		public string BeforeOperation = "";
		/// <summary>
		/// 入力した演算子
		/// </summary>
		public string NowOperation = "";
		public string LineBreakStr = "\n";                  //XAML中は&#10;

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
			CalcProcess.IsReadOnly = true;
			//VM = new CS_CalculatorViewModel();
			//this.DataContext = VM;
			this.Loaded += this_loaded;
		}
		//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
		private void this_loaded(object sender, RoutedEventArgs e)
		{
			string InputStrStock = InputStr;
			Initialize();
			//VM.CResult = "C(BackSpace)ボタンは1クリックで1文字づつ消去します";
			//VM.CInput = "CA(Delete)で全消去";
			//VM.MyView = this;
			CalcProcess.Text = InputStrStock;
		}

		public void Initialize()
		{
			InputStr = "";              //最終入力値を残す為、初期化から外す?
			BeforeVals = new List<BeforeVal>();
			ProcessVal = 0.0;
			isDecimal = false;
			BeforeOperation = "";
			CalcResult.Content = "";
			CalcOperation.Content = "";
			CalcMemo.Content = "";
			CalcProcess.Text = "";
			CalcProcess.Focus();
			IsBegin = true;
		}

		//public ViewModelCommand ClearClick {
		//	get { return new Livet.Commands.ViewModelCommand(ClearFunc); }
		//}
		private void ClearFunc()
		{
			string TAG = "ClearFunc";
			string dbMsg = "[CS_CalculatorControl]";
			try {
				string ProssesStr = CalcMemo.Content.ToString();
				InputStr = CalcProcess.Text;
				dbMsg += ",入力状況=" + InputStr;
				if (0 < InputStr.Length) {
					//入力エリアに文字が有る間は一文字づつ消去
					InputStr = InputStr.Substring(0, InputStr.Length - 1);
					CalcProcess.Text = InputStr;
				} else {
					dbMsg += ",残り=" + BeforeVals.Count + "件";
					if (1 < BeforeVals.Count) {
						//最終確定入力を読出し
						BeforeVal LastInput = BeforeVals[BeforeVals.Count - 1];
						//演算子と
						string LastOperatier = LastInput.Operater;
						CalcOperation.Content = LastOperatier;
						//値を転記
						double LastValue = LastInput.Value;
						dbMsg += "＝" + LastOperatier + " : " + LastValue;
						InputStr = LastValue.ToString();
						CalcProcess.Text = InputStr;
						//計算過程から最終確定値と演算子を消去
						CalcMemo.Content = ProssesStr.Substring(0, (ProssesStr.Length - InputStr.Length - LastOperatier.Length - LineBreakStr.Length));
						CalcMemoScroll.ScrollToBottom();
						//計算結果修正
						if (!LastOperatier.Equals("")) {
							if (LastOperatier.Equals("＋")) {
								ProcessVal -= LastValue;
							} else if (LastOperatier.Equals("－")) {
								ProcessVal += LastValue;
							} else if (LastOperatier.Equals("×")) {
								//	if (ProcessVal != 0) {
								ProcessVal /= LastValue;
								//		}
							} else if (LastOperatier.Equals("÷")) {
								ProcessVal *= LastValue;
							}
							CalcResult.Content = ProcessVal;
						}
						BeforeOperation = LastOperatier;
						///最後の確定入力を消去
						BeforeVals.RemoveAt(BeforeVals.Count - 1);
					} else {
						//最終入力の
						BeforeVal LastInput = BeforeVals[0];
						//演算子を転記
						string LastOperatier = LastInput.Operater;
						//値を読み出し
						double LastValue = LastInput.Value;
						dbMsg += "＝" + LastOperatier + " : " + LastValue;
						string LastInputStr = LastValue.ToString();
						Initialize();
						//格納値をクリアした後で最終入力をフィールドに書き戻す
						CalcOperation.Content = LastOperatier;
						CalcProcess.Text = LastInputStr;
					}
				}
				dbMsg += ">残り>" + BeforeVals.Count + "件";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void EnterFunc()
		{
			string TAG = "EnterFunc";
			string dbMsg = "[CS_CalculatorControl]";
			try {
				if (InputStr.Equals("")) {
					dbMsg += "処理する入力が無い";
					//VM.CResult = ProcessVal.ToString();
					//dbMsg += "、CResult=" + VM.CResult;
					MyLog(TAG, dbMsg);
					MyCallBack();
				} else if (IsContinuation()) {
					//			//無ければ入力の有無を確認して継続
					ProcessedFunc("");
				} else {
					dbMsg += "," + InputStr + "を" + BeforeOperation;
					ProcessedFunc(BeforeOperation);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 最初の入力ではない
		/// 各演算開始前に最初の入力値か否かを返す
		/// </summary>
		/// <returns></returns>
		public bool IsContinuation()
		{
			string TAG = "IsContinuation";
			string dbMsg = "[CS_CalculatorControl]";
			bool retBool = false;
			try {
				if (!InputStr.Equals("")) {
					//BeforeVal NowInput = new BeforeVal();
					//NowInput.Operater = CalcOperation.Content.ToString();
					//NowInput.Value = Double.Parse(InputStr);
					////演算値が有れば配列格納
					//BeforeVals.Add(NowInput);
					if (IsBegin) {
						dbMsg += "入力開始";
						IsBegin = false;
					} else {
						dbMsg += "入力継続中";
						retBool = true;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retBool;
		}

		/// <summary>
		/// 演算結果を表示し、次の入力を待つ
		/// </summary>
		/// <param name="OperationStr"></param>
		public void SetResult(string OperationStr)
		{
			string TAG = "SetResult";
			string dbMsg = "[CS_CalculatorControl]";
			dbMsg += ",OperationStr=" + OperationStr;
			try {
				CalcResult.Content = ProcessVal.ToString();
				string ProssesStr = CalcMemo.Content.ToString();

				if (!InputStr.Equals("")) {
					if (CalcMemo.Content.Equals("")) {
						dbMsg += "入力開始";
						CalcMemo.Content += "=" + InputStr;
					} else {
						dbMsg += "入力継続中";
						CalcMemo.Content += LineBreakStr + OperationStr + InputStr;
						CalcMemoScroll.ScrollToBottom();
					}
				}
				InputStr = "";
				CalcProcess.Text = InputStr;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 演算子キーが押された時点で前の演算を処理して、値の入力を待つ
		/// </summary>
		private void ProcessedFunc(string NextOperation)
		{
			string TAG = "ProcessedFunc";
			string dbMsg = "[CS_CalculatorControl]";
			try {
				if (!InputStr.Equals("")) {
					//演算値が有れば配列格納
					BeforeVal NowInput = new BeforeVal();
					NowInput.Operater = CalcOperation.Content.ToString();
					NowInput.Value = Double.Parse(InputStr);
					dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
					BeforeVals.Add(NowInput);
					dbMsg += ",演算結果=" + ProcessVal;
					if (BeforeOperation.Equals("") || IsBegin) {
						//演算子が無ければそのまま格納
						ProcessVal = BeforeVals[BeforeVals.Count - 1].Value;
						IsBegin = false;
					} else {
						//演算子が有れば演算
						if (BeforeOperation.Equals("＋")) {
							ProcessVal += BeforeVals[BeforeVals.Count - 1].Value;
						} else if (BeforeOperation.Equals("－")) {
							ProcessVal -= BeforeVals[BeforeVals.Count - 1].Value;
						} else if (BeforeOperation.Equals("×")) {
							ProcessVal *= BeforeVals[BeforeVals.Count - 1].Value;
						} else if (BeforeOperation.Equals("÷")) {
							if (ProcessVal != 0) {
								ProcessVal /= BeforeVals[BeforeVals.Count - 1].Value;
							}
						}
					}
					dbMsg += "＞＞" + ProcessVal;
					SetResult(BeforeOperation);
					CalcOperation.Content = NextOperation;
				} else {
					dbMsg += ",入力無し";
					//演算値が無ければ入力する値の演算区分だけを記入
					CalcOperation.Content = NextOperation;
				}
				BeforeOperation = NextOperation;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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
			if (!IsBegin && ProcessVal == 0) {
				MessageBox.Show("割られる値が0になっています。0は除算できません");
			} else if (InputStr.Equals("")) {
				MessageBox.Show("割る値が0になっています。0は除算できません");
			} else {
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

		/// <summary>
		/// 指定された入力枠に値を記入する
		/// </summary>
		public void MyCallBack()
		{
			if (!CalcResult.Content.Equals("")) {
				if (rootBT != null) {
					rootBT.TargetTextBox.Text = (string)CalcResult.Content;
					rootBT.CalcWindowCloss();
				}
			}
		}

		/// <summary>
		/// クローズボックスなどで強制的にUnloadされた場合
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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
			string TAG = "UserControl_KeyDown";
			string dbMsg = "[CS_CalculatorControl]";
			try {
				Key key = e.Key;
				dbMsg += "key=" + key.ToString();
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
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
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
			string TAG = "UserControl_PreviewKeyDown";
			string dbMsg = "[CS_CalculatorControl]";
			try {
				Key key = e.Key;
				dbMsg += "key=" + key.ToString();
				switch (key) {
					case Key.Back:
						ClearBt_Click(new object(), new RoutedEventArgs());
						break;
					case Key.Delete:
						ClearAllBt_Click(new object(), new RoutedEventArgs());
						break;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			CalcProcess.Focus();
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

		/// <summary>
		/// 確定した演算子と数値
		/// </summary>
		public class BeforeVal {
			public string Operater { get; set; }
			public double Value { get; set; }
		}

	}
}
