create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_supplier_product_price_rates` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	type_id  tinyint(1) not null comment '種別 : ※固定値：取引先区分',
	m_supplier_id  int not null comment '取引先ID : =取引先マスタ.ID',
	m_product_id  int not null comment '商品ID : =商品マスタ.ID',
	price  decimal(18,0)  not null primary key auto_increment not null comment '単価',
	rate  decimal(5,2)  not null primary key auto_increment not null comment '掛率',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1),type_id (2),m_supplier_id (3)))
	comment='取引先別商品別単価掛率マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_supplier_product_price_rates`(id , m_contract_id , type_id , m_supplier_id , m_product_id , price , rate , created_user , updated_user , )
select old.id , old.m_contract_id , old.type_id , old.m_supplier_id , old.m_product_id , old.price , old.rate , old.created_user , old.updated_user ,  from ks_cloud.m_supplier_product_price_rates old
/

drop table ks_cloud.m_supplier_product_price_rates cascade/

alter table ks_cloud.`$$m_supplier_product_price_rates` rename to m_supplier_product_price_rates
/

alter table ks_cloud.m_supplier_product_price_rates  add constraint `PRIMARY` primary key (id)
/


