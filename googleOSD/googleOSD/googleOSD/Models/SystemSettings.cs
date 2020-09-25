using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// システム設定
	/// </summary>
	public partial class SystemSettings{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///原価タブ名称1
		public string cost_tab_name1 { get; set; }
		///原価タブ名称2
		public string cost_tab_name2 { get; set; }
		///原価タブ名称3
		public string cost_tab_name3 { get; set; }
		///伝票ヘッダ集計区分名称1
		public string slip_header_aggregate_name1 { get; set; }
		///伝票ヘッダ集計区分名称2
		public string slip_header_aggregate_name2 { get; set; }
		///伝票ヘッダ集計区分名称3
		public string slip_header_aggregate_name3 { get; set; }
		///伝票ヘッダ集計区分名称4
		public string slip_header_aggregate_name4 { get; set; }
		///商品マスタ集計区分名称1
		public string product_aggregate_name1 { get; set; }
		///商品マスタ集計区分名称2
		public string product_aggregate_name2 { get; set; }
		///顧客マスタ集計区分名称1
		public string client_aggregate_name1 { get; set; }
		///顧客マスタ集計区分名称2
		public string client_aggregate_name2 { get; set; }
		///顧客マスタ集計区分名称3
		public string client_aggregate_name3 { get; set; }
		///顧客マスタ集計区分名称4
		public string client_aggregate_name4 { get; set; }
		///顧客マスタ集計区分名称5
		public string client_aggregate_name5 { get; set; }
		///物件管理フラグ
		public int property_management_flag { get; set; }
		///原価フラグ
		public int cost_function_flag { get; set; }
		///要尺機能フラグ
		public int width_function_flag { get; set; }
		///部門フラグ :0：部門無し、1：部門あり
		public int department_flag { get; set; }
		///単価掛率設定得意先最大件数
		public int supplier_price_rates_max_count { get; set; }
		///単価掛率設定商品最大件数
		public int product_price_rates_max_count { get; set; }
		///ルートパス :案件基本情報(ks009)や、物件マスタ(ks022)の「ファイル添付」でGoogle連携していない時
		public string root_path { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class SystemSettingsCollection : ObservableCollection<SystemSettings> {
		public SystemSettingsCollection(){
		}
	}
}
