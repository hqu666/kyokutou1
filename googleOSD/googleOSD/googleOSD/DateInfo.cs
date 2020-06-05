using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleOSD {
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
			string TAG = "CreatDateInfoeCalendarDate";
			string dbMsg = "[DateInfo]";
			try {
				dbMsg = yearMonth + "年月" + day + "日";
				this.YearMonthDay = yearMonth + day;
				this.Date = new DateTime(int.Parse(getYear()), int.Parse(getMonth()), int.Parse(day));
	//			MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
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

		public DateTime GetDateTime()
		{
			return Date;
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

	}
}