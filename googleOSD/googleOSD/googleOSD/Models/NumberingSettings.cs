using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 採番設定
	/// </summary>
	public partial class NumberingSettings{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///採番種別 :※固定値：採番種別
		public int numbering_type { get; set; }
		///接頭辞／接尾辞 :※固定値：接頭辞／接尾辞
		public int prefix_suffix { get; set; }
		///識別子
		public string identifier { get; set; }
		///採番ルール :※固定値：採番ルール
		public int numbering_rule { get; set; }
		///桁数
		public int number_of_digits { get; set; }
		///最終番号
		public int final_number { get; set; }
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

	public class NumberingSettingsCollection : ObservableCollection<NumberingSettings> {
		public NumberingSettingsCollection(){
		}
	}
}
