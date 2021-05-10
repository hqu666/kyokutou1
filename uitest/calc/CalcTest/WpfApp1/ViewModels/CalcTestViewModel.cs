using Livet;
using Livet.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using CS_Calculator;
using Infragistics.Windows.DataPresenter;
using System.Collections.Generic;
using GrapeCity.Windows.SpreadGrid;
using System.Windows.Data;
using GsSGCell = GrapeCity.Windows.SpreadGrid.Cell;
using XDGCell = Infragistics.Windows.DataPresenter.Cell;
using System.Configuration;

namespace WpfApp1.ViewModels {
	public class CalcTestViewModel : ViewModel {
		public string titolStr = "カスタムパーツテスト";

		public Views.CalcTestView MyView { get; set; }
		//	public ViewModels.MainViewModel RootViewModel { get; set; }

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
	
		private string _CalcTextShowX;
		/// <summary>
		/// 表示位置X座標
		/// </summary>
		public string CalcTextShowX {
			get => _CalcTextShowX;
			set {
				if (_CalcTextShowX == value)
					return;
					_CalcTextShowX = value;
					Properties.Settings.Default.CalcTextShowX = _CalcTextShowX;
					Properties.Settings.Default.Save();
			}
		}

		private string _CalcTextShowY;
		public string CalcTextShowY {
			get => _CalcTextShowY;
			set {
				if (_CalcTextShowY == value)
					return;
					_CalcTextShowY = value;
					Properties.Settings.Default.CalcTextShowY = _CalcTextShowY;
					Properties.Settings.Default.Save();
			}
		}

		public string CalcWindowWidthStr { get; set; }
		public string CalcWindowHeightStr { get; set; }

		public double CalcWindowWidth = 180;
		public double CalcWindowHeight = 250;

		public int CalcVer { get; set; }
		/// <summary>
		/// 演算子の優先順位で計算"
		/// </summary>
		public bool IsPO { get; set; }
		/*System.Windows.Data Error: 40 : BindingExpression path error: 'IsPo' property not found on 'object' ''CalcTestViewModel' (HashCode=50838910)'. BindingExpression:Path=IsPo; DataItem='CalcTestViewModel' (HashCode=50838910); target element is 'CheckBox' (Name='IsPoCK'); target property is 'IsChecked' (type 'Nullable`1')
*/
		private List<Product> _GsGlist;
		/// <summary>
		/// GcSpreadGridのItemsSource
		/// </summary>
		public List<Product> GsGlist {
			get => _GsGlist;
			set {
				if (_GsGlist == value)
					return;
				_GsGlist = value;
				RaisePropertyChanged();
			}
		}

		private ObservableCollection<Product> _DGDatas;
		/// <summary>
		/// 基底DataGridのソース
		/// </summary>
		public ObservableCollection<Product> DGDatas {
			get => _DGDatas;
			set {
				if (_DGDatas == value)
					return;
				_DGDatas = value;
				RaisePropertyChanged();
			}
		}

		private Product _SelectedDGData;
		/// <summary>
		/// 基底DataGridの選択レコード
		/// </summary>
		public Product SelectedDGData {
			get => _SelectedDGData;
			set {
				if (_SelectedDGData == value)
					return;
				_SelectedDGData = value;
				RaisePropertyChanged();
			}
		}

		private ObservableCollection<Product> _XDGDatas;
		/// <summary>
		/// XamDataGridのソース
		/// </summary>
		public ObservableCollection<Product> XDGDatas {
			get => _XDGDatas;
			set {
				if (_XDGDatas == value)
					return;
				_XDGDatas = value;
				RaisePropertyChanged();
			}
		}

		/// <summary>
		/// ここからスタート
		/// </summary>
		public CalcTestViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			string TAG = "Initialize";
			string dbMsg = "";
			try {
				//値を取得
				CalcTextFontSize = Properties.Settings.Default.CalcTextFontSize;
				CalcTexWidth = Properties.Settings.Default.CalcTexWidth;
				CalcTextShowX = Properties.Settings.Default.CalcTextShowX;
				CalcTextShowY = Properties.Settings.Default.CalcTextShowY;
				CalcTextDLogTitol = "電卓";
#if DEBUG
				CalcTextDLogTitol = Properties.Settings.Default.CalcTextDLogTitol;      //setting.Value.ValueXml.InnerText;
#endif
				dbMsg += ",CalcTextDLogTitol=" + CalcTextDLogTitol;
				CalcWindowWidthStr = Properties.Settings.Default.CalcWindowWidthStr;
				CalcWindowHeightStr = Properties.Settings.Default.CalcWindowHeightStr;
				//パラメータの初期値
				if (CalcTextFontSize == null || CalcTextFontSize.Equals("")) {
					CalcTextFontSize = "18";
				}
				dbMsg += ",CalcTextFontSize=" + CalcTextFontSize;
				if (CalcTextDLogTitol == null || CalcTextFontSize.Equals("")) {
					CalcTextDLogTitol = "電卓を表示するフィールドから";
				}
				if (CalcTexWidth == null || CalcTextDLogTitol.Equals("")) {
					CalcTexWidth = "200";
				}
				dbMsg += ",CalcTexWidth=" + CalcTexWidth;
				dbMsg += ",(" + CalcTextShowX + "," + CalcTextShowY + ")";
				if (CalcTextShowX == null || CalcTextShowX.Equals("")) {
					CalcTextShowX = "1200";
					dbMsg += ">>x=" + CalcTextShowX;
				}
				if (CalcTextShowY == null || CalcTextShowY.Equals("")) {
					CalcTextShowY = "400";
					dbMsg += ">>y=" + CalcTextShowY + ")";
				}
				dbMsg += ",[" + CalcWindowWidth + "×" + CalcWindowHeight + "]";
				if (CalcWindowWidthStr == null || CalcWindowWidthStr.Equals("")) {
					CalcWindowWidthStr = "180";
				}
				CalcWindowWidth = double.Parse(CalcWindowWidthStr);
				dbMsg += ">>[" + CalcWindowWidth;
				if (CalcWindowHeightStr == null || CalcWindowHeightStr.Equals("")) {
					CalcWindowHeightStr = "250";
				}
				CalcWindowHeight = double.Parse(CalcWindowHeightStr);
				dbMsg += "×" + CalcWindowHeight + "]";
				if (CalcResult == null || CalcResult.Equals("")) {
					CalcResult = "0123456789";
				}
				CalcVer = Properties.Settings.Default.CalcVer;
				dbMsg += ",摘要Ver=" + CalcVer;
				if (CalcVer < 0) {
					CalcVer = 0;
					dbMsg += ">>" + CalcVer;
				}
				if (0 == CalcVer) {
					dbMsg += ":Ver,1";
					IsPO = false;
					Properties.Settings.Default.IsPO = IsPO;
					Properties.Settings.Default.Save();
				} else {
					dbMsg += ":Ver,2";
					bool? IsPOTest = Properties.Settings.Default.IsPO;
					dbMsg += ",数式入力=" + IsPOTest;
					if (IsPOTest != null) {
						IsPO = (bool)IsPOTest;
					}else{
						dbMsg += "未指定";
					}
				}
				CalcResult = Properties.Settings.Default.CalcResult;
				RaisePropertyChanged();

				GsGlist = new List<Product>();
				GsGlist.Add(new Product() { Name = "みるきーくいん", Price = 2080, Tax = 8 , Quantity=1 });
				GsGlist.Add(new Product() { Name = "徳陽ほうじ茶", Price = 298, Tax = 10, Quantity = 1 });
				GsGlist.Add(new Product() { Name = "バスサイズ石鹸", Price = 140, Tax = 10, Quantity = 1 });
				GsGlist.Add(new Product() { Name = "５袋ラーメン", Price = 298, Tax = 8, Quantity = 1 });

				/* 動的生成例：
				 * https://docs.grapecity.com/help/spread-wpf-2/GrapeCity.WPF.SpreadGrid~GrapeCity.Windows.SpreadGrid.BindingDataField~Binding.html
				MyView.MyGsGrid.AutoGenerateColumns = false;
				MyView.MyGsGrid.ItemsSource = GsGlist;
				MyView.MyGsGrid.ColumnCount = 3;

				PropertyDataField dataField1 = new PropertyDataField();
				dataField1.Property = "Name";
				MyView.MyGsGrid.Columns[0].DataField = dataField1;

				BindingDataField dataField2 = new BindingDataField();
				Binding binding = new Binding();
				binding.Path = new PropertyPath("Price");
				dataField2.Binding = binding;
				MyView.MyGsGrid.Columns[1].DataField = dataField2;
				*/

				/// XamDataGridに初期値を書き込むj
				XDGDatas = new ObservableCollection<Product> {
					new Product { Name="LEDシーリング", Price=4980, Tax=10 , Quantity=1 },
					new Product { Name="歯磨き粉", Price=298, Tax=10 , Quantity=1 },
					new Product { Name="おにぎり", Price=124, Tax=8 , Quantity=1 },
					new Product { Name="緑茶", Price=800, Tax=8 , Quantity=1 }
				};

				/// 基底DataGridに初期値を書き込むj
				DGDatas = new ObservableCollection<Product> {
					new Product { Name="化粧品", Price=1900, Tax=10 , Quantity=1 },
					new Product { Name="洗剤", Price=298, Tax=10 , Quantity=1 },
					new Product { Name="パン", Price=128, Tax=8 , Quantity=1 },
					new Product { Name="牛乳", Price=120, Tax=8 , Quantity=1 }
				};
				RaisePropertyChanged();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// Spredのテスト
		/// </summary>
		#region MyGsGridContextMenuClick	　GcSpreadGridのコンテキストメニューから電卓を呼び出す
	//	private ViewModelCommand _MyGsGridContextMenuClick;

		//public ViewModelCommand MyGsGridContextMenuClick {
		//	get {
		//		if (_MyGsGridContextMenuClick == null)
		//		{
		//			_MyGsGridContextMenuClick = new ViewModelCommand(CalcDlogGsG);
		//		}
		//		return _MyGsGridContextMenuClick;
		//	}
		//}
		///// <summary>
		///// GcSpreadGridのコンテキストメニューから電卓を呼び出す
		///// </summary>
		//public void CalcDlogGsG()
		//{
		//	string TAG = "CalcDlogGsG";
		//	string dbMsg = "";
		//	try{
		//		GcSpreadGrid DG = MyView.MyGsGrid;
		//		DG.Focus();
		//		GsSGCell activeCell = DG.ActiveCell;
		//		if (activeCell != null){
		//			// 行番号(0起算)
		//			int rowIndex = activeCell.Position.Row;
		//			// 列番号(0起算)
		//			int columnIndex = activeCell.Position.Column;
		//			dbMsg += "[" + rowIndex + " , " + columnIndex + "]";
		//			string orgVal = activeCell.Value.ToString();
		//			dbMsg += orgVal;
		//			var result = 0;
		//			if (int.TryParse(orgVal, out result)){
		//				dbMsg += "は数値で" + result;
		//				//タイトルの初期値は書き戻し先のフィールド名
		//				string ViewTitle = "データグリッド" + DG.Name + "の" + (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目";
		//				 if(!CalcTextDLogTitol.Equals(""))	{
		//					ViewTitle = CalcTextDLogTitol;
		//				}
		//				dbMsg += "[" + CalcWindowWidth + " × " + CalcWindowHeight + "]";
		//				//				Point pt = targetTextBlock.PointToScreen(new Point(0.0d, 0.0d));
		//				Double ShowX = 0;
		//				Double ShowY = 0;
		//				dbMsg += ",指定座標(" + CalcTextShowX + "," + CalcTextShowY + ")";
		//				if (CalcTextShowX != ""){
		//					ShowX = Double.Parse(CalcTextShowX);
		//				}
		//				if (CalcTextShowY != ""){
		//					ShowY = Double.Parse(CalcTextShowY);
		//				}
		//				dbMsg += ">>(" + ShowX + "," + ShowY + ")";
		//				//電卓クラスを生成して書き込み先の参照を渡す
		//				CS_CalculatorControl calculatorControl = new CS_CalculatorControl();
		//				Window CalcWindow = new Window{                           //Windowを生成
		//					Title = ViewTitle,
		//					Width = CalcWindowWidth,
		//					Height = CalcWindowHeight,
		//					Left = ShowX,
		//					Top = ShowY,
		//					Content = calculatorControl,
		//					ResizeMode = ResizeMode.NoResize,
		//					Topmost=true
		//				};
		//				dbMsg += ">>(" + CalcWindow.Left + " , " + CalcWindow.Top + ")[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
		//				calculatorControl.CalcWindow = CalcWindow;				//dllからクローズなどのwindow制御を行う
		//				calculatorControl.InputStr = result.ToString();             //dllに元の書込み値を渡すv
		//				//	calculatorControl.TargetGsCell = activeCell;書き戻すElementを指定すると
		//				//	組込み先のライブラリバージョン不一致などで使えない
		//				Nullable<bool> dialogResult = CalcWindow.ShowDialog();			//ダイアログ表示
		//				dbMsg += ",dialogResult=" + dialogResult;       //falseが返される
		//				string resultStr = calculatorControl.ResultStr;	//ダイアログを閉じるまでここには進まない
		//				dbMsg += ",戻り値=" + resultStr;
		//				if(resultStr != null){
		//					activeCell.Value = double.Parse(resultStr);
		//				}
		//			}else{
		//				String titolStr = "XamDataGrid:" + DG.Name + "でコンテキストメニューで選択したアイテム";
		//				String msgStr = (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目（" + orgVal + "）は数値ではありません";
		//				msgStr += "\r\n電卓は数値を入力するセルでご利用ください";
		//				MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
		//			}
		//		}else{
		//			dbMsg += ",activeCell == null";
		//		}
		//		MyLog(TAG, dbMsg);
		//	}
		//	catch (Exception er){
		//		MyErrorLog(TAG, dbMsg, er);
		//	}
		//}
		#endregion

		/// <summary>
		/// XamDataGrid
		/// </summary>
		/*
		#region XDGContextMenuClick	　XamDataGridのコンテキストメニューから電卓を呼び出す
		private ViewModelCommand _XDGContextMenuClick;

		public ViewModelCommand XDGContextMenuClick {
			get {
				if (_XDGContextMenuClick == null)
				{
					_XDGContextMenuClick = new ViewModelCommand(CalcDlogXDG);
				}
				return _XDGContextMenuClick;
			}
		}
	
		/// <summary>
		/// XamDataGridのコンテキストメニューから電卓を呼び出す
		/// </summary>
		public void CalcDlogXDG()
		{
			string TAG = "CalcDlogXDG";
			string dbMsg = "";
			try{
				XamDataGrid DG = MyView.MyXDG;
				DG.Focus();
				DataPresenterBase.SelectedItemHolder selectedItems = DG.SelectedItems;
				XDGCell activeCell = DG.ActiveCell;
				if (activeCell != null){
					// 行番号(0起算)
					int rowIndex = activeCell.Record.Index;
					// 列番号(0起算)
					int columnIndex = activeCell.Field.Index;
					dbMsg += "[" + rowIndex + " , " + columnIndex + "]";
					string orgVal = activeCell.Value.ToString();
					dbMsg += orgVal;
					var result = 0;
					if (int.TryParse(orgVal, out result)){
						dbMsg += "は数値で" + result;
						//タイトルの初期値は書き戻し先のフィールド名
						string ViewTitle = "データグリッド" + DG.Name + "の" + (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目";
						if (!CalcTextDLogTitol.Equals("")){
							ViewTitle = CalcTextDLogTitol;
						}
						dbMsg += "[" + CalcWindowWidth + " × " + CalcWindowHeight + "]";
						//				Point pt = targetTextBlock.PointToScreen(new Point(0.0d, 0.0d));
						Double ShowX = 0;
						Double ShowY = 0;
						dbMsg += ",指定座標(" + CalcTextShowX + "," + CalcTextShowY + ")";
						if (CalcTextShowX != ""){
							ShowX = Double.Parse(CalcTextShowX);
						}
						if (CalcTextShowY != ""){
							ShowY = Double.Parse(CalcTextShowY);
						}

						dbMsg += ">>(" + ShowX + "," + ShowY + ")";
						//電卓クラスを生成して書き込み先の参照を渡す
						CS_CalculatorControl calculatorControl = new CS_CalculatorControl();
						Window CalcWindow = new Window{                           //Windowを生成
							Title = ViewTitle,
							Width = CalcWindowWidth,
							Height = CalcWindowHeight,
							Left = ShowX,
							Top = ShowY,
							Content = calculatorControl,
							ResizeMode = ResizeMode.NoResize,
							Topmost = true
						};
						dbMsg += ">>(" + CalcWindow.Left + " , " + CalcWindow.Top + ")[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
						calculatorControl.CalcWindow = CalcWindow;              //dllからクローズなどのwindow制御を行う
						calculatorControl.InputStr = result.ToString();             //dllに元の書込み値を渡すv
																					//	calculatorControl.TargetGsCell = activeCell;書き戻すElementを指定すると
																					//	組込み先のライブラリバージョン不一致などで使えない
						Nullable<bool> dialogResult = CalcWindow.ShowDialog();          //ダイアログ表示
						dbMsg += ",dialogResult=" + dialogResult;       //falseが返される
						string resultStr = calculatorControl.ResultStr; //ダイアログを閉じるまでここには進まない
						dbMsg += ",戻り値=" + resultStr;
						if (resultStr != null){
							activeCell.Value = double.Parse(resultStr);
						}
					}else	{
						String titolStr = "XamDataGrid:" + DG.Name + "でコンテキストメニューで選択したアイテム";
						String msgStr = (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目（" + orgVal + "）は数値ではありません";
						msgStr += "\r\n電卓は数値を入力するセルでご利用ください";
						MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					}
				}else{
					dbMsg += ",activeCell == null";
				}
				MyLog(TAG, dbMsg);
			}catch (Exception er){
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		#endregion
		*/

		/*
				#region XDGCEllRIGHTClick	　XamDataGridのCellを右クリックで電卓を呼び出す
				private ViewModelCommand _XDGCEllRIGHTClick;

				public ViewModelCommand XDGCEllRIGHTClick {
					get {
						if (_XDGCEllRIGHTClick == null){
							_XDGCEllRIGHTClick = new ViewModelCommand(CalcDlogXDG2);
						}
						return _XDGCEllRIGHTClick;
					}
				}
				/// <summary>
				/// XamDataGridのCellを右クリックで電卓を呼び出す
				/// </summary>
				public void CalcDlogXDG2()
				{
					string TAG = "CalcDlogXDG2";
					string dbMsg = "";
					try
					{
						XamDataGrid DG = MyView.MyXDG2;
						DG.Focus();
						DataPresenterBase.SelectedItemHolder selectedItems = DG.SelectedItems;
						XDGCell activeCell = DG.ActiveCell;
						if (activeCell != null)
						{
							// 行番号(0起算)
							int rowIndex = activeCell.Record.Index;
							// 列番号(0起算)
							int columnIndex = activeCell.Field.Index;
							dbMsg += "[" + rowIndex + " , " + columnIndex + "]";
							string orgVal = activeCell.Value.ToString();
							dbMsg += orgVal;
							var result = 0;
							if (int.TryParse(orgVal, out result))
							{
								dbMsg += "は数値で" + result;
								//タイトルの初期値は書き戻し先のフィールド名
								string ViewTitle = "データグリッド" + DG.Name + "の" + (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目";
								if (!CalcTextDLogTitol.Equals("")) {
									ViewTitle = CalcTextDLogTitol;
								}
								dbMsg += "[" + CalcWindowWidth + " × " + CalcWindowHeight + "]";
								//				Point pt = targetTextBlock.PointToScreen(new Point(0.0d, 0.0d));
								Double ShowX = 0;
								Double ShowY = 0;
								dbMsg += ",指定座標(" + CalcTextShowX + "," + CalcTextShowY + ")";
								if (CalcTextShowX != "") {
									ShowX = Double.Parse(CalcTextShowX);
								}
								if (CalcTextShowY != "") {
									ShowY = Double.Parse(CalcTextShowY);
								}

								dbMsg += ">>(" + ShowX + "," + ShowY + ")";
								//電卓クラスを生成して書き込み先の参照を渡す
								CS_CalculatorControl calculatorControl = new CS_CalculatorControl();
								Window CalcWindow = new Window {                           //Windowを生成
									Title = ViewTitle,
									Width = CalcWindowWidth,
									Height = CalcWindowHeight,
									Left = ShowX,
									Top = ShowY,
									Content = calculatorControl,
									ResizeMode = ResizeMode.NoResize,
									Topmost = true
								};
								dbMsg += ">>(" + CalcWindow.Left + " , " + CalcWindow.Top + ")[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
								calculatorControl.CalcWindow = CalcWindow;              //dllからクローズなどのwindow制御を行う
								calculatorControl.InputStr = result.ToString();             //dllに元の書込み値を渡すv
																							//	calculatorControl.TargetGsCell = activeCell;書き戻すElementを指定すると
																							//	組込み先のライブラリバージョン不一致などで使えない
								Nullable<bool> dialogResult = CalcWindow.ShowDialog();          //ダイアログ表示
								dbMsg += ",dialogResult=" + dialogResult;       //falseが返される
								string resultStr = calculatorControl.ResultStr; //ダイアログを閉じるまでここには進まない
								dbMsg += ",戻り値=" + resultStr;
								if (resultStr != null) {
									activeCell.Value = double.Parse(resultStr);
								}
							} else
							{
								String titolStr = "XamDataGrid:" + DG.Name + "でコンテキストメニューで選択したアイテム";
								String msgStr = (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目（" + orgVal + "）は数値ではありません";
								msgStr += "\r\n電卓は数値を入力するセルでご利用ください";
								MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
							}
						}
						else
						{
							dbMsg += ",activeCell == null";
						}
						MyLog(TAG, dbMsg);
					}
					catch (Exception er)
					{
						MyErrorLog(TAG, dbMsg, er);
					}
				}
				#endregion
		*/

		#region DGContextMenuClick	　基底のDataGridのコンテキストメニューから電卓を呼び出す
		private ViewModelCommand _DGContextMenuClick;

		public ViewModelCommand DGContextMenuClick {
			get {
				if (_DGContextMenuClick == null) {
					_DGContextMenuClick = new ViewModelCommand(CalcDlog);
				}
				return _DGContextMenuClick;
			}
		}

		/// <summary>
		/// 基底DataGridのコンテキストメニューから電卓を呼び出す
		/// </summary>
		public void CalcDlog() {
			string TAG = "CalcDlog";
			string dbMsg = "";
			try {
				DataGrid DG = MyView.MyDG;
				DG.Focus();
				// 行番号(0起算)
				int rowIndex = DG.Items.IndexOf(DG.CurrentItem);
				// 列番号(0起算)
				int columnIndex = DG.CurrentCell.Column.DisplayIndex;
				dbMsg += "[" + rowIndex + " , " + columnIndex + "]";
				TextBlock targetTextBlock = (TextBlock)DG.Columns[columnIndex].GetCellContent(DG.SelectedItem);
				string orgVal = targetTextBlock.Text;
				dbMsg += orgVal;
				var result = 0;
				if (int.TryParse(orgVal, out result)) {
					dbMsg += "は数値で" + result;
					//電卓クラスを生成して書き込み先の参照を渡す
					CS_CalculatorControl calculatorControl = new CS_CalculatorControl();
					calculatorControl.TargetTextBlock = targetTextBlock;
					calculatorControl.InputStr = targetTextBlock.Text;
					dbMsg += ",CalcVer=" + CalcVer;
					calculatorControl.CalcVer = CalcVer;
					dbMsg += ",IsPO=" + IsPO;
					calculatorControl.IsPO = IsPO;
					//Windowを生成；タイトルの初期値は書き戻し先のフィールド名
					Window CalcWindow = new Window {
						Title = CalcTextDLogTitol,	//targetTextBlock.Name,
						Content = calculatorControl,
						ResizeMode = ResizeMode.NoResize
					};
					dbMsg += ",Title=" + CalcWindow.Title;
					Point pt = targetTextBlock.PointToScreen(new Point(0.0d, 0.0d));
					//表示位置
					Double ShowX = 0;
					if (CalcTextShowX != "") {
						ShowX = Double.Parse(CalcTextShowX);
					}
					Double ShowY = 0;
					if (CalcTextShowY != "") {
						ShowY = Double.Parse(CalcTextShowY);
					}
					dbMsg += ",指定座標[" + ShowX + "," + ShowY + "]";
					if (0 == ShowX) {
						//指定が無ければ書き込み先フィールドの左やや下に表示する
						CalcWindow.Left = pt.X + 20;
					} else {
						//指定された位置に表示
						CalcWindow.Left = ShowX;
					}
					if (0 == ShowY) {
						//指定が無ければ書き込み先フィールドの左やや下に表示する
						CalcWindow.Top = pt.Y + 30;
					} else {
						//指定された位置に表示
						CalcWindow.Top = ShowY;
					}
					dbMsg += ">>[" + ShowX + "," + ShowY + "]";
					CalcWindow.Topmost = true;
					dbMsg += "(" + CalcWindow.Left + " , " + CalcWindow.Top + ")";
					CalcWindow.Width = CalcWindowWidth;
					CalcWindow.Height = CalcWindowHeight;
					dbMsg += "[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
					string ViewTitle = "データグリッド" + DG.Name + "の" + (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目";

					dbMsg += ",ViewTitol=" + ViewTitle;
					if (!ViewTitle.Equals("")) {
#if DEBUG
						CalcWindow.Title = ViewTitle;
#endif
					}
					calculatorControl.CalcWindow = CalcWindow;
					calculatorControl.InputStr = result.ToString();

					//		calculatorControl.OperatKey = this.OperatKey;
					Nullable<bool> dialogResult = CalcWindow.ShowDialog();
					dbMsg += ",dialogResult=" + dialogResult;
					if(dialogResult != false){
						string resultStr = calculatorControl.ResultStr;
						dbMsg += ",resultStr=" + resultStr;
						targetTextBlock.Text= resultStr;
					}
				} else {
					String titolStr = "データグリッド" + DG.Name + "でコンテキストメニューで選択したアイテム";
					String msgStr = (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目（" + orgVal + "）は数値ではありません";
					msgStr += "\r\n電卓は数値を入力するセルでご利用ください";
					MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
#endregion

		////////////////////////////////////////////////////////////////
		public static void MyLog(string TAG, string dbMsg) {
#if DEBUG
			Console.WriteLine(TAG + "[CS_Calculator:CalcTestViewModel]" + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err) {
			Console.WriteLine(TAG + "[CS_Calculator:CalcTestViewModel]" + dbMsg + "でエラー発生;" + err);
		}


		public MessageBoxResult MessageShowWPF(String msgStr,
																				String titolStr = null,
																				MessageBoxButton buttns = MessageBoxButton.OK,
																				MessageBoxImage icon = MessageBoxImage.None
																				) {
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

	}
}
