using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Äîñ`[i´¿wb_j
	/// </summary>
	public partial class ProjectSlipCostHeaders{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///Äîñî{ID :=Äîñî{.ID
		public int t_project_base_id { get; set; }
		///^uID :1F´¿PA2F´¿QA3F´¿3
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
		///´¿vàz
		public int cost_total_amount { get; set; }
		///løàz
		public int discount_amount { get; set; }
		///Äe¦
		public decimal project_gross_profit_rate { get; set; }
		///Äeàz
		public int project_gross_profit_amount { get; set; }
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

	public class ProjectSlipCostHeadersCollection : ObservableCollection<ProjectSlipCostHeaders> {
		public ProjectSlipCostHeadersCollection(){
		}
	}
}
