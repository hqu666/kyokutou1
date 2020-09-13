create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_catalog_products` (
	id int(11) primary key auto_increment not null comment 'ID',
	variety_type  int not null comment '品種区分 : ※固定値：品種区分',
	maker_cd  varchar(40)  not null comment 'メーカー品番',
	product_name  varchar(255)  comment '商品名',
	product_kana  varchar(255)  comment '商品カナ',
	product_abbreviation  varchar(255)  comment '商品略称',
	standard  varchar(255)  comment '規格',
	jan_code  varchar(40)  comment 'JANコード',
	order_data_flag  tinyint(1) default 0 not null comment '発注データ作成フラグ : 不要',
	over_order_alert_flag  tinyint(1) default 0 not null comment '過剰発注アラートフラグ : 不要',
	sale_flag  tinyint(1) comment '販売フラグ : 不要',
	purchase_flag  tinyint(1) default 0 not null comment '仕入フラグ : 不要',
	retail_price_tax_excluded  int comment '販売価格：販売上代（税抜）',
	retail_price_tax_included  int comment '販売価格：販売上代（税込）',
	sale_price_tax_excluded  int comment '販売価格：販売単価（税抜）',
	sale_price_tax_included  int comment '販売価格：販売単価（税込）',
	tax_classification  tinyint(1) comment '販売価格：課税区分 : ※固定値：課税区分',
	purchase_price_tax_excluded  int comment '仕入価格：仕入上代（税抜）',
	purchase_price_tax_included  int comment '仕入価格：仕入上代（税込）',
	cost_unit_price  int comment '仕入価格：原価単価',
	minimum_order_quantity  int comment '仕入価格：最低発注数',
	quantity  int comment '仕入価格：単位当入数',
	reference_unit_price  int comment '参考単価',
	cr_effective_width  int comment '要尺：クロス・クッションフロア：有効巾 : cr=Cross',
	cr_buy_unit  int comment '要尺：クロス・クッションフロア：購入単位',
	cr_repeat  int comment '要尺：クロス・クッションフロア：リピート',
	cr_cutting_allowance  int comment '要尺：クロス・クッションフロア：切り代',
	bb_effective_width  int comment '要尺：巾木：有効巾 : bb=Baseboard',
	bb_cutting_allowance  int comment '要尺：巾木：切り代',
	bb_case_quantity  int comment '要尺：巾木：ケース入り数',
	pt_width  int comment '要尺：Ｐタイル・タイルカーペット：巾 : pt= P tile',
	pt_length  int comment '要尺：Ｐタイル・タイルカーペット：長さ',
	pt_min_cut_width  int comment '要尺：Ｐタイル・タイルカーペット：最小カット巾',
	pt_case_quantity  int comment '要尺：Ｐタイル・タイルカーペット：ケース入り数',
	pt_deemed_quantity  int comment '要尺：Ｐタイル・タイルカーペット：㎡当みなし枚数',
	required_factor_cost_1  float(11) comment '必要係数：原価1 : 不要',
	required_factor_cost_2  float(11) comment '必要係数：原価2 : 不要',
	required_factor_cost_3  float(11) comment '必要係数：原価3 : 不要',
	m_catalog_id  int not null comment 'カタログマスタID : =カタログマスタ．ID',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='カタログ商品マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_catalog_products`(id , variety_type , maker_cd , product_name , product_kana , product_abbreviation , standard , jan_code , order_data_flag , over_order_alert_flag , sale_flag , purchase_flag , retail_price_tax_excluded , retail_price_tax_included , sale_price_tax_excluded , sale_price_tax_included , tax_classification , purchase_price_tax_excluded , purchase_price_tax_included , cost_unit_price , minimum_order_quantity , quantity , reference_unit_price , cr_effective_width , cr_buy_unit , cr_repeat , cr_cutting_allowance , bb_effective_width , bb_cutting_allowance , bb_case_quantity , pt_width , pt_length , pt_min_cut_width , pt_case_quantity , pt_deemed_quantity , required_factor_cost_1 , required_factor_cost_2 , required_factor_cost_3 , m_catalog_id , created_user , updated_user , )
select old.id , old.variety_type , old.maker_cd , old.product_name , old.product_kana , old.product_abbreviation , old.standard , old.jan_code , old.order_data_flag , old.over_order_alert_flag , old.sale_flag , old.purchase_flag , old.retail_price_tax_excluded , old.retail_price_tax_included , old.sale_price_tax_excluded , old.sale_price_tax_included , old.tax_classification , old.purchase_price_tax_excluded , old.purchase_price_tax_included , old.cost_unit_price , old.minimum_order_quantity , old.quantity , old.reference_unit_price , old.cr_effective_width , old.cr_buy_unit , old.cr_repeat , old.cr_cutting_allowance , old.bb_effective_width , old.bb_cutting_allowance , old.bb_case_quantity , old.pt_width , old.pt_length , old.pt_min_cut_width , old.pt_case_quantity , old.pt_deemed_quantity , old.required_factor_cost_1 , old.required_factor_cost_2 , old.required_factor_cost_3 , old.m_catalog_id , old.created_user , old.updated_user ,  from ks_cloud.m_catalog_products old
/

drop table ks_cloud.m_catalog_products cascade/

alter table ks_cloud.`$$m_catalog_products` rename to m_catalog_products
/

alter table ks_cloud.m_catalog_products  add constraint `PRIMARY` primary key (id)
/


