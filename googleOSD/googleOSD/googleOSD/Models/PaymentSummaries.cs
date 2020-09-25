using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 支払サマリー情報
	/// </summary>
	public partial class PaymentSummaries{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///支払No
		public string payment_no { get; set; }
		///仕入先ID :=取引先マスタ.ID
		public int m_suppliers_id { get; set; }
		///購買情報基本ID :=購買情報基本.ID
		public int t_purchase_base_id { get; set; }
		///締区分 :※固定値：締区分
		public int closing_kubun { get; set; }
		///前回支払額
		public decimal last_payment_amount { get; set; }
		///今回出金額
		public decimal currenct_withdrawal_amount { get; set; }
		///繰越額
		public int brought_forward_amount { get; set; }
		///今回仕入額
		public decimal currenct_stocking_amount { get; set; }
		///消費税
		public decimal tax_amount { get; set; }
		///仕入合計
		public int purchase_sum { get; set; }
		///今回支払額
		public decimal currenct_payment_amount { get; set; }
		///支払締日
		public DateTime payment_closing_date { get; set; }
		///初回残高設定フラグ :0：締め処理から作成、1：残高設定から作成
		public int first_balance_setting_flag { get; set; }
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

	public class PaymentSummariesCollection : ObservableCollection<PaymentSummaries> {
		public PaymentSummariesCollection(){
		}
	}
}
