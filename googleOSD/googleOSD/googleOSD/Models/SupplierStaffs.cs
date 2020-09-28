using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 取引先部門担当者マスタ
	/// </summary>
	public partial class SupplierStaffs{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///取引先ID :=取引先マスタ.ID
		public int m_supplier_id { get; set; }
		///担当者コード
		public string staff_cd { get; set; }
		///担当者名
		public string staff_name { get; set; }
		///役職
		public string position { get; set; }
		///連絡先
		public string contact_number { get; set; }
		///携帯電話
		public string mobile_number { get; set; }
		///Email
		public string email { get; set; }
		///備考
		public string remark { get; set; }
		///無効フラグ
		public int invalid_flg { get; set; }
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

	public class SupplierStaffsCollection : ObservableCollection<SupplierStaffs> {
		public SupplierStaffsCollection(){
		}
	}
}
