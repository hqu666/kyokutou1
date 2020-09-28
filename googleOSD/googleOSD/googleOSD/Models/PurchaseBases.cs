using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// wîñî{
	/// </summary>
	public partial class PurchaseBases{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///wÔ
		public string purchase_code { get; set; }
		///wÇÔ
		public string purchase_manage_code { get; set; }
		///wÄ¼
		public string purchase_name { get; set; }
		///ó][ú
		public DateTime desired_delivery_date { get; set; }
		///¨ID :=¨}X^.ID
		public int m_property_id { get; set; }
		///æøæID :=æøæ}X^.ID@idüæj
		public int m_supplier_id { get; set; }
		///düæSÒID :=æøæåSÒ}X^.ID
		public int m_supplier_staff_id { get; set; }
		///[üæID :=æøæ}X^.ID@i¾Óæj
		public int d_m_supplier_id { get; set; }
		///[üæFXÖÔ :=s¹{§}X^.ID
		public string d_postal_code { get; set; }
		///[üæFs¹{§hc
		public int d_m_prefecture_id { get; set; }
		///[üæFZP
		public string d_address_1 { get; set; }
		///[üæFZQ
		public string d_address_2 { get; set; }
		///[üæFõpZ :XÖÔ{s¹{§¼{ZP{ZQ
		public string d_search_address { get; set; }
		///åID :=å}X^.ID
		public int m_department_id { get; set; }
		///­SÒID :=©ÐSÒ}X^.ID
		public int h_m_own_company_staff_id { get; set; }
		///[iÔ
		public DateTime delivery_slip_code { get; set; }
		///x¥\èú
		public DateTime payment_expected_date { get; set; }
		///
		public string memo { get; set; }
		///Ev
		public string summary { get; set; }
		///mèú :mèªsíê½ú
		public DateTime confirmed_date { get; set; }
		///Xe[^X :¦ÅèlFwXe[^X
		public int status { get; set; }
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

	public class PurchaseBasesCollection : ObservableCollection<PurchaseBases> {
		public PurchaseBasesCollection(){
		}
	}
}
