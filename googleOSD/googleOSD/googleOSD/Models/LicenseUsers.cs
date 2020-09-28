using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���C�Z���X���[�U�[�A�g�}�X�^
	/// </summary>
	public partial class LicenseUsers{
		///ID
		public int id { get; set; }
		///���C�Z���XID :=���C�Z���X�}�X�^.ID
		public int m_license_id { get; set; }
		///���O�C�����[�U�[ID :=���O�C�����[�U�[�}�X�^.ID
		public int m_login_users_staff_id { get; set; }
		///���� :���Œ�l�F����
		public int level { get; set; }
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

	public class LicenseUsersCollection : ObservableCollection<LicenseUsers> {
		public LicenseUsersCollection(){
		}
	}
}
