create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_catalogs` (
	id int(11) primary key auto_increment not null comment 'ID',
	catalog_id  varchar(10)  not null comment 'カタログID',
	catalog_name  varchar(200)  not null comment 'カタログ名',
	rental_start  date not null comment '有効期間(FROM)',
	rental_end  date comment '有効期間(TO)',
	is_unsubscribe  tinyint(1)  default 0 not null comment '配信停止 : 1:配信停止',
	product_file  comment '商品ファイル : 不要',
	length_file  comment '要尺ファイル : 不要',
	memo  varchar(4000)  comment 'メモ',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='カタログマスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_catalogs`(id , catalog_id , catalog_name , rental_start , rental_end , is_unsubscribe , product_file , length_file , memo , created_user , updated_user , )
select old.id , old.catalog_id , old.catalog_name , old.rental_start , old.rental_end , old.is_unsubscribe , old.product_file , old.length_file , old.memo , old.created_user , old.updated_user ,  from ks_cloud.m_catalogs old
/

drop table ks_cloud.m_catalogs cascade/

alter table ks_cloud.`$$m_catalogs` rename to m_catalogs
/

alter table ks_cloud.m_catalogs  add constraint `PRIMARY` primary key (id)
/


