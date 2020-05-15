using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGSample {
	/// <summary>
	/// 年月情報
	/// </summary>
	public class MonthInfo {
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="yearMonth"></param>
		public MonthInfo(String yearMonth)
		{
			this.YearMonth = yearMonth;
			this.YearMonthWithKanji = getYear() + "年" + getMonth() + "月";
		}

		/// <summary>
		/// 年月
		/// </summary>
		public String YearMonth { set; get; }

		/// <summary>
		/// 年月（YYYY年MM月）
		/// </summary>
		public String YearMonthWithKanji { set; get; }

		/// <summary>
		/// 年を返します.
		/// </summary>
		/// <returns></returns>
		public String getYear()
		{
			if (String.IsNullOrEmpty(YearMonth)) return "";
			return YearMonth.Substring(0, 4);
		}

		/// <summary>
		/// 月を返します.
		/// </summary>
		/// <returns></returns>
		public String getMonth()
		{
			if (String.IsNullOrEmpty(YearMonth)) return "";
			return YearMonth.Substring(4, 2);
		}
	}
}