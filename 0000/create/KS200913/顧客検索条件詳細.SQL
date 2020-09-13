create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_customer_condition_details` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment 'Œ_–ñID : =Œ_–ñî•ñ.ID',
	search_criteria_base_id  int not null comment 'ŒÚ‹qŒŸõğŒŠî–{ID',
	condition_number  not null comment 'ğŒ”Ô†',
	conjunction  varchar(3)  not null comment 'And/Or',
	previous_parenthesis  not null comment '‘O‚©‚Á‚±',
	item  not null comment '€–Ú',
	comparing_value_3  not null comment '”äŠr‚·‚éğŒ',
	comparing_value_1  not null comment '”äŠr‚·‚é’l‚P',
	comparing_value_2  not null comment '”äŠr‚·‚é’l‚Q',
	after_parenthesis  not null comment 'Œã‚©‚Á‚±',
	created_user  int comment 'ì¬Ò',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment 'ì¬“ú',
	updated_user  int comment 'XVÒ',
	updated_at datetime comment 'XV“ú',
	deleted_at datetime comment 'íœ“ú',
	index idx1(m_contract_id (1)))
	comment='ŒÚ‹qŒŸõğŒÚ×'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_customer_condition_details`(id , m_contract_id , search_criteria_base_id , condition_number , conjunction , previous_parenthesis , item , comparing_value_3 , comparing_value_1 , comparing_value_2 , after_parenthesis , created_user , updated_user , )
select old.id , old.m_contract_id , old.search_criteria_base_id , old.condition_number , old.conjunction , old.previous_parenthesis , old.item , old.comparing_value_3 , old.comparing_value_1 , old.comparing_value_2 , old.after_parenthesis , old.created_user , old.updated_user ,  from ks_cloud.t_customer_condition_details old
/

drop table ks_cloud.t_customer_condition_details cascade/

alter table ks_cloud.`$$t_customer_condition_details` rename to t_customer_condition_details
/

alter table ks_cloud.t_customer_condition_details  add constraint `PRIMARY` primary key (id)
/


