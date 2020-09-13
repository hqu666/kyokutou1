create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_budget_suppliers` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñƒ}ƒXƒ^.ID',
	m_supplier_id  int not null comment 'æˆøæID : =æˆøæƒ}ƒXƒ^.ID',
	target_year  int not null comment '‘ÎÛ”N“x',
	buget_month_1  tinyint(1) not null comment 'NŒ',
	buget_month_2  tinyint(1) not null comment 'N{1Œ',
	buget_month_3  tinyint(1) not null comment 'N{2Œ',
	buget_month_4  tinyint(1) not null comment 'N{3Œ',
	buget_month_5  tinyint(1) not null comment 'N{4Œ',
	buget_month_6  tinyint(1) not null comment 'N{5Œ',
	buget_month_7  tinyint(1) not null comment 'N{6Œ',
	buget_month_8  tinyint(1) not null comment 'N{7Œ',
	buget_month_9  tinyint(1) not null comment 'N{8Œ',
	buget_month_10  tinyint(1) not null comment 'N{9Œ',
	buget_month_11  tinyint(1) not null comment 'N{10Œ',
	buget_month_12  tinyint(1) not null comment 'N{11Œ',
	buget_amount_1  int not null comment 'NŒ@–Ú•W—\ZŠz',
	buget_amount_2  int not null comment 'N{1Œ@–Ú•W—\ZŠz',
	buget_amount_3  int not null comment 'N{2Œ@–Ú•W—\ZŠz',
	buget_amount_4  int not null comment 'N{3Œ@–Ú•W—\ZŠz',
	buget_amount_5  int not null comment 'N{4Œ@–Ú•W—\ZŠz',
	buget_amount_6  int not null comment 'N{5Œ@–Ú•W—\ZŠz',
	buget_amount_7  int not null comment 'N{6Œ@–Ú•W—\ZŠz',
	buget_amount_8  int not null comment 'N{7Œ@–Ú•W—\ZŠz',
	buget_amount_9  int not null comment 'N{8Œ@–Ú•W—\ZŠz',
	buget_amount_10  int not null comment 'N{9Œ@–Ú•W—\ZŠz',
	buget_amount_11  int not null comment 'N{10Œ@–Ú•W—\ZŠz',
	buget_amount_12  int not null comment 'N{11Œ@–Ú•W—\ZŠz',
	gross_profit_amount_1  int not null comment 'NŒ@–Ú•W‘e—˜Šz',
	gross_profit_amount_2  int not null comment 'N{1Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_3  int not null comment 'N{2Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_4  int not null comment 'N{3Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_5  int not null comment 'N{4Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_6  int not null comment 'N{5Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_7  int not null comment 'N{6Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_8  int not null comment 'N{7Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_9  int not null comment 'N{8Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_10  int not null comment 'N{9Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_11  int not null comment 'N{10Œ@–Ú•W‘e—˜Šz',
	gross_profit_amount_12  int not null comment 'N{11Œ@–Ú•W‘e—˜Šz',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)),idx2(m_contract_id (1),m_supplier_id (2),target_year (3)))
	comment='“¾ˆÓæ•Ê—\Zƒ}ƒXƒ^'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_budget_suppliers`(id , m_contract_id , m_supplier_id , target_year , buget_month_1 , buget_month_2 , buget_month_3 , buget_month_4 , buget_month_5 , buget_month_6 , buget_month_7 , buget_month_8 , buget_month_9 , buget_month_10 , buget_month_11 , buget_month_12 , buget_amount_1 , buget_amount_2 , buget_amount_3 , buget_amount_4 , buget_amount_5 , buget_amount_6 , buget_amount_7 , buget_amount_8 , buget_amount_9 , buget_amount_10 , buget_amount_11 , buget_amount_12 , gross_profit_amount_1 , gross_profit_amount_2 , gross_profit_amount_3 , gross_profit_amount_4 , gross_profit_amount_5 , gross_profit_amount_6 , gross_profit_amount_7 , gross_profit_amount_8 , gross_profit_amount_9 , gross_profit_amount_10 , gross_profit_amount_11 , gross_profit_amount_12 , created_user , updated_user , )
select old.id , old.m_contract_id , old.m_supplier_id , old.target_year , old.buget_month_1 , old.buget_month_2 , old.buget_month_3 , old.buget_month_4 , old.buget_month_5 , old.buget_month_6 , old.buget_month_7 , old.buget_month_8 , old.buget_month_9 , old.buget_month_10 , old.buget_month_11 , old.buget_month_12 , old.buget_amount_1 , old.buget_amount_2 , old.buget_amount_3 , old.buget_amount_4 , old.buget_amount_5 , old.buget_amount_6 , old.buget_amount_7 , old.buget_amount_8 , old.buget_amount_9 , old.buget_amount_10 , old.buget_amount_11 , old.buget_amount_12 , old.gross_profit_amount_1 , old.gross_profit_amount_2 , old.gross_profit_amount_3 , old.gross_profit_amount_4 , old.gross_profit_amount_5 , old.gross_profit_amount_6 , old.gross_profit_amount_7 , old.gross_profit_amount_8 , old.gross_profit_amount_9 , old.gross_profit_amount_10 , old.gross_profit_amount_11 , old.gross_profit_amount_12 , old.created_user , old.updated_user ,  from ks_cloud.m_budget_suppliers old
/

drop table ks_cloud.m_budget_suppliers cascade/

alter table ks_cloud.`$$m_budget_suppliers` rename to m_budget_suppliers
/

alter table ks_cloud.m_budget_suppliers  add constraint `PRIMARY` primary key (id)
/


