create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_products` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約情報.ID',
	product_cd  varchar(40)  not null comment '自社品番',
	maker_cd  varchar(40)  not null comment 'メーカー品番',
	product_name  varchar(255)  comment '商品名',
	product_kana  varchar(255)  comment '商品カナ',
	product_abbreviation  varchar(255)  comment '商品略称',
	standard  varchar(255)  comment '規格',
	unit  tinyint(1) comment '単位 : =システム関連名称マスタ.ID　（区分=2)',
	jan_code  varchar(40)  comment 'JANコード',
	maker_id  tinyint(1) comment 'メーカー : =システム関連名称マスタ.ID　（区分=1)',
	m_varietie_id  int comment '品種 : =品種マスタ.ID',
	standard_supplier_id  int comment '標準仕入先 : =取引先マスタ.ID',
	products_aggregation_category1  tinyint(1) comment '商品マスタ集計区分1 : =集計区分名称マスタ.ID　（区分=5)',
	products_aggregation_category2  tinyint(1) comment '商品マスタ集計区分2 : =集計区分名称マスタ.ID　（区分=6)',
	order_data_flag  tinyint(1) default 0 not null comment '発注データ作成フラグ',
	over_order_alert_flag  tinyint(1) default 0 not null comment '過剰発注アラートフラグ',
	sale_flag  tinyint(1) comment '販売フラグ',
	purchase_flag  tinyint(1) default 0 not null comment '仕入フラグ',
	retail_price_tax_excluded  int comment '販売価格：販売上代（税抜）',
	retail_price_tax_included  int comment '販売価格：販売上代（税込）',
	retail_price_unit_price_tax_excluded  int comment '販売価格：上代単価（税抜）',
	retail_price_unit_price_tax_included  int comment '販売価格：上代単価（税込）',
	sale_price_tax_excluded  int comment '販売価格：販売単価（税抜）',
	sale_price_tax_included  int comment '販売価格：販売単価（税込）',
	tax_classification  tinyint(1) comment '販売価格：課税区分 : ※固定値：課税区分',
	purchase_price_tax_excluded  int comment '仕入価格：仕入上代（税抜）',
	purchase_price_tax_included  int comment '仕入価格：仕入上代（税込）',
	purchase_price_unit_price_tax_excluded  int comment '仕入価格：上代単価（税抜）',
	purchase_price_unit_price_tax_included  int comment '仕入価格：上代単価（税込）',
	purchase_unit  int comment '仕入価格：単位',
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
	required_factor_cost_1  float(11) comment '必要係数：原価1',
	required_factor_cost_2  float(11) comment '必要係数：原価2',
	required_factor_cost_3  float(11) comment '必要係数：原価3',
	discontinued_flag  tinyint(1) default 0 not null comment '廃番フラグ',
	m_catalog_product_id  int not null comment 'カタログ商品ID : =カタログ商品マスタ.ID',
	status  tinyint(1) default 0 not null comment 'ステータス : 0：仮登録、1：本登録',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='商品マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_products`(id , m_contract_id , product_cd , maker_cd , product_name , product_kana , product_abbreviation , standard , unit , jan_code , maker_id , m_varietie_id , standard_supplier_id , products_aggregation_category1 , products_aggregation_category2 , order_data_flag , over_order_alert_flag , sale_flag , purchase_flag , retail_price_tax_excluded , retail_price_tax_included , retail_price_unit_price_tax_excluded , retail_price_unit_price_tax_included , sale_price_tax_excluded , sale_price_tax_included , tax_classification , purchase_price_tax_excluded , purchase_price_tax_included , purchase_price_unit_price_tax_excluded , purchase_price_unit_price_tax_included , purchase_unit , cost_unit_price , minimum_order_quantity , quantity , reference_unit_price , cr_effective_width , cr_buy_unit , cr_repeat , cr_cutting_allowance , bb_effective_width , bb_cutting_allowance , bb_case_quantity , pt_width , pt_length , pt_min_cut_width , pt_case_quantity , pt_deemed_quantity , required_factor_cost_1 , required_factor_cost_2 , required_factor_cost_3 , discontinued_flag , m_catalog_product_id , status , created_user , updated_user , )
select old.id , old.m_contract_id , old.product_cd , old.maker_cd , old.product_name , old.product_kana , old.product_abbreviation , old.standard , old.unit , old.jan_code , old.maker_id , old.m_varietie_id , old.standard_supplier_id , old.products_aggregation_category1 , old.products_aggregation_category2 , old.order_data_flag , old.over_order_alert_flag , old.sale_flag , old.purchase_flag , old.retail_price_tax_excluded , old.retail_price_tax_included , old.retail_price_unit_price_tax_excluded , old.retail_price_unit_price_tax_included , old.sale_price_tax_excluded , old.sale_price_tax_included , old.tax_classification , old.purchase_price_tax_excluded , old.purchase_price_tax_included , old.purchase_price_unit_price_tax_excluded , old.purchase_price_unit_price_tax_included , old.purchase_unit , old.cost_unit_price , old.minimum_order_quantity , old.quantity , old.reference_unit_price , old.cr_effective_width , old.cr_buy_unit , old.cr_repeat , old.cr_cutting_allowance , old.bb_effective_width , old.bb_cutting_allowance , old.bb_case_quantity , old.pt_width , old.pt_length , old.pt_min_cut_width , old.pt_case_quantity , old.pt_deemed_quantity , old.required_factor_cost_1 , old.required_factor_cost_2 , old.required_factor_cost_3 , old.discontinued_flag , old.m_catalog_product_id , old.status , old.created_user , old.updated_user ,  from ks_cloud.m_products old
/

drop table ks_cloud.m_products cascade/

alter table ks_cloud.`$$m_products` rename to m_products
/

alter table ks_cloud.m_products  add constraint `PRIMARY` primary key (id)
/


