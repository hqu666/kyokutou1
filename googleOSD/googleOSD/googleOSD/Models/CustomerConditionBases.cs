using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �ڋq����������{
	/// </summary>
	public partial class CustomerConditionBases{
		///ID
		public int id { get; set; }
		///�_��ID :=�_����.ID
		public int m_contract_id { get; set; }
		///������
		public string search_name { get; set; }
		///����
		public string description { get; set; }
		///���ВS����ID
		public int m_own_company_staff_id { get; set; }
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

	public class CustomerConditionBasesCollection : ObservableCollection<CustomerConditionBases> {
		public CustomerConditionBasesCollection(){
		}
	}
}
