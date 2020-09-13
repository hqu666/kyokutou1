create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_slip_settings` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	m_login_users_staff_id  int not null comment 'ログインユーザーID : =ログインユーザーマスタ.ID',
	location_display_flag  tinyint(1) default 1 not null comment '場所：表示フラグ : 0：表示しない、1：表示する',
	location_union_item  tinyint(1) not null comment '場所：結合項目',
	location_order  int default 1 not null comment '場所：並び順',
	place_display_flag  tinyint(1) default 1 not null comment '箇所：表示 : 0：表示しない、1：表示する',
	place_union_item  tinyint(1) not null comment '箇所：結合項目',
	place_order  int default 2 not null comment '箇所：並び順',
	product_display_flag  tinyint(1) default 1 not null comment '自社品番：表示 : 0：表示しない、1：表示する',
	product_union_item  tinyint(1) not null comment '自社品番：結合項目',
	product_order  int default 3 not null comment '自社品番：並び順',
	maker_display_flag  tinyint(1) default 1 not null comment 'メーカー品番：表示 : 0：表示しない、1：表示する',
	maker_union_item  tinyint(1) not null comment 'メーカー品番：結合項目',
	maker_order  int default 4 not null comment 'メーカー品番：並び順',
	maker_name_display_flag  tinyint(1) default 1 not null comment 'メーカー名：表示 : 0：表示しない、1：表示する',
	maker_name_union_item  tinyint(1) not null comment 'メーカー名：結合項目',
	maker_name_order  int default 5 not null comment 'メーカー名：並び順',
	product_name_display_flag  tinyint(1) default 1 not null comment '品名：表示 : 0：表示しない、1：表示する',
	product_name_union_item  tinyint(1) not null comment '品名：結合項目',
	product_name_order  int default 6 not null comment '品名：並び順',
	standard_display_flag  tinyint(1) default 1 not null comment '規格：表示 : 0：表示しない、1：表示する',
	standard_union_item  tinyint(1) not null comment '規格：結合項目',
	standard_order  int default 7 not null comment '規格：並び順',
	variety_display_flag  tinyint(1) default 1 not null comment '品種：表示 : 0：表示しない、1：表示する',
	variety_union_item  tinyint(1) not null comment '品種：結合項目',
	variety_order  int default 8 not null comment '品種：並び順',
	quantity_display_flag  tinyint(1) default 1 not null comment '数量：表示 : 0：表示しない、1：表示する',
	quantity_union_item  tinyint(1) not null comment '数量：結合項目',
	quantity_order  int default 9 not null comment '数量：並び順',
	unit_display_flag  tinyint(1) default 1 not null comment '単位：表示 : 0：表示しない、1：表示する',
	unit_union_item  tinyint(1) not null comment '単位：結合項目',
	unit_order  int default 10 not null comment '単位：並び順',
	price_display_flag  tinyint(1) default 1 not null comment '単価：表示 : 0：表示しない、1：表示する',
	price_union_item  tinyint(1) not null comment '単価：結合項目',
	price_order  int default 11 not null comment '単価：並び順',
	am_display_flag  tinyint(1) default 1 not null comment '金額：表示 : am=Amount of money',
	am_union_item  tinyint(1) not null comment '金額：結合項目',
	am_order  int default 12 not null comment '金額：並び順',
	remarks_display_flag  tinyint(1) default 1 not null comment '備考：表示 : 0：表示しない、1：表示する',
	remarks_union_item  tinyint(1) not null comment '備考：結合項目',
	remarks_order  int default 13 not null comment '備考：並び順',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='伝票画面設定'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_slip_settings`(id , m_contract_id , m_login_users_staff_id , location_display_flag , location_union_item , location_order , place_display_flag , place_union_item , place_order , product_display_flag , product_union_item , product_order , maker_display_flag , maker_union_item , maker_order , maker_name_display_flag , maker_name_union_item , maker_name_order , product_name_display_flag , product_name_union_item , product_name_order , standard_display_flag , standard_union_item , standard_order , variety_display_flag , variety_union_item , variety_order , quantity_display_flag , quantity_union_item , quantity_order , unit_display_flag , unit_union_item , unit_order , price_display_flag , price_union_item , price_order , am_display_flag , am_union_item , am_order , remarks_display_flag , remarks_union_item , remarks_order , created_user , updated_user , )
select old.id , old.m_contract_id , old.m_login_users_staff_id , old.location_display_flag , old.location_union_item , old.location_order , old.place_display_flag , old.place_union_item , old.place_order , old.product_display_flag , old.product_union_item , old.product_order , old.maker_display_flag , old.maker_union_item , old.maker_order , old.maker_name_display_flag , old.maker_name_union_item , old.maker_name_order , old.product_name_display_flag , old.product_name_union_item , old.product_name_order , old.standard_display_flag , old.standard_union_item , old.standard_order , old.variety_display_flag , old.variety_union_item , old.variety_order , old.quantity_display_flag , old.quantity_union_item , old.quantity_order , old.unit_display_flag , old.unit_union_item , old.unit_order , old.price_display_flag , old.price_union_item , old.price_order , old.am_display_flag , old.am_union_item , old.am_order , old.remarks_display_flag , old.remarks_union_item , old.remarks_order , old.created_user , old.updated_user ,  from ks_cloud.m_slip_settings old
/

drop table ks_cloud.m_slip_settings cascade/

alter table ks_cloud.`$$m_slip_settings` rename to m_slip_settings
/

alter table ks_cloud.m_slip_settings  add constraint `PRIMARY` primary key (id)
/


