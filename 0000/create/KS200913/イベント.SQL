create database if not EXISTS ks_cloud character set utf8 collate utf8_bin;
create table ks_cloud.`$$t_events` (
	id int(11) primary key auto_increment not null comment 'ID',
	m_contract_id  int not null comment '契約ID : =契約マスタ.ID',
	t_project_base_id  int comment '案件ID : =案件情報.ID',
	event_type  tinyint(1) not null comment 'イベント種別 : ※固定値：イベント種別',
	event_date_start  date comment 'イベント開始日 : 未登録案件はnull',
	event_time_start  int not null comment 'イベント開始時刻 : ※固定値：イベント時刻',
	event_date_end  date comment 'イベント終了日',
	event_time_end  int comment 'イベント終了時刻 : ※固定値：イベント時刻',
	event_is_daylong  tinyint(1)  comment '終日',
	event_title  varchar(255)  not null comment 'タイトル',
	event_place  varchar(255)  comment '場所',
	event_memo  varchar(4000)  comment 'メモ',
	event_status  tinyint(1) default 0 comment 'ステータス : ※固定値：イベントステータス',
	google_id  varchar(100)  comment 'GoogleイベントID',
	event_bg_color  varchar(10)  default '1' comment '背景色 : ※固定値：カラーもしくはARGB値（９桁）',
	event_font_color  varchar(10)  default '#FFFFFFFF' comment '文字色 : ARGB値（９桁：カラーピッカーによっては透明度が付与される）',
	creater  int comment '作成者',
	created_at TIMESTAMP not null DEFAULT CURRENT_TIMESTAMP comment '作成日時',
	modifier  int comment '更新者',
	updated_at datetime comment '更新日時',
	deleted_at datetime comment '削除日時',
	)
	comment='イベント'
	engine InnoDB
	row_format COMPACT
	collate utf8_general_ci
/

insert into ks_cloud.$$t_events`(id , m_contract_id , t_project_base_id , event_type , event_date_start , event_time_start , event_date_end , event_time_end , event_is_daylong , event_title , event_place , event_memo , event_status , google_id , event_bg_color , event_font_color , creater , modifier , )
select old.id , old.m_contract_id , old.t_project_base_id , old.event_type , old.event_date_start , old.event_time_start , old.event_date_end , old.event_time_end , old.event_is_daylong , old.event_title , old.event_place , old.event_memo , old.event_status , old.google_id , old.event_bg_color , old.event_font_color , old.creater , old.modifier ,  from ks_cloud.t_events old
/

drop table ks_cloud.t_events cascade/

alter table ks_cloud.`$$t_events` rename to t_events
/

alter table ks_cloud.t_events  add constraint `PRIMARY` primary key (id)
/


