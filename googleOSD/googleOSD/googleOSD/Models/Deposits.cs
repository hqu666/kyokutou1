using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 入金情報
	/// </summary>
	public partial class Deposits{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///入金方法 :0：個別、1：一括
		public int deposit_method { get; set; }
		///入金種類 :0：売上、1：前受金
		public int deposit_type { get; set; }
		///入金No
		public int deposit_code { get; set; }
		///入金日
		public DateTime deposit_date { get; set; }
		///得意先ID :=取引先マスタ.ID
		public int m_supplier_id { get; set; }
		///自社担当者ID :=自社担当者マスタ.ID
		public int m_own_company_staff_id { get; set; }
		///入金額合計
		public decimal payment_sum { get; set; }
		///調整額合計
		public decimal adjustment_amount_sum { get; set; }
		///入金総額
		public decimal total_payment_sum { get; set; }
		///入金1：区分 :※固定値：入金区分
		public int deposit_classification_1 { get; set; }
		///入金1：入金額
		public decimal deposit_amount_1 { get; set; }
		///入金1：振込手数料
		public decimal transfer_commission_1 { get; set; }
		///入金1：調整額
		public decimal adjustment_amount_1 { get; set; }
		///入金1：取扱銀行ID
		public int m_bank_id_1 { get; set; }
		///入金1：手形期日
		public DateTime bill_deadline_1 { get; set; }
		///入金1：備考
		public string note_1 { get; set; }
		///入金1：入金合計
		public decimal total_payment_1 { get; set; }
		///入金2：区分 :※固定値：入金区分
		public int deposit_classification_2 { get; set; }
		///入金2：入金額
		public decimal deposit_amount_2 { get; set; }
		///入金2：振込手数料
		public decimal transfer_commission_2 { get; set; }
		///入金2：調整額
		public decimal adjustment_amount_2 { get; set; }
		///入金2：取扱銀行ID
		public int m_bank_id_2 { get; set; }
		///入金2：手形期日
		public DateTime bill_deadline_2 { get; set; }
		///入金2：備考
		public string note_2 { get; set; }
		///入金2：入金合計
		public decimal total_payment_2 { get; set; }
		///入金3：区分 :※固定値：入金区分
		public int deposit_classification_3 { get; set; }
		///入金3：入金額
		public decimal deposit_amount_3 { get; set; }
		///入金3：振込手数料
		public decimal transfer_commission_3 { get; set; }
		///入金3：調整額
		public decimal adjustment_amount_3 { get; set; }
		///入金3：取扱銀行ID
		public int m_bank_id_3 { get; set; }
		///入金3：手形期日
		public DateTime bill_deadline_3 { get; set; }
		///入金3：備考
		public string note_3 { get; set; }
		///入金3：入金合計
		public decimal total_payment_3 { get; set; }
		///請求締対象日
		public DateTime billing_closing_target_date { get; set; }
		///確定日 :確定処理が行われた日
		public DateTime confirmed_date { get; set; }
		///ロックフラグ :0：未ロック、1：ロック中
		public bool lock_flag { get; set; }
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

	public class DepositsCollection : ObservableCollection<Deposits> {
		public DepositsCollection(){
		}
	}
}
