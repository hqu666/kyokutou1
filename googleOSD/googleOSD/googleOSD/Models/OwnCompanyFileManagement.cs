using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 自社ファイル管理
	/// </summary>
	public partial class OwnCompanyFileManagement{
		///ID
		public int id { get; set; }
		///契約ID :=契約情報.ID
		public int m_contract_id { get; set; }
		///名称
		public string document_name { get; set; }
		///ファイルパス :フルパス
		public string file_path { get; set; }
		///ファイル名称
		public string file_name { get; set; }
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

	public class OwnCompanyFileManagementCollection : ObservableCollection<OwnCompanyFileManagement> {
		public OwnCompanyFileManagementCollection(){
		}
	}
}
