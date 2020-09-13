create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_postal_codes` (
	id int(11) primary key auto_increment not null comment 'ID',
	postal_code  varchar(7)  not null comment '—X•Ö”Ô†',
	prefectures_name  varchar(5)  not null comment '“s“¹•{Œ§–¼',
	prefectures_kana  varchar(10)  not null comment '“s“¹•{Œ§–¼ƒJƒi',
	address  varchar(255)  not null comment 'ZŠ',
	address_kana  varchar(255)  not null comment 'ZŠƒJƒi',
	creater  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	modifier  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	)
	comment='—X•Ö”Ô†ƒ}ƒXƒ^'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_postal_codes`(id , postal_code , prefectures_name , prefectures_kana , address , address_kana , creater , modifier , )
select old.id , old.postal_code , old.prefectures_name , old.prefectures_kana , old.address , old.address_kana , old.creater , old.modifier ,  from ks_cloud.m_postal_codes old
/

drop table ks_cloud.m_postal_codes cascade/

alter table ks_cloud.`$$m_postal_codes` rename to m_postal_codes
/

alter table ks_cloud.m_postal_codes  add constraint `PRIMARY` primary key (id)
/


