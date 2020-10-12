using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// •¨Œƒ}ƒXƒ^
	/// </summary>
	public partial class Properties
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
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
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
		///•¨ŒƒR[ƒh
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
			}
		}

		///<summary>
		///•¨Œ–¼Ì
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
			}
		}

		///<summary>
		///•¨ŒƒJƒi
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
			}
		}

		///<summary>
		///{å–¼
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
			}
		}

		///<summary>
		///—X•Ö”Ô†
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
			}
		}

		///<summary>
		///“s“¹•{Œ§ :=“s“¹•{Œ§ƒ}ƒXƒ^.ID
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
			}
		}

		///<summary>
		///ZŠ1
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
			}
		}

		///<summary>
		///ZŠ2
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
			}
		}

		///<summary>
		///’n}URL
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
			}
		}

		///<summary>
		///”õl
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
			}
		}

		///<summary>
		///ŒŸõ—pZŠ :“s“¹•{Œ§–¼{ZŠ1{ZŠ2
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
			}
		}

		///<summary>
		///ì¬“ú
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
			}
		}

		///<summary>
		///XV“ú
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
		///íœ“ú
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


	public class PropertiesCollection : ObservableCollection<Properties> {
		public PropertiesCollection(){
		}
	}
}
