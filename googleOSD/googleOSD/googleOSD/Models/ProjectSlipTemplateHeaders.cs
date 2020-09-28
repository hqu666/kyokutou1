using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Äîñ`[iev[gwb_j
	/// </summary>
	public partial class ProjectSlipTemplateHeaders{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///ev[gR[h
		public string template_code { get; set; }
		///ev[g¼
		public string template_name { get; set; }
		///^uID
		public int tab_id { get; set; }
		///Xe[^Xú
		public DateTime status_date { get; set; }
		///æøð
		public string trading_condition { get; set; }
		///Ev
		public string summary { get; set; }
		///vàziÅ²j
		public decimal total_amount { get; set; }
		///ÁïÅàz
		public decimal tax_amount { get; set; }
		///vàziÅj
		public decimal total_amount_tax_included { get; set; }
		///løàz
		public int discount_amount { get; set; }
		///Äe¦
		public decimal project_gross_profit_rate { get; set; }
		///Äeàz
		public int project_gross_profit_amount { get; set; }
		///½ÏJ±ïz
		public decimal average_labor_cost_amount { get; set; }
		///½Ïà|¦
		public decimal average_productivity_rate { get; set; }
		///ÐïÛ¯¿¦
		public decimal social_insurance_charge_rate { get; set; }
		///@èïz
		public decimal legal_welfare_expenses_amount { get; set; }
		///¿Uæîñ
		public int billing_transfer_target_information { get; set; }
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

	public class ProjectSlipTemplateHeadersCollection : ObservableCollection<ProjectSlipTemplateHeaders> {
		public ProjectSlipTemplateHeadersCollection(){
		}
	}
}
