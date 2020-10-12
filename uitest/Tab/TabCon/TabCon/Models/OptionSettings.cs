using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �I�v�V�����ݒ�
	/// </summary>
	public partial class OptionSettings
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
			}
		}

		///<summary>
		///���׍s�폜�����b�Z�[�W
		///</summary>
		private int _statement_delete_message;
		public int statement_delete_message
		{
			get => _statement_delete_message;
			set
			{
				if (_statement_delete_message == value)
					return;
				_statement_delete_message = value;
			}
		}

		///<summary>
		///�e�[�} :���Œ�l��`���FZ-5.�e�[�}��
		///</summary>
		private int _theme;
		public int theme
		{
			get => _theme;
			set
			{
				if (_theme == value)
					return;
				_theme = value;
			}
		}

		///<summary>
		///�`�[���׃p�^�[��ID :=�`�[���׃p�^�[���}�X�^.ID
		///</summary>
		private int _m_slip_item_patterns_id;
		public int m_slip_item_patterns_id
		{
			get => _m_slip_item_patterns_id;
			set
			{
				if (_m_slip_item_patterns_id == value)
					return;
				_m_slip_item_patterns_id = value;
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
			}
		}

	}


	public class OptionSettingsCollection : ObservableCollection<OptionSettings> {
		public OptionSettingsCollection(){
		}
	}
}
