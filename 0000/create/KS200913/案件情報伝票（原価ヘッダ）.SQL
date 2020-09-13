create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_project_slip_order_headers` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	t_project_base_id  int not null comment '案件情報基本ID',
	tab_id  int(2)  not null comment 'タブID',
	status_date  date not null comment 'ステータス日',
	trading_condition  varchar(50)  not null comment '取引条件',
	summary  varchar(1000)  not null comment '摘要',
	total_amount  decimal(18,0)  not null comment '合計金額（税抜）',
	tax_amount  decimal(18,0)  not null comment '消費税金額',
	reduction_tax_amount  decimal(18,0)  not null comment '消費税金額(軽減税率対象)',
	total_amount_tax_included  decimal(18,0)  not null comment '合計金額（税込）',
	cost_tab_1_amount  int not null comment '原価タブ①金額',
	cost_tab_2_amount  int not null comment '原価タブ②金額',
	cost_tab_3_amount  int not null comment '原価タブ③金額',
	cost_total_amount  int not null comment '原価合計金額',
	discount_amount  int not null comment '値引金額',
	project_gross_profit_rate  decimal(3,0)  not null comment '案件粗利率',
	project_gross_profit_amount  int not null comment '案件粗利金額',
	average_labor_cost_amount  decimal(5,2)  not null comment '平均労務費額',
	average_productivity_rate  decimal(5,2)  not null comment '平均歩掛率',
	social_insurance_charge_rate  decimal(5,2)  not null comment '社会保険料率',
	legal_welfare_expenses_amount  decimal(18,0)  not null comment '法定福利費額',
	billing_transfer_target_information  not null comment '請求振込先情報',
	lock_flag  tinyint(1)  default 0 not null comment 'ロックフラグ : 0：未ロック、1：ロック中',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='案件情報伝票（発注書ヘッダ）'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_project_slip_order_headers`(id , m_contract_id , t_project_base_id , tab_id , status_date , trading_condition , summary , total_amount , tax_amount , reduction_tax_amount , total_amount_tax_included , cost_tab_1_amount , cost_tab_2_amount , cost_tab_3_amount , cost_total_amount , discount_amount , project_gross_profit_rate , project_gross_profit_amount , average_labor_cost_amount , average_productivity_rate , social_insurance_charge_rate , legal_welfare_expenses_amount , billing_transfer_target_information , lock_flag , created_user , updated_user , )
select old.id , old.m_contract_id , old.t_project_base_id , old.tab_id , old.status_date , old.trading_condition , old.summary , old.total_amount , old.tax_amount , old.reduction_tax_amount , old.total_amount_tax_included , old.cost_tab_1_amount , old.cost_tab_2_amount , old.cost_tab_3_amount , old.cost_total_amount , old.discount_amount , old.project_gross_profit_rate , old.project_gross_profit_amount , old.average_labor_cost_amount , old.average_productivity_rate , old.social_insurance_charge_rate , old.legal_welfare_expenses_amount , old.billing_transfer_target_information , old.lock_flag , old.created_user , old.updated_user ,  from ks_cloud.t_project_slip_order_headers old
/

drop table ks_cloud.t_project_slip_order_headers cascade/

alter table ks_cloud.`$$t_project_slip_order_headers` rename to t_project_slip_order_headers
/

alter table ks_cloud.t_project_slip_order_headers  add constraint `PRIMARY` primary key (id)
/


