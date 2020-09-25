using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���i�}�X�^
	/// </summary>
	public partial class Products{
		///ID
		public int id { get; set; }
		///�_��ID :=�_����.ID
		public int m_contract_id { get; set; }
		///���Еi��
		public string product_cd { get; set; }
		///���[�J�[�i��
		public string maker_cd { get; set; }
		///���i��
		public string product_name { get; set; }
		///���i�J�i
		public string product_kana { get; set; }
		///���i����
		public string product_abbreviation { get; set; }
		///�K�i
		public string standard { get; set; }
		///�P�� :=�V�X�e���֘A���̃}�X�^.ID�@�i�敪=2)
		public int unit { get; set; }
		///JAN�R�[�h
		public string jan_code { get; set; }
		///���[�J�[ :=�V�X�e���֘A���̃}�X�^.ID�@�i�敪=1)
		public int maker_id { get; set; }
		///�i�� :=�i��}�X�^.ID
		public int m_varietie_id { get; set; }
		///�W���d���� :=�����}�X�^.ID
		public int standard_supplier_id { get; set; }
		///���i�}�X�^�W�v�敪1 :=�W�v�敪���̃}�X�^.ID�@�i�敪=5)
		public int products_aggregation_category1 { get; set; }
		///���i�}�X�^�W�v�敪2 :=�W�v�敪���̃}�X�^.ID�@�i�敪=6)
		public int products_aggregation_category2 { get; set; }
		///�����f�[�^�쐬�t���O
		public int order_data_flag { get; set; }
		///�ߏ蔭���A���[�g�t���O
		public int over_order_alert_flag { get; set; }
		///�̔��t���O
		public int sale_flag { get; set; }
		///�d���t���O
		public int purchase_flag { get; set; }
		///�̔����i�F�̔����i�Ŕ��j
		public decimal retail_price_tax_excluded { get; set; }
		///�̔����i�F�̔����i�ō��j
		public decimal retail_price_tax_included { get; set; }
		///�̔����i�F���P���i�Ŕ��j
		public decimal retail_price_unit_price_tax_excluded { get; set; }
		///�̔����i�F���P���i�ō��j
		public decimal retail_price_unit_price_tax_included { get; set; }
		///�̔����i�F�̔��P���i�Ŕ��j
		public decimal sale_price_tax_excluded { get; set; }
		///�̔����i�F�̔��P���i�ō��j
		public decimal sale_price_tax_included { get; set; }
		///�̔����i�F�ېŋ敪 :���Œ�l�F�ېŋ敪
		public int tax_classification { get; set; }
		///�d�����i�F�d�����i�Ŕ��j
		public decimal purchase_price_tax_excluded { get; set; }
		///�d�����i�F�d�����i�ō��j
		public decimal purchase_price_tax_included { get; set; }
		///�d�����i�F���P���i�Ŕ��j
		public decimal purchase_price_unit_price_tax_excluded { get; set; }
		///�d�����i�F���P���i�ō��j
		public decimal purchase_price_unit_price_tax_included { get; set; }
		///�d�����i�F�P��
		public int purchase_unit { get; set; }
		///�d�����i�F�����P��
		public decimal cost_unit_price { get; set; }
		///�d�����i�F�Œᔭ����
		public decimal minimum_order_quantity { get; set; }
		///�d�����i�F�P�ʓ�����
		public int quantity { get; set; }
		///�Q�l�P��
		public decimal reference_unit_price { get; set; }
		///�v�ځF�N���X�E�N�b�V�����t���A�F�L���� :cr=Cross
		public int cr_effective_width { get; set; }
		///�v�ځF�N���X�E�N�b�V�����t���A�F�w���P��
		public int cr_buy_unit { get; set; }
		///�v�ځF�N���X�E�N�b�V�����t���A�F���s�[�g
		public int cr_repeat { get; set; }
		///�v�ځF�N���X�E�N�b�V�����t���A�F�؂��
		public int cr_cutting_allowance { get; set; }
		///�v�ځF�Ж؁F�L���� :bb=Baseboard
		public int bb_effective_width { get; set; }
		///�v�ځF�Ж؁F�؂��
		public int bb_cutting_allowance { get; set; }
		///�v�ځF�Ж؁F�P�[�X���萔
		public int bb_case_quantity { get; set; }
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�� :pt= P tile
		public int pt_width { get; set; }
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F����
		public int pt_length { get; set; }
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�ŏ��J�b�g��
		public int pt_min_cut_width { get; set; }
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�P�[�X���萔
		public int pt_case_quantity { get; set; }
		///�v�ځF�o�^�C���E�^�C���J�[�y�b�g�F�u���݂Ȃ�����
		public int pt_deemed_quantity { get; set; }
		///�K�v�W���F����1
		public float required_factor_cost_1 { get; set; }
		///�K�v�W���F����2
		public float required_factor_cost_2 { get; set; }
		///�K�v�W���F����3
		public float required_factor_cost_3 { get; set; }
		///�p�ԃt���O
		public int discontinued_flag { get; set; }
		///�J�^���O���iID :=�J�^���O���i�}�X�^.ID
		public int m_catalog_product_id { get; set; }
		///�X�e�[�^�X :0�F���o�^�A1�F�{�o�^
		public int status { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class ProductsCollection : ObservableCollection<Products> {
		public ProductsCollection(){
		}
	}
}
