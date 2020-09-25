using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Googleアカウント認証テーブル
	/// </summary>
	public partial class GoogleAccount{
		///ID
		public int id { get; set; }
		///契約ID
		public int m_contract_id { get; set; }
		///Googleアカウント :@gmail.comのアカウント
		public string google_account { get; set; }
		///GoogleクライアントID :GoogleAPIが使用するアカウント相当情報
		public string client_id { get; set; }
		///Googleクライアントシークレット :上記のパスワード相当相当
		public string client_secret { get; set; }
		///GoogleプロジェクトID :GoogleAPIの登録先名
		public string project_id { get; set; }
		///カレンダID
		public string calender_id { get; set; }
		///ドライブID
		public string drive_id { get; set; }
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

	public class GoogleAccountCollection : ObservableCollection<GoogleAccount> {
		public GoogleAccountCollection(){
		}
	}
}
