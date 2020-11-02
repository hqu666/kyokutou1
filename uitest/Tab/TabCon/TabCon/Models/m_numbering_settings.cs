using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// �̔Ԑݒ�
	/// </summary>
	public partial class m_numbering_settings : NotificationObject
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
		///�̔Ԏ�� :���Œ�l�F�̔Ԏ��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ړ����^�ڔ��� :���Œ�l�F�ړ����^�ڔ���
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���ʎq
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�̔ԃ��[�� :���Œ�l�F�̔ԃ��[��
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ŏI�ԍ�
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


	public class m_numbering_settingsCollection : ObservableCollection<m_numbering_settings> {
		public m_numbering_settingsCollection(){
		}
	}
}
