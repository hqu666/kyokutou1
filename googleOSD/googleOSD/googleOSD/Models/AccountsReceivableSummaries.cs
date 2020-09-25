using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 売掛サマリー情報
	/// </summary>
	public partial class AccountsReceivableSummaries{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///得意先ID :=取引先マスタ.ID
		public int m_supplier_id { get; set; }
		///今月入金額
		public decimal current_month_payment_amount { get; set; }
		///今月調整額
		public decimal current_month_adjustment_amount { get; set; }
		///今月売上額
		public decimal current_month_sales_amount { get; set; }
		///今月消費税
		public decimal current_month_tax { get; set; }
		///今回売掛額
		public decimal currenct_accounts_receivable_amount { get; set; }
		///今回締日
		public DateTime currenct_closing_date { get; set; }
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

	public class AccountsReceivableSummariesCollection : ObservableCollection<AccountsReceivableSummaries> {
		public AccountsReceivableSummariesCollection(){
		}
	}
}
