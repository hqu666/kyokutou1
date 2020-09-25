using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 検索条件保存
	/// </summary>
	public partial class SearchConditions{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///検索種別 :※固定値：検索種別
		public int search_type { get; set; }
		///ログインユーザーID :=ログインユーザーマスタ.ID
		public int m_login_users_staff_id { get; set; }
		///条件名
		public string search_name { get; set; }
		///条件値1
		public string value1 { get; set; }
		///条件値2
		public string value2 { get; set; }
		///条件値3
		public string value3 { get; set; }
		///条件値4
		public string value4 { get; set; }
		///条件値5
		public string value5 { get; set; }
		///条件値6
		public string value6 { get; set; }
		///条件値7
		public string value7 { get; set; }
		///条件値8
		public string value8 { get; set; }
		///条件値9
		public string value9 { get; set; }
		///条件値10
		public string value10 { get; set; }
		///条件値11
		public string value11 { get; set; }
		///条件値12
		public string value12 { get; set; }
		///条件値13
		public string value13 { get; set; }
		///条件値14
		public string value14 { get; set; }
		///条件値15
		public string value15 { get; set; }
		///条件値16
		public string value16 { get; set; }
		///条件値17
		public string value17 { get; set; }
		///条件値18
		public string value18 { get; set; }
		///条件値19
		public string value19 { get; set; }
		///条件値20
		public string value20 { get; set; }
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

	public class SearchConditionsCollection : ObservableCollection<SearchConditions> {
		public SearchConditionsCollection(){
		}
	}
}
