using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// サイドバーカテゴリマスタ
	/// </summary>
	public partial class SidebarCategories{
		///ID
		public int id { get; set; }
		///カテゴリキー
		public string category_key { get; set; }
		///URL
		public string url_address { get; set; }
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

	public class SidebarCategoriesCollection : ObservableCollection<SidebarCategories> {
		public SidebarCategoriesCollection(){
		}
	}
}
