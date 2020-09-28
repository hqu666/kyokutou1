using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 請求サマリー情報
	/// </summary>
	public partial class BillingSummaries{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///請求No
		public string billing_no { get; set; }
		///得意先ID :=取引先マスタ.ID
		public int m_supplier_id { get; set; }
		///案件ID :=案件情報基本.ID
		public int t_project_base_id { get; set; }
		///締区分 :※固定値：締区分
		public int closing_kubun { get; set; }
		///前回請求額
		public decimal last_billing_amount { get; set; }
		///今回入金額
		public decimal payment_amount { get; set; }
		///繰越額
		public int brought_forward_amount { get; set; }
		///今回売上額
		public decimal total_amount { get; set; }
		///消費税
		public decimal tax_amount { get; set; }
		///売上合計
		public decimal total_amount_tax_included { get; set; }
		///今回請求額
		public decimal billing_amount { get; set; }
		///請求締日
		public DateTime billing_closing_date { get; set; }
		///初回残高設定フラグ :0：締め処理から作成、1：残高設定から作成
		public int first_balance_setting_flag { get; set; }
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

	public class BillingSummariesCollection : ObservableCollection<BillingSummaries> {
		public BillingSummariesCollection(){
		}
	}
}
