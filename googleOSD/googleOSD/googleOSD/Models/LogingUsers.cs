using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ログインユーザー
	/// </summary>
	public partial class LogingUsers{
		///ライセンスID :=ライセンスマスタ.ID
		public int m_license_id { get; set; }
		///ログインユーザーID
		public int m_login_users_staff_id { get; set; }
		///ホスト名
		public string host_name { get; set; }
		///ログオン時間
		public DateTime logon_time { get; set; }
		///最終操作時間
		public DateTime lasted_operation_time { get; set; }

	}

	public class LogingUsersCollection : ObservableCollection<LogingUsers> {
		public LogingUsersCollection(){
		}
	}
}
