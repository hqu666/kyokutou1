create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$m_versions` (
	id int(11) primary key auto_increment not null comment 'ID',
	version_name  varchar(20)  not null comment 'バージョン名',
	pre_m_version_id  int not null comment '前バージョンID : =バージョン情報.ID',
	version_lineage  decimal(4,2)  not null comment 'バージョン系統',
	application_name  varchar(30)  not null comment 'アプリケーション名 : EXE名',
	application_path  varchar(255)  not null comment 'アプリケーションパス : ダウンロード用のパス',
	delivery_date_start  date not null comment '配信開始日',
	delivery_date_end  date○ not null comment '配信終了日',
	version_upgrade_deadline  date not null comment 'バージョンアップ期限',
	undelivered_flag  tinyint(1) default 0 not null comment '配信停止フラグ',
	overview  varchar(4000) ○ not null comment 'バージョン概要 : バージョンアップ内容',
	created_user  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	updated_user  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='バージョンマスタ'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$m_versions`(id , version_name , pre_m_version_id , version_lineage , application_name , application_path , delivery_date_start , delivery_date_end , version_upgrade_deadline , undelivered_flag , overview , created_user , updated_user , )
select old.id , old.version_name , old.pre_m_version_id , old.version_lineage , old.application_name , old.application_path , old.delivery_date_start , old.delivery_date_end , old.version_upgrade_deadline , old.undelivered_flag , old.overview , old.created_user , old.updated_user ,  from ks_cloud.m_versions old
/

drop table ks_cloud.m_versions cascade/

alter table ks_cloud.`$$m_versions` rename to m_versions
/

alter table ks_cloud.m_versions  add constraint `PRIMARY` primary key (id)
/


