using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 振込先マスタ
	/// </summary>
	public partial class BankAccounts
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
		///契約ID :=契約情報.ID
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
		///振込先区分 :=固定値：振込先区分
		///</summary>
		private int _bank_account_type;
		public int bank_account_type
		{
			get => _bank_account_type;
			set
			{
				if (_bank_account_type == value)
					return;
				_bank_account_type = value;
			}
		}

		///<summary>
		///番号 :（自社）1～3、（部門）4
		///</summary>
		private bool _bank_account_code;
		public bool bank_account_code
		{
			get => _bank_account_code;
			set
			{
				if (_bank_account_code == value)
					return;
				_bank_account_code = value;
			}
		}

		///<summary>
		///部門ID :=部門マスタ.ID　（部門の振込先の場合）
		///</summary>
		private int _m_department_id;
		public int m_department_id
		{
			get => _m_department_id;
			set
			{
				if (_m_department_id == value)
					return;
				_m_department_id = value;
			}
		}

		///<summary>
		///銀行ID :=銀行マスタ.ID
		///</summary>
		private int _m_bank_id;
		public int m_bank_id
		{
			get => _m_bank_id;
			set
			{
				if (_m_bank_id == value)
					return;
				_m_bank_id = value;
			}
		}

		///<summary>
		///預金種別 :=固定値：預金種別
		///</summary>
		private bool _deposit_type;
		public bool deposit_type
		{
			get => _deposit_type;
			set
			{
				if (_deposit_type == value)
					return;
				_deposit_type = value;
			}
		}

		///<summary>
		///名義人
		///</summary>
		private string _bank_account_name;
		public string bank_account_name
		{
			get => _bank_account_name;
			set
			{
				if (_bank_account_name == value)
					return;
				_bank_account_name = value;
			}
		}

		///<summary>
		///口座番号
		///</summary>
		private string _bank_account_number;
		public string bank_account_number
		{
			get => _bank_account_number;
			set
			{
				if (_bank_account_number == value)
					return;
				_bank_account_number = value;
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


	public class BankAccountsCollection : ObservableCollection<BankAccounts> {
		public BankAccountsCollection(){
		}
	}
}
