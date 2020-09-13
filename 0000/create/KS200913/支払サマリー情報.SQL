create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_payment_summaries` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	payment_no  not null comment '支払No',
	m_suppliers_id  int not null comment '仕入先ID : =取引先マスタ.ID',
	t_purchase_base_id  int○ not null comment '購買情報基本ID : =購買情報基本.ID',
	closing_kubun  int not null comment '締区分 : ※固定値：締区分',
	last_payment_amount  int not null comment '前回支払額',
	currenct_withdrawal_amount  int not null comment '今回出金額',
	brought_forward_amount  int not null comment '繰越額',
	currenct_stocking_amount  int not null comment '今回仕入額',
	tax_amount  int not null comment '消費税',
	purchase_sum  int not null comment '仕入合計',
	currenct_payment_amount  int not null comment '今回支払額',
	payment_closing_date  date not null comment '支払締日',
	first_balance_setting_flag  tinyint(1) default 0 not null comment '初回残高設定フラグ : 0：締め処理から作成、1：残高設定から作成',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='支払サマリー情報'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_payment_summaries`(id , m_contract_id , payment_no , m_suppliers_id , t_purchase_base_id , closing_kubun , last_payment_amount , currenct_withdrawal_amount , brought_forward_amount , currenct_stocking_amount , tax_amount , purchase_sum , currenct_payment_amount , payment_closing_date , first_balance_setting_flag , created_user , updated_user , )
select old.id , old.m_contract_id , old.payment_no , old.m_suppliers_id , old.t_purchase_base_id , old.closing_kubun , old.last_payment_amount , old.currenct_withdrawal_amount , old.brought_forward_amount , old.currenct_stocking_amount , old.tax_amount , old.purchase_sum , old.currenct_payment_amount , old.payment_closing_date , old.first_balance_setting_flag , old.created_user , old.updated_user ,  from ks_cloud.t_payment_summaries old
/

drop table ks_cloud.t_payment_summaries cascade/

alter table ks_cloud.`$$t_payment_summaries` rename to t_payment_summaries
/

alter table ks_cloud.t_payment_summaries  add constraint `PRIMARY` primary key (id)
/


