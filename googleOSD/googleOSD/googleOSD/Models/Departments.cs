using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// •”–åƒ}ƒXƒ^
	/// </summary>
	public partial class Departments{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
		public int m_contract_id { get; set; }
		///•”–åƒR[ƒh
		public string department_cd { get; set; }
		///•”–å–¼Ì
		public string department_name { get; set; }
		///—X•Ö”Ô†
		public string postal_code { get; set; }
		///“s“¹•{Œ§ :=“s“¹•{Œ§ƒ}ƒXƒ^.ID
		public int m_prefecture_id { get; set; }
		///ZŠ1
		public string address_1 { get; set; }
		///ZŠ2
		public string address_2 { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///•”–å’·–¼
		public string department_head_name { get; set; }
		///Email
		public string email { get; set; }
		///URL
		public string url_address { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬“ú:
		DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XV“ú:
		DateTime updated_at { get; set; }
		///íœ“ú:
		DateTime deleted_at { get; set; }
	}

	public class DepartmentsCollection : ObservableCollection<Departments> {
		public DepartmentsCollection(){
		}
	}
}
