CREATE TABLE [dbo].[UserAccount]
(
	[Id] INT           IDENTITY (1, 1) NOT NULL, 
    [Account] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_UserAccount] PRIMARY KEY ([Id])
)
