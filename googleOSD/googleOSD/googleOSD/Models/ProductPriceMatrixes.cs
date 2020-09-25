using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ¤iP¿}gNX
	/// </summary>
	public partial class ProductPriceMatrixes{
		///ID
		public int id { get; set; }
		///_ñID :=_ñ}X^.ID
		public int m_contract_id { get; set; }
		///¤iID :=¤i}X^.ID
		public int m_product_id { get; set; }
		///c²¼
		public string col_name { get; set; }
		///¡²¼
		public string row_name { get; set; }
		///s1 :J}æØèÅñÌîñði[
		public string row1 { get; set; }
		///s2 :áj100,100,100,100,100,,,
		public string row2 { get; set; }
		///s3 :áj,,,,,,,
		public string row3 { get; set; }
		///s4
		public string row4 { get; set; }
		///s5
		public string row5 { get; set; }
		///s6
		public string row6 { get; set; }
		///s7
		public string row7 { get; set; }
		///s8
		public string row8 { get; set; }
		///c²Ú¼1
		public string col_item_name1 { get; set; }
		///c²Ú¼2
		public string col_item_name2 { get; set; }
		///c²Ú¼3
		public string col_item_name3 { get; set; }
		///c²Ú¼4
		public string col_item_name4 { get; set; }
		///c²Ú¼5
		public string col_item_name5 { get; set; }
		///c²Ú¼6
		public string col_item_name6 { get; set; }
		///c²Ú¼7
		public string col_item_name7 { get; set; }
		///c²Ú¼8
		public string col_item_name8 { get; set; }
		///¡²Ú¼1
		public string row_item_name1 { get; set; }
		///¡²Ú¼2
		public string row_item_name2 { get; set; }
		///¡²Ú¼3
		public string row_item_name3 { get; set; }
		///¡²Ú¼4
		public string row_item_name4 { get; set; }
		///¡²Ú¼5
		public string row_item_name5 { get; set; }
		///¡²Ú¼6
		public string row_item_name6 { get; set; }
		///¡²Ú¼7
		public string row_item_name7 { get; set; }
		///¡²Ú¼8
		public string row_item_name8 { get; set; }
		///ì¬Ò
		public int created_user { get; set; }
		///ì¬ú:
		DateTime created_at { get; set; }
		///XVÒ
		public int updated_user { get; set; }
		///XVú:
		DateTime updated_at { get; set; }
		///íú:
		DateTime deleted_at { get; set; }
	}

	public class ProductPriceMatrixesCollection : ObservableCollection<ProductPriceMatrixes> {
		public ProductPriceMatrixesCollection(){
		}
	}
}
