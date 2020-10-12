using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ログインユーザー
	/// </summary>
	public partial class LogingUsers
	{

		///<summary>
		///ライセンスID :=ライセンスマスタ.ID
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
			}
		}

		///<summary>
		///ログインユーザーID
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
		///ホスト名
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
			}
		}

		///<summary>
		///ログオン時間
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
			}
		}

		///<summary>
		///最終操作時間
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
			}
		}

	}


	public class LogingUsersCollection : ObservableCollection<LogingUsers> {
		public LogingUsersCollection(){
		}
	}
}
