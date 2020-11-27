using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TabCon.Enums
{
    /// <summary>
    /// 締日
    /// </summary>
    /// 
    [TypeConverter(typeof(EnumDisplayNameConverter))]
    public enum E11SuppliersClosingDates
    {
        [EnumDisplayName("随時")]
        anytime,
        [EnumDisplayName("1日")]
        one_day,
        [EnumDisplayName("2日")]
        two_days,
        [EnumDisplayName("3日")]
        three_days,
        [EnumDisplayName("4日")]
        four_days,
        [EnumDisplayName("5日")]
        five_days,
        [EnumDisplayName("6日")]
        six_days,
        [EnumDisplayName("7日")]
        seven_days,
        [EnumDisplayName("8日")]
        eight_days,
        [EnumDisplayName("9日")]
        nine_days,
        [EnumDisplayName("10日")]
        ten_days,
        [EnumDisplayName("11日")]
        eleven_days,
        [EnumDisplayName("12日")]
        twelve_days,
        [EnumDisplayName("13日")]
        thirteen_days,
        [EnumDisplayName("14日")]
        fourteen_days,
        [EnumDisplayName("15日")]
        fifteen_days,
        [EnumDisplayName("16日")]
        sixteen_days,
        [EnumDisplayName("17日")]
        seventeen_days,
        [EnumDisplayName("18日")]
        eighteen_days,
        [EnumDisplayName("19日")]
        nineteen_days,
        [EnumDisplayName("20日")]
        twenty_days,
        [EnumDisplayName("21日")]
        twenty_one_days,
        [EnumDisplayName("22日")]
        twenty_two_days,
        [EnumDisplayName("23日")]
        twenty_three_days,
        [EnumDisplayName("24日")]
        twenty_four_days,
        [EnumDisplayName("25日")]
        twenty_five_days,
        [EnumDisplayName("26日")]
        twenty_six_days,
        [EnumDisplayName("27日")]
        twenty_seven_days,
        [EnumDisplayName("28日")]
        twenty_eight_days,
        [EnumDisplayName("末締め")]
        last_day,
    }
}
