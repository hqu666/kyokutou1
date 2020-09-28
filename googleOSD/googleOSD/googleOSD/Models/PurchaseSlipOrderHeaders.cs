using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 購買情報伝票（発注書ヘッダ）
	/// </summary>
	public partial class PurchaseSlipOrderHeaders{
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
		///合計金額（税抜）
		public decimal total_amount { get; set; }
		///消費税金額
		public decimal tax_amount { get; set; }
		///消費税金額(軽減税率対象)
		public decimal reduction_tax_amount { get; set; }
		///合計金額（税込）
		public decimal total_amount_tax_included { get; set; }
		///値引金額
		public int discount_amount { get; set; }
		///ロックフラグ :0：未ロック、1：ロック中
		public int lock_flag { get; set; }
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

	public class PurchaseSlipOrderHeadersCollection : ObservableCollection<PurchaseSlipOrderHeaders> {
		public PurchaseSlipOrderHeadersCollection(){
		}
	}
}
