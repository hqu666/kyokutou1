create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_project_bases` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñƒ}ƒXƒ^.ID',
	project_code  varchar(10)  not null comment 'ˆÄŒ”Ô†',
	project_manage_code  varchar(255) comment 'ˆÄŒŠÇ—”Ô†',
	project_name  varchar(255)  not null comment 'ˆÄŒ–¼',
	m_property_id  int default 0 comment '•¨ŒID : =•¨Œƒ}ƒXƒ^.ID',
	delivery_date  date comment '”[Šú',
	plan_construction_period_from  date comment '—\’èHŠúiFROMj',
	plan_construction_period_to  date comment '—\’èHŠúiTO)',
	m_supplier_id  int comment '“¾ˆÓæID : =æˆøæƒ}ƒXƒ^.ID@i“¾ˆÓæj',
	m_supplier_staff_id  int comment '“¾ˆÓæ’S“–ÒID : =æˆøæ•”–å’S“–Òƒ}ƒXƒ^.ID',
	owner_name  varchar(20)  comment '{å–¼',
	d_m_supplier_id  int comment '”[“üæID : =æˆøæƒ}ƒXƒ^.ID@i“¾ˆÓæj',
	d_postal_code  varchar(8)  comment '”[“üæF—X•Ö”Ô†',
	d_m_prefecture_id  tinyint(1) comment '”[“üæF“s“¹•{Œ§‚h‚c',
	d_address_1  varchar(255)  comment '”[“üæFZŠ‚P',
	d_address_2  varchar(255)  comment '”[“üæFZŠ‚Q',
	d_search_address  varchar(255)  comment '”[“üæFŒŸõ—pZŠ',
	m_department_id  int comment '•”–åID : =•”–åƒ}ƒXƒ^.ID',
	m_own_company_staff_id  int comment '©Ğ’S“–ÒID : =©Ğ’S“–Òƒ}ƒXƒ^.ID',
	expiration_date  date comment '—LŒøŠúŒÀ“ú',
	billing_expected_date  date comment '¿‹—\’è“ú',
	tax_classification  tinyint(1) comment '‰ÛÅ‹æ•ª',
	tax_fraction_processing  tinyint(1) comment 'Å’[”ˆ—',
	aggregate_type_1  tinyint(1) comment 'WŒv‹æ•ª1',
	aggregate_type_2  tinyint(1) comment 'WŒv‹æ•ª2',
	aggregate_type_3  tinyint(1) comment 'WŒv‹æ•ª3',
	aggregate_type_4  tinyint(1) comment 'WŒv‹æ•ª4',
	memo  varchar(4000)  comment 'ƒƒ‚',
	summary  varchar(1000)  comment '“E—v',
	quotation_discard_date  date comment 'Œ©Ï”jŠü“ú',
	failure_date  date comment '¸’“ú',
	failure_cause_id  varchar(50)  comment '¸’——RID',
	advance_payment  int default 0 comment '‘Oó‹à',
	temporary_sales_money  int default 0 comment '‰¼”„ã‹à',
	total_amount  decimal(18,0)  not null comment '”„ãŠz',
	tax_amount  int not null comment 'Á”ïÅ',
	total_amount_tax_included  decimal(18,0)  not null comment '”„ã‡Œv : ”„ãŠz{Á”ïÅ',
	total_allocations_amount  decimal(18,0)  not null comment 'Š„UÏŠz : ‚±‚ÌˆÄŒ‚É•R‚Ã‚¯‚ç‚ê‚Ä‚¢‚éŠ„Uƒf[ƒ^‚ÌŠ„UŠz‚Ì‘Šz',
	allocation_remains  decimal(18,0)  not null comment 'Š„UcŠz : ”„ã‡Œv-Š„UÏŠz',
	print_setting  tinyint(1) default 0 comment 'ˆóüİ’è',
	confirmed_date  date comment 'Šm’è“ú : Šm’èˆ—‚ªs‚í‚ê‚½“ú',
	status  tinyint(1) default 0 comment 'ƒXƒe[ƒ^ƒX : ¦ŒÅ’è’lFˆÄŒƒXƒe[ƒ^ƒX',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)))
	comment='ˆÄŒî•ñŠî–{'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_project_bases`(id , m_contract_id , project_code , project_manage_code , project_name , m_property_id , delivery_date , plan_construction_period_from , plan_construction_period_to , m_supplier_id , m_supplier_staff_id , owner_name , d_m_supplier_id , d_postal_code , d_m_prefecture_id , d_address_1 , d_address_2 , d_search_address , m_department_id , m_own_company_staff_id , expiration_date , billing_expected_date , tax_classification , tax_fraction_processing , aggregate_type_1 , aggregate_type_2 , aggregate_type_3 , aggregate_type_4 , memo , summary , quotation_discard_date , failure_date , failure_cause_id , advance_payment , temporary_sales_money , total_amount , tax_amount , total_amount_tax_included , total_allocations_amount , allocation_remains , print_setting , confirmed_date , status , created_user , updated_user , )
select old.id , old.m_contract_id , old.project_code , old.project_manage_code , old.project_name , old.m_property_id , old.delivery_date , old.plan_construction_period_from , old.plan_construction_period_to , old.m_supplier_id , old.m_supplier_staff_id , old.owner_name , old.d_m_supplier_id , old.d_postal_code , old.d_m_prefecture_id , old.d_address_1 , old.d_address_2 , old.d_search_address , old.m_department_id , old.m_own_company_staff_id , old.expiration_date , old.billing_expected_date , old.tax_classification , old.tax_fraction_processing , old.aggregate_type_1 , old.aggregate_type_2 , old.aggregate_type_3 , old.aggregate_type_4 , old.memo , old.summary , old.quotation_discard_date , old.failure_date , old.failure_cause_id , old.advance_payment , old.temporary_sales_money , old.total_amount , old.tax_amount , old.total_amount_tax_included , old.total_allocations_amount , old.allocation_remains , old.print_setting , old.confirmed_date , old.status , old.created_user , old.updated_user ,  from ks_cloud.t_project_bases old
/

drop table ks_cloud.t_project_bases cascade/

alter table ks_cloud.`$$t_project_bases` rename to t_project_bases
/

alter table ks_cloud.t_project_bases  add constraint `PRIMARY` primary key (id)
/


