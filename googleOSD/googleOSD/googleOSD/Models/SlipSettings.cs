using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �`�[��ʐݒ�
	/// </summary>
	public partial class SlipSettings{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///���O�C�����[�U�[ID :=���O�C�����[�U�[�}�X�^.ID
		public int m_login_users_staff_id { get; set; }
		///�ꏊ�F�\���t���O :0�F�\�����Ȃ��A1�F�\������
		public int location_display_flag { get; set; }
		///�ꏊ�F��������
		public int location_union_item { get; set; }
		///�ꏊ�F���я�
		public int location_order { get; set; }
		///�ӏ��F�\�� :0�F�\�����Ȃ��A1�F�\������
		public int place_display_flag { get; set; }
		///�ӏ��F��������
		public int place_union_item { get; set; }
		///�ӏ��F���я�
		public int place_order { get; set; }
		///���Еi�ԁF�\�� :0�F�\�����Ȃ��A1�F�\������
		public int product_display_flag { get; set; }
		///���Еi�ԁF��������
		public int product_union_item { get; set; }
		///���Еi�ԁF���я�
		public int product_order { get; set; }
		///���[�J�[�i�ԁF�\�� :0�F�\�����Ȃ��A1�F�\������
		public int maker_display_flag { get; set; }
		///���[�J�[�i�ԁF��������
		public int maker_union_item { get; set; }
		///���[�J�[�i�ԁF���я�
		public int maker_order { get; set; }
		///���[�J�[���F�\�� :0�F�\�����Ȃ��A1�F�\������
		public int maker_name_display_flag { get; set; }
		///���[�J�[���F��������
		public int maker_name_union_item { get; set; }
		///���[�J�[���F���я�
		public int maker_name_order { get; set; }
		///�i���F�\�� :0�F�\�����Ȃ��A1�F�\������
		public int product_name_display_flag { get; set; }
		///�i���F��������
		public int product_name_union_item { get; set; }
		///�i���F���я�
		public int product_name_order { get; set; }
		///�K�i�F�\�� :0�F�\�����Ȃ��A1�F�\������
		public int standard_display_flag { get; set; }
		///�K�i�F��������
		public int standard_union_item { get; set; }
		///�K�i�F���я�
		public int standard_order { get; set; }
		///�i��F�\�� :0�F�\�����Ȃ��A1�F�\������
		public int variety_display_flag { get; set; }
		///�i��F��������
		public int variety_union_item { get; set; }
		///�i��F���я�
		public int variety_order { get; set; }
		///���ʁF�\�� :0�F�\�����Ȃ��A1�F�\������
		public int quantity_display_flag { get; set; }
		///���ʁF��������
		public int quantity_union_item { get; set; }
		///���ʁF���я�
		public int quantity_order { get; set; }
		///�P�ʁF�\�� :0�F�\�����Ȃ��A1�F�\������
		public int unit_display_flag { get; set; }
		///�P�ʁF��������
		public int unit_union_item { get; set; }
		///�P�ʁF���я�
		public int unit_order { get; set; }
		///�P���F�\�� :0�F�\�����Ȃ��A1�F�\������
		public int price_display_flag { get; set; }
		///�P���F��������
		public int price_union_item { get; set; }
		///�P���F���я�
		public int price_order { get; set; }
		///���z�F�\�� :am=Amount of money
		public int am_display_flag { get; set; }
		///���z�F��������
		public int am_union_item { get; set; }
		///���z�F���я�
		public int am_order { get; set; }
		///���l�F�\�� :0�F�\�����Ȃ��A1�F�\������
		public int remarks_display_flag { get; set; }
		///���l�F��������
		public int remarks_union_item { get; set; }
		///���l�F���я�
		public int remarks_order { get; set; }
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

	public class SlipSettingsCollection : ObservableCollection<SlipSettings> {
		public SlipSettingsCollection(){
		}
	}
}
