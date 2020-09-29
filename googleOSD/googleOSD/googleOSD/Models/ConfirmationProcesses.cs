using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 自社締情報
	/// </summary>
	public partial class ConfirmationProcesses{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///自社締区分 :固定値：自社締区分
		public bool confirmation_processes_type { get; set; }
		///締日
		public DateTime closing_date { get; set; }
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

	public class ConfirmationProcessesCollection : ObservableCollection<ConfirmationProcesses> {
		public ConfirmationProcessesCollection(){
		}
	}
}
