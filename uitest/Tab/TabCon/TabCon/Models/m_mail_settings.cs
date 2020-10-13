using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ���[���ݒ�}�X�^
	/// </summary>
	public partial class m_mail_settings : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�e���v���[�gID
		///</summary>
		private int _template_id;
		public int template_id
		{
			get => _template_id;
			set
			{
				if (_template_id == value)
					return;
				_template_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�e���v���[�g��
		///</summary>
		private string _template_name;
		public string template_name
		{
			get => _template_name;
			set
			{
				if (_template_name == value)
					return;
				_template_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���o�l
		///</summary>
		private string _mail_from;
		public string mail_from
		{
			get => _mail_from;
			set
			{
				if (_mail_from == value)
					return;
				_mail_from = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///CC
		///</summary>
		private string _mail_cc;
		public string mail_cc
		{
			get => _mail_cc;
			set
			{
				if (_mail_cc == value)
					return;
				_mail_cc = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///BCC
		///</summary>
		private string _mail_bcc;
		public string mail_bcc
		{
			get => _mail_bcc;
			set
			{
				if (_mail_bcc == value)
					return;
				_mail_bcc = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����
		///</summary>
		private string _subject;
		public string subject
		{
			get => _subject;
			set
			{
				if (_subject == value)
					return;
				_subject = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�{��
		///</summary>
		private string _contents;
		public string contents
		{
			get => _contents;
			set
			{
				if (_contents == value)
					return;
				_contents = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///����
		///</summary>
		private string _signature;
		public string signature
		{
			get => _signature;
			set
			{
				if (_signature == value)
					return;
				_signature = value;
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

	}


	public class m_mail_settingsCollection : ObservableCollection<m_mail_settings> {
		public m_mail_settingsCollection(){
		}
	}
}
