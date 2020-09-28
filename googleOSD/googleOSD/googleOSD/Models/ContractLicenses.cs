using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �_�񃉃C�Z���X�A�g�}�X�^
	/// </summary>
	public partial class ContractLicenses{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///���C�Z���XID :=���C�Z���X�}�X�^.ID
		public int m_license_id { get; set; }
		///�Č��쐬�\���� :0�F�������A0�ȏ�F���萔
		public int count_creatable_project { get; set; }
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

	public class ContractLicensesCollection : ObservableCollection<ContractLicenses> {
		public ContractLicensesCollection(){
		}
	}
}
