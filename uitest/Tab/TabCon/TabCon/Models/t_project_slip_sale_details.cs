using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �Č����`�[�i�󒍐������ׁj
	/// </summary>
	public partial class t_project_slip_sale_details : NotificationObject
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
		///�_��ID :=�_��}�X�^.ID
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
		///�󒍏��w�b�_ID :=�Č����`�[�i���Ϗ��w�b�_�j�DID
		///</summary>
		private int _t_project_slip_sale_headers_id;
		public int t_project_slip_sale_headers_id
		{
			get => _t_project_slip_sale_headers_id;
			set
			{
				if (_t_project_slip_sale_headers_id == value)
					return;
				_t_project_slip_sale_headers_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�s�ԍ�
		///</summary>
		private int _row_number;
		public int row_number
		{
			get => _row_number;
			set
			{
				if (_row_number == value)
					return;
				_row_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���o�� :0�F���o���ȊO�A1�F���o��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�敪 :���Œ�l��`���FA-5.���ׂ̋敪
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ꏊ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ӏ�
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���Еi��
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
		///���[�J�[�i��
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
		///���[�J�[��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���iID :=���i�}�X�^�DID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�i��
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
		///�K�i
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
		///�i��ID :=�i��}�X�^�DID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�i�햼
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�P�ʖ� :=�V�X�e���֘A���̃}�X�^.ID�@�i�敪=2)
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�P��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���z
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���l
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�̔����i�Ŕ��j
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�|��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����ID :=����Ń}�X�^�DID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ŗ�
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�@����|��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�\���t���O :0�F��\���A1�F�\��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�쐬��
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
		///�쐬����
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
		///�X�V��
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
		///�X�V����
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
		///�폜����
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


	public class t_project_slip_sale_detailsCollection : ObservableCollection<t_project_slip_sale_details> {
		public t_project_slip_sale_detailsCollection(){
		}
	}
}