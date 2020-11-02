using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// âs}X^
	/// </summary>
	public partial class m_banks : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///_ñID :=_ñ}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///âsR[h
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///âs¼
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///xXR[h
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///xX¼
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ì¬Ò
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ì¬ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///XVÒ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///XVú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///íú
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
				RaisePropertyChanged();
			}
		}

	}


	public class m_banksCollection : ObservableCollection<m_banks> {
		public m_banksCollection(){
		}
	}
}
