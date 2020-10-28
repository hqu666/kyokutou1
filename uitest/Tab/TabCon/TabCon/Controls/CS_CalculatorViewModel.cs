using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabCon.Controls
{
/// <summary>
/// 未使用
/// </summary>
	public class CS_CalculatorViewModel : ViewModel {
		public CS_CalculatorControl MyView { get; set; }
		/// <summary>
		/// 計算結果
		/// </summary>
		public string CResult { get; set; }
		/// <summary>
		/// 入力値
		/// </summary>
		public string CInput { get; set; }

		public CS_CalculatorViewModel()
		{
			Initialize();
		}

		public void Initialize()
		{
			CResult = "C(BackSpace)ボタンは1クリックで1文字づつ消去します";
			CInput = "CA(Delete)で全消去";
			RaisePropertyChanged();

		}
	}
}
