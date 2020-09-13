create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_purchase_slip_order_details` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	t_purchase_slip_order_headers_id  int not null comment '購買発注ヘッダID : =購買情報伝票（発注書ヘッダ）.ID',
	col_number  int not null comment '行番号',
	name_type  tinyint(1) not null comment '区分',
	t_project_base_id  int not null comment '案件ID : =案件基本情報.ID',
	event_place  varchar(255)  not null comment '場所',
	place  not null comment '箇所',
	product_cd  varchar(40)  not null comment '自社品番',
	maker_cd  varchar(40)  not null comment 'メーカー品番',
	maker_name  varchar(50)  not null comment 'メーカー名',
	m_product_id  int not null comment '商品ID : =商品マスタ.ID',
	product_name  varchar(255)  not null comment '品名',
	standard  varchar(255)  not null comment '規格',
	m_varietie_id  int not null comment '品種ID',
	variety_name  varchar(50)  not null comment '品種名',
	quantity  decimal(18,2)  not null comment '数量',
	unit  tinyint(1) comment '単位 : =システム関連名称マスタ.ID　（区分=2)',
	price  decimal(18,0)  not null comment '単価',
	amount  decimal(18,0)  not null comment '金額',
	remark  varchar(4000)  not null comment '備考',
	purchase_retail_price_tax_excluded  not null comment '仕入上代（税抜）',
	rate  decimal(5,2)  not null comment '掛率',
	m_tax_id  int not null comment '消費税ID',
	tax_rate  decimal(5,2)  not null comment '税率',
	court_productivity_rate  decimal(3,0)  not null comment '法廷歩掛率',
	tax_amount  int comment '消費税',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='購買情報伝票（発注書明細）'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_purchase_slip_order_details`(id , m_contract_id , t_purchase_slip_order_headers_id , col_number , name_type , t_project_base_id , event_place , place , product_cd , maker_cd , maker_name , m_product_id , product_name , standard , m_varietie_id , variety_name , quantity , unit , price , amount , remark , purchase_retail_price_tax_excluded , rate , m_tax_id , tax_rate , court_productivity_rate , tax_amount , created_user , updated_user , )
select old.id , old.m_contract_id , old.t_purchase_slip_order_headers_id , old.col_number , old.name_type , old.t_project_base_id , old.event_place , old.place , old.product_cd , old.maker_cd , old.maker_name , old.m_product_id , old.product_name , old.standard , old.m_varietie_id , old.variety_name , old.quantity , old.unit , old.price , old.amount , old.remark , old.purchase_retail_price_tax_excluded , old.rate , old.m_tax_id , old.tax_rate , old.court_productivity_rate , old.tax_amount , old.created_user , old.updated_user ,  from ks_cloud.t_purchase_slip_order_details old
/

drop table ks_cloud.t_purchase_slip_order_details cascade/

alter table ks_cloud.`$$t_purchase_slip_order_details` rename to t_purchase_slip_order_details
/

alter table ks_cloud.t_purchase_slip_order_details  add constraint `PRIMARY` primary key (id)
/


