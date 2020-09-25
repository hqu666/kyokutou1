using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// オプション設定
	/// </summary>
	public partial class OptionSettings{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///ログインユーザーID :=ログインユーザーマスタ.ID
		public int m_login_users_staff_id { get; set; }
		///明細行削除時メッセージ
		public int statement_delete_message { get; set; }
		///テーマ :※固定値定義書：Z-5.テーマ名
		public int theme { get; set; }
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

	public class OptionSettingsCollection : ObservableCollection<OptionSettings> {
		public OptionSettingsCollection(){
		}
	}
}
