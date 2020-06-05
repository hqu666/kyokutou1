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
	/// GEventDayList.xaml の相互作用ロジック
	/// </summary>
	public partial class GEventDayList : Window {
		public GCalender mainView;
		public GEventDayList()
		{
			string TAG = "GEventDayList";
			string dbMsg = "[GEventDayList]";
			try {
				InitializeComponent();
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
			string dbMsg = "[GEventDayList]";
			try {
				if (mainView != null) {
					//			this.Visible = false;//このオブジェクトを破棄させない(2);this.Close();だと再表示でクラッシュする
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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
