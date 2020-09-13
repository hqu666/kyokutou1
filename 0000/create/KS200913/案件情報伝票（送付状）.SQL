create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_project_slip_letters` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	t_project_base_id  int not null comment '案件情報基本ID',
	summary  varchar(1000)  not null comment '摘要',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='案件情報伝票（送付状）'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_project_slip_letters`(id , m_contract_id , t_project_base_id , summary , created_user , updated_user , )
select old.id , old.m_contract_id , old.t_project_base_id , old.summary , old.created_user , old.updated_user ,  from ks_cloud.t_project_slip_letters old
/

drop table ks_cloud.t_project_slip_letters cascade/

alter table ks_cloud.`$$t_project_slip_letters` rename to t_project_slip_letters
/

alter table ks_cloud.t_project_slip_letters  add constraint `PRIMARY` primary key (id)
/


