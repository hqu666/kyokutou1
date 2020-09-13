create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_billing_summaries` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	billing_no  not null comment '請求No',
	m_supplier_id  int not null comment '得意先ID : =取引先マスタ.ID',
	t_project_base_id  int○ not null comment '案件ID : =案件情報基本.ID',
	closing_kubun  int not null comment '締区分 : ※固定値：締区分',
	last_billing_amount  int not null comment '前回請求額',
	payment_amount  int not null comment '今回入金額',
	brought_forward_amount  int not null comment '繰越額',
	total_amount  int not null comment '今回売上額',
	tax_amount  int not null comment '消費税',
	total_amount_tax_included  decimal(18,0)  not null comment '売上合計',
	billing_amount  int not null comment '今回請求額',
	billing_closing_date  date not null comment '請求締日',
	first_balance_setting_flag  tinyint(1) default 0 not null comment '初回残高設定フラグ : 0：締め処理から作成、1：残高設定から作成',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='請求サマリー情報'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_billing_summaries`(id , m_contract_id , billing_no , m_supplier_id , t_project_base_id , closing_kubun , last_billing_amount , payment_amount , brought_forward_amount , total_amount , tax_amount , total_amount_tax_included , billing_amount , billing_closing_date , first_balance_setting_flag , created_user , updated_user , )
select old.id , old.m_contract_id , old.billing_no , old.m_supplier_id , old.t_project_base_id , old.closing_kubun , old.last_billing_amount , old.payment_amount , old.brought_forward_amount , old.total_amount , old.tax_amount , old.total_amount_tax_included , old.billing_amount , old.billing_closing_date , old.first_balance_setting_flag , old.created_user , old.updated_user ,  from ks_cloud.t_billing_summaries old
/

drop table ks_cloud.t_billing_summaries cascade/

alter table ks_cloud.`$$t_billing_summaries` rename to t_billing_summaries
/

alter table ks_cloud.t_billing_summaries  add constraint `PRIMARY` primary key (id)
/


