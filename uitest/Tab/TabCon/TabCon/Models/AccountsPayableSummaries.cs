using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 買掛サマリー情報
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
		///契約ID :=契約マスタ.ID
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
		///仕入先ID :=取引先マスタ.ID
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
		///今月出金額
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
		///今月調整額
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
		///今月仕入額
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
		///今月消費税
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
		///今回買掛額
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
		///今回締日
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
		///初回残高設定フラグ :0：締め処理から作成、1：残高設定から作成
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
		///作成者
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
		///作成日時
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
		///更新者
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
		///更新日時
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
		///削除日時
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
