using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Úqõðî{
	/// </summary>
	public partial class CustomerConditionBases{
		///ID
		public int id { get; set; }
		///_ñID :=_ñîñ.ID
		public int m_contract_id { get; set; }
		///ð¼
		public string search_name { get; set; }
		///à¾
		public string description { get; set; }
		///©ÐSÒID
		public int m_own_company_staff_id { get; set; }
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

	public class CustomerConditionBasesCollection : ObservableCollection<CustomerConditionBases> {
		public CustomerConditionBasesCollection(){
		}
	}
}
