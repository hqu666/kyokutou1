using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// õðÛ¶
	/// </summary>
	public partial class SearchConditions{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///õíÊ :¦ÅèlFõíÊ
		public int search_type { get; set; }
		///OC[U[ID :=OC[U[}X^.ID
		public int m_login_users_staff_id { get; set; }
		///ð¼
		public string search_name { get; set; }
		///ðl1
		public string value1 { get; set; }
		///ðl2
		public string value2 { get; set; }
		///ðl3
		public string value3 { get; set; }
		///ðl4
		public string value4 { get; set; }
		///ðl5
		public string value5 { get; set; }
		///ðl6
		public string value6 { get; set; }
		///ðl7
		public string value7 { get; set; }
		///ðl8
		public string value8 { get; set; }
		///ðl9
		public string value9 { get; set; }
		///ðl10
		public string value10 { get; set; }
		///ðl11
		public string value11 { get; set; }
		///ðl12
		public string value12 { get; set; }
		///ðl13
		public string value13 { get; set; }
		///ðl14
		public string value14 { get; set; }
		///ðl15
		public string value15 { get; set; }
		///ðl16
		public string value16 { get; set; }
		///ðl17
		public string value17 { get; set; }
		///ðl18
		public string value18 { get; set; }
		///ðl19
		public string value19 { get; set; }
		///ðl20
		public string value20 { get; set; }
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

	public class SearchConditionsCollection : ObservableCollection<SearchConditions> {
		public SearchConditionsCollection(){
		}
	}
}
