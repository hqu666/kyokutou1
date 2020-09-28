using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 案件情報伝票（テンプレートヘッダ）
	/// </summary>
	public partial class ProjectSlipTemplateHeaders{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///テンプレートコード
		public string template_code { get; set; }
		///テンプレート名
		public string template_name { get; set; }
		///タブID
		public int tab_id { get; set; }
		///ステータス日
		public DateTime status_date { get; set; }
		///取引条件
		public string trading_condition { get; set; }
		///摘要
		public string summary { get; set; }
		///合計金額（税抜）
		public decimal total_amount { get; set; }
		///消費税金額
		public decimal tax_amount { get; set; }
		///合計金額（税込）
		public decimal total_amount_tax_included { get; set; }
		///値引金額
		public int discount_amount { get; set; }
		///案件粗利率
		public decimal project_gross_profit_rate { get; set; }
		///案件粗利金額
		public int project_gross_profit_amount { get; set; }
		///平均労務費額
		public decimal average_labor_cost_amount { get; set; }
		///平均歩掛率
		public decimal average_productivity_rate { get; set; }
		///社会保険料率
		public decimal social_insurance_charge_rate { get; set; }
		///法定福利費額
		public decimal legal_welfare_expenses_amount { get; set; }
		///請求振込先情報
		public int billing_transfer_target_information { get; set; }
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

	public class ProjectSlipTemplateHeadersCollection : ObservableCollection<ProjectSlipTemplateHeaders> {
		public ProjectSlipTemplateHeadersCollection(){
		}
	}
}
