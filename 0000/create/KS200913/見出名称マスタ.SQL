create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_headline_names` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	name_type  varchar(255) not null comment '種別 : ※固定値：見出名称',
	name_code  varchar(20)  not null comment 'コード',
	name_value  varchar(50)  not null comment '名称',
	order  int not null comment '並び順',
	creater  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	modifier  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1),name_type (2)))
	comment='見出名称マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_headline_names`(id , m_contract_id , name_type , name_code , name_value , order , creater , modifier , )
select old.id , old.m_contract_id , old.name_type , old.name_code , old.name_value , old.order , old.creater , old.modifier ,  from ks_cloud.m_headline_names old
/

drop table ks_cloud.m_headline_names cascade/

alter table ks_cloud.`$$m_headline_names` rename to m_headline_names
/

alter table ks_cloud.m_headline_names  add constraint `PRIMARY` primary key (id)
/


