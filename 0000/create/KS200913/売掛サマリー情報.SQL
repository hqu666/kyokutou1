create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_accounts_receivable_summaries` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	m_supplier_id  int not null comment '得意先ID : =取引先マスタ.ID',
	closing_kubun  int not null comment '締区分 : ※固定値：締区分　2020/07/28 削除',
	last_accounts_receivable_amount  int not null comment '前回売掛額 : 2020/08/25 削除',
	current_month_payment_amount  int not null comment '今月入金額',
	current_month_adjustment_amount  int not null comment '今月調整額',
	current_month_brought_forward_amount  int not null comment '今月繰越額 : 2020/08/25 削除',
	current_month_sales_amount  int not null comment '今月売上額',
	current_month_discount_amount  int not null comment '今月値引額 : 2020/08/25 削除',
	current_month_tax  int not null comment '今月消費税',
	currenct_accounts_receivable_amount  int not null comment '今回売掛額',
	currenct_closing_date  date not null comment '今回締日',
	first_balance_setting_flag  tinyint(1) default 0 not null comment '初回残高設定フラグ : 0：締め処理から作成、1：残高設定から作成',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='売掛サマリー情報'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_accounts_receivable_summaries`(id , m_contract_id , m_supplier_id , closing_kubun , last_accounts_receivable_amount , current_month_payment_amount , current_month_adjustment_amount , current_month_brought_forward_amount , current_month_sales_amount , current_month_discount_amount , current_month_tax , currenct_accounts_receivable_amount , currenct_closing_date , first_balance_setting_flag , created_user , updated_user , )
select old.id , old.m_contract_id , old.m_supplier_id , old.closing_kubun , old.last_accounts_receivable_amount , old.current_month_payment_amount , old.current_month_adjustment_amount , old.current_month_brought_forward_amount , old.current_month_sales_amount , old.current_month_discount_amount , old.current_month_tax , old.currenct_accounts_receivable_amount , old.currenct_closing_date , old.first_balance_setting_flag , old.created_user , old.updated_user ,  from ks_cloud.t_accounts_receivable_summaries old
/

drop table ks_cloud.t_accounts_receivable_summaries cascade/

alter table ks_cloud.`$$t_accounts_receivable_summaries` rename to t_accounts_receivable_summaries
/

alter table ks_cloud.t_accounts_receivable_summaries  add constraint `PRIMARY` primary key (id)
/


