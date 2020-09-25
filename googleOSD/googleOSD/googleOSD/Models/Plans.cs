using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// プランマスタ
	/// </summary>
	public partial class Plans{
		///ID
		public int id { get; set; }
		///プラン名
		public string plan_name { get; set; }
		///ユーザー数 :何ユーザー利用できるか
		public int number_users { get; set; }
		///並び順
		public int order { get; set; }
		///案件管理 :0：無効、1：有効
		public int project_management { get; set; }
		///物件管理 :0：無効、1：有効
		public int property_management { get; set; }
		///伝票作成 :0：無制限、1以上：指定枚数
		public int slip_creation { get; set; }
		///顧客管理 :0：無効、1：有効
		public int customer_management { get; set; }
		///売掛管理（請求締め） :0：無効、1：有効
		public int accounts_receivable_billing_closing { get; set; }
		///売上集計表 :0：無効、1：有効
		public int sales_aggregate_table { get; set; }
		///原価管理 :0：無効、1：有効
		public int cost_management { get; set; }
		///スケジュール管理 :0：無効、1：有効
		public int schedule_management { get; set; }
		///法定福利費機能 :0：無効、1：有効
		public int legal_welfare_expenses_feature { get; set; }
		///予実管理機能 :0：無効、1：有効
		public int budget_control_feature { get; set; }
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

	public class PlansCollection : ObservableCollection<Plans> {
		public PlansCollection(){
		}
	}
}
