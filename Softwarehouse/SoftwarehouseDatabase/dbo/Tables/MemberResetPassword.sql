CREATE TABLE [dbo].[MemberResetPassword]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[MemberAccount]    NVARCHAR(25)    NOT NULL,
	[UniqueKey] NVARCHAR(450) NOT NULL,
	[SaltString] NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_MemberResetPassword] PRIMARY KEY ([Id])
)
GO

CREATE UNIQUE INDEX [IX_MemberResetPassword_UniqueKey] ON [dbo].[MemberResetPassword] ([UniqueKey])
