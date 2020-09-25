using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 見出名称マスタ
	/// </summary>
	public partial class HeadlineNames{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///種別 :※固定値：見出名称
		public string name_type { get; set; }
		///コード
		public string name_code { get; set; }
		///名称
		public string name_value { get; set; }
		///並び順
		public int order { get; set; }
		///作成者
		public int creater { get; set; }
		///作成日時:
		DateTime created_at { get; set; }
		///更新者
		public int modifier { get; set; }
		///更新日時:
		DateTime updated_at { get; set; }
		///削除日時:
		DateTime deleted_at { get; set; }
	}

	public class HeadlineNamesCollection : ObservableCollection<HeadlineNames> {
		public HeadlineNamesCollection(){
		}
	}
}
