CREATE TABLE [dbo].[t_events] (
    [Id]                INT            NOT NULL IDENTITY,
    [m_contract_id]     INT            NULL DEFAULT 1,
    [t_project_base_id] INT            NULL DEFAULT 1,
    [event_type]        TINYINT        NULL DEFAULT 1,
    [event_date_start]  DATE           NULL DEFAULT now(),
    [event_time_start]  TINYINT        NULL DEFAULT 10,
    [event_date_end]    DATE           NULL DEFAULT now() ,
    [event_time_end]    TINYINT        NULL DEFAULT 11,
    [event_is_daylong]  TINYINT        NULL DEFAULT 0,
    [event_title]       TEXT  NOT NULL ,
    [event_place]       VARCHAR (255)  NULL,
    [event_memo]        VARCHAR (4000) NULL,
    [event_status]      TINYINT        NULL,
    [google_id]         VARCHAR (100)  NULL,
    [event_bg_color]    VARCHAR (10)   NULL DEFAULT 2,
    [event_font_color]  VARCHAR (10)   NULL DEFAULT 1,
    [project_name]      TEXT           NULL ,
    [project_number]    VARCHAR (255)  NULL,
    [order_number]      VARCHAR (255)  NULL,
    [management_number] VARCHAR (255)  NULL,
    [owner_name]        VARCHAR (255)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'開始日',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_date_start'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'イベントID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'終了日',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_date_end'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'案件基本ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N't_project_base_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'契約ID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'm_contract_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'案件/工程/通常',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_type'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'終日',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_is_daylong'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'タイトル',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_title'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'場所',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_place'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'メモ',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_memo'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'GoogleCalenderEventID',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'google_id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'背景色',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_bg_color'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'文字色',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'event_font_color'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'案件名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'project_name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'案件No.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'project_number'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'契約No.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'order_number'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'管理No.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'management_number'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'施主名',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N't_events',
    @level2type = N'COLUMN',
    @level2name = N'owner_name'