using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// x¥T}[îñ
	/// </summary>
	public partial class PaymentSummaries{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///x¥No
		public string payment_no { get; set; }
		///düæID :=æøæ}X^.ID
		public int m_suppliers_id { get; set; }
		///wîñî{ID :=wîñî{.ID
		public int t_purchase_base_id { get; set; }
		///÷æª :¦ÅèlF÷æª
		public int closing_kubun { get; set; }
		///Oñx¥z
		public decimal last_payment_amount { get; set; }
		///¡ñoàz
		public decimal currenct_withdrawal_amount { get; set; }
		///Jzz
		public int brought_forward_amount { get; set; }
		///¡ñdüz
		public decimal currenct_stocking_amount { get; set; }
		///ÁïÅ
		public decimal tax_amount { get; set; }
		///düv
		public int purchase_sum { get; set; }
		///¡ñx¥z
		public decimal currenct_payment_amount { get; set; }
		///x¥÷ú
		public DateTime payment_closing_date { get; set; }
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

	public class PaymentSummariesCollection : ObservableCollection<PaymentSummaries> {
		public PaymentSummariesCollection(){
		}
	}
}
