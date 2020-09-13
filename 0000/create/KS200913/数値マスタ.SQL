create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_numbers` (
	value  tinyint(1) not null comment '値 : 0～9',
	)
	comment='数値マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_numbers`(value , )
select old.value ,  from ks_cloud.m_numbers old
/

drop table ks_cloud.m_numbers cascade/

alter table ks_cloud.`$$m_numbers` rename to m_numbers
/

alter table ks_cloud.m_numbers  add constraint `PRIMARY` primary key (id)
/


