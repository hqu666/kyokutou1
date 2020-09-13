create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_catalog_product_price_matrixes` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_catalog_product_id  int not null comment 'カタログ商品ID : =商品マスタ.ID',
	col_name  varchar(20)  not null comment '縦軸名',
	row_name  varchar(20)  not null comment '横軸名',
	col_count  int not null comment '行数',
	row_count  int not null comment '列数',
	row1  varchar(100)  not null comment '行1 : カンマ区切りで列の情報を格納',
	row2  varchar(100)  not null comment '行2 : 例）100,100,100,100,100,,,',
	row3  varchar(100)  not null comment '行3 : 例）,,,,,,,',
	row4  varchar(100)  not null comment '行4',
	row5  varchar(100)  not null comment '行5',
	row6  varchar(100)  not null comment '行6',
	row7  varchar(100)  not null comment '行7',
	row8  varchar(100)  not null comment '行8',
	col_item_name1  varchar(20)  not null comment '縦軸項目名1',
	col_item_name2  varchar(20)  not null comment '縦軸項目名2',
	col_item_name3  varchar(20)  not null comment '縦軸項目名3',
	col_item_name4  varchar(20)  not null comment '縦軸項目名4',
	col_item_name5  varchar(20)  not null comment '縦軸項目名5',
	col_item_name6  varchar(20)  not null comment '縦軸項目名6',
	col_item_name7  varchar(20)  not null comment '縦軸項目名7',
	col_item_name8  varchar(20)  not null comment '縦軸項目名8',
	row_item_name1  varchar(20)  not null comment '横軸項目名1',
	row_item_name2  varchar(20)  not null comment '横軸項目名2',
	row_item_name3  varchar(20)  not null comment '横軸項目名3',
	row_item_name4  varchar(20)  not null comment '横軸項目名4',
	row_item_name5  varchar(20)  not null comment '横軸項目名5',
	row_item_name6  varchar(20)  not null comment '横軸項目名6',
	row_item_name7  varchar(20)  not null comment '横軸項目名7',
	row_item_name8  varchar(20)  not null comment '横軸項目名8',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_catalog_product_id (２)))
	comment='カタログ商品単価マトリクス'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_catalog_product_price_matrixes`(id , m_catalog_product_id , col_name , row_name , col_count , row_count , row1 , row2 , row3 , row4 , row5 , row6 , row7 , row8 , col_item_name1 , col_item_name2 , col_item_name3 , col_item_name4 , col_item_name5 , col_item_name6 , col_item_name7 , col_item_name8 , row_item_name1 , row_item_name2 , row_item_name3 , row_item_name4 , row_item_name5 , row_item_name6 , row_item_name7 , row_item_name8 , created_user , updated_user , )
select old.id , old.m_catalog_product_id , old.col_name , old.row_name , old.col_count , old.row_count , old.row1 , old.row2 , old.row3 , old.row4 , old.row5 , old.row6 , old.row7 , old.row8 , old.col_item_name1 , old.col_item_name2 , old.col_item_name3 , old.col_item_name4 , old.col_item_name5 , old.col_item_name6 , old.col_item_name7 , old.col_item_name8 , old.row_item_name1 , old.row_item_name2 , old.row_item_name3 , old.row_item_name4 , old.row_item_name5 , old.row_item_name6 , old.row_item_name7 , old.row_item_name8 , old.created_user , old.updated_user ,  from ks_cloud.m_catalog_product_price_matrixes old
/

drop table ks_cloud.m_catalog_product_price_matrixes cascade/

alter table ks_cloud.`$$m_catalog_product_price_matrixes` rename to m_catalog_product_price_matrixes
/

alter table ks_cloud.m_catalog_product_price_matrixes  add constraint `PRIMARY` primary key (id)
/


