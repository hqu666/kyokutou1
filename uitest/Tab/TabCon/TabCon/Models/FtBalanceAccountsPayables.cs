using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 初回残高買掛額
	/// </summary>
	public partial class FtBalanceAccountsPayables
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
		private int _m_contracts_id;
		public int m_contracts_id
		{
			get => _m_contracts_id;
			set
			{
				if (_m_contracts_id == value)
					return;
				_m_contracts_id = value;
			}
		}

		///<summary>
		///取引先ID :=取引先マスタ.ID
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
		///前月買掛日
		///</summary>
		private DateTime _last_month_date;
		public DateTime last_month_date
		{
			get => _last_month_date;
			set
			{
				if (_last_month_date == value)
					return;
				_last_month_date = value;
			}
		}

		///<summary>
		///前月買掛額
		///</summary>
		private int _last_month_amount;
		public int last_month_amount
		{
			get => _last_month_amount;
			set
			{
				if (_last_month_amount == value)
					return;
				_last_month_amount = value;
			}
		}

		///<summary>
		///削除フラグ
		///</summary>
		private int _is_deleted;
		public int is_deleted
		{
			get => _is_deleted;
			set
			{
				if (_is_deleted == value)
					return;
				_is_deleted = value;
			}
		}

		///<summary>
		///作成者
		///</summary>
		private int _creater;
		public int creater
		{
			get => _creater;
			set
			{
				if (_creater == value)
					return;
				_creater = value;
			}
		}

		///<summary>
		///作成日時
		///</summary>
		private DateTime _created_on;
		public DateTime created_on
		{
			get => _created_on;
			set
			{
				if (_created_on == value)
					return;
				_created_on = value;
			}
		}

		///<summary>
		///更新者
		///</summary>
		private int _modifier;
		public int modifier
		{
			get => _modifier;
			set
			{
				if (_modifier == value)
					return;
				_modifier = value;
			}
		}

		///<summary>
		///更新日時
		///</summary>
		private DateTime _modifier_on;
		public DateTime modifier_on
		{
			get => _modifier_on;
			set
			{
				if (_modifier_on == value)
					return;
				_modifier_on = value;
			}
		}

	}


	public class FtBalanceAccountsPayablesCollection : ObservableCollection<FtBalanceAccountsPayables> {
		public FtBalanceAccountsPayablesCollection(){
		}
	}
}
