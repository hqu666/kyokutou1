using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 取込項目設定
	/// </summary>
	public partial class ImportItemSettings{
		///ID
		public int id { get; set; }
		///取込設定：メーカー品番 :if=ImportFlag
		public int if_maker_cd { get; set; }
		///取込設定：商品名
		public int if_product_name { get; set; }
		///取込設定：商品カナ
		public int if_product_kana { get; set; }
		///取込設定：商品略称
		public int if_product_abbreviation { get; set; }
		///取込設定：規格
		public int if_standard { get; set; }
		///取込設定：単位
		public int if_unit { get; set; }
		///取込設定：JANコード
		public int if_jan_code { get; set; }
		///取込設定：メーカー
		public int if_maker_id { get; set; }
		///取込設定：品種
		public int if_m_varietie_id { get; set; }
		///取込設定：標準仕入先
		public int if_standard_supplier_id { get; set; }
		///取込設定：商品マスタ集計区分1
		public int if_products_aggregation_category1 { get; set; }
		///取込設定：商品マスタ集計区分2
		public int if_products_aggregation_category2 { get; set; }
		///取込設定：販売価格：販売上代（税抜）
		public int if_retail_price_tax_excluded { get; set; }
		///取込設定：販売価格：販売上代（税込）
		public int if_retail_price_tax_included { get; set; }
		///取込設定：販売価格：上代単価（税抜）
		public int if_retail_price_unit_price_tax_excluded { get; set; }
		///取込設定：販売価格：上代単価（税込）
		public int if_retail_price_unit_price_tax_included { get; set; }
		///取込設定：販売価格：販売単価（税抜）
		public int if_sale_price_tax_excluded { get; set; }
		///取込設定：販売価格：販売単価（税込）
		public int if_sale_price_tax_included { get; set; }
		///取込設定：販売価格：課税区分
		public int if_tax_classification { get; set; }
		///取込設定：仕入価格：仕入上代（税抜）
		public int if_purchase_price_tax_excluded { get; set; }
		///取込設定：仕入価格：仕入上代（税込）
		public int if_purchase_price_tax_included { get; set; }
		///取込設定：仕入価格：上代単価（税抜）
		public int if_purchase_price_unit_price_tax_excluded { get; set; }
		///取込設定：仕入価格：上代単価（税込）
		public int if_purchase_price_unit_price_tax_included { get; set; }
		///取込設定：仕入価格：単位
		public int if_purchase_unit { get; set; }
		///取込設定：仕入価格：原価単価
		public int if_cost_unit_price { get; set; }
		///取込設定：仕入価格：最低発注数
		public int if_minimum_order_quantity { get; set; }
		///取込設定：仕入価格：単位当入数
		public int if_quantity { get; set; }
		///取込設定：参考単価
		public int if_reference_unit_price { get; set; }
		///取込設定：要尺
		public int if_lengths { get; set; }
		///取込設定：カタログID
		public string if_m_catalog_catalog_id { get; set; }
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

	public class ImportItemSettingsCollection : ObservableCollection<ImportItemSettings> {
		public ImportItemSettingsCollection(){
		}
	}
}
