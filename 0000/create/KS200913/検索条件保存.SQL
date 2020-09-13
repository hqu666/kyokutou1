create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_search_conditions` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	search_type  tinyint(1) not null comment '検索種別 : ※固定値：検索種別',
	m_login_users_staff_id  int not null comment 'ログインユーザーID : =ログインユーザーマスタ.ID',
	search_name  varchar(100) ○ not null comment '条件名',
	value1  varchar(100) ○ not null comment '条件値1',
	value2  varchar(100) ○ not null comment '条件値2',
	value3  varchar(100) ○ not null comment '条件値3',
	value4  varchar(100) ○ not null comment '条件値4',
	value5  varchar(100) ○ not null comment '条件値5',
	value6  varchar(100) ○ not null comment '条件値6',
	value7  varchar(100) ○ not null comment '条件値7',
	value8  varchar(100) ○ not null comment '条件値8',
	value9  varchar(100) ○ not null comment '条件値9',
	value10  varchar(100) ○ not null comment '条件値10',
	value11  varchar(100) ○ not null comment '条件値11',
	value12  varchar(100) ○ not null comment '条件値12',
	value13  varchar(100) ○ not null comment '条件値13',
	value14  varchar(100) ○ not null comment '条件値14',
	value15  varchar(100) ○ not null comment '条件値15',
	value16  varchar(100) ○ not null comment '条件値16',
	value17  varchar(100) ○ not null comment '条件値17',
	value18  varchar(100) ○ not null comment '条件値18',
	value19  varchar(100) ○ not null comment '条件値19',
	value20  varchar(100) ○ not null comment '条件値20',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(m_contract_id (1)))
	comment='検索条件保存'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_search_conditions`(id , m_contract_id , search_type , m_login_users_staff_id , search_name , value1 , value2 , value3 , value4 , value5 , value6 , value7 , value8 , value9 , value10 , value11 , value12 , value13 , value14 , value15 , value16 , value17 , value18 , value19 , value20 , created_user , updated_user , )
select old.id , old.m_contract_id , old.search_type , old.m_login_users_staff_id , old.search_name , old.value1 , old.value2 , old.value3 , old.value4 , old.value5 , old.value6 , old.value7 , old.value8 , old.value9 , old.value10 , old.value11 , old.value12 , old.value13 , old.value14 , old.value15 , old.value16 , old.value17 , old.value18 , old.value19 , old.value20 , old.created_user , old.updated_user ,  from ks_cloud.t_search_conditions old
/

drop table ks_cloud.t_search_conditions cascade/

alter table ks_cloud.`$$t_search_conditions` rename to t_search_conditions
/

alter table ks_cloud.t_search_conditions  add constraint `PRIMARY` primary key (id)
/


