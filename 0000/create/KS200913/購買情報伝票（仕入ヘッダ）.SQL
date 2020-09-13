create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_purchase_slip_purchase_headers` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñƒ}ƒXƒ^.ID',
	t_purchase_base_id  int not null comment 'w”ƒî•ñŠî–{ID : =w”ƒî•ñŠî–{.ID',
	status_date  date not null comment 'ƒXƒe[ƒ^ƒX“ú',
	summary  varchar(1000)  not null comment '“E—v',
	total_amount  decimal(18,0)  not null comment '‡Œv‹àŠziÅ”²j',
	tax_amount  decimal(18,0)  not null comment 'Á”ïÅ‹àŠz',
	reduction_tax_amount  decimal(18,0)  not null comment 'Á”ïÅ‹àŠz(ŒyŒ¸Å—¦‘ÎÛ)',
	total_amount_tax_included  decimal(18,0)  not null comment '‡Œv‹àŠziÅj',
	cost_tab_1_amount  int not null comment 'Œ´‰¿ƒ^ƒu‡@‹àŠz',
	cost_tab_2_amount  int not null comment 'Œ´‰¿ƒ^ƒu‡A‹àŠz',
	cost_tab_3_amount  int not null comment 'Œ´‰¿ƒ^ƒu‡B‹àŠz',
	cost_total_amount  int not null comment 'Œ´‰¿‡Œv‹àŠz',
	discount_amount  int not null comment '’lˆø‹àŠz',
	project_gross_profit_rate  decimal(3,0)  not null comment 'ˆÄŒ‘e—˜—¦',
	project_gross_profit_amount  int not null comment 'ˆÄŒ‘e—˜‹àŠz',
	average_labor_cost_amount  decimal(5,2)  not null comment '•½‹Ï˜J–±”ïŠz',
	average_productivity_rate  decimal(5,2)  not null comment '•½‹Ï•àŠ|—¦',
	social_insurance_charge_rate  decimal(5,2)  not null comment 'Ğ‰ï•ÛŒ¯—¿—¦',
	legal_welfare_expenses_amount  decimal(18,0)  not null comment '–@’è•Ÿ—˜”ïŠz',
	billing_transfer_target_information  not null comment '¿‹Uæî•ñ',
	lock_flag  tinyint(1)  default 0 not null comment 'ƒƒbƒNƒtƒ‰ƒO : 0F–¢ƒƒbƒNA1FƒƒbƒN’†',
	payment_closing_target_date  date not null comment 'x•¥’÷‘ÎÛ“ú',
	payment_form_issuing_flag  tinyint(1) default 0 not null comment 'x•¥‘”­sƒtƒ‰ƒO : 0F–¢”­sA1F”­sÏ',
	payment_form_issuing_date  date not null comment 'x•¥‘”­s“ú',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)))
	comment='w”ƒî•ñ“`•[id“ü‘ƒwƒbƒ_j'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_purchase_slip_purchase_headers`(id , m_contract_id , t_purchase_base_id , status_date , summary , total_amount , tax_amount , reduction_tax_amount , total_amount_tax_included , cost_tab_1_amount , cost_tab_2_amount , cost_tab_3_amount , cost_total_amount , discount_amount , project_gross_profit_rate , project_gross_profit_amount , average_labor_cost_amount , average_productivity_rate , social_insurance_charge_rate , legal_welfare_expenses_amount , billing_transfer_target_information , lock_flag , payment_closing_target_date , payment_form_issuing_flag , payment_form_issuing_date , created_user , updated_user , )
select old.id , old.m_contract_id , old.t_purchase_base_id , old.status_date , old.summary , old.total_amount , old.tax_amount , old.reduction_tax_amount , old.total_amount_tax_included , old.cost_tab_1_amount , old.cost_tab_2_amount , old.cost_tab_3_amount , old.cost_total_amount , old.discount_amount , old.project_gross_profit_rate , old.project_gross_profit_amount , old.average_labor_cost_amount , old.average_productivity_rate , old.social_insurance_charge_rate , old.legal_welfare_expenses_amount , old.billing_transfer_target_information , old.lock_flag , old.payment_closing_target_date , old.payment_form_issuing_flag , old.payment_form_issuing_date , old.created_user , old.updated_user ,  from ks_cloud.t_purchase_slip_purchase_headers old
/

drop table ks_cloud.t_purchase_slip_purchase_headers cascade/

alter table ks_cloud.`$$t_purchase_slip_purchase_headers` rename to t_purchase_slip_purchase_headers
/

alter table ks_cloud.t_purchase_slip_purchase_headers  add constraint `PRIMARY` primary key (id)
/


