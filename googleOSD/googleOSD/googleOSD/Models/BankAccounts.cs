using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �U����}�X�^
	/// </summary>
	public partial class BankAccounts{
		///ID
		public int id { get; set; }
		///�_��ID :=�_����.ID
		public int m_contract_id { get; set; }
		///�U����敪 :=�Œ�l�F�U����敪
		public int bank_account_type { get; set; }
		///�ԍ� :�i���Ёj1�`3�A�i����j4
		public int bank_account_code { get; set; }
		///����ID :=����}�X�^.ID�@�i����̐U����̏ꍇ�j
		public int m_department_id { get; set; }
		///��sID :=��s�}�X�^.ID
		public int m_bank_id { get; set; }
		///�a����� :=�Œ�l�F�a�����
		public int deposit_type { get; set; }
		///���`�l
		public string bank_account_name { get; set; }
		///�����ԍ�
		public string bank_account_number { get; set; }
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

	public class BankAccountsCollection : ObservableCollection<BankAccounts> {
		public BankAccountsCollection(){
		}
	}
}
