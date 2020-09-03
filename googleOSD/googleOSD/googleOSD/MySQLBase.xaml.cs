using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace GoogleOSD {
	/// <summary>
	/// MySQLBase.xaml の相互作用ロジック
	/// </summary>
	public partial class MySQLBase : Window {

		public MySqlConnection Connection = null;
		public string titolStr = "MySQL";
		private static readonly string Server = "localhost";             // MySQLサーバホスト名
		private static readonly int Port = 3306;                  // ポート番号
		private static readonly string Database = "sample";       // データベース名
		private static readonly string Uid = "root";           // MySQLユーザ名"user";              // ユーザ名
		private static readonly string Pwd = "";           // MySQLパスワード"password";          // パスワード
		private string ConnectionString;

		public MySQLBase()
		{
			InitializeComponent();
			dis_conect_bt.Visibility = System.Windows.Visibility.Hidden;
			conect_bt.Visibility = System.Windows.Visibility.Visible;
		}

		/// <summary>
		///データベースに接続
		/// </summary>
		/// <param name="args"></param>
		public void SqlConnect(string[] args)
		{
			string TAG = "SqlConnect";
			string dbMsg = "[GCalender]";
			try {
				// MySQLへの接続情報
				string database = "mysql";      // 接続するデータベース名
				ConnectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Server, database, Uid, Pwd);
				// MySQLへの接続
				try {
					server_lb.Content = Server;
					port_lb.Content = Port;
					uid_lb.Content = Uid;
					password_lb.Content = Pwd;
					connectionString_lb.Content = ConnectionString;

					Connection = new MySqlConnection(ConnectionString);
					Connection.Open();
					string msgStr = "MySQLに接続しました\r\n";
					msgStr = "MySQLに接続しました\r\n";
					dbMsg += ",msgStr=" + msgStr;
		//			MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dis_conect_bt.Visibility = System.Windows.Visibility.Visible;
					conect_bt.Visibility = System.Windows.Visibility.Hidden;

					MakeTable();
					ReadTable();

				} catch (MySqlException me) {
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
			string dbMsg = "[GCalender]";
			try {
				try {
					Connection.Close();
					string msgStr = "MySQLの接続を解除しました";
					dbMsg += ",msgStr=" + msgStr;
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dbMsg += "接続の解除";
					dis_conect_bt.Visibility = System.Windows.Visibility.Hidden;
					conect_bt.Visibility = System.Windows.Visibility.Visible;
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

		////////////////////////////////////////////////////
		public void MakeTable()
		{
			string TAG = "MakeTable";
			string dbMsg = "[GCalender]";
			try {
				// コネクションオブジェクトとコマンドオブジェクトを生成します。
				//using (var connection = new MySqlConnection(ConnectionString))
				using (var command = new MySqlCommand()) {
					// コネクションをオープンします。
					//Connection.Open();

					// テーブル作成SQLを実行します。
					command.Connection = Connection;
//案件基本
					string CreateTableSql = "CREATE TABLE IF NOT EXISTS t_project_base (id INT,";       //     IDENTITY (1, 1) NOT NULL,	PRIMARY KEY CLUSTERED ([Id] ASC)
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
					CreateTableSql = "alter table t_project_base convert to character set utf8;";            //日本語対応「
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


		public void ReadTable()
		{
			string TAG = "ReadTable";
			string dbMsg = "[GCalender]";
			try {
				string tableName = "t_project_base";
				if(Connection.State != ConnectionState.Open) {
					dbMsg += ",Openしてない";
					Connection.Open();
				}

				ProjecDataCollection projecDataCollection = new ProjecDataCollection();
				EventDataCollection eventDataCollection = new EventDataCollection();
				Object wModel = null;

				DataTable tbl = new DataTable();
				using (MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString)) {
					mySqlConnection.Open();
					using (MySqlCommand command = mySqlConnection.CreateCommand()) {
						command.CommandText = $"SELECT * FROM {tableName}";
						using (MySqlDataReader reader = command.ExecuteReader()) {
							while (reader.Read()) {
								string[] row = new string[reader.FieldCount];
								t_project_base rProject = new t_project_base();
								if (tableName.Equals("t_project_base")) {
									wModel = new t_project_base();
								} else if (tableName.Equals("t_events")) {
									wModel = new t_events();
								} else if (tableName.Equals("f_Color")) {
									wModel = new f_Color();
								}

								for (int i = 0; i < reader.FieldCount; i++) {
									string rName = reader.GetName(i);
									string rType = reader.GetFieldType(i).Name;
									dbMsg += ",rName=" + rName + ",rType=" + rType;
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
												} else if (rType.Equals("Boolean")) {						//tinyInt(1)
												//	rFeild.SetValue(wModel, reader.GetValue(i));
												} else if (rType.Equals("SByte")) {
													rFeild.SetValue(wModel, reader.GetValue(i));
													//						rFeild.SetValue(wModel, int.Parse( rVar.ToString()));          // 'System.Nullable`1[System.Byte]'
													//	rFeild.SetValue(wModel, reader.GetSByte(i));
												} else if (rType.Equals("MySqlDecimal")) {
													rFeild.SetValue(wModel, reader.GetMySqlDecimal(i));
												}
											}
										}
									}
								}

								if (tableName.Equals("t_project_base")) {
									projecDataCollection.Add(wModel as t_project_base);
									this.table_dg.DataContext = projecDataCollection;
								} else if (tableName.Equals("t_events")) {
									eventDataCollection.Add(wModel as t_events);
									//} else if (tableName.Equals("f_Color")) {
									//	this.table_dg.DataContext = projecDataCollection;
									//	wModel = new f_Color();
								}
							}
						}
					}

				}
				dbMsg += ",projecDataCollection=" + projecDataCollection.Count();
				// データをそのままセットする
				if (tableName.Equals("t_project_base")) {
					this.table_dg.DataContext = projecDataCollection;
				} else if (tableName.Equals("t_events")) {
					this.table_dg.DataContext = eventDataCollection;
				//} else if (tableName.Equals("f_Color")) {
				//	this.table_dg.DataContext = projecDataCollection;
				//	wModel = new f_Color();
				}
				//更新時はこれが必須
				this.table_dg.Items.Refresh();

				Connection.Close();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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
