create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_purchase_slip_letters` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñƒ}ƒXƒ^.ID',
	summary  varchar(1000)  not null comment '“E—v',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)))
	comment='w”ƒî•ñ“`•[i‘—•tój'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_purchase_slip_letters`(id , m_contract_id , summary , created_user , updated_user , )
select old.id , old.m_contract_id , old.summary , old.created_user , old.updated_user ,  from ks_cloud.t_purchase_slip_letters old
/

drop table ks_cloud.t_purchase_slip_letters cascade/

alter table ks_cloud.`$$t_purchase_slip_letters` rename to t_purchase_slip_letters
/

alter table ks_cloud.t_purchase_slip_letters  add constraint `PRIMARY` primary key (id)
/


