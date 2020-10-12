using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �Ǘ����[�U�[�}�X�^
	/// </summary>
	public partial class AdminUsers
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
		///���O�C��ID :���[���A�h���X
		///</summary>
		private string _login_id;
		public string login_id
		{
			get => _login_id;
			set
			{
				if (_login_id == value)
					return;
				_login_id = value;
			}
		}

		///<summary>
		///�p�X���[�h
		///</summary>
		private string _password;
		public string password
		{
			get => _password;
			set
			{
				if (_password == value)
					return;
				_password = value;
			}
		}

		///<summary>
		///����
		///</summary>
		private string _admin_name;
		public string admin_name
		{
			get => _admin_name;
			set
			{
				if (_admin_name == value)
					return;
				_admin_name = value;
			}
		}

		///<summary>
		///����
		///</summary>
		private string _department;
		public string department
		{
			get => _department;
			set
			{
				if (_department == value)
					return;
				_department = value;
			}
		}

		///<summary>
		///�V�X�e���Ǘ��Ҍ��� :0�F��ʁ@1�F�Ǘ���
		///</summary>
		private int _system_admin_permission;
		public int system_admin_permission
		{
			get => _system_admin_permission;
			set
			{
				if (_system_admin_permission == value)
					return;
				_system_admin_permission = value;
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


	public class AdminUsersCollection : ObservableCollection<AdminUsers> {
		public AdminUsersCollection(){
		}
	}
}
