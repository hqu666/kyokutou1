using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 案件情報伝票（発注書明細）
	/// </summary>
	public partial class ProjectSlipOrderDetails
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
			}
		}

		///<summary>
		///契約ID :=契約マスタ.ID
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
			}
		}

		///<summary>
		///発注書ヘッダID :=案件情報伝票（発注書ヘッダ）.ID
		///</summary>
		private int _t_project_slip_order_headers_id;
		public int t_project_slip_order_headers_id
		{
			get => _t_project_slip_order_headers_id;
			set
			{
				if (_t_project_slip_order_headers_id == value)
					return;
				_t_project_slip_order_headers_id = value;
			}
		}

		///<summary>
		///行番号
		///</summary>
		private int _col_number;
		public int col_number
		{
			get => _col_number;
			set
			{
				if (_col_number == value)
					return;
				_col_number = value;
			}
		}

		///<summary>
		///見出し :0：見出し以外、1：見出し
		///</summary>
		private bool _heading_flag;
		public bool heading_flag
		{
			get => _heading_flag;
			set
			{
				if (_heading_flag == value)
					return;
				_heading_flag = value;
			}
		}

		///<summary>
		///区分 :※固定値定義書：A-5.明細の区分
		///</summary>
		private int _name_type;
		public int name_type
		{
			get => _name_type;
			set
			{
				if (_name_type == value)
					return;
				_name_type = value;
			}
		}

		///<summary>
		///場所
		///</summary>
		private string _event_place;
		public string event_place
		{
			get => _event_place;
			set
			{
				if (_event_place == value)
					return;
				_event_place = value;
			}
		}

		///<summary>
		///箇所
		///</summary>
		private string _place;
		public string place
		{
			get => _place;
			set
			{
				if (_place == value)
					return;
				_place = value;
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
			}
		}

		///<summary>
		///メーカー名
		///</summary>
		private string _maker_name;
		public string maker_name
		{
			get => _maker_name;
			set
			{
				if (_maker_name == value)
					return;
				_maker_name = value;
			}
		}

		///<summary>
		///商品ID :=商品マスタ.ID
		///</summary>
		private int _m_product_id;
		public int m_product_id
		{
			get => _m_product_id;
			set
			{
				if (_m_product_id == value)
					return;
				_m_product_id = value;
			}
		}

		///<summary>
		///品名
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
			}
		}

		///<summary>
		///品種ID :=品種マスタ．ID
		///</summary>
		private int _m_varietie_id;
		public int m_varietie_id
		{
			get => _m_varietie_id;
			set
			{
				if (_m_varietie_id == value)
					return;
				_m_varietie_id = value;
			}
		}

		///<summary>
		///品種名
		///</summary>
		private string _variety_name;
		public string variety_name
		{
			get => _variety_name;
			set
			{
				if (_variety_name == value)
					return;
				_variety_name = value;
			}
		}

		///<summary>
		///数量
		///</summary>
		private decimal _quantity;
		public decimal quantity
		{
			get => _quantity;
			set
			{
				if (_quantity == value)
					return;
				_quantity = value;
			}
		}

		///<summary>
		///単位名 :=システム関連名称マスタ.ID　（区分=2)
		///</summary>
		private string _unit_name;
		public string unit_name
		{
			get => _unit_name;
			set
			{
				if (_unit_name == value)
					return;
				_unit_name = value;
			}
		}

		///<summary>
		///単価
		///</summary>
		private decimal _price;
		public decimal price
		{
			get => _price;
			set
			{
				if (_price == value)
					return;
				_price = value;
			}
		}

		///<summary>
		///金額
		///</summary>
		private decimal _amount;
		public decimal amount
		{
			get => _amount;
			set
			{
				if (_amount == value)
					return;
				_amount = value;
			}
		}

		///<summary>
		///備考
		///</summary>
		private string _remark;
		public string remark
		{
			get => _remark;
			set
			{
				if (_remark == value)
					return;
				_remark = value;
			}
		}

		///<summary>
		///販売上代（税抜）
		///</summary>
		private decimal _sales_retail_price_tax_excluded;
		public decimal sales_retail_price_tax_excluded
		{
			get => _sales_retail_price_tax_excluded;
			set
			{
				if (_sales_retail_price_tax_excluded == value)
					return;
				_sales_retail_price_tax_excluded = value;
			}
		}

		///<summary>
		///掛率
		///</summary>
		private decimal _rate;
		public decimal rate
		{
			get => _rate;
			set
			{
				if (_rate == value)
					return;
				_rate = value;
			}
		}

		///<summary>
		///消費税ID :=消費税マスタ．ID
		///</summary>
		private int _m_tax_id;
		public int m_tax_id
		{
			get => _m_tax_id;
			set
			{
				if (_m_tax_id == value)
					return;
				_m_tax_id = value;
			}
		}

		///<summary>
		///税率
		///</summary>
		private decimal _tax_rate;
		public decimal tax_rate
		{
			get => _tax_rate;
			set
			{
				if (_tax_rate == value)
					return;
				_tax_rate = value;
			}
		}

		///<summary>
		///法廷歩掛率
		///</summary>
		private decimal _court_productivity_rate;
		public decimal court_productivity_rate
		{
			get => _court_productivity_rate;
			set
			{
				if (_court_productivity_rate == value)
					return;
				_court_productivity_rate = value;
			}
		}

		///<summary>
		///消費税
		///</summary>
		private decimal _tax_amount;
		public decimal tax_amount
		{
			get => _tax_amount;
			set
			{
				if (_tax_amount == value)
					return;
				_tax_amount = value;
			}
		}

		///<summary>
		///表示フラグ :0：非表示、1：表示
		///</summary>
		private bool _display_flag;
		public bool display_flag
		{
			get => _display_flag;
			set
			{
				if (_display_flag == value)
					return;
				_display_flag = value;
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
			}
		}

	}


	public class ProjectSlipOrderDetailsCollection : ObservableCollection<ProjectSlipOrderDetails> {
		public ProjectSlipOrderDetailsCollection(){
		}
	}
}
