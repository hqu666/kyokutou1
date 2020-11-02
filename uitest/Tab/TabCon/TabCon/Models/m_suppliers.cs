using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// æøæ}X^
	/// </summary>
	public partial class m_suppliers : NotificationObject
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
		///_ñID :=_ñ}X^.ID
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
		///æøæR[h
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøæ¼
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøæJi
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøæª
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøææªF¾ÓætO
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøææªFdüætO
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøæíÊ :¦ÅèlFæøæíÊ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///©ÝqtO
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøâ~tO
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///XÖÔ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///s¹{§ :=s¹{§}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Z1
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Z2
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Ù}Aæ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ã\Ò¼
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///îñ¹ :=ÚqÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///æøæN :=ÚqÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Úq®«Ú1 :=ÚqÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Úq®«Ú2 :=ÚqÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Úq®«Ú3 :=ÚqÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Úq®«Ú4 :=ÚqÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Úq®«Ú5 :=ÚqÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///õpdbÔ :TEL+FAX+Ù}Aæ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///õpZ :s¹{§¼{Z1{Z2
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFP¿èæª :¦ÅèlFP¿èæª     c_FCustomer
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFWÌ|¦
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð1F÷ú :¦ÅèlF÷ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð1Fx¥ :¦ÅèlFx¥
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð1Fx¥ú :¦ÅèlFx¥ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð2F÷ú :¦ÅèlF÷ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð2Fx¥ :¦ÅèlFx¥
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð2Fx¥ú :¦ÅèlFx¥ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð3F÷ú :¦ÅèlF÷ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð3Fx¥ :¦ÅèlFx¥
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿ð3Fx¥ú :¦ÅèlFx¥ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF^MÀxz
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF©ÐSÒID :=æøæåSÒ}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFæøðID :=VXeÖA¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF¿­stO
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFÛÅæª :¦ÅèlFÛÅæª
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFÛÅPÊ :¦ÅèlFÛÅPÊ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFÅ[ :¦ÅèlFÅ[
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFàz[Ûß :¦ÅèlFàz[Ûß
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæFàz[ :¦ÅèlFàz[
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF`[wb_Wvæª1 :=Wvæª¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF`[wb_Wvæª2 :=Wvæª¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF`[wb_Wvæª3 :=Wvæª¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF`[wb_Wvæª4 :=Wvæª¼Ì}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///¾ÓæF
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFP¿èæª :¦ÅèlFP¿èæª     s_FSupplier
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFWdü|¦
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFÐïÛ¯¿¦
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFx¥ðF÷ú :¦ÅèlF÷ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFx¥ðFx¥ :¦ÅèlFx¥
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFx¥ðFx¥ú :¦ÅèlFx¥ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæF^MÀxz
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæF©ÐSÒID :=æøæåSÒ}X^.ID
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFdüæª :¦ÅèlFdüæª
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFx¥­stO
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFÛÅæª :¦ÅèlFÛÅæª
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFÛÅPÊ :¦ÅèlFÛÅPÊ
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFÅ[ :¦ÅèlFÅ[
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFàz[Ûß :¦ÅèlFàz[Ûß
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæFàz[ :¦ÅèlFàz[
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///düæF
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Oñ¿÷ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///Oñx¥÷ú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ÅIãú
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ì¬Ò
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
		///ì¬ú
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
		///XVÒ
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
		///XVú
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
		///íú
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


	public class m_suppliersCollection : ObservableCollection<m_suppliers> {
		public m_suppliersCollection(){
		}
	}
}
