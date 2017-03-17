CREATE TABLE [dbo].[VipData]
(
	[Id] INT           IDENTITY (1, 1) NOT NULL, 
    [UserAccountId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_VipData] UNIQUE ([Id]), 
    CONSTRAINT [FK_VipData_ToUserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id])
)
