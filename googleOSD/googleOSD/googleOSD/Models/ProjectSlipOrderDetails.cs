using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 案件情報伝票（発注書明細）
	/// </summary>
	public partial class ProjectSlipOrderDetails{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///発注書ヘッダID :=案件情報伝票（発注書ヘッダ）.ID
		public int t_project_slip_order_headers_id { get; set; }
		///行番号
		public int col_number { get; set; }
		///見出し :0：見出し以外、1：見出し
		public bool heading_flag { get; set; }
		///区分 :※固定値定義書：A-5.明細の区分
		public int name_type { get; set; }
		///場所
		public string event_place { get; set; }
		///箇所
		public string place { get; set; }
		///自社品番
		public string product_cd { get; set; }
		///メーカー品番
		public string maker_cd { get; set; }
		///メーカー名
		public string maker_name { get; set; }
		///商品ID :=商品マスタ.ID
		public int m_product_id { get; set; }
		///品名
		public string product_name { get; set; }
		///規格
		public string standard { get; set; }
		///品種ID :=品種マスタ．ID
		public int m_varietie_id { get; set; }
		///品種名
		public string variety_name { get; set; }
		///数量
		public decimal quantity { get; set; }
		///単位名 :=システム関連名称マスタ.ID　（区分=2)
		public string unit_name { get; set; }
		///単価
		public decimal price { get; set; }
		///金額
		public decimal amount { get; set; }
		///備考
		public string remark { get; set; }
		///販売上代（税抜）
		public decimal sales_retail_price_tax_excluded { get; set; }
		///掛率
		public decimal rate { get; set; }
		///消費税ID :=消費税マスタ．ID
		public int m_tax_id { get; set; }
		///税率
		public decimal tax_rate { get; set; }
		///法廷歩掛率
		public decimal court_productivity_rate { get; set; }
		///消費税
		public decimal tax_amount { get; set; }
		///表示フラグ :0：非表示、1：表示
		public bool display_flag { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }
		///削除日時:
		public DateTime deleted_at { get; set; }
	}

	public class ProjectSlipOrderDetailsCollection : ObservableCollection<ProjectSlipOrderDetails> {
		public ProjectSlipOrderDetailsCollection(){
		}
	}
}
