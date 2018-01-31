CREATE TABLE [dbo].[VipUsers]
(
	[Id] INT           IDENTITY (1, 1) NOT NULL, 
	[Account] NVARCHAR(25) NOT NULL, 
	[Password] NVARCHAR(MAX) NOT NULL, 
	[Email] NVARCHAR(50) NOT NULL, 
	[Name] NVARCHAR(50) , 
	[SaltString] NVARCHAR(50) NOT NULL, 
	CONSTRAINT [PK_VipUsers] PRIMARY KEY ([Id])
)

GO

CREATE INDEX [IX_VipUsers_Account] ON [dbo].[VipUsers] ([Account])

GO

CREATE INDEX [IX_VipUsers_Email] ON [dbo].[VipUsers] ([Email])
