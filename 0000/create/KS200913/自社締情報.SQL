create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_confirmation_processes` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	confirmation_processes_type  tinyint(1)  not null comment '自社締区分 : 固定値：自社締区分',
	closing_date  date not null comment '締日',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='自社締情報'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_confirmation_processes`(id , m_contract_id , confirmation_processes_type , closing_date , created_user , updated_user , )
select old.id , old.m_contract_id , old.confirmation_processes_type , old.closing_date , old.created_user , old.updated_user ,  from ks_cloud.t_confirmation_processes old
/

drop table ks_cloud.t_confirmation_processes cascade/

alter table ks_cloud.`$$t_confirmation_processes` rename to t_confirmation_processes
/

alter table ks_cloud.t_confirmation_processes  add constraint `PRIMARY` primary key (id)
/


