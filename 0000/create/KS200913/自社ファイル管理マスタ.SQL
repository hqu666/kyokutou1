create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_own_company_file_management` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約情報.ID',
	document_name  varchar(255)  not null comment '名称',
	file_path  varchar(500)  not null comment 'ファイルパス : フルパス',
	file_name  varchar(255)  not null comment 'ファイル名称',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='自社ファイル管理'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_own_company_file_management`(id , m_contract_id , document_name , file_path , file_name , created_user , updated_user , )
select old.id , old.m_contract_id , old.document_name , old.file_path , old.file_name , old.created_user , old.updated_user ,  from ks_cloud.m_own_company_file_management old
/

drop table ks_cloud.m_own_company_file_management cascade/

alter table ks_cloud.`$$m_own_company_file_management` rename to m_own_company_file_management
/

alter table ks_cloud.m_own_company_file_management  add constraint `PRIMARY` primary key (id)
/


