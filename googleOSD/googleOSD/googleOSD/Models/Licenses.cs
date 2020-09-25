using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���C�Z���X�}�X�^
	/// </summary>
	public partial class Licenses{
		///ID
		public int id { get; set; }
		///���C�Z���X�L�[
		public string license_key { get; set; }
		///��~�t���O
		public int stop_flag { get; set; }
		///�L�������iFROM)
		public DateTime effective_period_from { get; set; }
		///�L�������iTO�j
		public DateTime effective_period_to { get; set; }
		///�v����ID :���v�����}�X�^�DID
		public int m_plan_id { get; set; }
		///�X�V�`�F�b�N�Ԋu :���P�ʂŐݒ�
		public int check_interval { get; set; }
		///�o�[�W�����A�b�v�\Ver :0�F��ɍŐV�A�ȊO�F�o�[�W�����}�X�^.ID
		public int m_version_id { get; set; }
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

	public class LicensesCollection : ObservableCollection<Licenses> {
		public LicensesCollection(){
		}
	}
}
