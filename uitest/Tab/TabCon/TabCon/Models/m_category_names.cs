using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 集計区分名称マスタ
	/// </summary>
	public partial class m_category_names : NotificationObject
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
		///区分 :※固定値：集計区分名称
		///</summary>
		private int _name_type;
		public int name_type
		{
			get => _name_type;
			set
			{
				if (_name_type == value)
					return;
				_name_type = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///コード
		///</summary>
		private int _name_code;
		public int name_code
		{
			get => _name_code;
			set
			{
				if (_name_code == value)
					return;
				_name_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///名称
		///</summary>
		private string _name_value;
		public string name_value
		{
			get => _name_value;
			set
			{
				if (_name_value == value)
					return;
				_name_value = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///並び順
		///</summary>
		private int _order;
		public int order
		{
			get => _order;
			set
			{
				if (_order == value)
					return;
				_order = value;
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///削除日時
		///</summary>
		private DateTime _deleted_on;
		public DateTime deleted_on
		{
			get => _deleted_on;
			set
			{
				if (_deleted_on == value)
					return;
				_deleted_on = value;
				RaisePropertyChanged();
			}
		}

	}


	public class m_category_namesCollection : ObservableCollection<m_category_names> {
		public m_category_namesCollection(){
		}
	}
}
