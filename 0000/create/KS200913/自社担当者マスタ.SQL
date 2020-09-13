create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_own_company_staffs` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	staff_cd  varchar(20)  not null comment '担当者コード',
	staff_name  varchar(40)  not null comment '担当者名',
	m_login_users_staff_id  int not null comment 'ログインユーザーID : =ログインユーザーマスタ.ID',
	group_id  not null comment 'グループID : 不要',
	password  varchar(256)  not null comment 'パスワード : 不要',
	m_department_id  int not null comment '部門ID : 部門マスタのID',
	contact_number  varchar(16)  comment '連絡先',
	mobile_number  varchar(16)  comment '携帯電話',
	email  varchar(255)  comment 'メールアドレス',
	invalid_flg  tinyint(1) default 0 not null comment '無効フラグ',
	data_varsion  comment 'データバージョン : 不要',
	spare_1  varchar(40)  comment '予備１',
	spare_2  varchar(40)  comment '予備２',
	spare_3  varchar(40)  comment '予備３',
	spare_n1  varchar(40)  comment '予備N1',
	spare_n2  varchar(40)  comment '予備N2',
	spare_n3  varchar(40)  comment '予備N3',
	spare_d1  varchar(40)  comment '予備D1',
	spare_d2  varchar(40)  comment '予備D２',
	spare_d3  varchar(40)  comment '予備D3',
	stamp_image  varchar(256)  comment '印鑑イメージ',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='自社担当者マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_own_company_staffs`(id , m_contract_id , staff_cd , staff_name , m_login_users_staff_id , group_id , password , m_department_id , contact_number , mobile_number , email , invalid_flg , data_varsion , spare_1 , spare_2 , spare_3 , spare_n1 , spare_n2 , spare_n3 , spare_d1 , spare_d2 , spare_d3 , stamp_image , created_user , updated_user , )
select old.id , old.m_contract_id , old.staff_cd , old.staff_name , old.m_login_users_staff_id , old.group_id , old.password , old.m_department_id , old.contact_number , old.mobile_number , old.email , old.invalid_flg , old.data_varsion , old.spare_1 , old.spare_2 , old.spare_3 , old.spare_n1 , old.spare_n2 , old.spare_n3 , old.spare_d1 , old.spare_d2 , old.spare_d3 , old.stamp_image , old.created_user , old.updated_user ,  from ks_cloud.m_own_company_staffs old
/

drop table ks_cloud.m_own_company_staffs cascade/

alter table ks_cloud.`$$m_own_company_staffs` rename to m_own_company_staffs
/

alter table ks_cloud.m_own_company_staffs  add constraint `PRIMARY` primary key (id)
/


