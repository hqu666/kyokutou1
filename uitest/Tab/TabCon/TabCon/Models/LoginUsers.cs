using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// ���O�C�����[�U�[�}�X�^
	/// </summary>
	public partial class LoginUsers
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
		///���O�C��ID :���[���A�h���X
		///</summary>
		private string _login_id;
		public string login_id
		{
			get => _login_id;
			set
			{
				if (_login_id == value)
					return;
				_login_id = value;
			}
		}

		///<summary>
		///�p�X���[�h
		///</summary>
		private string _password;
		public string password
		{
			get => _password;
			set
			{
				if (_password == value)
					return;
				_password = value;
			}
		}

		///<summary>
		///���O�C�����[�U�[��
		///</summary>
		private string _login_user_name;
		public string login_user_name
		{
			get => _login_user_name;
			set
			{
				if (_login_user_name == value)
					return;
				_login_user_name = value;
			}
		}

		///<summary>
		///�閧�̎���P :�I�������閧�̎���ID ���Œ�l�F�閧�̎���1
		///</summary>
		private int _secret_question_1;
		public int secret_question_1
		{
			get => _secret_question_1;
			set
			{
				if (_secret_question_1 == value)
					return;
				_secret_question_1 = value;
			}
		}

		///<summary>
		///�閧�̓����P
		///</summary>
		private string _secret_answer_1;
		public string secret_answer_1
		{
			get => _secret_answer_1;
			set
			{
				if (_secret_answer_1 == value)
					return;
				_secret_answer_1 = value;
			}
		}

		///<summary>
		///�閧�̎���Q :�I�������閧�̎���ID ���Œ�l�F�閧�̎���2
		///</summary>
		private int _secret_question_2;
		public int secret_question_2
		{
			get => _secret_question_2;
			set
			{
				if (_secret_question_2 == value)
					return;
				_secret_question_2 = value;
			}
		}

		///<summary>
		///�閧�̓����Q
		///</summary>
		private string _secret_answer_2;
		public string secret_answer_2
		{
			get => _secret_answer_2;
			set
			{
				if (_secret_answer_2 == value)
					return;
				_secret_answer_2 = value;
			}
		}

		///<summary>
		///�閧�̎���R :�I�������閧�̎���ID ���Œ�l�F�閧�̎���3
		///</summary>
		private int _secret_question_3;
		public int secret_question_3
		{
			get => _secret_question_3;
			set
			{
				if (_secret_question_3 == value)
					return;
				_secret_question_3 = value;
			}
		}

		///<summary>
		///�閧�̓����R
		///</summary>
		private string _secret_answer_3;
		public string secret_answer_3
		{
			get => _secret_answer_3;
			set
			{
				if (_secret_answer_3 == value)
					return;
				_secret_answer_3 = value;
			}
		}

		///<summary>
		///�ŏI���O�C������
		///</summary>
		private DateTime _lasted_login_time;
		public DateTime lasted_login_time
		{
			get => _lasted_login_time;
			set
			{
				if (_lasted_login_time == value)
					return;
				_lasted_login_time = value;
			}
		}

		///<summary>
		///���p�X���[�h
		///</summary>
		private string _wrk_password;
		public string wrk_password
		{
			get => _wrk_password;
			set
			{
				if (_wrk_password == value)
					return;
				_wrk_password = value;
			}
		}

		///<summary>
		///���p�X���[�h�L������
		///</summary>
		private DateTime _wrk_password_limit;
		public DateTime wrk_password_limit
		{
			get => _wrk_password_limit;
			set
			{
				if (_wrk_password_limit == value)
					return;
				_wrk_password_limit = value;
			}
		}

		///<summary>
		///�X�e�[�^�X :0�F�L���A1�F����
		///</summary>
		private int _status;
		public int status
		{
			get => _status;
			set
			{
				if (_status == value)
					return;
				_status = value;
			}
		}

		///<summary>
		///�Č��Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		///</summary>
		private bool _project_management_permission;
		public bool project_management_permission
		{
			get => _project_management_permission;
			set
			{
				if (_project_management_permission == value)
					return;
				_project_management_permission = value;
			}
		}

		///<summary>
		///�������� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		///</summary>
		private bool _cost_item_permission;
		public bool cost_item_permission
		{
			get => _cost_item_permission;
			set
			{
				if (_cost_item_permission == value)
					return;
				_cost_item_permission = value;
			}
		}

		///<summary>
		///�����Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		///</summary>
		private bool _order_management_permission;
		public bool order_management_permission
		{
			get => _order_management_permission;
			set
			{
				if (_order_management_permission == value)
					return;
				_order_management_permission = value;
			}
		}

		///<summary>
		///�����E���|���߁A�����Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		///</summary>
		private bool _bill_closing_deposit_mng_permission;
		public bool bill_closing_deposit_mng_permission
		{
			get => _bill_closing_deposit_mng_permission;
			set
			{
				if (_bill_closing_deposit_mng_permission == value)
					return;
				_bill_closing_deposit_mng_permission = value;
			}
		}

		///<summary>
		///�x���E���|���߁A�o���Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		///</summary>
		private bool _pay_closing_withdrawal_mng_permission;
		public bool pay_closing_withdrawal_mng_permission
		{
			get => _pay_closing_withdrawal_mng_permission;
			set
			{
				if (_pay_closing_withdrawal_mng_permission == value)
					return;
				_pay_closing_withdrawal_mng_permission = value;
			}
		}

		///<summary>
		///�����ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		///</summary>
		private bool _account_setting_permission;
		public bool account_setting_permission
		{
			get => _account_setting_permission;
			set
			{
				if (_account_setting_permission == value)
					return;
				_account_setting_permission = value;
			}
		}

		///<summary>
		///���Аݒ�P (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		///</summary>
		private bool _own_company_setting_1_permission;
		public bool own_company_setting_1_permission
		{
			get => _own_company_setting_1_permission;
			set
			{
				if (_own_company_setting_1_permission == value)
					return;
				_own_company_setting_1_permission = value;
			}
		}

		///<summary>
		///���Аݒ�Q (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		///</summary>
		private bool _own_company_setting_2_permission;
		public bool own_company_setting_2_permission
		{
			get => _own_company_setting_2_permission;
			set
			{
				if (_own_company_setting_2_permission == value)
					return;
				_own_company_setting_2_permission = value;
			}
		}

		///<summary>
		///�\�Z�ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		///</summary>
		private bool _budget_setting_permission;
		public bool budget_setting_permission
		{
			get => _budget_setting_permission;
			set
			{
				if (_budget_setting_permission == value)
					return;
				_budget_setting_permission = value;
			}
		}

		///<summary>
		///���̐ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		///</summary>
		private bool _name_setting_permission;
		public bool name_setting_permission
		{
			get => _name_setting_permission;
			set
			{
				if (_name_setting_permission == value)
					return;
				_name_setting_permission = value;
			}
		}

		///<summary>
		///�V�X�e���ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		///</summary>
		private bool _sysytem_setting_permission;
		public bool sysytem_setting_permission
		{
			get => _sysytem_setting_permission;
			set
			{
				if (_sysytem_setting_permission == value)
					return;
				_sysytem_setting_permission = value;
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


	public class LoginUsersCollection : ObservableCollection<LoginUsers> {
		public LoginUsersCollection(){
		}
	}
}
