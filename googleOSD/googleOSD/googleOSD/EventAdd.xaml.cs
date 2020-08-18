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

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			string TAG = "Window_Loaded";
			string dbMsg = "[EventAdd]";
			try {
				dbMsg += ",startDT=" + startDT;
				this.Title = String.Format("{0:yyyy/MM/dd}", startDT) + "に新しい予定を追加します";
				var query =
							from project in dataEntities.t_project_base
							where project.status != 9 & project.deleted_on == null
							orderby project.delivery_date
							select new { project.project_manage_code, 
												project.project_name, 
												project.delivery_date,
												project.Id,
												project.m_contract_id,
												project.m_property_id,
												project.project_number,
												project.order_number,
												project.project_code,
												project.management_number,
												project.supplier_name,
												project.owner_name,
												project.project_place,
												project.status,
												project.modifier_on
							};
				//							select new { project };
				// CategoryName = product.ProductCategory.Name, product.ListPrice
				Project_dg.ItemsSource = query.ToList();
				prject_count.Content = query.Count().ToString();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		//https://docs.microsoft.com/ja-jp/dotnet/framework/wpf/controls/walkthrough-display-data-from-a-sql-server-database-in-a-datagrid-control

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
