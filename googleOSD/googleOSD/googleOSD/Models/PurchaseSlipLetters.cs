using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 購買情報伝票（送付状）
	/// </summary>
	public partial class PurchaseSlipLetters{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///購買情報基本ID :=購買情報基本.ID
		public int t_purchase_base_id { get; set; }
		///ステータス日
		public DateTime status_date { get; set; }
		///摘要
		public string summary { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class PurchaseSlipLettersCollection : ObservableCollection<PurchaseSlipLetters> {
		public PurchaseSlipLettersCollection(){
		}
	}
}
