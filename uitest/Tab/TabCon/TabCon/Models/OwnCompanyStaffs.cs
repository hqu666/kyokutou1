using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ���ВS���҃}�X�^
	/// </summary>
	public partial class OwnCompanyStaffs
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
			}
		}

		///<summary>
		///����ID :����}�X�^��ID
		///</summary>
		private int _m_department_id;
		public int m_department_id
		{
			get => _m_department_id;
			set
			{
				if (_m_department_id == value)
					return;
				_m_department_id = value;
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
			}
		}

		///<summary>
		///���[���A�h���X
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
			}
		}

		///<summary>
		///�\���P
		///</summary>
		private string _spare_1;
		public string spare_1
		{
			get => _spare_1;
			set
			{
				if (_spare_1 == value)
					return;
				_spare_1 = value;
			}
		}

		///<summary>
		///�\���Q
		///</summary>
		private string _spare_2;
		public string spare_2
		{
			get => _spare_2;
			set
			{
				if (_spare_2 == value)
					return;
				_spare_2 = value;
			}
		}

		///<summary>
		///�\���R
		///</summary>
		private string _spare_3;
		public string spare_3
		{
			get => _spare_3;
			set
			{
				if (_spare_3 == value)
					return;
				_spare_3 = value;
			}
		}

		///<summary>
		///�\��N1
		///</summary>
		private string _spare_n1;
		public string spare_n1
		{
			get => _spare_n1;
			set
			{
				if (_spare_n1 == value)
					return;
				_spare_n1 = value;
			}
		}

		///<summary>
		///�\��N2
		///</summary>
		private string _spare_n2;
		public string spare_n2
		{
			get => _spare_n2;
			set
			{
				if (_spare_n2 == value)
					return;
				_spare_n2 = value;
			}
		}

		///<summary>
		///�\��N3
		///</summary>
		private string _spare_n3;
		public string spare_n3
		{
			get => _spare_n3;
			set
			{
				if (_spare_n3 == value)
					return;
				_spare_n3 = value;
			}
		}

		///<summary>
		///�\��D1
		///</summary>
		private string _spare_d1;
		public string spare_d1
		{
			get => _spare_d1;
			set
			{
				if (_spare_d1 == value)
					return;
				_spare_d1 = value;
			}
		}

		///<summary>
		///�\��D�Q
		///</summary>
		private string _spare_d2;
		public string spare_d2
		{
			get => _spare_d2;
			set
			{
				if (_spare_d2 == value)
					return;
				_spare_d2 = value;
			}
		}

		///<summary>
		///�\��D3
		///</summary>
		private string _spare_d3;
		public string spare_d3
		{
			get => _spare_d3;
			set
			{
				if (_spare_d3 == value)
					return;
				_spare_d3 = value;
			}
		}

		///<summary>
		///��ӃC���[�W
		///</summary>
		private string _stamp_image;
		public string stamp_image
		{
			get => _stamp_image;
			set
			{
				if (_stamp_image == value)
					return;
				_stamp_image = value;
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


	public class OwnCompanyStaffsCollection : ObservableCollection<OwnCompanyStaffs> {
		public OwnCompanyStaffsCollection(){
		}
	}
}
