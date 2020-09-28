using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���|�T�}���[���
	/// </summary>
	public partial class AccountsPayableSummaries{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�d����ID :=�����}�X�^.ID
		public int m_suppliers_id { get; set; }
		///�����o���z
		public decimal current_month_withdrawal_amount { get; set; }
		///���������z
		public decimal current_month_adjustment_amount { get; set; }
		///�����d���z
		public decimal current_month_stocking_amount { get; set; }
		///���������
		public decimal current_month_tax { get; set; }
		///���񔃊|�z
		public decimal currenct_accounts_payable_amount { get; set; }
		///�������
		public DateTime currenct_closing_date { get; set; }
		///����c���ݒ�t���O :0�F���ߏ�������쐬�A1�F�c���ݒ肩��쐬
		public int first_balance_setting_flag { get; set; }
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

	public class AccountsPayableSummariesCollection : ObservableCollection<AccountsPayableSummaries> {
		public AccountsPayableSummariesCollection(){
		}
	}
}
