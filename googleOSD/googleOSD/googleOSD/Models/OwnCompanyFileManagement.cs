using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���Ѓt�@�C���Ǘ�
	/// </summary>
	public partial class OwnCompanyFileManagement{
		///ID
		public int id { get; set; }
		///�_��ID :=�_����.ID
		public int m_contract_id { get; set; }
		///����
		public string document_name { get; set; }
		///�t�@�C���p�X :�t���p�X
		public string file_path { get; set; }
		///�t�@�C������
		public string file_name { get; set; }
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

	public class OwnCompanyFileManagementCollection : ObservableCollection<OwnCompanyFileManagement> {
		public OwnCompanyFileManagementCollection(){
		}
	}
}
