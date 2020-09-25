using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Google�A�J�E���g�F�؃e�[�u��
	/// </summary>
	public partial class GoogleAccount{
		///ID
		public int id { get; set; }
		///�_��ID
		public int m_contract_id { get; set; }
		///Google�A�J�E���g :@gmail.com�̃A�J�E���g
		public string google_account { get; set; }
		///Google�N���C�A���gID :GoogleAPI���g�p����A�J�E���g�������
		public string client_id { get; set; }
		///Google�N���C�A���g�V�[�N���b�g :��L�̃p�X���[�h��������
		public string client_secret { get; set; }
		///Google�v���W�F�N�gID :GoogleAPI�̓o�^�於
		public string project_id { get; set; }
		///�J�����_ID
		public string calender_id { get; set; }
		///�h���C�uID
		public string drive_id { get; set; }
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

	public class GoogleAccountCollection : ObservableCollection<GoogleAccount> {
		public GoogleAccountCollection(){
		}
	}
}
