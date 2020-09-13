create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_properties` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñƒ}ƒXƒ^.ID',
	property_code  varchar(10)  not null comment '•¨ŒƒR[ƒh',
	property_name  varchar(40)  not null comment '•¨Œ–¼Ì',
	property_kana  varchar(40)  not null comment '•¨ŒƒJƒi',
	owner_name  varchar(20)  comment '{å–¼',
	postal_code  varchar(8)  not null comment '—X•Ö”Ô†',
	m_prefecture_id  tinyint(1) not null comment '“s“¹•{Œ§ : =“s“¹•{Œ§ƒ}ƒXƒ^.ID',
	address_1  varchar(255)  not null comment 'ZŠ1',
	address_2  varchar(255)  comment 'ZŠ2',
	tell_number  varchar(16)  not null comment 'TEL',
	fax_number  varchar(16)  comment 'FAX',
	map_url  varchar(1000)  comment '’n}URL',
	remark  varchar(4000)  comment '”õl',
	search_address  varchar(256)  comment 'ŒŸõ—pZŠ : “s“¹•{Œ§–¼{ZŠ1{ZŠ2',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)))
	comment='•¨Œƒ}ƒXƒ^'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_properties`(id , m_contract_id , property_code , property_name , property_kana , owner_name , postal_code , m_prefecture_id , address_1 , address_2 , tell_number , fax_number , map_url , remark , search_address , created_user , updated_user , )
select old.id , old.m_contract_id , old.property_code , old.property_name , old.property_kana , old.owner_name , old.postal_code , old.m_prefecture_id , old.address_1 , old.address_2 , old.tell_number , old.fax_number , old.map_url , old.remark , old.search_address , old.created_user , old.updated_user ,  from ks_cloud.m_properties old
/

drop table ks_cloud.m_properties cascade/

alter table ks_cloud.`$$m_properties` rename to m_properties
/

alter table ks_cloud.m_properties  add constraint `PRIMARY` primary key (id)
/


