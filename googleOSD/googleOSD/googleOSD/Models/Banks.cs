using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 銀行マスタ
	/// </summary>
	public partial class Banks{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///銀行コード
		public string bank_cd { get; set; }
		///銀行名
		public string bank_name { get; set; }
		///支店コード
		public string branch_cd { get; set; }
		///支店名
		public string branch_name { get; set; }
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

	public class BanksCollection : ObservableCollection<Banks> {
		public BanksCollection(){
		}
	}
}
