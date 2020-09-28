using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 集計区分名称マスタ
	/// </summary>
	public partial class CategoryNames{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///区分 :※固定値：集計区分名称
		public int name_type { get; set; }
		///コード
		public int name_code { get; set; }
		///名称
		public string name_value { get; set; }
		///並び順
		public int order { get; set; }
		///作成者
		public int creater { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int modifier { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }
		///削除日時:
		public DateTime deleted_at { get; set; }
	}

	public class CategoryNamesCollection : ObservableCollection<CategoryNames> {
		public CategoryNamesCollection(){
		}
	}
}
