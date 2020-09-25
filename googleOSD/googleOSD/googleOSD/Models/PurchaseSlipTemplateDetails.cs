using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// wîñ`[iev[g¾×j
	/// </summary>
	public partial class PurchaseSlipTemplateDetails{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///ev[gwb_ID
		public int template_header_id { get; set; }
		///sÔ
		public int col_number { get; set; }
		///æª
		public int name_type { get; set; }
		///ê
		public string event_place { get; set; }
		///Ó
		public string place { get; set; }
		///©ÐiÔ
		public string product_cd { get; set; }
		///[J[iÔ
		public string maker_cd { get; set; }
		///[J[¼
		public string maker_name { get; set; }
		///¤iID :=¤i}X^.ID
		public int m_product_id { get; set; }
		///i¼
		public string product_name { get; set; }
		///Ki
		public string standard { get; set; }
		///iíID
		public int m_varietie_id { get; set; }
		///ií¼
		public string variety_name { get; set; }
		///Ê
		public decimal quantity { get; set; }
		///PÊ¼ :=VXeÖA¼Ì}X^.ID@iæª=2)
		public string unit_name { get; set; }
		///P¿
		public decimal price { get; set; }
		///àz
		public decimal amount { get; set; }
		///õl
		public string remark { get; set; }
		///ÌããiÅ²j
		public decimal sales_retail_price_tax_excluded { get; set; }
		///|¦
		public decimal rate { get; set; }
		///ÁïÅID
		public int m_tax_id { get; set; }
		///Å¦
		public decimal tax_rate { get; set; }
		///@ìà|¦
		public decimal court_productivity_rate { get; set; }
		///ÁïÅ
		public decimal tax_amount { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬ú:
		DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XVú:
		DateTime updated_at { get; set; }
		///íú:
		DateTime deleted_at { get; set; }
	}

	public class PurchaseSlipTemplateDetailsCollection : ObservableCollection<PurchaseSlipTemplateDetails> {
		public PurchaseSlipTemplateDetailsCollection(){
		}
	}
}
