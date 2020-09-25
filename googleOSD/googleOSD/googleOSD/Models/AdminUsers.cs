using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Ǘ����[�U�[�}�X�^
	/// </summary>
	public partial class AdminUsers{
		///ID
		public int id { get; set; }
		///���O�C��ID :���[���A�h���X
		public string login_id { get; set; }
		///�p�X���[�h
		public string password { get; set; }
		///����
		public string admin_name { get; set; }
		///����
		public string department { get; set; }
		///�V�X�e���Ǘ��Ҍ��� :0�F��ʁ@1�F�Ǘ���
		public int system_admin_permission { get; set; }
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

	public class AdminUsersCollection : ObservableCollection<AdminUsers> {
		public AdminUsersCollection(){
		}
	}
}
