using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ���O�C�����[�U�[
	/// </summary>
	public partial class s_loging_users : NotificationObject
	{

		///<summary>
		///���C�Z���XID :=���C�Z���X�}�X�^.ID
		///</summary>
		private int _m_license_id;
		public int m_license_id
		{
			get => _m_license_id;
			set
			{
				if (_m_license_id == value)
					return;
				_m_license_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���O�C�����[�U�[ID
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
		///�z�X�g��
		///</summary>
		private string _host_name;
		public string host_name
		{
			get => _host_name;
			set
			{
				if (_host_name == value)
					return;
				_host_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���O�I������
		///</summary>
		private DateTime _logon_time;
		public DateTime logon_time
		{
			get => _logon_time;
			set
			{
				if (_logon_time == value)
					return;
				_logon_time = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�ŏI���쎞��
		///</summary>
		private DateTime _lasted_operation_time;
		public DateTime lasted_operation_time
		{
			get => _lasted_operation_time;
			set
			{
				if (_lasted_operation_time == value)
					return;
				_lasted_operation_time = value;
				RaisePropertyChanged();
			}
		}

	}


	public class s_loging_usersCollection : ObservableCollection<s_loging_users> {
		public s_loging_usersCollection(){
		}
	}
}
