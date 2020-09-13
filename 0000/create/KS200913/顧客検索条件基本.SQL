create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_customer_condition_bases` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñî•ñ.ID',
	search_name  varchar(100)  not null comment 'ğŒ–¼',
	description  varchar(1000)  comment 'à–¾',
	m_own_company_staff_id  int comment '©Ğ’S“–ÒID',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)))
	comment='ŒÚ‹qŒŸõğŒŠî–{'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_customer_condition_bases`(id , m_contract_id , search_name , description , m_own_company_staff_id , created_user , updated_user , )
select old.id , old.m_contract_id , old.search_name , old.description , old.m_own_company_staff_id , old.created_user , old.updated_user ,  from ks_cloud.t_customer_condition_bases old
/

drop table ks_cloud.t_customer_condition_bases cascade/

alter table ks_cloud.`$$t_customer_condition_bases` rename to t_customer_condition_bases
/

alter table ks_cloud.t_customer_condition_bases  add constraint `PRIMARY` primary key (id)
/


