CREATE TABLE [dbo].[Objects]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(255) NOT NULL, 
    [ShortDescription] NVARCHAR(50) NOT NULL
)
