using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 銀行マスタ
	/// </summary>
	public partial class Banks
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
		///銀行コード
		///</summary>
		private string _bank_cd;
		public string bank_cd
		{
			get => _bank_cd;
			set
			{
				if (_bank_cd == value)
					return;
				_bank_cd = value;
			}
		}

		///<summary>
		///銀行名
		///</summary>
		private string _bank_name;
		public string bank_name
		{
			get => _bank_name;
			set
			{
				if (_bank_name == value)
					return;
				_bank_name = value;
			}
		}

		///<summary>
		///支店コード
		///</summary>
		private string _branch_cd;
		public string branch_cd
		{
			get => _branch_cd;
			set
			{
				if (_branch_cd == value)
					return;
				_branch_cd = value;
			}
		}

		///<summary>
		///支店名
		///</summary>
		private string _branch_name;
		public string branch_name
		{
			get => _branch_name;
			set
			{
				if (_branch_name == value)
					return;
				_branch_name = value;
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


	public class BanksCollection : ObservableCollection<Banks> {
		public BanksCollection(){
		}
	}
}
