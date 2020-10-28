using Livet;
using Livet.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace TabCon.ViewModels {
	public class ParrtsTestViewModel : ViewModel {
		public string titolStr = "カスタムパーツテスト";

		public Views.ParrtsTestView MyView { get; set; }
		public ViewModels.MainViewModel RootViewModel { get; set; }

		/// <summary>
		/// 結果表示フィールド値
		/// </summary>
		public string CalcResult { get; set; }
		/// <summary>
		/// ダイアログタイトル
		/// </summary>
		public string CalcTextDLogTitol { get; set; }
		/// <summary>
		/// 幅
		/// </summary>
		public string CalcTexWidth { get; set; }
		/// <summary>
		/// フォントサイズ
		/// </summary>
		public string CalcTextFontSize { get; set; }
		
		public ParrtsTestViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			CalcTextDLogTitol = "電卓を表示するフィールドから";
			CalcTexWidth = "120";
			CalcTextFontSize = "18";
			CalcResult = "0123456789";
			RaisePropertyChanged();
		}


		////////////////////////////////////////////////////
		//public static void MyLog(string TAG, string dbMsg)
		//{
		//	CS_Util Util = new CS_Util();
		//	Util.MyLog(TAG, dbMsg);
		//}

		//public static void MyErrorLog(string TAG, string dbMsg, Exception err)
		//{
		//	CS_Util Util = new CS_Util();
		//	Util.MyErrorLog(TAG, dbMsg, err);
		//}

		//public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
		//																MessageBoxButton buttns,
		//																MessageBoxImage icon
		//																)
		//{
		//	CS_Util Util = new CS_Util();
		//	return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		//}


	}
}
