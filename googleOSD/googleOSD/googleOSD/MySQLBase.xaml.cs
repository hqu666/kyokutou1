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
		public MySQLBase()
		{
			InitializeComponent();
			string[] args = null;
			SqlConnect( args);
		}

		static void SqlConnect(string[] args)
		{
			string TAG = "SqlConnect";
			string dbMsg = "[GCalender]";
			try {
				// MySQLへの接続情報
				string server = "localhost";        // MySQLサーバホスト名
				string user = "root";           // MySQLユーザ名
				string pass = "";           // MySQLパスワード
				string database = "mysql";      // 接続するデータベース名
				string connectionString = string.Format("Server={0};Database={1};Uid={2};Pwd={3}", server, database, user, pass);
				// MySQLへの接続
				try {
					MySqlConnection connection = new MySqlConnection(connectionString);
					connection.Open();
					Console.WriteLine("MySQLに接続しました！");
					// 接続の解除
					connection.Close();
				} catch (MySqlException me) {
					Console.WriteLine("ERROR: " + me.Message);
				}
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
