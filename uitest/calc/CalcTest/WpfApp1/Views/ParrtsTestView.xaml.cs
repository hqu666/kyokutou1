﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using CS_Calculator;

namespace WpfApp1.Views {
	/// <summary>
	/// ParrtsTestView.xaml の相互作用ロジック
	/// </summary>
	public partial class ParrtsTestView : Window {

		public ViewModels.ParrtsTestViewModel VM;

		public ParrtsTestView()
		{
			InitializeComponent();
			//ViewとViewModelの紐付け
			VM = new ViewModels.ParrtsTestViewModel();
			this.DataContext = VM;
			this.Loaded += ThisLoaded;
		}
		private void ThisLoaded(object sender, RoutedEventArgs e)
		{
			//ViewModelのViewプロパティに自分のインスタンス（つまりViewのインスタンス）を渡しています。
			//VM.MyView = this;
			MyDG.ItemsSource = new ObservableCollection<Product> {
			new Product { Name="化粧品", Price=1900, Tax=10 },
			new Product { Name="洗剤", Price=500, Tax=10 },
			new Product { Name="パン", Price=800, Tax=8 },
			new Product { Name="牛乳", Price=800, Tax=8 }
		};
		}

		private void MyDGContextMenu_Click(object sender, RoutedEventArgs e) {
			string TAG = "MyDGContextMenu_Click";
			string dbMsg = "";
			try {
				DataGrid DG = MyDG;                      //(DataGrid)sender;
				DG.Focus();
				// 行番号(0起算)
				int rowIndex = DG.Items.IndexOf(DG.CurrentItem);
				// 列番号(0起算)
				int columnIndex = DG.CurrentCell.Column.DisplayIndex;
				dbMsg += "[" + rowIndex + " , " + columnIndex + "]";
				Product rec = (Product)DG.CurrentCell.Item;
				string orgVal = ((TextBlock)DG.Columns[columnIndex].GetCellContent(DG.SelectedItem)).Text;
				dbMsg += orgVal;
				var result = 0;
				if (int.TryParse(orgVal, out result)) {
					dbMsg += "は数値で" + result;
				} else {
					String titolStr = "データグリッド" + DG.Name + "でコンテキストメニューで選択したアイテム";
					String msgStr = (rowIndex+1) + "行目" + columnIndex + "列目（" + orgVal + "）は数値ではありません\r\n電卓は数値を入力するセルでご利用ください";
					MessageShowWPF( msgStr, titolStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
				}


				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}



		private void MyGSGridContextMenu_Click(object sender, System.EventArgs e) {
			MessageBox.Show("You chose color.");
		}

		/// <summary>
		/// このView上の表示調整
		/// サンプルなのでコードビハインドで対処
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcTextFontSize_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			Bt2Tbox.FontSize = int.Parse(TB.Text);
			CalcCallBt.MinWidth = int.Parse(CalcTextFontSize.Text) * 1.4;
		}

		private void CalcTexWidth_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			Bt2Tbox.Width = int.Parse(TB.Text);
		}

		private void CalcTextShow_TextChanged(object sender, TextChangedEventArgs e) {
			if (CalcTextShowX.Text.Equals("")) { return; }
			if (CalcTextShowY.Text.Equals("")) { return; }
			CalcCallBt.ShowX = double.Parse(CalcTextShowX.Text);
			CalcCallBt.ShowY = double.Parse(CalcTextShowY.Text);
		}

		private void CalcTextDLogTitol_TextChanged(object sender, TextChangedEventArgs e) {
			TextBox TB = sender as TextBox;
			CalcCallBt.ViewTitle = TB.Text;
		}

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

		private class Product {
			///<summary>
			///製品名
			///</summary>
			private string _Name;
			public string Name {
				get => _Name;
				set {
					if (_Name == value)
						return;
					_Name = value;
				}
			}
			private int _Price;
			public int Price {
				get => _Price;
				set {
					if (_Price == value)
						return;
					_Price = value;
				}
			}

			private int _Tax;
			public int Tax {
				get => _Tax;
				set {
					if (_Tax == value)
						return;
					_Tax = value;
				}
			}


		}
	}
}

