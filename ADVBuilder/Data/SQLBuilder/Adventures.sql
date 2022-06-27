CREATE TABLE [dbo].[Adventures] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Title]            NVARCHAR (50)  DEFAULT ('') NOT NULL,
    [SubTitle]         NVARCHAR (50)  DEFAULT ('') NOT NULL,
    [Description]      NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [ShortDescription] NVARCHAR (255) DEFAULT ('') NOT NULL,
    [Version]          NVARCHAR (10)  DEFAULT ('00.00.0000') NOT NULL,
    [Author]           NVARCHAR (50)  DEFAULT ('') NOT NULL,
    [CurrentRoom]        INT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

