using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���ВS���҃}�X�^
	/// </summary>
	public partial class OwnCompanyStaffs{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�S���҃R�[�h
		public string staff_cd { get; set; }
		///�S���Җ�
		public string staff_name { get; set; }
		///����ID :����}�X�^��ID
		public int m_department_id { get; set; }
		///�g�ѓd�b
		public string mobile_number { get; set; }
		///���[���A�h���X
		public string email { get; set; }
		///�����t���O
		public int invalid_flg { get; set; }
		///�\���P
		public string spare_1 { get; set; }
		///�\���Q
		public string spare_2 { get; set; }
		///�\���R
		public string spare_3 { get; set; }
		///�\��N1
		public string spare_n1 { get; set; }
		///�\��N2
		public string spare_n2 { get; set; }
		///�\��N3
		public string spare_n3 { get; set; }
		///�\��D1
		public string spare_d1 { get; set; }
		///�\��D�Q
		public string spare_d2 { get; set; }
		///�\��D3
		public string spare_d3 { get; set; }
		///��ӃC���[�W
		public string stamp_image { get; set; }
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

	public class OwnCompanyStaffsCollection : ObservableCollection<OwnCompanyStaffs> {
		public OwnCompanyStaffsCollection(){
		}
	}
}
