CREATE TABLE [dbo].[MemberData] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [UserAccountId]     INT    NOT NULL,
    [Name] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK_MemberData] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_MemberData_ToUserAccount] FOREIGN KEY ([UserAccountId]) REFERENCES [UserAccount]([Id])
);

