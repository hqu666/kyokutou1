using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// カタログマスタ
	/// </summary>
	public partial class Catalogs{
		///ID
		public int id { get; set; }
		///カタログID
		public string catalog_id { get; set; }
		///カタログ名
		public string catalog_name { get; set; }
		///有効期間(FROM)
		public DateTime rental_start { get; set; }
		///有効期間(TO)
		public DateTime rental_end { get; set; }
		///配信停止 :1:配信停止
		public int is_unsubscribe { get; set; }
		///メモ
		public string memo { get; set; }
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

	public class CatalogsCollection : ObservableCollection<Catalogs> {
		public CatalogsCollection(){
		}
	}
}
