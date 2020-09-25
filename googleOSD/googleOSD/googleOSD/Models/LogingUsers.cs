using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���O�C�����[�U�[
	/// </summary>
	public partial class LogingUsers{
		///���C�Z���XID :=���C�Z���X�}�X�^.ID
		public int m_license_id { get; set; }
		///���O�C�����[�U�[ID
		public int m_login_users_staff_id { get; set; }
		///�z�X�g��
		public string host_name { get; set; }
		///���O�I������
		public DateTime logon_time { get; set; }
		///�ŏI���쎞��
		public DateTime lasted_operation_time { get; set; }

	}

	public class LogingUsersCollection : ObservableCollection<LogingUsers> {
		public LogingUsersCollection(){
		}
	}
}
