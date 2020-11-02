using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ���������ۑ�
	/// </summary>
	public partial class t_search_conditions : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///������� :���Œ�l�F�������
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���O�C�����[�U�[ID :=���O�C�����[�U�[�}�X�^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///������
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l1
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l2
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l3
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l4
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l5
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l6
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l7
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l8
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l9
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l10
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l11
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l12
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l13
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l14
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l15
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l16
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l17
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l18
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l19
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����l20
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

	}


	public class t_search_conditionsCollection : ObservableCollection<t_search_conditions> {
		public t_search_conditionsCollection(){
		}
	}
}
