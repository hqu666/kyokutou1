create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$s_loging_users` (
	m_license_id  int not null primary key auto_increment not null comment 'ライセンスID : =ライセンスマスタ.ID',
	m_login_users_staff_id  int not null primary key auto_increment not null comment 'ログインユーザーID',
	host_name  varchar(255) not null primary key auto_increment not null comment 'ホスト名',
	logon_time  datetime not null comment 'ログオン時間',
	lasted_operation_time  datetime not null comment '最終操作時間',
	)
	comment='ログインユーザー'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$s_loging_users`(m_license_id , m_login_users_staff_id , host_name , logon_time , lasted_operation_time , )
select old.m_license_id , old.m_login_users_staff_id , old.host_name , old.logon_time , old.lasted_operation_time ,  from ks_cloud.s_loging_users old
/

drop table ks_cloud.s_loging_users cascade/

alter table ks_cloud.`$$s_loging_users` rename to s_loging_users
/

alter table ks_cloud.s_loging_users  add constraint `PRIMARY` primary key (id)
/


