using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ���Џ��}�X�^
	/// </summary>
	public partial class OwnCompanies{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�Ж�������1
		public string company_name_1 { get; set; }
		///�Ж�������2
		public string company_name_2 { get; set; }
		///�Ж��ȗ���
		public string company_short_name { get; set; }
		///�X�֔ԍ�
		public string postal_code { get; set; }
		///�s���{�� :=�s���{���}�X�^.ID
		public int m_prefecture_id { get; set; }
		///�Z��1
		public string address_1 { get; set; }
		///�Z��2
		public string address_2 { get; set; }
		///��\�Җ�
		public string representative_name { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
		///���Z��
		public int receivable_cclosing_month { get; set; }
		///�����敪 :���Œ�l�F�����敪
		public int closing_date_kubun { get; set; }
		///�x���� :���Œ�l�F�x����
		public int payment_month { get; set; }
		///�x���� :���Œ�l�F�x����
		public int payment_day { get; set; }
		///�W���̔��e����
		public decimal sales_gross_profit_rate { get; set; }
		///�������
		public string trading_condition { get; set; }
		///�^�p�J�n��
		public DateTime operation_date_start { get; set; }
		///�o�^�ԍ�
		public string registration_number { get; set; }
		///���S�C���[�W
		public string logo_image { get; set; }
		///Google�J�����_�[�ŏI���f����
		public DateTime last_application_time { get; set; }
		///���ϘJ����z
		public decimal average_labor_cost_amount { get; set; }
		///���ϕ��|��
		public decimal average_productivity_rate { get; set; }
		///�Љ�ی�����
		public decimal social_insurance_charge_rate { get; set; }
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

	public class OwnCompaniesCollection : ObservableCollection<OwnCompanies> {
		public OwnCompaniesCollection(){
		}
	}
}
