using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ����敔��S���҃}�X�^
	/// </summary>
	public partial class SupplierStaffs{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�����ID :=�����}�X�^.ID
		public int m_supplier_id { get; set; }
		///�S���҃R�[�h
		public string staff_cd { get; set; }
		///�S���Җ�
		public string staff_name { get; set; }
		///��E
		public string position { get; set; }
		///�A����
		public string contact_number { get; set; }
		///�g�ѓd�b
		public string mobile_number { get; set; }
		///Email
		public string email { get; set; }
		///���l
		public string remark { get; set; }
		///�����t���O
		public int invalid_flg { get; set; }
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

	public class SupplierStaffsCollection : ObservableCollection<SupplierStaffs> {
		public SupplierStaffsCollection(){
		}
	}
}
