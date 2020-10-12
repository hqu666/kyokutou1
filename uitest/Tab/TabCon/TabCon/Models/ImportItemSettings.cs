using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �捞���ڐݒ�
	/// </summary>
	public partial class ImportItemSettings
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
		///�捞�ݒ�F���[�J�[�i�� :if=ImportFlag
		///</summary>
		private int _if_maker_cd;
		public int if_maker_cd
		{
			get => _if_maker_cd;
			set
			{
				if (_if_maker_cd == value)
					return;
				_if_maker_cd = value;
			}
		}

		///<summary>
		///�捞�ݒ�F���i��
		///</summary>
		private int _if_product_name;
		public int if_product_name
		{
			get => _if_product_name;
			set
			{
				if (_if_product_name == value)
					return;
				_if_product_name = value;
			}
		}

		///<summary>
		///�捞�ݒ�F���i�J�i
		///</summary>
		private int _if_product_kana;
		public int if_product_kana
		{
			get => _if_product_kana;
			set
			{
				if (_if_product_kana == value)
					return;
				_if_product_kana = value;
			}
		}

		///<summary>
		///�捞�ݒ�F���i����
		///</summary>
		private int _if_product_abbreviation;
		public int if_product_abbreviation
		{
			get => _if_product_abbreviation;
			set
			{
				if (_if_product_abbreviation == value)
					return;
				_if_product_abbreviation = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�K�i
		///</summary>
		private int _if_standard;
		public int if_standard
		{
			get => _if_standard;
			set
			{
				if (_if_standard == value)
					return;
				_if_standard = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�P��
		///</summary>
		private int _if_unit;
		public int if_unit
		{
			get => _if_unit;
			set
			{
				if (_if_unit == value)
					return;
				_if_unit = value;
			}
		}

		///<summary>
		///�捞�ݒ�FJAN�R�[�h
		///</summary>
		private int _if_jan_code;
		public int if_jan_code
		{
			get => _if_jan_code;
			set
			{
				if (_if_jan_code == value)
					return;
				_if_jan_code = value;
			}
		}

		///<summary>
		///�捞�ݒ�F���[�J�[
		///</summary>
		private int _if_maker_id;
		public int if_maker_id
		{
			get => _if_maker_id;
			set
			{
				if (_if_maker_id == value)
					return;
				_if_maker_id = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�i��
		///</summary>
		private int _if_m_varietie_id;
		public int if_m_varietie_id
		{
			get => _if_m_varietie_id;
			set
			{
				if (_if_m_varietie_id == value)
					return;
				_if_m_varietie_id = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�W���d����
		///</summary>
		private int _if_standard_supplier_id;
		public int if_standard_supplier_id
		{
			get => _if_standard_supplier_id;
			set
			{
				if (_if_standard_supplier_id == value)
					return;
				_if_standard_supplier_id = value;
			}
		}

		///<summary>
		///�捞�ݒ�F���i�}�X�^�W�v�敪1
		///</summary>
		private int _if_products_aggregation_category1;
		public int if_products_aggregation_category1
		{
			get => _if_products_aggregation_category1;
			set
			{
				if (_if_products_aggregation_category1 == value)
					return;
				_if_products_aggregation_category1 = value;
			}
		}

		///<summary>
		///�捞�ݒ�F���i�}�X�^�W�v�敪2
		///</summary>
		private int _if_products_aggregation_category2;
		public int if_products_aggregation_category2
		{
			get => _if_products_aggregation_category2;
			set
			{
				if (_if_products_aggregation_category2 == value)
					return;
				_if_products_aggregation_category2 = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�̔����i�F�̔����i�Ŕ��j
		///</summary>
		private int _if_retail_price_tax_excluded;
		public int if_retail_price_tax_excluded
		{
			get => _if_retail_price_tax_excluded;
			set
			{
				if (_if_retail_price_tax_excluded == value)
					return;
				_if_retail_price_tax_excluded = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�̔����i�F�̔����i�ō��j
		///</summary>
		private int _if_retail_price_tax_included;
		public int if_retail_price_tax_included
		{
			get => _if_retail_price_tax_included;
			set
			{
				if (_if_retail_price_tax_included == value)
					return;
				_if_retail_price_tax_included = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�̔����i�F���P���i�Ŕ��j
		///</summary>
		private int _if_retail_price_unit_price_tax_excluded;
		public int if_retail_price_unit_price_tax_excluded
		{
			get => _if_retail_price_unit_price_tax_excluded;
			set
			{
				if (_if_retail_price_unit_price_tax_excluded == value)
					return;
				_if_retail_price_unit_price_tax_excluded = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�̔����i�F���P���i�ō��j
		///</summary>
		private int _if_retail_price_unit_price_tax_included;
		public int if_retail_price_unit_price_tax_included
		{
			get => _if_retail_price_unit_price_tax_included;
			set
			{
				if (_if_retail_price_unit_price_tax_included == value)
					return;
				_if_retail_price_unit_price_tax_included = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�̔����i�F�̔��P���i�Ŕ��j
		///</summary>
		private int _if_sale_price_tax_excluded;
		public int if_sale_price_tax_excluded
		{
			get => _if_sale_price_tax_excluded;
			set
			{
				if (_if_sale_price_tax_excluded == value)
					return;
				_if_sale_price_tax_excluded = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�̔����i�F�̔��P���i�ō��j
		///</summary>
		private int _if_sale_price_tax_included;
		public int if_sale_price_tax_included
		{
			get => _if_sale_price_tax_included;
			set
			{
				if (_if_sale_price_tax_included == value)
					return;
				_if_sale_price_tax_included = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�̔����i�F�ېŋ敪
		///</summary>
		private int _if_tax_classification;
		public int if_tax_classification
		{
			get => _if_tax_classification;
			set
			{
				if (_if_tax_classification == value)
					return;
				_if_tax_classification = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F�d�����i�Ŕ��j
		///</summary>
		private int _if_purchase_price_tax_excluded;
		public int if_purchase_price_tax_excluded
		{
			get => _if_purchase_price_tax_excluded;
			set
			{
				if (_if_purchase_price_tax_excluded == value)
					return;
				_if_purchase_price_tax_excluded = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F�d�����i�ō��j
		///</summary>
		private int _if_purchase_price_tax_included;
		public int if_purchase_price_tax_included
		{
			get => _if_purchase_price_tax_included;
			set
			{
				if (_if_purchase_price_tax_included == value)
					return;
				_if_purchase_price_tax_included = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F���P���i�Ŕ��j
		///</summary>
		private int _if_purchase_price_unit_price_tax_excluded;
		public int if_purchase_price_unit_price_tax_excluded
		{
			get => _if_purchase_price_unit_price_tax_excluded;
			set
			{
				if (_if_purchase_price_unit_price_tax_excluded == value)
					return;
				_if_purchase_price_unit_price_tax_excluded = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F���P���i�ō��j
		///</summary>
		private int _if_purchase_price_unit_price_tax_included;
		public int if_purchase_price_unit_price_tax_included
		{
			get => _if_purchase_price_unit_price_tax_included;
			set
			{
				if (_if_purchase_price_unit_price_tax_included == value)
					return;
				_if_purchase_price_unit_price_tax_included = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F�P��
		///</summary>
		private int _if_purchase_unit;
		public int if_purchase_unit
		{
			get => _if_purchase_unit;
			set
			{
				if (_if_purchase_unit == value)
					return;
				_if_purchase_unit = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F�����P��
		///</summary>
		private int _if_cost_unit_price;
		public int if_cost_unit_price
		{
			get => _if_cost_unit_price;
			set
			{
				if (_if_cost_unit_price == value)
					return;
				_if_cost_unit_price = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F�Œᔭ����
		///</summary>
		private int _if_minimum_order_quantity;
		public int if_minimum_order_quantity
		{
			get => _if_minimum_order_quantity;
			set
			{
				if (_if_minimum_order_quantity == value)
					return;
				_if_minimum_order_quantity = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�d�����i�F�P�ʓ�����
		///</summary>
		private int _if_quantity;
		public int if_quantity
		{
			get => _if_quantity;
			set
			{
				if (_if_quantity == value)
					return;
				_if_quantity = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�Q�l�P��
		///</summary>
		private int _if_reference_unit_price;
		public int if_reference_unit_price
		{
			get => _if_reference_unit_price;
			set
			{
				if (_if_reference_unit_price == value)
					return;
				_if_reference_unit_price = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�v��
		///</summary>
		private int _if_lengths;
		public int if_lengths
		{
			get => _if_lengths;
			set
			{
				if (_if_lengths == value)
					return;
				_if_lengths = value;
			}
		}

		///<summary>
		///�捞�ݒ�F�J�^���OID
		///</summary>
		private int _if_m_catalog_catalog_id;
		public int if_m_catalog_catalog_id
		{
			get => _if_m_catalog_catalog_id;
			set
			{
				if (_if_m_catalog_catalog_id == value)
					return;
				_if_m_catalog_catalog_id = value;
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


	public class ImportItemSettingsCollection : ObservableCollection<ImportItemSettings> {
		public ImportItemSettingsCollection(){
		}
	}
}
