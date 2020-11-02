using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 消費税マスタ
	/// </summary>
	public partial class m_taxs : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///消費税コード
		///</summary>
		private string _tax_cd;
		public string tax_cd
		{
			get => _tax_cd;
			set
			{
				if (_tax_cd == value)
					return;
				_tax_cd = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///消費税名称
		///</summary>
		private string _tax_name;
		public string tax_name
		{
			get => _tax_name;
			set
			{
				if (_tax_name == value)
					return;
				_tax_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///運用開始日
		///</summary>
		private DateTime _operation_date_start;
		public DateTime operation_date_start
		{
			get => _operation_date_start;
			set
			{
				if (_operation_date_start == value)
					return;
				_operation_date_start = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///運用終了日
		///</summary>
		private DateTime _operation_date_end;
		public DateTime operation_date_end
		{
			get => _operation_date_end;
			set
			{
				if (_operation_date_end == value)
					return;
				_operation_date_end = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///税率
		///</summary>
		private decimal _tax_rate;
		public decimal tax_rate
		{
			get => _tax_rate;
			set
			{
				if (_tax_rate == value)
					return;
				_tax_rate = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///経過措置適用開始日
		///</summary>
		private DateTime _transitional_date_start;
		public DateTime transitional_date_start
		{
			get => _transitional_date_start;
			set
			{
				if (_transitional_date_start == value)
					return;
				_transitional_date_start = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///経過措置適用終了日
		///</summary>
		private DateTime _transitional_date_end;
		public DateTime transitional_date_end
		{
			get => _transitional_date_end;
			set
			{
				if (_transitional_date_end == value)
					return;
				_transitional_date_end = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///初期値フラグ
		///</summary>
		private int _default_flag;
		public int default_flag
		{
			get => _default_flag;
			set
			{
				if (_default_flag == value)
					return;
				_default_flag = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///極東産機フラグ :1：極東産機設定、0：ユーザー設定
		///</summary>
		private int _ks_flag;
		public int ks_flag
		{
			get => _ks_flag;
			set
			{
				if (_ks_flag == value)
					return;
				_ks_flag = value;
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

	}


	public class m_taxsCollection : ObservableCollection<m_taxs> {
		public m_taxsCollection(){
		}
	}
}
