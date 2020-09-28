using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 初回残高売掛額
	/// </summary>
	public partial class FtBalanceAccountsReceivables{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contracts_id { get; set; }
		///取引先ID :=取引先マスタ.ID
		public int m_suppliers_id { get; set; }
		///前月売掛日
		public DateTime last_month_date { get; set; }
		///前月売掛額
		public int last_month_amount { get; set; }
		///削除フラグ
		public int is_deleted { get; set; }
		///作成者
		public int creater { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int modifier { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }

	}

	public class FtBalanceAccountsReceivablesCollection : ObservableCollection<FtBalanceAccountsReceivables> {
		public FtBalanceAccountsReceivablesCollection(){
		}
	}
}
