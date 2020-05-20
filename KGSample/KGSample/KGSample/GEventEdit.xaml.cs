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

namespace KGSample {
	/// <summary>
	/// GEventEdit.xaml の相互作用ロジック
	/// </summary>
	public partial class GEventEdit : Window {

		public GCalender mainView;

		/// <summary>
		/// このページで編集するEvent
		/// </summary>
		//public Uri taregetURL { set; get; }
		private Google.Apis.Calendar.v3.Data.Event taregetEvent { set; get; }

		public GEventEdit(Google.Apis.Calendar.v3.Data.Event taregetEvent)
		{
			string TAG = "GEventEdit";
			string dbMsg = "[GEventEdit]";
			try {
				InitializeComponent();
				dbMsg = "taregetEvent=" + taregetEvent.Summary;
				titol_tv.Content = taregetEvent.Summary;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}



		private void Back_bt_Click(object sender, EventArgs e)
		{
			string TAG = "back_bt_Click";
			string dbMsg = "[GEventEdit]";
			try {
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// WPFでクローズボックスなど、ウインドウを閉じる時に発生するイベントハンドラ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string TAG = "Window_Closing";
			string dbMsg = "[GEventEdit]";
			try {
//				e.Cancel = true;                //このオブジェクトを破棄させない(1)
				QuitMe();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		/// <summary>
		/// このフォームを閉じる
		/// ※this.Close();だと再表示でクラッシュするのでthis.Visible = false;でこのオブジェクトを破棄させない
		/// </summary>
		private void QuitMe()
		{
			string TAG = "QuitMe";
			string dbMsg = "[GEventEdit]";
			try {
				if (mainView != null) {
					mainView.editView = null;
			//		this.Visibility=false;//このオブジェクトを破棄させない(2);this.Close();だと再表示でクラッシュする
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