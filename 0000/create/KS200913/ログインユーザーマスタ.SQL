create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_login_users` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	login_id  varchar(40)  not null comment 'ログインID : メールアドレス',
	password  varchar(256)  not null comment 'パスワード',
	login_user_name  varchar(50)  not null comment 'ログインユーザー名',
	secret_question_1  int comment '秘密の質問１ : 選択した秘密の質問ID ※固定値：秘密の質問1',
	secret_answer_1  varchar(255) comment '秘密の答え１',
	secret_question_2  int comment '秘密の質問２ : 選択した秘密の質問ID ※固定値：秘密の質問2',
	secret_answer_2  varchar(255) comment '秘密の答え２',
	secret_question_3  int comment '秘密の質問３ : 選択した秘密の質問ID ※固定値：秘密の質問3',
	secret_answer_3  varchar(255) comment '秘密の答え３',
	lasted_login_time  datetime comment '最終ログイン日時',
	wrk_password  varchar(256)  comment '仮パスワード',
	wrk_password_limit  datetime comment '仮パスワード有効期限',
	status  tinyint(1) not null comment 'ステータス : 0：有効、1：無効',
	project_management_permission  tinyint(1)  not null comment '案件管理（権限) : 1：R/W、2：R/O、9：NOT ※固定値：権限',
	cost_item_permission  tinyint(1)  not null comment '原価明細（権限) : 1：R/W、2：R/O、9：NOT ※固定値：権限',
	order_management_permission  tinyint(1)  not null comment '発注管理（権限) : 1：R/W、2：R/O、9：NOT ※固定値：権限',
	bill_closing_deposit_mng_permission  tinyint(1)  not null comment '請求・売掛締め、入金管理（権限) : 1：R/W、2：R/O、9：NOT ※固定値：権限',
	pay_closing_withdrawal_mng_permission  tinyint(1)  not null comment '支払・買掛締め、出金管理（権限) : 1：R/W、2：R/O、9：NOT ※固定値：権限',
	account_setting_permission  tinyint(1)  not null comment '取引先設定（権限) : 1：R/W、2：R/O ※固定値：権限',
	own_company_setting_1_permission  tinyint(1)  not null comment '自社設定１（権限) : 1：R/W、2：R/O ※固定値：権限',
	own_company_setting_2_permission  tinyint(1)  not null comment '自社設定２（権限) : 1：R/W、2：R/O ※固定値：権限',
	budget_setting_permission  tinyint(1)  not null comment '予算設定（権限) : 1：R/W、2：R/O ※固定値：権限',
	name_setting_permission  tinyint(1)  not null comment '名称設定（権限) : 1：R/W、2：R/O ※固定値：権限',
	sysytem_setting_permission  tinyint(1)  not null comment 'システム設定（権限) : 1：R/W、2：R/O ※固定値：権限',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)),idx2(m_contract_id (1),login_id (2)))
	comment='ログインユーザーマスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_login_users`(id , m_contract_id , login_id , password , login_user_name , secret_question_1 , secret_answer_1 , secret_question_2 , secret_answer_2 , secret_question_3 , secret_answer_3 , lasted_login_time , wrk_password , wrk_password_limit , status , project_management_permission , cost_item_permission , order_management_permission , bill_closing_deposit_mng_permission , pay_closing_withdrawal_mng_permission , account_setting_permission , own_company_setting_1_permission , own_company_setting_2_permission , budget_setting_permission , name_setting_permission , sysytem_setting_permission , created_user , updated_user , )
select old.id , old.m_contract_id , old.login_id , old.password , old.login_user_name , old.secret_question_1 , old.secret_answer_1 , old.secret_question_2 , old.secret_answer_2 , old.secret_question_3 , old.secret_answer_3 , old.lasted_login_time , old.wrk_password , old.wrk_password_limit , old.status , old.project_management_permission , old.cost_item_permission , old.order_management_permission , old.bill_closing_deposit_mng_permission , old.pay_closing_withdrawal_mng_permission , old.account_setting_permission , old.own_company_setting_1_permission , old.own_company_setting_2_permission , old.budget_setting_permission , old.name_setting_permission , old.sysytem_setting_permission , old.created_user , old.updated_user ,  from ks_cloud.m_login_users old
/

drop table ks_cloud.m_login_users cascade/

alter table ks_cloud.`$$m_login_users` rename to m_login_users
/

alter table ks_cloud.m_login_users  add constraint `PRIMARY` primary key (id)
/


