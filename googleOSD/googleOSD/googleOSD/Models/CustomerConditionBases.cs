using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ŒÚ‹qŒŸõğŒŠî–{
	/// </summary>
	public partial class CustomerConditionBases{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñî•ñ.ID
		public int m_contract_id { get; set; }
		///ğŒ–¼
		public string search_name { get; set; }
		///à–¾
		public string description { get; set; }
		///©Ğ’S“–ÒID
		public int m_own_company_staff_id { get; set; }
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

	public class CustomerConditionBasesCollection : ObservableCollection<CustomerConditionBases> {
		public CustomerConditionBasesCollection(){
		}
	}
}
