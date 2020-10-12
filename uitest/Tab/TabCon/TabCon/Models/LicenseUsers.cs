using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ライセンスユーザー連携マスタ
	/// </summary>
	public partial class LicenseUsers
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
		///ログインユーザーID :=ログインユーザーマスタ.ID
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
		///権限 :※固定値：権限
		///</summary>
		private int _level;
		public int level
		{
			get => _level;
			set
			{
				if (_level == value)
					return;
				_level = value;
			}
		}

		///<summary>
		///作成者
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
		///作成日時
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
		///更新者
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
		///更新日時
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
		///削除日時
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


	public class LicenseUsersCollection : ObservableCollection<LicenseUsers> {
		public LicenseUsersCollection(){
		}
	}
}
