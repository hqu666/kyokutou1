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
	public partial class AccountsReceivableSummaries
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
		///���Ӑ�ID :=�����}�X�^.ID
		///</summary>
		private int _m_supplier_id;
		public int m_supplier_id
		{
			get => _m_supplier_id;
			set
			{
				if (_m_supplier_id == value)
					return;
				_m_supplier_id = value;
			}
		}

		///<summary>
		///���������z
		///</summary>
		private decimal _current_month_payment_amount;
		public decimal current_month_payment_amount
		{
			get => _current_month_payment_amount;
			set
			{
				if (_current_month_payment_amount == value)
					return;
				_current_month_payment_amount = value;
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
		///��������z
		///</summary>
		private decimal _current_month_sales_amount;
		public decimal current_month_sales_amount
		{
			get => _current_month_sales_amount;
			set
			{
				if (_current_month_sales_amount == value)
					return;
				_current_month_sales_amount = value;
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
		///���񔄊|�z
		///</summary>
		private decimal _currenct_accounts_receivable_amount;
		public decimal currenct_accounts_receivable_amount
		{
			get => _currenct_accounts_receivable_amount;
			set
			{
				if (_currenct_accounts_receivable_amount == value)
					return;
				_currenct_accounts_receivable_amount = value;
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


	public class AccountsReceivableSummariesCollection : ObservableCollection<AccountsReceivableSummaries> {
		public AccountsReceivableSummariesCollection(){
		}
	}
}
