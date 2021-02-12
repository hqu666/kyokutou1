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
		/// <summary>
		/// 表示位置
		/// </summary>
		public string CalcTextShowX { get; set; }
		public string CalcTextShowY { get; set; }

		public int SuppliersClosing1 { get; set; }

		//private int _SuppliersClosing1;
		//public int SuppliersClosing1 {  
		//		get {
		//			return _SuppliersClosing1;
		//		}
		//		set {
		//			if (value == _SuppliersClosing1)
		//				return;
		//		_SuppliersClosing1 = value;
		//			titolStr = "締日1";
		//			string msgStr = _SuppliersClosing1 + "に設定されました";
		//			System.Windows.MessageBox.Show(msgStr, titolStr, MessageBoxButton.OK);
		//		}
		//	}
		public int SuppliersClosing2 { get; set; }
		//private int _SuppliersClosing2;
		//public int SuppliersClosing2 {
		//	get {
		//		return _SuppliersClosing2;
		//	}
		//	set {
		//		if (value == _SuppliersClosing2)
		//			return;
		//		_SuppliersClosing2 = value;
		//		titolStr = "締日2";
		//		string msgStr = _SuppliersClosing2 + "に設定されました";
		//		System.Windows.MessageBox.Show(msgStr, titolStr, MessageBoxButton.OK);
		//	}
		//}


		public ParrtsTestViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			CalcTextDLogTitol = "電卓を表示するフィールドから";
			CalcTexWidth = "200";
			CalcTextFontSize = "18";
			CalcTextShowX = "200";
			CalcTextShowY = "400";
			CalcResult = "0123456789";
			SuppliersClosing1 = 5;
			SuppliersClosing2 =15;
			RaisePropertyChanged();
		}

	}
}
