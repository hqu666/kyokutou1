create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_catalog_product_price_matrixes` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_catalog_product_id  int not null comment 'カタログ商品ID : =カタログ商品マスタ.ID',
	creater  int default 0 comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	modifier  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='カタログ商品単価マトリクス'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_catalog_product_price_matrixes`(id , m_catalog_product_id , creater , modifier , )
select old.id , old.m_catalog_product_id , old.creater , old.modifier ,  from ks_cloud.m_catalog_product_price_matrixes old
/

drop table ks_cloud.m_catalog_product_price_matrixes cascade/

alter table ks_cloud.`$$m_catalog_product_price_matrixes` rename to m_catalog_product_price_matrixes
/

alter table ks_cloud.m_catalog_product_price_matrixes  add constraint `PRIMARY` primary key (id)
/


