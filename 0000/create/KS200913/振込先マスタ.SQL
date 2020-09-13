create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_bank_accounts` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約情報.ID',
	bank_account_type  tinyint(1) not null comment '振込先区分 : =固定値：振込先区分',
	bank_account_code  tinyint(1)  comment '番号 : （自社）1～3、（部門）4',
	m_department_id  int not null comment '部門ID : =部門マスタ.ID　（部門の振込先の場合）',
	m_bank_id  int comment '銀行ID : =銀行マスタ.ID',
	deposit_type  tinyint(1)  comment '預金種別 : =固定値：預金種別',
	bank_account_name  varchar(20)  comment '名義人',
	bank_account_number  varchar(20)  comment '口座番号',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='振込先マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_bank_accounts`(id , m_contract_id , bank_account_type , bank_account_code , m_department_id , m_bank_id , deposit_type , bank_account_name , bank_account_number , created_user , updated_user , )
select old.id , old.m_contract_id , old.bank_account_type , old.bank_account_code , old.m_department_id , old.m_bank_id , old.deposit_type , old.bank_account_name , old.bank_account_number , old.created_user , old.updated_user ,  from ks_cloud.m_bank_accounts old
/

drop table ks_cloud.m_bank_accounts cascade/

alter table ks_cloud.`$$m_bank_accounts` rename to m_bank_accounts
/

alter table ks_cloud.m_bank_accounts  add constraint `PRIMARY` primary key (id)
/


