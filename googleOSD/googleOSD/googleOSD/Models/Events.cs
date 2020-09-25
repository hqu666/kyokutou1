using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �C�x���g
	/// </summary>
	public partial class Events{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�Č�ID :=�Č����.ID
		public int t_project_base_id { get; set; }
		///�C�x���g��� :���Œ�l�F�C�x���g���
		public int event_type { get; set; }
		///�C�x���g�J�n�� :���o�^�Č���null
		public DateTime event_date_start { get; set; }
		///�C�x���g�J�n���� :���Œ�l�F�C�x���g����
		public int event_time_start { get; set; }
		///�C�x���g�I����
		public DateTime event_date_end { get; set; }
		///�C�x���g�I������ :���Œ�l�F�C�x���g����
		public int event_time_end { get; set; }
		///�I��
		public int event_is_daylong { get; set; }
		///�^�C�g��
		public string event_title { get; set; }
		///�ꏊ
		public string event_place { get; set; }
		///����
		public string event_memo { get; set; }
		///�X�e�[�^�X :���Œ�l�F�C�x���g�X�e�[�^�X
		public int event_status { get; set; }
		///Google�C�x���gID
		public string google_id { get; set; }
		///�w�i�F :���Œ�l�F�J���[��������ARGB�l�i�X���j
		public string event_bg_color { get; set; }
		///�����F :ARGB�l�i�X���F�J���[�s�b�J�[�ɂ���Ă͓����x���t�^�����j
		public string event_font_color { get; set; }
		///�쐬��
		public int creater { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int modifier { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class EventsCollection : ObservableCollection<Events> {
		public EventsCollection(){
		}
	}
}
