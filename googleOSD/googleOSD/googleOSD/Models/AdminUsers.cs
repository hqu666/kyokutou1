using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 管理ユーザーマスタ
	/// </summary>
	public partial class AdminUsers{
		///ID
		public int id { get; set; }
		///ログインID :メールアドレス
		public string login_id { get; set; }
		///パスワード
		public string password { get; set; }
		///氏名
		public string admin_name { get; set; }
		///部署
		public string department { get; set; }
		///システム管理者権限 :0：一般　1：管理者
		public int system_admin_permission { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class AdminUsersCollection : ObservableCollection<AdminUsers> {
		public AdminUsersCollection(){
		}
	}
}
