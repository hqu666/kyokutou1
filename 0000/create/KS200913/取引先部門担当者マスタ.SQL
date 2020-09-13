create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_supplier_staffs` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	m_supplier_id  int not null comment '取引先ID : =取引先マスタ.ID',
	staff_cd  varchar(20)  not null comment '担当者コード',
	staff_name  varchar(40)  not null comment '担当者名',
	position  varchar(20)  comment '役職',
	contact_number  varchar(16)  not null comment '連絡先',
	mobile_number  varchar(16)  comment '携帯電話',
	email  varchar(256)  comment 'Email',
	remark  varchar(4000)  comment '備考',
	invalid_flg  tinyint(1) default 0 not null comment '無効フラグ',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1),m_supplier_id (2)))
	comment='取引先部門担当者マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_supplier_staffs`(id , m_contract_id , m_supplier_id , staff_cd , staff_name , position , contact_number , mobile_number , email , remark , invalid_flg , created_user , updated_user , )
select old.id , old.m_contract_id , old.m_supplier_id , old.staff_cd , old.staff_name , old.position , old.contact_number , old.mobile_number , old.email , old.remark , old.invalid_flg , old.created_user , old.updated_user ,  from ks_cloud.m_supplier_staffs old
/

drop table ks_cloud.m_supplier_staffs cascade/

alter table ks_cloud.`$$m_supplier_staffs` rename to m_supplier_staffs
/

alter table ks_cloud.m_supplier_staffs  add constraint `PRIMARY` primary key (id)
/


