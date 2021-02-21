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
		/// 表示位置
		/// </summary>
		public string CalcTextShowX { get; set; }
		public string CalcTextShowY { get; set; }

		public double CalcWindowWidth = 180;
		public double CalcWindowHeight = 250;


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
			//パラメータの初期値
			CalcTextDLogTitol = "電卓を表示するフィールドから";
			CalcTexWidth = "200";
			CalcTextFontSize = "18";
			CalcTextShowX = "1200";
			CalcTextShowY = "400";
			CalcWindowWidth = 180;
			CalcWindowHeight = 250;
			CalcResult = "0123456789";

			GsGlist = new List<Product>();
			GsGlist.Add(new Product() { Name ="みるきーくいん", Price = 2080, Tax = 8});
			GsGlist.Add(new Product() { Name = "徳陽ほうじ茶", Price = 298, Tax =10 });
			GsGlist.Add(new Product() { Name = "バスサイズ石鹸", Price =140, Tax =10});
			GsGlist.Add(new Product() { Name = "５袋ラーメン", Price = 298, Tax = 8});

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
				new Product { Name="LEDシーリング", Price=4980, Tax=10 },
				new Product { Name="歯磨き粉", Price=298, Tax=10 },
				new Product { Name="おにぎり", Price=124, Tax=8 },
				new Product { Name="緑茶", Price=800, Tax=8 }
			};

			/// 基底DataGridに初期値を書き込むj
			DGDatas = new ObservableCollection<Product> {
				new Product { Name="化粧品", Price=1900, Tax=10 },
				new Product { Name="洗剤", Price=500, Tax=10 },
				new Product { Name="パン", Price=800, Tax=8 },
				new Product { Name="牛乳", Price=800, Tax=8 }
			};
			RaisePropertyChanged();
		}

		#region MyGsGridContextMenuClick	　GcSpreadGridのコンテキストメニューから電卓を呼び出す
		private ViewModelCommand _MyGsGridContextMenuClick;

		public ViewModelCommand MyGsGridContextMenuClick {
			get {
				if (_MyGsGridContextMenuClick == null)
				{
					_MyGsGridContextMenuClick = new ViewModelCommand(CalcDlogGsG);
				}
				return _MyGsGridContextMenuClick;
			}
		}
		/// <summary>
		/// GcSpreadGridのコンテキストメニューから電卓を呼び出す
		/// </summary>
		public void CalcDlogGsG()
		{
			string TAG = "CalcDlogGsG";
			string dbMsg = "";
			try{
				GcSpreadGrid DG = MyView.MyGsGrid;
				DG.Focus();
				GsSGCell activeCell = DG.ActiveCell;
				if (activeCell != null){
					// 行番号(0起算)
					int rowIndex = activeCell.Position.Row;
					// 列番号(0起算)
					int columnIndex = activeCell.Position.Column;
					dbMsg += "[" + rowIndex + " , " + columnIndex + "]";
					string orgVal = activeCell.Value.ToString();
					dbMsg += orgVal;
					var result = 0;
					if (int.TryParse(orgVal, out result)){
						dbMsg += "は数値で" + result;
						//タイトルの初期値は書き戻し先のフィールド名
						string ViewTitle = "データグリッド" + DG.Name + "の" + (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目";
						 if(!CalcTextDLogTitol.Equals(""))	{
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
							Topmost=true
						};
						dbMsg += ">>(" + CalcWindow.Left + " , " + CalcWindow.Top + ")[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
						calculatorControl.CalcWindow = CalcWindow;				//dllからクローズなどのwindow制御を行う
						calculatorControl.InputStr = result.ToString();             //dllに元の書込み値を渡すv
						//	calculatorControl.TargetGsCell = activeCell;書き戻すElementを指定すると
						//	組込み先のライブラリバージョン不一致などで使えない
						Nullable<bool> dialogResult = CalcWindow.ShowDialog();			//ダイアログ表示
						dbMsg += ",dialogResult=" + dialogResult;       //falseが返される
						string resultStr = calculatorControl.ResultStr;	//ダイアログを閉じるまでここには進まない
						dbMsg += ",戻り値=" + resultStr;
						if(resultStr != null){
							activeCell.Value = double.Parse(resultStr);
						}
					}else{
						String titolStr = "XamDataGrid:" + DG.Name + "でコンテキストメニューで選択したアイテム";
						String msgStr = (rowIndex + 1) + "行目" + (columnIndex + 1) + "列目（" + orgVal + "）は数値ではありません";
						msgStr += "\r\n電卓は数値を入力するセルでご利用ください";
						MessageShowWPF(msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					}
				}else{
					dbMsg += ",activeCell == null";
				}
				MyLog(TAG, dbMsg);
			}
			catch (Exception er){
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		#endregion

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
						////電卓クラスを生成して書き込み先の参照を渡す
						//CS_CalculatorControl calculatorControl = new CS_CalculatorControl();
						//calculatorControl.TargetCell = activeCell;

						////Windowを生成；タイトルの初期値は書き戻し先のフィールド名
						//Window CalcWindow = new Window
						//{
						//	//				Title = targetTextBlock.Name,
						//	Content = calculatorControl,
						//	ResizeMode = ResizeMode.NoResize
						//};
						////				Point pt = targetTextBlock.PointToScreen(new Point(0.0d, 0.0d));
						////表示位置
						//Double ShowX = 0;
						//if (CalcTextShowX != "")
						//{
						//	ShowX = Double.Parse(CalcTextShowX);
						//}
						//Double ShowY = 0;
						//if (CalcTextShowY != "")
						//{
						//	ShowY = Double.Parse(CalcTextShowY);
						//}
						//dbMsg += ",指定座標[" + ShowX + "," + ShowY + "]";
						//if (0 == ShowX)
						//{
						//	//指定が無ければ書き込み先フィールドの左やや下に表示する
						//	//					CalcWindow.Left = pt.X + 20;
						//}
						//else
						//{
						//	//指定された位置に表示
						//	CalcWindow.Left = ShowX;
						//}
						//if (0 == ShowY)
						//{
						//	//指定が無ければ書き込み先フィールドの左やや下に表示する
						//	//					CalcWindow.Top = pt.Y + 30;
						//}
						//else
						//{
						//	//指定された位置に表示
						//	CalcWindow.Top = ShowY;
						//}
						//dbMsg += ">>[" + ShowX + "," + ShowY + "]";
						//CalcWindow.Topmost = true;
						//dbMsg += "(" + CalcWindow.Left + " , " + CalcWindow.Top + ")";
						//CalcWindow.Width = 300;
						//CalcWindow.Height = 400;
						//dbMsg += "[" + CalcWindow.Width + " × " + CalcWindow.Height + "]";
						//string ViewTitle = DG.Name + "[" + (rowIndex + 1) + "," + (columnIndex + 1) + "]";
						////			ViewTitle += activeCell.Record;
						//ViewTitle += ":" + activeCell.Field.Label;
						//dbMsg += ",ViewTitol=" + ViewTitle;

						//if (!ViewTitle.Equals(""))
						//{
						//	CalcWindow.Title = ViewTitle;
						//}
						//calculatorControl.CalcWindow = CalcWindow;
						//calculatorControl.InputStr = result.ToString();

						////		calculatorControl.OperatKey = this.OperatKey;
						//Nullable<bool> dialogResult = CalcWindow.ShowDialog();
						//dbMsg += ",dialogResult=" + dialogResult;

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


		#region DGContextMenuClick	　規定DataGridのコンテキストメニューから電卓を呼び出す
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

					//Windowを生成；タイトルの初期値は書き戻し先のフィールド名
					Window CalcWindow = new Window {
						Title = targetTextBlock.Name,
						Content = calculatorControl,
						ResizeMode = ResizeMode.NoResize
					};
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
						CalcWindow.Title = ViewTitle;
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
			Console.WriteLine(TAG + "[CS_Calculator:CalculatorButtun]" + dbMsg);
#endif
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err) {
			Console.WriteLine(TAG + "[CS_Calculator:CalculatorButtun]" + dbMsg + "でエラー発生;" + err);
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
