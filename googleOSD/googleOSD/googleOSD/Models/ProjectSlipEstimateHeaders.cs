using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Äîñ`[i©Ïwb_j
	/// </summary>
	public partial class ProjectSlipEstimateHeaders{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///Äîñî{ID :=Äîñî{.ID
		public int t_project_base_id { get; set; }
		///©Ïú
		public DateTime quote_date { get; set; }
		///æøð
		public string trading_condition { get; set; }
		///Ev
		public string summary { get; set; }
		///vàziÅ²j
		public decimal total_amount { get; set; }
		///ÁïÅàz
		public decimal tax_amount { get; set; }
		///ÁïÅàz(y¸Å¦ÎÛ)
		public decimal reduction_tax_amount { get; set; }
		///vàziÅj
		public decimal total_amount_tax_included { get; set; }
		///´¿^u@àz
		public int cost_tab_1_amount { get; set; }
		///´¿^uAàz
		public int cost_tab_2_amount { get; set; }
		///´¿^uBàz
		public int cost_tab_3_amount { get; set; }
		///´¿vàz
		public int cost_total_amount { get; set; }
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
		///bNtO :0F¢bNA1FbN
		public int lock_flag { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬ú:
		DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XVú:
		DateTime updated_at { get; set; }
		///íú:
		DateTime deleted_at { get; set; }
	}

	public class ProjectSlipEstimateHeadersCollection : ObservableCollection<ProjectSlipEstimateHeaders> {
		public ProjectSlipEstimateHeadersCollection(){
		}
	}
}
