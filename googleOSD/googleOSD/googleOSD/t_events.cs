//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoogleOSD
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_events
    {
        public int Id { get; set; }
        public int m_contract_id { get; set; }
        public int t_project_base_id { get; set; }
		public int event_type { get; set; }
        public DateTime event_date_start { get; set; }
        public int event_time_start { get; set; }
        public DateTime event_date_end { get; set; }
        public int event_time_end { get; set; }
        public bool event_is_daylong { get; set; }
        public string event_title { get; set; }
        public string event_place { get; set; }
        public string event_memo { get; set; }
        public bool event_status { get; set; }
        public string google_id { get; set; }
        public string event_bg_color { get; set; }
        public string event_font_color { get; set; }
        public DateTime modifier_on { get; set; }
        public DateTime deleted_on { get; set; }
    }
}
