CREATE TABLE [dbo].[Actions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (25)  DEFAULT ('') NOT NULL,
    [Description] NVARCHAR (255) DEFAULT ('') NOT NULL,
    [DeepObjects] INT            DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

nhbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb