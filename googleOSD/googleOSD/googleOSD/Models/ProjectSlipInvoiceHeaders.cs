using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Äîñ`[i¿¾×wb_j
	/// </summary>
	public partial class ProjectSlipInvoiceHeaders{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///Äîñî{ID :=Äîñî{.ID
		public int t_project_base_id { get; set; }
		///Xe[^Xú
		public DateTime status_date { get; set; }
		///[üæID :=æøæ}X^.ID@i¾Óæj
		public int d_m_supplier_id { get; set; }
		///[üæFXÖÔ
		public string d_postal_code { get; set; }
		///[üæFs¹{§hc :=s¹{§}X^.ID
		public int d_m_prefecture_id { get; set; }
		///[üæFZP
		public string d_address_1 { get; set; }
		///[üæFZQ
		public string d_address_2 { get; set; }
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
		///¿Uæîñ :=Uæ}X^DID
		public int billing_transfer_target_information { get; set; }
		///üà®¹tO :0F¢®¹A1F®¹
		public int payment_complete_flag { get; set; }
		///bNtO :0F¢bNA1FbN
		public int lock_flag { get; set; }
		///¿÷ÎÛú
		public DateTime billing_closing_target_date { get; set; }
		///¿­stO :0F¢­sA1F­sÏ
		public int billing_issue_flag { get; set; }
		///¿­sú
		public DateTime billing_issue_date { get; set; }
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

	public class ProjectSlipInvoiceHeadersCollection : ObservableCollection<ProjectSlipInvoiceHeaders> {
		public ProjectSlipInvoiceHeadersCollection(){
		}
	}
}
