using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �o�[�W�����}�X�^
	/// </summary>
	public partial class Versions
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
		///�o�[�W������
		///</summary>
		private string _version_name;
		public string version_name
		{
			get => _version_name;
			set
			{
				if (_version_name == value)
					return;
				_version_name = value;
			}
		}

		///<summary>
		///�O�o�[�W����ID :=�o�[�W�������.ID
		///</summary>
		private int _pre_m_version_id;
		public int pre_m_version_id
		{
			get => _pre_m_version_id;
			set
			{
				if (_pre_m_version_id == value)
					return;
				_pre_m_version_id = value;
			}
		}

		///<summary>
		///�o�[�W�����n��
		///</summary>
		private decimal _version_lineage;
		public decimal version_lineage
		{
			get => _version_lineage;
			set
			{
				if (_version_lineage == value)
					return;
				_version_lineage = value;
			}
		}

		///<summary>
		///�A�v���P�[�V������ :EXE��
		///</summary>
		private string _application_name;
		public string application_name
		{
			get => _application_name;
			set
			{
				if (_application_name == value)
					return;
				_application_name = value;
			}
		}

		///<summary>
		///�A�v���P�[�V�����p�X :�_�E�����[�h�p�̃p�X
		///</summary>
		private string _application_path;
		public string application_path
		{
			get => _application_path;
			set
			{
				if (_application_path == value)
					return;
				_application_path = value;
			}
		}

		///<summary>
		///�z�M�J�n��
		///</summary>
		private DateTime _delivery_date_start;
		public DateTime delivery_date_start
		{
			get => _delivery_date_start;
			set
			{
				if (_delivery_date_start == value)
					return;
				_delivery_date_start = value;
			}
		}

		///<summary>
		///�z�M�I����
		///</summary>
		private DateTime _delivery_date_end;
		public DateTime delivery_date_end
		{
			get => _delivery_date_end;
			set
			{
				if (_delivery_date_end == value)
					return;
				_delivery_date_end = value;
			}
		}

		///<summary>
		///�o�[�W�����A�b�v����
		///</summary>
		private DateTime _version_upgrade_deadline;
		public DateTime version_upgrade_deadline
		{
			get => _version_upgrade_deadline;
			set
			{
				if (_version_upgrade_deadline == value)
					return;
				_version_upgrade_deadline = value;
			}
		}

		///<summary>
		///�z�M��~�t���O
		///</summary>
		private int _undelivered_flag;
		public int undelivered_flag
		{
			get => _undelivered_flag;
			set
			{
				if (_undelivered_flag == value)
					return;
				_undelivered_flag = value;
			}
		}

		///<summary>
		///�o�[�W�����T�v :�o�[�W�����A�b�v���e
		///</summary>
		private string _overview;
		public string overview
		{
			get => _overview;
			set
			{
				if (_overview == value)
					return;
				_overview = value;
			}
		}

		///<summary>
		///�쐬��
		///</summary>
		private int _created_user;
		public int created_user
		{
			get => _created_user;
			set
			{
				if (_created_user == value)
					return;
				_created_user = value;
			}
		}

		///<summary>
		///�쐬����
		///</summary>
		private DateTime _created_at;
		public DateTime created_at
		{
			get => _created_at;
			set
			{
				if (_created_at == value)
					return;
				_created_at = value;
			}
		}

		///<summary>
		///�X�V��
		///</summary>
		private int _updated_user;
		public int updated_user
		{
			get => _updated_user;
			set
			{
				if (_updated_user == value)
					return;
				_updated_user = value;
			}
		}

		///<summary>
		///�X�V����
		///</summary>
		private DateTime _updated_at;
		public DateTime updated_at
		{
			get => _updated_at;
			set
			{
				if (_updated_at == value)
					return;
				_updated_at = value;
			}
		}

		///<summary>
		///�폜����
		///</summary>
		private DateTime _deleted_at;
		public DateTime deleted_at
		{
			get => _deleted_at;
			set
			{
				if (_deleted_at == value)
					return;
				_deleted_at = value;
			}
		}

	}


	public class VersionsCollection : ObservableCollection<Versions> {
		public VersionsCollection(){
		}
	}
}
