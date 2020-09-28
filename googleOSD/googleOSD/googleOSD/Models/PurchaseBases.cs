using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// w”ƒî•ñŠî–{
	/// </summary>
	public partial class PurchaseBases{
		///ID
		public int id { get; set; }
		///Œ_–ñID :=Œ_–ñƒ}ƒXƒ^.ID
		public int m_contract_id { get; set; }
		///w”ƒ”Ô†
		public string purchase_code { get; set; }
		///w”ƒŠÇ—”Ô†
		public string purchase_manage_code { get; set; }
		///w”ƒˆÄŒ–¼
		public string purchase_name { get; set; }
		///Šó–]”[Šú
		public DateTime desired_delivery_date { get; set; }
		///•¨ŒID :=•¨Œƒ}ƒXƒ^.ID
		public int m_property_id { get; set; }
		///æˆøæID :=æˆøæƒ}ƒXƒ^.ID@id“üæj
		public int m_supplier_id { get; set; }
		///d“üæ’S“–ÒID :=æˆøæ•”–å’S“–Òƒ}ƒXƒ^.ID
		public int m_supplier_staff_id { get; set; }
		///”[“üæID :=æˆøæƒ}ƒXƒ^.ID@i“¾ˆÓæj
		public int d_m_supplier_id { get; set; }
		///”[“üæF—X•Ö”Ô† :=“s“¹•{Œ§ƒ}ƒXƒ^.ID
		public string d_postal_code { get; set; }
		///”[“üæF“s“¹•{Œ§‚h‚c
		public int d_m_prefecture_id { get; set; }
		///”[“üæFZŠ‚P
		public string d_address_1 { get; set; }
		///”[“üæFZŠ‚Q
		public string d_address_2 { get; set; }
		///”[“üæFŒŸõ—pZŠ :—X•Ö”Ô†{“s“¹•{Œ§–¼{ZŠ‚P{ZŠ‚Q
		public string d_search_address { get; set; }
		///•”–åID :=•”–åƒ}ƒXƒ^.ID
		public int m_department_id { get; set; }
		///”­’’S“–ÒID :=©Ğ’S“–Òƒ}ƒXƒ^.ID
		public int h_m_own_company_staff_id { get; set; }
		///”[•i‘”Ô†
		public DateTime delivery_slip_code { get; set; }
		///x•¥—\’è“ú
		public DateTime payment_expected_date { get; set; }
		///ƒƒ‚
		public string memo { get; set; }
		///“E—v
		public string summary { get; set; }
		///Šm’è“ú :Šm’èˆ—‚ªs‚í‚ê‚½“ú
		public DateTime confirmed_date { get; set; }
		///ƒXƒe[ƒ^ƒX :¦ŒÅ’è’lFw”ƒƒXƒe[ƒ^ƒX
		public int status { get; set; }
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

	public class PurchaseBasesCollection : ObservableCollection<PurchaseBases> {
		public PurchaseBasesCollection(){
		}
	}
}
