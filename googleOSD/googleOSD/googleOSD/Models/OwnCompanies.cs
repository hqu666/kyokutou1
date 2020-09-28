using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ©Ğî•ñƒ}ƒXƒ^
	/// </summary>
	public partial class OwnCompanies{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
		public int m_contract_id { get; set; }
		///Ğ–¼³®–¼1
		public string company_name_1 { get; set; }
		///Ğ–¼³®–¼2
		public string company_name_2 { get; set; }
		///Ğ–¼È—ª–¼
		public string company_short_name { get; set; }
		///—X•Ö”Ô†
		public string postal_code { get; set; }
		///“s“¹•{Œ§ :=“s“¹•{Œ§ƒ}ƒXƒ^.ID
		public int m_prefecture_id { get; set; }
		///ZŠ1
		public string address_1 { get; set; }
		///ZŠ2
		public string address_2 { get; set; }
		///‘ã•\Ò–¼
		public string representative_name { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
		///ŒˆZŒ
		public int receivable_cclosing_month { get; set; }
		///’÷“ú‹æ•ª :¦ŒÅ’è’lF’÷“ú‹æ•ª
		public int closing_date_kubun { get; set; }
		///x•¥Œ :¦ŒÅ’è’lFx•¥Œ
		public int payment_month { get; set; }
		///x•¥“ú :¦ŒÅ’è’lFx•¥“ú
		public int payment_day { get; set; }
		///•W€”Ì”„‘e—˜—¦
		public decimal sales_gross_profit_rate { get; set; }
		///æˆøğŒ
		public string trading_condition { get; set; }
		///‰^—pŠJn“ú
		public DateTime operation_date_start { get; set; }
		///“o˜^”Ô†
		public string registration_number { get; set; }
		///ƒƒSƒCƒ[ƒW
		public string logo_image { get; set; }
		///GoogleƒJƒŒƒ“ƒ_[ÅI”½‰f“ú
		public DateTime last_application_time { get; set; }
		///•½‹Ï˜J–±”ïŠz
		public decimal average_labor_cost_amount { get; set; }
		///•½‹Ï•àŠ|—¦
		public decimal average_productivity_rate { get; set; }
		///Ğ‰ï•ÛŒ¯—¿—¦
		public decimal social_insurance_charge_rate { get; set; }
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

	public class OwnCompaniesCollection : ObservableCollection<OwnCompanies> {
		public OwnCompaniesCollection(){
		}
	}
}
