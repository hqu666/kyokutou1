create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_mail_settings` (
	id int(11) primary key auto_increment not null comment 'ID',
	template_id  int not null comment 'テンプレートID',
	template_name  varchar(20)  not null comment 'テンプレート名',
	mail_from  varchar(100)  not null comment '差出人',
	mail_cc  varchar(255)  not null comment 'CC',
	mail_bcc  varchar(255)  not null comment 'BCC',
	subject  varchar(255) not null comment '件名',
	contents  text not null comment '本文',
	signature  text not null comment '署名',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(template_id (1)))
	comment='メール設定マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_mail_settings`(id , template_id , template_name , mail_from , mail_cc , mail_bcc , subject , contents , signature , created_user , updated_user , )
select old.id , old.template_id , old.template_name , old.mail_from , old.mail_cc , old.mail_bcc , old.subject , old.contents , old.signature , old.created_user , old.updated_user ,  from ks_cloud.m_mail_settings old
/

drop table ks_cloud.m_mail_settings cascade/

alter table ks_cloud.`$$m_mail_settings` rename to m_mail_settings
/

alter table ks_cloud.m_mail_settings  add constraint `PRIMARY` primary key (id)
/


