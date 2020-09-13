create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_own_companies` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	company_name_1  varchar(50)  not null comment '社名正式名1',
	company_name_2  varchar(50)  comment '社名正式名2',
	company_short_name  varchar(50)  not null comment '社名省略名',
	postal_code  varchar(8)  not null comment '郵便番号',
	m_prefecture_id  tinyint(1) not null comment '都道府県 : =都道府県マスタ.ID',
	address_1  varchar(255)  not null comment '住所1',
	address_2  varchar(255)  comment '住所2',
	representative_name  varchar(40)  comment '代表者名',
	tell_number  varchar(16)  not null comment 'TEL',
	fax_number  varchar(16)  comment 'FAX',
	bank_1  varchar(50)  not null comment '取引銀行1 : 2020/07/31 削除→振込先マスタへ',
	deposit_type_1  int(1)  not null comment '預金種別１',
	transfer_account_1  varchar(20)  not null comment '振込口座1',
	nominee_1  varchar(30)  not null comment '名義人1',
	bank_2  varchar(50)  comment '取引銀行2',
	deposit_type_2  int(1)  not null comment '預金種別2',
	transfer_account_2  varchar(20)  comment '振込口座2',
	nominee_2  varchar(30)  comment '名義人2',
	bank_3  varchar(50)  comment '取引銀行3',
	deposit_type_3  int(1)  not null comment '預金種別3',
	transfer_account_3  varchar(20)  comment '振込口座3',
	nominee_3  varchar(30)  comment '名義人3',
	email  varchar(256)  comment 'Email',
	url_address  varchar(256)  comment 'URL',
	receivable_cclosing_month  tinyint(1) comment '決算月',
	closing_date  date comment '締日 : ※固定値：締日',
	payment_month  tinyint(1) comment '支払月 : ※固定値：支払月',
	payment_day  tinyint(1) comment '支払日 : ※固定値：支払日',
	sales_gross_profit_rate  decimal(5,2)  comment '標準販売粗利率',
	trading_condition  varchar(50) ○ not null comment '取引条件',
	tax_classification  tinyint(1) comment '課税区分 : ※固定値：課税区分',
	taxable_unit  tinyint(1) comment '課税単位 : ※固定値：課税単位',
	tax_fraction_processing  tinyint(1) comment '税端数処理 : ※固定値：税端数処理',
	rounding_fractional  tinyint(1) comment '金額端数丸め : ※固定値：金額端数丸め',
	fractional_processing  tinyint(1) comment '金額端数処理 : ※固定値：金額端数処理',
	operation_date_start  date comment '運用開始日',
	registration_number  varchar(20)  comment '登録番号',
	logo_image  varchar(256)  comment 'ロゴイメージ',
	last_application_time  datetime comment 'Googleカレンダー最終反映日時',
	average_labor_cost_amount  decimal(5,2)  comment '平均労務費額',
	average_productivity_rate  decimal(5,2)  comment '平均歩掛率',
	social_insurance_charge_rate  decimal(5,2)  comment '社会保険料率',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='自社情報マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_own_companies`(id , m_contract_id , company_name_1 , company_name_2 , company_short_name , postal_code , m_prefecture_id , address_1 , address_2 , representative_name , tell_number , fax_number , bank_1 , deposit_type_1 , transfer_account_1 , nominee_1 , bank_2 , deposit_type_2 , transfer_account_2 , nominee_2 , bank_3 , deposit_type_3 , transfer_account_3 , nominee_3 , email , url_address , receivable_cclosing_month , closing_date , payment_month , payment_day , sales_gross_profit_rate , trading_condition , tax_classification , taxable_unit , tax_fraction_processing , rounding_fractional , fractional_processing , operation_date_start , registration_number , logo_image , last_application_time , average_labor_cost_amount , average_productivity_rate , social_insurance_charge_rate , created_user , updated_user , )
select old.id , old.m_contract_id , old.company_name_1 , old.company_name_2 , old.company_short_name , old.postal_code , old.m_prefecture_id , old.address_1 , old.address_2 , old.representative_name , old.tell_number , old.fax_number , old.bank_1 , old.deposit_type_1 , old.transfer_account_1 , old.nominee_1 , old.bank_2 , old.deposit_type_2 , old.transfer_account_2 , old.nominee_2 , old.bank_3 , old.deposit_type_3 , old.transfer_account_3 , old.nominee_3 , old.email , old.url_address , old.receivable_cclosing_month , old.closing_date , old.payment_month , old.payment_day , old.sales_gross_profit_rate , old.trading_condition , old.tax_classification , old.taxable_unit , old.tax_fraction_processing , old.rounding_fractional , old.fractional_processing , old.operation_date_start , old.registration_number , old.logo_image , old.last_application_time , old.average_labor_cost_amount , old.average_productivity_rate , old.social_insurance_charge_rate , old.created_user , old.updated_user ,  from ks_cloud.m_own_companies old
/

drop table ks_cloud.m_own_companies cascade/

alter table ks_cloud.`$$m_own_companies` rename to m_own_companies
/

alter table ks_cloud.m_own_companies  add constraint `PRIMARY` primary key (id)
/


