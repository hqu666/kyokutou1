using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���O�C�����[�U�[���ВS���A�g�}�X�^
	/// </summary>
	public partial class LoginUserConnections{
		///ID
		public int id { get; set; }
		///���ВS����ID :=���ВS���҃}�X�^.ID
		public int m_own_company_staff_id { get; set; }
		///���O�C�����[�U�[ID :=���O�C�����[�U�[�}�X�^.ID
		public int m_login_users_staff_id { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class LoginUserConnectionsCollection : ObservableCollection<LoginUserConnections> {
		public LoginUserConnectionsCollection(){
		}
	}
}
