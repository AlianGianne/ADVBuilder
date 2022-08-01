CREATE TABLE [dbo].[Sentences]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdCharacter] INT NOT NULL, 
    [Sentence] NVARCHAR(MAX) NOT NULL, 
    [Level] INT NOT NULL
)
