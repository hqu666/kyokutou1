using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 商品マスタ
	/// </summary>
	public partial class m_products : NotificationObject
	{

		///<summary>
		///ID
		///</summary>
		private int _id;
		public int id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///契約ID :=契約情報.ID
		///</summary>
		private int _m_contract_id;
		public int m_contract_id
		{
			get => _m_contract_id;
			set
			{
				if (_m_contract_id == value)
					return;
				_m_contract_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///自社品番
		///</summary>
		private string _product_cd;
		public string product_cd
		{
			get => _product_cd;
			set
			{
				if (_product_cd == value)
					return;
				_product_cd = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///メーカー品番
		///</summary>
		private string _maker_cd;
		public string maker_cd
		{
			get => _maker_cd;
			set
			{
				if (_maker_cd == value)
					return;
				_maker_cd = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///商品名
		///</summary>
		private string _product_name;
		public string product_name
		{
			get => _product_name;
			set
			{
				if (_product_name == value)
					return;
				_product_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///商品カナ
		///</summary>
		private string _product_kana;
		public string product_kana
		{
			get => _product_kana;
			set
			{
				if (_product_kana == value)
					return;
				_product_kana = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///商品略称
		///</summary>
		private string _product_abbreviation;
		public string product_abbreviation
		{
			get => _product_abbreviation;
			set
			{
				if (_product_abbreviation == value)
					return;
				_product_abbreviation = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///規格
		///</summary>
		private string _standard;
		public string standard
		{
			get => _standard;
			set
			{
				if (_standard == value)
					return;
				_standard = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///単位 :=システム関連名称マスタ.ID　（区分=2)
		///</summary>
		private int _unit;
		public int unit
		{
			get => _unit;
			set
			{
				if (_unit == value)
					return;
				_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///JANコード
		///</summary>
		private string _jan_code;
		public string jan_code
		{
			get => _jan_code;
			set
			{
				if (_jan_code == value)
					return;
				_jan_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///メーカー :=システム関連名称マスタ.ID　（区分=1)
		///</summary>
		private int _maker_id;
		public int maker_id
		{
			get => _maker_id;
			set
			{
				if (_maker_id == value)
					return;
				_maker_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///品種 :=品種マスタ.ID
		///</summary>
		private int _m_variety_id;
		public int m_variety_id
		{
			get => _m_variety_id;
			set
			{
				if (_m_variety_id == value)
					return;
				_m_variety_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///標準仕入先 :=取引先マスタ.ID
		///</summary>
		private int _standard_supplier_id;
		public int standard_supplier_id
		{
			get => _standard_supplier_id;
			set
			{
				if (_standard_supplier_id == value)
					return;
				_standard_supplier_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///商品マスタ集計区分1 :=集計区分名称マスタ.ID　（区分=5)
		///</summary>
		private int _products_aggregation_category1;
		public int products_aggregation_category1
		{
			get => _products_aggregation_category1;
			set
			{
				if (_products_aggregation_category1 == value)
					return;
				_products_aggregation_category1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///商品マスタ集計区分2 :=集計区分名称マスタ.ID　（区分=6)
		///</summary>
		private int _products_aggregation_category2;
		public int products_aggregation_category2
		{
			get => _products_aggregation_category2;
			set
			{
				if (_products_aggregation_category2 == value)
					return;
				_products_aggregation_category2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///発注データ作成フラグ
		///</summary>
		private int _order_data_flag;
		public int order_data_flag
		{
			get => _order_data_flag;
			set
			{
				if (_order_data_flag == value)
					return;
				_order_data_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///過剰発注アラートフラグ
		///</summary>
		private int _over_order_alert_flag;
		public int over_order_alert_flag
		{
			get => _over_order_alert_flag;
			set
			{
				if (_over_order_alert_flag == value)
					return;
				_over_order_alert_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売フラグ
		///</summary>
		private int _sale_flag;
		public int sale_flag
		{
			get => _sale_flag;
			set
			{
				if (_sale_flag == value)
					return;
				_sale_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入フラグ
		///</summary>
		private int _purchase_flag;
		public int purchase_flag
		{
			get => _purchase_flag;
			set
			{
				if (_purchase_flag == value)
					return;
				_purchase_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売価格：販売上代（税抜）
		///</summary>
		private decimal _retail_price_tax_excluded;
		public decimal retail_price_tax_excluded
		{
			get => _retail_price_tax_excluded;
			set
			{
				if (_retail_price_tax_excluded == value)
					return;
				_retail_price_tax_excluded = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売価格：販売上代（税込）
		///</summary>
		private decimal _retail_price_tax_included;
		public decimal retail_price_tax_included
		{
			get => _retail_price_tax_included;
			set
			{
				if (_retail_price_tax_included == value)
					return;
				_retail_price_tax_included = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売価格：上代単価（税抜）
		///</summary>
		private decimal _retail_price_unit_price_tax_excluded;
		public decimal retail_price_unit_price_tax_excluded
		{
			get => _retail_price_unit_price_tax_excluded;
			set
			{
				if (_retail_price_unit_price_tax_excluded == value)
					return;
				_retail_price_unit_price_tax_excluded = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売価格：上代単価（税込）
		///</summary>
		private decimal _retail_price_unit_price_tax_included;
		public decimal retail_price_unit_price_tax_included
		{
			get => _retail_price_unit_price_tax_included;
			set
			{
				if (_retail_price_unit_price_tax_included == value)
					return;
				_retail_price_unit_price_tax_included = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売価格：販売単価（税抜）
		///</summary>
		private decimal _sale_price_tax_excluded;
		public decimal sale_price_tax_excluded
		{
			get => _sale_price_tax_excluded;
			set
			{
				if (_sale_price_tax_excluded == value)
					return;
				_sale_price_tax_excluded = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売価格：販売単価（税込）
		///</summary>
		private decimal _sale_price_tax_included;
		public decimal sale_price_tax_included
		{
			get => _sale_price_tax_included;
			set
			{
				if (_sale_price_tax_included == value)
					return;
				_sale_price_tax_included = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///販売価格：課税区分 :※固定値：課税区分
		///</summary>
		private int _tax_classification;
		public int tax_classification
		{
			get => _tax_classification;
			set
			{
				if (_tax_classification == value)
					return;
				_tax_classification = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：仕入上代（税抜）
		///</summary>
		private decimal _purchase_price_tax_excluded;
		public decimal purchase_price_tax_excluded
		{
			get => _purchase_price_tax_excluded;
			set
			{
				if (_purchase_price_tax_excluded == value)
					return;
				_purchase_price_tax_excluded = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：仕入上代（税込）
		///</summary>
		private decimal _purchase_price_tax_included;
		public decimal purchase_price_tax_included
		{
			get => _purchase_price_tax_included;
			set
			{
				if (_purchase_price_tax_included == value)
					return;
				_purchase_price_tax_included = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：上代単価（税抜）
		///</summary>
		private decimal _purchase_price_unit_price_tax_excluded;
		public decimal purchase_price_unit_price_tax_excluded
		{
			get => _purchase_price_unit_price_tax_excluded;
			set
			{
				if (_purchase_price_unit_price_tax_excluded == value)
					return;
				_purchase_price_unit_price_tax_excluded = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：上代単価（税込）
		///</summary>
		private decimal _purchase_price_unit_price_tax_included;
		public decimal purchase_price_unit_price_tax_included
		{
			get => _purchase_price_unit_price_tax_included;
			set
			{
				if (_purchase_price_unit_price_tax_included == value)
					return;
				_purchase_price_unit_price_tax_included = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：単位
		///</summary>
		private int _purchase_unit;
		public int purchase_unit
		{
			get => _purchase_unit;
			set
			{
				if (_purchase_unit == value)
					return;
				_purchase_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：原価単価（材料）
		///</summary>
		private decimal _cost_unit_price_material;
		public decimal cost_unit_price_material
		{
			get => _cost_unit_price_material;
			set
			{
				if (_cost_unit_price_material == value)
					return;
				_cost_unit_price_material = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：原価単価（作業）
		///</summary>
		private decimal _cost_unit_price_work;
		public decimal cost_unit_price_work
		{
			get => _cost_unit_price_work;
			set
			{
				if (_cost_unit_price_work == value)
					return;
				_cost_unit_price_work = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：原価単価（その他）
		///</summary>
		private decimal _cost_unit_price_other;
		public decimal cost_unit_price_other
		{
			get => _cost_unit_price_other;
			set
			{
				if (_cost_unit_price_other == value)
					return;
				_cost_unit_price_other = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：最低発注数
		///</summary>
		private decimal _minimum_order_quantity;
		public decimal minimum_order_quantity
		{
			get => _minimum_order_quantity;
			set
			{
				if (_minimum_order_quantity == value)
					return;
				_minimum_order_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入価格：単位当入数
		///</summary>
		private int _quantity;
		public int quantity
		{
			get => _quantity;
			set
			{
				if (_quantity == value)
					return;
				_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///参考単価
		///</summary>
		private decimal _reference_unit_price;
		public decimal reference_unit_price
		{
			get => _reference_unit_price;
			set
			{
				if (_reference_unit_price == value)
					return;
				_reference_unit_price = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：クロス・クッションフロア：有効巾 :cr=Cross
		///</summary>
		private int _cr_effective_width;
		public int cr_effective_width
		{
			get => _cr_effective_width;
			set
			{
				if (_cr_effective_width == value)
					return;
				_cr_effective_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：クロス・クッションフロア：購入単位
		///</summary>
		private int _cr_buy_unit;
		public int cr_buy_unit
		{
			get => _cr_buy_unit;
			set
			{
				if (_cr_buy_unit == value)
					return;
				_cr_buy_unit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：クロス・クッションフロア：リピート
		///</summary>
		private int _cr_repeat;
		public int cr_repeat
		{
			get => _cr_repeat;
			set
			{
				if (_cr_repeat == value)
					return;
				_cr_repeat = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：クロス・クッションフロア：切り代
		///</summary>
		private int _cr_cutting_allowance;
		public int cr_cutting_allowance
		{
			get => _cr_cutting_allowance;
			set
			{
				if (_cr_cutting_allowance == value)
					return;
				_cr_cutting_allowance = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：巾木：有効巾 :bb=Baseboard
		///</summary>
		private int _bb_effective_width;
		public int bb_effective_width
		{
			get => _bb_effective_width;
			set
			{
				if (_bb_effective_width == value)
					return;
				_bb_effective_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：巾木：切り代
		///</summary>
		private int _bb_cutting_allowance;
		public int bb_cutting_allowance
		{
			get => _bb_cutting_allowance;
			set
			{
				if (_bb_cutting_allowance == value)
					return;
				_bb_cutting_allowance = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：巾木：ケース入り数
		///</summary>
		private int _bb_case_quantity;
		public int bb_case_quantity
		{
			get => _bb_case_quantity;
			set
			{
				if (_bb_case_quantity == value)
					return;
				_bb_case_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：Ｐタイル・タイルカーペット：巾 :pt= P tile
		///</summary>
		private int _pt_width;
		public int pt_width
		{
			get => _pt_width;
			set
			{
				if (_pt_width == value)
					return;
				_pt_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：Ｐタイル・タイルカーペット：長さ
		///</summary>
		private int _pt_length;
		public int pt_length
		{
			get => _pt_length;
			set
			{
				if (_pt_length == value)
					return;
				_pt_length = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：Ｐタイル・タイルカーペット：最小カット巾
		///</summary>
		private int _pt_min_cut_width;
		public int pt_min_cut_width
		{
			get => _pt_min_cut_width;
			set
			{
				if (_pt_min_cut_width == value)
					return;
				_pt_min_cut_width = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：Ｐタイル・タイルカーペット：ケース入り数
		///</summary>
		private int _pt_case_quantity;
		public int pt_case_quantity
		{
			get => _pt_case_quantity;
			set
			{
				if (_pt_case_quantity == value)
					return;
				_pt_case_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///要尺：Ｐタイル・タイルカーペット：㎡当みなし枚数
		///</summary>
		private int _pt_deemed_quantity;
		public int pt_deemed_quantity
		{
			get => _pt_deemed_quantity;
			set
			{
				if (_pt_deemed_quantity == value)
					return;
				_pt_deemed_quantity = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///必要係数：原価1
		///</summary>
		private float _required_factor_cost_1;
		public float required_factor_cost_1
		{
			get => _required_factor_cost_1;
			set
			{
				if (_required_factor_cost_1 == value)
					return;
				_required_factor_cost_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///必要係数：原価2
		///</summary>
		private float _required_factor_cost_2;
		public float required_factor_cost_2
		{
			get => _required_factor_cost_2;
			set
			{
				if (_required_factor_cost_2 == value)
					return;
				_required_factor_cost_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///必要係数：原価3
		///</summary>
		private float _required_factor_cost_3;
		public float required_factor_cost_3
		{
			get => _required_factor_cost_3;
			set
			{
				if (_required_factor_cost_3 == value)
					return;
				_required_factor_cost_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///廃番フラグ
		///</summary>
		private int _discontinued_flag;
		public int discontinued_flag
		{
			get => _discontinued_flag;
			set
			{
				if (_discontinued_flag == value)
					return;
				_discontinued_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///カタログ商品ID :=カタログ商品マスタ.ID
		///</summary>
		private int _m_catalog_product_id;
		public int m_catalog_product_id
		{
			get => _m_catalog_product_id;
			set
			{
				if (_m_catalog_product_id == value)
					return;
				_m_catalog_product_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ステータス :0：仮登録、1：本登録
		///</summary>
		private int _status;
		public int status
		{
			get => _status;
			set
			{
				if (_status == value)
					return;
				_status = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///平均歩掛率
		///</summary>
		private decimal _average_productivity_rate;
		public decimal average_productivity_rate
		{
			get => _average_productivity_rate;
			set
			{
				if (_average_productivity_rate == value)
					return;
				_average_productivity_rate = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///作成者
		///</summary>
		private int _created_user;
		public int created_user
		{
			get => _created_user;
			set
			{
				if (_created_user == value)
					return;
				_created_user = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///作成日時
		///</summary>
		private DateTime _created_at;
		public DateTime created_at
		{
			get => _created_at;
			set
			{
				if (_created_at == value)
					return;
				_created_at = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///更新者
		///</summary>
		private int _updated_user;
		public int updated_user
		{
			get => _updated_user;
			set
			{
				if (_updated_user == value)
					return;
				_updated_user = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///更新日時
		///</summary>
		private DateTime _updated_at;
		public DateTime updated_at
		{
			get => _updated_at;
			set
			{
				if (_updated_at == value)
					return;
				_updated_at = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///削除日時
		///</summary>
		private DateTime _deleted_at;
		public DateTime deleted_at
		{
			get => _deleted_at;
			set
			{
				if (_deleted_at == value)
					return;
				_deleted_at = value;
				RaisePropertyChanged();
			}
		}

	}


	public class m_productsCollection : ObservableCollection<m_products> {
		public m_productsCollection(){
		}
	}
}
