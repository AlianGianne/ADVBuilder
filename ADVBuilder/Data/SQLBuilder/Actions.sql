﻿CREATE TABLE [dbo].[Actions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Action] NVARCHAR(25) NOT NULL DEFAULT '', 
    [Description] NVARCHAR(255) NOT NULL DEFAULT ''
)
