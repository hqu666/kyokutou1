using Livet;

namespace WpfApp1.ViewModels {
	public class ParrtsTestViewModel : ViewModel {
		public string titolStr = "カスタムパーツテスト";

//		public Views.ParrtsTestView MyView { get; set; }
	//	public ViewModels.MainViewModel RootViewModel { get; set; }

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
		/// 表示位置
		/// </summary>
		public string CalcTextShowX { get; set; }
		public string CalcTextShowY { get; set; }

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
			RaisePropertyChanged();
		}

	}
}
