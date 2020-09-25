using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 入金割振情報
	/// </summary>
	public partial class DepositAllocations{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///入金情報ID :=入金情報（一括）.ID
		public int t_deposit_id { get; set; }
		///案件ID :=案件情報基本.ID
		public int t_project_base_id { get; set; }
		///請求明細ヘッダID :=案件情報請求明細ヘッダ.ID
		public int t_project_slip_invoice_header_id { get; set; }
		///割振額
		public decimal allocations_amount { get; set; }
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

	public class DepositAllocationsCollection : ObservableCollection<DepositAllocations> {
		public DepositAllocationsCollection(){
		}
	}
}
