using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// メール設定マスタ
	/// </summary>
	public partial class MailSettings{
		///ID
		public int id { get; set; }
		///テンプレートID
		public int template_id { get; set; }
		///テンプレート名
		public string template_name { get; set; }
		///差出人
		public string mail_from { get; set; }
		///CC
		public string mail_cc { get; set; }
		///BCC
		public string mail_bcc { get; set; }
		///件名
		public string subject { get; set; }
		///本文
		public string contents { get; set; }
		///署名
		public string signature { get; set; }
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

	public class MailSettingsCollection : ObservableCollection<MailSettings> {
		public MailSettingsCollection(){
		}
	}
}
