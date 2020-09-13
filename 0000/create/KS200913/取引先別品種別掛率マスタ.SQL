create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_supplier_variety_rates` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	type_id  tinyint(1) not null comment '種別 : ※固定値：取引先区分',
	m_supplier_id  int not null comment '取引先ID : =取引先マスタ.ID',
	m_varietie_id  int not null comment '品種ID : =品種マスタ.ID',
	rate  decimal(5,2)  not null comment '掛率',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1),type_id (2),m_supplier_id (3)))
	comment='取引先別品種別掛率マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_supplier_variety_rates`(id , m_contract_id , type_id , m_supplier_id , m_varietie_id , rate , created_user , updated_user , )
select old.id , old.m_contract_id , old.type_id , old.m_supplier_id , old.m_varietie_id , old.rate , old.created_user , old.updated_user ,  from ks_cloud.m_supplier_variety_rates old
/

drop table ks_cloud.m_supplier_variety_rates cascade/

alter table ks_cloud.`$$m_supplier_variety_rates` rename to m_supplier_variety_rates
/

alter table ks_cloud.m_supplier_variety_rates  add constraint `PRIMARY` primary key (id)
/


