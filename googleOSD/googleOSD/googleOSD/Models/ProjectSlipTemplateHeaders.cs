using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Č����`�[�i�e���v���[�g�w�b�_�j
	/// </summary>
	public partial class ProjectSlipTemplateHeaders{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�e���v���[�g�R�[�h
		public string template_code { get; set; }
		///�e���v���[�g��
		public string template_name { get; set; }
		///�^�uID
		public int tab_id { get; set; }
		///�X�e�[�^�X��
		public DateTime status_date { get; set; }
		///�������
		public string trading_condition { get; set; }
		///�E�v
		public string summary { get; set; }
		///���v���z�i�Ŕ��j
		public decimal total_amount { get; set; }
		///����ŋ��z
		public decimal tax_amount { get; set; }
		///���v���z�i�ō��j
		public decimal total_amount_tax_included { get; set; }
		///�l�����z
		public int discount_amount { get; set; }
		///�Č��e����
		public decimal project_gross_profit_rate { get; set; }
		///�Č��e�����z
		public int project_gross_profit_amount { get; set; }
		///���ϘJ����z
		public decimal average_labor_cost_amount { get; set; }
		///���ϕ��|��
		public decimal average_productivity_rate { get; set; }
		///�Љ�ی�����
		public decimal social_insurance_charge_rate { get; set; }
		///�@�蕟����z
		public decimal legal_welfare_expenses_amount { get; set; }
		///�����U������
		public int billing_transfer_target_information { get; set; }
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

	public class ProjectSlipTemplateHeadersCollection : ObservableCollection<ProjectSlipTemplateHeaders> {
		public ProjectSlipTemplateHeadersCollection(){
		}
	}
}
