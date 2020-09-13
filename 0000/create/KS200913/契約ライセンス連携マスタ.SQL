create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_contract_licenses` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	m_license_id  int not null comment 'ライセンスID : =ライセンスマスタ.ID',
	count_creatable_project  int default 0 not null comment '案件作成可能件数 : 0：無制限、0以上：限定数',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='契約ライセンス連携マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_contract_licenses`(id , m_contract_id , m_license_id , count_creatable_project , created_user , updated_user , )
select old.id , old.m_contract_id , old.m_license_id , old.count_creatable_project , old.created_user , old.updated_user ,  from ks_cloud.m_contract_licenses old
/

drop table ks_cloud.m_contract_licenses cascade/

alter table ks_cloud.`$$m_contract_licenses` rename to m_contract_licenses
/

alter table ks_cloud.m_contract_licenses  add constraint `PRIMARY` primary key (id)
/


