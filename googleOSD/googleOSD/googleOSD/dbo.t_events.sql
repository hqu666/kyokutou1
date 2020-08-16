CREATE TABLE [dbo].[t_events] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [m_contract_id]     INT             NULL,
    [t_project_base_id] INT             NULL,
    [event_type]        TINYINT         NULL DEFAULT (1),
    [event_date_start]  DATE            NULL DEFAULT (now()),
    [event_time_start]  TINYINT         NULL DEFAULT (09),
    [event_date_end]    DATE            NULL DEFAULT (now()),
    [event_time_end]    TINYINT         NULL DEFAULT (10),
    [event_is_daylong]  TINYINT         NULL DEFAULT (0),
    [event_title]       NVARCHAR (100)  DEFAULT ('案件') NULL,
    [event_place]       NVARCHAR (100)  DEFAULT ('??') NULL,
    [event_memo]        NVARCHAR (4000) DEFAULT ('??') NULL,
    [event_status]      TINYINT         NULL,
    [google_id]         VARCHAR (100)   NULL,
    [event_bg_color]    VARCHAR (10)    NULL DEFAULT ('2'),
    [event_font_color]  VARCHAR (10)    NULL DEFAULT ('1'),
    [project_name]      NVARCHAR (100)  NULL,
    [project_number]    VARCHAR (20)    NULL,
    [order_number]      VARCHAR (20)    NULL,
    [management_number] VARCHAR (20)    NULL,
    [owner_name]        NVARCHAR (100)  NULL,
    [modify]            DATETIME        NULL DEFAULT (now()),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'契約ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'm_contract_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'案件基本ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N't_project_base_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'案件/工程/通常', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_type';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'開始日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_date_start';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'開始時刻', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_time_start';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'終了日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_date_end';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'終了時刻', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_time_end';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'終日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_is_daylong';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'タイトル', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'場所', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_place';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'メモ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_memo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ステータス', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'GoogleCalenderEvrentID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'google_id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'背景色', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_bg_color';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'文字色', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'event_font_color';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'案件名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'project_name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'案件No.', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'project_number';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'注文番号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'order_number';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'管理番号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'management_number';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'施主名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'owner_name';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N't_events', @level2type = N'COLUMN', @level2name = N'modify';

