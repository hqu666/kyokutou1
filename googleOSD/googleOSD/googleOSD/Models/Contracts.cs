using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 契約マスタ
	/// </summary>
	public partial class Contracts{
		///契約ID
		public int m_contract_id { get; set; }
		///契約番号
		public string contract_number { get; set; }
		///会社名
		public string company_name { get; set; }
		///部署名
		public string department_name { get; set; }
		///契約期間（開始）
		public DateTime contract_period_start { get; set; }
		///契約期間（終了）
		public DateTime contract_period_end { get; set; }
		///代理店コード
		public string shop_code { get; set; }
		///代理店名
		public string shop_name { get; set; }
		///サイドバーカテゴリID :＝カテゴリマスタ．ID
		public int m_sidebar_category_id { get; set; }
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

	public class ContractsCollection : ObservableCollection<Contracts> {
		public ContractsCollection(){
		}
	}
}
