using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �v�ڃ}�X�^
	/// </summary>
	public partial class Lengths{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�N���X�@�L����(cm) :cr=Cross
		public int cr_effective_width { get; set; }
		///�N���X�@�w���P��(cm)
		public int cr_buy_unit { get; set; }
		///�N���X�@���s�[�g(cm)
		public int cr_repeat { get; set; }
		///�N���X�@�؂��(cm)
		public int cr_cutting_allowance { get; set; }
		///�N���X�@�̔�
		public int cr_sale_type { get; set; }
		///�N���X�@�̔�(�P��)
		public int cr_sale_unit { get; set; }
		///�N���X�@�d��
		public int cr_purchase_type { get; set; }
		///�N���X�@�d���i�P�ʁj
		public int cr_purchase_unit { get; set; }
		///�N���X�@�{�H
		public int cr_construction_type { get; set; }
		///�N���X�@�{�H�i�P�ʁj
		public int cr_construction_unit { get; set; }
		///�Ж؁@�L����(cm) :bb=Baseboard
		public int bb_effective_width { get; set; }
		///�Ж؁@�؂��(cm)
		public int bb_cutting_allowance { get; set; }
		///�Ж؁@�P�[�X���萔(��/�P�[�X)
		public int bb_case_quantity { get; set; }
		///�Ж؁@�̔�
		public int bb_sale_type { get; set; }
		///�Ж؁@�̔��i�P�ʁj
		public int bb_sale_unit { get; set; }
		///�Ж؁@�d��
		public int bb_purchase_type { get; set; }
		///�Ж؁@�d���i�P�ʁj
		public int bb_purchase_unit { get; set; }
		///�Ж؁@�{�H
		public int bb_construction_type { get; set; }
		///�Ж؁@�{�H�i�P�ʁj
		public int bb_construction_unit { get; set; }
		///P�^�C���@��(mm) :pt= P tile
		public int pt_width { get; set; }
		///P�^�C���@����(mm)
		public int pt_length { get; set; }
		///P�^�C���@�ŏ��J�b�g��(mm)
		public int pt_min_cut_width { get; set; }
		///P�^�C���@�P�[�X���萔
		public int pt_case_quantity { get; set; }
		///P�^�C���@�u���݂Ȃ�����
		public int pt_deemed_quantity { get; set; }
		///P�^�C���@�̔�
		public int pt_sale_type { get; set; }
		///P�^�C���@�̔��i�P�ʁj
		public int pt_sale_unit { get; set; }
		///P�^�C���@�d��
		public int pt_purchase_type { get; set; }
		///P�^�C���@�d���i�P�ʁj
		public int pt_purchase_unit { get; set; }
		///P�^�C���@�{�H
		public int pt_construction_type { get; set; }
		///P�^�C���@�{�H�i�P�ʁj :tc=Tile carpet
		public int pt_construction_unit { get; set; }
		///�^�C���J�[�y�b�g�@��(mm)
		public int tc_width { get; set; }
		///�^�C���J�[�y�b�g�@����(mm)
		public int tc_length { get; set; }
		///�^�C���J�[�y�b�g�@�ŏ��J�b�g��(mm)
		public int tc_min_cut_width { get; set; }
		///�^�C���J�[�y�b�g�@�P�[�X���萔
		public int tc_case_quantity { get; set; }
		///�^�C���J�[�y�b�g�@�u���݂Ȃ�����
		public int tc_deemed_quantity { get; set; }
		///�^�C���J�[�y�b�g�@�̔�
		public int tc_sale_type { get; set; }
		///�^�C���J�[�y�b�g�@�̔��i�P�ʁj
		public int tc_sale_unit { get; set; }
		///�^�C���J�[�y�b�g�@�d��
		public int tc_purchase_type { get; set; }
		///�^�C���J�[�y�b�g�@�d���i�P�ʁj
		public int tc_purchase_unit { get; set; }
		///�^�C���J�[�y�b�g�@�{�H
		public int tc_construction_type { get; set; }
		///�^�C���J�[�y�b�g�@�{�H�i�P�ʁj
		public int tc_construction_unit { get; set; }
		///�N�b�V�����t���A�@�L����(cm) :cf=Cushion floor
		public int cf_effective_width { get; set; }
		///�N�b�V�����t���A�@�w���P��(cm)
		public int cf_buy_unit { get; set; }
		///�N�b�V�����t���A�@���s�[�g(cm)
		public int cf_repeat { get; set; }
		///�N�b�V�����t���A�@�؂��(cm)
		public int cf_cutting_allowance { get; set; }
		///�N�b�V�����t���A�@�̔�
		public int cf_sale_type { get; set; }
		///�N�b�V�����t���A�@�̔��i�P�ʁj
		public int cf_sale_unit { get; set; }
		///�N�b�V�����t���A�@�d��
		public int cf_purchase_type { get; set; }
		///�N�b�V�����t���A�@�d���i�P�ʁj
		public int cf_purchase_unit { get; set; }
		///�N�b�V�����t���A�@�{�H
		public int cf_construction_type { get; set; }
		///�N�b�V�����t���A�@�{�H�i�P�ʁj
		public int cf_construction_unit { get; set; }
		///�J�[�y�b�g�@�̔� :ca=carpet
		public int ca_sale_type { get; set; }
		///�J�[�y�b�g�@�̔��i�P�ʁj
		public int ca_sale_unit { get; set; }
		///�J�[�y�b�g�@�d��
		public int ca_purchase_type { get; set; }
		///�J�[�y�b�g�@�d���i�P�ʁj
		public int ca_purchase_unit { get; set; }
		///�J�[�y�b�g�@�{�H
		public int ca_construction_type { get; set; }
		///�J�[�y�b�g�@�{�H�i�P�ʁj
		public int ca_construction_unit { get; set; }
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

	public class LengthsCollection : ObservableCollection<Lengths> {
		public LengthsCollection(){
		}
	}
}
