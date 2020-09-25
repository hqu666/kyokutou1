using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �I�v�V�����ݒ�
	/// </summary>
	public partial class OptionSettings{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///���O�C�����[�U�[ID :=���O�C�����[�U�[�}�X�^.ID
		public int m_login_users_staff_id { get; set; }
		///���׍s�폜�����b�Z�[�W
		public int statement_delete_message { get; set; }
		///�e�[�} :���Œ�l��`���FZ-5.�e�[�}��
		public int theme { get; set; }
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

	public class OptionSettingsCollection : ObservableCollection<OptionSettings> {
		public OptionSettingsCollection(){
		}
	}
}
