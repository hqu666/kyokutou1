create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_varieties` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	variety_type  int not null comment '品種区分 : ※固定値：品種区分',
	variety_code  int not null comment '品種コード',
	variety_name  varchar(50)  not null comment '品種名',
	order  int not null comment '並び順',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)),idx2(m_contract_id (1),variety_type (2)))
	comment='品種マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_varieties`(id , m_contract_id , variety_type , variety_code , variety_name , order , created_user , updated_user , )
select old.id , old.m_contract_id , old.variety_type , old.variety_code , old.variety_name , old.order , old.created_user , old.updated_user ,  from ks_cloud.m_varieties old
/

drop table ks_cloud.m_varieties cascade/

alter table ks_cloud.`$$m_varieties` rename to m_varieties
/

alter table ks_cloud.m_varieties  add constraint `PRIMARY` primary key (id)
/


