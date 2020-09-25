using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// âs}X^
	/// </summary>
	public partial class Banks{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///âsR[h
		public string bank_cd { get; set; }
		///âs¼
		public string bank_name { get; set; }
		///xXR[h
		public string branch_cd { get; set; }
		///xX¼
		public string branch_name { get; set; }
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

	public class BanksCollection : ObservableCollection<Banks> {
		public BanksCollection(){
		}
	}
}
