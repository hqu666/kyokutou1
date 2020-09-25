using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �J�^���O���i�}�X�^
	/// </summary>
	public partial class CatalogProducts{
		///ID
		public int id { get; set; }
		///�i��敪 :���Œ�l�F�i��敪
		public int variety_type { get; set; }
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
		///JAN�R�[�h
		public string jan_code { get; set; }
		///�̔����i�F�̔����i�Ŕ��j
		public decimal retail_price_tax_excluded { get; set; }
		///�̔����i�F�̔����i�ō��j
		public decimal retail_price_tax_included { get; set; }
		///�̔����i�F���P���i�Ŕ��j
		public decimal retail_price_unit_price_tax_excluded { get; set; }
		///�̔����i�F���P���i�ō��j
		public decimal retail_price_unit_price_tax_included { get; set; }
		///�̔����i�F�̔��P���i�Ŕ��j :���Œ�l�F�ېŋ敪
		public decimal sale_price_tax_excluded { get; set; }
		///�̔����i�F�̔��P���i�ō��j
		public decimal sale_price_tax_included { get; set; }
		///�̔����i�F�ېŋ敪
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
		///�d�����i�F�����P�� :���Œ�l�F�ېŋ敪
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
		///�J�^���O�}�X�^ID :=�J�^���O�}�X�^�DID
		public int m_catalog_id { get; set; }
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

	public class CatalogProductsCollection : ObservableCollection<CatalogProducts> {
		public CatalogProductsCollection(){
		}
	}
}
