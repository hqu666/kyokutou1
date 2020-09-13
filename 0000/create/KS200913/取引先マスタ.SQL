create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_suppliers` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	supplier_cd  varchar(12)  not null comment '取引先コード',
	supplier_name  varchar(80)  not null comment '取引先名',
	supplier_kana  varchar(80)  comment '取引先カナ',
	supplier_ryaku  varchar(16)  comment '取引先略',
	customer_flag  tinyint(1) default 0 not null comment '取引先区分：得意先フラグ',
	supplier_flag  tinyint(1) default 0 not null comment '取引先区分：仕入先フラグ',
	supplier_type  tinyint(1) not null comment '取引先種別 : ※固定値：取引先種別',
	prospect_flag  tinyint(1) default 0 not null comment '見込み客フラグ',
	stop_flag  tinyint(1) default 0 not null comment '取引停止フラグ',
	postal_code  varchar(8)  comment '郵便番号',
	m_prefecture_id  tinyint(1) comment '都道府県 : =都道府県マスタ.ID',
	address_1  varchar(255)  comment '住所1',
	address_2  varchar(255)  comment '住所2',
	tell_number  varchar(16)  comment 'TEL',
	fax_number  varchar(16)  comment 'FAX',
	emergency_number  varchar(16)  comment '緊急連絡先',
	representative_name  varchar(40)  comment '代表者名',
	email  varchar(256)  comment 'Email',
	url_address  varchar(256)  comment 'URL',
	m_client_name_info  tinyint(1) comment '情報源 : =顧客関連名称マスタ.ID',
	m_client_name_lank  tinyint(1) comment '取引先ランク : =顧客関連名称マスタ.ID',
	m_client_name_id1  tinyint(1) comment '顧客属性項目1 : =顧客関連名称マスタ.ID',
	m_client_name_id2  tinyint(1) comment '顧客属性項目2 : =顧客関連名称マスタ.ID',
	m_client_name_id3  tinyint(1) comment '顧客属性項目3 : =顧客関連名称マスタ.ID',
	m_client_name_id4  tinyint(1) comment '顧客属性項目4 : =顧客関連名称マスタ.ID',
	m_client_name_id5  tinyint(1) comment '顧客属性項目5 : =顧客関連名称マスタ.ID',
	memo  varchar(4000)  comment 'メモ',
	search_tel  varchar(256)  comment '検索用電話番号 : TEL+FAX+緊急連絡先',
	search_address  varchar(256)  comment '検索用住所 : 都道府県名＋住所1＋住所2',
	c_unit_price_determination  tinyint(1) comment '得意先：単価決定区分 : ※固定値：単価決定区分     c_：Customer',
	c_standard_sales_rate  decimal(5,2)  comment '得意先：標準販売掛率',
	c_last_confirmed_date  date comment '得意先：最終確定日 : 7/31 不要のため削除',
	c_closing_date1  tinyint(1) comment '得意先：請求条件1：締日 : ※固定値：締日',
	c_payment_month1  tinyint(1) comment '得意先：請求条件1：支払月 : ※固定値：支払月',
	c_payment_day1  tinyint(1) comment '得意先：請求条件1：支払日 : ※固定値：支払日',
	c_closing_date2  tinyint(1) comment '得意先：請求条件2：締日 : ※固定値：締日',
	c_payment_month2  tinyint(1) comment '得意先：請求条件2：支払月 : ※固定値：支払月',
	c_payment_day2  tinyint(1) comment '得意先：請求条件2：支払日 : ※固定値：支払日',
	c_closing_date3  tinyint(1) comment '得意先：請求条件3：締日 : ※固定値：締日',
	c_payment_month3  tinyint(1) comment '得意先：請求条件3：支払月 : ※固定値：支払月',
	c_payment_day3  tinyint(1) comment '得意先：請求条件3：支払日 : ※固定値：支払日',
	c_credit_limit  int comment '得意先：与信限度額',
	c_m_own_company_staff_id  int comment '得意先：自社担当者ID : =取引先部門担当者マスタ.ID',
	c_m_system_name_id  int comment '得意先：取引条件ID : =システム関連名称マスタ.ID',
	c_Invoice_flag  tinyint(1) comment '得意先：請求書発行フラグ',
	c_tax_classification  tinyint(1) comment '得意先：課税区分 : ※固定値：課税区分',
	c_taxable_unit  tinyint(1) comment '得意先：課税単位 : ※固定値：課税単位',
	c_tax_fraction_processing  tinyint(1) comment '得意先：税端数処理 : ※固定値：税端数処理',
	c_rounding_fractional  tinyint(1) comment '得意先：金額端数丸め : ※固定値：金額端数丸め',
	c_fractional_processing  tinyint(1) comment '得意先：金額端数処理 : ※固定値：金額端数処理',
	c_m_category_name_id1  tinyint(1) comment '得意先：伝票ヘッダ集計区分1 : =集計区分名称マスタ.ID',
	c_m_category_name_id2  tinyint(1) comment '得意先：伝票ヘッダ集計区分2 : =集計区分名称マスタ.ID',
	c_m_category_name_id3  tinyint(1) comment '得意先：伝票ヘッダ集計区分3 : =集計区分名称マスタ.ID',
	c_m_category_name_id4  tinyint(1) comment '得意先：伝票ヘッダ集計区分4 : =集計区分名称マスタ.ID',
	c_memo  varchar(4000)  comment '得意先：メモ',
	s_unit_price_determination  tinyint(1) comment '仕入先：単価決定区分 : ※固定値：単価決定区分     s_：Supplier',
	s_standard_purchase_rate  comment '仕入先：標準仕入掛率',
	s_last_confirmed_date  date comment '仕入先：最終確定日 : 7/31 不要のため削除',
	s_closing_date  tinyint(1) comment '仕入先：支払条件：締日 : ※固定値：締日',
	s_payment_month  tinyint(1) comment '仕入先：支払条件：支払月 : ※固定値：支払月',
	s_payment_day  tinyint(1) comment '仕入先：支払条件：支払日 : ※固定値：支払日',
	s_credit_limit  int comment '仕入先：与信限度額',
	s_m_own_company_staff_id  int comment '仕入先：自社担当者ID : =取引先部門担当者マスタ.ID',
	s_purchase_category  tinyint(1) comment '仕入先：仕入区分 : ※固定値：仕入区分',
	s_payment_flag  tinyint(1) comment '仕入先：支払書発行フラグ',
	s_tax_classification  tinyint(1) comment '仕入先：課税区分 : ※固定値：課税区分',
	s_taxable_unit  tinyint(1) comment '仕入先：課税単位 : ※固定値：課税単位',
	s_tax_fraction_processing  tinyint(1) comment '仕入先：税端数処理 : ※固定値：税端数処理',
	s_fractional_processing  tinyint(1) comment '仕入先：金額端数処理 : ※固定値：金額端数処理',
	s_memo  varchar(4000)  comment '仕入先：メモ',
	last_billing_closing_date  date comment '前回請求締日',
	last_payment_closing_date  date comment '前回支払締日',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='取引先マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_suppliers`(id , m_contract_id , supplier_cd , supplier_name , supplier_kana , supplier_ryaku , customer_flag , supplier_flag , supplier_type , prospect_flag , stop_flag , postal_code , m_prefecture_id , address_1 , address_2 , tell_number , fax_number , emergency_number , representative_name , email , url_address , m_client_name_info , m_client_name_lank , m_client_name_id1 , m_client_name_id2 , m_client_name_id3 , m_client_name_id4 , m_client_name_id5 , memo , search_tel , search_address , c_unit_price_determination , c_standard_sales_rate , c_last_confirmed_date , c_closing_date1 , c_payment_month1 , c_payment_day1 , c_closing_date2 , c_payment_month2 , c_payment_day2 , c_closing_date3 , c_payment_month3 , c_payment_day3 , c_credit_limit , c_m_own_company_staff_id , c_m_system_name_id , c_Invoice_flag , c_tax_classification , c_taxable_unit , c_tax_fraction_processing , c_rounding_fractional , c_fractional_processing , c_m_category_name_id1 , c_m_category_name_id2 , c_m_category_name_id3 , c_m_category_name_id4 , c_memo , s_unit_price_determination , s_standard_purchase_rate , s_last_confirmed_date , s_closing_date , s_payment_month , s_payment_day , s_credit_limit , s_m_own_company_staff_id , s_purchase_category , s_payment_flag , s_tax_classification , s_taxable_unit , s_tax_fraction_processing , s_fractional_processing , s_memo , last_billing_closing_date , last_payment_closing_date , created_user , updated_user , )
select old.id , old.m_contract_id , old.supplier_cd , old.supplier_name , old.supplier_kana , old.supplier_ryaku , old.customer_flag , old.supplier_flag , old.supplier_type , old.prospect_flag , old.stop_flag , old.postal_code , old.m_prefecture_id , old.address_1 , old.address_2 , old.tell_number , old.fax_number , old.emergency_number , old.representative_name , old.email , old.url_address , old.m_client_name_info , old.m_client_name_lank , old.m_client_name_id1 , old.m_client_name_id2 , old.m_client_name_id3 , old.m_client_name_id4 , old.m_client_name_id5 , old.memo , old.search_tel , old.search_address , old.c_unit_price_determination , old.c_standard_sales_rate , old.c_last_confirmed_date , old.c_closing_date1 , old.c_payment_month1 , old.c_payment_day1 , old.c_closing_date2 , old.c_payment_month2 , old.c_payment_day2 , old.c_closing_date3 , old.c_payment_month3 , old.c_payment_day3 , old.c_credit_limit , old.c_m_own_company_staff_id , old.c_m_system_name_id , old.c_Invoice_flag , old.c_tax_classification , old.c_taxable_unit , old.c_tax_fraction_processing , old.c_rounding_fractional , old.c_fractional_processing , old.c_m_category_name_id1 , old.c_m_category_name_id2 , old.c_m_category_name_id3 , old.c_m_category_name_id4 , old.c_memo , old.s_unit_price_determination , old.s_standard_purchase_rate , old.s_last_confirmed_date , old.s_closing_date , old.s_payment_month , old.s_payment_day , old.s_credit_limit , old.s_m_own_company_staff_id , old.s_purchase_category , old.s_payment_flag , old.s_tax_classification , old.s_taxable_unit , old.s_tax_fraction_processing , old.s_fractional_processing , old.s_memo , old.last_billing_closing_date , old.last_payment_closing_date , old.created_user , old.updated_user ,  from ks_cloud.m_suppliers old
/

drop table ks_cloud.m_suppliers cascade/

alter table ks_cloud.`$$m_suppliers` rename to m_suppliers
/

alter table ks_cloud.m_suppliers  add constraint `PRIMARY` primary key (id)
/


