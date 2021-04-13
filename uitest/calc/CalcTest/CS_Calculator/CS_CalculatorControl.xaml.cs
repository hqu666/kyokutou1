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

				//	IsPO = Properties.Settings.Default.IsPO;
	
				//計算の優先順位は電卓処理から
	//			IsPO = SetOperationPriority(false);
//#if DEBUG
//				IsPO = SetOperationPriority(true);
//#endif
				MemoryComb.Visibility = Visibility.Hidden;
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
				if (TargetTextBox != null) {
					dbMsg += ",TextBoxから";
					InputStr = TargetTextBox.Text;
				}else if (TargetTextBlock != null) {
					dbMsg += ",TextBlockから";
					InputStr = TargetTextBlock.Text;
				}
				dbMsg += ",InputStr=" + InputStr;
		//		CalcProcess.Text = InputStr;
				//計算経過
				NowOperations.Text = InputStr;              // BeforeVals[0].Value.ToString(); 
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
					NowOperations.Text += NextOperation;
				} else if (OperatKey == Key.D8) {
					NextOperation = ParenStr;
					ParenFunc();
				}
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
			//	InputStr = CalcProcess.Text;
				dbMsg += ",入力状況=" + InputStr;
				if (0 < InputStr.Length) {
					//入力エリアに文字が有る間は一文字づつ消去
					InputStr = InputStr.Substring(0, InputStr.Length - 1);
		//			CalcProcess.Text = InputStr;
				} else {
					dbMsg += ",BeforeVals残り=" + BeforeVals.Count + "件";
					if (0 < BeforeVals.Count) {
						//最終確定入力を読出し
						BeforeVal LastInput = BeforeVals[BeforeVals.Count - 1];
						string LastOperatier = LastInput.Operater;
						dbMsg += ",演算子=" + LastOperatier;            //Parenなど
		//				CalcOperation.Content = LastOperatier;
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
		//					CalcProcess.Text = InputStr;
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
				BeforeOperation = "";
				dbMsg += "最終入力" + InputStr;
				//if (BeforeOperation.Equals(ParenthesisStr) && !InputStr.Equals("")) {
				//	dbMsg += "；優先範囲終端直後の数値";
				//	BeforeVals[BeforeVals.Count - 1].Value = double.Parse(InputStr);
				//	ProgressRefresh();
				//	ReCalk();
				//	CalcResult.Content = ResultStr; 
				//	OnPropertyChanged("ResultStr");
				//} else 
				if (InputStr.Equals("")) {
					dbMsg += "処理する入力が無い";
					MyLog(TAG, dbMsg);
					MyCallBack();
				} else if (IsBegin) {
					IsBegin = false;
					ProcessedFunc("");
				} else {
					dbMsg += "," + InputStr + "を" + BeforeOperation;
					//BeforeVal eVals = new BeforeVal();
					// eVals.Operater= BeforeOperation;
					//eVals.Value = Double.Parse(InputStr);
					//dbMsg += eVals.Operater + eVals.Value;

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
				dbMsg += ",渡された演算子=" + NextOperation;
				dbMsg += ",現在の入力値=" + InputStr;
				BeforeVal NowInput = new BeforeVal();
				NowInput.Operater = NextOperation;
				dbMsg += ",前の演算子=" + BeforeOperation;
				//if (BeforeOperation.Equals(ParenthesisStr) && !InputStr.Equals("")) {
				//	BeforeVals[BeforeVals.Count - 1].Value= double.Parse(InputStr);

				if (!InputStr.Equals("") ) {
					string bInputOperater = "";
					double ? bInputValue = null;
					int bIndex = BeforeVals.Count - 1;
					dbMsg += ",前の格納[" + bIndex + "]";
					if(-1<bIndex) {
						BeforeVal bInput = BeforeVals[bIndex];
						bInputOperater = bInput.Operater;
						bInputValue = bInput.Value;
						dbMsg += bInputOperater + bInputValue;
					}else{
						dbMsg += "未格納";
					}
					if (bInputOperater.EndsWith(ParenStr) && bInputValue ==null && 1 < bIndex) {
						BeforeVals[bIndex].Value = double.Parse(InputStr);
						dbMsg += ",>>" + BeforeVals[BeforeVals.Count - 1].Operater + BeforeVals[BeforeVals.Count - 1].Value;
						InputStr = "";
					} else {
						//演算値が有れば配列格納
						NowInput.Operater = BeforeOperation;                // 20210330:CalcOperation.Content.ToString();
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
					}
				} else if (NextOperation.EndsWith(ParenStr)) {
					dbMsg += ",優先開始";
					NowInput.Value = null;
					dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
					BeforeVals.Add(NowInput);
					InputStr = "";
				} else {
					dbMsg += ",入力無し：演算子から入力された";
				//	CalcOperation.Content = NextOperation;
				}
				ProgressRefresh();

				BeforeOperation = NextOperation;
				NowOperations.Text += NextOperation;
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
				//if (1 == iValCount && isParsonOnly) {
				//	dbMsg += ">関数ではない>積算に置き換え";
				//	aVal.Operater = MultiplyStr;
				//}
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
		private void CalcParen(double parenResult, ObservableCollection<BeforeVal> ParenVals , int ParenCount, int ParenthesisCount) {
			string TAG = "CalcParen";
			string dbMsg = "";
			ObservableCollection<BeforeVal> resurtVals = new ObservableCollection<BeforeVal>();
			try {
				dbMsg += ",演算結果=" + parenResult + "]";
				dbMsg += ",経過配列=" + ParenVals.Count + "件";
#if DEBUG
				foreach (BeforeVal tVal in ParenVals) {
					string tOperater = tVal.Operater;
					double? tValue = tVal.Value;
					dbMsg += "" + tOperater + tValue;
				}
#endif				
				dbMsg += ",優先範囲出現数：開始=" + ParenCount + "回/終了="+ ParenthesisCount+"回";
				ParenCount -= ParenthesisCount;
				dbMsg += ">>" + ParenCount +  "回";
				int iParenCount = 0;							//処理中の優先範囲
				int iValCount = 0;								//範囲内の未処理入力値数
				bool isParsonOnly = false;					//優先範囲指定のみ：関数ではない
				BeforeVal bVal = new BeforeVal();		//経過各行
				int valsCount = 0;                              //経過行数
				int valsEnd = ParenVals.Count;           //行数
				string parenOperare = MultiplyStr;
				bool isInParen = false;
				foreach (BeforeVal iVal in ParenVals) {
					valsCount++;
					dbMsg += "\r\nSouce" + valsCount + "/" + valsEnd + "行目" ;
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += ":" + iOperater + iValue;
					if(iVal.Value == null) {
						iValue = null;
					}
					//int valsRest = valsEnd - valsCount;                                   //残り行数
					//dbMsg += ":処理残り" + valsRest;
					if (iOperater.EndsWith(ParenStr)) {
						dbMsg += "：優先範囲開始;";
						iParenCount++;
						isInParen = true;
						if (iValue== null) {
							dbMsg += "：値無し;そのまま格納";
							resurtVals.Add(iVal);
						} else {
							parenResult = (double)iValue;
			//				parenResult = 0.0;
						}
						if (0<iParenCount) {
							parenOperare = ParenStr;
						}else{
							parenOperare = MultiplyStr;
						}
					} else if (iOperater.Equals(ParenthesisStr)) {
						dbMsg += "：優先範囲終了;";
						BeforeVal aVal =new BeforeVal();
						if (isInParen) {
							aVal.Operater = parenOperare;
						}else if(parenResult<0) {
							aVal.Operater = SubtractStr;
							parenResult *= -1;
						} else{
							aVal.Operater = MultiplyStr;
						}
						aVal.Value = parenResult;
						dbMsg += aVal.Operater + aVal.Value + "を格納";
						resurtVals.Add(aVal);
						iParenCount--;
						if (parenOperare.Equals(ParenStr)) {           
							dbMsg += "：終端を作成";
							aVal = new BeforeVal();
							aVal.Operater = ParenthesisStr;
							aVal.Value = null;
							resurtVals.Add(aVal);
						}
						isInParen = false;
						dbMsg += "：：範囲終了：残処理=" + iParenCount;
					} else if(iParenCount < 1) {
						dbMsg += "：優先範囲外;そのまま格納";
						resurtVals.Add(iVal);
					} else {
						dbMsg += "：優先範囲内;";
						parenResult = ReCalkBody(parenResult, iVal);
					}
					dbMsg += "：範囲集計値=" + parenResult;
					//ループ終端でも優先範囲が完結しない場合の処理に渡す
					bVal.Operater = iVal.Operater;
					bVal.Value = iVal.Value;
					int eCount = resurtVals.Count - 1;
					dbMsg += "[終端" + (eCount + 1) + "件]=" + resurtVals[eCount].Operater + resurtVals[eCount].Value;
					dbMsg += "：Paren残り=" + iParenCount + "回";
				}
				iParenCount -= ParenthesisCount;
				dbMsg += "\r\n優先範囲処理：残り=" + iParenCount + "回";
				if (0< iParenCount) {
					dbMsg += ">優先範囲未完結＞格納";
					bVal = RemainPason(iValCount, parenResult, isParsonOnly);
					resurtVals.Add(bVal);
					//範囲終了の不足を補完
					for (int i = 0; i < iParenCount; i++) {
						BeforeVal aVal = new BeforeVal();       //経過各行
						aVal.Operater = ParenthesisStr;
						aVal.Value = null;
						resurtVals.Add(aVal);
					}
				}

				dbMsg += ">中置記法対応後>" + resurtVals.Count + "組=";

				//#if DEBUG
				string afterStr = "";
				foreach (BeforeVal iVal in resurtVals) {
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					afterStr += "" + iOperater + iValue;
				}
				dbMsg += afterStr;
				afterStr = afterStr.Replace(")(" ,MultiplyStr);
				dbMsg += ">>"+afterStr;
				//#endif
				dbMsg += "\r\n優先範囲出現数：残り=" + ParenCount + "回";
				MyLog(TAG, dbMsg);
				//if (0 < ParenCount) {
				//	CalcParen(parenResult, resurtVals, ParenCount, ParenthesisCount);
				//}else{
				ReCalkEnd(resurtVals);
				//}
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
				string PFAOStr = "";
				int valsCount = 0;                              //経過行数
				int valsEnd = BeforeVals.Count;           //行数
														 //中置記法を数えて,経過表示を更新する
				foreach (BeforeVal iVal in BeforeVals) {
					valsCount++;
					dbMsg += "\r\nSouce" + valsCount + "/" + valsEnd + "行目";
					string iOperater = iVal.Operater;
					double? iValue = iVal.Value;
					dbMsg += ":" + iOperater + iValue;
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
							if(iValue==null) {
								PFAOStr += iOperater;
							}else{
								PFAOStr += ")*";
							}
						} else {
							PFAOStr += iOperater;
						}
					}
					NowOperations.Text += iValue;
					PFAOStr += iValue;
				}
				dbMsg += "\r\n優先範囲開始=" + iParenCount + "件:終了 = " + ParenthesisCount + "件";
				int deficitParenthesis = iParenCount - ParenthesisCount;
				dbMsg += "：)不足＝"+ deficitParenthesis;
				dbMsg += "入力状況" + PFAOStr;
				for (int tCount = 0; tCount < deficitParenthesis; tCount++) {
					PFAOStr += ParenthesisStr;
				}
				dbMsg += ">優先範囲終端補完>" + PFAOStr;
				if (IsPO) {
					dbMsg += ">>四則演算処理:";
					if (PFAOStr.Equals("")) {
						CalcResult.Content = InputStr.ToString();
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
							string titolStr = "電卓：結果表示";
							MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Error);
							MyErrorLog(TAG, dbMsg, er);
						}
					}
				} else {
					dbMsg += ">>電卓処理";
					MyLog(TAG, dbMsg);
					if (0< iParenCount) {
						dbMsg += ">>優先範囲有り";
						StrInParenCalc(PFAOStr);
		//				CalcParen(ResultNow, BeforeVals, iParenCount, ParenthesisCount);
					}else{
						dbMsg += ">>優先範囲無し";
						string rStr = CalculatorCalc(PFAOStr);
						ProcessVal = Double.Parse(rStr);
						CalcResult.Content = ProcessVal.ToString();
						//		ReCalkEnd(BeforeVals);
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 演算子の出現位置
		/// </summary>
		/// <param name="pStr"></param>
		/// <returns></returns>
		private int OpraterIndex(string pStr) {
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
				int SubtractPoint = pStr.IndexOf(SubtractStr);
				if (-1 < SubtractPoint) {
					dbMsg += "、SubtractPoint=" + SubtractPoint;
					if(retInt> SubtractPoint || retInt == -1) {
						retInt = SubtractPoint;
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
		//		MyLog(TAG, dbMsg);
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
				double finishVal = 0;
				string inParenStr = pStr;           // pStr.Substring(startPoint, endPoint);
				dbMsg += "," + inParenStr;
				int startPoint = inParenStr.IndexOf(ParenStr);
				int endPoint = inParenStr.IndexOf(ParenthesisStr);
				int calcLength = endPoint- startPoint;
				dbMsg += ",優先範囲の位置" + startPoint + "～" + +endPoint + "(" + calcLength + "文字)まで";
				if (-1 < startPoint) {
					//優先範囲と前後に分ける
					string beforeStr = inParenStr.Substring(0,startPoint-1);
					string calcStr = inParenStr.Substring(startPoint+1);
					string remStr = "";                 //残りを記録
					if (-1 < endPoint) {
						calcStr = inParenStr.Substring(startPoint, calcLength);
						remStr = inParenStr.Substring(endPoint+1);
					}
					//開始に続いて数値が有るところまで
					while (-1 < calcStr.IndexOf(ParenStr)) {
						startPoint++;
						calcLength--;
						beforeStr = inParenStr.Substring(0,startPoint-1);
						calcStr = inParenStr.Substring(startPoint+1);
						if (-1 < endPoint) {
							calcStr = inParenStr.Substring(startPoint, calcLength);
						}
					}
					dbMsg += "\r\n直後にParen:startPoint=" + startPoint + "～" + endPoint + "(" + calcLength + "文字)に修正";
					dbMsg += ";" + beforeStr + " と " + calcStr + " と " + remStr;
					calcStr = CalculatorCalc(calcStr);
					inParenStr = beforeStr + calcStr + remStr;
					dbMsg += "、範囲内計算後=" + inParenStr;
					if(-1 < inParenStr.IndexOf(ParenStr)) {                         //1< pCount
						dbMsg += ">優先範囲残り>再帰";
						MyLog(TAG, dbMsg);
						StrInParenCalc(inParenStr);
					}
				}
				//混入防止
				dbMsg += "、優先範囲除去=" + inParenStr;
				string testStr = inParenStr.Replace(ParenStr, "");
				testStr = testStr.Replace(ParenthesisStr, "");
				inParenStr = CalculatorCalc(testStr);			//余計？
				dbMsg += "、終了判定前=" + inParenStr;
				if (double.TryParse(inParenStr, out finishVal)) {       //-1 == OpraterIndex(inParenStr)
					dbMsg += ">>最終値="+ finishVal;
					ProcessVal = Double.Parse(inParenStr);
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
			string inOperateStr = pStr;           // pStr.Substring(startPoint, endPoint);
			try {
				dbMsg += ",開始=" + inOperateStr;
				int endPoint = OpraterIndex(inOperateStr);
				dbMsg += ",演算子の位置" + endPoint + "まで" ;
				if (0 < endPoint) {
					//演算子が無くなるまで先頭から計算
					while (0 < OpraterIndex(inOperateStr)) {
						endPoint = OpraterIndex(inOperateStr);
						string calcStr = inOperateStr.Substring(0, endPoint);
						dbMsg += "\r\n前値=" + calcStr;
						string remStr = inOperateStr.Substring(endPoint);
						dbMsg += ",以降:" + remStr;
						endPoint = OpraterIndex(remStr.Substring(1));
						dbMsg += ",次は：" + endPoint + "まで";
						if (endPoint == -1) {
							calcStr = inOperateStr;
							dbMsg += "、渡されたのは2値だけ";
							remStr = "";
						}else{
							//		calcStr = inOperateStr.Substring(0, endPoint);
							calcStr += remStr.Substring(0, endPoint+1);
							//			dbMsg += ",後値=" + calcStr;
							remStr = inOperateStr.Substring(endPoint + 2);
						}
						dbMsg += ">>" + calcStr;
						try {
							dbMsg += ",Compute=" + calcStr;
							System.Data.DataTable dt = new System.Data.DataTable();
							var pVal = dt.Compute(calcStr, "");
							inOperateStr = pVal.ToString() ;
							dbMsg += "=" + inOperateStr;
						} catch (Exception er) {
							MyErrorLog(TAG, dbMsg, er);
						}
						dbMsg += ",残り=" + remStr;
						inOperateStr += remStr;
						dbMsg += ">>" + inOperateStr;
					}
				} else{
					dbMsg += "、演算子無し";
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			return inOperateStr;
		}


		private void ReCalkEnd(ObservableCollection<BeforeVal> ParenVals) {
			string TAG = "ReCalkEnd";
			string dbMsg = "";
			double ResultNow = 0.0;
			try {
				dbMsg += "最終処理前" + ParenVals.Count + "組\r\n";
#if DEBUG
				//入力値が侵食されていない事を確認する
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
						dbMsg += ">>電卓処理";
					bool isParenCalcAfter = true;
					if (ParenVals.Count == BeforeVals.Count) {
						 isParenCalcAfter = false;
					}
					dbMsg += ":中置記法対応=" + isParenCalcAfter;
					foreach (BeforeVal cVals in ParenVals) {
						dbMsg += "＞" + cVals.Operater + cVals.Value;
						if (cVals.Value != null) {
							ResultNow = ReCalkBody(ResultNow, cVals);
						}else if(isParenCalcAfter) {
							ResultNow = 0.0;
						}
					}
					dbMsg += "=" + ResultNow;
					ProcessVal = ResultNow;
					CalcResult.Content = ProcessVal.ToString();
				}
				dbMsg += "=" + ResultNow;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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
				dbMsg += ",優先範囲残り=" + ParenCount + "階層";
				dbMsg += ",BeforeOperation=" + BeforeOperation + ",現在の入力" + InputStr;
				dbMsg += ",最終確定値=" + BeforeVals[BeforeVals.Count-1].Operater + BeforeVals[BeforeVals.Count - 1].Value;
				//		ProcessedFunc(NextOperation); を使わず、ここで独自処理
				BeforeVal NowInput = new BeforeVal();
				NowInput.Operater = BeforeOperation;					//20210330: CalcOperation.Content.ToString();
				NowInput.Value = Double.Parse(InputStr);
				dbMsg += ",一つ前の入力を格納格納=" + NowInput.Operater + " : " + NowInput.Value;
				BeforeVals.Add(NowInput);

				NowInput = new BeforeVal();
				NowInput.Operater = ParenthesisStr;
				NowInput.Value = null;
				dbMsg += ",優先範囲終端記号を格納=" + NowInput.Operater + " : " + NowInput.Value;
				BeforeVals.Add(NowInput);
				InputStr = "";
				//計算経過に追記;
				NowOperations.Text += ParenthesisStr;
				//dbMsg += ",NowOperations=" + NowOperations.Text;
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
	//		NowOperations.Text += operaterStr;
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
	//		CalcProcess.Text = InputStr;
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
			IsPO = SetOperationPriority(false);
		}

		/// <summary>
		/// 四則演算の優先順位で計算
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PriorityFourArithmeticOperation(object sender, RoutedEventArgs e) {
			IsPO= SetOperationPriority(true);
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
		//		CalcProcess.Text = InputStr;
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