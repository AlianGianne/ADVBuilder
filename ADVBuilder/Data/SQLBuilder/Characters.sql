CREATE TABLE [dbo].[Characters]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdRoom] INT NOT NULL, 
    [Title] NVARCHAR(25) NOT NULL, 
    [Description] NVARCHAR(255) NOT NULL, 
    [ShortDescription] NVARCHAR(130) NOT NULL, 
    [Status] NVARCHAR(15) NOT NULL, 
    [Action] NVARCHAR(15) NOT NULL, 
    [SufferAction] NVARCHAR(15) NOT NULL 
)
