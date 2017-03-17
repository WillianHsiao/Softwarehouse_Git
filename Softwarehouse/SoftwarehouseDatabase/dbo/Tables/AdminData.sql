CREATE TABLE [dbo].[AdminData]
(
	[Id] INT           IDENTITY (1, 1) NOT NULL, 
    [UserAccountId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_AdminData] UNIQUE ([Id]), 
    CONSTRAINT [FK_AdminData_ToUserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id])
)
