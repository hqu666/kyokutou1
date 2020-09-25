using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ¨}X^
	/// </summary>
	public partial class Properties{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///¨R[h
		public string property_code { get; set; }
		///¨¼Ì
		public string property_name { get; set; }
		///¨Ji
		public string property_kana { get; set; }
		///{å¼
		public string owner_name { get; set; }
		///XÖÔ
		public string postal_code { get; set; }
		///s¹{§ :=s¹{§}X^.ID
		public int m_prefecture_id { get; set; }
		///Z1
		public string address_1 { get; set; }
		///Z2
		public string address_2 { get; set; }
		///TEL
		public string tell_number { get; set; }
		///FAX
		public string fax_number { get; set; }
		///n}URL
		public string map_url { get; set; }
		///õl
		public string remark { get; set; }
		///õpZ :s¹{§¼{Z1{Z2
		public string search_address { get; set; }
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

	public class PropertiesCollection : ObservableCollection<Properties> {
		public PropertiesCollection(){
		}
	}
}
