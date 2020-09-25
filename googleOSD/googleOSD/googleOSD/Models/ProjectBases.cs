using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 案件情報基本
	/// </summary>
	public partial class ProjectBases{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///案件番号
		public string project_code { get; set; }
		///案件管理番号
		public string project_manage_code { get; set; }
		///案件名
		public string project_name { get; set; }
		///物件ID :=物件マスタ.ID
		public int m_property_id { get; set; }
		///納期
		public DateTime delivery_date { get; set; }
		///予定工期（FROM）
		public DateTime plan_construction_period_from { get; set; }
		///予定工期（TO)
		public DateTime plan_construction_period_to { get; set; }
		///得意先ID :=取引先マスタ.ID　（得意先）
		public int m_supplier_id { get; set; }
		///得意先担当者ID :=取引先部門担当者マスタ.ID
		public int m_supplier_staff_id { get; set; }
		///施主名
		public string owner_name { get; set; }
		///納入先ID :=取引先マスタ.ID　（得意先）
		public int d_m_supplier_id { get; set; }
		///納入先：郵便番号
		public string d_postal_code { get; set; }
		///納入先：都道府県ＩＤ
		public int d_m_prefecture_id { get; set; }
		///納入先：住所１
		public string d_address_1 { get; set; }
		///納入先：住所２
		public string d_address_2 { get; set; }
		///納入先：検索用住所
		public string d_search_address { get; set; }
		///部門ID :=部門マスタ.ID
		public int m_department_id { get; set; }
		///自社担当者ID :=自社担当者マスタ.ID
		public int m_own_company_staff_id { get; set; }
		///有効期限日
		public DateTime expiration_date { get; set; }
		///請求予定日
		public DateTime billing_expected_date { get; set; }
		///課税区分
		public int tax_classification { get; set; }
		///税端数処理
		public int tax_fraction_processing { get; set; }
		///集計区分1
		public int aggregate_type_1 { get; set; }
		///集計区分2
		public int aggregate_type_2 { get; set; }
		///集計区分3
		public int aggregate_type_3 { get; set; }
		///集計区分4
		public int aggregate_type_4 { get; set; }
		///メモ
		public string memo { get; set; }
		///摘要
		public string summary { get; set; }
		///見積破棄日
		public DateTime quotation_discard_date { get; set; }
		///失注日
		public DateTime failure_date { get; set; }
		///失注理由ID
		public string failure_cause_id { get; set; }
		///前受金
		public int advance_payment { get; set; }
		///仮売上金
		public int temporary_sales_money { get; set; }
		///売上額
		public decimal total_amount { get; set; }
		///消費税
		public decimal tax_amount { get; set; }
		///売上合計 :売上額＋消費税
		public decimal total_amount_tax_included { get; set; }
		///割振済額 :この案件に紐づけられている割振データの割振額の総額
		public decimal total_allocations_amount { get; set; }
		///割振残額 :売上合計-割振済額
		public decimal allocation_remains { get; set; }
		///印刷設定
		public int print_setting { get; set; }
		///確定日 :確定処理が行われた日
		public DateTime confirmed_date { get; set; }
		///ステータス :※固定値：案件ステータス
		public int status { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class ProjectBasesCollection : ObservableCollection<ProjectBases> {
		public ProjectBasesCollection(){
		}
	}
}
