using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// �����}�X�^
	/// </summary>
	public partial class Suppliers{
		///ID
		public int id { get; set; }
		///�_��ID :=�_��}�X�^.ID
		public int m_contract_id { get; set; }
		///�����R�[�h
		public string supplier_cd { get; set; }
		///����於
		public string supplier_name { get; set; }
		///�����J�i
		public string supplier_kana { get; set; }
		///����旪
		public string supplier_ryaku { get; set; }
		///�����敪�F���Ӑ�t���O
		public int customer_flag { get; set; }
		///�����敪�F�d����t���O
		public int supplier_flag { get; set; }
		///������� :���Œ�l�F�������
		public int supplier_type { get; set; }
		///�����݋q�t���O
		public int prospect_flag { get; set; }
		///�����~�t���O
		public int stop_flag { get; set; }
		///�X�֔ԍ�
		public string postal_code { get; set; }
		///�s���{�� :=�s���{���}�X�^.ID
		public int m_prefecture_id { get; set; }
		///�Z��1
		public string address_1 { get; set; }
		///�Z��2
		public string address_2 { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///�ً}�A����
		public string emergency_number { get; set; }
		///��\�Җ�
		public string representative_name { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
		///��� :=�ڋq�֘A���̃}�X�^.ID
		public int m_client_name_info { get; set; }
		///����惉���N :=�ڋq�֘A���̃}�X�^.ID
		public int m_client_name_lank { get; set; }
		///�ڋq��������1 :=�ڋq�֘A���̃}�X�^.ID
		public int m_client_name_id1 { get; set; }
		///�ڋq��������2 :=�ڋq�֘A���̃}�X�^.ID
		public int m_client_name_id2 { get; set; }
		///�ڋq��������3 :=�ڋq�֘A���̃}�X�^.ID
		public int m_client_name_id3 { get; set; }
		///�ڋq��������4 :=�ڋq�֘A���̃}�X�^.ID
		public int m_client_name_id4 { get; set; }
		///�ڋq��������5 :=�ڋq�֘A���̃}�X�^.ID
		public int m_client_name_id5 { get; set; }
		///����
		public string memo { get; set; }
		///�����p�d�b�ԍ� :TEL+FAX+�ً}�A����
		public string search_tel { get; set; }
		///�����p�Z�� :�s���{�����{�Z��1�{�Z��2
		public string search_address { get; set; }
		///���Ӑ�F�P������敪 :���Œ�l�F�P������敪     c_�FCustomer
		public int c_unit_price_determination { get; set; }
		///���Ӑ�F�W���̔��|��
		public decimal c_standard_sales_rate { get; set; }
		///���Ӑ�F��������1�F���� :���Œ�l�F����
		public int c_closing_date1 { get; set; }
		///���Ӑ�F��������1�F�x���� :���Œ�l�F�x����
		public int c_payment_month1 { get; set; }
		///���Ӑ�F��������1�F�x���� :���Œ�l�F�x����
		public int c_payment_day1 { get; set; }
		///���Ӑ�F��������2�F���� :���Œ�l�F����
		public int c_closing_date2 { get; set; }
		///���Ӑ�F��������2�F�x���� :���Œ�l�F�x����
		public int c_payment_month2 { get; set; }
		///���Ӑ�F��������2�F�x���� :���Œ�l�F�x����
		public int c_payment_day2 { get; set; }
		///���Ӑ�F��������3�F���� :���Œ�l�F����
		public int c_closing_date3 { get; set; }
		///���Ӑ�F��������3�F�x���� :���Œ�l�F�x����
		public int c_payment_month3 { get; set; }
		///���Ӑ�F��������3�F�x���� :���Œ�l�F�x����
		public int c_payment_day3 { get; set; }
		///���Ӑ�F�^�M���x�z
		public int c_credit_limit { get; set; }
		///���Ӑ�F���ВS����ID :=����敔��S���҃}�X�^.ID
		public int c_m_own_company_staff_id { get; set; }
		///���Ӑ�F�������ID :=�V�X�e���֘A���̃}�X�^.ID
		public int c_m_system_name_id { get; set; }
		///���Ӑ�F���������s�t���O
		public int c_Invoice_flag { get; set; }
		///���Ӑ�F�ېŋ敪 :���Œ�l�F�ېŋ敪
		public int c_tax_classification { get; set; }
		///���Ӑ�F�ېŒP�� :���Œ�l�F�ېŒP��
		public int c_taxable_unit { get; set; }
		///���Ӑ�F�Œ[������ :���Œ�l�F�Œ[������
		public int c_tax_fraction_processing { get; set; }
		///���Ӑ�F���z�[���ۂ� :���Œ�l�F���z�[���ۂ�
		public int c_rounding_fractional { get; set; }
		///���Ӑ�F���z�[������ :���Œ�l�F���z�[������
		public int c_fractional_processing { get; set; }
		///���Ӑ�F�`�[�w�b�_�W�v�敪1 :=�W�v�敪���̃}�X�^.ID
		public int c_m_category_name_id1 { get; set; }
		///���Ӑ�F�`�[�w�b�_�W�v�敪2 :=�W�v�敪���̃}�X�^.ID
		public int c_m_category_name_id2 { get; set; }
		///���Ӑ�F�`�[�w�b�_�W�v�敪3 :=�W�v�敪���̃}�X�^.ID
		public int c_m_category_name_id3 { get; set; }
		///���Ӑ�F�`�[�w�b�_�W�v�敪4 :=�W�v�敪���̃}�X�^.ID
		public int c_m_category_name_id4 { get; set; }
		///���Ӑ�F����
		public string c_memo { get; set; }
		///�d����F�P������敪 :���Œ�l�F�P������敪     s_�FSupplier
		public int s_unit_price_determination { get; set; }
		///�d����F�W���d���|��
		public decimal s_standard_purchase_rate { get; set; }
		///�d����F�x�������F���� :���Œ�l�F����
		public int s_closing_date { get; set; }
		///�d����F�x�������F�x���� :���Œ�l�F�x����
		public int s_payment_month { get; set; }
		///�d����F�x�������F�x���� :���Œ�l�F�x����
		public int s_payment_day { get; set; }
		///�d����F�^�M���x�z
		public int s_credit_limit { get; set; }
		///�d����F���ВS����ID :=����敔��S���҃}�X�^.ID
		public int s_m_own_company_staff_id { get; set; }
		///�d����F�d���敪 :���Œ�l�F�d���敪
		public int s_purchase_category { get; set; }
		///�d����F�x�������s�t���O
		public int s_payment_flag { get; set; }
		///�d����F�ېŋ敪 :���Œ�l�F�ېŋ敪
		public int s_tax_classification { get; set; }
		///�d����F�ېŒP�� :���Œ�l�F�ېŒP��
		public int s_taxable_unit { get; set; }
		///�d����F�Œ[������ :���Œ�l�F�Œ[������
		public int s_tax_fraction_processing { get; set; }
		///�d����F���z�[���ۂ� :���Œ�l�F���z�[���ۂ�
		public int s_rounding_fractional { get; set; }
		///�d����F���z�[������ :���Œ�l�F���z�[������
		public int s_fractional_processing { get; set; }
		///�d����F����
		public string s_memo { get; set; }
		///�O�񐿋�����
		public DateTime last_billing_closing_date { get; set; }
		///�O��x������
		public DateTime last_payment_closing_date { get; set; }
		///�ŏI�����
		public DateTime last_project_slip_invoice_date { get; set; }
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

	public class SuppliersCollection : ObservableCollection<Suppliers> {
		public SuppliersCollection(){
		}
	}
}
