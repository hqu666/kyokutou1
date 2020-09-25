using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 振込先マスタ
	/// </summary>
	public partial class BankAccounts{
		///ID
		public int id { get; set; }
		///契約ID :=契約情報.ID
		public int m_contract_id { get; set; }
		///振込先区分 :=固定値：振込先区分
		public int bank_account_type { get; set; }
		///番号 :（自社）1～3、（部門）4
		public int bank_account_code { get; set; }
		///部門ID :=部門マスタ.ID　（部門の振込先の場合）
		public int m_department_id { get; set; }
		///銀行ID :=銀行マスタ.ID
		public int m_bank_id { get; set; }
		///預金種別 :=固定値：預金種別
		public int deposit_type { get; set; }
		///名義人
		public string bank_account_name { get; set; }
		///口座番号
		public string bank_account_number { get; set; }
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

	public class BankAccountsCollection : ObservableCollection<BankAccounts> {
		public BankAccountsCollection(){
		}
	}
}
