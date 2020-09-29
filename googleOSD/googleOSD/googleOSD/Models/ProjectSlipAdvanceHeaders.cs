using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// 案件情報伝票（前受金請求書ヘッダ）
	/// </summary>
	public partial class ProjectSlipAdvanceHeaders{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///案件情報基本ID :=案件情報基本.ID
		public int t_project_base_id { get; set; }
		///受注日
		public DateTime order_date { get; set; }
		///取引条件
		public string trading_condition { get; set; }
		///摘要
		public string summary { get; set; }
		///合計金額（税抜）
		public decimal total_amount { get; set; }
		///消費税金額
		public decimal tax_amount { get; set; }
		///合計金額（税込）
		public decimal total_amount_tax_included { get; set; }
		///値引金額
		public int discount_amount { get; set; }
		///案件粗利率
		public decimal project_gross_profit_rate { get; set; }
		///案件粗利金額
		public int project_gross_profit_amount { get; set; }
		///請求振込先情報 :=振込先マスタ．ID
		public int billing_transfer_target_information { get; set; }
		///ロックフラグ :0：未ロック、1：ロック中
		public bool lock_flag { get; set; }
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

	public class ProjectSlipAdvanceHeadersCollection : ObservableCollection<ProjectSlipAdvanceHeaders> {
		public ProjectSlipAdvanceHeadersCollection(){
		}
	}
}
