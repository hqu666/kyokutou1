using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �捞���ڐݒ�
	/// </summary>
	public partial class ImportItemSettings{
		///ID
		public int id { get; set; }
		///�捞�ݒ�F���[�J�[�i�� :if=ImportFlag
		public int if_maker_cd { get; set; }
		///�捞�ݒ�F���i��
		public int if_product_name { get; set; }
		///�捞�ݒ�F���i�J�i
		public int if_product_kana { get; set; }
		///�捞�ݒ�F���i����
		public int if_product_abbreviation { get; set; }
		///�捞�ݒ�F�K�i
		public int if_standard { get; set; }
		///�捞�ݒ�F�P��
		public int if_unit { get; set; }
		///�捞�ݒ�FJAN�R�[�h
		public int if_jan_code { get; set; }
		///�捞�ݒ�F���[�J�[
		public int if_maker_id { get; set; }
		///�捞�ݒ�F�i��
		public int if_m_varietie_id { get; set; }
		///�捞�ݒ�F�W���d����
		public int if_standard_supplier_id { get; set; }
		///�捞�ݒ�F���i�}�X�^�W�v�敪1
		public int if_products_aggregation_category1 { get; set; }
		///�捞�ݒ�F���i�}�X�^�W�v�敪2
		public int if_products_aggregation_category2 { get; set; }
		///�捞�ݒ�F�̔����i�F�̔����i�Ŕ��j
		public int if_retail_price_tax_excluded { get; set; }
		///�捞�ݒ�F�̔����i�F�̔����i�ō��j
		public int if_retail_price_tax_included { get; set; }
		///�捞�ݒ�F�̔����i�F���P���i�Ŕ��j
		public int if_retail_price_unit_price_tax_excluded { get; set; }
		///�捞�ݒ�F�̔����i�F���P���i�ō��j
		public int if_retail_price_unit_price_tax_included { get; set; }
		///�捞�ݒ�F�̔����i�F�̔��P���i�Ŕ��j
		public int if_sale_price_tax_excluded { get; set; }
		///�捞�ݒ�F�̔����i�F�̔��P���i�ō��j
		public int if_sale_price_tax_included { get; set; }
		///�捞�ݒ�F�̔����i�F�ېŋ敪
		public int if_tax_classification { get; set; }
		///�捞�ݒ�F�d�����i�F�d�����i�Ŕ��j
		public int if_purchase_price_tax_excluded { get; set; }
		///�捞�ݒ�F�d�����i�F�d�����i�ō��j
		public int if_purchase_price_tax_included { get; set; }
		///�捞�ݒ�F�d�����i�F���P���i�Ŕ��j
		public int if_purchase_price_unit_price_tax_excluded { get; set; }
		///�捞�ݒ�F�d�����i�F���P���i�ō��j
		public int if_purchase_price_unit_price_tax_included { get; set; }
		///�捞�ݒ�F�d�����i�F�P��
		public int if_purchase_unit { get; set; }
		///�捞�ݒ�F�d�����i�F�����P��
		public int if_cost_unit_price { get; set; }
		///�捞�ݒ�F�d�����i�F�Œᔭ����
		public int if_minimum_order_quantity { get; set; }
		///�捞�ݒ�F�d�����i�F�P�ʓ�����
		public int if_quantity { get; set; }
		///�捞�ݒ�F�Q�l�P��
		public int if_reference_unit_price { get; set; }
		///�捞�ݒ�F�v��
		public int if_lengths { get; set; }
		///�捞�ݒ�F�J�^���OID
		public string if_m_catalog_catalog_id { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }
		///�폜����:
		public DateTime deleted_at { get; set; }
	}

	public class ImportItemSettingsCollection : ObservableCollection<ImportItemSettings> {
		public ImportItemSettingsCollection(){
		}
	}
}
