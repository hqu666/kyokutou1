using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 品種マスタ
	/// </summary>
	public partial class Varieties{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///品種区分 :※固定値：品種区分
		public int variety_type { get; set; }
		///品種コード
		public int variety_code { get; set; }
		///品種名
		public string variety_name { get; set; }
		///並び順
		public int order { get; set; }
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

	public class VarietiesCollection : ObservableCollection<Varieties> {
		public VarietiesCollection(){
		}
	}
}
