using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 顧客検索条件詳細
	/// </summary>
	public partial class CustomerConditionDetails{
		///ID
		public int id { get; set; }
		///契約ID :=契約情報.ID
		public int m_contract_id { get; set; }
		///顧客検索条件基本ID
		public int search_criteria_base_id { get; set; }
		///条件番号 :検索条件の行番号
		public int condition_number { get; set; }
		///And/Or
		public string conjunction { get; set; }
		///前かっこ
		public string previous_parenthesis { get; set; }
		///項目 :※固定値：顧客検索条件：項目（表示用）、顧客検索条件：項目（検索用）
		public int item { get; set; }
		///比較する条件 :※固定値：顧客検索条件：比較する条件（演算子）
		public int comparing_value_3 { get; set; }
		///比較する値１
		public string comparing_value_1 { get; set; }
		///比較する値２
		public string comparing_value_2 { get; set; }
		///後かっこ
		public string after_parenthesis { get; set; }
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

	public class CustomerConditionDetailsCollection : ObservableCollection<CustomerConditionDetails> {
		public CustomerConditionDetailsCollection(){
		}
	}
}
