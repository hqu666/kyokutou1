create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_deposit_allocations` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	t_deposit_id  int not null comment '入金情報ID : =入金情報（一括）.ID',
	t_project_base_id  int not null comment '案件ID : =案件情報基本.ID',
	t_project_slip_invoice_header_id  int not null comment '請求明細ヘッダID : =案件情報請求明細ヘッダ.ID',
	allocations_amount  decimal(18,0)  not null comment '割振額',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)),idx2(t_deposit_id (1)))
	comment='入金割振情報'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_deposit_allocations`(id , m_contract_id , t_deposit_id , t_project_base_id , t_project_slip_invoice_header_id , allocations_amount , created_user , updated_user , )
select old.id , old.m_contract_id , old.t_deposit_id , old.t_project_base_id , old.t_project_slip_invoice_header_id , old.allocations_amount , old.created_user , old.updated_user ,  from ks_cloud.t_deposit_allocations old
/

drop table ks_cloud.t_deposit_allocations cascade/

alter table ks_cloud.`$$t_deposit_allocations` rename to t_deposit_allocations
/

alter table ks_cloud.t_deposit_allocations  add constraint `PRIMARY` primary key (id)
/


