using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �J�^���O���i�}�X�^
	/// </summary>
	public partial class CatalogProducts
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
		///�i��敪 :���Œ�l�F�i��敪
		///</summary>
		private int _variety_type;
		public int variety_type
		{
			get => _variety_type;
			set
			{
				if (_variety_type == value)
					return;
				_variety_type = value;
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
			}
		}

		///<summary>
		///���i��
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
		///���i�J�i
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
			}
		}

		///<summary>
		///���i����
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
			}
		}

		///<summary>
		///�P�ʖ���
		///</summary>
		private string _unit_name_value;
		public string unit_name_value
		{
			get => _unit_name_value;
			set
			{
				if (_unit_name_value == value)
					return;
				_unit_name_value = value;
			}
		}

		///<summary>
		///JAN�R�[�h
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
			}
		}

		///<summary>
		///�̔����i�F�̔����i�Ŕ��j
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
			}
		}

		///<summary>
		///�̔����i�F�̔����i�ō��j
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
			}
		}

		///<summary>
		///�̔����i�F���P���i�Ŕ��j
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
			}
		}

		///<summary>
		///�̔����i�F���P���i�ō��j
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
			}
		}

		///<summary>
		///�̔����i�F�̔��P���i�Ŕ��j :���Œ�l�F�ېŋ敪
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
			}
		}

		///<summary>
		///�̔����i�F�̔��P���i�ō��j
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
			}
		}

		///<summary>
		///�̔����i�F�ېŋ敪
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
			}
		}

		///<summary>
		///�d�����i�F�d�����i�Ŕ��j
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
			}
		}

		///<summary>
		///�d�����i�F�d�����i�ō��j
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
			}
		}

		///<summary>
		///�d�����i�F���P���i�Ŕ��j
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
			}
		}

		///<summary>
		///�d�����i�F���P���i�ō��j
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
			}
		}

		///<summary>
		///�d�����i�F�P��
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
			}
		}

		///<summary>
		///�d�����i�F�����P���i�ޗ��j
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
			}
		}

		///<summary>
		///�d�����i�F�����P���i��Ɓj
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
			}
		}

		///<summary>
		///�d�����i�F�����P���i���̑��j
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
			}
		}

		///<summary>
		///�d�����i�F�Œᔭ����
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
			}
		}

		///<summary>
		///�d�����i�F�P�ʓ�����
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
			}
		}

		///<summary>
		///�Q�l�P��
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
			}
		}

		///<summary>
		///�v�ځF�N���X�E�N�b�V�����t���A�F�L���� :cr=Cross
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
			}
		}

		///<summary>
		///�v�ځF�N���X�E�N�b�V�����t���A�F�w���P��
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
			}
		}

		///<summary>
		///�v�ځF�N���X�E�N�b�V�����t���A�F���s�[�g
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
			}
		}

		///<summary>
		///�v�ځF�N���X�E�N�b�V�����t���A�F�؂��
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
			}
		}

		///<summary>
		///�v�ځF�Ж؁F�L���� :bb=Baseboard
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
			}
		}

		///<summary>
		///�v�ځF�Ж؁F�؂��
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
			}
		}

		///<summary>
		///�v�ځF�Ж؁F�P�[�X���萔
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
			}
		}

		///<summary>
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�� :pt= P tile
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
			}
		}

		///<summary>
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F����
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
			}
		}

		///<summary>
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�ŏ��J�b�g��
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
			}
		}

		///<summary>
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�P�[�X���萔
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
			}
		}

		///<summary>
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�u���݂Ȃ�����
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
			}
		}

		///<summary>
		///�J�^���O�}�X�^ID :=�J�^���O�}�X�^�DID
		///</summary>
		private int _m_catalog_id;
		public int m_catalog_id
		{
			get => _m_catalog_id;
			set
			{
				if (_m_catalog_id == value)
					return;
				_m_catalog_id = value;
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
			}
		}

	}


	public class CatalogProductsCollection : ObservableCollection<CatalogProducts> {
		public CatalogProductsCollection(){
		}
	}
}
