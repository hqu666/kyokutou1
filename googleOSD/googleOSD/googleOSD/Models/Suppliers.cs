using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// æøæ}X^
	/// </summary>
	public partial class Suppliers{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///æøæR[h
		public string supplier_cd { get; set; }
		///æøæ¼
		public string supplier_name { get; set; }
		///æøæJi
		public string supplier_kana { get; set; }
		///æøæª
		public string supplier_ryaku { get; set; }
		///æøææªF¾ÓætO
		public int customer_flag { get; set; }
		///æøææªFdüætO
		public int supplier_flag { get; set; }
		///æøæíÊ :¦ÅèlFæøæíÊ
		public int supplier_type { get; set; }
		///©ÝqtO
		public int prospect_flag { get; set; }
		///æøâ~tO
		public int stop_flag { get; set; }
		///XÖÔ
		public string postal_code { get; set; }
		///s¹{§ :=s¹{§}X^.ID
		public int m_prefecture_id { get; set; }
		///Z1
		public string address_1 { get; set; }
		///Z2
		public string address_2 { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///Ù}Aæ
		public string emergency_number { get; set; }
		///ã\Ò¼
		public string representative_name { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
		///îñ¹ :=ÚqÖA¼Ì}X^.ID
		public int m_client_name_info { get; set; }
		///æøæN :=ÚqÖA¼Ì}X^.ID
		public int m_client_name_lank { get; set; }
		///Úq®«Ú1 :=ÚqÖA¼Ì}X^.ID
		public int m_client_name_id1 { get; set; }
		///Úq®«Ú2 :=ÚqÖA¼Ì}X^.ID
		public int m_client_name_id2 { get; set; }
		///Úq®«Ú3 :=ÚqÖA¼Ì}X^.ID
		public int m_client_name_id3 { get; set; }
		///Úq®«Ú4 :=ÚqÖA¼Ì}X^.ID
		public int m_client_name_id4 { get; set; }
		///Úq®«Ú5 :=ÚqÖA¼Ì}X^.ID
		public int m_client_name_id5 { get; set; }
		///
		public string memo { get; set; }
		///õpdbÔ :TEL+FAX+Ù}Aæ
		public string search_tel { get; set; }
		///õpZ :s¹{§¼{Z1{Z2
		public string search_address { get; set; }
		///¾ÓæFP¿èæª :¦ÅèlFP¿èæª     c_FCustomer
		public int c_unit_price_determination { get; set; }
		///¾ÓæFWÌ|¦
		public decimal c_standard_sales_rate { get; set; }
		///¾ÓæF¿ð1F÷ú :¦ÅèlF÷ú
		public int c_closing_date1 { get; set; }
		///¾ÓæF¿ð1Fx¥ :¦ÅèlFx¥
		public int c_payment_month1 { get; set; }
		///¾ÓæF¿ð1Fx¥ú :¦ÅèlFx¥ú
		public int c_payment_day1 { get; set; }
		///¾ÓæF¿ð2F÷ú :¦ÅèlF÷ú
		public int c_closing_date2 { get; set; }
		///¾ÓæF¿ð2Fx¥ :¦ÅèlFx¥
		public int c_payment_month2 { get; set; }
		///¾ÓæF¿ð2Fx¥ú :¦ÅèlFx¥ú
		public int c_payment_day2 { get; set; }
		///¾ÓæF¿ð3F÷ú :¦ÅèlF÷ú
		public int c_closing_date3 { get; set; }
		///¾ÓæF¿ð3Fx¥ :¦ÅèlFx¥
		public int c_payment_month3 { get; set; }
		///¾ÓæF¿ð3Fx¥ú :¦ÅèlFx¥ú
		public int c_payment_day3 { get; set; }
		///¾ÓæF^MÀxz
		public int c_credit_limit { get; set; }
		///¾ÓæF©ÐSÒID :=æøæåSÒ}X^.ID
		public int c_m_own_company_staff_id { get; set; }
		///¾ÓæFæøðID :=VXeÖA¼Ì}X^.ID
		public int c_m_system_name_id { get; set; }
		///¾ÓæF¿­stO
		public int c_Invoice_flag { get; set; }
		///¾ÓæFÛÅæª :¦ÅèlFÛÅæª
		public int c_tax_classification { get; set; }
		///¾ÓæFÛÅPÊ :¦ÅèlFÛÅPÊ
		public int c_taxable_unit { get; set; }
		///¾ÓæFÅ[ :¦ÅèlFÅ[
		public int c_tax_fraction_processing { get; set; }
		///¾ÓæFàz[Ûß :¦ÅèlFàz[Ûß
		public int c_rounding_fractional { get; set; }
		///¾ÓæFàz[ :¦ÅèlFàz[
		public int c_fractional_processing { get; set; }
		///¾ÓæF`[wb_Wvæª1 :=Wvæª¼Ì}X^.ID
		public int c_m_category_name_id1 { get; set; }
		///¾ÓæF`[wb_Wvæª2 :=Wvæª¼Ì}X^.ID
		public int c_m_category_name_id2 { get; set; }
		///¾ÓæF`[wb_Wvæª3 :=Wvæª¼Ì}X^.ID
		public int c_m_category_name_id3 { get; set; }
		///¾ÓæF`[wb_Wvæª4 :=Wvæª¼Ì}X^.ID
		public int c_m_category_name_id4 { get; set; }
		///¾ÓæF
		public string c_memo { get; set; }
		///düæFP¿èæª :¦ÅèlFP¿èæª     s_FSupplier
		public int s_unit_price_determination { get; set; }
		///düæFWdü|¦
		public decimal s_standard_purchase_rate { get; set; }
		///düæFx¥ðF÷ú :¦ÅèlF÷ú
		public int s_closing_date { get; set; }
		///düæFx¥ðFx¥ :¦ÅèlFx¥
		public int s_payment_month { get; set; }
		///düæFx¥ðFx¥ú :¦ÅèlFx¥ú
		public int s_payment_day { get; set; }
		///düæF^MÀxz
		public int s_credit_limit { get; set; }
		///düæF©ÐSÒID :=æøæåSÒ}X^.ID
		public int s_m_own_company_staff_id { get; set; }
		///düæFdüæª :¦ÅèlFdüæª
		public int s_purchase_category { get; set; }
		///düæFx¥­stO
		public int s_payment_flag { get; set; }
		///düæFÛÅæª :¦ÅèlFÛÅæª
		public int s_tax_classification { get; set; }
		///düæFÛÅPÊ :¦ÅèlFÛÅPÊ
		public int s_taxable_unit { get; set; }
		///düæFÅ[ :¦ÅèlFÅ[
		public int s_tax_fraction_processing { get; set; }
		///düæFàz[Ûß :¦ÅèlFàz[Ûß
		public int s_rounding_fractional { get; set; }
		///düæFàz[ :¦ÅèlFàz[
		public int s_fractional_processing { get; set; }
		///düæF
		public string s_memo { get; set; }
		///Oñ¿÷ú
		public DateTime last_billing_closing_date { get; set; }
		///Oñx¥÷ú
		public DateTime last_payment_closing_date { get; set; }
		///ÅIãú
		public DateTime last_project_slip_invoice_date { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬ú:
		public DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XVú:
		public DateTime updated_at { get; set; }
		///íú:
		public DateTime deleted_at { get; set; }
	}

	public class SuppliersCollection : ObservableCollection<Suppliers> {
		public SuppliersCollection(){
		}
	}
}
