create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_google_account` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID',
	google_account  varchar(100)  not null comment 'Googleアカウント : @gmail.comのアカウント',
	client_id  varchar(200)  not null comment 'GoogleクライアントID : GoogleAPIが使用するアカウント相当情報',
	client_secret  varchar(100)  not null comment 'Googleクライアントシークレット : 上記のパスワード相当相当',
	project_id  varchar(40)  not null comment 'GoogleプロジェクトID : GoogleAPIの登録先名',
	calender_id  varchar(200)  default 'primary' not null comment 'カレンダID',
	drive_id  varchar(255)  not null comment 'ドライブID',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='Googleアカウント認証テーブル'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_google_account`(id , m_contract_id , google_account , client_id , client_secret , project_id , calender_id , drive_id , created_user , updated_user , )
select old.id , old.m_contract_id , old.google_account , old.client_id , old.client_secret , old.project_id , old.calender_id , old.drive_id , old.created_user , old.updated_user ,  from ks_cloud.m_google_account old
/

drop table ks_cloud.m_google_account cascade/

alter table ks_cloud.`$$m_google_account` rename to m_google_account
/

alter table ks_cloud.m_google_account  add constraint `PRIMARY` primary key (id)
/


