create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_lengths` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	cr_effective_width  int not null comment 'クロス　有効巾(cm) : cr=Cross',
	cr_buy_unit  int not null comment 'クロス　購入単位(cm)',
	cr_repeat  int not null comment 'クロス　リピート(cm)',
	cr_cutting_allowance  int not null comment 'クロス　切り代(cm)',
	cr_sale_type  tinyint(1) not null comment 'クロス　販売',
	cr_sale_unit  tinyint(1) not null comment 'クロス　販売(単位)',
	cr_purchase_type  tinyint(1) not null comment 'クロス　仕入',
	cr_purchase_unit  tinyint(1) not null comment 'クロス　仕入（単位）',
	cr_construction_type  tinyint(1) not null comment 'クロス　施工',
	cr_construction_unit  tinyint(1) not null comment 'クロス　施工（単位）',
	bb_effective_width  int not null comment '巾木　有効巾(cm) : bb=Baseboard',
	bb_cutting_allowance  int not null comment '巾木　切り代(cm)',
	bb_case_quantity  int not null comment '巾木　ケース入り数(枚/ケース)',
	bb_sale_type  tinyint(1) not null comment '巾木　販売',
	bb_sale_unit  tinyint(1) not null comment '巾木　販売（単位）',
	bb_purchase_type  tinyint(1) not null comment '巾木　仕入',
	bb_purchase_unit  tinyint(1) not null comment '巾木　仕入（単位）',
	bb_construction_type  tinyint(1) not null comment '巾木　施工',
	bb_construction_unit  tinyint(1) not null comment '巾木　施工（単位）',
	pt_width  int not null comment 'Pタイル　巾(mm) : pt= P tile',
	pt_length  int not null comment 'Pタイル　長さ(mm)',
	pt_min_cut_width  int not null comment 'Pタイル　最小カット巾(mm)',
	pt_case_quantity  int not null comment 'Pタイル　ケース入り数',
	pt_deemed_quantity  int not null comment 'Pタイル　㎡当みなし枚数',
	pt_sale_type  tinyint(1) not null comment 'Pタイル　販売',
	pt_sale_unit  tinyint(1) not null comment 'Pタイル　販売（単位）',
	pt_purchase_type  tinyint(1) not null comment 'Pタイル　仕入',
	pt_purchase_unit  tinyint(1) not null comment 'Pタイル　仕入（単位）',
	pt_construction_type  tinyint(1) not null comment 'Pタイル　施工',
	pt_construction_unit  tinyint(1) not null comment 'Pタイル　施工（単位） : tc=Tile carpet',
	tc_width  int not null comment 'タイルカーペット　巾(mm)',
	tc_length  int not null comment 'タイルカーペット　長さ(mm)',
	tc_min_cut_width  int not null comment 'タイルカーペット　最小カット巾(mm)',
	tc_case_quantity  int not null comment 'タイルカーペット　ケース入り数',
	tc_deemed_quantity  int not null comment 'タイルカーペット　㎡当みなし枚数',
	tc_sale_type  tinyint(1) not null comment 'タイルカーペット　販売',
	tc_sale_unit  tinyint(1) not null comment 'タイルカーペット　販売（単位）',
	tc_purchase_type  tinyint(1) not null comment 'タイルカーペット　仕入',
	tc_purchase_unit  tinyint(1) not null comment 'タイルカーペット　仕入（単位）',
	tc_construction_type  tinyint(1) not null comment 'タイルカーペット　施工',
	tc_construction_unit  tinyint(1) not null comment 'タイルカーペット　施工（単位）',
	cf_effective_width  int not null comment 'クッションフロア　有効巾(cm) : cf=Cushion floor',
	cf_buy_unit  int not null comment 'クッションフロア　購入単位(cm)',
	cf_repeat  int not null comment 'クッションフロア　リピート(cm)',
	cf_cutting_allowance  int not null comment 'クッションフロア　切り代(cm)',
	cf_sale_type  tinyint(1) not null comment 'クッションフロア　販売',
	cf_sale_unit  tinyint(1) not null comment 'クッションフロア　販売（単位）',
	cf_purchase_type  tinyint(1) not null comment 'クッションフロア　仕入',
	cf_purchase_unit  tinyint(1) not null comment 'クッションフロア　仕入（単位）',
	cf_construction_type  tinyint(1) not null comment 'クッションフロア　施工',
	cf_construction_unit  tinyint(1) not null comment 'クッションフロア　施工（単位）',
	ca_sale_type  tinyint(1) not null comment 'カーペット　販売 : ca=carpet',
	ca_sale_unit  tinyint(1) not null comment 'カーペット　販売（単位）',
	ca_purchase_type  tinyint(1) not null comment 'カーペット　仕入',
	ca_purchase_unit  tinyint(1) not null comment 'カーペット　仕入（単位）',
	ca_construction_type  tinyint(1) not null comment 'カーペット　施工',
	ca_construction_unit  tinyint(1) not null comment 'カーペット　施工（単位）',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)),idx2(m_contract_id (1)))
	comment='要尺マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_lengths`(id , m_contract_id , cr_effective_width , cr_buy_unit , cr_repeat , cr_cutting_allowance , cr_sale_type , cr_sale_unit , cr_purchase_type , cr_purchase_unit , cr_construction_type , cr_construction_unit , bb_effective_width , bb_cutting_allowance , bb_case_quantity , bb_sale_type , bb_sale_unit , bb_purchase_type , bb_purchase_unit , bb_construction_type , bb_construction_unit , pt_width , pt_length , pt_min_cut_width , pt_case_quantity , pt_deemed_quantity , pt_sale_type , pt_sale_unit , pt_purchase_type , pt_purchase_unit , pt_construction_type , pt_construction_unit , tc_width , tc_length , tc_min_cut_width , tc_case_quantity , tc_deemed_quantity , tc_sale_type , tc_sale_unit , tc_purchase_type , tc_purchase_unit , tc_construction_type , tc_construction_unit , cf_effective_width , cf_buy_unit , cf_repeat , cf_cutting_allowance , cf_sale_type , cf_sale_unit , cf_purchase_type , cf_purchase_unit , cf_construction_type , cf_construction_unit , ca_sale_type , ca_sale_unit , ca_purchase_type , ca_purchase_unit , ca_construction_type , ca_construction_unit , created_user , updated_user , )
select old.id , old.m_contract_id , old.cr_effective_width , old.cr_buy_unit , old.cr_repeat , old.cr_cutting_allowance , old.cr_sale_type , old.cr_sale_unit , old.cr_purchase_type , old.cr_purchase_unit , old.cr_construction_type , old.cr_construction_unit , old.bb_effective_width , old.bb_cutting_allowance , old.bb_case_quantity , old.bb_sale_type , old.bb_sale_unit , old.bb_purchase_type , old.bb_purchase_unit , old.bb_construction_type , old.bb_construction_unit , old.pt_width , old.pt_length , old.pt_min_cut_width , old.pt_case_quantity , old.pt_deemed_quantity , old.pt_sale_type , old.pt_sale_unit , old.pt_purchase_type , old.pt_purchase_unit , old.pt_construction_type , old.pt_construction_unit , old.tc_width , old.tc_length , old.tc_min_cut_width , old.tc_case_quantity , old.tc_deemed_quantity , old.tc_sale_type , old.tc_sale_unit , old.tc_purchase_type , old.tc_purchase_unit , old.tc_construction_type , old.tc_construction_unit , old.cf_effective_width , old.cf_buy_unit , old.cf_repeat , old.cf_cutting_allowance , old.cf_sale_type , old.cf_sale_unit , old.cf_purchase_type , old.cf_purchase_unit , old.cf_construction_type , old.cf_construction_unit , old.ca_sale_type , old.ca_sale_unit , old.ca_purchase_type , old.ca_purchase_unit , old.ca_construction_type , old.ca_construction_unit , old.created_user , old.updated_user ,  from ks_cloud.m_lengths old
/

drop table ks_cloud.m_lengths cascade/

alter table ks_cloud.`$$m_lengths` rename to m_lengths
/

alter table ks_cloud.m_lengths  add constraint `PRIMARY` primary key (id)
/


