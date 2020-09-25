using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 初回残高請求額
	/// </summary>
	public partial class FtBalanceBillings{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contracts_id { get; set; }
		///取引先ID :=取引先マスタ.ID
		public int m_suppliers_id { get; set; }
		///前月請求日
		public DateTime last_month_date { get; set; }
		///前月請求額
		public int last_month_amount { get; set; }
		///削除フラグ
		public int is_deleted { get; set; }
		///作成者
		public int creater { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int modifier { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }

	}

	public class FtBalanceBillingsCollection : ObservableCollection<FtBalanceBillings> {
		public FtBalanceBillingsCollection(){
		}
	}
}
