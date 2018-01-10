CREATE TABLE [dbo].[Members] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Account]     NVARCHAR(25)    NOT NULL,
    [Password] NVARCHAR(MAX) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [SaltString] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Members] PRIMARY KEY ([Id])
);


GO

CREATE UNIQUE INDEX [IX_Members_Account] ON [dbo].[Members] ([Account])

GO

CREATE UNIQUE INDEX [IX_Members_Email] ON [dbo].[Members] ([Email])
