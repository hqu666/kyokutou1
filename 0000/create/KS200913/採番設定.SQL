create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_numbering_settings` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	numbering_type  tinyint(1) not null comment '採番種別 : ※固定値：採番種別',
	prefix_suffix  tinyint(1) not null comment '接頭辞／接尾辞 : ※固定値：接頭辞／接尾辞',
	identifier  varchar(5)  not null comment '識別子',
	numbering_rule  tinyint(1) not null comment '採番ルール : ※固定値：採番ルール',
	number_of_digits  tinyint(1) not null comment '桁数',
	final_number  int default 0 not null comment '最終番号',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='採番設定'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_numbering_settings`(id , m_contract_id , numbering_type , prefix_suffix , identifier , numbering_rule , number_of_digits , final_number , created_user , updated_user , )
select old.id , old.m_contract_id , old.numbering_type , old.prefix_suffix , old.identifier , old.numbering_rule , old.number_of_digits , old.final_number , old.created_user , old.updated_user ,  from ks_cloud.m_numbering_settings old
/

drop table ks_cloud.m_numbering_settings cascade/

alter table ks_cloud.`$$m_numbering_settings` rename to m_numbering_settings
/

alter table ks_cloud.m_numbering_settings  add constraint `PRIMARY` primary key (id)
/


