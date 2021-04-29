using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using System.Configuration;
using System.Runtime.InteropServices;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Text.RegularExpressions;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
//using GsSGCell = GrapeCity.Windows.SpreadGrid.Cell;
//using XDGCell = Infragistics.Windows.DataPresenter.Cell;

namespace CS_Calculator{
	/// <summary>
	/// 電卓
	/// :ダイヤログなど別コントロールに組み込んで使用
	/// </summary>
	/// C:\work\2020\kyokuto\Smple\uitest\Tab\TabCon\CS_Calculator\CS_CalculatorControl.xaml.cs

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
		/// DataGridのセル
		/// </summary>
		public TextBlock TargetTextBlock {
			get { return (TextBlock)GetValue(TargetTextBlockProperty); }
			set { SetValue(TargetTextBlockProperty, value); }
		}
		public static readonly DependencyProperty TargetTextBlockProperty =
			DependencyProperty.Register("TargetTextBlock", typeof(TextBlock), typeof(CS_CalculatorControl), new PropertyMetadata(default(TextBlock)));

		///// <summary>
		///// XamDataGridのセル
		///// </summary>
		//public XDGCell TargetCell {
		//	get { return (XDGCell)GetValue(TargetCellProperty); }
		//	set { SetValue(TargetCellProperty, value); }
		//}
		//public static readonly DependencyProperty TargetCellProperty =
		//	DependencyProperty.Register("TargetField", typeof(XDGCell), typeof(CS_CalculatorControl), new PropertyMetadata(default(XDGCell)));

		///// <summary>
		///// GcSpreadGridのセル
		///// </summary>
		//public GsSGCell TargetGsCell {
		//	get { return (GsSGCell)GetValue(TargetGsCellProperty); }
		//	set { SetValue(TargetGsCellProperty, value); }
		//}
		//public static readonly DependencyProperty TargetGsCellProperty =
		//	DependencyProperty.Register("TargetGsCell", typeof(GsSGCell), typeof(CS_CalculatorControl), new PropertyMetadata(default(GsSGCell)));

		/// <summary>
		/// キーボードもしくはボタンクリックで入力される値
		/// 初期値
		/// </summary>
		public string InputStr {
			get { return (string)GetValue(InputStrProperty); }
			set { SetValue(InputStrProperty, value); }
		}
		public static readonly DependencyProperty InputStrProperty =
			DependencyProperty.Register("InputStr", typeof(string), typeof(CS_CalculatorControl), new PropertyMetadata(default(string)));

		public string ResultStr {
			get { return (string)GetValue(ResultStrProperty); }
			set { SetValue(ResultStrProperty, value); }
		}
		public static readonly DependencyProperty ResultStrProperty =
			DependencyProperty.Register("ResultStr", typeof(string), typeof(CS_CalculatorControl), new PropertyMetadata(default(string)));

		/// <summary>
		/// 四則演算の優先順位で計算
		/// </summary>
		public bool IsPO {
			get { return (bool)GetValue(IsPOProperty); }
			set { SetValue(IsPOProperty, value); }
		}
		public static readonly DependencyProperty IsPOProperty =
			DependencyProperty.Register("IsPO", typeof(bool), typeof(CS_CalculatorControl), new PropertyMetadata(default(bool)));


		/// <summary>
		/// 電卓を表示しているウィンドウ
		/// </summary>
		public Window CalcWindow;

		public string SelectOperater { get; set; }
		public string SelectValue { get; set; }

		/// <summary>
		/// 計算結果
		/// </summary>
		public double ProcessVal = 0.0;
		/// <summary>
		/// 入力確定値の配列
		/// </summary>
		public ObservableCollection<BeforeVal> BeforeVals;
		//表示①CalcResult:計算結果
		//表示②NowOperations.Text;計算過程は各入力時点で追記され、ReCalkで入力確定値の配列の読みだしに更新される
		//		数字はNumInput、演算子はProcessedFuncの開始時に追記されるがParenthesisはここを通さない
		//表示③CalcProgress
		//破棄	CalcOperation、CalcProcess
		/// <summary>
		/// 小数点以下の処理が必要
		/// </summary>
		public bool isDecimal = false;
		/// <summary>
		/// 直前の演算
		/// </summary>
		public string BeforeOperation = "";
		/// <summary>
		/// 入力値を負数にする
		/// </summary>
		public bool isMinus = false;

		/// <summary>
		/// 入力した演算子
		/// </summary>
		public string NowOperation = "";
		public string LineBreakStr = "\n";                  //XAML中は&#10;
		private static string AddStr = "+";
		private static string SubtractStr = "-";                //演算子ではなく数値を負数化する
		private static string DivideStr = "/";
		private static string MultiplyStr = "*";
		private static string ParenStr = "(";
		private static string ParenthesisStr = ")";
		private static string[] MyOperaters = { AddStr, SubtractStr, DivideStr, MultiplyStr, ParenStr, ParenthesisStr };

		private static string PowerStr = "Pow(";       // "^";
		private static string SqrtStr = "Sqrt(";       //"√";
		private static string SinStr = "Sin(";             //Math.Sin(
		private static string CosStr = "Cos(";             //Math.Cos(
		private static string TanStr = "Tan(";             //Math.Tan(
		private static string AsinStr = "Asin(";             //Math.Asin(
		private static string AcosStr = "Acos(";             //Math.Acos(
		private static string AtanStr = "Atan(";             //Math.Atan(
		private static string[]MyFunctions={PowerStr,SqrtStr, SinStr , CosStr , TanStr , AsinStr, AcosStr , AtanStr };
	
		private static string PiStr = "PI";             //Math.PI :定数
		private static string[] MyConstants = { PiStr };

		public Key OperatKey;

		/// <summary>
		/// 最初の入力か
		/// </summary>
		private bool IsBegin = true;
		/// <summary>
		/// 編集値の変更か
		/// </summary>
		private bool IsPrgresEdit = false;

		/// <summary>
		/// Shiftキーを押された
		/// </summary>
		private bool IsShiftKey = false;
		/// <summary>
		/// 優先範囲の階層
		/// </summary>
		private int ParenCount = 0;
		/// <summary>
		/// 再帰回数
		/// </summary>
		private int recursionCount = 0;
		private int recursionCount2 = 0;

		/// <summary>
		/// 起動処理
		/// </summary>
		public CS_CalculatorControl()
		{
			InitializeComponent();
			this.Loaded += ThisLoaded;
		}

		/// <summary>
		/// CEと合わせ、初期化処理
		/// </summary>
		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try
			{
				dbMsg += ",InputStr=" + InputStr;		//この時点で値は渡らない
				BeforeVals = new ObservableCollection<BeforeVal>();
				ProcessVal = 0.0;
				isDecimal = false;
				BeforeOperation = "";
				//計算結果
				CalcResult.FontSize = 14;
				CalcResult.Content = "";
				//計算経過
				NowOperations.FontSize = 11;
				NowOperations.Text = "";
				dbMsg += ",計算経過=" + NowOperations.Text;
				IsBegin = true;
				//経過リスト
				CalcProgress.ItemsSource = BeforeVals;
				CalcProgress.Items.Refresh();
				CalcResult.Focus();
//#if DEBUG
//				IsPO = SetOperationPriority(true);
//#endif
				CorpProgress();
				MyLog(TAG, dbMsg);
			}
			catch (Exception er)
			{
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 読込み完了後、エレメント参照やプロセスの始動を行う	TargetGsCell
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ThisLoaded(object sender, RoutedEventArgs e)
		{
			string TAG = "ThisLoaded";
			string dbMsg = "";
			try {
				Initialize();
				//起動時はメモリコンボを非表示
				MemoryComb.Visibility = Visibility.Hidden;
				if (TargetTextBox != null) {
					dbMsg += ",TextBoxから";
					InputStr = TargetTextBox.Text;
				}else if (TargetTextBlock != null) {
					dbMsg += ",TextBlockから";
					InputStr = TargetTextBlock.Text;
				}
				dbMsg += ",InputStr=" + InputStr;
				if (!InputStr.Equals("")) {
					double frastVal;
					if (double.TryParse(InputStr, out frastVal)) {       //-1 == OpraterIndex(inParenStr)
						dbMsg += ">>数値=" + frastVal;
						ProcessVal = frastVal;
						CalcResult.Content = ProcessVal.ToString();
						BeforeVal NowInput = new BeforeVal();
						NowInput.Operater = null;
						NowInput.Value = InputStr;
						BeforeVals.Add(NowInput);
						InputStr = frastVal.ToString();
					} else {
						dbMsg += ">呼び出し元の値無し";
					}
				}
				//			NowOperations.Text = InputStr;
				//計算経過
				InputStr = "";              //渡された初期値を空白化して2項目を待つ
				string NextOperation = "";
				dbMsg += ",OperatKey=" + OperatKey.ToString();
				if (Key.Multiply <= OperatKey) {     
					switch (OperatKey) {
						case Key.Add:					//85
						case Key.OemPlus:				//141
							NextOperation = AddStr;
							break;
						case Key.Subtract:			//87
						case Key.OemMinus:      //143
							isMinus = true;
		//					NextOperation = SubtractStr;
							break;
						case Key.Divide:				//89
							NextOperation = DivideStr;
							break;
						case Key.Multiply:      //84 テンキー
							NextOperation = MultiplyStr;
							break;
					}
					dbMsg += ",=" + NextOperation;
					ProcessedFunc(NextOperation);
					BeforeOperation = NextOperation;
					NowOperations.Text = NextOperation;
				} else if (OperatKey == Key.D8) {
					NextOperation = ParenStr;
					ParenFunc();
				}
				dbMsg += ",NowOperations=" + NowOperations.Text;
				//計算の優先順位は電卓処理から
				dbMsg += ",数式入力=" + IsPO;
				IsPO = SetOperationPriority(IsPO);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// C:クリア：一文字づつ消去
		/// </summary>
		private void ClearFunc()
		{
			string TAG = "ClearFunc";
			string dbMsg = "";
			try {
				bool isReCalk = true;
				string nowOperationsText = NowOperations.Text;
				int recordCount = BeforeVals.Count;
				dbMsg += ",ここまでの入力=" + nowOperationsText + ",配列格納[" + recordCount + "]" + ValsLog(BeforeVals) + "=" + ProcessVal;
				if(!InputStr.Equals("")) {
					dbMsg += "：：数値入力中＝"+ InputStr;
					InputStr = "";
				} else if(0< recordCount) {
					int delRecord = recordCount - 1;
					BeforeVal LastInput = BeforeVals[delRecord];
					dbMsg += ",削除対象[" + delRecord + "]" + LastInput.Operater + LastInput.Value;
					//if(LastInput.Value != null) {
					//	BeforeVals[delRecord].Value = null;
					//}else{
					BeforeVals.RemoveAt(delRecord);
					BeforeOperation = LastInput.Operater;
					//}
				} else {
					dbMsg += "：：削除対象無し：：";
					isReCalk = false;
				}
				if (isReCalk) {
					dbMsg += ",削除結果：：：" + ValsLog(BeforeVals) + "=" + ProcessVal;
					MyLog(TAG, dbMsg);
					ReCalk();
					CalcResult.Content = ProcessVal;
					//計算過程を更新
					CalcProgress.ItemsSource = BeforeVals;
					CalcProgress.Items.Refresh();
				}

				/*
				一文字づつ末尾から消去する場合
								if(0<nowOperationsText.Length) {
									string targetStr = NowOperations.Text.Substring(NowOperations.Text.Length - 1);
									dbMsg += ",削除対象=" + targetStr;
									dbMsg += ",入力状況=" + BeforeOperation + InputStr;
									if (0 < InputStr.Length) {
										dbMsg += "：：確定前：：";
										//入力エリアに文字が有る間（）は一文字づつ消去
										if (InputStr.Contains("E")) {
											dbMsg += ">>値は指数";
											int bp = 16;
											string[] rStrs = InputStr.Split('E');
											InputStr = rStrs[0].Replace(".", "") + "0";
											dbMsg += ",sVer=" + InputStr;
											int pStr = int.Parse(rStrs[1].Substring(1, rStrs[1].Length - 1)) - bp;
											dbMsg += ",残り=" + pStr;
											InputStr += Math.Pow(10, pStr).ToString().Replace("1", "");
										} else {
											dbMsg += ">>値は指数無し";
											InputStr = InputStr.Remove(InputStr.Length - 1);
										}
										//計算経過から削除
										NowOperations.Text = NowOperations.Text.Remove(NowOperations.Text.Length - 1);
										if (BeforeVals.Count<1) {
											dbMsg += "：：確定無し：：";
											ProcessVal = 0;
											CalcResult.Content = ProcessVal;
										}
									} else {
										dbMsg += ",BeforeVals残り=" + BeforeVals.Count + "件";
										if (0 < BeforeVals.Count) {
											BeforeVal LastInput = BeforeVals[BeforeVals.Count - 1];
											//読み出したら消す
											BeforeVals.RemoveAt(BeforeVals.Count - 1);
											BeforeOperation = LastInput.Operater;
											if(BeforeOperation == null) {
												BeforeOperation = "";
											}
											double? LastValue = LastInput.Value;
											dbMsg += ",最終確定入力;;" + BeforeOperation + LastValue;
											if (LastValue == null) {
												InputStr = "";
											} else {
												string LastValueStr = LastValue.ToString();
												double JudgeVal = 0;
												if (double.TryParse(LastValueStr, out JudgeVal)) {
													InputStr = LastValueStr;
												} else {
													dbMsg += ">>数値化不能=" + LastValueStr;
													InputStr = "";
												}
											}

											dbMsg += ">InputStr>" + InputStr;
											ReCalk();
											CalcResult.Content = ProcessVal;
											//計算過程を更新
											CalcProgress.ItemsSource = BeforeVals;
											CalcProgress.Items.Refresh();
											NowOperations.Text += BeforeOperation + InputStr;
										}
									}
									dbMsg += ">残り>" + BeforeVals.Count + "件";
									if (BeforeVals.Count < 1) {
										IsBegin = true;
									}
									dbMsg += ",削除後=" + NowOperations.Text + ",配列格納[" + BeforeVals.Count + "]" + ValsLog(BeforeVals) + "=" + ProcessVal;
								}else{
									dbMsg += "：：削除対象無し：：";
								}
				*/
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// Enter:確定処理
		/// </summary>
		private void EnterFunc()
		{
			string TAG = "EnterFunc";
			string dbMsg = "";
			try {
	//			BeforeOperation = "";			//ここで空白にすると二項しかない時点で演算子が消える
				dbMsg += "最終入力" + InputStr;
				if (InputStr.Equals("")) {
					dbMsg += "処理する入力が無い";
					MyLog(TAG, dbMsg);
					MyCallBack();
				} else if (IsBegin) {
					IsBegin = false;
					ProcessedFunc("");
				} else {
					dbMsg += "," + InputStr;
					ProcessedFunc("");
				}
				for (int i = ParenCount; 0<i ; i--){
					dbMsg += ",優先範囲" + i + "/" + ParenCount;
					ParenthesisFunc();
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
			string dbMsg = "";
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
		/// 演算子キーが押された時点で前の演算を処理して、値の入力を待つ
		/// </summary>
		private void ProcessedFunc(string NextOperation)
		{
			string TAG = "ProcessedFunc";
			string dbMsg = "";
			try {
	//			bool isWithInput=false;			//入力値に続いて入力された
				dbMsg += ",渡された演算子=" + NextOperation;
				BeforeVal NowInput = new BeforeVal();
				dbMsg += ",現在の入力値=" + InputStr;
				//if(InputStr !=null && !InputStr.Equals("")) {
				//	isWithInput = true;
				//}
				NowInput.Operater = NextOperation;
				dbMsg += ",前の演算子=" + BeforeOperation;
				bool isReCalk = false;
				//if (0==BeforeVals.Count && NextOperation.EndsWith(ParenStr)) {
				//	dbMsg += "最初が関数の場合";
				//} else 
				if (!InputStr.Equals("") ) {
					if (isMinus) {
						dbMsg += ">>負数化";
						NowInput.Operater = null;
						InputStr = SubtractStr + InputStr;
						double secVal = 0;
						if (double.TryParse(InputStr, out secVal)) {
							//残りが負数を含む数値なら演算子無しと判定
							NowInput.Value = InputStr;
							BeforeVals.Add(NowInput);
							InputStr = "";
							isMinus = false;
							isReCalk = true;
							//MyLog(TAG, dbMsg);
							////演算子が有れば演算
							//ReCalk();
						} else {
							dbMsg += ">>数値化できず";
						}
					}else{
						string bInputOperater = "";
						string bInputValue = null;
						int bIndex = BeforeVals.Count - 1;
						dbMsg += ",前の格納[" + bIndex + "]";
						if (-1 < bIndex) {
							BeforeVal bInput = BeforeVals[bIndex];
							bInputOperater = bInput.Operater;
							bInputValue = bInput.Value;
							dbMsg += bInputOperater + bInputValue;
						} else {
							dbMsg += "未格納";
						}
						if(bInputOperater == null) {
							bInputOperater = "";
						}
						if (bInputOperater.EndsWith(ParenStr) && bInputValue == null && 1 < bIndex) {
							dbMsg += "値に続く関数、優先範囲の開始";
							BeforeVals[bIndex].Value = InputStr;
							dbMsg += ",>>" + BeforeVals[bIndex].Operater + BeforeVals[bIndex].Value;
							InputStr = "";
							isReCalk = true;
						} else {
							//演算値が有れば配列格納
							NowInput.Operater = BeforeOperation; 
							NowInput.Value = InputStr;
							dbMsg += ",直前入力：格納=" + NowInput.Operater + " : " + NowInput.Value;
							BeforeVals.Add(NowInput);
							InputStr = "";				//0428
							dbMsg += ",演算前=" + ProcessVal;
							if (BeforeOperation.Equals("") || BeforeVals.Count < 1) {
								double pVal;
								string bStr = BeforeVals[BeforeVals.Count - 1].Value;
								if (double.TryParse(bStr, out pVal)) {       //-1 == OpraterIndex(inParenStr)
									//演算子が無ければそのまま格納
									ProcessVal = pVal;
								}
								IsBegin = false;
							} else {
								isReCalk = true;
							}
						}
					}
					if (NextOperation.Equals(ParenthesisStr)) {
						dbMsg += ",値に続く優先終了";
						//BeforeValを作り直さないとBeforeValsの前の格納値を上書きする
						NowInput = new BeforeVal();
						NowInput.Operater = NextOperation;
						NowInput.Value = null;
						dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
						BeforeVals.Add(NowInput);
						isReCalk = true;
					}
				} else if (NextOperation.Equals(ParenthesisStr)) {
					dbMsg += ",値無しの優先終了";
					NowInput.Value = null;
					dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
					BeforeVals.Add(NowInput);
					isReCalk = true;
				} else if (NextOperation.Equals(ParenStr)) {
					dbMsg += ",優先開始";
					NowInput.Value = null;
					dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
					BeforeVals.Add(NowInput);
					InputStr = "";
				} else if (NextOperation.EndsWith(ParenStr)) {
					dbMsg += ",関数の場合";
					if (BeforeOperation.Equals("")) {
						dbMsg += "::前の値無し；関数から始まる式";
						dbMsg += ">>今回の値を格納=" + NowInput.Operater + " : " + NowInput.Value;
						BeforeVals.Add(NowInput);
					} else {
						BeforeVal BeforeInput = new BeforeVal();
						BeforeInput.Operater = BeforeOperation;
						BeforeInput.Value = null;
						dbMsg += ">>前の値を格納=" + BeforeInput.Operater + " : " + BeforeInput.Value;
						BeforeVals.Add(BeforeInput);

			//			NowOperations.Text += BeforeOperation;
						NowInput.Value = null;
						dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
						BeforeVals.Add(NowInput);
					}
				} else {
					dbMsg += ",入力無し：演算子から入力された";
				}
				dbMsg += "入力=" + NowOperations.Text + ">結果>配列格納[" + BeforeVals.Count + "]" + ValsLog(BeforeVals) + "=" + ProcessVal + ";再計算" + isReCalk;
				MyLog(TAG, dbMsg);
				if (isReCalk) {
					ReCalk();
					dbMsg += "＞続き：結果＞" + ProcessVal;
					//計算結果と経過を更新	:SetResult
					ResultStr = ProcessVal.ToString();
					CalcResult.Content = ResultStr;
					OnPropertyChanged("ResultStr");
					InputStr = "";
				}

				ProgressRefresh();
				if (NextOperation.Equals(ParenthesisStr)) {
					BeforeOperation = "";
	//				NowOperations.Text += NextOperation;
				} else if (NextOperation.EndsWith(ParenStr)) {
					BeforeOperation = "";
					NowOperations.Text += NextOperation;
				} else {
					if (0 < BeforeVals.Count) {
						BeforeOperation = NextOperation;
						//Parenthesis以外は配列格納が次回になるので補完して終わる
						NowOperations.Text += NextOperation;
					} else{
						dbMsg += "＞＞四則演算子からの入力開始を無視";
						//if(isWithInput) {
						//	NowOperations.Text += NextOperation;
						//}
					}
				}
				dbMsg += ",BeforeOperation=" + BeforeOperation;
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 演算本体
		/// 計算結果に次の演算を行う
		/// </summary>
		/// <param name="ResultNow"></param>
		/// <param name="beforeVal"></param>
		/// <returns></returns>
		private double ReCalkBody(double rcResultNow,BeforeVal rcbeforeVal ) {
			string TAG = "ReCalkBody";
			string dbMsg = "";
			try {
				dbMsg += "開始=" + rcResultNow;
				if (rcbeforeVal == null) {
					dbMsg += "BeforeValがnull";
				} else { 
					string bOperater = rcbeforeVal.Operater;
					dbMsg += bOperater;
					double bValue = 0.0;
					if (rcbeforeVal.Value == null) {
						dbMsg += "；Valueが0";
					} else {
						if (double.TryParse(rcbeforeVal.Value, out bValue)) {
						}
						dbMsg += bValue;
					}
					if (bOperater.Equals("")) {
						dbMsg += "＜＜開始";
						rcResultNow = bValue;
					} else if (bOperater.Equals(AddStr)) {
						dbMsg += ">加算>";
						rcResultNow += bValue;
					} else if (bOperater.Equals(SubtractStr)) {
						dbMsg += ">減算>";
						rcResultNow -= bValue;
					} else if (bOperater.Equals(MultiplyStr) ||
									bOperater.Equals(ParenStr) ||
									bOperater.Equals(ParenthesisBt)
									) {
						dbMsg += ">積算もしくは優先範囲>";
						rcResultNow *= bValue;
					} else if (bOperater.Equals(DivideStr)) {
						dbMsg += ">除算>";
						if (rcResultNow != 0) {
							rcResultNow /= bValue;
						} else {
							dbMsg += ">0除算回避>";
						}
					}
				}
				dbMsg += "=" + rcResultNow;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return rcResultNow;
		}

		/// <summary>
		/// 関数から計算して最終値になるまでループする
		/// </summary>
		/// <param name="inFunctionStr"></param>
		private void FunctionCalc(string inFunctionStr) {
			string TAG = "FunctionCalc";
			string dbMsg = "";
			try {
				string valStr = "0";
				dbMsg += "," + inFunctionStr;
				if(inFunctionStr.Contains("*)")) {
					inFunctionStr=inFunctionStr.Replace("*)", ")*");
					dbMsg += ">>" + inFunctionStr;
				} else if (inFunctionStr.Contains("**")) {
					inFunctionStr=inFunctionStr.Replace("**", "*");
					dbMsg += ">>" + inFunctionStr;
				} else if (inFunctionStr.EndsWith("*")) {
					inFunctionStr=inFunctionStr.Remove(inFunctionStr.Length-1,1);
					dbMsg += ">>" + inFunctionStr;
				}

				string beforeStr = inFunctionStr;
				string remStr = inFunctionStr;
				while (0< beforeStr.Length ||0 < remStr.Length) {
					dbMsg += "\r\n" + beforeStr.Length + "文字中";
					if (inFunctionStr.Contains("*)")) {
						inFunctionStr = inFunctionStr.Replace("*)", ")*");
						dbMsg += ">>" + inFunctionStr;
					} 
					if (inFunctionStr.Contains("**")) {
						inFunctionStr = inFunctionStr.Replace("**", "*");
						dbMsg += ">>" + inFunctionStr;
					} 
					if (inFunctionStr.EndsWith("*")) {
						inFunctionStr = inFunctionStr.Remove(inFunctionStr.Length - 1, 1);
						dbMsg += ">>" + inFunctionStr;
					}

					int funcStart = -1;
					string funkName = "";
					beforeStr = "";
					foreach (string fName in MyFunctions) {
						funcStart = inFunctionStr.LastIndexOf(fName);
						if(-1< funcStart) {
							funkName = fName;
							beforeStr = inFunctionStr.Substring(0, funcStart);
							break;
						}
					}
					dbMsg += ",計算対象" + funkName;
					int parenStart = inFunctionStr.LastIndexOf(ParenStr);
					//ParenStr無しで-1で先頭から最後までが代入される
					remStr = inFunctionStr.Substring(parenStart+1);
					int parenEnd = remStr.IndexOf(ParenthesisStr);
					dbMsg += "," + parenStart + "～" + parenEnd;
					if (-1< parenEnd) {
						valStr = remStr.Substring(0, parenEnd);
						remStr = remStr.Substring(parenEnd + 1);
					}else{
						valStr = remStr;
						remStr = "";
					}
					dbMsg += "," + beforeStr + "　と　" + valStr + "　と　" + remStr;
					try {
						System.Data.DataTable dt = new System.Data.DataTable();
						var pVal = dt.Compute(valStr, "");
						double secVal = 0;
						if (double.TryParse(pVal.ToString(), out secVal)) {
							double fRes = 0;
							if (funkName.Equals(PowerStr)) {
								fRes = Math.Pow(secVal, 2);
							} else if (funkName.Equals(SqrtStr)) {
								fRes = Math.Sqrt(secVal);
							} else if (funkName.Equals(SinStr)) {
								fRes = Math.Sin(secVal);
							} else if (funkName.Equals(CosStr)) {
								fRes = Math.Cos(secVal);
							} else if (funkName.Equals(TanStr)) {
								fRes = Math.Tan(secVal);
							} else if (funkName.Equals(AsinStr)) {
								fRes = Math.Asin(secVal);
							} else if (funkName.Equals(AcosStr)) {
								fRes = Math.Acos(secVal);
							} else if (funkName.Equals(AtanStr)) {
								fRes = Math.Atan(secVal);
							} else if (funkName.Equals("")) {
								dbMsg += ">>関数無し";
								fRes = secVal;
							}
							valStr = fRes.ToString();
						}
					} catch (Exception er) {
						MyErrorLog(TAG, dbMsg, er);
					}
					inFunctionStr = beforeStr + valStr + remStr;
					dbMsg += "結果::" + inFunctionStr;
				}
				CalcResult.Content = valStr.ToString();
				ProcessVal = double.Parse((string)CalcResult.Content);
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
		private void ReCalk()
		{
			string TAG = "ReCalk";
			string dbMsg = "";
			try {
				dbMsg += ",ここまでの入力=" + NowOperations.Text + ",配列格納[" + BeforeVals.Count + "]" + ValsLog(BeforeVals) + "=" + ProcessVal;
				int iParenCount = 0;
				int ParenthesisCount = 0;
				string PFAOStr = "";
				int deficitParenthesis = 0;
				iParenCount = 0;
				ParenthesisCount = 0;
				PFAOStr = "";
				int valsCount = 0;                              //経過行数
				int valsEnd = BeforeVals.Count;           //行数
				NowOperations.Text = "";        //+= BeforeVals[0].Value.ToString();
				//中置記法を数えて,経過表示を更新する
				string iOperater = "_";         //""だと数値のみで演算子無しと同じになる
				string iValStr = "";
				foreach (BeforeVal iVal in BeforeVals) {
					valsCount++;
					dbMsg += "\r\nSouce" + valsCount + "/" + valsEnd + "行目";
					iOperater = iVal.Operater;
					if(iOperater==null) {
						iOperater = "";
					}
					iValStr = iVal.Value;
					if(iValStr==null) {
						iValStr = "";
					}else{
						foreach (string  iConst in MyConstants) {
							if (iValStr.Equals(PiStr)) {
								iValStr = Math.PI.ToString();
							}
						}
					}
					dbMsg += ":" + iOperater + iValStr;
					if (!iOperater.Equals("")) {
						NowOperations.Text += iOperater;
						if (iOperater.EndsWith(ParenStr)) {
							dbMsg += ">>Paren側";
							iParenCount++;
							if (1 < valsCount) {
								if (BeforeVals[valsCount - 2].Value != null) {
									dbMsg += ">>数値に連結";
									PFAOStr += "*" + iOperater;
								} else if(BeforeVals[valsCount - 2].Operater.Equals(ParenthesisStr)) {
									dbMsg += ">>Parenthesisに続く";
									PFAOStr += "*" + iOperater;
								} else {
									PFAOStr += iOperater;
								}
							} else {
								dbMsg += ">>配列開始";
								PFAOStr += iOperater;
							}
						} else if(iOperater.Equals(ParenthesisStr)){
							dbMsg += ">>Parenthesis側";
							ParenthesisCount++;
							if(iValStr == null && !iValStr.Equals("")) {
								PFAOStr += iOperater;
							}else{
								PFAOStr += ")*";
							}
						} else {
							PFAOStr += iOperater;
						}
					}
					NowOperations.Text += iValStr;
					PFAOStr += iValStr;
				}
				dbMsg += "\r\n優先範囲開始=" + iParenCount + "件:終了 = " + ParenthesisCount + "件";
				deficitParenthesis = iParenCount - ParenthesisCount;
				dbMsg += "：)不足＝"+ deficitParenthesis;
				dbMsg += "入力状況" + PFAOStr;
				if(PFAOStr.EndsWith(iOperater) && !PFAOStr.Equals(iValStr)) {
					int eLength = PFAOStr.Length - iOperater.Length;
					PFAOStr=PFAOStr.Remove(eLength, iOperater.Length);
					dbMsg += ">演算子で終わった>" + PFAOStr;
				}
				for (int tCount = 0; tCount < deficitParenthesis; tCount++) {
					PFAOStr += ParenthesisStr;
				}
				dbMsg += ">優先範囲終端補完後>" + PFAOStr;
				bool isFunc = false;
				foreach (string fName in MyFunctions) {
					if(PFAOStr.Contains(fName)) {
						isFunc = true;
						dbMsg += ">>関数を含む:";
					}
				}
				if (IsPO) {
					dbMsg += ">>四則演算処理:";
					if (PFAOStr.Equals("")) {
						CalcResult.Content = InputStr.ToString();
					}else if(isFunc) {
						FunctionCalc(PFAOStr);
					} else {
						try {
							//式を計算する .NET5?
							System.Data.DataTable dt = new System.Data.DataTable();
							var pVal =dt.Compute(PFAOStr, "");
							CalcResult.Content = pVal.ToString();
							ProcessVal = double.Parse((string)CalcResult.Content);
						} catch (Exception er) {
							String msgStr = "計算できない入力になっています。\r\n";
							msgStr += "\r\n"+ PFAOStr;
							msgStr += "\r\n修正をお願いします";
							string titolStr = "電卓：数式入力";
							MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
							MyErrorLog(TAG, dbMsg, er);
						}
					}
				} else {
					dbMsg += ">>電卓処理";
					if (0< iParenCount) {
						dbMsg += ">>優先範囲有り";
						MyLog(TAG, dbMsg);
						recursionCount = 0;
						StrInParenCalc(PFAOStr);
					}else{
						dbMsg += ">>優先範囲無し";
						recursionCount2 = 0;
						string rStr = CalculatorCalc(PFAOStr);
						dbMsg += ">rStr=" + rStr;
						double JudgeVal = 0;
						if (double.TryParse(rStr, out JudgeVal)) {
						}else{
							dbMsg += ">>数値にならず";
						}
						ProcessVal = JudgeVal;
						CalcResult.Content = ProcessVal.ToString();
						MyLog(TAG, dbMsg);
					}
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 演算子の出現位置
		/// </summary>
		/// <param name="pStr">演算子を含む文字列</param>
		/// <param name="inSubString">-を演算子として判定する</param>
		/// <returns></returns>
		private int OpraterIndex(string pStr, bool inSubString=false)  {
			string TAG = "OpraterIndex";
			string dbMsg = "";
			int retInt = -1;
			try {
				dbMsg += "pStr=" + pStr;
				int AddPoint = pStr.IndexOf(AddStr);
				if(-1< AddPoint) {
					dbMsg += "、AddPoint=" + AddPoint;
					retInt = AddPoint;
				}
				if (inSubString) {
					dbMsg += "、-を演算子に含める";
					// -  は演算子ではなく値の負数化
					int SubtractPoint = pStr.IndexOf(SubtractStr);
					if (0 < SubtractPoint) {
						//if (0== SubtractPoint) {
						//	dbMsg += ">先頭の負数を拾った：再帰";
						//	retInt=OpraterIndex(pStr.Remove(0,1), true);
						//	dbMsg += ">"+ retInt;
						//}
						dbMsg += "、SubtractPoint=" + SubtractPoint;
						if (retInt > SubtractPoint || retInt == -1) {
							retInt = SubtractPoint;
						}
					} else if (0 == SubtractPoint) {
						dbMsg += ">先頭の負数を拾った";
					}
				}
				int DividePoint = pStr.IndexOf(DivideStr);
				if (-1 < DividePoint) {
					dbMsg += "、DivideStrPoint=" + DividePoint;
					if (retInt > DividePoint || retInt==-1) {
						retInt = DividePoint;
					}
				}
				int MultiplyPoint = pStr.IndexOf(MultiplyStr);
				if (-1 < MultiplyPoint) {
					dbMsg += "、MultiplyPoint=" + MultiplyPoint;
					if (retInt > MultiplyPoint || retInt == -1) {
						retInt = MultiplyPoint;
					}
				}
				dbMsg += "、retInt=" + retInt;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retInt;
		}

		/// <summary>
		/// 文字列で渡された数式から優先計算範囲が無くなるまで処理
		/// </summary>
		/// <param name="pStr"></param>
		private void StrInParenCalc(string pStr) {
			string TAG = "StrInParenCalc";
			string dbMsg = "";
			try {
				string inParenStr = pStr;           // pStr.Substring(startPoint, endPoint);
				recursionCount++;
				dbMsg += "[" + recursionCount+"回目="+ inParenStr;
				dbMsg += ",ここまでの入力=" + NowOperations.Text + ",配列格納=" + ValsLog(BeforeVals) + "=" + ProcessVal;
				double finishVal = 0;
				int startPoint = inParenStr.LastIndexOf(ParenStr);		//最後の優先範囲開始
				dbMsg += ",優先範囲の位置" + startPoint;
				if (-1 < startPoint) {
					int endPoint = inParenStr.IndexOf(ParenthesisStr);  //最初の優先範囲終了：反転する可能性あり
					int calcLength = endPoint - startPoint;
					dbMsg += "～" + +endPoint + "(" + calcLength + "文字)まで";
					//優先範囲と前後に分ける
					string beforeStr = inParenStr.Substring(0,startPoint);
					string calcStr = inParenStr.Substring(startPoint+1);
					calcLength = calcStr.IndexOf(ParenthesisStr);
					string remStr = "";                 //残りを記録
					if (-1 < calcLength) {
						dbMsg += ",範囲修正＝" + startPoint + "から" + calcLength + "文字";
						remStr = calcStr.Substring( calcLength+1);
						calcStr = inParenStr.Substring(startPoint+1, calcLength);
					}
					dbMsg += ";" + beforeStr + " と " + calcStr + " と " + remStr;
					MyLog(TAG, dbMsg);
					dbMsg += "\r\n範囲内計算結果：CalculatorCalc(" + calcStr;
					recursionCount2 = 0;
					calcStr = CalculatorCalc(calcStr);
					dbMsg += ")=" + calcStr;
					double JudgeVal = 0;
					if (double.TryParse(calcStr, out JudgeVal)) {
						dbMsg += ">一値になった";
						if (remStr.StartsWith(ParenthesisStr)) {
							dbMsg += ">優先範囲終了削除";
							remStr = remStr.Remove(0, 1);
							if (beforeStr.EndsWith(ParenStr)) {
								dbMsg += ">優先範囲開始削除";
								beforeStr = beforeStr.Remove(beforeStr.Length - 1);
							}
						}
					}
					dbMsg += ">>" + beforeStr + " と " + calcStr + " と " + remStr;
					inParenStr = beforeStr + calcStr + remStr;
					dbMsg += "、範囲内計算後=" + inParenStr;
					if (-1 < inParenStr.IndexOf(ParenStr)) {                         //1< pCount
						dbMsg += ">優先範囲残り>再帰";
						MyLog(TAG, dbMsg);
						StrInParenCalc(inParenStr);
						//再帰後の結果ならないので強制的に止める
						return;
					}
				}
				//混入防止
				dbMsg += "、優先範囲除去=" + inParenStr;
				inParenStr = CalculatorCalc(inParenStr); 
				dbMsg += "、終了判定前=" + inParenStr;
				if (double.TryParse(inParenStr, out finishVal)) {       //-1 == OpraterIndex(inParenStr)
					dbMsg += ">>最終値="+ finishVal;
					ProcessVal = finishVal;
					CalcResult.Content = ProcessVal.ToString();
				}else{
					dbMsg += ">非数値>再帰";
					MyLog(TAG, dbMsg);
					StrInParenCalc(inParenStr);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 演算子が無くなるまで先頭から計算して結果を文字列で返す
		/// </summary>
		/// <param name="pStr"></param>
		/// <returns></returns>
		private string CalculatorCalc(string pStr) {
			string TAG = "CalculatorCalc";
			string dbMsg = "";
			string inOperateStr = pStr;  
			try {
				recursionCount2++;
				dbMsg += "[" + recursionCount2 + "回目=" + inOperateStr;
				string calcStr = "";
				string remStr = "";
				dbMsg += ",開始=" + inOperateStr;
				dbMsg += ",ここまでの入力=" + NowOperations.Text + "[" + BeforeVals.Count + "件目]配列格納=" + ValsLog(BeforeVals) + "=" + ProcessVal + "\r\n";
				int endPoint = OpraterIndex(inOperateStr,true);
				dbMsg += ",演算子の位置" + endPoint + "まで" ;
				if (0 < endPoint) { 
					//演算子が無くなるまで先頭から計算
					while (0 < OpraterIndex(inOperateStr,true) ) { 
						endPoint = OpraterIndex(inOperateStr,true);
						dbMsg += "\r\n演算子の位置:" + endPoint;
						if (-1 < endPoint) {
							calcStr = inOperateStr.Substring(0, endPoint);
							dbMsg += "；前値=" + calcStr;
							remStr = inOperateStr.Substring(endPoint);
							dbMsg += ",以降:" + remStr;
							//0418:ここで　-2*でループ
							if (remStr.Equals(MultiplyStr)) {
								inOperateStr = calcStr;
								break;
							}
							string oprand = inOperateStr.Substring(endPoint, 1);
							dbMsg += ",演算子:" + oprand;
							int nextPoint = OpraterIndex(remStr, true);
							string secValStr = remStr;
							dbMsg += "3項目以降" ;
							if (0 < nextPoint) {
								dbMsg += "[" + nextPoint + "]から";
								secValStr = remStr.Substring(0, nextPoint);
								remStr = remStr.Substring(nextPoint);
								dbMsg += "::"+ remStr;
							}else{
								dbMsg += "無し";
								remStr = "";
							}
							dbMsg += "::2項目＝" + secValStr;
							if(secValStr.StartsWith(SubtractStr)) {
								dbMsg += "＞演算子-を含む";
								calcStr += secValStr;
							}else{
								double secVal = 0;
								if (double.TryParse(secValStr, out secVal)) {
									//	+-は正負符号扱で演算子が消える
									dbMsg += "＞数値のみ";
									calcStr += oprand + secVal.ToString();
								} else {
									dbMsg += "＞演算子を含む";
									calcStr += secValStr;
								}
							}
							dbMsg += ">>" + calcStr;
							try {
								dbMsg += ",Compute=" + calcStr;
								System.Data.DataTable dt = new System.Data.DataTable();
								var pVal = dt.Compute(calcStr, "");
								inOperateStr = pVal.ToString();
								dbMsg += "=" + inOperateStr;
							} catch (Exception er) {
								MyErrorLog(TAG, dbMsg, er);
							}
							dbMsg += ",残り=" + remStr;
							inOperateStr += remStr;
						} else {
							dbMsg += "::演算子は無くなった";
						}
					}
					dbMsg += ">while後>" + inOperateStr;
				} else {
					dbMsg += "、演算子無し";
				}
				dbMsg += ",結果=" + inOperateStr;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return inOperateStr;
		}

		/// <summary>
		/// 計算経過の更新
		/// </summary>
		public void ProgressRefresh()
		{
			string TAG = "ProgressRefresh";
			string dbMsg = "";
			try {
				OnPropertyChanged("BeforeVals");
				//DataGridの場合
				CalcProgress.ItemsSource = BeforeVals;
				CalcProgress.Items.Refresh();
				int lastRow = CalcProgress.Items.Count - 1;             //書込み結果で取得＞だめならソースで＞
				dbMsg += "、最終=" + lastRow;
				if (-1 < lastRow) {
					CalcProgress.ScrollIntoView(CalcProgress.Items.GetItemAt(lastRow));
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 経過編集
		/// </summary>
		/// <param name="selectedIndex">変更データのインデックス</param>
		/// <param name="feladame">変更先</param>
		/// <param name="value">内容</param>
		private void ProgressEdit(int selectedIndex, string fieldName, string eValue)
		{
			string TAG = "ProgressEdit";
			string dbMsg = "";
			try {
				dbMsg += "元[" + selectedIndex + "]";
				dbMsg += BeforeVals[selectedIndex].Operater + "=" + BeforeVals[selectedIndex].Value;
				dbMsg += ">変更＞" + fieldName + " : " + eValue;
				if (fieldName.Equals("Operater")) {
					BeforeVals[selectedIndex].Operater = eValue;
				} else if (fieldName.Equals("Value")) {
					BeforeVals[selectedIndex].Value = eValue;
				}
				dbMsg += ">>" + BeforeVals[selectedIndex].Operater + "=" + BeforeVals[selectedIndex].Value;
				 ReCalk();
//				CalcResult.Content = ProcessVal.ToString();
				IsPrgresEdit = false;
				dbMsg += ";既存値変更" + IsPrgresEdit;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// このアプリ内で使える演算子と関数ならtrue
		/// </summary>
		/// <param name="operaterStr"></param>
		private bool IsMyOperater(string operaterStr) {
			string TAG = "IsMyOperater";
			string dbMsg = "";
			bool retBool = false;
			try {
				bool isFunc = false;
				dbMsg += ",検査対象=" + operaterStr;
				foreach (string fName in MyFunctions) {
					if (operaterStr.Contains(fName)) {
						dbMsg += ">>関数:" + fName + "を含む:";
						isFunc = true;
						operaterStr = operaterStr.Replace(fName, "");
					}
				}
				string repStr = "";
				if (!isFunc) {
					if (operaterStr.Contains(ParenStr)) {
						dbMsg += ">>" + ParenStr;
						repStr = operaterStr.Replace(ParenStr, "");
						if (0 == repStr.Length) {
							dbMsg += "のみ含む:";
						} else {
							dbMsg += "も含む:";
							operaterStr = repStr;
						}
					}
				}
				repStr = "";
				if (operaterStr.Contains(ParenthesisStr)) {
					dbMsg += ">>" + ParenthesisStr;
					repStr = operaterStr.Replace(ParenthesisStr, "");
					if (0 == repStr.Length) {
						dbMsg += "のみ含む:"; ;
					} else {
						dbMsg += "も含む:";
						operaterStr = repStr;
					}
				}

				dbMsg += ",残り=" + operaterStr;
				retBool = false;
				foreach (string oName in MyOperaters) {
					if (operaterStr.Equals(oName)) {
						dbMsg += ">>演算子:" + oName;
						retBool = true;
					}
				}
				if (!retBool) {
					if (isFunc) {
						dbMsg += "関数のみ含む:"; ;
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
		/// 定数を含め数値として扱えればtrue
		/// </summary>
		/// <param name="valueStr"></param>
		/// <returns></returns>
		private bool IsMyValue(string valueStr) {
			string TAG = "IsMyValue";
			string dbMsg = "";
			bool retBool = false;
			try {
				dbMsg += ",検査対象=" + valueStr;
				foreach (string vName in MyFunctions) {
					if (valueStr.Contains(vName)) {
						dbMsg += ">>定数:" + vName + "を含む:";
						retBool = true;
					}
				}
				if (!retBool) {
					double number;
					if (double.TryParse(valueStr, out number)) {
						dbMsg += ",入力の変換結果=" + number;
						dbMsg += "数値のみ:";
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
		/// DataGridをクリック：直接編集開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcProgress_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			string TAG = "CalcProgress_SelectedCellsChanged";
			string dbMsg = "";
			try {
				dbMsg += "既存値変更開始状態" + IsPrgresEdit;
				DataGrid DG = CalcProgress;
				int selectedIndex = DG.SelectedIndex;
				dbMsg += "[" + selectedIndex + "]";
				if(DG.SelectedItem == null) {
					dbMsg += "SelectedItem=null" ;
				} else {
					BeforeVal selectedItem = (BeforeVal)DG.SelectedItem;
					dbMsg += "=" + selectedItem.Operater + " : " + selectedItem.Value;
					IsPrgresEdit = true;
					dbMsg += "＞＞既存値変更開始" + IsPrgresEdit;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 経過編集後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcProgress_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
		{
			string TAG = "CalcProgress_CellEditEnding";
			string dbMsg = "";
			try {
				string titolStr = "確定値編集";
				DataGrid DG = sender as DataGrid;
				int selectedIndex = DG.SelectedIndex;
				dbMsg += "[" + selectedIndex + "]";
				BeforeVal selectedItem = (BeforeVal)DG.SelectedItem;
				dbMsg += "=" + selectedItem.Operater + " : " + selectedItem.Value;
				TextBox textEdit = (TextBox)e.EditingElement;
				string eValue = textEdit.Text;
				dbMsg += " :TextBox= " + eValue;
				string fieldName = (string)e.Column.Header;
				dbMsg += ",fieldName=" + fieldName;
				if (fieldName == null || fieldName.Equals("none")) {
					if(eValue == selectedItem.Operater) {
						fieldName= "Operater";
					} else if (eValue == selectedItem.Value.ToString()) {
						fieldName = "Value";
					}
					dbMsg += ">>" + fieldName;
				}

				if (fieldName.Equals("Operater")) {
					if (0== selectedIndex) {
						dbMsg += "先頭行の演算子";
						ProgressEdit(selectedIndex, fieldName, null);
					} else if (IsMyOperater(eValue)) {
						dbMsg += ",問題無し";
						ProgressEdit(selectedIndex, fieldName, eValue);
					} else {
						String msgStr = "演算子以外が入力されています\r\n";
						msgStr += eValue;
						msgStr += "\r\n修正をお願いします";
						MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
						IsPrgresEdit = false;
						textEdit.Text = BeforeVals[selectedIndex].Operater.ToString();
						NowOperations.Focus();
					return;
					}
				} else if (fieldName.Equals("Value")) {
						if (IsMyValue(eValue)) {
							dbMsg += ",問題無し"; 
							ProgressEdit(selectedIndex, fieldName, eValue);
						} else {
							String msgStr = "数値以外が入力されています\r\n";
							msgStr += eValue;
							msgStr += "\r\n修正をお願いします";
							MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
							IsPrgresEdit = false;
							textEdit.Text=BeforeVals[selectedIndex].Value.ToString();
							return;
						}
					}
					
				ReCalk();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 指定された入力枠に値を記入する
		/// Nullなら空白文字を記入する
		/// </summary>
		public void MyCallBack()
		{
			string TAG = "MyCallBack";
			string dbMsg = "";
			try
			{
				this.ResultStr = (string)CalcResult.Content.ToString();
				dbMsg += ",戻り値=" + ResultStr;
				if (this.ResultStr ==null || this.ResultStr.Equals("")){
					this.ResultStr = this.InputStr;
					dbMsg += ">>" + this.ResultStr;
				}
				if (TargetTextBox != null) {
					dbMsg += ",TextBoxへ";
					TargetTextBox.Text = this.ResultStr;
				} else if (TargetTextBlock != null) {
					dbMsg += ",TextBlockへ";
					TargetTextBlock.Text = this.ResultStr;
				//}else if (TargetCell != null){
				//	dbMsg += ",XamDataGridのCellへ";
				//	//IntのCellなら四捨五入した整数が入る
				//	TargetCell.Value =double.Parse( rText);
				//}else if (TargetGsCell != null){
				//	dbMsg += ",GcSpreadGridのCell ";
				//	dbMsg += TargetGsCell.Position.Row + "レコード" + TargetGsCell.Position.ColumnName + "へ";
				//	TargetGsCell.Value =double.Parse(ResultStr);
				//	//TargetGsCell.Text = rText;では戻らない
				}
				if(CalcWindow != null)
				{
					CalcWindow.Close();
				}
				MyLog(TAG, dbMsg);
			}
			catch (Exception er)
			{
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		///累乗 ^n
		/// </summary>
		private void PowerFunc(object sender, RoutedEventArgs e) {
			string TAG = "PowerFunc";
			string dbMsg = "累乗";
			try {
				OperaterInput(PowerStr);          //Math.Pow
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
			
		/// <summary>
		/// 平方根 ^1/n
		/// </summary>
		private void SqrtFunc(object sender, RoutedEventArgs e) {
			string TAG = "SqrtFunc";
			string dbMsg = "平方根";
			try {
				OperaterInput(SqrtStr);             //Math.Sqrt(
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void SinFunc(object sender, RoutedEventArgs e) {
			string TAG = "SinFunc";
			string dbMsg = "Sin";
			try {
				OperaterInput(SinStr);             //Math.Sin(
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void CosFunc(object sender, RoutedEventArgs e) {
			string TAG = "CosFunc";
			string dbMsg = "Cos";
			try {
				OperaterInput(CosStr);             //Math.Cos(
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void TanFunc(object sender, RoutedEventArgs e) {
			string TAG = "TanFunc";
			string dbMsg = "Tan";
			try {
				OperaterInput(TanStr);             //Math.Tan(
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void AsinrFunc(object sender, RoutedEventArgs e) {
			string TAG = "AsinrFunc";
			string dbMsg = "Asin";
			try {
				OperaterInput(AsinStr);             //Math.Asin(
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void AcosFunc(object sender, RoutedEventArgs e) {
			string TAG = "AsinrFunc";
			string dbMsg = "Acos";
			try {
				OperaterInput(AsinStr);             //Math.Acos(
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void AtanFunc(object sender, RoutedEventArgs e) {
			string TAG = "AsinrFunc";
			string dbMsg = "Atan";
			try {
				OperaterInput(AtanStr);             //Math.Atan(
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 優先範囲開始の設定
		/// </summary>
		private void ParenFunc() {
			string TAG = "ParenFunc";
			string dbMsg = "";
			try {
				OperaterInput(ParenStr);
				ParenCount++;
				dbMsg += ",優先範囲開始=" + ParenCount + "階層";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		/// <summary>
		/// 優先範囲開始　(
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ParenBt_Click(object sender, RoutedEventArgs e) {
			ParenFunc();
		}

		/// <summary>
		/// 優先範囲終了の設定
		/// </summary>
		private void ParenthesisFunc() {
			string TAG = "ParenthesisFunc";
			string dbMsg = "";
			try {
				//計算経過に追記;
	//			NowOperations.Text += ParenthesisStr;
				ProcessedFunc(ParenthesisStr);

				/*
								//		ProcessedFunc(NextOperation); を使わず、ここで独自処理
								BeforeVal NowInput = new BeforeVal();
								NowInput.Operater = BeforeOperation;					//20210330: CalcOperation.Content.ToString();
								NowInput.Value = Double.Parse(InputStr);
								InputStr = "";
								dbMsg += ",一つ前の入力を格納格納=" + NowInput.Operater + " : " + NowInput.Value;
								BeforeVals.Add(NowInput);

								//NowInput = new BeforeVal();
								//NowInput.Operater = ParenthesisStr;
								//NowInput.Value = null;
								//dbMsg += ",優先範囲終端記号を格納=" + NowInput.Operater + " : " + NowInput.Value;
								//BeforeVals.Add(NowInput);
								//InputStr = "";
								//dbMsg += ",NowOperations=" + NowOperations.Text;
								BeforeOperation = ParenthesisStr;

							*/
				ParenCount--;
				dbMsg += ",優先範囲開始=" + ParenCount + "階層";
				//ReCalk();
				//CalcResult.Content = ProcessVal.ToString();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		//最後の演算子が反映される

		/// <summary>
		/// 優先範囲終了　)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ParenthesisBt_Click(object sender, RoutedEventArgs e) {
			ParenthesisFunc();
		}

		private void OperaterInput(string operaterStr) {
			ProcessedFunc(operaterStr);
		}

		/// <summary>
		/// 除算
		/// </summary>
		private void DivideFunc()
		{
			string TAG = "DivideFunc";
			string dbMsg = "";
			try {
				dbMsg += ",現在=" + InputStr;
				dbMsg += ",ここまでの入力=" + NowOperations.Text+",配列格納=" + ValsLog(BeforeVals) +"="	+ProcessVal;
				if (BeforeVals.Count < 1 ) {
					dbMsg += ",最初の値が無い";
					if (InputStr.Equals("")) {
						MessageBox.Show("0は除算できません。割られる値から入力して下さい。");
					}else{
						dbMsg += ">>最初の値を登録";
						MyLog(TAG, dbMsg);
						OperaterInput(DivideStr);
					}
				} else {
					dbMsg += ">>通常登録";
					MyLog(TAG, dbMsg);
					OperaterInput(DivideStr);
				}
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 加算
		/// </summary>
		private void PlusFunc()
		{
			OperaterInput(AddStr);
		}

		/// <summary>
		/// 加算
		/// </summary>
		private void PlusBt_Click(object sender, RoutedEventArgs e)
		{
			if(BeforeOperation != null) {
				if (BeforeOperation.Equals(AddStr) && InputStr.Equals("")) {
					MyLog("PlusBt_Click", AddStr + "重複");
					return;
				}
			}
			OperaterInput(AddStr);
		}

		/// <summary>
		/// 減算
		/// </summary>
		private void MinusFunc() {
			string TAG = "MinusFunc";
			string dbMsg = "";
			try {
				dbMsg += ",ここまでの入力=" + NowOperations.Text + "[" + BeforeVals.Count + "件目]配列格納=" + ValsLog(BeforeVals) + "=" + ProcessVal + ":前の演算子" + BeforeOperation + "\r\n";
				if (!BeforeOperation.Equals("")  && !BeforeOperation.Equals(ParenStr)) {
				//0421;( が余計に追加されていた
					dbMsg += "別の演算子が入っている";
					BeforeVal bInput = new BeforeVal();
					bInput.Operater = BeforeOperation;
					bInput.Value = null;
					dbMsg += ",前の値を格納" + bInput.Operater + bInput.Value;
					BeforeVals.Add(bInput);
					dbMsg += "[" + BeforeVals.Count + "件目]";
				}
				OperaterInput(SubtractStr);
				isMinus = true;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 減算
		/// </summary>
		private void MinusBt_Click(object sender, RoutedEventArgs e)
		{
			if (BeforeOperation != null) {
				if (BeforeOperation.Equals(SubtractStr) && InputStr.Equals("")) {
					MyLog("MinusBt_Click", SubtractStr + "重複");
					return;
				}
			}
			MinusFunc();
		}
		/// <summary>
		/// 積算
		/// </summary>
		private void AsteriskBt_Click(object sender, RoutedEventArgs e)
		{
			if (BeforeOperation != null) {
				if (BeforeOperation.Equals(MultiplyStr) && InputStr.Equals("")) {
					MyLog("AsteriskBt_Click", MultiplyStr + "重複");
					return;
				}
			}
			OperaterInput(MultiplyStr);
		}
		private void SlashBt_Click(object sender, RoutedEventArgs e)
		{
			if (BeforeOperation != null) {
				if (BeforeOperation.Equals(DivideStr) && InputStr.Equals("")) {
					MyLog("SlashBt_Click", DivideStr + "重複");
					return;
				}
			}
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
			InputStr = "";
			Initialize();
		}

		/// <summary>
		/// 数字の逐次入力
		/// </summary>
		/// <param name="inputStr"></param>
		private void NumInput(string inputStr) {
			InputStr += inputStr;
			NowOperations.Text += inputStr;
		}
		private void PIFunc(object sender, RoutedEventArgs e) {
			string TAG = "PIFunc";
			string dbMsg = "π";
			try {
				NumInput(PiStr);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 小数点
		/// </summary>
		private void PeriodBt_Click(object sender, RoutedEventArgs e)
		{
			if (InputStr.Contains(".")) {
				MyLog("PeriodBt_Click", "小数点重複");
				return;
			}
			isDecimal = true;
			NumInput(".");
		}
		private void ZeroBt_Click(object sender, RoutedEventArgs e)
		{
			NumInput("0");
		}
		private void OneBt_Click(object sender, RoutedEventArgs e){
			NumInput("1");
		}
		private void TwoBt_Click(object sender, RoutedEventArgs e){
			NumInput("2");
		}
		private void ThreeBt_Click(object sender, RoutedEventArgs e){
			NumInput("3");
		}
		private void FourBt_Click(object sender, RoutedEventArgs e){
			NumInput("4");
		}
		private void FiveBt_Click(object sender, RoutedEventArgs e){
			NumInput("5");
		}
		private void SixBt_Click(object sender, RoutedEventArgs e){
			NumInput("6");
		}
		private void SevenBt_Click(object sender, RoutedEventArgs e){
			NumInput("7");
		}
		private void EightBt_Click(object sender, RoutedEventArgs e){
			NumInput("8");
		}
		private void NineBt_Click(object sender, RoutedEventArgs e)
		{
			NumInput("9");
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
			string dbMsg = "";
			try {
				//押されているModifiersキーを取得
				ModifierKeys keyboardModifiers = Keyboard.Modifiers;
				dbMsg += "複合キー=" + keyboardModifiers;
				//主キーを取得
				Key key = e.Key;
				dbMsg += "key=" + key.ToString();
				if (IsPrgresEdit) {
					dbMsg += ";既存値変更";
				} else {
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
							if (keyboardModifiers == ModifierKeys.Shift) {
								Key2ButtonClickerAsync(ParenBt);
							} else {
								Key2ButtonClickerAsync(EightBt);
							}
							break;
						case Key.NumPad9:
						case Key.D9:
							if (keyboardModifiers == ModifierKeys.Shift) {
								Key2ButtonClickerAsync(ParenthesisBt);
							} else {
								Key2ButtonClickerAsync(NineBt);
							}
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
						case Key.M:
							if (keyboardModifiers == ModifierKeys.Control) {
								Key2ButtonClickerAsync(MemorySaveBt);
							}
							break;
					}
				}
		//		MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// システム キーのダウンイベント
		/// </summary>
		/// <param name="sender">クリックされたキー</param>
		/// <param name="e"></param>
		private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			string TAG = "UserControl_PreviewKeyDown";
			string dbMsg = "";
			try {
				Key key = e.Key;
				dbMsg += "key=" + key.ToString();

				if (IsPrgresEdit) {
					dbMsg += ";既存値変更";
				} else {
					switch (key) {
						case Key.Back:
							Key2ButtonClickerAsync(ClearBt);
							break;
						case Key.Delete:
							Key2ButtonClickerAsync(ClearAllBt);
							break;
					}
				}
	//			MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public Button TargetBt;
		/// <summary>
		/// キーボード押下に相当するボタンのクリック
		/// </summary>
		/// <param name="targetBt"></param>
		private async Task Key2ButtonClickerAsync(Button targetBt)
		{
			string TAG = "Key2ButtonClicker";
			string dbMsg = "";
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
	//			MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void CorpBt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "CorpBt_Click";
			string dbMsg = "";
			try
			{
				if (CalcProgress.IsVisible){
					dbMsg = "非表示";
					CorpProgress();
				} else {
					dbMsg = "表示";
					KeyGrid.Visibility = Visibility.Collapsed;
					CalcProgress.Visibility = Visibility.Visible;
					CorpBt.Content = "△";
				}
				MyLog(TAG, dbMsg);
			}catch (Exception er){
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 経過リストを畳む
		/// </summary>
		private void CorpProgress(){
			CalcProgress.Visibility = Visibility.Collapsed;
			FunctionGrid.Visibility = Visibility.Visible;
			KeyGrid.Visibility = Visibility.Visible;
			CorpBt.Content = "▼";
			EnterBt.Focus();
		}
		//private void DataGridTextColumn_Opened(object sender, RoutedEventArgs e) {
		//	string TAG = "DataGridTextColumn_Opened";
		//	string dbMsg = "";
		//	try {
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}

		/// <summary>
		/// 経過に記録されたアイテムを分割する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProgressItemSepareat(object sender, RoutedEventArgs e) {
			string TAG = "ProgressItemSepareat";
			string dbMsg = "";
			try {
				//最新状態を取得:'Refresh' は、AddNew トランザクションまたは EditItem トランザクションの実行中は許可されません。
	//			CalcProgress.Items.Refresh();
				BeforeVal selectedItem = (BeforeVal)CalcProgress.SelectedItem;
				int selectedIndex = CalcProgress.SelectedIndex;
				int insertPosition = selectedIndex+1;
				string selectedValueString = selectedItem.Value.ToString();
				dbMsg += selectedValueString;
				int srtLen = selectedValueString.Length;
				int sepPosition = (int)srtLen / 2;
				dbMsg += ";" + srtLen+ "文字中" + sepPosition + "から";
				string insertValStr = selectedValueString.Substring(sepPosition, (srtLen - sepPosition));
				dbMsg += "=" + insertValStr;
				BeforeVal insertRecord = new BeforeVal();
				insertRecord.Operater = AddStr;
				insertRecord.Value = insertValStr;

				string titolStr = "電卓；入力値の変更";
				String msgStr = "["+ insertPosition + "番目]" + selectedValueString + "を分割します。\r\n";
				msgStr += "\r\nよろしいですか？";
				msgStr += "\r\n(中心で分割して演算子は" + insertRecord.Operater + "で" + insertRecord.Value + "にします)";
				MessageBoxResult dResurt = MessageShowWPF(msgStr, titolStr, MessageBoxButton.OKCancel, MessageBoxImage.Error);
				if (dResurt == MessageBoxResult.OK){
					dbMsg += "分割開始";
					BeforeVals.Insert(insertPosition, insertRecord);
					BeforeVals[selectedIndex].Value = selectedValueString.Substring(0,sepPosition);

					CalcProgress.ItemsSource = BeforeVals;
					CalcProgress.Items.Refresh();
					ReCalk();
				//	CalcResult.Content = ProcessVal;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void ProgressItemDelete(object sender, RoutedEventArgs e) {
			string TAG = "ProgressItemDelete";
			string dbMsg = "";
			try {
				BeforeVal selectedItem = (BeforeVal)CalcProgress.SelectedItem;
				int selectedIndex = CalcProgress.SelectedIndex;
				string selectedOperater = selectedItem.Operater;
				string selectedValue = selectedItem.Value;
				int delPosition = selectedIndex + 1;
				string titolStr = "電卓；入力値の削除";
				String msgStr = "[" + delPosition + "番目]" + selectedOperater+ selectedValue + "を削除します。\r\n";
				msgStr += "\r\nよろしいですか？";
				MessageBoxResult dResurt = MessageShowWPF(msgStr, titolStr, MessageBoxButton.OKCancel, MessageBoxImage.Error);
				if (dResurt == MessageBoxResult.OK) {
					dbMsg += "削除開始";
					BeforeVals.RemoveAt(selectedIndex);
					CalcProgress.ItemsSource = BeforeVals;
					CalcProgress.Items.Refresh();
					ReCalk();
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 四則演算の優先順位で計算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChangeToPO(object sender, RoutedEventArgs e) {
			string TAG = "ChangeToPO";
			string dbMsg = "";
			try {
				IsPO = SetOperationPriority(true);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 電卓処理：現在の結果に次の演算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChangeToCalculator(object sender, RoutedEventArgs e) {
			string TAG = "ChangeToCalculator";
			string dbMsg = "";
			try {
				IsPO = SetOperationPriority(false);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// trueで四則演算の優先順位で計算 に切替
		/// </summary>
		/// <param name="retBool"></param>
		/// <returns></returns>
		public bool SetOperationPriority(bool retBool) {
			string TAG = "SetOperationPriority";
			string dbMsg = "";
			try {
				IsPO = retBool;
				//メニューをすべて非表示
				PCOMenu.Visibility = Visibility.Collapsed;
				PFAOMenu.Visibility = Visibility.Collapsed;
				TBMenuSeparator.Visibility = Visibility.Collapsed;
				TBMenuFunc.Visibility = Visibility.Collapsed;
				//状況に見合うメニューだけを表示
				if (retBool) {
					dbMsg += "数式入力 に切替";
					PCOMenu.Visibility = Visibility.Visible;
					TBMenuSeparator.Visibility = Visibility.Visible;
					TBMenuFunc.Visibility = Visibility.Visible;
				} else {
					dbMsg += "電卓処理 に切替";
					PFAOMenu.Visibility = Visibility.Visible;
				}
				ReCalk();
				dbMsg += "、 retBool＝" + retBool;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return retBool;
		}

		/// <summary>
		/// その時点の計算結果をメモリーコンボボックスに追加
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MemorySaveBt_Click(object sender, RoutedEventArgs e) {
			string TAG = "MemorySaveBt_Click";
			string dbMsg = "";
			try {
				dbMsg += "ProcessVal=" + ProcessVal;
				if (0 !=ProcessVal) {
					bool IsPreexist = false;

					foreach (var pItem in MemoryComb.Items){
						if(pItem.ToString().Equals(ProcessVal.ToString())) {
							IsPreexist = true;
						}
					}
					if(IsPreexist) {
						string titolStr = "電卓：メモリへの追加"; ;
						String msgStr = ProcessVal +"は既にメモリに登録済みです。";
						MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Information);
					} else {
						MemoryComb.Items.Add(ProcessVal.ToString());
						dbMsg += "＞＞" + MemoryComb.Items.Count + "件";
						MemoryComb.Visibility = Visibility.Visible;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// メモリコンボボックスで選択したアイテムを入力枠にコピーする
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MemoryComb_SelectionChanged(object sender, SelectionChangedEventArgs e) {
			string TAG = "MemoryComb_SelectionChanged";
			string dbMsg = "";
			try {
				ComboBox cb = (ComboBox)sender;
				if(cb ==null) {
					dbMsg += "senderを拾えない";
					cb = MemoryComb;       // (ComboBox)sender;
				}
				int selectedIndex = cb.SelectedIndex;
				if (-1 < cb.SelectedIndex) {
					dbMsg += "[" + selectedIndex + "]";
					if (cb.SelectedValue == null) {
						dbMsg += "SelectedValueが無い";
					} else {
						string selectStr = cb.SelectedValue.ToString();
						dbMsg += selectStr;
						/*
							string oprater = NowOperations.Text.Substring(NowOperations.Text.Length - 1);
							dbMsg += "演算子=" + oprater;
							if (OpraterIndex(oprater, true) < 0) {
								string titolStr = "電卓：メモリーから呼出し";
								string msgStr = "演算子を入力して下さい。";
								MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
								return;
							}
							*/
						InputStr = selectStr;		// cb.SelectedItem.ToString();
						dbMsg += "選択値=" + InputStr;
						NowOperations.Text += selectStr;
						dbMsg += "演算子=" + BeforeOperation;
														//if(BeforeOperation != null && !BeforeOperation.Equals("")) {
														//	ProcessedFunc("");
														//}
														//		EnterFunc();
					}
				} else{
					dbMsg += "選択されていない";
				}
				//	選択を外して、再び同じ値でも動作させる
				cb.SelectedIndex = -1;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// メモリーから記録されたアイテムを削除する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MemoryItemDeleat(object sender, RoutedEventArgs e) {
			string TAG = "MemoryItemDeleat";
			string dbMsg = "";
			try {
				ComboBox cb = MemoryComb;		// (ComboBox)sender;
				//先頭は-1？？
				if(cb.SelectedValue != null) {
					string titolStr = "電卓：メモリーから削除"; ;
					String msgStr = "[" + (cb.SelectedIndex + 1) + "]" + cb.SelectedValue + "をメモリから削除します。";
					MessageBoxResult res = MessageShowWPF(msgStr, titolStr, MessageBoxButton.YesNo, MessageBoxImage.Information);
					if (res.Equals(MessageBoxResult.Yes)) {
						MemoryComb.Items.RemoveAt(cb.SelectedIndex);
						dbMsg += "＞削除＞" + MemoryComb.Items.Count + "件";
						if (MemoryComb.Items.Count < 1) {
							MemoryComb.Visibility = Visibility.Hidden;
							dbMsg += "＞＞コンボボックス非表示" ;
						}
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void FunkBt_Loaded(object sender, RoutedEventArgs e) {
			string TAG = "FunkBt_Loaded";
			string dbMsg = "";
			try {
				var btn = (ToggleButton)sender;

				btn.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsOpen") { Source=btn.ContextMenu });
				btn.ContextMenu.PlacementTarget = btn;
				btn.ContextMenu.Placement = PlacementMode.Bottom;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		/// <summary>
		/// マウス右クリック
		/// </summary>
		/// <param name="e"></param>
		protected override void OnMouseRightButtonUp(MouseButtonEventArgs e) {
			string TAG = "OnMouseRightButtonUp";
			string dbMsg = "";
			try {
				//		e.Handled = true;				//上書きさせる
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName) {
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
#if DEBUG
			Console.WriteLine(TAG + "[CS_CalculatorControl]" + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			Console.WriteLine(TAG + "[CS_CalculatorControl] : " + dbMsg + "でエラー発生;" + err);
		}

		public string ValsLog(IEnumerable<BeforeVal> testVals) {
#if DEBUG
			string retStr = "";
			//入力値が侵食されていない事を確認する
			foreach (BeforeVal iVal in testVals) {
				string iOperater = iVal.Operater;
				string iValue = iVal.Value;
				retStr += "" + iOperater + iValue;
			}
#endif
			return retStr;
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
		////////////////////////////////////////////////////
		/// <summary>
		/// 確定した演算子と数値
		/// </summary>
		public class BeforeVal {
			public string Operater { get; set; }
			public string Value { get; set; }
		}
		//20210428 			public double? Value { get; set; }
	}

}