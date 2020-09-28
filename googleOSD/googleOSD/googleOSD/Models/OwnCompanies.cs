using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ©Ðîñ}X^
	/// </summary>
	public partial class OwnCompanies{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///Ð¼³®¼1
		public string company_name_1 { get; set; }
		///Ð¼³®¼2
		public string company_name_2 { get; set; }
		///Ð¼Èª¼
		public string company_short_name { get; set; }
		///XÖÔ
		public string postal_code { get; set; }
		///s¹{§ :=s¹{§}X^.ID
		public int m_prefecture_id { get; set; }
		///Z1
		public string address_1 { get; set; }
		///Z2
		public string address_2 { get; set; }
		///ã\Ò¼
		public string representative_name { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
		///Z
		public int receivable_cclosing_month { get; set; }
		///÷úæª :¦ÅèlF÷úæª
		public int closing_date_kubun { get; set; }
		///x¥ :¦ÅèlFx¥
		public int payment_month { get; set; }
		///x¥ú :¦ÅèlFx¥ú
		public int payment_day { get; set; }
		///WÌe¦
		public decimal sales_gross_profit_rate { get; set; }
		///æøð
		public string trading_condition { get; set; }
		///^pJnú
		public DateTime operation_date_start { get; set; }
		///o^Ô
		public string registration_number { get; set; }
		///SC[W
		public string logo_image { get; set; }
		///GoogleJ_[ÅI½fú
		public DateTime last_application_time { get; set; }
		///½ÏJ±ïz
		public decimal average_labor_cost_amount { get; set; }
		///½Ïà|¦
		public decimal average_productivity_rate { get; set; }
		///ÐïÛ¯¿¦
		public decimal social_insurance_charge_rate { get; set; }
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

	public class OwnCompaniesCollection : ObservableCollection<OwnCompanies> {
		public OwnCompaniesCollection(){
		}
	}
}
