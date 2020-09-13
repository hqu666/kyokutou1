create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_banks` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	bank_cd  varchar(4)  not null comment '銀行コード',
	bank_name  varchar(20)  not null comment '銀行名',
	branch_cd  varchar(3)  not null comment '支店コード',
	branch_name  varchar(20)  not null comment '支店名',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='銀行マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_banks`(id , m_contract_id , bank_cd , bank_name , branch_cd , branch_name , created_user , updated_user , )
select old.id , old.m_contract_id , old.bank_cd , old.bank_name , old.branch_cd , old.branch_name , old.created_user , old.updated_user ,  from ks_cloud.m_banks old
/

drop table ks_cloud.m_banks cascade/

alter table ks_cloud.`$$m_banks` rename to m_banks
/

alter table ks_cloud.m_banks  add constraint `PRIMARY` primary key (id)
/


