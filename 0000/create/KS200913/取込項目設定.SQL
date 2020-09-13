create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_import_item_settings` (
	id int(11) primary key auto_increment not null comment 'ID',
	if_maker_cd  tinyint(1) default 1 not null comment '取込設定：メーカー品番 : if=ImportFlag',
	if_product_name  tinyint(1) not null comment '取込設定：商品名',
	if_product_kana  tinyint(1) not null comment '取込設定：商品カナ',
	if_product_abbreviation  tinyint(1) not null comment '取込設定：商品略称',
	if_standard  tinyint(1) not null comment '取込設定：規格',
	if_unit  tinyint(1) not null comment '取込設定：単位',
	if_jan_code  tinyint(1) not null comment '取込設定：JANコード',
	if_maker_id  tinyint(1) not null comment '取込設定：メーカー',
	if_m_varietie_id  tinyint(1) default 0 not null comment '取込設定：品種',
	if_standard_supplier_id  tinyint(1) not null comment '取込設定：標準仕入先',
	if_products_aggregation_category1  tinyint(1) not null comment '取込設定：商品マスタ集計区分1',
	if_products_aggregation_category2  tinyint(1) not null comment '取込設定：商品マスタ集計区分2',
	if_order_data_flag  tinyint(1) not null comment '取込設定：発注データ作成フラグ',
	if_over_order_alert_flag  tinyint(1) not null comment '取込設定：過剰発注アラートフラグ',
	if_sale_flag  tinyint(1) not null comment '取込設定：販売フラグ',
	if_purchase_flag  tinyint(1) not null comment '取込設定：仕入フラグ',
	if_retail_price_tax_excluded  tinyint(1) not null comment '取込設定：販売価格：販売上代（税抜）',
	if_retail_price_tax_included  tinyint(1) not null comment '取込設定：販売価格：販売上代（税込）',
	if_sale_price_tax_excluded  tinyint(1) not null comment '取込設定：販売価格：販売単価（税抜）',
	if_sale_price_tax_included  tinyint(1) not null comment '取込設定：販売価格：販売単価（税込）',
	if_tax_classification  tinyint(1) not null comment '取込設定：販売価格：課税区分',
	if_purchase_price_tax_excluded  tinyint(1) not null comment '取込設定：仕入価格：仕入上代（税抜）',
	if_purchase_price_tax_included  tinyint(1) not null comment '取込設定：仕入価格：仕入上代（税込）',
	if_purchase_unit  tinyint(1) not null comment '取込設定：仕入価格：単位',
	if_cost_unit_price  tinyint(1) not null comment '取込設定：仕入価格：原価単価',
	if_minimum_order_quantity  tinyint(1) not null comment '取込設定：仕入価格：最低発注数',
	if_quantity  tinyint(1) not null comment '取込設定：仕入価格：単位当入数',
	if_reference_unit_price  tinyint(1) not null comment '取込設定：参考単価',
	if_lengths  tinyint(1) default 1 not null comment '取込設定：要尺',
	required_factor_cost_1  tinyint(1) not null comment '取込設定：必要係数：原価1',
	required_factor_cost_2  tinyint(1) not null comment '取込設定：必要係数：原価2',
	required_factor_cost_3  tinyint(1) not null comment '取込設定：必要係数：原価3',
	if_m_catalog_catalog_id  varchar(10)  not null comment '取込設定：カタログID',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='取込項目設定'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_import_item_settings`(id , if_maker_cd , if_product_name , if_product_kana , if_product_abbreviation , if_standard , if_unit , if_jan_code , if_maker_id , if_m_varietie_id , if_standard_supplier_id , if_products_aggregation_category1 , if_products_aggregation_category2 , if_order_data_flag , if_over_order_alert_flag , if_sale_flag , if_purchase_flag , if_retail_price_tax_excluded , if_retail_price_tax_included , if_sale_price_tax_excluded , if_sale_price_tax_included , if_tax_classification , if_purchase_price_tax_excluded , if_purchase_price_tax_included , if_purchase_unit , if_cost_unit_price , if_minimum_order_quantity , if_quantity , if_reference_unit_price , if_lengths , required_factor_cost_1 , required_factor_cost_2 , required_factor_cost_3 , if_m_catalog_catalog_id , created_user , updated_user , )
select old.id , old.if_maker_cd , old.if_product_name , old.if_product_kana , old.if_product_abbreviation , old.if_standard , old.if_unit , old.if_jan_code , old.if_maker_id , old.if_m_varietie_id , old.if_standard_supplier_id , old.if_products_aggregation_category1 , old.if_products_aggregation_category2 , old.if_order_data_flag , old.if_over_order_alert_flag , old.if_sale_flag , old.if_purchase_flag , old.if_retail_price_tax_excluded , old.if_retail_price_tax_included , old.if_sale_price_tax_excluded , old.if_sale_price_tax_included , old.if_tax_classification , old.if_purchase_price_tax_excluded , old.if_purchase_price_tax_included , old.if_purchase_unit , old.if_cost_unit_price , old.if_minimum_order_quantity , old.if_quantity , old.if_reference_unit_price , old.if_lengths , old.required_factor_cost_1 , old.required_factor_cost_2 , old.required_factor_cost_3 , old.if_m_catalog_catalog_id , old.created_user , old.updated_user ,  from ks_cloud.m_import_item_settings old
/

drop table ks_cloud.m_import_item_settings cascade/

alter table ks_cloud.`$$m_import_item_settings` rename to m_import_item_settings
/

alter table ks_cloud.m_import_item_settings  add constraint `PRIMARY` primary key (id)
/


