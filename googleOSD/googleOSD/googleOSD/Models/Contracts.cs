using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �_��}�X�^
	/// </summary>
	public partial class Contracts{
		///�_��ID
		public int m_contract_id { get; set; }
		///�_��ԍ�
		public string contract_number { get; set; }
		///��Ж�
		public string company_name { get; set; }
		///������
		public string department_name { get; set; }
		///�_����ԁi�J�n�j
		public DateTime contract_period_start { get; set; }
		///�_����ԁi�I���j
		public DateTime contract_period_end { get; set; }
		///�㗝�X�R�[�h
		public string shop_code { get; set; }
		///�㗝�X��
		public string shop_name { get; set; }
		///�T�C�h�o�[�J�e�S��ID :���J�e�S���}�X�^�DID
		public int m_sidebar_category_id { get; set; }
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

	public class ContractsCollection : ObservableCollection<Contracts> {
		public ContractsCollection(){
		}
	}
}
