CREATE TABLE [dbo].[Member] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Account]  NVARCHAR (20) NOT NULL,
    [Password] NVARCHAR (20) NOT NULL,
    [Name]     NCHAR (10)    NOT NULL,
    CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED ([Id] ASC)
);

