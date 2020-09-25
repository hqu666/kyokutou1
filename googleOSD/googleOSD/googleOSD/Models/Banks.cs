using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ��s�}�X�^
	/// </summary>
	public partial class Banks{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///��s�R�[�h
		public string bank_cd { get; set; }
		///��s��
		public string bank_name { get; set; }
		///�x�X�R�[�h
		public string branch_cd { get; set; }
		///�x�X��
		public string branch_name { get; set; }
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

	public class BanksCollection : ObservableCollection<Banks> {
		public BanksCollection(){
		}
	}
}
