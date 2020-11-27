using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TabCon.Enums
{
    /// <summary>
    /// カラー
	/// カラーピッカー出力によりARGBに変更
	/// index1以降はGoogleCalenderの背景色に準拠
    /// </summary>
    [TypeConverter(typeof(EnumDisplayNameConverter))]
    public enum Z03Color {
        [EnumDisplayName("白")]
		sFFFFFF,
		[EnumDisplayName("ラベンダー")] 
		s7986CB,
		[EnumDisplayName("セージ")]
		s01B679,
		[EnumDisplayName("ブドウ")]
        s8E24AA,
        [EnumDisplayName("フラミンゴ")]
		sE67C73,
        [EnumDisplayName("バナナ")]
		sF6C028,
        [EnumDisplayName("ミカン")]
		sF4511E,
        [EnumDisplayName("ピーコック")]
        s039BE5,
        [EnumDisplayName("ブルーベリー")]
        s3F51B5,
		[EnumDisplayName("グラファイト")]
		s616161,
		[EnumDisplayName("バジル")]
		s0B8043,
		[EnumDisplayName("トマト")]
		sD50000
	}
}
