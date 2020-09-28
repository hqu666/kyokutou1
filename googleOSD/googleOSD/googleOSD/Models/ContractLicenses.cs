using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 契約ライセンス連携マスタ
	/// </summary>
	public partial class ContractLicenses{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///ライセンスID :=ライセンスマスタ.ID
		public int m_license_id { get; set; }
		///案件作成可能件数 :0：無制限、0以上：限定数
		public int count_creatable_project { get; set; }
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

	public class ContractLicensesCollection : ObservableCollection<ContractLicenses> {
		public ContractLicensesCollection(){
		}
	}
}
