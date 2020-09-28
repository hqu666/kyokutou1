using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Č����`�[�i�󒍐����w�b�_�j
	/// </summary>
	public partial class ProjectSlipSaleHeaders{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�Č�����{ID :=�Č�����{.ID
		public int t_project_base_id { get; set; }
		///�󒍓�
		public DateTime order_date { get; set; }
		///�������
		public string trading_condition { get; set; }
		///�E�v
		public string summary { get; set; }
		///���v���z�i�Ŕ��j
		public decimal total_amount { get; set; }
		///����ŋ��z
		public decimal tax_amount { get; set; }
		///����ŋ��z(�y���ŗ��Ώ�)
		public decimal reduction_tax_amount { get; set; }
		///���v���z�i�ō��j
		public decimal total_amount_tax_included { get; set; }
		///�����^�u�@���z
		public int cost_tab_1_amount { get; set; }
		///�����^�u�A���z
		public int cost_tab_2_amount { get; set; }
		///�����^�u�B���z
		public int cost_tab_3_amount { get; set; }
		///�������v���z
		public int cost_total_amount { get; set; }
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
		///���b�N�t���O :0�F�����b�N�A1�F���b�N��
		public int lock_flag { get; set; }
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

	public class ProjectSlipSaleHeadersCollection : ObservableCollection<ProjectSlipSaleHeaders> {
		public ProjectSlipSaleHeadersCollection(){
		}
	}
}
