create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_purchase_bases` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñƒ}ƒXƒ^.ID',
	purchase_code  varchar(10)  not null comment 'w”ƒ”Ô†',
	purchase_manage_code  varchar(255) comment 'w”ƒŠÇ—”Ô†',
	purchase_name  varchar(255)  not null comment 'w”ƒˆÄŒ–¼',
	desired_delivery_date  date comment 'Šó–]”[Šú',
	m_property_id  int default 0 comment '•¨ŒID : =•¨Œƒ}ƒXƒ^.ID',
	m_supplier_id  int comment 'æˆøæID : =æˆøæƒ}ƒXƒ^.ID@id“üæj',
	m_supplier_staff_id  int comment 'd“üæ’S“–ÒID : =æˆøæ•”–å’S“–Òƒ}ƒXƒ^.ID',
	d_m_supplier_id  int comment '”[“üæID : =æˆøæƒ}ƒXƒ^.ID@i“¾ˆÓæj',
	d_postal_code  varchar(8)  comment '”[“üæF—X•Ö”Ô† : =“s“¹•{Œ§ƒ}ƒXƒ^.ID',
	d_m_prefecture_id  tinyint(1) comment '”[“üæF“s“¹•{Œ§‚h‚c',
	d_address_1  varchar(255)  comment '”[“üæFZŠ‚P',
	d_address_2  varchar(255)  comment '”[“üæFZŠ‚Q',
	d_search_address  varchar(255)  comment '”[“üæFŒŸõ—pZŠ : —X•Ö”Ô†{“s“¹•{Œ§–¼{ZŠ‚P{ZŠ‚Q',
	m_department_id  int comment '•”–åID : =•”–åƒ}ƒXƒ^.ID',
	h_m_own_company_staff_id  int comment '”­’’S“–ÒID : =©Ğ’S“–Òƒ}ƒXƒ^.ID',
	delivery_slip_code  date comment '”[•i‘”Ô†',
	payment_expected_date  date comment 'x•¥—\’è“ú',
	memo  varchar(4000)  comment 'ƒƒ‚',
	summary  varchar(1000)  comment '“E—v',
	confirmed_date  date comment 'Šm’è“ú : Šm’èˆ—‚ªs‚í‚ê‚½“ú',
	status  tinyint(1) default 0 comment 'ƒXƒe[ƒ^ƒX : ¦ŒÅ’è’lFw”ƒƒXƒe[ƒ^ƒX',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)))
	comment='w”ƒî•ñŠî–{'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_purchase_bases`(id , m_contract_id , purchase_code , purchase_manage_code , purchase_name , desired_delivery_date , m_property_id , m_supplier_id , m_supplier_staff_id , d_m_supplier_id , d_postal_code , d_m_prefecture_id , d_address_1 , d_address_2 , d_search_address , m_department_id , h_m_own_company_staff_id , delivery_slip_code , payment_expected_date , memo , summary , confirmed_date , status , created_user , updated_user , )
select old.id , old.m_contract_id , old.purchase_code , old.purchase_manage_code , old.purchase_name , old.desired_delivery_date , old.m_property_id , old.m_supplier_id , old.m_supplier_staff_id , old.d_m_supplier_id , old.d_postal_code , old.d_m_prefecture_id , old.d_address_1 , old.d_address_2 , old.d_search_address , old.m_department_id , old.h_m_own_company_staff_id , old.delivery_slip_code , old.payment_expected_date , old.memo , old.summary , old.confirmed_date , old.status , old.created_user , old.updated_user ,  from ks_cloud.t_purchase_bases old
/

drop table ks_cloud.t_purchase_bases cascade/

alter table ks_cloud.`$$t_purchase_bases` rename to t_purchase_bases
/

alter table ks_cloud.t_purchase_bases  add constraint `PRIMARY` primary key (id)
/


