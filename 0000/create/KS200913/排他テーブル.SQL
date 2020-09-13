create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$s_transactions` (
	m_contract_id  int not null primary key auto_increment not null comment 'å_ñÒID',
	)
	comment='îrëºÉeÅ[ÉuÉã'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$s_transactions`(m_contract_id , )
select old.m_contract_id ,  from ks_cloud.s_transactions old
/

drop table ks_cloud.s_transactions cascade/

alter table ks_cloud.`$$s_transactions` rename to s_transactions
/

alter table ks_cloud.s_transactions  add constraint `PRIMARY` primary key (id)
/


