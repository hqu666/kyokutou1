create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_system_settings` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	cost_tab_name1  varchar(20)  default '材料原価' comment '原価タブ名称1',
	cost_tab_name2  varchar(20)  default '施工原価' comment '原価タブ名称2',
	cost_tab_name3  varchar(20)  default 'その他経費' comment '原価タブ名称3',
	slip_header_aggregate_name1  varchar(20)  default '顧客業態' comment '伝票ヘッダ集計区分名称1',
	slip_header_aggregate_name2  varchar(20)  default '商圏' comment '伝票ヘッダ集計区分名称2',
	slip_header_aggregate_name3  varchar(20)  default '販売経路' comment '伝票ヘッダ集計区分名称3',
	slip_header_aggregate_name4  varchar(20)  default '予備' comment '伝票ヘッダ集計区分名称4',
	product_aggregate_name1  varchar(20)  default '大分類' comment '商品マスタ集計区分名称1',
	product_aggregate_name2  varchar(20)  default '小分類' comment '商品マスタ集計区分名称2',
	client_aggregate_name1  varchar(20)  default '物件情報' comment '顧客マスタ集計区分名称1',
	client_aggregate_name2  varchar(20)  default '地区' comment '顧客マスタ集計区分名称2',
	client_aggregate_name3  varchar(20)  default '紹介経路' comment '顧客マスタ集計区分名称3',
	client_aggregate_name4  varchar(20)  default '予備①' comment '顧客マスタ集計区分名称4',
	client_aggregate_name5  varchar(20)  default '予備②' comment '顧客マスタ集計区分名称5',
	property_management_flag  tinyint(1) default 0 not null comment '物件管理フラグ',
	cost_function_flag  tinyint(1) default 0 not null comment '原価フラグ',
	width_function_flag  tinyint(1) default 0 not null comment '要尺機能フラグ',
	department_flag  tinyint(1) default 1 not null comment '部門フラグ : 0：部門無し、1：部門あり',
	supplier_price_rates_max_count  int not null comment '単価掛率設定得意先最大件数',
	product_price_rates_max_count  int not null comment '単価掛率設定商品最大件数',
	root_path  varchar(255)  comment 'ルートパス : 案件基本情報(ks009)や、物件マスタ(ks022)の「ファイル添付」でGoogle連携していない時',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='システム設定'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_system_settings`(id , m_contract_id , cost_tab_name1 , cost_tab_name2 , cost_tab_name3 , slip_header_aggregate_name1 , slip_header_aggregate_name2 , slip_header_aggregate_name3 , slip_header_aggregate_name4 , product_aggregate_name1 , product_aggregate_name2 , client_aggregate_name1 , client_aggregate_name2 , client_aggregate_name3 , client_aggregate_name4 , client_aggregate_name5 , property_management_flag , cost_function_flag , width_function_flag , department_flag , supplier_price_rates_max_count , product_price_rates_max_count , root_path , created_user , updated_user , )
select old.id , old.m_contract_id , old.cost_tab_name1 , old.cost_tab_name2 , old.cost_tab_name3 , old.slip_header_aggregate_name1 , old.slip_header_aggregate_name2 , old.slip_header_aggregate_name3 , old.slip_header_aggregate_name4 , old.product_aggregate_name1 , old.product_aggregate_name2 , old.client_aggregate_name1 , old.client_aggregate_name2 , old.client_aggregate_name3 , old.client_aggregate_name4 , old.client_aggregate_name5 , old.property_management_flag , old.cost_function_flag , old.width_function_flag , old.department_flag , old.supplier_price_rates_max_count , old.product_price_rates_max_count , old.root_path , old.created_user , old.updated_user ,  from ks_cloud.m_system_settings old
/

drop table ks_cloud.m_system_settings cascade/

alter table ks_cloud.`$$m_system_settings` rename to m_system_settings
/

alter table ks_cloud.m_system_settings  add constraint `PRIMARY` primary key (id)
/


