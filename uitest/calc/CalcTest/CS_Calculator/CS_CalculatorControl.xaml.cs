﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Interop;
using System.Text.RegularExpressions;
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
		/// 電卓を表示しているウィンドウ
		/// </summary>
		public Window CalcWindow;

		public string SelectOperater { get; set; }
		public string SelectValue { get; set; }
	
		/// <summary>
		/// 四則演算の優先順位で計算
		/// </summary>
		public bool IsPriorityFourArithmeticOperation = true;


		/// <summary>
		/// 計算結果
		/// </summary>
		public double ProcessVal = 0.0;
		/// <summary>
		/// 入力確定値の配列
		/// </summary>
		public ObservableCollection<BeforeVal> BeforeVals;
	//	public Dictionary<string, string> BeforeValDec { get; set; }
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
		private static string AddStr = "+";
		private static string SubtractStr = "-";
		private static string DivideStr = "/";
		private static string MultiplyStr = "*";
		private static string PowerStr = "^";
		private static string SqrtStr = "√";
		private static string ParenStr = "(";	
		private static string ParenthesisStr = ")";


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
		/// 起動処理
		/// </summary>
		public CS_CalculatorControl()
		{
			//string TAG = "CS_CalculatorControl";
			//string dbMsg = "";
			InitializeComponent();
			CalcProcess.IsReadOnly = true;
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
				CalcOperation.Content = "";
				CalcProcess.Text = "";
				IsBegin = true;
				//経過リスト
				CalcProgress.ItemsSource = BeforeVals;
				CalcProgress.Items.Refresh();
				CalcResult.Focus();

				//計算の優先順位は電卓処理から
				IsPriorityFourArithmeticOperation = SetOperationPriority(false);
#if DEBUG
				IsPriorityFourArithmeticOperation = SetOperationPriority(true);
#endif
				MemoryComb.Visibility = Visibility.Hidden;
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
				if (TargetTextBox != null) {
					dbMsg += ",TextBoxから";
					InputStr = TargetTextBox.Text;
				}else if (TargetTextBlock != null) {
					dbMsg += ",TextBlockから";
					InputStr = TargetTextBlock.Text;
				}
				dbMsg += ",InputStr=" + InputStr;
				CalcProcess.Text = InputStr;
				string NextOperation = "";
				dbMsg += ",OperatKey=" + OperatKey.ToString();
				if (Key.Add <= OperatKey) {
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
				} else if (OperatKey == Key.D8) {
					NextOperation = ParenStr;
					ParenFunc();
				}
				CorpProgress();
				//計算経過
				NowOperations.Text = BeforeVals[0].Value.ToString(); 
				NowOperations.Text += NextOperation;  
				dbMsg += ",NowOperations=" + NowOperations.Text;

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
				InputStr = CalcProcess.Text;
				dbMsg += ",入力状況=" + InputStr;
				if (0 < InputStr.Length) {
					//入力エリアに文字が有る間は一文字づつ消去
					InputStr = InputStr.Substring(0, InputStr.Length - 1);
					CalcProcess.Text = InputStr;
				} else {
					dbMsg += ",BeforeVals残り=" + BeforeVals.Count + "件";
					if (0 < BeforeVals.Count) {
						//最終確定入力を読出し
						BeforeVal LastInput = BeforeVals[BeforeVals.Count - 1];
						string LastOperatier = LastInput.Operater;
						dbMsg += ",演算子=" + LastOperatier;            //Parenなど
						CalcOperation.Content = LastOperatier;
						if (LastInput.Value == null) {
							dbMsg += ">>値はnull";			//Parenなど
						} else { 
							//値を転記
							double LastValue = (double)LastInput.Value;
							dbMsg += "＝" + LastOperatier + " : " + LastValue;
							InputStr = LastValue.ToString();
							if (InputStr.Contains("E")) {
								dbMsg += ">>値は指数";
								int bp = 16;
								string[] rStr = InputStr.Split('E');
								InputStr = rStr[0].Replace(".", "") + "0";
								dbMsg += ",sVer=" + InputStr;
								int pStr = int.Parse(rStr[1].Substring(1, rStr[1].Length - 1)) - bp;
								dbMsg += ",残り=" + pStr;
								InputStr += Math.Pow(10, pStr).ToString().Replace("1", "");
							}
							CalcProcess.Text = InputStr;
						}
						///最後の確定入力を消去
						BeforeVals.RemoveAt(BeforeVals.Count - 1);
						ReCalk();
						CalcResult.Content = ProcessVal;
						BeforeOperation = LastOperatier;
						//計算過程を更新
						CalcProgress.ItemsSource = BeforeVals;
						CalcProgress.Items.Refresh();
						////計算過程から最終確定値と演算子を消去
						////CalcProgress.Content = ProssesStr.Substring(0, (ProssesStr.Length - InputStr.Length - LastOperatier.Length - LineBreakStr.Length));
						////CalcProgressScroll.ScrollToBottom();
					//} else if(0==BeforeVals.Count) {
					//	//最終入力の
					//	BeforeVal LastInput = BeforeVals[0];
					//	if(LastInput == null) {
					//		dbMsg += ",LastInput=null" ;
					//	} else {
					//		string LastInputStr = "";
					//		//演算子を転記
					//		string LastOperatier = LastInput.Operater;
					//		dbMsg += "＝" + LastOperatier ;
					//		if (LastInput.Value == null) {
					//			dbMsg += ",Value=null";
					//		} else {
					//			dbMsg += ",値を読み出し";
					//			double LastValue = (double)LastInput.Value;
					//			dbMsg +=  " : " + LastValue;
					//			LastInputStr = LastValue.ToString();
					//		}
					//		Initialize();
					//		//格納値をクリアした後で最終入力をフィールドに書き戻す
					//		CalcOperation.Content = LastOperatier;
					//		CalcProcess.Text = LastInputStr;
					//	}
					}
				}
				dbMsg += ">残り>" + BeforeVals.Count + "件";
				if (BeforeVals.Count < 1) {
					IsBegin = true;
				}
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
				InputStr = CalcProcess.Text;
				dbMsg += "最終入力" + InputStr;
				if (BeforeOperation.Equals(ParenthesisStr) && !InputStr.Equals("")) {
					dbMsg += "；優先範囲終端直後の数値";
					BeforeVals[BeforeVals.Count - 1].Value = double.Parse(InputStr);
					ProgressRefresh();
					 ReCalk();
				//	ResultStr = ProcessVal.ToString();
					CalcResult.Content = ResultStr; 
					OnPropertyChanged("ResultStr");
				} else if (InputStr.Equals("")) {
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
				BeforeVal NowInput = new BeforeVal();
				NowInput.Operater = NextOperation;
				if (BeforeOperation.Equals(ParenthesisStr) && !InputStr.Equals("")) {
					BeforeVals[BeforeVals.Count - 1].Value= double.Parse(InputStr);
				} else if (!InputStr.Equals("") ) {
					//演算値が有れば配列格納
					NowInput.Operater = CalcOperation.Content.ToString();
					NowInput.Value = Double.Parse(InputStr);
					dbMsg += ",直前入力：格納=" + NowInput.Operater + " : " + NowInput.Value;
					BeforeVals.Add(NowInput);
					dbMsg += ",演算前=" + ProcessVal;
					if (BeforeOperation.Equals("") || BeforeVals.Count < 1) {
						//演算子が無ければそのまま格納
						ProcessVal = (double)BeforeVals[BeforeVals.Count - 1].Value;
						IsBegin = false;
					} else {
						//演算子が有れば演算
						 ReCalk();
					}
					dbMsg += "＞結果＞" + ProcessVal;
					//計算結果と経過を更新	:SetResult
					ResultStr = ProcessVal.ToString();
					CalcResult.Content = ResultStr;     //ProcessVal.ToString();
					OnPropertyChanged("ResultStr");
					InputStr = "";
					CalcProcess.Text = InputStr;
					CalcOperation.Content = NextOperation;
				}else if(NextOperation.EndsWith(ParenStr)) {
					dbMsg += ",優先開始" ;
					NowInput.Value = null;
					dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
					BeforeVals.Add(NowInput);
				} else {
					dbMsg += ",入力無し：演算子から入力された";
					CalcOperation.Content = NextOperation;
				}
				ProgressRefresh();

				BeforeOperation = NextOperation;
				MyLog(TAG, dbMsg);
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
						bValue = (double)rcbeforeVal.Value;
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
		/// パーレン内計算値格納
		/// パーレンの最終値が1ブロックだけなら積算に置き換え
		/// </summary>
		/// <param name="iValCount">優先範囲階層の深さ</param>
		/// <param name="ResultNow">集計値</param>
		/// <param name="bVal">対象の経過行</param>
		/// <param name="isParsonOnly">優先範囲指定のみ：関数の場合はFalse</param>
		/// <returns></returns>
		public BeforeVal RemainPason(int iValCount, double? ResultNow,  bool isParsonOnly) {
			string TAG = "RemainPason";
			string dbMsg = "";
			BeforeVal aVal = new BeforeVal();
			try {
#if DEBUG
				dbMsg += "\r\n処理前＝";
				foreach (BeforeVal iVal in BeforeVals) {
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += "" + iOperater + iValue;
				}
				dbMsg += "\r\n";
#endif
				dbMsg += "集計値＝" + ResultNow;
				dbMsg += "優先範囲階層の深さ＝" + iValCount;
				dbMsg += ",非関数=" + isParsonOnly;
				aVal.Operater = ParenStr;
				if (1 == iValCount && isParsonOnly) {
					dbMsg += ">関数ではない>積算に置き換え";
					aVal.Operater = MultiplyStr;
				}
				aVal.Value = ResultNow;
				dbMsg += aVal.Operater + aVal.Value;
#if DEBUG
				dbMsg += "\r\n処理後＝";
				foreach (BeforeVal iVal in BeforeVals) {
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += "" + iOperater + iValue;
				}
#endif
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return aVal;
		}

		/// <summary>
		/// 中置記法が無くなるまで
		/// </summary>
		/// <param name="ResultNow">演算結果</param>
		/// <param name="ParenVals">経過配列</param>
		/// <param name="ParenCount">優先範囲範囲出現数</param>
		/// <param name="ParenthesisCount">優先範囲終了出現数</param>
		/// <param name="isADPPriority">積商乗算優先</param>
		/// <returns>経過配列</returns>
		private void CalcParen(double parenResult, ObservableCollection<BeforeVal> ParenVals , int ParenCount, int ParenthesisCount, bool isADPPriority) {
			string TAG = "CalcParen";
			string dbMsg = "";
			ObservableCollection<BeforeVal> resurtVals = new ObservableCollection<BeforeVal>();
			try {
				dbMsg += ",演算結果=" + parenResult + "]";
				dbMsg += ",経過配列=" + ParenVals.Count + "件";
				dbMsg += ",優先範囲出現数：開始=" + ParenCount + "回/終了="+ ParenthesisCount+"回";
				ParenCount -= ParenthesisCount;
				dbMsg += ">>" + ParenCount +  "回";
				dbMsg += ",積商乗算優先=" + isADPPriority ;
				int iParenCount = 0;
				int iValCount = 0;								//範囲内の未処理入力値数
				bool isParsonOnly = false;					//優先範囲指定のみ：関数ではない
				BeforeVal bVal = new BeforeVal();		//経過各行
				int valsCount = 0;                              //経過行数
				int valsEnd = ParenVals.Count;           //行数
				foreach (BeforeVal iVal in ParenVals) {
					valsCount++;
					dbMsg += "\r\nSouce" + valsCount + "/" + valsEnd + "行目" ;
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += ":" + iOperater + iValue;
					int valsRest = valsEnd - valsCount;                                   //残り行数
					dbMsg += ":残り" + valsRest;
					dbMsg += ":優先範囲内" + iParenCount + "階層";
					int beforeCount = resurtVals.Count - 1;
					BeforeVal pBeforeVal = new BeforeVal();
					//string beforeOperater = "";
					//double? beforeValue = null;
					if (1< valsCount) {
						pBeforeVal = ParenVals[valsCount - 2];
						//beforeOperater = ParenVals[valsCount-2].Operater;
						//beforeValue = ParenVals[valsCount-2].Value;
						//			if (0 < beforeCount) {
						//beforeOperater = resurtVals[beforeCount].Operater;
						//beforeValue = resurtVals[beforeCount].Value;
						dbMsg += "[前回" + beforeCount + "]=" + pBeforeVal.Operater + pBeforeVal.Value;
					}
					if (iOperater.Equals("") ) {            //|| iOperater==null
						dbMsg += ">経過リスト開始>そのまま格納";
						resurtVals.Add(iVal);
					} else if (iOperater.EndsWith(ParenStr)) {
						if (iOperater.Equals(ParenStr)) {
							isParsonOnly = true;
						}else{
							dbMsg += ";関数開始";
							isParsonOnly = false;
						}
						iParenCount++;
						iValCount = 1;
						dbMsg += "：優先範囲開始[" + iParenCount + "]";
						parenResult = 0.0;          //要るか？
						if (iValue == null || isADPPriority) {
							dbMsg += ">数値無し>そのまま格納";
							resurtVals.Add(iVal);
						} else {
							dbMsg += ">>優先範囲内計算開始";
							parenResult = (double)iValue;
						}
						ParenCount--;
					} else if (iOperater.Equals(ParenthesisStr)) {
						dbMsg += "：優先範囲終了;";
						dbMsg += "：範囲集計値=" + parenResult;
						if (parenResult == 0.0) {
							if(iValue !=null) {
								dbMsg += ">続けて数値がある>" + iValue;
								parenResult = (double)iValue;
							}
						} else {
							parenResult = ReCalkBody(parenResult, iVal);
						}
						dbMsg += ">>" + parenResult;
							//if (0 < iParenCount) {
							//	dbMsg += "：優先範囲残り=" + iParenCount + "階層";
							//}
							//if (1 == iValCount) {
							//	if (isParsonOnly) {
							//		dbMsg += "は関数ではないので積算に置き換え";
							//		//	resurtVals.RemoveAt(bCount);
							//		iParenCount--;
							//	}
							//	//			ParenCount--;
							//}
						if(parenResult !=0.0) {
							BeforeVal aVal = RemainPason(iValCount, parenResult, isParsonOnly);
							dbMsg += ">範囲内集計値>" + aVal.Operater + aVal.Value;
							resurtVals.Add(aVal);
						}
						//if (iValue != null) {
						//		dbMsg += ">続けて数値がある>" + iValue;
						//		aVal.Operater = MultiplyStr;
						//		aVal.Value = (double)iValue;
						//		dbMsg += ">範囲継続値>" + aVal.Operater + aVal.Value + "を追加";
						//		resurtVals.Add(aVal);
						//	}
						//if ( isParsonOnly) {        //1 == iValCount &&
						//} else { 
						//	dbMsg += ">関数なので範囲終端追加";
						//	bVal.Operater = ParenthesisStr;
						//	bVal.Value = null;
						//	resurtVals.Add(bVal);
						//}
						parenResult = 0.0;
						iParenCount--;
				} else {
						iValCount++;
						dbMsg += ",未処理入力値数" + iValCount+"組";
						if (isADPPriority) {
							dbMsg += ">演算子優先順位有り";
							int resEnd = resurtVals.Count - 1;
							BeforeVal resEndVals = resurtVals[resEnd];
							dbMsg += "[前値" + (resEnd + 1) + "件目]=" + resEndVals.Operater+ resEndVals.Value;
							if (isADPPriority && (iOperater.Equals(AddStr) || iOperater.Equals(SubtractStr))) {
								dbMsg += ";和差>";
								//if(resEndVals.Operater.EndsWith(ParenStr)) {
								//	dbMsg += ">>範囲開始を格納して";
								//	resurtVals.Add(resEndVals);
								//}
								dbMsg += "今回の値はそのまま格納";
								resurtVals.Add(iVal);
								parenResult = (double)iValue;
							}else{
								dbMsg += ";和差以外>";
								parenResult = ReCalkBody((double)resEndVals.Value, iVal);
								dbMsg += "を" + parenResult + "に置き換え";
								resurtVals[resEnd].Value = parenResult;
								parenResult = 0.0;
							}
						} else {
							if(0<iParenCount && pBeforeVal.Value != null) {
								dbMsg += ">前値"+ pBeforeVal.Value;
								parenResult = ReCalkBody((double)pBeforeVal.Value, iVal);
							} else {
								dbMsg += "," + parenResult + "に演算";
								parenResult = ReCalkBody(parenResult, iVal);
							}
							iValCount--;
						}
					}
					//ループ終端でも優先範囲が完結しない場合の処理に渡す
					bVal.Operater = iVal.Operater;
					bVal.Value = iVal.Value;
					int eCount = resurtVals.Count - 1;
					dbMsg += "[終端" + (eCount + 1) + "件]=" + resurtVals[eCount].Operater + resurtVals[eCount].Value;
				}
				iParenCount -= ParenthesisCount;
				dbMsg += "\r\n優先範囲処理：残り=" + iParenCount + "回";
				if (0< iParenCount) {
					dbMsg += ">優先範囲未完結＞格納";
					bVal = RemainPason(iValCount, parenResult, isParsonOnly);
					resurtVals.Add(bVal);
					ParenCount--;
				}

				dbMsg += ">中置記法対応後>" + resurtVals.Count + "組=";
#if DEBUG
				foreach (BeforeVal iVal in resurtVals) {
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += "" + iOperater + iValue;
				}
#endif
				dbMsg += "\r\n優先範囲出現数：残り=" + ParenCount + "回";
				MyLog(TAG, dbMsg);
				if ( isADPPriority) {//0 < ParenCount ||
									 //if (isADPPriority) {
					isADPPriority = false;
					//}else{
					//	isADPPriority = true;
					//}
					CalcParen(parenResult, resurtVals, ParenCount, ParenthesisCount, isADPPriority);
				}else{
					ReCalkEnd(resurtVals);
				}
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
			double ResultNow = 0.0;
			try {
				dbMsg += "BeforeVals=" + BeforeVals.Count + "組";
				int iParenCount = 0;
				int ParenthesisCount = 0;
				NowOperations.Text = "";        //+= BeforeVals[0].Value.ToString();
				//中置記法を数えて,経過表示を更新する
				foreach (BeforeVal iVal in BeforeVals) {
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += "\r\n" + iOperater + iValue;
					if (!iOperater.Equals("")) {
						NowOperations.Text += iOperater;
						if (iOperater.EndsWith(ParenStr)) {
							iParenCount++;
						}else if(iOperater.Equals(ParenthesisStr)){
							ParenthesisCount++; 
							}
					}
					NowOperations.Text += iValue;
				}
				dbMsg += "\r\n優先範囲開始=" + iParenCount + "件:終了 = " + ParenthesisCount + "件";
				int deficitParenthesis = iParenCount - ParenthesisCount;
				dbMsg += "：)不足＝"+ deficitParenthesis;
				if (IsPriorityFourArithmeticOperation) {
					dbMsg += ">>四則演算処理:";
					string NOText = NowOperations.Text;
					if (NOText.Equals("")) {
						CalcResult.Content = InputStr.ToString();
					} else {
						dbMsg += "入力状況" + NOText;
						for (int tCount = 0; tCount < deficitParenthesis; tCount++) {
							NOText += ParenthesisStr;
						}
						dbMsg += ">優先範囲終端補完>" + NOText;
						//Regex reg = new Regex(@"[0-9]-?");
						//NOText = reg.Replace(NOText, "*(");
						//dbMsg += ">s>" + NOText;
						//reg = new Regex(")[0-9]");
						//NOText = reg.Replace(NOText, "*(");
						//dbMsg += ">>" + NOText;
						try {
							//式を計算する .NET5?
							System.Data.DataTable dt = new System.Data.DataTable();
							ProcessVal = (double)dt.Compute(NOText, "");

							CalcResult.Content = ProcessVal.ToString();
						} catch (Exception er) {
							//String msgStr = "計算できない入力になっています。\r\n";
							//msgStr += "\r\n修正をお願いします";
							//string titolStr = "電卓：結果表示";
				//			MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
							MyErrorLog(TAG, dbMsg, er);
						}
					}
				} else {
					dbMsg += ">>電卓処理";
					CalcParen(ResultNow, BeforeVals, iParenCount, ParenthesisCount, IsPriorityFourArithmeticOperation);
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private double ReCalkEnd(ObservableCollection<BeforeVal> ParenVals) {
			string TAG = "ReCalkEnd";
			string dbMsg = "";
			double ResultNow = 0.0;
			try {
				dbMsg += ">中置記法対応後>" + ParenVals.Count + "組\r\n";
#if DEBUG
				foreach (BeforeVal iVal in BeforeVals) {
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += "" + iOperater + iValue;
				}
				dbMsg += "=";
				foreach (BeforeVal iVal in ParenVals) {
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += "" + iOperater + iValue;
				}
#endif
				if (0 < ParenVals.Count) {
					dbMsg += "\r\nOperation=" + IsPriorityFourArithmeticOperation;
					if (IsPriorityFourArithmeticOperation) {
						dbMsg += ">>四則演算処理へ";
						ResultNow = ReCalkPFO(ParenVals);
					} else {
						dbMsg += ">>電卓処理";
						foreach (BeforeVal beforeVal in ParenVals) {
							if (beforeVal.Value != null) {
								ResultNow = ReCalkBody(ResultNow, beforeVal);
							}
						}
					}
					ProcessVal = ResultNow;
					CalcResult.Content = ProcessVal.ToString();
				}
				dbMsg += "=" + ResultNow;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return ResultNow;
		}

		/// <summary>
		/// 四則演算の優先順位で計算
		/// </summary>
		/// <returns></returns>
		private double ReCalkPFO(ObservableCollection<BeforeVal> ParenVals) {
			string TAG = "ReCalkPFO";
			string dbMsg = "";
			double ResultNow = 0.0;
			try {
				dbMsg += "BeforeVals=" + ParenVals.Count + "組";
				ObservableCollection<BeforeVal> PFOVals = new ObservableCollection<BeforeVal>();
				string bOperater = "";
				double bValue = 0.0;
				foreach (BeforeVal beforeVal in ParenVals) {
					string nOperater = beforeVal.Operater;
					double? nValue = null;
					if(beforeVal.Value!=null) {
						nValue = (double)beforeVal.Value;
					}
					dbMsg += "\r\n" + nOperater + " " + nValue;
					BeforeVal pfoVal = new BeforeVal();
					if (nOperater.Equals("")) {
						dbMsg += "＜＜開始";
						pfoVal.Operater = nOperater;
						pfoVal.Value = nValue;
						PFOVals.Add(pfoVal);
					} else if (nOperater.Equals(AddStr) || nOperater.Equals(SubtractStr)) {
						dbMsg += "＜＜和差";
						pfoVal.Operater = nOperater;
						pfoVal.Value = nValue;
						PFOVals.Add(pfoVal);
					} else if (nOperater.Equals(MultiplyStr)) {
						dbMsg += "積>>";
						BeforeVal bPFOVal = PFOVals[PFOVals.Count - 1];
						dbMsg += bPFOVal.Value + "×" + nValue;
						bPFOVal.Value *= nValue;
						dbMsg += "=" + bPFOVal.Value ;
						PFOVals[PFOVals.Count - 1].Value = bPFOVal.Value;
					} else if (nOperater.Equals(DivideStr)) {
						dbMsg += "商>>";
						BeforeVal bPFOVal = PFOVals[PFOVals.Count - 1];
						dbMsg += bPFOVal.Value;
						if (bPFOVal.Value != 0) {
							dbMsg +=  "÷" + nValue;
							bPFOVal.Value /= nValue;
						}else{
							bPFOVal.Value = 0;
						}
						PFOVals[PFOVals.Count - 1].Value = bPFOVal.Value;
					} else if (nOperater.Equals(ParenStr)) {
						dbMsg += "(" + nValue;
					} else if (nOperater.Equals(ParenthesisStr)) {
						dbMsg += ")" + nValue;
					}
				}
				dbMsg += "PFOVals=" + PFOVals.Count + "組";
				foreach (BeforeVal beforeVal in PFOVals) {
					bOperater = beforeVal.Operater;
					bValue = (double)beforeVal.Value;
					dbMsg += "\r\n" + bOperater + " " + bValue;
					ResultNow = ReCalkBody(ResultNow, beforeVal);
				}

				dbMsg += "=" + ResultNow;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return ResultNow;
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
				int lastRow = CalcProgress.Items.Count - 1;             //書込み結果で取得＞だめならソースで＞ (BeforeVals.Count - 1);
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
					BeforeVals[selectedIndex].Value = double.Parse(eValue);
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
		/// DataGridをクリック：直接編集開始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcProgress_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			string TAG = "CalcProgress_SelectedCellsChanged";
			string dbMsg = "";
			try {
				//			DataGrid DG = sender as DataGrid;
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
				string fieldName = (string)e.Column.Header;
				dbMsg += ",fieldName" + fieldName;
				TextBox textEdit = (TextBox)e.EditingElement;
				string eValue = textEdit.Text;
				dbMsg += " : " + eValue;
				if (fieldName.Equals("Operater")) {
					if (eValue.Equals(AddStr) ||
						eValue.Equals(SubtractStr) ||
						eValue.Equals(DivideStr) ||
						eValue.Equals(MultiplyStr)) {
						dbMsg += ",問題無し";
						ProgressEdit(selectedIndex, fieldName, eValue);
					} else {
						String msgStr = "演算子(+-*/)以外が入力されています\r\n";
						msgStr += eValue;
						msgStr += "\r\n修正をお願いします";
						MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
						IsPrgresEdit = false;
						textEdit.Text = BeforeVals[selectedIndex].Operater.ToString();
				//		CalcProcess.Focus();
						return;
					}
				} else if (fieldName.Equals("Value")) {
					double number;
					if (double.TryParse(eValue, out number)) {
						dbMsg += ",入力の変換結果=" + number;
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
		///階乗 ^n
		/// </summary>
		private void PowerFunc() {
			string TAG = "Power";
			string dbMsg = "階乗:作成中";
			try {
				string NextOperation = PowerStr;
				//			ProcessedFunc(NextOperation);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		/// <summary>
		///階乗 ^n
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PowerBt_Click(object sender, RoutedEventArgs e) {
			PowerFunc();
		}
		/// <summary>
		/// 平方根 ^1/n
		/// </summary>
		private void SqrtFunc() {
			string TAG = "Power";
			string dbMsg = "平方根:作成中";
			try {
				string NextOperation = SqrtStr;
				//			ProcessedFunc(NextOperation);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 平方根　
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>　^0.5
		private void SqrtBt_Click(object sender, RoutedEventArgs e) {
			SqrtFunc();
		}

		/// <summary>
		/// 優先範囲開始の設定
		/// </summary>
		private void ParenFunc() {
			string TAG = "ParenFunc";
			string dbMsg = "";
			try {
				string NextOperation = ParenStr;
				ProcessedFunc(NextOperation);
				//演算子を優先部開始にして
				CalcOperation.Content = ParenStr;
				if(!NowOperations.Text.Equals("")) {
					//Parenが起動トリガになった場合を避けて、電卓上での入力後にのみ追記
					NowOperations.Text += ParenStr;
					dbMsg += ",NowOperations=" + NowOperations.Text;
				}
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
				dbMsg += ",優先範囲残り=" + ParenCount + "階層";
			//	string NextOperation = ParenthesisStr;
				//		ProcessedFunc(NextOperation); を使わず、ここで独自処理
				BeforeVal NowInput = new BeforeVal();
		//		NowInput.Value = null;
				NowInput.Operater = CalcOperation.Content.ToString();
				NowInput.Value = Double.Parse(InputStr);
				dbMsg += ",一つ前の入力を格納格納=" + NowInput.Operater + " : " + NowInput.Value;
				BeforeVals.Add(NowInput);

				NowInput = new BeforeVal();
				NowInput.Operater = ParenthesisStr;
				NowInput.Value = null;
				dbMsg += ",優先範囲終端記号を格納=" + NowInput.Operater + " : " + NowInput.Value;
				BeforeVals.Add(NowInput);
				InputStr = "";
				CalcProcess.Text = InputStr;
				CalcOperation.Content = ParenthesisStr;
				NowOperations.Text += ParenthesisStr;
				dbMsg += ",NowOperations=" + NowOperations.Text;
				BeforeOperation = ParenthesisStr;
				ParenCount--;
				dbMsg += ",優先範囲開始=" + ParenCount + "階層";
				ReCalk();
				CalcResult.Content = ProcessVal.ToString();
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
			NowOperations.Text += operaterStr;
		}

		/// <summary>
		/// 除算
		/// </summary>
		private void DivideFunc()
		{
			string TAG = "DivideFunc";
			string dbMsg = "";
			try {
				string InputStr = CalcProcess.Text;
				dbMsg += ",現在=" + InputStr;
				 ReCalk();
				dbMsg += ",ここまでの演算結果=" + ProcessVal;
				if (BeforeVals.Count < 1 ) {
					dbMsg += ",最初の値が無い";
					if (InputStr.Equals("")) {
						MessageBox.Show("0は除算できません。割られる値から入力して下さい。");
					}else{
						dbMsg += ">>最初の値を登録";
						OperaterInput(DivideStr);
					}
				//} else if (ProcessVal == 0) {
				//	MessageBox.Show("ここまでの演算結果が0になっています。0は除算できません");
				} else {
					dbMsg += ">>通常登録";
					OperaterInput(DivideStr);
				}
				MyLog(TAG, dbMsg);
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
			OperaterInput(AddStr);
			//	PlusFunc();
		}
		/// <summary>
		/// 減算
		/// </summary>
		private void MinusBt_Click(object sender, RoutedEventArgs e)
		{
			OperaterInput(SubtractStr);
		}
		/// <summary>
		/// 積算
		/// </summary>
		private void AsteriskBt_Click(object sender, RoutedEventArgs e)
		{
			OperaterInput(MultiplyStr);
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

		/// <summary>
		/// 数字の逐次入力
		/// </summary>
		/// <param name="inputStr"></param>
		private void NumInput(string inputStr) {
			InputStr += inputStr;
			CalcProcess.Text = InputStr;
			NowOperations.Text += InputStr;
		}

		/// <summary>
		/// 小数点
		/// </summary>
		private void DecimalFunc() {
			isDecimal = true;
			NumInput(".");
		}

		private void PeriodBt_Click(object sender, RoutedEventArgs e)
		{
			DecimalFunc();
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
//				MyLog(TAG, dbMsg);
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
			//			CalcProcess.Focus();
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
		//			ProcessVal = ReCalk();
				} else {
					dbMsg = "表示";
					KeyGrid.Visibility = Visibility.Collapsed;
					CalcProgress.Visibility = Visibility.Visible;
					CorpBt.Content = "△";
				}
				MyLog(TAG, dbMsg);
			}
			catch (Exception er)
			{
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
		//	ProcessVal = ReCalk();
		}
		private void DataGridTextColumn_Opened(object sender, RoutedEventArgs e) {
			string TAG = "DataGridTextColumn_Opened";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 経過に記録されたアイテムを分割する
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ProgressItemSepareat(object sender, RoutedEventArgs e) {
			string TAG = "ProgressItemSepareat";
			string dbMsg = "";
			try {
				//最新状態を取得
				CalcProgress.Items.Refresh();
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
				insertRecord.Value = double.Parse(insertValStr);

				string titolStr = "電卓；入力値の変更";
				String msgStr = "["+ insertPosition + "番目]" + selectedValueString + "を分割します。\r\n";
				msgStr += "\r\nよろしいですか？";
				msgStr += "\r\n(中心で分割して演算子は" + insertRecord.Operater + "で" + insertRecord.Value + "にします)";
				MessageBoxResult dResurt = MessageShowWPF(msgStr, titolStr, MessageBoxButton.OKCancel, MessageBoxImage.Error);
				if (dResurt == MessageBoxResult.OK){
					dbMsg += "分割開始";
					BeforeVals.Insert(insertPosition, insertRecord);
					BeforeVals[selectedIndex].Value = double.Parse(selectedValueString.Substring(0,sepPosition));

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
				string selectedValueString = selectedItem.Value.ToString();
				int insertPosition = selectedIndex + 1;
				string titolStr = "電卓；入力値の削除";
				String msgStr = "[" + insertPosition + "番目]" + selectedValueString + "を削除します。\r\n";
				msgStr += "\r\nよろしいですか？";
				MessageBoxResult dResurt = MessageShowWPF(msgStr, titolStr, MessageBoxButton.OKCancel, MessageBoxImage.Error);
				if (dResurt == MessageBoxResult.OK) {
					dbMsg += "削除開始";
					BeforeVals.RemoveAt(selectedIndex);
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

		/// <summary>
		/// 電卓処理：現在の結果に次の演算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PriorityCalcOperation(object sender, RoutedEventArgs e) {
			IsPriorityFourArithmeticOperation = SetOperationPriority(false);
		}

		/// <summary>
		/// 四則演算の優先順位で計算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PriorityFourArithmeticOperation(object sender, RoutedEventArgs e) {
			IsPriorityFourArithmeticOperation= SetOperationPriority(true);
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
				IsPriorityFourArithmeticOperation = retBool;
				PCOMenu.IsEnabled = false;
				PFAOMenu.IsEnabled = false;
				if (retBool) {
					dbMsg += "四則演算の優先順位で計算 に切替";
					PCOMenu.IsEnabled = true;
				} else {
					dbMsg += "電卓処理 に切替";
					PFAOMenu.IsEnabled = true;
				}
				ReCalk();
	//			CalcResult.Content = ProcessVal;
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
		//		MyLog(TAG, dbMsg);
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
				ComboBox cb = MemoryComb;       // (ComboBox)sender;
				InputStr = cb.SelectedItem.ToString();
				//	String sele = MemoryComb.Text;
				dbMsg += "選択値=" + InputStr;
				CalcProcess.Text = InputStr;
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
					string titolStr = "電卓：メモリから削除"; ;
					String msgStr = "[" + (cb.SelectedIndex + 1) + "]" + cb.SelectedValue + "をメモリから削除します。";
					MessageBoxResult res = MessageShowWPF(msgStr, titolStr, MessageBoxButton.YesNo, MessageBoxImage.Information);
					if (res.Equals(MessageBoxResult.Yes)) {
						MemoryComb.Items.RemoveAt(cb.SelectedIndex);
						dbMsg += "＞＞" + MemoryComb.Items.Count + "件";
						if (MemoryComb.Items.Count < 1) {
							MemoryComb.Visibility = Visibility.Hidden;
						}
					}
				}
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
			public double? Value { get; set; }
		}

	}

}