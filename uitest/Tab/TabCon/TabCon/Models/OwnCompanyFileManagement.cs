using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ���Ѓt�@�C���Ǘ�
	/// </summary>
	public partial class OwnCompanyFileManagement
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
		///�_��ID :=�_����.ID
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
		///����
		///</summary>
		private string _document_name;
		public string document_name
		{
			get => _document_name;
			set
			{
				if (_document_name == value)
					return;
				_document_name = value;
			}
		}

		///<summary>
		///�t�@�C���p�X :�t���p�X
		///</summary>
		private string _file_path;
		public string file_path
		{
			get => _file_path;
			set
			{
				if (_file_path == value)
					return;
				_file_path = value;
			}
		}

		///<summary>
		///�t�@�C������
		///</summary>
		private string _file_name;
		public string file_name
		{
			get => _file_name;
			set
			{
				if (_file_name == value)
					return;
				_file_name = value;
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


	public class OwnCompanyFileManagementCollection : ObservableCollection<OwnCompanyFileManagement> {
		public OwnCompanyFileManagementCollection(){
		}
	}
}
