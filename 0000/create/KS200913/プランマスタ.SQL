create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_plans` (
	id int(11) primary key auto_increment not null comment 'ID',
	plan_name  varchar(255) not null comment 'プラン名',
	number_users  int default 1 not null comment 'ユーザー数 : 何ユーザー利用できるか',
	order  int not null comment '並び順',
	project_management  tinyint(1)  not null comment '案件管理 : 0：無効、1：有効',
	property_management  tinyint(1) not null comment '物件管理 : 0：無効、1：有効',
	slip_creation  int not null comment '伝票作成 : 0：無制限、1以上：指定枚数',
	customer_management  tinyint(1) not null comment '顧客管理 : 0：無効、1：有効',
	accounts_receivable_billing_closing  tinyint(1) not null comment '売掛管理（請求締め） : 0：無効、1：有効',
	sales_aggregate_table  tinyint(1) not null comment '売上集計表 : 0：無効、1：有効',
	cost_management  tinyint(1) not null comment '原価管理 : 0：無効、1：有効',
	schedule_management  tinyint(1) not null comment 'スケジュール管理 : 0：無効、1：有効',
	legal_welfare_expenses_feature  tinyint(1) not null comment '法定福利費機能 : 0：無効、1：有効',
	budget_control_feature  tinyint(1) not null comment '予実管理機能 : 0：無効、1：有効',
	created_user  int not null comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int not null comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='プランマスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_plans`(id , plan_name , number_users , order , project_management , property_management , slip_creation , customer_management , accounts_receivable_billing_closing , sales_aggregate_table , cost_management , schedule_management , legal_welfare_expenses_feature , budget_control_feature , created_user , updated_user , )
select old.id , old.plan_name , old.number_users , old.order , old.project_management , old.property_management , old.slip_creation , old.customer_management , old.accounts_receivable_billing_closing , old.sales_aggregate_table , old.cost_management , old.schedule_management , old.legal_welfare_expenses_feature , old.budget_control_feature , old.created_user , old.updated_user ,  from ks_cloud.m_plans old
/

drop table ks_cloud.m_plans cascade/

alter table ks_cloud.`$$m_plans` rename to m_plans
/

alter table ks_cloud.m_plans  add constraint `PRIMARY` primary key (id)
/


