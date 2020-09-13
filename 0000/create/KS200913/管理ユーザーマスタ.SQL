create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_admin_users` (
	id int(11) primary key auto_increment not null comment 'ID',
	login_id  varchar(40)  default '60' not null comment 'ログインID : 分',
	password  varchar(256)  not null comment 'パスワード : 人',
	admin_name  varchar(20)  not null comment '氏名',
	department  varchar(40) ○ not null comment '部署',
	system_admin_permission  tinyint(1) default 0 not null comment 'システム管理者権限 : 0：一般　1：管理者',
	created_user  int not null comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int not null comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='管理ユーザーマスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_admin_users`(id , login_id , password , admin_name , department , system_admin_permission , created_user , updated_user , )
select old.id , old.login_id , old.password , old.admin_name , old.department , old.system_admin_permission , old.created_user , old.updated_user ,  from ks_cloud.m_admin_users old
/

drop table ks_cloud.m_admin_users cascade/

alter table ks_cloud.`$$m_admin_users` rename to m_admin_users
/

alter table ks_cloud.m_admin_users  add constraint `PRIMARY` primary key (id)
/


