using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �o�[�W�����}�X�^
	/// </summary>
	public partial class Versions{
		///ID
		public int id { get; set; }
		///�o�[�W������
		public string version_name { get; set; }
		///�O�o�[�W����ID :=�o�[�W�������.ID
		public int pre_m_version_id { get; set; }
		///�o�[�W�����n��
		public decimal version_lineage { get; set; }
		///�A�v���P�[�V������ :EXE��
		public string application_name { get; set; }
		///�A�v���P�[�V�����p�X :�_�E�����[�h�p�̃p�X
		public string application_path { get; set; }
		///�z�M�J�n��
		public DateTime delivery_date_start { get; set; }
		///�z�M�I����
		public DateTime delivery_date_end { get; set; }
		///�o�[�W�����A�b�v����
		public DateTime version_upgrade_deadline { get; set; }
		///�z�M��~�t���O
		public int undelivered_flag { get; set; }
		///�o�[�W�����T�v :�o�[�W�����A�b�v���e
		public string overview { get; set; }
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

	public class VersionsCollection : ObservableCollection<Versions> {
		public VersionsCollection(){
		}
	}
}
