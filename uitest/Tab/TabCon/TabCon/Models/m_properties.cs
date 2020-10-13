using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �����}�X�^
	/// </summary>
	public partial class m_properties : NotificationObject
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
		///�����R�[�h
		///</summary>
		private string _property_code;
		public string property_code
		{
			get => _property_code;
			set
			{
				if (_property_code == value)
					return;
				_property_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///��������
		///</summary>
		private string _property_name;
		public string property_name
		{
			get => _property_name;
			set
			{
				if (_property_name == value)
					return;
				_property_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����J�i
		///</summary>
		private string _property_kana;
		public string property_kana
		{
			get => _property_kana;
			set
			{
				if (_property_kana == value)
					return;
				_property_kana = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�{�喼
		///</summary>
		private string _owner_name;
		public string owner_name
		{
			get => _owner_name;
			set
			{
				if (_owner_name == value)
					return;
				_owner_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�X�֔ԍ�
		///</summary>
		private string _postal_code;
		public string postal_code
		{
			get => _postal_code;
			set
			{
				if (_postal_code == value)
					return;
				_postal_code = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�s���{�� :=�s���{���}�X�^.ID
		///</summary>
		private int _m_prefecture_id;
		public int m_prefecture_id
		{
			get => _m_prefecture_id;
			set
			{
				if (_m_prefecture_id == value)
					return;
				_m_prefecture_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Z��1
		///</summary>
		private string _address_1;
		public string address_1
		{
			get => _address_1;
			set
			{
				if (_address_1 == value)
					return;
				_address_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Z��2
		///</summary>
		private string _address_2;
		public string address_2
		{
			get => _address_2;
			set
			{
				if (_address_2 == value)
					return;
				_address_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///TEL
		///</summary>
		private string _tell_number;
		public string tell_number
		{
			get => _tell_number;
			set
			{
				if (_tell_number == value)
					return;
				_tell_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///FAX
		///</summary>
		private string _fax_number;
		public string fax_number
		{
			get => _fax_number;
			set
			{
				if (_fax_number == value)
					return;
				_fax_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�n�}URL
		///</summary>
		private string _map_url;
		public string map_url
		{
			get => _map_url;
			set
			{
				if (_map_url == value)
					return;
				_map_url = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���l
		///</summary>
		private string _remark;
		public string remark
		{
			get => _remark;
			set
			{
				if (_remark == value)
					return;
				_remark = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����p�Z�� :�s���{�����{�Z��1�{�Z��2
		///</summary>
		private string _search_address;
		public string search_address
		{
			get => _search_address;
			set
			{
				if (_search_address == value)
					return;
				_search_address = value;
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


	public class m_propertiesCollection : ObservableCollection<m_properties> {
		public m_propertiesCollection(){
		}
	}
}
