create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_service_settings` (
	id int(11) primary key auto_increment not null comment 'ID',
	temporary_password_limit  int default 60 not null comment '仮パスワード有効時間 : 分',
	concurrent_executions_limit  int not null comment 'データ取込同時実行数 : 人',
	data_import_max_file_size  int not null comment 'データ取込最大ファイルサイズ : KB単位',
	supplier_price_rates_max_count  int not null comment '単価掛率設定得意先最大件数',
	product_price_rates_max_count  int not null comment '単価掛率設定商品最大件数',
	is_maintenance  tinyint(1) default 0 not null comment 'システムメンテナンスモードフラグ : 0：Off、1：On',
	created_user  int not null comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int not null comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='サービス設定'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_service_settings`(id , temporary_password_limit , concurrent_executions_limit , data_import_max_file_size , supplier_price_rates_max_count , product_price_rates_max_count , is_maintenance , created_user , updated_user , )
select old.id , old.temporary_password_limit , old.concurrent_executions_limit , old.data_import_max_file_size , old.supplier_price_rates_max_count , old.product_price_rates_max_count , old.is_maintenance , old.created_user , old.updated_user ,  from ks_cloud.m_service_settings old
/

drop table ks_cloud.m_service_settings cascade/

alter table ks_cloud.`$$m_service_settings` rename to m_service_settings
/

alter table ks_cloud.m_service_settings  add constraint `PRIMARY` primary key (id)
/


