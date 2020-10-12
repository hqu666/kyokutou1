using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// 取引先マスタ
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
		///契約ID :=契約マスタ.ID
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
		///取引先コード
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
		///取引先名
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
		///取引先カナ
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
		///取引先略
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
		///取引先区分：得意先フラグ
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
		///取引先区分：仕入先フラグ
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
		///取引先種別 :※固定値：取引先種別
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
		///見込み客フラグ
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
		///取引停止フラグ
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
		///郵便番号
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
		///都道府県 :=都道府県マスタ.ID
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
		///住所1
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
		///住所2
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
		///緊急連絡先
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
		///代表者名
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
		///情報源 :=顧客関連名称マスタ.ID
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
		///取引先ランク :=顧客関連名称マスタ.ID
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
		///顧客属性項目1 :=顧客関連名称マスタ.ID
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
		///顧客属性項目2 :=顧客関連名称マスタ.ID
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
		///顧客属性項目3 :=顧客関連名称マスタ.ID
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
		///顧客属性項目4 :=顧客関連名称マスタ.ID
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
		///顧客属性項目5 :=顧客関連名称マスタ.ID
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
		///メモ
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
		///検索用電話番号 :TEL+FAX+緊急連絡先
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
		///検索用住所 :都道府県名＋住所1＋住所2
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
		///得意先：単価決定区分 :※固定値：単価決定区分     c_：Customer
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
		///得意先：標準販売掛率
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
		///得意先：請求条件1：締日 :※固定値：締日
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
		///得意先：請求条件1：支払月 :※固定値：支払月
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
		///得意先：請求条件1：支払日 :※固定値：支払日
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
		///得意先：請求条件2：締日 :※固定値：締日
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
		///得意先：請求条件2：支払月 :※固定値：支払月
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
		///得意先：請求条件2：支払日 :※固定値：支払日
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
		///得意先：請求条件3：締日 :※固定値：締日
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
		///得意先：請求条件3：支払月 :※固定値：支払月
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
		///得意先：請求条件3：支払日 :※固定値：支払日
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
		///得意先：与信限度額
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
		///得意先：自社担当者ID :=取引先部門担当者マスタ.ID
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
		///得意先：取引条件ID :=システム関連名称マスタ.ID
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
		///得意先：請求書発行フラグ
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
		///得意先：課税区分 :※固定値：課税区分
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
		///得意先：課税単位 :※固定値：課税単位
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
		///得意先：税端数処理 :※固定値：税端数処理
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
		///得意先：金額端数丸め :※固定値：金額端数丸め
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
		///得意先：金額端数処理 :※固定値：金額端数処理
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
		///得意先：伝票ヘッダ集計区分1 :=集計区分名称マスタ.ID
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
		///得意先：伝票ヘッダ集計区分2 :=集計区分名称マスタ.ID
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
		///得意先：伝票ヘッダ集計区分3 :=集計区分名称マスタ.ID
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
		///得意先：伝票ヘッダ集計区分4 :=集計区分名称マスタ.ID
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
		///得意先：メモ
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
		///仕入先：単価決定区分 :※固定値：単価決定区分     s_：Supplier
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
		///仕入先：標準仕入掛率
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
		///仕入先：社会保険料率
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
		///仕入先：支払条件：締日 :※固定値：締日
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
		///仕入先：支払条件：支払月 :※固定値：支払月
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
		///仕入先：支払条件：支払日 :※固定値：支払日
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
		///仕入先：与信限度額
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
		///仕入先：自社担当者ID :=取引先部門担当者マスタ.ID
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
		///仕入先：仕入区分 :※固定値：仕入区分
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
		///仕入先：支払書発行フラグ
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
		///仕入先：課税区分 :※固定値：課税区分
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
		///仕入先：課税単位 :※固定値：課税単位
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
		///仕入先：税端数処理 :※固定値：税端数処理
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
		///仕入先：金額端数丸め :※固定値：金額端数丸め
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
		///仕入先：金額端数処理 :※固定値：金額端数処理
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
		///仕入先：メモ
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
		///前回請求締日
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
		///前回支払締日
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
		///最終売上日
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
		///作成者
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
		///作成日時
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
		///更新者
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
		///更新日時
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
		///削除日時
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
