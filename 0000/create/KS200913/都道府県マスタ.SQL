create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_prefectures` (
	id int(11) primary key auto_increment not null comment 'ID',
	prefectures_name  varchar(10)  not null comment '“s“¹•{Œ§–¼',
	)
	comment='“s“¹•{Œ§ƒ}ƒXƒ^'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_prefectures`(id , prefectures_name , )
select old.id , old.prefectures_name ,  from ks_cloud.m_prefectures old
/

drop table ks_cloud.m_prefectures cascade/

alter table ks_cloud.`$$m_prefectures` rename to m_prefectures
/

alter table ks_cloud.m_prefectures  add constraint `PRIMARY` primary key (id)
/


