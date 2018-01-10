CREATE TABLE [dbo].[VipUsers]
(
	[Id] INT           IDENTITY (1, 1) NOT NULL, 
	[Account] NVARCHAR(25) NOT NULL, 
	[Password] NVARCHAR(50) NOT NULL, 
	[Email] NVARCHAR(50) NOT NULL, 
	CONSTRAINT [PK_VipUsers] PRIMARY KEY ([Id])
)
