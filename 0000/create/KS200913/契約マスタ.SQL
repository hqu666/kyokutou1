create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_contracts` (
	m_contract_id  int not null primary key auto_increment not null comment '契約ID',
	contract_number  varchar(20) ○ not null comment '契約番号',
	company_name  varchar(40)  not null comment '会社名',
	department_name  varchar(40) ○ not null comment '部署名',
	contract_period_start  date not null comment '契約期間（開始）',
	contract_period_end  date○ not null comment '契約期間（終了）',
	shop_code  varchar(8) ○ not null comment '代理店コード',
	shop_name  varchar(32) ○ not null comment '代理店名',
	m_sidebar_category_id  int not null comment 'サイドバーカテゴリID : ＝カテゴリマスタ．ID',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='契約マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_contracts`(m_contract_id , contract_number , company_name , department_name , contract_period_start , contract_period_end , shop_code , shop_name , m_sidebar_category_id , created_user , updated_user , )
select old.m_contract_id , old.contract_number , old.company_name , old.department_name , old.contract_period_start , old.contract_period_end , old.shop_code , old.shop_name , old.m_sidebar_category_id , old.created_user , old.updated_user ,  from ks_cloud.m_contracts old
/

drop table ks_cloud.m_contracts cascade/

alter table ks_cloud.`$$m_contracts` rename to m_contracts
/

alter table ks_cloud.m_contracts  add constraint `PRIMARY` primary key (id)
/


