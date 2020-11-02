using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �X�֔ԍ��}�X�^
	/// </summary>
	public partial class m_postal_codes : NotificationObject
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
		///�s���{����
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�s���{�����J�i
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Z��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�Z���J�i
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�쐬��
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
		///�쐬����
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
		///�X�V��
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
		///�X�V����
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
		///�폜����
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


	public class m_postal_codesCollection : ObservableCollection<m_postal_codes> {
		public m_postal_codesCollection(){
		}
	}
}
