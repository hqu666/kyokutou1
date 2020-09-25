using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ¿T}[îñ
	/// </summary>
	public partial class BillingSummaries{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///¿No
		public string billing_no { get; set; }
		///¾ÓæID :=æøæ}X^.ID
		public int m_supplier_id { get; set; }
		///ÄID :=Äîñî{.ID
		public int t_project_base_id { get; set; }
		///÷æª :¦ÅèlF÷æª
		public int closing_kubun { get; set; }
		///Oñ¿z
		public decimal last_billing_amount { get; set; }
		///¡ñüàz
		public decimal payment_amount { get; set; }
		///Jzz
		public int brought_forward_amount { get; set; }
		///¡ñãz
		public decimal total_amount { get; set; }
		///ÁïÅ
		public decimal tax_amount { get; set; }
		///ãv
		public decimal total_amount_tax_included { get; set; }
		///¡ñ¿z
		public decimal billing_amount { get; set; }
		///¿÷ú
		public DateTime billing_closing_date { get; set; }
		///ñcÝètO :0F÷ß©çì¬A1FcÝè©çì¬
		public int first_balance_setting_flag { get; set; }
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

	public class BillingSummariesCollection : ObservableCollection<BillingSummaries> {
		public BillingSummariesCollection(){
		}
	}
}
