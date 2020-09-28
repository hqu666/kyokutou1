using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ˆÄŒî•ñ“`•[ió’¿‘ƒwƒbƒ_j
	/// </summary>
	public partial class ProjectSlipSaleHeaders{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
		public int m_contract_id { get; set; }
		///ˆÄŒî•ñŠî–{ID :=ˆÄŒî•ñŠî–{.ID
		public int t_project_base_id { get; set; }
		///ó’“ú
		public DateTime order_date { get; set; }
		///æˆøğŒ
		public string trading_condition { get; set; }
		///“E—v
		public string summary { get; set; }
		///‡Œv‹àŠziÅ”²j
		public decimal total_amount { get; set; }
		///Á”ïÅ‹àŠz
		public decimal tax_amount { get; set; }
		///Á”ïÅ‹àŠz(ŒyŒ¸Å—¦‘ÎÛ)
		public decimal reduction_tax_amount { get; set; }
		///‡Œv‹àŠziÅj
		public decimal total_amount_tax_included { get; set; }
		///Œ´‰¿ƒ^ƒu‡@‹àŠz
		public int cost_tab_1_amount { get; set; }
		///Œ´‰¿ƒ^ƒu‡A‹àŠz
		public int cost_tab_2_amount { get; set; }
		///Œ´‰¿ƒ^ƒu‡B‹àŠz
		public int cost_tab_3_amount { get; set; }
		///Œ´‰¿‡Œv‹àŠz
		public int cost_total_amount { get; set; }
		///’lˆø‹àŠz
		public int discount_amount { get; set; }
		///ˆÄŒ‘e—˜—¦
		public decimal project_gross_profit_rate { get; set; }
		///ˆÄŒ‘e—˜‹àŠz
		public int project_gross_profit_amount { get; set; }
		///•½‹Ï˜J–±”ïŠz
		public decimal average_labor_cost_amount { get; set; }
		///•½‹Ï•àŠ|—¦
		public decimal average_productivity_rate { get; set; }
		///Ğ‰ï•ÛŒ¯—¿—¦
		public decimal social_insurance_charge_rate { get; set; }
		///–@’è•Ÿ—˜”ïŠz
		public decimal legal_welfare_expenses_amount { get; set; }
		///¿‹Uæî•ñ
		public int billing_transfer_target_information { get; set; }
		///ƒƒbƒNƒtƒ‰ƒO :0F–¢ƒƒbƒNA1FƒƒbƒN’†
		public int lock_flag { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬“ú:
		public DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XV“ú:
		public DateTime updated_at { get; set; }
		///íœ“ú:
		public DateTime deleted_at { get; set; }
	}

	public class ProjectSlipSaleHeadersCollection : ObservableCollection<ProjectSlipSaleHeaders> {
		public ProjectSlipSaleHeadersCollection(){
		}
	}
}
