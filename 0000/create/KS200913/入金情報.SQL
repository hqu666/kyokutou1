create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_deposits` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	deposit_method  tinyint(1) not null comment '入金方法 : 0：個別、1：一括',
	deposit_type  tinyint(1) not null comment '入金種類 : 0：売上、1：前受金',
	deposit_code  int not null comment '入金No',
	deposit_date  date not null comment '入金日',
	m_supplier_id  int not null comment '得意先ID : =取引先マスタ.ID',
	m_own_company_staff_id  int not null comment '自社担当者ID : =自社担当者マスタ.ID',
	payment_sum  decimal(18,0)  not null comment '入金額合計',
	adjustment_amount_sum  decimal(18,0)  not null comment '調整額合計',
	total_payment_sum  decimal(18,0)  not null comment '入金総額',
	deposit_classification_1  tinyint(1) not null comment '入金1：区分 : ※固定値：入金区分',
	deposit_amount_1  decimal(18,0)  not null comment '入金1：入金額',
	transfer_commission_1  decimal(18,0)  not null comment '入金1：振込手数料',
	adjustment_amount_1  decimal(18,0)  not null comment '入金1：調整額',
	m_bank_id_1  int not null comment '入金1：取扱銀行ID',
	bill_deadline_1  date not null comment '入金1：手形期日',
	note_1  varchar(255)  not null comment '入金1：備考',
	total_payment_1  decimal(18,0)  not null comment '入金1：入金合計',
	deposit_classification_2  tinyint(1) not null comment '入金2：区分 : ※固定値：入金区分',
	deposit_amount_2  decimal(18,0)  not null comment '入金2：入金額',
	transfer_commission_2  decimal(18,0)  not null comment '入金2：振込手数料',
	adjustment_amount_2  decimal(18,0)  not null comment '入金2：調整額',
	m_bank_id_2  int not null comment '入金2：取扱銀行ID',
	bill_deadline_2  date not null comment '入金2：手形期日',
	note_2  varchar(255)  not null comment '入金2：備考',
	total_payment_2  decimal(18,0)  not null comment '入金2：入金合計',
	deposit_classification_3  tinyint(1) not null comment '入金3：区分 : ※固定値：入金区分',
	deposit_amount_3  decimal(18,0)  not null comment '入金3：入金額',
	transfer_commission_3  decimal(18,0)  not null comment '入金3：振込手数料',
	adjustment_amount_3  decimal(18,0)  not null comment '入金3：調整額',
	m_bank_id_3  int not null comment '入金3：取扱銀行ID',
	bill_deadline_3  date not null comment '入金3：手形期日',
	note_3  varchar(255)  not null comment '入金3：備考',
	total_payment_3  decimal(18,0)  not null comment '入金3：入金合計',
	billing_closing_target_date  date not null comment '請求締対象日',
	confirmed_date  date comment '確定日 : 確定処理が行われた日',
	lock_flag  tinyint(1)  default 0 not null comment 'ロックフラグ : 0：未ロック、1：ロック中',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='入金情報'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_deposits`(id , m_contract_id , deposit_method , deposit_type , deposit_code , deposit_date , m_supplier_id , m_own_company_staff_id , payment_sum , adjustment_amount_sum , total_payment_sum , deposit_classification_1 , deposit_amount_1 , transfer_commission_1 , adjustment_amount_1 , m_bank_id_1 , bill_deadline_1 , note_1 , total_payment_1 , deposit_classification_2 , deposit_amount_2 , transfer_commission_2 , adjustment_amount_2 , m_bank_id_2 , bill_deadline_2 , note_2 , total_payment_2 , deposit_classification_3 , deposit_amount_3 , transfer_commission_3 , adjustment_amount_3 , m_bank_id_3 , bill_deadline_3 , note_3 , total_payment_3 , billing_closing_target_date , confirmed_date , lock_flag , created_user , updated_user , )
select old.id , old.m_contract_id , old.deposit_method , old.deposit_type , old.deposit_code , old.deposit_date , old.m_supplier_id , old.m_own_company_staff_id , old.payment_sum , old.adjustment_amount_sum , old.total_payment_sum , old.deposit_classification_1 , old.deposit_amount_1 , old.transfer_commission_1 , old.adjustment_amount_1 , old.m_bank_id_1 , old.bill_deadline_1 , old.note_1 , old.total_payment_1 , old.deposit_classification_2 , old.deposit_amount_2 , old.transfer_commission_2 , old.adjustment_amount_2 , old.m_bank_id_2 , old.bill_deadline_2 , old.note_2 , old.total_payment_2 , old.deposit_classification_3 , old.deposit_amount_3 , old.transfer_commission_3 , old.adjustment_amount_3 , old.m_bank_id_3 , old.bill_deadline_3 , old.note_3 , old.total_payment_3 , old.billing_closing_target_date , old.confirmed_date , old.lock_flag , old.created_user , old.updated_user ,  from ks_cloud.t_deposits old
/

drop table ks_cloud.t_deposits cascade/

alter table ks_cloud.`$$t_deposits` rename to t_deposits
/

alter table ks_cloud.t_deposits  add constraint `PRIMARY` primary key (id)
/


