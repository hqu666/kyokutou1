using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// イベント
	/// </summary>
	public partial class Events{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///案件ID :=案件情報.ID
		public int t_project_base_id { get; set; }
		///イベント種別 :※固定値：イベント種別
		public int event_type { get; set; }
		///イベント開始日 :未登録案件はnull
		public DateTime event_date_start { get; set; }
		///イベント開始時刻 :※固定値：イベント時刻
		public int event_time_start { get; set; }
		///イベント終了日
		public DateTime event_date_end { get; set; }
		///イベント終了時刻 :※固定値：イベント時刻
		public int event_time_end { get; set; }
		///終日
		public int event_is_daylong { get; set; }
		///タイトル
		public string event_title { get; set; }
		///場所
		public string event_place { get; set; }
		///メモ
		public string event_memo { get; set; }
		///ステータス :※固定値：イベントステータス
		public int event_status { get; set; }
		///GoogleイベントID
		public string google_id { get; set; }
		///背景色 :※固定値：カラーもしくはARGB値（９桁）
		public string event_bg_color { get; set; }
		///文字色 :ARGB値（９桁：カラーピッカーによっては透明度が付与される）
		public string event_font_color { get; set; }
		///作成者
		public int creater { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int modifier { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class EventsCollection : ObservableCollection<Events> {
		public EventsCollection(){
		}
	}
}
