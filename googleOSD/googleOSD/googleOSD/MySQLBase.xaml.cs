using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Globalization;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using System.Windows.Data;
using System.Collections;

namespace GoogleOSD {
	/// <summary>
	/// MySQLBase.xaml の相互作用ロジック
	/// </summary>
	public partial class MySQLBase : Window {

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

		public Dictionary<string, string> TableCombo { get; set; }

		public MySQLBase()
		{
			InitializeComponent();
			DataContext = this;

			table_combo.Visibility = System.Windows.Visibility.Hidden;
			dis_conect_bt.Visibility = System.Windows.Visibility.Hidden;
			conect_bt.Visibility = System.Windows.Visibility.Visible;
			// コンテンツに合わせて自動的にWindow幅と高さをリサイズする
			this.SizeToContent = SizeToContent.WidthAndHeight;
			server_lb.Text = Constant.Server;
			database_lb.Text = Constant.Database;
			port_lb.Text = Constant.Port.ToString();
			uid_lb.Text = Constant.Uid;
			password_lb.Text = Constant.Pwd;

		}

		/// <summary>
		///データベースに接続
		/// </summary>
		/// <param name="args"></param>
		public void SqlConnect(string[] args)
		{
			string TAG = "SqlConnect";
			string dbMsg = "GetAllTable";
			try {
				// MySQLへの接続情報
				Constant.ConnectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", server_lb.Text, database_lb.Text, uid_lb.Text, password_lb.Text);
				// MySQLへの接続
				try {
					//server_lb.Text = Constant.Server;
					//database_lb.Text = Constant.Database;
					//port_lb.Text = Constant.Port.ToString();
					//uid_lb.Text = Constant.Uid;
					//password_lb.Text = Constant.Pwd;
					connectionString_lb.Content = Constant.ConnectionString;

					Connection = new MySqlConnection(Constant.ConnectionString);
					Connection.Open();
					string msgStr = "MySQLに接続しました\r\n";
					msgStr = "MySQLに接続しました\r\n";
					dbMsg += ",msgStr=" + msgStr;
					table_combo.Visibility = System.Windows.Visibility.Visible;
					dis_conect_bt.Visibility = System.Windows.Visibility.Visible;
					conect_bt.Visibility = System.Windows.Visibility.Hidden;
					GetAllTable();
				//	MakeTable();
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
							table_combo.Visibility = System.Windows.Visibility.Hidden;
							dis_conect_bt.Visibility = System.Windows.Visibility.Hidden;
							conect_bt.Visibility = System.Windows.Visibility.Visible;
							this.table_dg.DataContext = null;
							this.table_dg.Items.Refresh();
							connectionString_lb.Content ="";

					// コンテンツに合わせて自動的にWindow幅と高さをリサイズする
					this.SizeToContent = SizeToContent.WidthAndHeight;
						} catch (MySqlException me) {
							MyErrorLog(TAG, dbMsg, me);
						}
						MyLog(TAG, dbMsg);
					} catch (Exception er) {
						MyErrorLog(TAG, dbMsg, er);
					}
				}

		private void Dis_conect_bt_Click(object sender, RoutedEventArgs e)
		{
			DisConnect();
		}

		private void Conect_bt_Click(object sender, RoutedEventArgs e)
		{
			string[] args = null;


			SqlConnect(args);
		}
	
		/// <summary>
		/// テーブル選択
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Table_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string TAG = "Table_combo_SelectionChanged";
			string dbMsg = "[MySQLBase]";
			try {
				ComboBox combo = sender as ComboBox;
				int selectedIndex = combo.SelectedIndex;
				dbMsg += "[" + selectedIndex + "]";
				string selectedTableName = combo.SelectedValue.ToString();
				dbMsg += selectedTableName;
				MyLog(TAG, dbMsg);
				ReadTable(selectedTableName);
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
				var rowIndex = table_dg.Items.IndexOf(table_dg.CurrentItem);
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
				var rowIndex = table_dg.Items.IndexOf(table_dg.CurrentItem);
				dbMsg += rowIndex+ "/"+ wCollection.Count+ "レコード目";
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
				var rowIndex = table_dg.Items.IndexOf(table_dg.CurrentItem);
				dbMsg += "[R" + rowIndex ;
				// 列番号(0起算)
				//var columnIndex = table_dg.CurrentCell.Column.DisplayIndex;
				//dbMsg +=  "C" + columnIndex + "]";
				if(table_dg.SelectedItem != null){
					// 列番号(0起算)
					var columnIndex = table_dg.SelectedIndex;
					dbMsg += "C" + columnIndex + "]";
					MessageBox.Show(table_dg.Columns[columnIndex].Header.ToString() + ": " +
					((TextBlock)table_dg.Columns[columnIndex].GetCellContent(table_dg.SelectedItem)).Text + "を選択") ; 
				}else{
					MessageBox.Show("値を入力して下さい");
				}
				dbMsg += ":id," + ((TextBlock)table_dg.Columns[0].GetCellContent(table_dg.Columns[0])).Text;
				dbMsg += ":作成日時," + ((TextBlock)table_dg.Columns[0].GetCellContent(table_dg.Columns[FieldCount-4])).Text;
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
					int ItemCount = table_dg.Columns.Count;
					dbMsg += "×C" + ItemCount + "]";
					wModel = (Object)Activator.CreateInstance(modelType);
					if (wCollection.Count < rowIndex) {
						wModel = wCollection[rowIndex];
					}
					for (int i = 0; i < ItemCount; i++) {
						dbMsg += "\r\n[" + i + "/" + ItemCount + "]";
						//// DataGridにフォーカスし, 指定行、列のDataGridCellInfoを生成
						DataGridCellInfo cellInfo = new DataGridCellInfo(table_dg.Items[rowIndex], table_dg.Columns[i]);
						if (cellInfo == null) {
						}else{
							string fealdName = table_dg.Columns[i].Header.ToString();
							dbMsg += fealdName;
							table_dg.CurrentCell = cellInfo;
							string cVar = ((TextBlock)table_dg.Columns[i].GetCellContent(table_dg.SelectedItem)).Text;
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
										((TextBlock)table_dg.Columns[i].GetCellContent(table_dg.SelectedItem)).Text = wVar;
									} else {
										((TextBlock)table_dg.Columns[i].GetCellContent(table_dg.SelectedItem)).Text = "";
									}
								} else if (cType.Equals("int32")) {        //TypeInt32
									((TextBlock)table_dg.Columns[i].GetCellContent(table_dg.SelectedItem)).Text = "";
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
						TableCombo = new Dictionary<string, string>();
						// データがある間繰り返します。
						while (reader.Read()) {
							// 取得したテーブル名を表示します。
							string key = reader.GetString(0);                   //テーブル名（日）に記載した　日本語の名称は?
							string name = reader.GetString(0);
							dbMsg += "," + key + " : " + name;
							TableCombo.Add(key, name);
						}
						dbMsg += ",取得結果：" + TableCombo.Count + "テーブル ";
						table_combo.ItemsSource = TableCombo;
					}
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

//		public void MakeTable()
//		{
//			string TAG = "MakeTable";
//			string dbMsg = "[MySQLBase]";
//			try {
//				// コネクションオブジェクトとコマンドオブジェクトを生成します。
//				//using (var connection = new MySqlConnection(ConnectionString))
//				using (var command = new MySqlCommand()) {
//					// コネクションをオープンします。
//					//Connection.Open();

//					// テーブル作成SQLを実行します。
//					command.Connection = Connection;
////案件基本
//					string CreateTableSql = "CREATE TABLE IF NOT EXISTS t_project_bases (id INT,";       //     IDENTITY (1, 1) NOT NULL,	PRIMARY KEY CLUSTERED ([Id] ASC)
//					CreateTableSql += " m_contract_id INT,";            //契約ID
//					CreateTableSql += " m_property_id INT,";            //案件基本
//					CreateTableSql += " project_number VARCHAR (10),";            //案件番号
//					CreateTableSql += " order_number VARCHAR (10),";            //注文番号
//					CreateTableSql += " project_code VARCHAR (10),";            //
//					CreateTableSql += " project_manage_code VARCHAR (10),";            //案件管理番号
//					CreateTableSql += " project_name NVARCHAR (50),";            //案件名
//					CreateTableSql += " management_number VARCHAR (10),";            //
//					CreateTableSql += " delivery_date DATE,";            //     DEFAULT (dateadd(month,(1),getdate())) NULL,		納期
//					CreateTableSql += " supplier_name NVARCHAR (255),";            //得意先名
//					CreateTableSql += " owner_name VARCHAR (50),";            //施主
//					CreateTableSql += " project_place VARCHAR (255),";            //場所
//					CreateTableSql += " status TINYINT,";            //  DEFAULT ((1))	ステータス
//					CreateTableSql += " modifier_on DATETIME,";            //  DEFAULT (getdate())		更新日時,
//					CreateTableSql += " deleted_on DATETIME";            //   削除日時,
//					CreateTableSql += ")";

//					command.CommandText = CreateTableSql;
//					command.ExecuteNonQuery();
//					CreateTableSql = "alter table t_project_bases convert to character set utf8;";            //日本語対応「
//					command.CommandText = CreateTableSql;
//					command.ExecuteNonQuery();
	
//					//カラーテーブル
//					 CreateTableSql = "CREATE TABLE IF NOT EXISTS f_Color (id INT,";       //     IDENTITY (1, 1) NOT NULL,	PRIMARY KEY CLUSTERED ([Id] ASC)
//					CreateTableSql += " Color_var NCHAR (10),";         
//					CreateTableSql += " Color_name  NVARCHAR (255),";
//					CreateTableSql += " google_Color_id VARCHAR (100),";  
//					CreateTableSql += " modifier_on DATETIME,";            //  DEFAULT (getdate())		更新日時,
//					CreateTableSql += " deleted_on DATETIME";            //   削除日時,
//					CreateTableSql += ")";
//					command.CommandText = CreateTableSql;
//					command.ExecuteNonQuery();
//					CreateTableSql = "alter table f_Color convert to character set utf8;";            //日本語対応「
//					command.CommandText = CreateTableSql;
//					command.ExecuteNonQuery();
//					//イベント
//					CreateTableSql = "CREATE TABLE IF NOT EXISTS t_events (id INT,";       //     IDENTITY (1, 1) NOT NULL,	PRIMARY KEY CLUSTERED ([Id] ASC)
//					CreateTableSql += " m_contract_id INT,";            //契約ID
//					CreateTableSql += " t_project_base_id INT,";            //案件基本
//					CreateTableSql += " event_type TINYINT,";
//					CreateTableSql += " event_date_start DATE,";
//					CreateTableSql += " event_time_start TINYINT,";                 //  DEFAULT ((10)) 
//					CreateTableSql += " event_date_end DATE,";
//					CreateTableSql += " event_time_end TINYINT,";                 //  DEFAULT ((11)) 
//					CreateTableSql += " event_is_daylong TINYINT,";                 //  DEFAULT ((1)) 
//					CreateTableSql += " event_title NVARCHAR (100),";            //注文番号
//					CreateTableSql += " event_place NVARCHAR (255),";            //
//					CreateTableSql += " event_memo NVARCHAR (4000),";            //案件管理番号
//					CreateTableSql += " google_id NVARCHAR (255),";            //案件名
//					CreateTableSql += " event_status TINYINT,";
//					CreateTableSql += " event_bg_color VARCHAR (10),";            //
//					CreateTableSql += " event_font_color VARCHAR (10),";            //得意先名
//					CreateTableSql += " modifier_on DATETIME,";            //  DEFAULT (getdate())		更新日時,
//					CreateTableSql += " deleted_on DATETIME";            //   削除日時,
//					CreateTableSql += ")";

//					command.CommandText = CreateTableSql;
//					command.ExecuteNonQuery();
//					CreateTableSql = "alter table t_events convert to character set utf8;";            //日本語対応「
//					command.CommandText = CreateTableSql;
//					command.ExecuteNonQuery();

//				}
//				MyLog(TAG, dbMsg);
//			} catch (Exception er) {
//				MyErrorLog(TAG, dbMsg, er);
//			}
//		}

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
				this.table_dg.DataContext = null;
				this.table_dg.Items.Refresh();

				string[] rStrs = tableName.Split('_');
				TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

				Type myType = typeof(MySQLBase);
				string modelName = myType.Namespace + ".Models.";                 // "GoogleOSD.Models."
				for (int i = 1; i < rStrs.Length; i++) {
					string rStr = ti.ToTitleCase(rStrs[i]);
					modelName += rStr;
				}
				dbMsg += ",modelName=" + modelName;
				modelType = Type.GetType(modelName);
				dbMsg += ",type=" + modelType.FullName;
				wModel = (Object)Activator.CreateInstance(modelType);
				//ObservableCollectionを変数化するとAddが使えない
				wCollection = new List<object>();
				//ヘッダー作成：型の確定;	列定義を書き換え
				table_dg.Columns.Clear();		//全列削除
				var viewModel = this;
				// リソースからスタイルを取得
				//var headerStyle = (Style)table_dg.FindResource("HeaderStyle");
				//var textStyle = (Style)table_dg.FindResource("TextStyle");
				foreach (var rFeild in wModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
					string rName = rFeild.Name;
					string rType = rFeild.PropertyType.Name;
					dbMsg += "\r\nrName=" + rName + ",rType=" + rType;
					if (rType.Equals("Boolean")) {
						table_dg.Columns.Add(new DataGridCheckBoxColumn() {
							Header = rName,
							Binding = new Binding(rName)
						});
					} else if (rType.Equals("DateTime")) {
						table_dg.Columns.Add(new DataGridTextColumn() {
							Header = rName,
							Binding = new Binding(rName) { StringFormat = "yyyy/MM/dd hh:mm" }
						});
					}else{
						table_dg.Columns.Add(new DataGridTextColumn() {
							Header = rName,
							//HeaderStyle = headerStyle,
							//ElementStyle = textStyle,
							//IsReadOnly = true,
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
												}else if (rType.Equals("Int32")) {
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
				if(rCount < 1) {
					dbMsg += ",データ入力無し";        //ObservableCollectionから該当モデルのフィールドのみを引き当てる
					Type CollectionType = Type.GetType(modelName + "Collection");
					Object bCollection = (Object)Activator.CreateInstance(CollectionType);
		//			dbMsg += ",wCollection=" + bCollection.FullName;
					this.table_dg.DataContext = bCollection;
				} else {
					// データをそのままセットする
					this.table_dg.DataContext = wCollection;
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
				this.table_dg.Items.Refresh();
				Connection.Close();
				// コンテンツに合わせて自動的にWindow幅と高さをリサイズする
				this.SizeToContent = SizeToContent.WidthAndHeight;

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

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
