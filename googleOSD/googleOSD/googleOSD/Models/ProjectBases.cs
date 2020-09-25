using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �Č�����{
	/// </summary>
	public partial class ProjectBases{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�Č��ԍ�
		public string project_code { get; set; }
		///�Č��Ǘ��ԍ�
		public string project_manage_code { get; set; }
		///�Č���
		public string project_name { get; set; }
		///����ID :=�����}�X�^.ID
		public int m_property_id { get; set; }
		///�[��
		public DateTime delivery_date { get; set; }
		///�\��H���iFROM�j
		public DateTime plan_construction_period_from { get; set; }
		///�\��H���iTO)
		public DateTime plan_construction_period_to { get; set; }
		///���Ӑ�ID :=�����}�X�^.ID�@�i���Ӑ�j
		public int m_supplier_id { get; set; }
		///���Ӑ�S����ID :=����敔��S���҃}�X�^.ID
		public int m_supplier_staff_id { get; set; }
		///�{�喼
		public string owner_name { get; set; }
		///�[����ID :=�����}�X�^.ID�@�i���Ӑ�j
		public int d_m_supplier_id { get; set; }
		///�[����F�X�֔ԍ�
		public string d_postal_code { get; set; }
		///�[����F�s���{���h�c
		public int d_m_prefecture_id { get; set; }
		///�[����F�Z���P
		public string d_address_1 { get; set; }
		///�[����F�Z���Q
		public string d_address_2 { get; set; }
		///�[����F�����p�Z��
		public string d_search_address { get; set; }
		///����ID :=����}�X�^.ID
		public int m_department_id { get; set; }
		///���ВS����ID :=���ВS���҃}�X�^.ID
		public int m_own_company_staff_id { get; set; }
		///�L��������
		public DateTime expiration_date { get; set; }
		///�����\���
		public DateTime billing_expected_date { get; set; }
		///�ېŋ敪
		public int tax_classification { get; set; }
		///�Œ[������
		public int tax_fraction_processing { get; set; }
		///�W�v�敪1
		public int aggregate_type_1 { get; set; }
		///�W�v�敪2
		public int aggregate_type_2 { get; set; }
		///�W�v�敪3
		public int aggregate_type_3 { get; set; }
		///�W�v�敪4
		public int aggregate_type_4 { get; set; }
		///����
		public string memo { get; set; }
		///�E�v
		public string summary { get; set; }
		///���ϔj����
		public DateTime quotation_discard_date { get; set; }
		///������
		public DateTime failure_date { get; set; }
		///�������RID
		public string failure_cause_id { get; set; }
		///�O���
		public int advance_payment { get; set; }
		///�������
		public int temporary_sales_money { get; set; }
		///����z
		public decimal total_amount { get; set; }
		///�����
		public decimal tax_amount { get; set; }
		///���㍇�v :����z�{�����
		public decimal total_amount_tax_included { get; set; }
		///���U�ϊz :���̈Č��ɕR�Â����Ă��銄�U�f�[�^�̊��U�z�̑��z
		public decimal total_allocations_amount { get; set; }
		///���U�c�z :���㍇�v-���U�ϊz
		public decimal allocation_remains { get; set; }
		///����ݒ�
		public int print_setting { get; set; }
		///�m��� :�m�菈�����s��ꂽ��
		public DateTime confirmed_date { get; set; }
		///�X�e�[�^�X :���Œ�l�F�Č��X�e�[�^�X
		public int status { get; set; }
		///�쐬��
		public int created_user { get; set; }
		///�쐬����:
		DateTime created_at { get; set; }
		///�X�V��
		public int updated_user { get; set; }
		///�X�V����:
		DateTime updated_at { get; set; }
		///�폜����:
		DateTime deleted_at { get; set; }
	}

	public class ProjectBasesCollection : ObservableCollection<ProjectBases> {
		public ProjectBasesCollection(){
		}
	}
}
