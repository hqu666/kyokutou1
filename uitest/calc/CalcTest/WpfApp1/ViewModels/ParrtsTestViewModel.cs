﻿using Livet;
using Livet.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Models;
using CS_Calculator;

namespace WpfApp1.ViewModels {
	public class ParrtsTestViewModel : ViewModel {
		public string titolStr = "カスタムパーツテスト";

		public Views.ParrtsTestView MyView { get; set; }
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

		


		/// <summary>
		/// ここからスタート
		/// </summary>
		public ParrtsTestViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			//パラメータの初期値
			CalcTextDLogTitol = "電卓を表示するフィールドから";
			CalcTexWidth = "200";
			CalcTextFontSize = "18";
			CalcTextShowX = "200";
			CalcTextShowY = "400";
			CalcResult = "0123456789";

			/// 基底DataGridに初期値を書き込むj
			DGDatas = new ObservableCollection<Product> {
				new Product { Name="化粧品", Price=1900, Tax=10 },
				new Product { Name="洗剤", Price=500, Tax=10 },
				new Product { Name="パン", Price=800, Tax=8 },
				new Product { Name="牛乳", Price=800, Tax=8 }
			};

			RaisePropertyChanged();
		}

		#region DGContextMenuClick	　基底DataGridのコンテキストメニューから電卓を呼び出す
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
					CalcWindow.Width = 300;
					CalcWindow.Height = 400;
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
