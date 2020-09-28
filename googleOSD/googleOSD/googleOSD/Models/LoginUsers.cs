using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���O�C�����[�U�[�}�X�^
	/// </summary>
	public partial class LoginUsers{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///���O�C��ID :���[���A�h���X
		public string login_id { get; set; }
		///�p�X���[�h
		public string password { get; set; }
		///���O�C�����[�U�[��
		public string login_user_name { get; set; }
		///�閧�̎���P :�I�������閧�̎���ID ���Œ�l�F�閧�̎���1
		public int secret_question_1 { get; set; }
		///�閧�̓����P
		public string secret_answer_1 { get; set; }
		///�閧�̎���Q :�I�������閧�̎���ID ���Œ�l�F�閧�̎���2
		public int secret_question_2 { get; set; }
		///�閧�̓����Q
		public string secret_answer_2 { get; set; }
		///�閧�̎���R :�I�������閧�̎���ID ���Œ�l�F�閧�̎���3
		public int secret_question_3 { get; set; }
		///�閧�̓����R
		public string secret_answer_3 { get; set; }
		///�ŏI���O�C������
		public DateTime lasted_login_time { get; set; }
		///���p�X���[�h
		public string wrk_password { get; set; }
		///���p�X���[�h�L������
		public DateTime wrk_password_limit { get; set; }
		///�X�e�[�^�X :0�F�L���A1�F����
		public int status { get; set; }
		///�Č��Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		public int project_management_permission { get; set; }
		///�������� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		public int cost_item_permission { get; set; }
		///�����Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		public int order_management_permission { get; set; }
		///�����E���|���߁A�����Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		public int bill_closing_deposit_mng_permission { get; set; }
		///�x���E���|���߁A�o���Ǘ� (����) :1�FR/W�A2�FR/O�A9�FNOT ���Œ�l�F����
		public int pay_closing_withdrawal_mng_permission { get; set; }
		///�����ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		public int account_setting_permission { get; set; }
		///���Аݒ�P (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		public int own_company_setting_1_permission { get; set; }
		///���Аݒ�Q (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		public int own_company_setting_2_permission { get; set; }
		///�\�Z�ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		public int budget_setting_permission { get; set; }
		///���̐ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		public int name_setting_permission { get; set; }
		///�V�X�e���ݒ� (����) :1�FR/W�A2�FR/O ���Œ�l�F����
		public int sysytem_setting_permission { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		public DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		public DateTime updated_at { get; set; }
		///�폜����:
		public DateTime deleted_at { get; set; }
	}

	public class LoginUsersCollection : ObservableCollection<LoginUsers> {
		public LoginUsersCollection(){
		}
	}
}
