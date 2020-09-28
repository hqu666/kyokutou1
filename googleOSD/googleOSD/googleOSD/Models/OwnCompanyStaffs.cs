using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ©Ğ’S“–Òƒ}ƒXƒ^
	/// </summary>
	public partial class OwnCompanyStaffs{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
		public int m_contract_id { get; set; }
		///’S“–ÒƒR[ƒh
		public string staff_cd { get; set; }
		///’S“–Ò–¼
		public string staff_name { get; set; }
		///•”–åID :•”–åƒ}ƒXƒ^‚ÌID
		public int m_department_id { get; set; }
		///Œg‘Ñ“d˜b
		public string mobile_number { get; set; }
		///ƒ[ƒ‹ƒAƒhƒŒƒX
		public string email { get; set; }
		///–³Œøƒtƒ‰ƒO
		public int invalid_flg { get; set; }
		///—\”õ‚P
		public string spare_1 { get; set; }
		///—\”õ‚Q
		public string spare_2 { get; set; }
		///—\”õ‚R
		public string spare_3 { get; set; }
		///—\”õN1
		public string spare_n1 { get; set; }
		///—\”õN2
		public string spare_n2 { get; set; }
		///—\”õN3
		public string spare_n3 { get; set; }
		///—\”õD1
		public string spare_d1 { get; set; }
		///—\”õD‚Q
		public string spare_d2 { get; set; }
		///—\”õD3
		public string spare_d3 { get; set; }
		///ˆóŠÓƒCƒ[ƒW
		public string stamp_image { get; set; }
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

	public class OwnCompanyStaffsCollection : ObservableCollection<OwnCompanyStaffs> {
		public OwnCompanyStaffsCollection(){
		}
	}
}
