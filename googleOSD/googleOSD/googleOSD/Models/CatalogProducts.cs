using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// J^O¤i}X^
	/// </summary>
	public partial class CatalogProducts{
		///ID
		public int id { get; set; }
		///iíæª :¦ÅèlFiíæª
		public int variety_type { get; set; }
		///[J[iÔ
		public string maker_cd { get; set; }
		///¤i¼
		public string product_name { get; set; }
		///¤iJi
		public string product_kana { get; set; }
		///¤iªÌ
		public string product_abbreviation { get; set; }
		///Ki
		public string standard { get; set; }
		///JANR[h
		public string jan_code { get; set; }
		///Ì¿iFÌããiÅ²j
		public decimal retail_price_tax_excluded { get; set; }
		///Ì¿iFÌããiÅj
		public decimal retail_price_tax_included { get; set; }
		///Ì¿iFããP¿iÅ²j
		public decimal retail_price_unit_price_tax_excluded { get; set; }
		///Ì¿iFããP¿iÅj
		public decimal retail_price_unit_price_tax_included { get; set; }
		///Ì¿iFÌP¿iÅ²j :¦ÅèlFÛÅæª
		public decimal sale_price_tax_excluded { get; set; }
		///Ì¿iFÌP¿iÅj
		public decimal sale_price_tax_included { get; set; }
		///Ì¿iFÛÅæª
		public int tax_classification { get; set; }
		///dü¿iFdüããiÅ²j
		public decimal purchase_price_tax_excluded { get; set; }
		///dü¿iFdüããiÅj
		public decimal purchase_price_tax_included { get; set; }
		///dü¿iFããP¿iÅ²j
		public decimal purchase_price_unit_price_tax_excluded { get; set; }
		///dü¿iFããP¿iÅj
		public decimal purchase_price_unit_price_tax_included { get; set; }
		///dü¿iFPÊ
		public int purchase_unit { get; set; }
		///dü¿iF´¿P¿ :¦ÅèlFÛÅæª
		public decimal cost_unit_price { get; set; }
		///dü¿iFÅá­
		public decimal minimum_order_quantity { get; set; }
		///dü¿iFPÊü
		public int quantity { get; set; }
		///QlP¿
		public decimal reference_unit_price { get; set; }
		///vÚFNXENbVtAFLøÐ :cr=Cross
		public int cr_effective_width { get; set; }
		///vÚFNXENbVtAFwüPÊ
		public int cr_buy_unit { get; set; }
		///vÚFNXENbVtAFs[g
		public int cr_repeat { get; set; }
		///vÚFNXENbVtAFØèã
		public int cr_cutting_allowance { get; set; }
		///vÚFÐØFLøÐ :bb=Baseboard
		public int bb_effective_width { get; set; }
		///vÚFÐØFØèã
		public int bb_cutting_allowance { get; set; }
		///vÚFÐØFP[Xüè
		public int bb_case_quantity { get; set; }
		///vÚFo^CE^CJ[ybgFÐ :pt= P tile
		public int pt_width { get; set; }
		///vÚFo^CE^CJ[ybgF·³
		public int pt_length { get; set; }
		///vÚFo^CE^CJ[ybgFÅ¬JbgÐ
		public int pt_min_cut_width { get; set; }
		///vÚFo^CE^CJ[ybgFP[Xüè
		public int pt_case_quantity { get; set; }
		///vÚFo^CE^CJ[ybgFuÝÈµ
		public int pt_deemed_quantity { get; set; }
		///J^O}X^ID :=J^O}X^DID
		public int m_catalog_id { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬ú:
		public DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XVú:
		public DateTime updated_at { get; set; }
		///íú:
		public DateTime deleted_at { get; set; }
	}

	public class CatalogProductsCollection : ObservableCollection<CatalogProducts> {
		public CatalogProductsCollection(){
		}
	}
}
