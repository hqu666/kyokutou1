using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Reflection;
//using Windows.UI.ViewManagement;
//using Windows.ApplicationModel.Core;
//IValueConverter 
using System.Globalization;
using System.Windows.Data;
using System.Linq;
//DynamicObject
using System.ComponentModel;
using System.Dynamic;

//IEnumerable
using System.Collections;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using TabCon.Views;
using System.Windows.Input;
using TabCon.Infrastructures;

namespace TabCon.ViewModels{
	public class MySQLBaseViewModel : ViewModel {
		public Views.MySQLBase MyView { get; set; }

		public string server { get; set; }
		public string database { get; set; }
		public string port { get; set; }
		public string uid { get; set; }
		public string password { get; set; }

		/// <summary>
		/// テーブル選択コンボボックス
		/// </summary>
		public System.Windows.Visibility TableComboVisibility { get; set; }
		public System.Windows.Visibility disConectBtVisibility { get; set; }
		public System.Windows.Visibility conectBtVisibility { get; set; }
		
		public Views.MainWindow MW { get; set; }
		public ViewTabControl TC { get; set; }

		/// <summary>
		/// 接続情報
		/// </summary>
		public MySqlConnection Connection = null;
		/// <summary>
		/// 選択されたテーブル名
		/// </summary>
		public string selectedTableName;
		/// <summary>
		/// 選択しているテーブルのモデル
		/// </summary>
		public Object wModel;
		/// <summary>
		/// モデルの再生用
		/// </summary>
		public Type modelType;
		/// <summary>
		/// "GoogleOSD.Models."を含むモデル名
		/// </summary>
		public string modelName;
		/// <summary>
		/// DataGridのソース
		/// </summary>
		public List<object> wCollection;
		/// <summary>
		/// 対象テーブルの列数
		/// </summary>
		public int FieldCount;
		public string titolStr = "MySQL";


		public MySQLBaseViewModel()
		{
			//TableComboVisibility = System.Windows.Visibility.Hidden;
			//disConectBtVisibility = System.Windows.Visibility.Hidden;
			//conectBtVisibility = System.Windows.Visibility.Visible;
			//// コンテンツに合わせて自動的にWindow幅と高さをリサイズする(Windowプロパティ)
			//MyView.SizeToContent = SizeToContent.WidthAndHeight;
			server = Constant.Server;
			database = Constant.Database;
			port = Constant.Port.ToString();
			uid = Constant.Uid;
			password = Constant.Pwd;
	}

		public ViewModelCommand ConectClicked {
			get { return new Livet.Commands.ViewModelCommand(MySqlConnection); }
		}

		/// <summary>
		///データベースに接続
		///OpeningFileSelectionMessage m
		/// </summary>
		public void MySqlConnection()
		{
			string TAG = "SqlConnect";
			string dbMsg = "GetAllTable";
			try {
				// MySQLへの接続情報
				Constant.ConnectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}",
					MyView.server_lb.Text, MyView.database_lb.Text, MyView.uid_lb.Text, MyView.password_lb.Text);
				// MySQLへの接続
				try {
					MyView.connectionString_lb.Content = Constant.ConnectionString;

					Connection = new MySqlConnection(Constant.ConnectionString);
					Connection.Open();
					string msgStr = "MySQLに接続しました\r\n";
					msgStr = "MySQLに接続しました\r\n";
					dbMsg += ",msgStr=" + msgStr;
					GetAllTable();
					TableComboVisibility = System.Windows.Visibility.Visible;
					disConectBtVisibility = System.Windows.Visibility.Visible;
			//		conectBtVisibility = System.Windows.Visibility.Hidden;
				} catch (MySqlException me) {
					string titolStr = TAG;
					string msgStr = "XAMPPもしくはMySQLデータベースの起動確認を";
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					MyErrorLog(TAG, dbMsg, me);
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public ViewModelCommand DisConectClicked {
			get { return new Livet.Commands.ViewModelCommand(DisConnect); }
		}

		/// <summary>
		/// データベース接続解除
		/// </summary>
		public void DisConnect()
		{
			string TAG = "DisConnect";
			string dbMsg = "[MySQLBase]";
			try {
				try {
					Connection.Close();
					string msgStr = "MySQLの接続を解除しました";
					dbMsg += ",msgStr=" + msgStr;
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += "接続の解除";
					//TableComboVisibility = System.Windows.Visibility.Hidden;
					//disConectBtVisibility = System.Windows.Visibility.Hidden;
					//conectBtVisibility = System.Windows.Visibility.Visible;
					MyView.table_dg.DataContext = null;
					MyView.table_dg.Items.Refresh();
					MyView.connectionString_lb.Content = "";

					//// コンテンツに合わせて自動的にWindow幅と高さをリサイズする
					//this.SizeToContent = SizeToContent.WidthAndHeight;
				} catch (MySqlException me) {
					MyErrorLog(TAG, dbMsg, me);
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// DataGirdでレコードが選択された
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Table_dg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
		{
			string TAG = "Table_dg_SelectedCellsChanged";
			string dbMsg = "[MySQLBase]";
			try {
				var rowIndex = MyView.table_dg.Items.IndexOf(MyView.table_dg.CurrentItem);
				dbMsg += rowIndex + "/" + wCollection.Count + "レコード目";
				DefoltValueCheck(rowIndex);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 一行分の編集修正
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Table_dg_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
		{
			string TAG = "Table_dg_RowEditEnding";
			string dbMsg = "[MySQLBase]";
			try {
				var rowIndex = MyView.table_dg.Items.IndexOf(MyView.table_dg.CurrentItem);
				dbMsg += rowIndex + "/" + wCollection.Count + "レコード目";
				string Msg = dbMsg;
				MessageBoxResult result = MessageShowWPF(titolStr, Msg, MessageBoxButton.OKCancel, MessageBoxImage.Information);
				dbMsg += ",result=" + result;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 登録ボタンのクリック
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Save_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Save_bt_Click";
			string dbMsg = "[MySQLBase]";
			try {
				// 行番号(0起算)
				var rowIndex = MyView.table_dg.Items.IndexOf(MyView.table_dg.CurrentItem);
				dbMsg += "[R" + rowIndex;
				// 列番号(0起算)
				//var columnIndex = table_dg.CurrentCell.Column.DisplayIndex;
				//dbMsg +=  "C" + columnIndex + "]";
				if (MyView.table_dg.SelectedItem != null) {
					// 列番号(0起算)
					var columnIndex = MyView.table_dg.SelectedIndex;
					dbMsg += "C" + columnIndex + "]";
					MessageBox.Show(MyView.table_dg.Columns[columnIndex].Header.ToString() + ": " +
					((TextBlock)MyView.table_dg.Columns[columnIndex].GetCellContent(MyView.table_dg.SelectedItem)).Text + "を選択");
				} else {
					MessageBox.Show("値を入力して下さい");
				}
				dbMsg += ":id," + ((TextBlock)MyView.table_dg.Columns[0].GetCellContent(MyView.table_dg.Columns[0])).Text;
				dbMsg += ":作成日時," + ((TextBlock)MyView.table_dg.Columns[0].GetCellContent(MyView.table_dg.Columns[FieldCount - 4])).Text;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//MySQL//////////////////////////////////////////////////

		/// <summary>
		/// 初期値修正：DateTimeの1/1/0001などの修正
		/// </summary>
		private void DefoltValueCheck(int rowIndex)
		{
			string TAG = "DefoltValueCheck";
			string dbMsg = "[MySQLBase]";
			try {
				//Type TypeDateTime = typeof(System.DateTime);
				//Type TypeInt32 = typeof(System.Int32);
				// 行番号(0起算)
				if (-1 < rowIndex) {
					dbMsg += "[R" + rowIndex;
					int ItemCount = MyView.table_dg.Columns.Count;
					dbMsg += "×C" + ItemCount + "]";
					wModel = (Object)Activator.CreateInstance(modelType);
					if (wCollection.Count < rowIndex) {
						wModel = wCollection[rowIndex];
					}
					for (int i = 0; i < ItemCount; i++) {
						dbMsg += "\r\n[" + i + "/" + ItemCount + "]";
						//// DataGridにフォーカスし, 指定行、列のDataGridCellInfoを生成
						DataGridCellInfo cellInfo = new DataGridCellInfo(MyView.table_dg.Items[rowIndex], MyView.table_dg.Columns[i]);
						if (cellInfo == null) {
						} else {
							string fealdName = MyView.table_dg.Columns[i].Header.ToString();
							dbMsg += fealdName;
							MyView.table_dg.CurrentCell = cellInfo;
							string cVar = ((TextBlock)MyView.table_dg.Columns[i].GetCellContent(MyView.table_dg.SelectedItem)).Text;
							dbMsg += "=" + cVar;
							string cType = null;
							foreach (var rFeild in wModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
								if (rFeild.Name.Equals(fealdName)) {
									cType = rFeild.PropertyType.Name;
									goto ExitTypeForeach;
								}
							}
						ExitTypeForeach:
							dbMsg += "(" + cType + ")";
							if (fealdName.Equals("deleted_at") || cVar.Contains("1/1/0001") || cVar.Contains("0001/1/1")) {
								//Nullにしなければならない場合
								cVar = "";
							}
							if (cVar.Equals("") || cVar.Equals(null)) {
								dbMsg += "未設定";
								if (cType.Equals("DateTime")) {           //TypeDateTime
									string wVar = System.DateTime.Now.ToString();
									if (fealdName.Equals("created_at") || fealdName.Equals("updated_at")) {
										((TextBlock)MyView.table_dg.Columns[i].GetCellContent(MyView.table_dg.SelectedItem)).Text = wVar;
									} else {
										((TextBlock)MyView.table_dg.Columns[i].GetCellContent(MyView.table_dg.SelectedItem)).Text = "";
									}
								} else if (cType.Equals("int32")) {        //TypeInt32
									((TextBlock)MyView.table_dg.Columns[i].GetCellContent(MyView.table_dg.SelectedItem)).Text = "";
								}
								//			}else if (cVar.Equals("")) {
							}
						}
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

//	public Dictionary<string, string> TableCombo { get; set; }
		#region SQLTablesViewModel変更通知プロパティ
		private ObservableCollection<SQLTablesViewModel> _TableCombo;
		public ObservableCollection<SQLTablesViewModel> TableCombo {
			get { return _TableCombo; }
			set {
				if (_TableCombo == value)
					return;
				_TableCombo = value;
				RaisePropertyChanged();
			}
		}
		#endregion

		/// <summary>
		/// 接続したデータベースの全テーブルデータ取得し、テーブル選択コンボボックスを形成
		/// </summary>
		public void GetAllTable()
		{
			string TAG = "GetAllTable";
			string dbMsg = "[MySQLBase]";
			try {
				// テーブル一覧取得SQL
				string TableListSql = $"SHOW TABLES FROM {Constant.Database}";
				// コネクションオブジェクトとコマンドオブジェクトを生成します。
				//	using (var connection = new MySqlConnection(Constant.ConnectionString))
				using (var command = new MySqlCommand()) {
					// コネクションをオープンします。
					//		connection.Open();

					// テーブル一覧取得SQLを実行します。
					command.Connection = Connection;
					command.CommandText = TableListSql;
					var reader = command.ExecuteReader();
					// データがある場合
					if (reader.HasRows) {
						dbMsg += ",reader=" + reader.RecordsAffected + "テーブル ";
						//Binding出来ない場合は書込み配列に築盛
						//		TableCombo = new Dictionary<string, string>();
						TableCombo = new ObservableCollection<SQLTablesViewModel>();
						// データがある間繰り返します。
						while (reader.Read()) {
							SQLTablesViewModel SQLT = new SQLTablesViewModel();
							// 取得したテーブル名を表示します。
							SQLT.key = reader.GetString(0);
							SQLT.name = reader.GetString(0);
							dbMsg += "," + SQLT.key + " : " + SQLT.name;
							TableCombo.Add(SQLT);
							//Binding出来ない場合
							//		TableCombo.Add(SQLT.key, SQLT.name);
						}
						dbMsg += ",取得結果：" + TableCombo.Count + "テーブル ";
						RaisePropertyChanged();
						//Binding出来ない場合はViewへの参照で書き込む
						//		MyView.table_combo.ItemsSource = TableCombo;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// テーブル選択
		/// </summary>
		#region TCSelectedValueChanged
		private string _TCSelectedValue;
		public string TCSelectedValue {
			get {
				return _TCSelectedValue;
			}
			set {
				if (value == _TCSelectedValue)
					return;

				_TCSelectedValue = value;
				RaisePropertyChanged();
				if(value != null) {
					ReadTable(value);
				}
			}
		}
		#endregion

		/// <summary>
		/// 指定されたテーブルの読出し
		/// </summary>
		/// <param name="tableName"></param>
		public void ReadTable(string tableName)
		{
			string TAG = "ReadTable";
			string dbMsg = "[MySQLBase]";
			try {
				dbMsg += ",tableName=" + tableName;

				if (Connection.State != ConnectionState.Open) {
					dbMsg += ",Openしてない";
					Connection.Open();
				}
				MyView.table_dg.DataContext = null;
				MyView.table_dg.Items.Refresh();


				Type myType = typeof(MySQLBase);
				string Namespace = myType.Namespace;
				string[] rStrs = Namespace.Split('.');
				//		TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
				Namespace = rStrs[0];
				string modelName = Namespace + ".Models."+ tableName;                 // "GoogleOSD.Models."
				//for (int i = 1; i < rStrs.Length; i++) {
				//	string rStr = ti.ToTitleCase(rStrs[i]);
				//	modelName += rStr;
				//}
				dbMsg += ",modelName=" + modelName;
				modelType = Type.GetType(modelName);
				dbMsg += ",type=" + modelType.FullName;
				wModel = (Object)Activator.CreateInstance(modelType);
				//ObservableCollectionを変数化するとAddが使えない
				wCollection = new List<object>();
				//ヘッダー作成：型の確定;	列定義を書き換え
				MyView.table_dg.Columns.Clear();       //全列削除
				var viewModel = this;
				// リソースからスタイルを取得
				//var headerStyle = (Style)table_dg.FindResource("HeaderStyle");
				//var textStyle = (Style)table_dg.FindResource("TextStyle");
				foreach (var rFeild in wModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
					string rName = rFeild.Name;
					string rType = rFeild.PropertyType.Name;
					dbMsg += "\r\nrName=" + rName + ",rType=" + rType;
					if (rType.Equals("Boolean")) {
						MyView.table_dg.Columns.Add(new DataGridCheckBoxColumn() {
							Header = rName,
							Binding = new Binding(rName)
						});
					} else if (rType.Equals("DateTime")) {

						//table_dg.Columns.Add(new DataGridTextColumn() {
						//	Header = rName,
						//	Binding = new Binding(rName) { StringFormat = "yyyy/MM/dd hh:mm" }
						//});
						DataGridTemplateColumn templateColumn = new DataGridTemplateColumn();
						templateColumn.Header = rName;

						Binding bnding = new Binding(rName);
						//表示をラベルに
						FrameworkElementFactory DateLabel = new FrameworkElementFactory(typeof(DateLabel));
						DateLabel.SetBinding(Label.ContentProperty, new Binding(rName));
						//DateLabel.SetBinding(TextBlock.TextProperty, new Binding(rName));
						templateColumn.CellTemplate = new DataTemplate { VisualTree = DateLabel };

						//入力をDatePickerに
						FrameworkElementFactory cTextBox = new FrameworkElementFactory(typeof(CustomDatePicker));
		//				SetBinding(DatePicker.SelectedDateProperty, bnding);
						templateColumn.CellEditingTemplate = new DataTemplate { VisualTree = cTextBox };

						MyView.table_dg.Columns.Add(templateColumn);

					} else {
						MyView.table_dg.Columns.Add(new DataGridTextColumn() {
							Header = rName,
							//HeaderStyle = headerStyle,
							//ElementStyle = textStyle,		DataGridTemplateColumn
							//IsReadOnly = true,				TargetType
							//CanUserSort = true,
							Binding = new Binding(rName)
						});
					}
				}

				using (MySqlConnection mySqlConnection = new MySqlConnection(Constant.ConnectionString)) {
					mySqlConnection.Open();
					using (MySqlCommand command = mySqlConnection.CreateCommand()) {
						command.CommandText = $"SELECT * FROM {tableName}";
						using (MySqlDataReader reader = command.ExecuteReader()) {
							FieldCount = reader.FieldCount;
							dbMsg += "," + FieldCount + "項目";

							//一行づつデータを読み取りモデルに書込む
							while (reader.Read()) {
								wModel = (Object)Activator.CreateInstance(modelType);
								for (int i = 0; i < FieldCount; i++) {
									string rName = reader.GetName(i);
									string rType = reader.GetFieldType(i).Name;
									dbMsg += "\r\nrName=" + rName + ",rType=" + rType;
									var rVar = reader.GetValue(i);
									dbMsg += ",rVar=" + rVar;

									if (reader.IsDBNull(i) || rVar.Equals("")) {
										dbMsg += "null";
									} else {
										foreach (var rFeild in wModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
											if (rFeild.Name.Equals(rName)) {
												if (rFeild.Name.Equals("deleted_at")) {
													rFeild.SetValue(wModel, null);
												} else if (rType.Equals("Int32")) {
													rFeild.SetValue(wModel, reader.GetInt32(i));
												} else if (rType.Equals("String")) {
													rFeild.SetValue(wModel, reader.GetString(i));
												} else if (rType.Equals("DateTime")) {
													rFeild.SetValue(wModel, reader.GetDateTime(i));
												} else if (rType.Equals("Boolean")) {                       //tinyInt(1)
													rFeild.SetValue(wModel, reader.GetBoolean(i));
												} else if (rType.Equals("SByte")) {
													rFeild.SetValue(wModel, reader.GetSByte(i));
												} else if (rType.Equals("MySqlDecimal")) {
													rFeild.SetValue(wModel, reader.GetMySqlDecimal(i));
													//} else {
													//	dbMsg += ",該当型無し" ;
													//	rFeild.SetValue(wModel, reader.GetValue(i));
												}
											}
										}
									}
								}
								wCollection.Add(wModel);
							}
						}
					}
				}
				int rCount = wCollection.Count;
				dbMsg += ",wCollection=" + rCount + "件";
				if (rCount < 1) {
					dbMsg += ",データ入力無し";        //ObservableCollectionから該当モデルのフィールドのみを引き当てる
					Type CollectionType = Type.GetType(modelName + "Collection");
					Object bCollection = (Object)Activator.CreateInstance(CollectionType);
					//			dbMsg += ",wCollection=" + bCollection.FullName;
					MyView.table_dg.DataContext = bCollection;
				} else {
					// データをそのままセットする
					MyView.table_dg.DataContext = wCollection;
					//for(int i=0;i< rCount;i++) {
					//	// DataGridにフォーカスします。
					//	table_dg.Focus();
					//	// 指定行、列のDataGridCellInfoを生成します。
					//	DataGridCellInfo cellInfo = new DataGridCellInfo(table_dg.Items[i], table_dg.Columns[0]);
					//	// DataGridのCurrentCellに生成したDataGridCellInfoを設定します。
					//	table_dg.CurrentCell = cellInfo;
					//	DefoltValueCheck(i);
					//}
				}
				//更新時はこれが必須
				MyView.table_dg.Items.Refresh();
				Connection.Close();
				//// コンテンツに合わせて自動的にWindow幅と高さをリサイズする
				//SizeToContent = SizeToContent.WidthAndHeight;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// DataGrid内で日付を表示
		/// フォーマットでカスタム定義
		/// </summary>
		internal class DateLabel : Label {
			public DateLabel()
			{
				ContentStringFormat = "yyyy/MM/dd hh:mm";
				//TargetNullValue = '';
				//FallbackValue = '';
			}
			//	public DateLabel() : base() => ContentStringFormat = "yyyy/MM/dd hh:mm" ,TargetNullValue='()', FallbackValue='()'};
		}

		/// <summary>
		/// DataGrid内で日付を入力
		/// </summary>
		internal class CustomDatePicker : DatePicker {
			public CustomDatePicker() { }
			//: base()
			//{
			//	SelectedDateFormat = "Short";
			//}
		}

		//internal class CustomTextBox : TextBox {
		//	public CustomTextBox() : base() => Background = Brushes.LightSkyBlue;
		//}

		/// <summary>
		/// 選択されたテーブルの全レコード書き出し
		/// </summary>
		public void WriteOneRecord()
		{
			string TAG = "WriteOneRecord";
			string dbMsg = "[MySQLBase]";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public static PropertyInfo GetPropertyInfo(Type type, string name)
		{
			var property = type.GetProperty(name);
			return property;
		}

		//////////////////////////////////////////////////MySQL//
		public static void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		{
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		)
		{
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}

	}

}
/*
 C#からMySQLに接続する		https://dianxnao.com/c%E3%81%8B%E3%82%89mysql%E3%81%AB%E6%8E%A5%E7%B6%9A%E3%81%99%E3%82%8B/

 */
