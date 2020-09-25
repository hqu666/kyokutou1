using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// カタログ商品単価マトリクス
	/// </summary>
	public partial class CatalogProductPriceMatrixes{
		///ID
		public int id { get; set; }
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

	public class CatalogProductPriceMatrixesCollection : ObservableCollection<CatalogProductPriceMatrixes> {
		public CatalogProductPriceMatrixesCollection(){
		}
	}
}
