CREATE TABLE [dbo].[MemberData] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Account]     NVARCHAR(25)    NOT NULL,
    [Password] NVARCHAR(MAX) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL
);

