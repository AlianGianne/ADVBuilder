CREATE TABLE [dbo].[Characters] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [IdRoom]           INT            NOT NULL,
    [Title]            NVARCHAR (25)  NOT NULL,
    [Description]      NVARCHAR (MAX) NOT NULL,
    [ShortDescription] NVARCHAR (130) NOT NULL,
    [Status]           NVARCHAR (130) NOT NULL,
    [Action]           NVARCHAR (15)  NOT NULL,
    [SufferAction]     NVARCHAR (15)  NOT NULL,
    [LifePoint]        INT            DEFAULT ((100)) NOT NULL,
    [Skls]             NVARCHAR (MAX) DEFAULT ('{  "Age": -184244145,  "Force": 1569221092,  "Wisdom": 716419273,  "Physique": 1871824249,  "Dexterity": 1195678712,  "Smartness": -921593444,  "Experience": -1403817515,  "Life": -1579785251,  "Mana": 1524658408,  "Xp": 248870592,  "Level": 2011192338,  "XpNextLevel": 627613224}') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

