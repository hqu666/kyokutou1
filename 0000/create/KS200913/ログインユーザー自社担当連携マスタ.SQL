create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_login_user_connections` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_own_company_staff_id  int not null comment '自社担当者ID : =自社担当者マスタ.ID',
	m_login_users_staff_id  int not null comment 'ログインユーザーID : =ログインユーザーマスタ.ID',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='ログインユーザー自社担当連携マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_login_user_connections`(id , m_own_company_staff_id , m_login_users_staff_id , created_user , updated_user , )
select old.id , old.m_own_company_staff_id , old.m_login_users_staff_id , old.created_user , old.updated_user ,  from ks_cloud.m_login_user_connections old
/

drop table ks_cloud.m_login_user_connections cascade/

alter table ks_cloud.`$$m_login_user_connections` rename to m_login_user_connections
/

alter table ks_cloud.m_login_user_connections  add constraint `PRIMARY` primary key (id)
/


