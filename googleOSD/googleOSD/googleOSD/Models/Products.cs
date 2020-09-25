using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 商品マスタ
	/// </summary>
	public partial class Products{
		///ID
		public int id { get; set; }
		///契約ID :=契約情報.ID
		public int m_contract_id { get; set; }
		///自社品番
		public string product_cd { get; set; }
		///メーカー品番
		public string maker_cd { get; set; }
		///商品名
		public string product_name { get; set; }
		///商品カナ
		public string product_kana { get; set; }
		///商品略称
		public string product_abbreviation { get; set; }
		///規格
		public string standard { get; set; }
		///単位 :=システム関連名称マスタ.ID　（区分=2)
		public int unit { get; set; }
		///JANコード
		public string jan_code { get; set; }
		///メーカー :=システム関連名称マスタ.ID　（区分=1)
		public int maker_id { get; set; }
		///品種 :=品種マスタ.ID
		public int m_varietie_id { get; set; }
		///標準仕入先 :=取引先マスタ.ID
		public int standard_supplier_id { get; set; }
		///商品マスタ集計区分1 :=集計区分名称マスタ.ID　（区分=5)
		public int products_aggregation_category1 { get; set; }
		///商品マスタ集計区分2 :=集計区分名称マスタ.ID　（区分=6)
		public int products_aggregation_category2 { get; set; }
		///発注データ作成フラグ
		public int order_data_flag { get; set; }
		///過剰発注アラートフラグ
		public int over_order_alert_flag { get; set; }
		///販売フラグ
		public int sale_flag { get; set; }
		///仕入フラグ
		public int purchase_flag { get; set; }
		///販売価格：販売上代（税抜）
		public decimal retail_price_tax_excluded { get; set; }
		///販売価格：販売上代（税込）
		public decimal retail_price_tax_included { get; set; }
		///販売価格：上代単価（税抜）
		public decimal retail_price_unit_price_tax_excluded { get; set; }
		///販売価格：上代単価（税込）
		public decimal retail_price_unit_price_tax_included { get; set; }
		///販売価格：販売単価（税抜）
		public decimal sale_price_tax_excluded { get; set; }
		///販売価格：販売単価（税込）
		public decimal sale_price_tax_included { get; set; }
		///販売価格：課税区分 :※固定値：課税区分
		public int tax_classification { get; set; }
		///仕入価格：仕入上代（税抜）
		public decimal purchase_price_tax_excluded { get; set; }
		///仕入価格：仕入上代（税込）
		public decimal purchase_price_tax_included { get; set; }
		///仕入価格：上代単価（税抜）
		public decimal purchase_price_unit_price_tax_excluded { get; set; }
		///仕入価格：上代単価（税込）
		public decimal purchase_price_unit_price_tax_included { get; set; }
		///仕入価格：単位
		public int purchase_unit { get; set; }
		///仕入価格：原価単価
		public decimal cost_unit_price { get; set; }
		///仕入価格：最低発注数
		public decimal minimum_order_quantity { get; set; }
		///仕入価格：単位当入数
		public int quantity { get; set; }
		///参考単価
		public decimal reference_unit_price { get; set; }
		///要尺：クロス・クッションフロア：有効巾 :cr=Cross
		public int cr_effective_width { get; set; }
		///要尺：クロス・クッションフロア：購入単位
		public int cr_buy_unit { get; set; }
		///要尺：クロス・クッションフロア：リピート
		public int cr_repeat { get; set; }
		///要尺：クロス・クッションフロア：切り代
		public int cr_cutting_allowance { get; set; }
		///要尺：巾木：有効巾 :bb=Baseboard
		public int bb_effective_width { get; set; }
		///要尺：巾木：切り代
		public int bb_cutting_allowance { get; set; }
		///要尺：巾木：ケース入り数
		public int bb_case_quantity { get; set; }
		///要尺：Ｐタイル・タイルカーペット：巾 :pt= P tile
		public int pt_width { get; set; }
		///要尺：Ｐタイル・タイルカーペット：長さ
		public int pt_length { get; set; }
		///要尺：Ｐタイル・タイルカーペット：最小カット巾
		public int pt_min_cut_width { get; set; }
		///要尺：Ｐタイル・タイルカーペット：ケース入り数
		public int pt_case_quantity { get; set; }
		///要尺：Ｐタイル・タイルカーペット：㎡当みなし枚数
		public int pt_deemed_quantity { get; set; }
		///必要係数：原価1
		public float required_factor_cost_1 { get; set; }
		///必要係数：原価2
		public float required_factor_cost_2 { get; set; }
		///必要係数：原価3
		public float required_factor_cost_3 { get; set; }
		///廃番フラグ
		public int discontinued_flag { get; set; }
		///カタログ商品ID :=カタログ商品マスタ.ID
		public int m_catalog_product_id { get; set; }
		///ステータス :0：仮登録、1：本登録
		public int status { get; set; }
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

	public class ProductsCollection : ObservableCollection<Products> {
		public ProductsCollection(){
		}
	}
}
