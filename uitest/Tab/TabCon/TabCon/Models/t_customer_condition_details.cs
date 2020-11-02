using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// 顧客検索条件詳細
	/// </summary>
	public partial class t_customer_condition_details : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///顧客検索条件基本ID
		///</summary>
		private int _search_criteria_base_id;
		public int search_criteria_base_id
		{
			get => _search_criteria_base_id;
			set
			{
				if (_search_criteria_base_id == value)
					return;
				_search_criteria_base_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///条件番号 :検索条件の行番号
		///</summary>
		private int _condition_number;
		public int condition_number
		{
			get => _condition_number;
			set
			{
				if (_condition_number == value)
					return;
				_condition_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///And/Or
		///</summary>
		private string _conjunction;
		public string conjunction
		{
			get => _conjunction;
			set
			{
				if (_conjunction == value)
					return;
				_conjunction = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///前かっこ
		///</summary>
		private string _previous_parenthesis;
		public string previous_parenthesis
		{
			get => _previous_parenthesis;
			set
			{
				if (_previous_parenthesis == value)
					return;
				_previous_parenthesis = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///項目 :※固定値：顧客検索条件：項目（表示用）、顧客検索条件：項目（検索用）
		///</summary>
		private int _item;
		public int item
		{
			get => _item;
			set
			{
				if (_item == value)
					return;
				_item = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///比較する条件 :※固定値：顧客検索条件：比較する条件（演算子）
		///</summary>
		private int _comparing_value_3;
		public int comparing_value_3
		{
			get => _comparing_value_3;
			set
			{
				if (_comparing_value_3 == value)
					return;
				_comparing_value_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///比較する値１
		///</summary>
		private string _comparing_value_1;
		public string comparing_value_1
		{
			get => _comparing_value_1;
			set
			{
				if (_comparing_value_1 == value)
					return;
				_comparing_value_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///比較する値２
		///</summary>
		private string _comparing_value_2;
		public string comparing_value_2
		{
			get => _comparing_value_2;
			set
			{
				if (_comparing_value_2 == value)
					return;
				_comparing_value_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///後かっこ
		///</summary>
		private string _after_parenthesis;
		public string after_parenthesis
		{
			get => _after_parenthesis;
			set
			{
				if (_after_parenthesis == value)
					return;
				_after_parenthesis = value;
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


	public class t_customer_condition_detailsCollection : ObservableCollection<t_customer_condition_details> {
		public t_customer_condition_detailsCollection(){
		}
	}
}
