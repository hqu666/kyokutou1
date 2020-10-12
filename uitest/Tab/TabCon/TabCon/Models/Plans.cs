using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabCon.Models
{
	/// <summary>
	/// プランマスタ
	/// </summary>
	public partial class Plans
	{

		///<summary>
		///ID
		///</summary>
		private int _id;
		public int id
		{
			get => _id;
			set
			{
				if (_id == value)
					return;
				_id = value;
			}
		}

		///<summary>
		///プラン名
		///</summary>
		private string _plan_name;
		public string plan_name
		{
			get => _plan_name;
			set
			{
				if (_plan_name == value)
					return;
				_plan_name = value;
			}
		}

		///<summary>
		///ユーザー数 :何ユーザー利用できるか
		///</summary>
		private int _number_users;
		public int number_users
		{
			get => _number_users;
			set
			{
				if (_number_users == value)
					return;
				_number_users = value;
			}
		}

		///<summary>
		///並び順
		///</summary>
		private int _order;
		public int order
		{
			get => _order;
			set
			{
				if (_order == value)
					return;
				_order = value;
			}
		}

		///<summary>
		///案件管理 :0：無効、1：有効
		///</summary>
		private bool _project_management;
		public bool project_management
		{
			get => _project_management;
			set
			{
				if (_project_management == value)
					return;
				_project_management = value;
			}
		}

		///<summary>
		///物件管理 :0：無効、1：有効
		///</summary>
		private int _property_management;
		public int property_management
		{
			get => _property_management;
			set
			{
				if (_property_management == value)
					return;
				_property_management = value;
			}
		}

		///<summary>
		///伝票作成 :0：無制限、1以上：指定枚数
		///</summary>
		private int _slip_creation;
		public int slip_creation
		{
			get => _slip_creation;
			set
			{
				if (_slip_creation == value)
					return;
				_slip_creation = value;
			}
		}

		///<summary>
		///顧客管理 :0：無効、1：有効
		///</summary>
		private int _customer_management;
		public int customer_management
		{
			get => _customer_management;
			set
			{
				if (_customer_management == value)
					return;
				_customer_management = value;
			}
		}

		///<summary>
		///売掛管理（請求締め） :0：無効、1：有効
		///</summary>
		private int _accounts_receivable_billing_closing;
		public int accounts_receivable_billing_closing
		{
			get => _accounts_receivable_billing_closing;
			set
			{
				if (_accounts_receivable_billing_closing == value)
					return;
				_accounts_receivable_billing_closing = value;
			}
		}

		///<summary>
		///売上集計表 :0：無効、1：有効
		///</summary>
		private int _sales_aggregate_table;
		public int sales_aggregate_table
		{
			get => _sales_aggregate_table;
			set
			{
				if (_sales_aggregate_table == value)
					return;
				_sales_aggregate_table = value;
			}
		}

		///<summary>
		///原価管理 :0：無効、1：有効
		///</summary>
		private int _cost_management;
		public int cost_management
		{
			get => _cost_management;
			set
			{
				if (_cost_management == value)
					return;
				_cost_management = value;
			}
		}

		///<summary>
		///スケジュール管理 :0：無効、1：有効
		///</summary>
		private int _schedule_management;
		public int schedule_management
		{
			get => _schedule_management;
			set
			{
				if (_schedule_management == value)
					return;
				_schedule_management = value;
			}
		}

		///<summary>
		///法定福利費機能 :0：無効、1：有効
		///</summary>
		private int _legal_welfare_expenses_feature;
		public int legal_welfare_expenses_feature
		{
			get => _legal_welfare_expenses_feature;
			set
			{
				if (_legal_welfare_expenses_feature == value)
					return;
				_legal_welfare_expenses_feature = value;
			}
		}

		///<summary>
		///予実管理機能 :0：無効、1：有効
		///</summary>
		private int _budget_control_feature;
		public int budget_control_feature
		{
			get => _budget_control_feature;
			set
			{
				if (_budget_control_feature == value)
					return;
				_budget_control_feature = value;
			}
		}

		///<summary>
		///作成者
		///</summary>
		private int _created_user;
		public int created_user
		{
			get => _created_user;
			set
			{
				if (_created_user == value)
					return;
				_created_user = value;
			}
		}

		///<summary>
		///作成日時
		///</summary>
		private DateTime _created_at;
		public DateTime created_at
		{
			get => _created_at;
			set
			{
				if (_created_at == value)
					return;
				_created_at = value;
			}
		}

		///<summary>
		///更新者
		///</summary>
		private int _updated_user;
		public int updated_user
		{
			get => _updated_user;
			set
			{
				if (_updated_user == value)
					return;
				_updated_user = value;
			}
		}

		///<summary>
		///更新日時
		///</summary>
		private DateTime _updated_at;
		public DateTime updated_at
		{
			get => _updated_at;
			set
			{
				if (_updated_at == value)
					return;
				_updated_at = value;
			}
		}

		///<summary>
		///削除日時
		///</summary>
		private DateTime _deleted_at;
		public DateTime deleted_at
		{
			get => _deleted_at;
			set
			{
				if (_deleted_at == value)
					return;
				_deleted_at = value;
			}
		}

	}


	public class PlansCollection : ObservableCollection<Plans> {
		public PlansCollection(){
		}
	}
}
