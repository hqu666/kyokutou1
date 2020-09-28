using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 取引先別品種別掛率マスタ
	/// </summary>
	public partial class SupplierVarietyRates{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///種別 :※固定値：取引先区分
		public int type_id { get; set; }
		///取引先ID :=取引先マスタ.ID
		public int m_supplier_id { get; set; }
		///品種ID :=品種マスタ.ID
		public int m_varietie_id { get; set; }
		///掛率
		public decimal rate { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }
		///削除日時:
		public DateTime deleted_at { get; set; }
	}

	public class SupplierVarietyRatesCollection : ObservableCollection<SupplierVarietyRates> {
		public SupplierVarietyRatesCollection(){
		}
	}
}
