using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ����}�X�^
	/// </summary>
	public partial class Departments{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///����R�[�h
		public string department_cd { get; set; }
		///���喼��
		public string department_name { get; set; }
		///�X�֔ԍ�
		public string postal_code { get; set; }
		///�s���{�� :=�s���{���}�X�^.ID
		public int m_prefecture_id { get; set; }
		///�Z��1
		public string address_1 { get; set; }
		///�Z��2
		public string address_2 { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///���咷��
		public string department_head_name { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
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

	public class DepartmentsCollection : ObservableCollection<Departments> {
		public DepartmentsCollection(){
		}
	}
}
