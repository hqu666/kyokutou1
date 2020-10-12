using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �C�x���g
	/// </summary>
	public partial class Events
	{

		///<summary>
		///ID
		///</summary>
		private int _id;
		public int id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
			}
		}

		///<summary>
		///�_��ID :=�_��}�X�^.ID
		///</summary>
		private int _m_contract_id;
		public int m_contract_id
		{
			get => _m_contract_id;
			set
			{
				if (_m_contract_id == value)
					return;
				_m_contract_id = value;
			}
		}

		///<summary>
		///�Č�ID :=�Č����.ID
		///</summary>
		private int _t_project_base_id;
		public int t_project_base_id
		{
			get => _t_project_base_id;
			set
			{
				if (_t_project_base_id == value)
					return;
				_t_project_base_id = value;
			}
		}

		///<summary>
		///�C�x���g��� :���Œ�l�F�C�x���g���
		///</summary>
		private int _event_type;
		public int event_type
		{
			get => _event_type;
			set
			{
				if (_event_type == value)
					return;
				_event_type = value;
			}
		}

		///<summary>
		///�C�x���g�J�n�� :���o�^�Č���null
		///</summary>
		private DateTime _event_date_start;
		public DateTime event_date_start
		{
			get => _event_date_start;
			set
			{
				if (_event_date_start == value)
					return;
				_event_date_start = value;
			}
		}

		///<summary>
		///�C�x���g�J�n���� :���Œ�l�F�C�x���g����
		///</summary>
		private int _event_time_start;
		public int event_time_start
		{
			get => _event_time_start;
			set
			{
				if (_event_time_start == value)
					return;
				_event_time_start = value;
			}
		}

		///<summary>
		///�C�x���g�I����
		///</summary>
		private DateTime _event_date_end;
		public DateTime event_date_end
		{
			get => _event_date_end;
			set
			{
				if (_event_date_end == value)
					return;
				_event_date_end = value;
			}
		}

		///<summary>
		///�C�x���g�I������ :���Œ�l�F�C�x���g����
		///</summary>
		private int _event_time_end;
		public int event_time_end
		{
			get => _event_time_end;
			set
			{
				if (_event_time_end == value)
					return;
				_event_time_end = value;
			}
		}

		///<summary>
		///�I��
		///</summary>
		private bool _event_is_daylong;
		public bool event_is_daylong
		{
			get => _event_is_daylong;
			set
			{
				if (_event_is_daylong == value)
					return;
				_event_is_daylong = value;
			}
		}

		///<summary>
		///�^�C�g��
		///</summary>
		private string _event_title;
		public string event_title
		{
			get => _event_title;
			set
			{
				if (_event_title == value)
					return;
				_event_title = value;
			}
		}

		///<summary>
		///�ꏊ
		///</summary>
		private string _event_place;
		public string event_place
		{
			get => _event_place;
			set
			{
				if (_event_place == value)
					return;
				_event_place = value;
			}
		}

		///<summary>
		///����
		///</summary>
		private string _event_memo;
		public string event_memo
		{
			get => _event_memo;
			set
			{
				if (_event_memo == value)
					return;
				_event_memo = value;
			}
		}

		///<summary>
		///�X�e�[�^�X :���Œ�l�F�C�x���g�X�e�[�^�X
		///</summary>
		private int _event_status;
		public int event_status
		{
			get => _event_status;
			set
			{
				if (_event_status == value)
					return;
				_event_status = value;
			}
		}

		///<summary>
		///Google�C�x���gID
		///</summary>
		private string _google_id;
		public string google_id
		{
			get => _google_id;
			set
			{
				if (_google_id == value)
					return;
				_google_id = value;
			}
		}

		///<summary>
		///�w�i�F :���Œ�l�F�J���[��������ARGB�l�i�X���j
		///</summary>
		private string _event_bg_color;
		public string event_bg_color
		{
			get => _event_bg_color;
			set
			{
				if (_event_bg_color == value)
					return;
				_event_bg_color = value;
			}
		}

		///<summary>
		///�����F :ARGB�l�i�X���F�J���[�s�b�J�[�ɂ���Ă͓����x���t�^�����j
		///</summary>
		private string _event_font_color;
		public string event_font_color
		{
			get => _event_font_color;
			set
			{
				if (_event_font_color == value)
					return;
				_event_font_color = value;
			}
		}

		///<summary>
		///�쐬��
		///</summary>
		private int _creater;
		public int creater
		{
			get => _creater;
			set
			{
				if (_creater == value)
					return;
				_creater = value;
			}
		}

		///<summary>
		///�쐬����
		///</summary>
		private DateTime _created_on;
		public DateTime created_on
		{
			get => _created_on;
			set
			{
				if (_created_on == value)
					return;
				_created_on = value;
			}
		}

		///<summary>
		///�X�V��
		///</summary>
		private int _modifier;
		public int modifier
		{
			get => _modifier;
			set
			{
				if (_modifier == value)
					return;
				_modifier = value;
			}
		}

		///<summary>
		///�X�V����
		///</summary>
		private DateTime _modifier_on;
		public DateTime modifier_on
		{
			get => _modifier_on;
			set
			{
				if (_modifier_on == value)
					return;
				_modifier_on = value;
			}
		}

		///<summary>
		///�폜����
		///</summary>
		private DateTime _deleted_on;
		public DateTime deleted_on
		{
			get => _deleted_on;
			set
			{
				if (_deleted_on == value)
					return;
				_deleted_on = value;
			}
		}

	}


	public class EventsCollection : ObservableCollection<Events> {
		public EventsCollection(){
		}
	}
}
