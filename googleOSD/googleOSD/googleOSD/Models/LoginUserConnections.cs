using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ログインユーザー自社担当連携マスタ
	/// </summary>
	public partial class LoginUserConnections{
		///ID
		public int id { get; set; }
		///自社担当者ID :=自社担当者マスタ.ID
		public int m_own_company_staff_id { get; set; }
		///ログインユーザーID :=ログインユーザーマスタ.ID
		public int m_login_users_staff_id { get; set; }
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

	public class LoginUserConnectionsCollection : ObservableCollection<LoginUserConnections> {
		public LoginUserConnectionsCollection(){
		}
	}
}
