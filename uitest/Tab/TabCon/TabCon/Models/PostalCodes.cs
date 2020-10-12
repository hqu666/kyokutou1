using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// —X•Ö”Ô†ƒ}ƒXƒ^
	/// </summary>
	public partial class PostalCodes
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
		///“s“¹•{Œ§–¼
		///</summary>
		private string _prefectures_name;
		public string prefectures_name
		{
			get => _prefectures_name;
			set
			{
				if (_prefectures_name == value)
					return;
				_prefectures_name = value;
			}
		}

		///<summary>
		///“s“¹•{Œ§–¼ƒJƒi
		///</summary>
		private string _prefectures_kana;
		public string prefectures_kana
		{
			get => _prefectures_kana;
			set
			{
				if (_prefectures_kana == value)
					return;
				_prefectures_kana = value;
			}
		}

		///<summary>
		///ZŠ
		///</summary>
		private string _address;
		public string address
		{
			get => _address;
			set
			{
				if (_address == value)
					return;
				_address = value;
			}
		}

		///<summary>
		///ZŠƒJƒi
		///</summary>
		private string _address_kana;
		public string address_kana
		{
			get => _address_kana;
			set
			{
				if (_address_kana == value)
					return;
				_address_kana = value;
			}
		}

		///<summary>
		///ì¬Ò
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
		///ì¬“ú
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
		///XVÒ
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
		///XV“ú
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

		///<summary>
		///íœ“ú
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
			}
		}

	}


	public class PostalCodesCollection : ObservableCollection<PostalCodes> {
		public PostalCodesCollection(){
		}
	}
}
