create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_ft_balance_billings` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contracts_id  int not null comment '契約ID : =契約マスタ.ID',
	m_suppliers_id  int not null comment '取引先ID : =取引先マスタ.ID',
	last_month_date  date not null comment '前月請求日',
	last_month_amount  int not null comment '前月請求額',
	is_deleted  tinyint(1) default 0 not null comment '削除フラグ',
	creater  int not null comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	modifier  int not null comment '更新者',
	updated_at datetime comment '更新日時',
	index idx1(m_contracts_id (1)),idx2(m_contracts_id (1),m_suppliers_id (2)))
	comment='初回残高請求額'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_ft_balance_billings`(id , m_contracts_id , m_suppliers_id , last_month_date , last_month_amount , is_deleted , creater , modifier , )
select old.id , old.m_contracts_id , old.m_suppliers_id , old.last_month_date , old.last_month_amount , old.is_deleted , old.creater , old.modifier ,  from ks_cloud.m_ft_balance_billings old
/

drop table ks_cloud.m_ft_balance_billings cascade/

alter table ks_cloud.`$$m_ft_balance_billings` rename to m_ft_balance_billings
/

alter table ks_cloud.m_ft_balance_billings  add constraint `PRIMARY` primary key (id)
/


