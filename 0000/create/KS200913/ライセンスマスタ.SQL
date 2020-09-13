create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_licenses` (
	id int(11) primary key auto_increment not null comment 'ID',
	license_key  varchar(20)  not null comment 'ライセンスキー',
	stop_flag  tinyint(1)  default 0 not null comment '停止フラグ',
	effective_period_from  date not null comment '有効期限（FROM)',
	effective_period_to  date comment '有効期限（TO）',
	m_plan_id  int not null comment 'プランID : ＝プランマスタ．ID',
	check_interval  int(4)  default 1440 not null comment '更新チェック間隔 : 分単位で設定',
	m_version_id  int not null comment 'バージョンアップ可能Ver : 0：常に最新、以外：バージョンマスタ.ID',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='ライセンスマスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_licenses`(id , license_key , stop_flag , effective_period_from , effective_period_to , m_plan_id , check_interval , m_version_id , created_user , updated_user , )
select old.id , old.license_key , old.stop_flag , old.effective_period_from , old.effective_period_to , old.m_plan_id , old.check_interval , old.m_version_id , old.created_user , old.updated_user ,  from ks_cloud.m_licenses old
/

drop table ks_cloud.m_licenses cascade/

alter table ks_cloud.`$$m_licenses` rename to m_licenses
/

alter table ks_cloud.m_licenses  add constraint `PRIMARY` primary key (id)
/


