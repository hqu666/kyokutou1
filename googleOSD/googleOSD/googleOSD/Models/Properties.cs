using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// •¨Œƒ}ƒXƒ^
	/// </summary>
	public partial class Properties{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
		public int m_contract_id { get; set; }
		///•¨ŒƒR[ƒh
		public string property_code { get; set; }
		///•¨Œ–¼Ì
		public string property_name { get; set; }
		///•¨ŒƒJƒi
		public string property_kana { get; set; }
		///{å–¼
		public string owner_name { get; set; }
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
		///’n}URL
		public string map_url { get; set; }
		///”õl
		public string remark { get; set; }
		///ŒŸõ—pZŠ :“s“¹•{Œ§–¼{ZŠ1{ZŠ2
		public string search_address { get; set; }
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

	public class PropertiesCollection : ObservableCollection<Properties> {
		public PropertiesCollection(){
		}
	}
}
