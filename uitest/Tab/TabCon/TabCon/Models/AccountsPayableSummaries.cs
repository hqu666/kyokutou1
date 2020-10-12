using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ���|�T�}���[���
	/// </summary>
	public partial class AccountsPayableSummaries
	{

		///<summary>
		///ID
		///</summary>
		private int _id;
		public int id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
			}
		}

		///<summary>
		///�_��ID :=�_��}�X�^.ID
		///</summary>
		private int _m_contract_id;
		public int m_contract_id
		{
			get => _m_contract_id;
			set
			{
				if (_m_contract_id == value)
					return;
				_m_contract_id = value;
			}
		}

		///<summary>
		///�d����ID :=�����}�X�^.ID
		///</summary>
		private int _m_suppliers_id;
		public int m_suppliers_id
		{
			get => _m_suppliers_id;
			set
			{
				if (_m_suppliers_id == value)
					return;
				_m_suppliers_id = value;
			}
		}

		///<summary>
		///�����o���z
		///</summary>
		private decimal _current_month_withdrawal_amount;
		public decimal current_month_withdrawal_amount
		{
			get => _current_month_withdrawal_amount;
			set
			{
				if (_current_month_withdrawal_amount == value)
					return;
				_current_month_withdrawal_amount = value;
			}
		}

		///<summary>
		///���������z
		///</summary>
		private decimal _current_month_adjustment_amount;
		public decimal current_month_adjustment_amount
		{
			get => _current_month_adjustment_amount;
			set
			{
				if (_current_month_adjustment_amount == value)
					return;
				_current_month_adjustment_amount = value;
			}
		}

		///<summary>
		///�����d���z
		///</summary>
		private decimal _current_month_stocking_amount;
		public decimal current_month_stocking_amount
		{
			get => _current_month_stocking_amount;
			set
			{
				if (_current_month_stocking_amount == value)
					return;
				_current_month_stocking_amount = value;
			}
		}

		///<summary>
		///���������
		///</summary>
		private decimal _current_month_tax;
		public decimal current_month_tax
		{
			get => _current_month_tax;
			set
			{
				if (_current_month_tax == value)
					return;
				_current_month_tax = value;
			}
		}

		///<summary>
		///���񔃊|�z
		///</summary>
		private decimal _currenct_accounts_payable_amount;
		public decimal currenct_accounts_payable_amount
		{
			get => _currenct_accounts_payable_amount;
			set
			{
				if (_currenct_accounts_payable_amount == value)
					return;
				_currenct_accounts_payable_amount = value;
			}
		}

		///<summary>
		///�������
		///</summary>
		private DateTime _currenct_closing_date;
		public DateTime currenct_closing_date
		{
			get => _currenct_closing_date;
			set
			{
				if (_currenct_closing_date == value)
					return;
				_currenct_closing_date = value;
			}
		}

		///<summary>
		///����c���ݒ�t���O :0�F���ߏ�������쐬�A1�F�c���ݒ肩��쐬
		///</summary>
		private int _first_balance_setting_flag;
		public int first_balance_setting_flag
		{
			get => _first_balance_setting_flag;
			set
			{
				if (_first_balance_setting_flag == value)
					return;
				_first_balance_setting_flag = value;
			}
		}

		///<summary>
		///�쐬��
		///</summary>
		private int _created_user;
		public int created_user
		{
			get => _created_user;
			set
			{
				if (_created_user == value)
					return;
				_created_user = value;
			}
		}

		///<summary>
		///�쐬����
		///</summary>
		private DateTime _created_at;
		public DateTime created_at
		{
			get => _created_at;
			set
			{
				if (_created_at == value)
					return;
				_created_at = value;
			}
		}

		///<summary>
		///�X�V��
		///</summary>
		private int _updated_user;
		public int updated_user
		{
			get => _updated_user;
			set
			{
				if (_updated_user == value)
					return;
				_updated_user = value;
			}
		}

		///<summary>
		///�X�V����
		///</summary>
		private DateTime _updated_at;
		public DateTime updated_at
		{
			get => _updated_at;
			set
			{
				if (_updated_at == value)
					return;
				_updated_at = value;
			}
		}

		///<summary>
		///�폜����
		///</summary>
		private DateTime _deleted_at;
		public DateTime deleted_at
		{
			get => _deleted_at;
			set
			{
				if (_deleted_at == value)
					return;
				_deleted_at = value;
			}
		}

	}


	public class AccountsPayableSummariesCollection : ObservableCollection<AccountsPayableSummaries> {
		public AccountsPayableSummariesCollection(){
		}
	}
}
