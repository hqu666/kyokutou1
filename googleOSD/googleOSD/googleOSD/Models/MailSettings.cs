using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���[���ݒ�}�X�^
	/// </summary>
	public partial class MailSettings{
		///ID
		public int id { get; set; }
		///�e���v���[�gID
		public int template_id { get; set; }
		///�e���v���[�g��
		public string template_name { get; set; }
		///���o�l
		public string mail_from { get; set; }
		///CC
		public string mail_cc { get; set; }
		///BCC
		public string mail_bcc { get; set; }
		///����
		public string subject { get; set; }
		///�{��
		public string contents { get; set; }
		///����
		public string signature { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }
		///�폜����:
		public DateTime deleted_at { get; set; }
	}

	public class MailSettingsCollection : ObservableCollection<MailSettings> {
		public MailSettingsCollection(){
		}
	}
}
