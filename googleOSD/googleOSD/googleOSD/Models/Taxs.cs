using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 消費税マスタ
	/// </summary>
	public partial class Taxs{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///消費税コード
		public string tax_cd { get; set; }
		///消費税名称
		public string tax_name { get; set; }
		///運用開始日
		public DateTime operation_date_start { get; set; }
		///運用終了日
		public DateTime operation_date_end { get; set; }
		///税率
		public decimal tax_rate { get; set; }
		///経過措置適用開始日
		public DateTime transitional_date_start { get; set; }
		///経過措置適用終了日
		public DateTime transitional_date_end { get; set; }
		///初期値フラグ
		public int default_flag { get; set; }
		///極東産機フラグ :1：極東産機設定、0：ユーザー設定
		public int ks_flag { get; set; }
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

	public class TaxsCollection : ObservableCollection<Taxs> {
		public TaxsCollection(){
		}
	}
}
