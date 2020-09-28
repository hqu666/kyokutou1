using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 出金情報
	/// </summary>
	public partial class PaymentLumps{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///出金No
		public int withdrawal_no { get; set; }
		///出金日
		public DateTime withdrawal_date { get; set; }
		///仕入先ID :=取引先マスタ.ID
		public int m_suppliers_id { get; set; }
		///自社担当者ID :=自社担当者マスタ.ID
		public int m_own_company_staff_id { get; set; }
		///出金額合計
		public decimal withdrawal_amount_sum { get; set; }
		///調整額合計
		public decimal adjustment_amount_sum { get; set; }
		///出金総額
		public decimal withdrawal_total_amount { get; set; }
		///出金1：区分 :※固定値：出金区分
		public int kubun_1 { get; set; }
		///出金1：出金額
		public decimal withdrawal_amount_1 { get; set; }
		///出金1：振込手数料
		public decimal transfer_fee_1 { get; set; }
		///出金1：調整額
		public decimal adjustment_amount_1 { get; set; }
		///出金1：取扱銀行ID
		public int handling_bank_id1 { get; set; }
		///出金1：手形期日
		public DateTime bill_deadline_1 { get; set; }
		///出金1：備考
		public string recital_1 { get; set; }
		///出金1：出金合計
		public decimal withdrawal_total_1 { get; set; }
		///出金2：区分 :※固定値：出金区分
		public int kubun_2 { get; set; }
		///出金2：出金額
		public decimal withdrawal_amount_2 { get; set; }
		///出金2：振込手数料
		public decimal transfer_fee_2 { get; set; }
		///出金2：調整額
		public decimal adjustment_amount_2 { get; set; }
		///出金2：取扱銀行ID
		public int handling_bank_id2 { get; set; }
		///出金2：手形期日
		public DateTime bill_deadline_2 { get; set; }
		///出金2：備考
		public string recital_2 { get; set; }
		///出金2：出金合計
		public decimal withdrawal_total_2 { get; set; }
		///出金3：区分 :※固定値：出金区分
		public int kubun_3 { get; set; }
		///出金3：出金額
		public decimal withdrawal_amount_3 { get; set; }
		///出金3：振込手数料
		public decimal transfer_fee_3 { get; set; }
		///出金3：調整額
		public decimal adjustment_amount_3 { get; set; }
		///出金3：取扱銀行ID
		public int handling_bank_id3 { get; set; }
		///出金3：手形期日
		public DateTime bill_deadline_3 { get; set; }
		///出金3：備考
		public string recital_3 { get; set; }
		///出金3：出金合計
		public decimal withdrawal_total_3 { get; set; }
		///支払締対象日
		public DateTime payment_closing_target_date { get; set; }
		///確定日 :確定処理が行われた日
		public DateTime confirmed_date { get; set; }
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

	public class PaymentLumpsCollection : ObservableCollection<PaymentLumps> {
		public PaymentLumpsCollection(){
		}
	}
}
