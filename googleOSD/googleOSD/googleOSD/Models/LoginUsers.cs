using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GoogleOSD.Models{
	/// <summary>
	/// ログインユーザーマスタ
	/// </summary>
	public partial class LoginUsers{
		///ID
		public int id { get; set; }
		///契約ID :=契約マスタ.ID
		public int m_contract_id { get; set; }
		///ログインID :メールアドレス
		public string login_id { get; set; }
		///パスワード
		public string password { get; set; }
		///ログインユーザー名
		public string login_user_name { get; set; }
		///秘密の質問１ :選択した秘密の質問ID ※固定値：秘密の質問1
		public int secret_question_1 { get; set; }
		///秘密の答え１
		public string secret_answer_1 { get; set; }
		///秘密の質問２ :選択した秘密の質問ID ※固定値：秘密の質問2
		public int secret_question_2 { get; set; }
		///秘密の答え２
		public string secret_answer_2 { get; set; }
		///秘密の質問３ :選択した秘密の質問ID ※固定値：秘密の質問3
		public int secret_question_3 { get; set; }
		///秘密の答え３
		public string secret_answer_3 { get; set; }
		///最終ログイン日時
		public DateTime lasted_login_time { get; set; }
		///仮パスワード
		public string wrk_password { get; set; }
		///仮パスワード有効期限
		public DateTime wrk_password_limit { get; set; }
		///ステータス :0：有効、1：無効
		public int status { get; set; }
		///案件管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		public int project_management_permission { get; set; }
		///原価明細 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		public int cost_item_permission { get; set; }
		///発注管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		public int order_management_permission { get; set; }
		///請求・売掛締め、入金管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		public int bill_closing_deposit_mng_permission { get; set; }
		///支払・買掛締め、出金管理 (権限) :1：R/W、2：R/O、9：NOT ※固定値：権限
		public int pay_closing_withdrawal_mng_permission { get; set; }
		///取引先設定 (権限) :1：R/W、2：R/O ※固定値：権限
		public int account_setting_permission { get; set; }
		///自社設定１ (権限) :1：R/W、2：R/O ※固定値：権限
		public int own_company_setting_1_permission { get; set; }
		///自社設定２ (権限) :1：R/W、2：R/O ※固定値：権限
		public int own_company_setting_2_permission { get; set; }
		///予算設定 (権限) :1：R/W、2：R/O ※固定値：権限
		public int budget_setting_permission { get; set; }
		///名称設定 (権限) :1：R/W、2：R/O ※固定値：権限
		public int name_setting_permission { get; set; }
		///システム設定 (権限) :1：R/W、2：R/O ※固定値：権限
		public int sysytem_setting_permission { get; set; }
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

	public class LoginUsersCollection : ObservableCollection<LoginUsers> {
		public LoginUsersCollection(){
		}
	}
}
