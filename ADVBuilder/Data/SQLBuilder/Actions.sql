CREATE TABLE [dbo].[Actions] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Action]      NVARCHAR (25)  DEFAULT ('') NOT NULL,
    [Description] NVARCHAR (255) DEFAULT ('') NOT NULL,
    [DeepObjects] INT NOT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

