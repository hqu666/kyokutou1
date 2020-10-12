using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 検索条件保存
	/// </summary>
	public partial class SearchConditions
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
		///検索種別 :※固定値：検索種別
		///</summary>
		private int _search_type;
		public int search_type
		{
			get => _search_type;
			set
			{
				if (_search_type == value)
					return;
				_search_type = value;
			}
		}

		///<summary>
		///ログインユーザーID :=ログインユーザーマスタ.ID
		///</summary>
		private int _m_login_users_staff_id;
		public int m_login_users_staff_id
		{
			get => _m_login_users_staff_id;
			set
			{
				if (_m_login_users_staff_id == value)
					return;
				_m_login_users_staff_id = value;
			}
		}

		///<summary>
		///条件名
		///</summary>
		private string _search_name;
		public string search_name
		{
			get => _search_name;
			set
			{
				if (_search_name == value)
					return;
				_search_name = value;
			}
		}

		///<summary>
		///条件値1
		///</summary>
		private string _value1;
		public string value1
		{
			get => _value1;
			set
			{
				if (_value1 == value)
					return;
				_value1 = value;
			}
		}

		///<summary>
		///条件値2
		///</summary>
		private string _value2;
		public string value2
		{
			get => _value2;
			set
			{
				if (_value2 == value)
					return;
				_value2 = value;
			}
		}

		///<summary>
		///条件値3
		///</summary>
		private string _value3;
		public string value3
		{
			get => _value3;
			set
			{
				if (_value3 == value)
					return;
				_value3 = value;
			}
		}

		///<summary>
		///条件値4
		///</summary>
		private string _value4;
		public string value4
		{
			get => _value4;
			set
			{
				if (_value4 == value)
					return;
				_value4 = value;
			}
		}

		///<summary>
		///条件値5
		///</summary>
		private string _value5;
		public string value5
		{
			get => _value5;
			set
			{
				if (_value5 == value)
					return;
				_value5 = value;
			}
		}

		///<summary>
		///条件値6
		///</summary>
		private string _value6;
		public string value6
		{
			get => _value6;
			set
			{
				if (_value6 == value)
					return;
				_value6 = value;
			}
		}

		///<summary>
		///条件値7
		///</summary>
		private string _value7;
		public string value7
		{
			get => _value7;
			set
			{
				if (_value7 == value)
					return;
				_value7 = value;
			}
		}

		///<summary>
		///条件値8
		///</summary>
		private string _value8;
		public string value8
		{
			get => _value8;
			set
			{
				if (_value8 == value)
					return;
				_value8 = value;
			}
		}

		///<summary>
		///条件値9
		///</summary>
		private string _value9;
		public string value9
		{
			get => _value9;
			set
			{
				if (_value9 == value)
					return;
				_value9 = value;
			}
		}

		///<summary>
		///条件値10
		///</summary>
		private string _value10;
		public string value10
		{
			get => _value10;
			set
			{
				if (_value10 == value)
					return;
				_value10 = value;
			}
		}

		///<summary>
		///条件値11
		///</summary>
		private string _value11;
		public string value11
		{
			get => _value11;
			set
			{
				if (_value11 == value)
					return;
				_value11 = value;
			}
		}

		///<summary>
		///条件値12
		///</summary>
		private string _value12;
		public string value12
		{
			get => _value12;
			set
			{
				if (_value12 == value)
					return;
				_value12 = value;
			}
		}

		///<summary>
		///条件値13
		///</summary>
		private string _value13;
		public string value13
		{
			get => _value13;
			set
			{
				if (_value13 == value)
					return;
				_value13 = value;
			}
		}

		///<summary>
		///条件値14
		///</summary>
		private string _value14;
		public string value14
		{
			get => _value14;
			set
			{
				if (_value14 == value)
					return;
				_value14 = value;
			}
		}

		///<summary>
		///条件値15
		///</summary>
		private string _value15;
		public string value15
		{
			get => _value15;
			set
			{
				if (_value15 == value)
					return;
				_value15 = value;
			}
		}

		///<summary>
		///条件値16
		///</summary>
		private string _value16;
		public string value16
		{
			get => _value16;
			set
			{
				if (_value16 == value)
					return;
				_value16 = value;
			}
		}

		///<summary>
		///条件値17
		///</summary>
		private string _value17;
		public string value17
		{
			get => _value17;
			set
			{
				if (_value17 == value)
					return;
				_value17 = value;
			}
		}

		///<summary>
		///条件値18
		///</summary>
		private string _value18;
		public string value18
		{
			get => _value18;
			set
			{
				if (_value18 == value)
					return;
				_value18 = value;
			}
		}

		///<summary>
		///条件値19
		///</summary>
		private string _value19;
		public string value19
		{
			get => _value19;
			set
			{
				if (_value19 == value)
					return;
				_value19 = value;
			}
		}

		///<summary>
		///条件値20
		///</summary>
		private string _value20;
		public string value20
		{
			get => _value20;
			set
			{
				if (_value20 == value)
					return;
				_value20 = value;
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


	public class SearchConditionsCollection : ObservableCollection<SearchConditions> {
		public SearchConditionsCollection(){
		}
	}
}
