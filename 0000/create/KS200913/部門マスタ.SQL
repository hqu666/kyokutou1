create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_departments` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	department_cd  varchar(5)  not null comment '部門コード',
	department_name  varchar(20)  not null comment '部門名称',
	postal_code  varchar(8)  not null comment '郵便番号',
	m_prefecture_id  tinyint(1) not null comment '都道府県 : =都道府県マスタ.ID',
	address_1  varchar(255)  not null comment '住所1',
	address_2  varchar(255)  comment '住所2',
	tell_number  varchar(16)  not null comment 'TEL',
	fax_number  varchar(16)  comment 'FAX',
	bank  int comment '取引銀行 : 2020/07/31 削除→振込先マスタへ',
	transfer_account  varchar(20)  comment '振込口座 : 2020/07/31 削除→振込先マスタへ',
	bank_account_name  varchar(20)  comment '名義人 : 2020/07/31 削除→振込先マスタへ',
	department_head_name  varchar(20)  comment '部門長名',
	email  varchar(256)  comment 'Email',
	url_address  varchar(256)  comment 'URL',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='部門マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_departments`(id , m_contract_id , department_cd , department_name , postal_code , m_prefecture_id , address_1 , address_2 , tell_number , fax_number , bank , transfer_account , bank_account_name , department_head_name , email , url_address , created_user , updated_user , )
select old.id , old.m_contract_id , old.department_cd , old.department_name , old.postal_code , old.m_prefecture_id , old.address_1 , old.address_2 , old.tell_number , old.fax_number , old.bank , old.transfer_account , old.bank_account_name , old.department_head_name , old.email , old.url_address , old.created_user , old.updated_user ,  from ks_cloud.m_departments old
/

drop table ks_cloud.m_departments cascade/

alter table ks_cloud.`$$m_departments` rename to m_departments
/

alter table ks_cloud.m_departments  add constraint `PRIMARY` primary key (id)
/


