using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// wîñ`[i­wb_j
	/// </summary>
	public partial class PurchaseSlipOrderHeaders{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///wîñî{ID :=wîñî{.ID
		public int t_purchase_base_id { get; set; }
		///Xe[^Xú
		public DateTime status_date { get; set; }
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
		///løàz
		public int discount_amount { get; set; }
		///bNtO :0F¢bNA1FbN
		public bool lock_flag { get; set; }
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

	public class PurchaseSlipOrderHeadersCollection : ObservableCollection<PurchaseSlipOrderHeaders> {
		public PurchaseSlipOrderHeadersCollection(){
		}
	}
}
