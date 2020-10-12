using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ÌÔÝè
	/// </summary>
	public partial class NumberingSettings
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
			}
		}

		///<summary>
		///ÌÔíÊ :¦ÅèlFÌÔíÊ
		///</summary>
		private int _numbering_type;
		public int numbering_type
		{
			get => _numbering_type;
			set
			{
				if (_numbering_type == value)
					return;
				_numbering_type = value;
			}
		}

		///<summary>
		///Úª«^Úö« :¦ÅèlFÚª«^Úö«
		///</summary>
		private int _prefix_suffix;
		public int prefix_suffix
		{
			get => _prefix_suffix;
			set
			{
				if (_prefix_suffix == value)
					return;
				_prefix_suffix = value;
			}
		}

		///<summary>
		///¯Êq
		///</summary>
		private string _identifier;
		public string identifier
		{
			get => _identifier;
			set
			{
				if (_identifier == value)
					return;
				_identifier = value;
			}
		}

		///<summary>
		///ÌÔ[ :¦ÅèlFÌÔ[
		///</summary>
		private int _numbering_rule;
		public int numbering_rule
		{
			get => _numbering_rule;
			set
			{
				if (_numbering_rule == value)
					return;
				_numbering_rule = value;
			}
		}

		///<summary>
		///
		///</summary>
		private int _number_of_digits;
		public int number_of_digits
		{
			get => _number_of_digits;
			set
			{
				if (_number_of_digits == value)
					return;
				_number_of_digits = value;
			}
		}

		///<summary>
		///ÅIÔ
		///</summary>
		private int _final_number;
		public int final_number
		{
			get => _final_number;
			set
			{
				if (_final_number == value)
					return;
				_final_number = value;
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
			}
		}

	}


	public class NumberingSettingsCollection : ObservableCollection<NumberingSettings> {
		public NumberingSettingsCollection(){
		}
	}
}
