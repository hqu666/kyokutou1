using System;
using System.Collections.Generic;
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

namespace GoogleOSD {
	/// <summary>
	/// MySQLBase.xaml の相互作用ロジック
	/// </summary>
	public partial class MySQLBase : Window {

		public MySqlConnection connection = null;
		public string titolStr = "MySQL";
		private static readonly string Server = "localhost";             // MySQLサーバホスト名
		private static readonly int Port = 3306;                  // ポート番号
		private static readonly string Database = "sample";       // データベース名
		private static readonly string Uid = "root";           // MySQLユーザ名"user";              // ユーザ名
		private static readonly string Pwd = "";           // MySQLパスワード"password";          // パスワード

		public MySQLBase()
		{
			InitializeComponent();
			dis_conect_bt.Visibility = System.Windows.Visibility.Hidden;
			conect_bt.Visibility = System.Windows.Visibility.Visible;
		}

		public void SqlConnect(string[] args)
		{
			string TAG = "SqlConnect";
			string dbMsg = "[GCalender]";
			try {
				// MySQLへの接続情報
				string database = "mysql";      // 接続するデータベース名
				string connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", Server, database, Uid, Pwd);
				// MySQLへの接続
				try {
					server_lb.Content = Server;
					port_lb.Content = Port;
					uid_lb.Content = Uid;
					password_lb.Content = Pwd;
					connectionString_lb.Content = connectionString;

					connection = new MySqlConnection(connectionString);
					connection.Open();
					string msgStr = "MySQLに接続しました\r\n";
					msgStr = "MySQLに接続しました\r\n";
					dbMsg += ",msgStr=" + msgStr;
					MessageBoxResult result = MessageShowWPF(titolStr, msgStr, MessageBoxButton.OK, MessageBoxImage.Exclamation);
					dis_conect_bt.Visibility = System.Windows.Visibility.Visible;
					conect_bt.Visibility = System.Windows.Visibility.Hidden;

					// 接続の解除
					//connection.Close();
				} catch (MySqlException me) {
					MyErrorLog(TAG, dbMsg, me);
				}

				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void DisConnect()
		{
			string TAG = "DisConnect";
			string dbMsg = "[GCalender]";
			try {
				try {
					connection.Close();
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
