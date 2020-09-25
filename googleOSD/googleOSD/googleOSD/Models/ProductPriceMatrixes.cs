using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 商品単価マトリクス
	/// </summary>
	public partial class ProductPriceMatrixes{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///商品ID :=商品マスタ.ID
		public int m_product_id { get; set; }
		///縦軸名
		public string col_name { get; set; }
		///横軸名
		public string row_name { get; set; }
		///行1 :カンマ区切りで列の情報を格納
		public string row1 { get; set; }
		///行2 :例）100,100,100,100,100,,,
		public string row2 { get; set; }
		///行3 :例）,,,,,,,
		public string row3 { get; set; }
		///行4
		public string row4 { get; set; }
		///行5
		public string row5 { get; set; }
		///行6
		public string row6 { get; set; }
		///行7
		public string row7 { get; set; }
		///行8
		public string row8 { get; set; }
		///縦軸項目名1
		public string col_item_name1 { get; set; }
		///縦軸項目名2
		public string col_item_name2 { get; set; }
		///縦軸項目名3
		public string col_item_name3 { get; set; }
		///縦軸項目名4
		public string col_item_name4 { get; set; }
		///縦軸項目名5
		public string col_item_name5 { get; set; }
		///縦軸項目名6
		public string col_item_name6 { get; set; }
		///縦軸項目名7
		public string col_item_name7 { get; set; }
		///縦軸項目名8
		public string col_item_name8 { get; set; }
		///横軸項目名1
		public string row_item_name1 { get; set; }
		///横軸項目名2
		public string row_item_name2 { get; set; }
		///横軸項目名3
		public string row_item_name3 { get; set; }
		///横軸項目名4
		public string row_item_name4 { get; set; }
		///横軸項目名5
		public string row_item_name5 { get; set; }
		///横軸項目名6
		public string row_item_name6 { get; set; }
		///横軸項目名7
		public string row_item_name7 { get; set; }
		///横軸項目名8
		public string row_item_name8 { get; set; }
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

	public class ProductPriceMatrixesCollection : ObservableCollection<ProductPriceMatrixes> {
		public ProductPriceMatrixesCollection(){
		}
	}
}
