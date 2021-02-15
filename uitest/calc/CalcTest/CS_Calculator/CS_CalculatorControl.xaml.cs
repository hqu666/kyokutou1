using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Infragistics.Controls;
using Infragistics.Windows.DataPresenter;

namespace CS_Calculator {
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

		/// <summary>
		/// XamDataGridのセル
		/// </summary>
		public Cell TargetCell {
			get { return (Cell)GetValue(TargetCellProperty); }
			set { SetValue(TargetCellProperty, value); }
		}
		public static readonly DependencyProperty TargetCellProperty =
			DependencyProperty.Register("TargetField", typeof(Cell), typeof(CS_CalculatorControl), new PropertyMetadata(default(Cell)));
		//
		//public Field TargetField {
		//	get { return (Field)GetValue(TargetFieldProperty); }
		//	set { SetValue(TargetFieldProperty, value); }
		//}
		//public static readonly DependencyProperty TargetFieldProperty =
		//	DependencyProperty.Register("TargetField", typeof(Field), typeof(CS_CalculatorControl), new PropertyMetadata(default(Field)));


		//public TextField TargetTextField {
		//	get { return (TextBlock)GetValue(TargetTextFieldProperty); }
		//	set { SetValue(TargetTextFieldProperty, value); }
		//}
		//public static readonly DependencyProperty TargetTextFieldProperty =
		//	DependencyProperty.Register("TargetTextField", typeof(TextField), typeof(CS_CalculatorControl), new PropertyMetadata(default(TextField)));

		/// <summary>
		/// キーボードもしくはボタンクリックで入力される値
		/// 初期値
		/// </summary>
		//	public string InputStr = "";
		public string InputStr {
			get { return (string)GetValue(InputStrProperty); }
			set { SetValue(InputStrProperty, value); }
		}
		public static readonly DependencyProperty InputStrProperty =
			DependencyProperty.Register("InputStr", typeof(string), typeof(CS_CalculatorControl), new PropertyMetadata(default(string)));

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
		/// 読込み完了後、エレメント参照やプロセスの始動を行う
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ThisLoaded(object sender, RoutedEventArgs e)
		{
			string TAG = "UserControl_KeyDown";
			string dbMsg = "";
			try {
				Initialize();
				if (TargetTextBox != null) {
					dbMsg += ",TextBoxから";
					InputStr = TargetTextBox.Text;
				}else if (TargetTextBlock != null) {
					dbMsg += ",TextBlockから";
					InputStr = TargetTextBlock.Text;
				}else if (TargetCell != null){
					dbMsg += ",XamDataGridのCellから";
					InputStr = TargetCell.Value.ToString();
				}


				dbMsg += ",InputStr=" + InputStr;
				CalcProcess.Text = InputStr;
				dbMsg += ",OperatKey=" + OperatKey.ToString();
				if (Key.Add <= OperatKey) {
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
			InputStr = "";
			BeforeVals = new ObservableCollection<BeforeVal>();
			ProcessVal = 0.0;
			isDecimal = false;
			BeforeOperation = "";
			CalcResult.Content = "";
			CalcOperation.Content = "";
			CalcProcess.Text = "";
			IsBegin = true;
			//DataGridの場合
			CalcProgress.ItemsSource = BeforeVals;
			CalcProgress.Items.Refresh();
			//	CalcProgress.Content = "";									//ラベルの場合
			CalcProcess.Focus();
		}

		/// <summary>
		/// C:クリア：一文字づつ消去
		/// </summary>
		private void ClearFunc()
		{
			string TAG = "ClearFunc";
			string dbMsg = "";
			try {
				//		string ProssesStr = CalcProgress.Content.ToString();
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
						if (InputStr.Contains("E")) {
							int bp = 16;
							string[] rStr = InputStr.Split('E');
							InputStr = rStr[0].Replace(".", "") + "0";
							dbMsg += ",sVer=" + InputStr;
							int pStr = int.Parse(rStr[1].Substring(1, rStr[1].Length - 1)) - bp;
							dbMsg += ",残り=" + pStr;
							InputStr += Math.Pow(10, pStr).ToString().Replace("1", "");
						}
						CalcProcess.Text = InputStr;
						///最後の確定入力を消去
						BeforeVals.RemoveAt(BeforeVals.Count - 1);
						ProcessVal = ReCalk();
						CalcResult.Content = ProcessVal;
						BeforeOperation = LastOperatier;
						//計算過程を更新
						CalcProgress.ItemsSource = BeforeVals;
						CalcProgress.Items.Refresh();
						////計算過程から最終確定値と演算子を消去
						////CalcProgress.Content = ProssesStr.Substring(0, (ProssesStr.Length - InputStr.Length - LastOperatier.Length - LineBreakStr.Length));
						////CalcProgressScroll.ScrollToBottom();
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
				if (!InputStr.Equals("")) {
					//演算値が有れば配列格納
					BeforeVal NowInput = new BeforeVal();
					NowInput.Operater = CalcOperation.Content.ToString();
					NowInput.Value = Double.Parse(InputStr);
					dbMsg += ",格納=" + NowInput.Operater + " : " + NowInput.Value;
					BeforeVals.Add(NowInput);
					dbMsg += ",演算前=" + ProcessVal;
					if (BeforeOperation.Equals("") || BeforeVals.Count<1) {
						//BeforeOperation.Equals("") || IsBegin
						//演算子が無ければそのまま格納
						ProcessVal = BeforeVals[BeforeVals.Count - 1].Value;
						IsBegin = false;
					} else {
						//演算子が有れば演算
						ProcessVal = ReCalk();
					}
					dbMsg += "＞結果＞" + ProcessVal;
					//計算結果と経過を更新	:SetResult
					CalcResult.Content = ProcessVal.ToString();
					//DataGridの場合
					CalcProgress.DataContext = BeforeVals;
					CalcProgress.Items.Refresh();
					ProgressRefresh();
					OnPropertyChanged("BeforeVals");
					InputStr = "";
					CalcProcess.Text = InputStr;

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
			string dbMsg = "";
			double ResultNow = 0.0;
			try {
				foreach (var BeforeVal in BeforeVals) {
					string bOperater = BeforeVal.Operater;
					double bValue = BeforeVal.Value;
					dbMsg += "\r\n" + bOperater + " " + bValue;
					if (bOperater.Equals("")) {
						dbMsg += "＜＜開始";
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
		/// 計算経過の更新
		/// </summary>
		public void ProgressRefresh()
		{
			string TAG = "ProgressRefresh";
			string dbMsg = "";
			try {
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
				ProcessVal = ReCalk();
				CalcResult.Content = ProcessVal.ToString();
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
				DataGrid DG = sender as DataGrid;
				int selectedIndex = DG.SelectedIndex;
				dbMsg += "[" + selectedIndex + "]";
				BeforeVal selectedItem = (BeforeVal)DG.SelectedItem;
				dbMsg += "=" + selectedItem.Operater + " : " + selectedItem.Value;
				IsPrgresEdit = true;
				dbMsg += "＞＞既存値変更開始" + IsPrgresEdit;
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
				//		CalcProcess.Focus();
						return;
					}
				}
				MyLog(TAG, dbMsg);
			//	ProgressEdit(selectedIndex, fieldName, eValue);
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
				string rText = (string)CalcResult.Content.ToString();
				dbMsg += ",rText=" + rText;
				if (TargetTextBox != null) {
					dbMsg += ",TextBoxへ";
					TargetTextBox.Text = rText;
				} else if (TargetTextBlock != null) {
					dbMsg += ",TextBlockへ";
					TargetTextBlock.Text = rText;
				}else if (TargetCell != null){
					dbMsg += ",XamDataGridのCellへ";
					//IntのCellなら四捨五入した整数が入る
					TargetCell.Value =double.Parse( rText);
				}
				CalcWindow.Close();
					MyLog(TAG, dbMsg);
			}
			catch (Exception er)
			{
				MyErrorLog(TAG, dbMsg, er);
			}
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
				double ProcessVal = ReCalk();
				dbMsg += ",ここまでの演算結果=" + ProcessVal;
				if (BeforeVals.Count < 1 ) {
					dbMsg += ",最初の値が無い";
					if (InputStr.Equals("")) {
						MessageBox.Show("0は除算できません。割られる値から入力して下さい。");
					}else{
						dbMsg += ">>最初の値を登録";
						string NextOperation = DivideStr;
						ProcessedFunc(NextOperation);
					}
				} else if (ProcessVal == 0) {
					MessageBox.Show("ここまでの演算結果が0になっています。0は除算できません");
				} else {
					dbMsg += ">>通常登録";
					string NextOperation = DivideStr;
					ProcessedFunc(NextOperation);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
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
			string dbMsg = "";
			try {
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
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			//		CalcProcess.Focus();
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
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			//		CalcProcess.Focus();
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
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			//			CalcProcess.Focus();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg)
		{
#if DEBUG
			Console.WriteLine(TAG + "[CalcTest.CS_Calculator:CS_CalculatorControl]" + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			Console.WriteLine(TAG + "[CalcTest.CS_Calculator:CS_CalculatorControl] : " + dbMsg + "でエラー発生;" + err);
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
			public double Value { get; set; }
		}

	}

}