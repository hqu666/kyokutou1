using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// Wvæª¼Ì}X^
	/// </summary>
	public partial class CategoryNames{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///æª :¦ÅèlFWvæª¼Ì
		public int name_type { get; set; }
		///R[h
		public int name_code { get; set; }
		///¼Ì
		public string name_value { get; set; }
		///ÀÑ
		public int order { get; set; }
		///ì¬Ò
		public int creater { get; set; }
		///ì¬ú:
		DateTime created_at { get; set; }
		///XVÒ
		public int modifier { get; set; }
		///XVú:
		DateTime updated_at { get; set; }
		///íú:
		DateTime deleted_at { get; set; }
	}

	public class CategoryNamesCollection : ObservableCollection<CategoryNames> {
		public CategoryNamesCollection(){
		}
	}
}
