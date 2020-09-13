create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_sidebar_categories` (
	id int(11) primary key auto_increment not null comment 'ID',
	category_key  varchar(40)  not null comment 'カテゴリキー',
	url_address  varchar(256)  not null comment 'URL',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='サイドバーカテゴリマスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_sidebar_categories`(id , category_key , url_address , created_user , updated_user , )
select old.id , old.category_key , old.url_address , old.created_user , old.updated_user ,  from ks_cloud.m_sidebar_categories old
/

drop table ks_cloud.m_sidebar_categories cascade/

alter table ks_cloud.`$$m_sidebar_categories` rename to m_sidebar_categories
/

alter table ks_cloud.m_sidebar_categories  add constraint `PRIMARY` primary key (id)
/


