CREATE TABLE [dbo].[MemberResetPassword]
(
	[Id] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[MemberAccount]    NVARCHAR(25)    NOT NULL,
	[RandomString] NVARCHAR(50) NOT NULL
)
