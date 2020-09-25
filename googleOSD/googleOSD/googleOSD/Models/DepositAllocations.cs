using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// üàUîñ
	/// </summary>
	public partial class DepositAllocations{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///üàîñID :=üàîñiêj.ID
		public int t_deposit_id { get; set; }
		///ÄID :=Äîñî{.ID
		public int t_project_base_id { get; set; }
		///¿¾×wb_ID :=Äîñ¿¾×wb_.ID
		public int t_project_slip_invoice_header_id { get; set; }
		///Uz
		public decimal allocations_amount { get; set; }
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

	public class DepositAllocationsCollection : ObservableCollection<DepositAllocations> {
		public DepositAllocationsCollection(){
		}
	}
}
