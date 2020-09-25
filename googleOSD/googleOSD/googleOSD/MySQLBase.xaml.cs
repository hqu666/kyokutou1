using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Globalization;

namespace GoogleOSD {
	/// <summary>
	/// MySQLBase.xaml の相互作用ロジック
	/// </summary>
	public partial class MySQLBase : Window {

		public MySqlConnection Connection = null;
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
					//connectionString_lb.Content = Constant.ConnectionString;

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
		/// 接続したデータベースの全テーブルデータ取得
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
						dbMsg += ",reader=" + reader.RecordsAffected + "テーブル " ;
						TableCombo = new Dictionary<string, string>();
						// データがある間繰り返します。
						while (reader.Read()) {
							// 取得したテーブル名を表示します。
							string key = reader.GetString(0);                   //テーブル名（日）に記載した　日本語の名称は?
							string name = reader.GetString(0);
							dbMsg += "," + key + " : " + name;
							TableCombo.Add( key,name);
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
				string selectedValue = combo.SelectedValue.ToString();
				dbMsg +=  selectedValue;
				MyLog(TAG, dbMsg);
				ReadTable(selectedValue);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		////////////////////////////////////////////////////
		public void MakeTable()
		{
			string TAG = "MakeTable";
			string dbMsg = "[MySQLBase]";
			try {
				// コネクションオブジェクトとコマンドオブジェクトを生成します。
				//using (var connection = new MySqlConnection(ConnectionString))
				using (var command = new MySqlCommand()) {
					// コネクションをオープンします。
					//Connection.Open();

					// テーブル作成SQLを実行します。
					command.Connection = Connection;
//案件基本
					string CreateTableSql = "CREATE TABLE IF NOT EXISTS t_project_bases (id INT,";       //     IDENTITY (1, 1) NOT NULL,	PRIMARY KEY CLUSTERED ([Id] ASC)
					CreateTableSql += " m_contract_id INT,";            //契約ID
					CreateTableSql += " m_property_id INT,";            //案件基本
					CreateTableSql += " project_number VARCHAR (10),";            //案件番号
					CreateTableSql += " order_number VARCHAR (10),";            //注文番号
					CreateTableSql += " project_code VARCHAR (10),";            //
					CreateTableSql += " project_manage_code VARCHAR (10),";            //案件管理番号
					CreateTableSql += " project_name NVARCHAR (50),";            //案件名
					CreateTableSql += " management_number VARCHAR (10),";            //
					CreateTableSql += " delivery_date DATE,";            //     DEFAULT (dateadd(month,(1),getdate())) NULL,		納期
					CreateTableSql += " supplier_name NVARCHAR (255),";            //得意先名
					CreateTableSql += " owner_name VARCHAR (50),";            //施主
					CreateTableSql += " project_place VARCHAR (255),";            //場所
					CreateTableSql += " status TINYINT,";            //  DEFAULT ((1))	ステータス
					CreateTableSql += " modifier_on DATETIME,";            //  DEFAULT (getdate())		更新日時,
					CreateTableSql += " deleted_on DATETIME";            //   削除日時,
					CreateTableSql += ")";

					command.CommandText = CreateTableSql;
					command.ExecuteNonQuery();
					CreateTableSql = "alter table t_project_bases convert to character set utf8;";            //日本語対応「
					command.CommandText = CreateTableSql;
					command.ExecuteNonQuery();
	
					//カラーテーブル
					 CreateTableSql = "CREATE TABLE IF NOT EXISTS f_Color (id INT,";       //     IDENTITY (1, 1) NOT NULL,	PRIMARY KEY CLUSTERED ([Id] ASC)
					CreateTableSql += " Color_var NCHAR (10),";         
					CreateTableSql += " Color_name  NVARCHAR (255),";
					CreateTableSql += " google_Color_id VARCHAR (100),";  
					CreateTableSql += " modifier_on DATETIME,";            //  DEFAULT (getdate())		更新日時,
					CreateTableSql += " deleted_on DATETIME";            //   削除日時,
					CreateTableSql += ")";
					command.CommandText = CreateTableSql;
					command.ExecuteNonQuery();
					CreateTableSql = "alter table f_Color convert to character set utf8;";            //日本語対応「
					command.CommandText = CreateTableSql;
					command.ExecuteNonQuery();
					//イベント
					CreateTableSql = "CREATE TABLE IF NOT EXISTS t_events (id INT,";       //     IDENTITY (1, 1) NOT NULL,	PRIMARY KEY CLUSTERED ([Id] ASC)
					CreateTableSql += " m_contract_id INT,";            //契約ID
					CreateTableSql += " t_project_base_id INT,";            //案件基本
					CreateTableSql += " event_type TINYINT,";
					CreateTableSql += " event_date_start DATE,";
					CreateTableSql += " event_time_start TINYINT,";                 //  DEFAULT ((10)) 
					CreateTableSql += " event_date_end DATE,";
					CreateTableSql += " event_time_end TINYINT,";                 //  DEFAULT ((11)) 
					CreateTableSql += " event_is_daylong TINYINT,";                 //  DEFAULT ((1)) 
					CreateTableSql += " event_title NVARCHAR (100),";            //注文番号
					CreateTableSql += " event_place NVARCHAR (255),";            //
					CreateTableSql += " event_memo NVARCHAR (4000),";            //案件管理番号
					CreateTableSql += " google_id NVARCHAR (255),";            //案件名
					CreateTableSql += " event_status TINYINT,";
					CreateTableSql += " event_bg_color VARCHAR (10),";            //
					CreateTableSql += " event_font_color VARCHAR (10),";            //得意先名
					CreateTableSql += " modifier_on DATETIME,";            //  DEFAULT (getdate())		更新日時,
					CreateTableSql += " deleted_on DATETIME";            //   削除日時,
					CreateTableSql += ")";

					command.CommandText = CreateTableSql;
					command.ExecuteNonQuery();
					CreateTableSql = "alter table t_events convert to character set utf8;";            //日本語対応「
					command.CommandText = CreateTableSql;
					command.ExecuteNonQuery();

				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

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

				Type type = Type.GetType(modelName);
				dbMsg += ",type=" + type.FullName;
				Object wModel = (Object)Activator.CreateInstance(type);
				type = Type.GetType(modelName + "Collection");
				Object wCollection = (Object)Activator.CreateInstance(type);
				DataTable tbl = new DataTable();
				using (MySqlConnection mySqlConnection = new MySqlConnection(Constant.ConnectionString)) {
					mySqlConnection.Open();
					using (MySqlCommand command = mySqlConnection.CreateCommand()) {
						command.CommandText = $"SELECT * FROM {tableName}";
						using (MySqlDataReader reader = command.ExecuteReader()) {
							while (reader.Read()) {
								for (int i = 0; i < reader.FieldCount; i++) {
									string rName = reader.GetName(i);
									string rType = reader.GetFieldType(i).Name;
									dbMsg += "\r\nrName=" + rName + ",rType=" + rType;
									var rVar = reader.GetValue(i);
									dbMsg += ",rVar=" + rVar;

									if (!reader.IsDBNull(i)) {
										foreach (var rFeild in wModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
											if (rFeild.Name.Equals(rName)) {
												if (rType.Equals("Int32")) {
													rFeild.SetValue(wModel, reader.GetInt32(i));
												} else if (rType.Equals("String")) {
													rFeild.SetValue(wModel, reader.GetString(i));
												} else if (rType.Equals("DateTime")) {
													rFeild.SetValue(wModel, reader.GetDateTime(i));
												} else if (rType.Equals("Boolean")) {                       //tinyInt(1)
													rFeild.SetValue(wModel, reader.GetBoolean(i));
												} else if (rType.Equals("SByte")) {
													rFeild.SetValue(wModel, reader.GetValue(i));
													rFeild.SetValue(wModel, reader.GetSByte(i));
												} else if (rType.Equals("MySqlDecimal")) {
													rFeild.SetValue(wModel, reader.GetMySqlDecimal(i));
												}
											}
										}
									}
								}
							}
						}
					}

				}
		//		dbMsg += ",projecDataCollection=" + wCollection.
				// データをそのままセットする
				this.table_dg.DataContext = wCollection;
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

		public static PropertyInfo GetPropertyInfo(Type type, string name)
		{
			var property = type.GetProperty(name);

			return property;
		}

		////////////////////////////////////////////////////
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
