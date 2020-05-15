using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGSample {
	/// <summary>
	/// 日付情報
	/// </summary>
	public class DateInfo : MonthInfo {
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="yearMonth"></param>
		/// <param name="day"></param>
		public DateInfo(String yearMonth, String day) : base(yearMonth)
		{
			this.YearMonthDay = yearMonth + day;
			this.Date = new DateTime(int.Parse(getYear()), int.Parse(getMonth()), int.Parse(day));
		}

		public DateTime Date { set; get; }

		/// <summary>
		/// 年月日
		/// </summary>
		public String YearMonthDay { set; get; }

		/// <summary>
		/// 年月日（YYYY年MM月DD日）
		/// </summary>
		public String getYearMonthDayWithKanji()
		{
			return String.Format("{0:yyyy年MM月dd日（ddd）}", Date);
		}

		/// <summary>
		/// 日を返します.
		/// </summary>
		/// <returns></returns>
		public String getDay()
		{
			if (String.IsNullOrEmpty(YearMonthDay)) return "";
			return YearMonthDay.Substring(6, 2);
		}
	}
}