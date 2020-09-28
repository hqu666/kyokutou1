using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 案件情報伝票（送付状）
	/// </summary>
	public partial class ProjectSlipLetters{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///案件情報基本ID :=案件情報基本.ID
		public int t_project_base_id { get; set; }
		///ステータス日
		public DateTime status_date { get; set; }
		///摘要
		public string summary { get; set; }
		///作成者
		public int created_user { get; set; }
		///作成日時:
		public DateTime created_at { get; set; }
		///更新者
		public int updated_user { get; set; }
		///更新日時:
		public DateTime updated_at { get; set; }
		///削除日時:
		public DateTime deleted_at { get; set; }
	}

	public class ProjectSlipLettersCollection : ObservableCollection<ProjectSlipLetters> {
		public ProjectSlipLettersCollection(){
		}
	}
}
