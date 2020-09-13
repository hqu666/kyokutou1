create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_option_settings` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	m_login_users_staff_id  int not null comment 'ログインユーザーID : =ログインユーザーマスタ.ID',
	statement_delete_message  tinyint(1) not null comment '明細行削除時メッセージ',
	theme  int not null comment 'テーマ : ※固定値定義書：Z-5.テーマ名',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='オプション設定'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_option_settings`(id , m_contract_id , m_login_users_staff_id , statement_delete_message , theme , created_user , updated_user , )
select old.id , old.m_contract_id , old.m_login_users_staff_id , old.statement_delete_message , old.theme , old.created_user , old.updated_user ,  from ks_cloud.m_option_settings old
/

drop table ks_cloud.m_option_settings cascade/

alter table ks_cloud.`$$m_option_settings` rename to m_option_settings
/

alter table ks_cloud.m_option_settings  add constraint `PRIMARY` primary key (id)
/


