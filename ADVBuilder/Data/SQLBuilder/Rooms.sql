CREATE TABLE [dbo].[Rooms] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [IdAdv]            INT            NOT NULL,
    [Title]            NVARCHAR (50)  DEFAULT ('') NOT NULL,
    [Description]      NVARCHAR (MAX) DEFAULT ('') NOT NULL,
    [ShortDescription] NVARCHAR (255) DEFAULT ('') NOT NULL,
    [NN]               INT            DEFAULT ((0)) NOT NULL,
    [NE]               INT            DEFAULT ((0)) NOT NULL,
    [EE]               INT            DEFAULT ((0)) NOT NULL,
    [SE]               INT            DEFAULT ((0)) NOT NULL,
    [SS]               INT            DEFAULT ((0)) NOT NULL,
    [SO]               INT            DEFAULT ((0)) NOT NULL,
    [OO]               INT            DEFAULT ((0)) NOT NULL,
    [NO]               INT            DEFAULT ((0)) NOT NULL,
    [AA]               INT            DEFAULT ((0)) NOT NULL,
    [BB]               INT            DEFAULT ((0)) NOT NULL,
    [Layer]            INT            DEFAULT ((0)) NOT NULL,
    [Sector]           INT            DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

