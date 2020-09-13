create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_deadlines` (
	id int(11) primary key auto_increment not null comment 'ID',
	supplier_type  tinyint(1) not null comment '取引先区分 : ※取引先区分',
	closing_date  date not null comment '締日 : 0：随時、日付（1～29）、99：末締め',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	index idx1(supplier_type (1)))
	comment='締日マスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_deadlines`(id , supplier_type , closing_date , created_user , updated_user , )
select old.id , old.supplier_type , old.closing_date , old.created_user , old.updated_user ,  from ks_cloud.m_deadlines old
/

drop table ks_cloud.m_deadlines cascade/

alter table ks_cloud.`$$m_deadlines` rename to m_deadlines
/

alter table ks_cloud.m_deadlines  add constraint `PRIMARY` primary key (id)
/


