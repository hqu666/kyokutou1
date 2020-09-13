create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_taxs` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	tax_cd  varchar(5)  not null comment '消費税コード',
	tax_name  varchar(20)  not null comment '消費税名称',
	operation_date_start  date not null comment '運用開始日',
	operation_date_end  date○ not null comment '運用終了日',
	tax_rate  decimal(5,2)  not null comment '税率',
	transitional_date_start  date○ not null comment '経過措置適用開始日',
	transitional_date_end  date○ not null comment '経過措置適用終了日',
	default_flag  tinyint(1) default 0 not null comment '初期値フラグ',
	ks_flag  tinyint(1) not null comment '極東産機フラグ : 1：極東産機設定、0：ユーザー設定',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='消費税マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_taxs`(id , m_contract_id , tax_cd , tax_name , operation_date_start , operation_date_end , tax_rate , transitional_date_start , transitional_date_end , default_flag , ks_flag , created_user , updated_user , )
select old.id , old.m_contract_id , old.tax_cd , old.tax_name , old.operation_date_start , old.operation_date_end , old.tax_rate , old.transitional_date_start , old.transitional_date_end , old.default_flag , old.ks_flag , old.created_user , old.updated_user ,  from ks_cloud.m_taxs old
/

drop table ks_cloud.m_taxs cascade/

alter table ks_cloud.`$$m_taxs` rename to m_taxs
/

alter table ks_cloud.m_taxs  add constraint `PRIMARY` primary key (id)
/


