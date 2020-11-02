using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace TabCon.Models
{
	/// <summary>
	/// ログインユーザーマスタ
	/// </summary>
	public partial class m_login_users : NotificationObject
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
				RaisePropertyChanged();
			}
		}

		///<summary>
		///契約ID :=契約マスタ.ID
		///</summary>
		private int _m_contract_id;
		public int m_contract_id
		{
			get => _m_contract_id;
			set
			{
				if (_m_contract_id == value)
					return;
				_m_contract_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ログインID :メールアドレス
		///</summary>
		private string _login_id;
		public string login_id
		{
			get => _login_id;
			set
			{
				if (_login_id == value)
					return;
				_login_id = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///パスワード
		///</summary>
		private string _password;
		public string password
		{
			get => _password;
			set
			{
				if (_password == value)
					return;
				_password = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ログインユーザー名
		///</summary>
		private string _login_user_name;
		public string login_user_name
		{
			get => _login_user_name;
			set
			{
				if (_login_user_name == value)
					return;
				_login_user_name = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///秘密の質問１ :選択した秘密の質問ID ※固定値：秘密の質問1
		///</summary>
		private int _secret_question_1;
		public int secret_question_1
		{
			get => _secret_question_1;
			set
			{
				if (_secret_question_1 == value)
					return;
				_secret_question_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///秘密の答え１
		///</summary>
		private string _secret_answer_1;
		public string secret_answer_1
		{
			get => _secret_answer_1;
			set
			{
				if (_secret_answer_1 == value)
					return;
				_secret_answer_1 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///秘密の質問２ :選択した秘密の質問ID ※固定値：秘密の質問2
		///</summary>
		private int _secret_question_2;
		public int secret_question_2
		{
			get => _secret_question_2;
			set
			{
				if (_secret_question_2 == value)
					return;
				_secret_question_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///秘密の答え２
		///</summary>
		private string _secret_answer_2;
		public string secret_answer_2
		{
			get => _secret_answer_2;
			set
			{
				if (_secret_answer_2 == value)
					return;
				_secret_answer_2 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///秘密の質問３ :選択した秘密の質問ID ※固定値：秘密の質問3
		///</summary>
		private int _secret_question_3;
		public int secret_question_3
		{
			get => _secret_question_3;
			set
			{
				if (_secret_question_3 == value)
					return;
				_secret_question_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///秘密の答え３
		///</summary>
		private string _secret_answer_3;
		public string secret_answer_3
		{
			get => _secret_answer_3;
			set
			{
				if (_secret_answer_3 == value)
					return;
				_secret_answer_3 = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///最終ログイン日時
		///</summary>
		private DateTime _lasted_login_time;
		public DateTime lasted_login_time
		{
			get => _lasted_login_time;
			set
			{
				if (_lasted_login_time == value)
					return;
				_lasted_login_time = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仮パスワード
		///</summary>
		private string _wrk_password;
		public string wrk_password
		{
			get => _wrk_password;
			set
			{
				if (_wrk_password == value)
					return;
				_wrk_password = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仮パスワード有効期限
		///</summary>
		private DateTime _wrk_password_limit;
		public DateTime wrk_password_limit
		{
			get => _wrk_password_limit;
			set
			{
				if (_wrk_password_limit == value)
					return;
				_wrk_password_limit = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///ステータス :0：有効、1：無効
		///</summary>
		private int _status;
		public int status
		{
			get => _status;
			set
			{
				if (_status == value)
					return;
				_status = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///案件管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		///</summary>
		private bool _project_management_permission;
		public bool project_management_permission
		{
			get => _project_management_permission;
			set
			{
				if (_project_management_permission == value)
					return;
				_project_management_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///原価明細 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		///</summary>
		private bool _cost_item_permission;
		public bool cost_item_permission
		{
			get => _cost_item_permission;
			set
			{
				if (_cost_item_permission == value)
					return;
				_cost_item_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///発注管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		///</summary>
		private bool _order_management_permission;
		public bool order_management_permission
		{
			get => _order_management_permission;
			set
			{
				if (_order_management_permission == value)
					return;
				_order_management_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///仕入管理（権限） :1：R/W、2：R/O、9：NOT ※固定値：権限
		///</summary>
		private bool _purchase_management_permission;
		public bool purchase_management_permission
		{
			get => _purchase_management_permission;
			set
			{
				if (_purchase_management_permission == value)
					return;
				_purchase_management_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///請求・売掛締め、入金管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		///</summary>
		private bool _bill_closing_deposit_mng_permission;
		public bool bill_closing_deposit_mng_permission
		{
			get => _bill_closing_deposit_mng_permission;
			set
			{
				if (_bill_closing_deposit_mng_permission == value)
					return;
				_bill_closing_deposit_mng_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///支払・買掛締め、出金管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		///</summary>
		private bool _pay_closing_withdrawal_mng_permission;
		public bool pay_closing_withdrawal_mng_permission
		{
			get => _pay_closing_withdrawal_mng_permission;
			set
			{
				if (_pay_closing_withdrawal_mng_permission == value)
					return;
				_pay_closing_withdrawal_mng_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///取引先設定 (権限) :1：R/W、2：R/O ※固定値：権限
		///</summary>
		private bool _account_setting_permission;
		public bool account_setting_permission
		{
			get => _account_setting_permission;
			set
			{
				if (_account_setting_permission == value)
					return;
				_account_setting_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///自社設定１ (権限) :1：R/W、2：R/O ※固定値：権限
		///</summary>
		private bool _own_company_setting_1_permission;
		public bool own_company_setting_1_permission
		{
			get => _own_company_setting_1_permission;
			set
			{
				if (_own_company_setting_1_permission == value)
					return;
				_own_company_setting_1_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///自社設定２ (権限) :1：R/W、2：R/O ※固定値：権限
		///</summary>
		private bool _own_company_setting_2_permission;
		public bool own_company_setting_2_permission
		{
			get => _own_company_setting_2_permission;
			set
			{
				if (_own_company_setting_2_permission == value)
					return;
				_own_company_setting_2_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///予算設定 (権限) :1：R/W、2：R/O ※固定値：権限
		///</summary>
		private bool _budget_setting_permission;
		public bool budget_setting_permission
		{
			get => _budget_setting_permission;
			set
			{
				if (_budget_setting_permission == value)
					return;
				_budget_setting_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///名称設定 (権限) :1：R/W、2：R/O ※固定値：権限
		///</summary>
		private bool _name_setting_permission;
		public bool name_setting_permission
		{
			get => _name_setting_permission;
			set
			{
				if (_name_setting_permission == value)
					return;
				_name_setting_permission = value;
				RaisePropertyChanged();
			}
		}

		///<summary>
		///システム設定 (権限) :1：R/W、2：R/O ※固定値：権限
		///</summary>
		private bool _sysytem_setting_permission;
		public bool sysytem_setting_permission
		{
			get => _sysytem_setting_permission;
			set
			{
				if (_sysytem_setting_permission == value)
					return;
				_sysytem_setting_permission = value;
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
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
				RaisePropertyChanged();
			}
		}

	}


	public class m_login_usersCollection : ObservableCollection<m_login_users> {
		public m_login_usersCollection(){
		}
	}
}
