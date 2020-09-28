using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ライセンスユーザー連携マスタ
	/// </summary>
	public partial class LicenseUsers{
		///ID
		public int id { get; set; }
		///ライセンスID :=ライセンスマスタ.ID
		public int m_license_id { get; set; }
		///ログインユーザーID :=ログインユーザーマスタ.ID
		public int m_login_users_staff_id { get; set; }
		///権限 :※固定値：権限
		public int level { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }
		///削除日時:
		public DateTime deleted_at { get; set; }
	}

	public class LicenseUsersCollection : ObservableCollection<LicenseUsers> {
		public LicenseUsersCollection(){
		}
	}
}
