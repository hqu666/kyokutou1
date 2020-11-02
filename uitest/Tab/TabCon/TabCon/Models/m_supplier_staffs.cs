using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ����敔��S���҃}�X�^
	/// </summary>
	public partial class m_supplier_staffs : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����ID :=�����}�X�^.ID
		///</summary>
		private int _m_supplier_id;
		public int m_supplier_id
		{
			get => _m_supplier_id;
			set
			{
				if (_m_supplier_id == value)
					return;
				_m_supplier_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�S���҃R�[�h
		///</summary>
		private string _staff_cd;
		public string staff_cd
		{
			get => _staff_cd;
			set
			{
				if (_staff_cd == value)
					return;
				_staff_cd = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�S���Җ�
		///</summary>
		private string _staff_name;
		public string staff_name
		{
			get => _staff_name;
			set
			{
				if (_staff_name == value)
					return;
				_staff_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///��E
		///</summary>
		private string _position;
		public string position
		{
			get => _position;
			set
			{
				if (_position == value)
					return;
				_position = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�A����
		///</summary>
		private string _contact_number;
		public string contact_number
		{
			get => _contact_number;
			set
			{
				if (_contact_number == value)
					return;
				_contact_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�g�ѓd�b
		///</summary>
		private string _mobile_number;
		public string mobile_number
		{
			get => _mobile_number;
			set
			{
				if (_mobile_number == value)
					return;
				_mobile_number = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Email
		///</summary>
		private string _email;
		public string email
		{
			get => _email;
			set
			{
				if (_email == value)
					return;
				_email = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///���l
		///</summary>
		private string _remark;
		public string remark
		{
			get => _remark;
			set
			{
				if (_remark == value)
					return;
				_remark = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///�����t���O
		///</summary>
		private int _invalid_flg;
		public int invalid_flg
		{
			get => _invalid_flg;
			set
			{
				if (_invalid_flg == value)
					return;
				_invalid_flg = value;
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


	public class m_supplier_staffsCollection : ObservableCollection<m_supplier_staffs> {
		public m_supplier_staffsCollection(){
		}
	}
}
