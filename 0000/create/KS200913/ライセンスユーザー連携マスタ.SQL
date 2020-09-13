create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_license_users` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_license_id  int not null comment 'ライセンスID : =ライセンスマスタ.ID',
	m_login_users_staff_id  int not null comment 'ログインユーザーID : =ログインユーザーマスタ.ID',
	level  tinyint(1) not null comment '権限 : ※固定値：権限',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_license_id (1)))
	comment='ライセンスユーザー連携マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_license_users`(id , m_license_id , m_login_users_staff_id , level , created_user , updated_user , )
select old.id , old.m_license_id , old.m_login_users_staff_id , old.level , old.created_user , old.updated_user ,  from ks_cloud.m_license_users old
/

drop table ks_cloud.m_license_users cascade/

alter table ks_cloud.`$$m_license_users` rename to m_license_users
/

alter table ks_cloud.m_license_users  add constraint `PRIMARY` primary key (id)
/


