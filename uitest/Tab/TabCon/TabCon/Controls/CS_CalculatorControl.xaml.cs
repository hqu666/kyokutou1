using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;

namespace TabCon.Controls {

	/// <summary>
	/// 電卓
	/// :ダイヤログなど別コントロールに組み込んで使用
	/// </summary>
	public partial class CS_CalculatorControl : UserControl {
		/// <summary>
		/// 結果の書き出し先
		/// </summary>
		public TextBox TargetTextBox {
			get { return (TextBox)GetValue(TargetTextBoxtProperty); }
			set { SetValue(TargetTextBoxtProperty, value); }
		}
		public static readonly DependencyProperty TargetTextBoxtProperty =
			DependencyProperty.Register("TargetTextBox", typeof(TextBox), typeof(CS_CalculatorControl), new PropertyMetadata(default(TextBox)));
	
		/// <summary>
		/// 電卓を表示しているウィンドウ
		/// </summary>
		public Window CalcWindow;

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
		public string BeforeOperation ="";
		/// <summary>
		/// 入力した演算子
		/// </summary>
		public string NowOperation = "";
		public string LineBreakStr = "\n";                  //XAML中は&#10;
		private static string AddStr = "＋";
		private static string SubtractStr = "－";
		private static string DivideStr = "÷";
		private static string MultiplyStr = "×";

		public Key OperatKey;

		/// <summary>
		/// 最初の入力か
		/// </summary>
		private bool IsBegin = true;
		/// <summary>
		/// 起動処理
		/// </summary>
		public CS_CalculatorControl()
		{
			InitializeComponent();
			CalcProcess.IsReadOnly = true;
			this.Loaded += ThisLoaded;
		}
		/// <summary>
		/// 読込み完了後、エレメント参照やプロセスの始動を行う
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ThisLoaded(object sender, RoutedEventArgs e)
		{
			string TAG = "UserControl_KeyDown";
			string dbMsg = "[CS_CalculatorControl]";
			try {
				Initialize();
				InputStr = TargetTextBox.Text;
				CalcProcess.Text = InputStr;
				dbMsg += ",OperatKey=" + OperatKey.ToString();
				if (Key.Add <= OperatKey ) {
					string NextOperation = "";
					switch (OperatKey) {
						case Key.Add:
						case Key.OemPlus:
							NextOperation = AddStr;
							break;
						case Key.Subtract:
						case Key.OemMinus:
							NextOperation = SubtractStr;
							break;
						case Key.Divide:
							NextOperation = DivideStr;
							break;
						case Key.Multiply:
							NextOperation = MultiplyStr;
							break;
					}
					dbMsg += ",=" + NextOperation;
					ProcessedFunc(NextOperation);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// CEと合わせ、初期化処理
		/// </summary>
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

		/// <summary>
		/// C:クリア：一文字づつ消去
		/// </summary>
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
					dbMsg += ",残り=" + BeforeVals.Count +"件";
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
						CalcMemo.Content = ProssesStr.Substring(0, (ProssesStr.Length - InputStr.Length- LastOperatier.Length - LineBreakStr.Length));
						CalcMemoScroll.ScrollToBottom();
						///最後の確定入力を消去
						BeforeVals.RemoveAt(BeforeVals.Count - 1);
						ProcessVal = ReCalk();
						CalcResult.Content = ProcessVal;
						BeforeOperation = LastOperatier;
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
				InputStr=CalcProcess.Text;
				if (InputStr.Equals("")) { 
					dbMsg += "処理する入力が無い";
					MyLog(TAG, dbMsg);
					MyCallBack();
				} else if (IsBegin) {
					IsBegin = false;
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
						CalcMemo.Content += LineBreakStr+OperationStr + InputStr;
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
					dbMsg += ",演算前=" + ProcessVal;
					if (BeforeOperation.Equals("") || IsBegin) {
						//演算子が無ければそのまま格納
						ProcessVal = BeforeVals[BeforeVals.Count - 1].Value;
						IsBegin = false;
					} else {
						//演算子が有れば演算
						ProcessVal = ReCalk();
					}
					dbMsg += "＞結果＞" + ProcessVal;
					SetResult(BeforeOperation);
					CalcOperation.Content = NextOperation;
				} else {
					dbMsg += ",入力無し：演算子から入力された";
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
		/// 再計算
		///  : Deleteなど追加する演算が無ければ演算子は"",値は0を指定して下さい
		/// </summary>
		/// <param name="AddOperater">演算子</param>
		/// <param name="AddVal">値</param>
		/// <returns></returns>
		private double ReCalk()
		{
			string TAG = "ReCalk";
			string dbMsg = "[CS_CalculatorControl]";
			double ResultNow = 0.0;
			try {
				foreach(var BeforeVal in BeforeVals) {
					string bOperater = BeforeVal.Operater;
					double bValue = BeforeVal.Value;
					dbMsg += "\r\n" + bOperater + " " + bValue;
					if (bOperater.Equals("")) {
						dbMsg += "＜＜開始" ;
						ResultNow = bValue;
					} else if (bOperater.Equals(AddStr)) {
						ResultNow += bValue;
					} else if (bOperater.Equals(SubtractStr)) {
						ResultNow -= bValue;
					} else if (bOperater.Equals(MultiplyStr)) {
						ResultNow *= bValue;
					} else if (bOperater.Equals(DivideStr)) {
						if (ResultNow != 0) {
							ResultNow /= bValue;
						}
					}
				}
				dbMsg += "=" + ResultNow;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return ResultNow;
		}

		/// <summary>
		/// 指定された入力枠に値を記入する
		/// Nullなら空白文字を記入する
		/// </summary>
		public void MyCallBack()
		{
			string rText = (string)CalcResult.Content;
			TargetTextBox.Text = (string)CalcResult.Content;
			CalcWindow.Close();
		}

		/// <summary>
		/// 除算
		/// </summary>
		private void DivideFunc()
		{
			if (!IsBegin && ProcessVal == 0) {
				MessageBox.Show("割られる値が0になっています。0は除算できません");
			} else if(!IsBegin && InputStr.Equals("")) {
				MessageBox.Show("割る値が0になっています。0は除算できません");
			} else{
				string NextOperation = DivideStr;
				ProcessedFunc(NextOperation);
			}
		}
		/// <summary>
		/// 積算
		/// </summary>
		private void MultiplyFunc()
		{
			string NextOperation = MultiplyStr;
			ProcessedFunc(NextOperation);
		}
		/// <summary>
		/// 減算
		/// </summary>
		private void MinusFunc()
		{
			string NextOperation = SubtractStr;
			ProcessedFunc(NextOperation);
		}
		/// <summary>
		/// 加算
		/// </summary>
		private void PlusFunc()
		{
			string NextOperation = AddStr;
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
						Key2ButtonClickerAsync(OneBt);
						break;
					case Key.NumPad2:
					case Key.D2:
						Key2ButtonClickerAsync(TwoBt);
						break;
					case Key.NumPad3:
					case Key.D3:
						Key2ButtonClickerAsync(ThreeBt);
						break;
					case Key.NumPad4:
					case Key.D4:
						Key2ButtonClickerAsync(FourBt);
						break;
					case Key.NumPad5:
					case Key.D5:
						Key2ButtonClickerAsync(FiveBt);
						break;
					case Key.NumPad6:
					case Key.D6:
						Key2ButtonClickerAsync(SixBt);
						break;
					case Key.NumPad7:
					case Key.D7:
						Key2ButtonClickerAsync(SevenBt);
						break;
					case Key.NumPad8:
					case Key.D8:
						Key2ButtonClickerAsync(EightBt);
						break;
					case Key.NumPad9:
					case Key.D9:
						Key2ButtonClickerAsync(NineBt);
						break;
					case Key.NumPad0:
					case Key.D0:
						Key2ButtonClickerAsync(ZeroBt);
						break;
					case Key.Decimal:
						Key2ButtonClickerAsync(PeriodBt);
						break;
					case Key.Add:
						Key2ButtonClickerAsync(PlusBt);
						break;
					case Key.Subtract:
						Key2ButtonClickerAsync(MinusBt);
						break;
					case Key.Multiply:
						Key2ButtonClickerAsync(AsteriskBt);
						break;
					case Key.Divide:
						Key2ButtonClickerAsync(SlashBt);
						break;
					case Key.Enter:
						Key2ButtonClickerAsync(EnterBt);
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
						Key2ButtonClickerAsync(ClearBt);
						break;
					case Key.Delete:
						 Key2ButtonClickerAsync(ClearAllBt);
						break;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			CalcProcess.Focus();
		}

		public Button TargetBt;
		/// <summary>
		/// キーボード押下に相当するボタンのクリック
		/// </summary>
		/// <param name="targetBt"></param>
		private async Task Key2ButtonClickerAsync(Button targetBt)
		{
			string TAG = "Key2ButtonClicker";
			string dbMsg = "[CS_CalculatorControl]";
			try {
				dbMsg += ",targetBt=" + targetBt.Name;
				TargetBt = targetBt;
				typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(targetBt, new object[] { true });
				targetBt.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
				await Task.Delay(100);
				typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(targetBt, new object[] { false });

				////以下でも動作はするがクリック表示にならない
				//var provider = new ButtonAutomationPeer(targetBt) as IInvokeProvider;
				//provider.Invoke();
				//もしくは	ClearBt_Click(new object(), new RoutedEventArgs());
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			CalcProcess.Focus();
		}
		////////////////////////////////////////////////////
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
		////////////////////////////////////////////////////
		/// <summary>
		/// 確定した演算子と数値
		/// </summary>
		public class BeforeVal{
			public string Operater { get; set; }
			public double Value { get; set; }
		}

	}

}
