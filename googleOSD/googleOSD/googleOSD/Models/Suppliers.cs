using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 取引先マスタ
	/// </summary>
	public partial class Suppliers{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///取引先コード
		public string supplier_cd { get; set; }
		///取引先名
		public string supplier_name { get; set; }
		///取引先カナ
		public string supplier_kana { get; set; }
		///取引先略
		public string supplier_ryaku { get; set; }
		///取引先区分：得意先フラグ
		public int customer_flag { get; set; }
		///取引先区分：仕入先フラグ
		public int supplier_flag { get; set; }
		///取引先種別 :※固定値：取引先種別
		public int supplier_type { get; set; }
		///見込み客フラグ
		public int prospect_flag { get; set; }
		///取引停止フラグ
		public int stop_flag { get; set; }
		///郵便番号
		public string postal_code { get; set; }
		///都道府県 :=都道府県マスタ.ID
		public int m_prefecture_id { get; set; }
		///住所1
		public string address_1 { get; set; }
		///住所2
		public string address_2 { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///緊急連絡先
		public string emergency_number { get; set; }
		///代表者名
		public string representative_name { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
		///情報源 :=顧客関連名称マスタ.ID
		public int m_client_name_info { get; set; }
		///取引先ランク :=顧客関連名称マスタ.ID
		public int m_client_name_lank { get; set; }
		///顧客属性項目1 :=顧客関連名称マスタ.ID
		public int m_client_name_id1 { get; set; }
		///顧客属性項目2 :=顧客関連名称マスタ.ID
		public int m_client_name_id2 { get; set; }
		///顧客属性項目3 :=顧客関連名称マスタ.ID
		public int m_client_name_id3 { get; set; }
		///顧客属性項目4 :=顧客関連名称マスタ.ID
		public int m_client_name_id4 { get; set; }
		///顧客属性項目5 :=顧客関連名称マスタ.ID
		public int m_client_name_id5 { get; set; }
		///メモ
		public string memo { get; set; }
		///検索用電話番号 :TEL+FAX+緊急連絡先
		public string search_tel { get; set; }
		///検索用住所 :都道府県名＋住所1＋住所2
		public string search_address { get; set; }
		///得意先：単価決定区分 :※固定値：単価決定区分     c_：Customer
		public int c_unit_price_determination { get; set; }
		///得意先：標準販売掛率
		public decimal c_standard_sales_rate { get; set; }
		///得意先：請求条件1：締日 :※固定値：締日
		public int c_closing_date1 { get; set; }
		///得意先：請求条件1：支払月 :※固定値：支払月
		public int c_payment_month1 { get; set; }
		///得意先：請求条件1：支払日 :※固定値：支払日
		public int c_payment_day1 { get; set; }
		///得意先：請求条件2：締日 :※固定値：締日
		public int c_closing_date2 { get; set; }
		///得意先：請求条件2：支払月 :※固定値：支払月
		public int c_payment_month2 { get; set; }
		///得意先：請求条件2：支払日 :※固定値：支払日
		public int c_payment_day2 { get; set; }
		///得意先：請求条件3：締日 :※固定値：締日
		public int c_closing_date3 { get; set; }
		///得意先：請求条件3：支払月 :※固定値：支払月
		public int c_payment_month3 { get; set; }
		///得意先：請求条件3：支払日 :※固定値：支払日
		public int c_payment_day3 { get; set; }
		///得意先：与信限度額
		public int c_credit_limit { get; set; }
		///得意先：自社担当者ID :=取引先部門担当者マスタ.ID
		public int c_m_own_company_staff_id { get; set; }
		///得意先：取引条件ID :=システム関連名称マスタ.ID
		public int c_m_system_name_id { get; set; }
		///得意先：請求書発行フラグ
		public int c_Invoice_flag { get; set; }
		///得意先：課税区分 :※固定値：課税区分
		public int c_tax_classification { get; set; }
		///得意先：課税単位 :※固定値：課税単位
		public int c_taxable_unit { get; set; }
		///得意先：税端数処理 :※固定値：税端数処理
		public int c_tax_fraction_processing { get; set; }
		///得意先：金額端数丸め :※固定値：金額端数丸め
		public int c_rounding_fractional { get; set; }
		///得意先：金額端数処理 :※固定値：金額端数処理
		public int c_fractional_processing { get; set; }
		///得意先：伝票ヘッダ集計区分1 :=集計区分名称マスタ.ID
		public int c_m_category_name_id1 { get; set; }
		///得意先：伝票ヘッダ集計区分2 :=集計区分名称マスタ.ID
		public int c_m_category_name_id2 { get; set; }
		///得意先：伝票ヘッダ集計区分3 :=集計区分名称マスタ.ID
		public int c_m_category_name_id3 { get; set; }
		///得意先：伝票ヘッダ集計区分4 :=集計区分名称マスタ.ID
		public int c_m_category_name_id4 { get; set; }
		///得意先：メモ
		public string c_memo { get; set; }
		///仕入先：単価決定区分 :※固定値：単価決定区分     s_：Supplier
		public int s_unit_price_determination { get; set; }
		///仕入先：標準仕入掛率
		public decimal s_standard_purchase_rate { get; set; }
		///仕入先：支払条件：締日 :※固定値：締日
		public int s_closing_date { get; set; }
		///仕入先：支払条件：支払月 :※固定値：支払月
		public int s_payment_month { get; set; }
		///仕入先：支払条件：支払日 :※固定値：支払日
		public int s_payment_day { get; set; }
		///仕入先：与信限度額
		public int s_credit_limit { get; set; }
		///仕入先：自社担当者ID :=取引先部門担当者マスタ.ID
		public int s_m_own_company_staff_id { get; set; }
		///仕入先：仕入区分 :※固定値：仕入区分
		public int s_purchase_category { get; set; }
		///仕入先：支払書発行フラグ
		public int s_payment_flag { get; set; }
		///仕入先：課税区分 :※固定値：課税区分
		public int s_tax_classification { get; set; }
		///仕入先：課税単位 :※固定値：課税単位
		public int s_taxable_unit { get; set; }
		///仕入先：税端数処理 :※固定値：税端数処理
		public int s_tax_fraction_processing { get; set; }
		///仕入先：金額端数丸め :※固定値：金額端数丸め
		public int s_rounding_fractional { get; set; }
		///仕入先：金額端数処理 :※固定値：金額端数処理
		public int s_fractional_processing { get; set; }
		///仕入先：メモ
		public string s_memo { get; set; }
		///前回請求締日
		public DateTime last_billing_closing_date { get; set; }
		///前回支払締日
		public DateTime last_payment_closing_date { get; set; }
		///最終売上日
		public DateTime last_project_slip_invoice_date { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }
		///削除日時:
		public DateTime deleted_at { get; set; }
	}

	public class SuppliersCollection : ObservableCollection<Suppliers> {
		public SuppliersCollection(){
		}
	}
}
