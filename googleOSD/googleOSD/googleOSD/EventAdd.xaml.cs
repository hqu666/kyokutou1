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

namespace GoogleOSD {
	/// <summary>
	/// EventAdd.xaml の相互作用ロジック
	/// </summary>
	public partial class EventAdd : Window {

		CompanyEntities dataEntities = new CompanyEntities();
		public ProjecDataCollection projecDataCollection;

		public GCalender ownerView;
		public DateTime startDT;

		public EventAdd()
		{
			string TAG = "EventAdd";
			string dbMsg = "[EventAdd]";
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//DataGrid操作/////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// t_project_baseをDataGridに表示
		/// 		//https://docs.microsoft.com/ja-jp/dotnet/framework/wpf/controls/walkthrough-display-data-from-a-sql-server-database-in-a-datagrid-control
		/// </summary>
		private void ListDrow()
		{
			string TAG = "ListDrow";
			string dbMsg = "[EventAdd]";
			try {
				Project_dg.ItemsSource = projecDataCollection.ToList();
				//該当件数を表示
				prject_count.Content = projecDataCollection.Count().ToString();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// リストアイテムクリック
		/// 新規案件イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Project_dg_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			string TAG = "Project_dg_MouseDoubleClick";
			string dbMsg = "[EventAdd]";
			try {
				DataGrid dGrid = sender as DataGrid;
				//		t_project_base selectedData = this.Project_dg.SelectedItem as t_project_base;

				t_project_base currentItems = dGrid.CurrentCell.Item as t_project_base;
				t_events nEvents = new t_events();
				nEvents.m_contract_id = currentItems.m_contract_id;                                         //契約ID
				nEvents.event_type = 1;																						//案件
				nEvents.t_project_base_id = currentItems.Id; 
				dbMsg += "案件:[" + nEvents.t_project_base_id + "]";
				nEvents.event_title = currentItems.owner_name + "様　" + currentItems.project_name;
				dbMsg += nEvents.event_title;
				nEvents.event_date_start = startDT;
				nEvents.event_date_end = currentItems.delivery_date;
				dbMsg += "," + nEvents.event_date_start + "～" + nEvents.event_date_end;
				nEvents.event_is_daylong = 1;																	//終日
				nEvents.event_place = currentItems.project_place;                                      //場所
				nEvents.event_bg_color = "2";                                                                   //背景
				nEvents.event_font_color = "1";                                                                   //文字色
																												/*    public Nullable<int> m_contract_id { get; set; }
																																public Nullable<byte> event_time_start { get; set; }
																																public Nullable<System.DateTime> event_date_end { get; set; }
																																public Nullable<byte> event_time_end { get; set; }
																																public string event_memo { get; set; }
																																public Nullable<byte> event_status { get; set; }
																																public string google_id { get; set; }
																																public Nullable<byte> status { get; set; }
																																public Nullable<System.DateTime> modifier_on { get; set; }
																																public Nullable<System.DateTime> deleted_on { get; set; }*/
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////////

		/// <summary>
		/// window生成後
		/// DataGrid作成へ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			string TAG = "Window_Loaded";
			string dbMsg = "[EventAdd]";
			try {
				dbMsg += ",startDT=" + startDT;
				//タイトルを記載
				this.Title = String.Format("{0:yyyy/MM/dd}", startDT) + "に新しい予定を追加します";
				ListDrow();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void add_sced_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "add_sced_bt_Click";
			string dbMsg = "[EventAdd]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Cancel_bt_Click(object sender, RoutedEventArgs e)
		{
			string TAG = "Cancel_bt_Click";
			string dbMsg = "[EventAdd]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			string TAG = "Window_Closed";
			string dbMsg = "[EventAdd]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// このフォームを閉じる
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[EventAdd]";
			try {
				if (ownerView != null) {
					ownerView.EADlog = null;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
			this.Close();
		}


		////////////////////////////////////////////////////
		public void MyLog(string TAG, string dbMsg)
		{
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err)
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
