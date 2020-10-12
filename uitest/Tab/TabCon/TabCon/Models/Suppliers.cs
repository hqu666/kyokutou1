using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// �����}�X�^
	/// </summary>
	public partial class Suppliers
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
		///�����R�[�h
		///</summary>
		private string _supplier_cd;
		public string supplier_cd
		{
			get => _supplier_cd;
			set
			{
				if (_supplier_cd == value)
					return;
				_supplier_cd = value;
			}
		}

		///<summary>
		///����於
		///</summary>
		private string _supplier_name;
		public string supplier_name
		{
			get => _supplier_name;
			set
			{
				if (_supplier_name == value)
					return;
				_supplier_name = value;
			}
		}

		///<summary>
		///�����J�i
		///</summary>
		private string _supplier_kana;
		public string supplier_kana
		{
			get => _supplier_kana;
			set
			{
				if (_supplier_kana == value)
					return;
				_supplier_kana = value;
			}
		}

		///<summary>
		///����旪
		///</summary>
		private string _supplier_ryaku;
		public string supplier_ryaku
		{
			get => _supplier_ryaku;
			set
			{
				if (_supplier_ryaku == value)
					return;
				_supplier_ryaku = value;
			}
		}

		///<summary>
		///�����敪�F���Ӑ�t���O
		///</summary>
		private int _customer_flag;
		public int customer_flag
		{
			get => _customer_flag;
			set
			{
				if (_customer_flag == value)
					return;
				_customer_flag = value;
			}
		}

		///<summary>
		///�����敪�F�d����t���O
		///</summary>
		private int _supplier_flag;
		public int supplier_flag
		{
			get => _supplier_flag;
			set
			{
				if (_supplier_flag == value)
					return;
				_supplier_flag = value;
			}
		}

		///<summary>
		///������� :���Œ�l�F�������
		///</summary>
		private int _supplier_type;
		public int supplier_type
		{
			get => _supplier_type;
			set
			{
				if (_supplier_type == value)
					return;
				_supplier_type = value;
			}
		}

		///<summary>
		///�����݋q�t���O
		///</summary>
		private int _prospect_flag;
		public int prospect_flag
		{
			get => _prospect_flag;
			set
			{
				if (_prospect_flag == value)
					return;
				_prospect_flag = value;
			}
		}

		///<summary>
		///�����~�t���O
		///</summary>
		private int _stop_flag;
		public int stop_flag
		{
			get => _stop_flag;
			set
			{
				if (_stop_flag == value)
					return;
				_stop_flag = value;
			}
		}

		///<summary>
		///�X�֔ԍ�
		///</summary>
		private string _postal_code;
		public string postal_code
		{
			get => _postal_code;
			set
			{
				if (_postal_code == value)
					return;
				_postal_code = value;
			}
		}

		///<summary>
		///�s���{�� :=�s���{���}�X�^.ID
		///</summary>
		private int _m_prefecture_id;
		public int m_prefecture_id
		{
			get => _m_prefecture_id;
			set
			{
				if (_m_prefecture_id == value)
					return;
				_m_prefecture_id = value;
			}
		}

		///<summary>
		///�Z��1
		///</summary>
		private string _address_1;
		public string address_1
		{
			get => _address_1;
			set
			{
				if (_address_1 == value)
					return;
				_address_1 = value;
			}
		}

		///<summary>
		///�Z��2
		///</summary>
		private string _address_2;
		public string address_2
		{
			get => _address_2;
			set
			{
				if (_address_2 == value)
					return;
				_address_2 = value;
			}
		}

		///<summary>
		///TEL
		///</summary>
		private string _tell_number;
		public string tell_number
		{
			get => _tell_number;
			set
			{
				if (_tell_number == value)
					return;
				_tell_number = value;
			}
		}

		///<summary>
		///FAX
		///</summary>
		private string _fax_number;
		public string fax_number
		{
			get => _fax_number;
			set
			{
				if (_fax_number == value)
					return;
				_fax_number = value;
			}
		}

		///<summary>
		///�ً}�A����
		///</summary>
		private string _emergency_number;
		public string emergency_number
		{
			get => _emergency_number;
			set
			{
				if (_emergency_number == value)
					return;
				_emergency_number = value;
			}
		}

		///<summary>
		///��\�Җ�
		///</summary>
		private string _representative_name;
		public string representative_name
		{
			get => _representative_name;
			set
			{
				if (_representative_name == value)
					return;
				_representative_name = value;
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
			}
		}

		///<summary>
		///URL
		///</summary>
		private string _url_address;
		public string url_address
		{
			get => _url_address;
			set
			{
				if (_url_address == value)
					return;
				_url_address = value;
			}
		}

		///<summary>
		///��� :=�ڋq�֘A���̃}�X�^.ID
		///</summary>
		private int _m_client_name_info;
		public int m_client_name_info
		{
			get => _m_client_name_info;
			set
			{
				if (_m_client_name_info == value)
					return;
				_m_client_name_info = value;
			}
		}

		///<summary>
		///����惉���N :=�ڋq�֘A���̃}�X�^.ID
		///</summary>
		private int _m_client_name_lank;
		public int m_client_name_lank
		{
			get => _m_client_name_lank;
			set
			{
				if (_m_client_name_lank == value)
					return;
				_m_client_name_lank = value;
			}
		}

		///<summary>
		///�ڋq��������1 :=�ڋq�֘A���̃}�X�^.ID
		///</summary>
		private int _m_client_name_id1;
		public int m_client_name_id1
		{
			get => _m_client_name_id1;
			set
			{
				if (_m_client_name_id1 == value)
					return;
				_m_client_name_id1 = value;
			}
		}

		///<summary>
		///�ڋq��������2 :=�ڋq�֘A���̃}�X�^.ID
		///</summary>
		private int _m_client_name_id2;
		public int m_client_name_id2
		{
			get => _m_client_name_id2;
			set
			{
				if (_m_client_name_id2 == value)
					return;
				_m_client_name_id2 = value;
			}
		}

		///<summary>
		///�ڋq��������3 :=�ڋq�֘A���̃}�X�^.ID
		///</summary>
		private int _m_client_name_id3;
		public int m_client_name_id3
		{
			get => _m_client_name_id3;
			set
			{
				if (_m_client_name_id3 == value)
					return;
				_m_client_name_id3 = value;
			}
		}

		///<summary>
		///�ڋq��������4 :=�ڋq�֘A���̃}�X�^.ID
		///</summary>
		private int _m_client_name_id4;
		public int m_client_name_id4
		{
			get => _m_client_name_id4;
			set
			{
				if (_m_client_name_id4 == value)
					return;
				_m_client_name_id4 = value;
			}
		}

		///<summary>
		///�ڋq��������5 :=�ڋq�֘A���̃}�X�^.ID
		///</summary>
		private int _m_client_name_id5;
		public int m_client_name_id5
		{
			get => _m_client_name_id5;
			set
			{
				if (_m_client_name_id5 == value)
					return;
				_m_client_name_id5 = value;
			}
		}

		///<summary>
		///����
		///</summary>
		private string _memo;
		public string memo
		{
			get => _memo;
			set
			{
				if (_memo == value)
					return;
				_memo = value;
			}
		}

		///<summary>
		///�����p�d�b�ԍ� :TEL+FAX+�ً}�A����
		///</summary>
		private string _search_tel;
		public string search_tel
		{
			get => _search_tel;
			set
			{
				if (_search_tel == value)
					return;
				_search_tel = value;
			}
		}

		///<summary>
		///�����p�Z�� :�s���{�����{�Z��1�{�Z��2
		///</summary>
		private string _search_address;
		public string search_address
		{
			get => _search_address;
			set
			{
				if (_search_address == value)
					return;
				_search_address = value;
			}
		}

		///<summary>
		///���Ӑ�F�P������敪 :���Œ�l�F�P������敪     c_�FCustomer
		///</summary>
		private int _c_unit_price_determination;
		public int c_unit_price_determination
		{
			get => _c_unit_price_determination;
			set
			{
				if (_c_unit_price_determination == value)
					return;
				_c_unit_price_determination = value;
			}
		}

		///<summary>
		///���Ӑ�F�W���̔��|��
		///</summary>
		private decimal _c_standard_sales_rate;
		public decimal c_standard_sales_rate
		{
			get => _c_standard_sales_rate;
			set
			{
				if (_c_standard_sales_rate == value)
					return;
				_c_standard_sales_rate = value;
			}
		}

		///<summary>
		///���Ӑ�F��������1�F���� :���Œ�l�F����
		///</summary>
		private int _c_closing_date1;
		public int c_closing_date1
		{
			get => _c_closing_date1;
			set
			{
				if (_c_closing_date1 == value)
					return;
				_c_closing_date1 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������1�F�x���� :���Œ�l�F�x����
		///</summary>
		private int _c_payment_month1;
		public int c_payment_month1
		{
			get => _c_payment_month1;
			set
			{
				if (_c_payment_month1 == value)
					return;
				_c_payment_month1 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������1�F�x���� :���Œ�l�F�x����
		///</summary>
		private int _c_payment_day1;
		public int c_payment_day1
		{
			get => _c_payment_day1;
			set
			{
				if (_c_payment_day1 == value)
					return;
				_c_payment_day1 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������2�F���� :���Œ�l�F����
		///</summary>
		private int _c_closing_date2;
		public int c_closing_date2
		{
			get => _c_closing_date2;
			set
			{
				if (_c_closing_date2 == value)
					return;
				_c_closing_date2 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������2�F�x���� :���Œ�l�F�x����
		///</summary>
		private int _c_payment_month2;
		public int c_payment_month2
		{
			get => _c_payment_month2;
			set
			{
				if (_c_payment_month2 == value)
					return;
				_c_payment_month2 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������2�F�x���� :���Œ�l�F�x����
		///</summary>
		private int _c_payment_day2;
		public int c_payment_day2
		{
			get => _c_payment_day2;
			set
			{
				if (_c_payment_day2 == value)
					return;
				_c_payment_day2 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������3�F���� :���Œ�l�F����
		///</summary>
		private int _c_closing_date3;
		public int c_closing_date3
		{
			get => _c_closing_date3;
			set
			{
				if (_c_closing_date3 == value)
					return;
				_c_closing_date3 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������3�F�x���� :���Œ�l�F�x����
		///</summary>
		private int _c_payment_month3;
		public int c_payment_month3
		{
			get => _c_payment_month3;
			set
			{
				if (_c_payment_month3 == value)
					return;
				_c_payment_month3 = value;
			}
		}

		///<summary>
		///���Ӑ�F��������3�F�x���� :���Œ�l�F�x����
		///</summary>
		private int _c_payment_day3;
		public int c_payment_day3
		{
			get => _c_payment_day3;
			set
			{
				if (_c_payment_day3 == value)
					return;
				_c_payment_day3 = value;
			}
		}

		///<summary>
		///���Ӑ�F�^�M���x�z
		///</summary>
		private int _c_credit_limit;
		public int c_credit_limit
		{
			get => _c_credit_limit;
			set
			{
				if (_c_credit_limit == value)
					return;
				_c_credit_limit = value;
			}
		}

		///<summary>
		///���Ӑ�F���ВS����ID :=����敔��S���҃}�X�^.ID
		///</summary>
		private int _c_m_own_company_staff_id;
		public int c_m_own_company_staff_id
		{
			get => _c_m_own_company_staff_id;
			set
			{
				if (_c_m_own_company_staff_id == value)
					return;
				_c_m_own_company_staff_id = value;
			}
		}

		///<summary>
		///���Ӑ�F�������ID :=�V�X�e���֘A���̃}�X�^.ID
		///</summary>
		private int _c_m_system_name_id;
		public int c_m_system_name_id
		{
			get => _c_m_system_name_id;
			set
			{
				if (_c_m_system_name_id == value)
					return;
				_c_m_system_name_id = value;
			}
		}

		///<summary>
		///���Ӑ�F���������s�t���O
		///</summary>
		private int _c_Invoice_flag;
		public int c_Invoice_flag
		{
			get => _c_Invoice_flag;
			set
			{
				if (_c_Invoice_flag == value)
					return;
				_c_Invoice_flag = value;
			}
		}

		///<summary>
		///���Ӑ�F�ېŋ敪 :���Œ�l�F�ېŋ敪
		///</summary>
		private int _c_tax_classification;
		public int c_tax_classification
		{
			get => _c_tax_classification;
			set
			{
				if (_c_tax_classification == value)
					return;
				_c_tax_classification = value;
			}
		}

		///<summary>
		///���Ӑ�F�ېŒP�� :���Œ�l�F�ېŒP��
		///</summary>
		private int _c_taxable_unit;
		public int c_taxable_unit
		{
			get => _c_taxable_unit;
			set
			{
				if (_c_taxable_unit == value)
					return;
				_c_taxable_unit = value;
			}
		}

		///<summary>
		///���Ӑ�F�Œ[������ :���Œ�l�F�Œ[������
		///</summary>
		private int _c_tax_fraction_processing;
		public int c_tax_fraction_processing
		{
			get => _c_tax_fraction_processing;
			set
			{
				if (_c_tax_fraction_processing == value)
					return;
				_c_tax_fraction_processing = value;
			}
		}

		///<summary>
		///���Ӑ�F���z�[���ۂ� :���Œ�l�F���z�[���ۂ�
		///</summary>
		private int _c_rounding_fractional;
		public int c_rounding_fractional
		{
			get => _c_rounding_fractional;
			set
			{
				if (_c_rounding_fractional == value)
					return;
				_c_rounding_fractional = value;
			}
		}

		///<summary>
		///���Ӑ�F���z�[������ :���Œ�l�F���z�[������
		///</summary>
		private int _c_fractional_processing;
		public int c_fractional_processing
		{
			get => _c_fractional_processing;
			set
			{
				if (_c_fractional_processing == value)
					return;
				_c_fractional_processing = value;
			}
		}

		///<summary>
		///���Ӑ�F�`�[�w�b�_�W�v�敪1 :=�W�v�敪���̃}�X�^.ID
		///</summary>
		private int _c_m_category_name_id1;
		public int c_m_category_name_id1
		{
			get => _c_m_category_name_id1;
			set
			{
				if (_c_m_category_name_id1 == value)
					return;
				_c_m_category_name_id1 = value;
			}
		}

		///<summary>
		///���Ӑ�F�`�[�w�b�_�W�v�敪2 :=�W�v�敪���̃}�X�^.ID
		///</summary>
		private int _c_m_category_name_id2;
		public int c_m_category_name_id2
		{
			get => _c_m_category_name_id2;
			set
			{
				if (_c_m_category_name_id2 == value)
					return;
				_c_m_category_name_id2 = value;
			}
		}

		///<summary>
		///���Ӑ�F�`�[�w�b�_�W�v�敪3 :=�W�v�敪���̃}�X�^.ID
		///</summary>
		private int _c_m_category_name_id3;
		public int c_m_category_name_id3
		{
			get => _c_m_category_name_id3;
			set
			{
				if (_c_m_category_name_id3 == value)
					return;
				_c_m_category_name_id3 = value;
			}
		}

		///<summary>
		///���Ӑ�F�`�[�w�b�_�W�v�敪4 :=�W�v�敪���̃}�X�^.ID
		///</summary>
		private int _c_m_category_name_id4;
		public int c_m_category_name_id4
		{
			get => _c_m_category_name_id4;
			set
			{
				if (_c_m_category_name_id4 == value)
					return;
				_c_m_category_name_id4 = value;
			}
		}

		///<summary>
		///���Ӑ�F����
		///</summary>
		private string _c_memo;
		public string c_memo
		{
			get => _c_memo;
			set
			{
				if (_c_memo == value)
					return;
				_c_memo = value;
			}
		}

		///<summary>
		///�d����F�P������敪 :���Œ�l�F�P������敪     s_�FSupplier
		///</summary>
		private int _s_unit_price_determination;
		public int s_unit_price_determination
		{
			get => _s_unit_price_determination;
			set
			{
				if (_s_unit_price_determination == value)
					return;
				_s_unit_price_determination = value;
			}
		}

		///<summary>
		///�d����F�W���d���|��
		///</summary>
		private decimal _s_standard_purchase_rate;
		public decimal s_standard_purchase_rate
		{
			get => _s_standard_purchase_rate;
			set
			{
				if (_s_standard_purchase_rate == value)
					return;
				_s_standard_purchase_rate = value;
			}
		}

		///<summary>
		///�d����F�Љ�ی�����
		///</summary>
		private int _purchase_social_insurance_charge_rate;
		public int purchase_social_insurance_charge_rate
		{
			get => _purchase_social_insurance_charge_rate;
			set
			{
				if (_purchase_social_insurance_charge_rate == value)
					return;
				_purchase_social_insurance_charge_rate = value;
			}
		}

		///<summary>
		///�d����F�x�������F���� :���Œ�l�F����
		///</summary>
		private int _s_closing_date;
		public int s_closing_date
		{
			get => _s_closing_date;
			set
			{
				if (_s_closing_date == value)
					return;
				_s_closing_date = value;
			}
		}

		///<summary>
		///�d����F�x�������F�x���� :���Œ�l�F�x����
		///</summary>
		private int _s_payment_month;
		public int s_payment_month
		{
			get => _s_payment_month;
			set
			{
				if (_s_payment_month == value)
					return;
				_s_payment_month = value;
			}
		}

		///<summary>
		///�d����F�x�������F�x���� :���Œ�l�F�x����
		///</summary>
		private int _s_payment_day;
		public int s_payment_day
		{
			get => _s_payment_day;
			set
			{
				if (_s_payment_day == value)
					return;
				_s_payment_day = value;
			}
		}

		///<summary>
		///�d����F�^�M���x�z
		///</summary>
		private int _s_credit_limit;
		public int s_credit_limit
		{
			get => _s_credit_limit;
			set
			{
				if (_s_credit_limit == value)
					return;
				_s_credit_limit = value;
			}
		}

		///<summary>
		///�d����F���ВS����ID :=����敔��S���҃}�X�^.ID
		///</summary>
		private int _s_m_own_company_staff_id;
		public int s_m_own_company_staff_id
		{
			get => _s_m_own_company_staff_id;
			set
			{
				if (_s_m_own_company_staff_id == value)
					return;
				_s_m_own_company_staff_id = value;
			}
		}

		///<summary>
		///�d����F�d���敪 :���Œ�l�F�d���敪
		///</summary>
		private int _s_purchase_category;
		public int s_purchase_category
		{
			get => _s_purchase_category;
			set
			{
				if (_s_purchase_category == value)
					return;
				_s_purchase_category = value;
			}
		}

		///<summary>
		///�d����F�x�������s�t���O
		///</summary>
		private int _s_payment_flag;
		public int s_payment_flag
		{
			get => _s_payment_flag;
			set
			{
				if (_s_payment_flag == value)
					return;
				_s_payment_flag = value;
			}
		}

		///<summary>
		///�d����F�ېŋ敪 :���Œ�l�F�ېŋ敪
		///</summary>
		private int _s_tax_classification;
		public int s_tax_classification
		{
			get => _s_tax_classification;
			set
			{
				if (_s_tax_classification == value)
					return;
				_s_tax_classification = value;
			}
		}

		///<summary>
		///�d����F�ېŒP�� :���Œ�l�F�ېŒP��
		///</summary>
		private int _s_taxable_unit;
		public int s_taxable_unit
		{
			get => _s_taxable_unit;
			set
			{
				if (_s_taxable_unit == value)
					return;
				_s_taxable_unit = value;
			}
		}

		///<summary>
		///�d����F�Œ[������ :���Œ�l�F�Œ[������
		///</summary>
		private int _s_tax_fraction_processing;
		public int s_tax_fraction_processing
		{
			get => _s_tax_fraction_processing;
			set
			{
				if (_s_tax_fraction_processing == value)
					return;
				_s_tax_fraction_processing = value;
			}
		}

		///<summary>
		///�d����F���z�[���ۂ� :���Œ�l�F���z�[���ۂ�
		///</summary>
		private int _s_rounding_fractional;
		public int s_rounding_fractional
		{
			get => _s_rounding_fractional;
			set
			{
				if (_s_rounding_fractional == value)
					return;
				_s_rounding_fractional = value;
			}
		}

		///<summary>
		///�d����F���z�[������ :���Œ�l�F���z�[������
		///</summary>
		private int _s_fractional_processing;
		public int s_fractional_processing
		{
			get => _s_fractional_processing;
			set
			{
				if (_s_fractional_processing == value)
					return;
				_s_fractional_processing = value;
			}
		}

		///<summary>
		///�d����F����
		///</summary>
		private string _s_memo;
		public string s_memo
		{
			get => _s_memo;
			set
			{
				if (_s_memo == value)
					return;
				_s_memo = value;
			}
		}

		///<summary>
		///�O�񐿋�����
		///</summary>
		private DateTime _last_billing_closing_date;
		public DateTime last_billing_closing_date
		{
			get => _last_billing_closing_date;
			set
			{
				if (_last_billing_closing_date == value)
					return;
				_last_billing_closing_date = value;
			}
		}

		///<summary>
		///�O��x������
		///</summary>
		private DateTime _last_payment_closing_date;
		public DateTime last_payment_closing_date
		{
			get => _last_payment_closing_date;
			set
			{
				if (_last_payment_closing_date == value)
					return;
				_last_payment_closing_date = value;
			}
		}

		///<summary>
		///�ŏI�����
		///</summary>
		private DateTime _last_project_slip_invoice_date;
		public DateTime last_project_slip_invoice_date
		{
			get => _last_project_slip_invoice_date;
			set
			{
				if (_last_project_slip_invoice_date == value)
					return;
				_last_project_slip_invoice_date = value;
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


	public class SuppliersCollection : ObservableCollection<Suppliers> {
		public SuppliersCollection(){
		}
	}
}
