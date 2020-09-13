create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_payment_lumps` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	withdrawal_no  int not null comment '出金No',
	withdrawal_date  date not null comment '出金日',
	m_suppliers_id  int not null comment '仕入先ID : =取引先マスタ.ID',
	m_own_company_staff_id  int not null comment '自社担当者ID : =自社担当者マスタ.ID',
	withdrawal_amount_sum  int not null comment '出金額合計',
	adjustment_amount_sum  decimal(18,0)  not null comment '調整額合計',
	withdrawal_total_amount  int not null comment '出金総額',
	kubun_1  tinyint(1) not null comment '出金1：区分 : ※固定値：出金区分',
	withdrawal_amount_1  int not null comment '出金1：出金額',
	transfer_fee_1  int not null comment '出金1：振込手数料',
	adjustment_amount_1  int not null comment '出金1：調整額',
	handling_bank_id1  int not null comment '出金1：取扱銀行ID',
	bill_deadline_1  date not null comment '出金1：手形期日',
	recital_1  varchar(255) not null comment '出金1：備考',
	withdrawal_total_1  int not null comment '出金1：出金合計',
	kubun_2  tinyint(1) not null comment '出金2：区分 : ※固定値：出金区分',
	withdrawal_amount_2  int not null comment '出金2：出金額',
	transfer_fee_2  int not null comment '出金2：振込手数料',
	adjustment_amount_2  int not null comment '出金2：調整額',
	handling_bank_id2  int not null comment '出金2：取扱銀行ID',
	bill_deadline_2  date not null comment '出金2：手形期日',
	recital_2  varchar(255) not null comment '出金2：備考',
	withdrawal_total_2  int not null comment '出金2：出金合計',
	kubun_3  tinyint(1) not null comment '出金3：区分 : ※固定値：出金区分',
	withdrawal_amount_3  int not null comment '出金3：出金額',
	transfer_fee_3  int not null comment '出金3：振込手数料',
	adjustment_amount_3  int not null comment '出金3：調整額',
	handling_bank_id3  int not null comment '出金3：取扱銀行ID',
	bill_deadline_3  date not null comment '出金3：手形期日',
	recital_3  varchar(255) not null comment '出金3：備考',
	withdrawal_total_3  int not null comment '出金3：出金合計',
	payment_closing_target_date  date not null comment '支払締対象日',
	confirmed_date  date comment '確定日 : 確定処理が行われた日',
	lock_flag  tinyint(1)  default 0 not null comment 'ロックフラグ : 0：未ロック、1：ロック中',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='出金情報'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_payment_lumps`(id , m_contract_id , withdrawal_no , withdrawal_date , m_suppliers_id , m_own_company_staff_id , withdrawal_amount_sum , adjustment_amount_sum , withdrawal_total_amount , kubun_1 , withdrawal_amount_1 , transfer_fee_1 , adjustment_amount_1 , handling_bank_id1 , bill_deadline_1 , recital_1 , withdrawal_total_1 , kubun_2 , withdrawal_amount_2 , transfer_fee_2 , adjustment_amount_2 , handling_bank_id2 , bill_deadline_2 , recital_2 , withdrawal_total_2 , kubun_3 , withdrawal_amount_3 , transfer_fee_3 , adjustment_amount_3 , handling_bank_id3 , bill_deadline_3 , recital_3 , withdrawal_total_3 , payment_closing_target_date , confirmed_date , lock_flag , created_user , updated_user , )
select old.id , old.m_contract_id , old.withdrawal_no , old.withdrawal_date , old.m_suppliers_id , old.m_own_company_staff_id , old.withdrawal_amount_sum , old.adjustment_amount_sum , old.withdrawal_total_amount , old.kubun_1 , old.withdrawal_amount_1 , old.transfer_fee_1 , old.adjustment_amount_1 , old.handling_bank_id1 , old.bill_deadline_1 , old.recital_1 , old.withdrawal_total_1 , old.kubun_2 , old.withdrawal_amount_2 , old.transfer_fee_2 , old.adjustment_amount_2 , old.handling_bank_id2 , old.bill_deadline_2 , old.recital_2 , old.withdrawal_total_2 , old.kubun_3 , old.withdrawal_amount_3 , old.transfer_fee_3 , old.adjustment_amount_3 , old.handling_bank_id3 , old.bill_deadline_3 , old.recital_3 , old.withdrawal_total_3 , old.payment_closing_target_date , old.confirmed_date , old.lock_flag , old.created_user , old.updated_user ,  from ks_cloud.t_payment_lumps old
/

drop table ks_cloud.t_payment_lumps cascade/

alter table ks_cloud.`$$t_payment_lumps` rename to t_payment_lumps
/

alter table ks_cloud.t_payment_lumps  add constraint `PRIMARY` primary key (id)
/


