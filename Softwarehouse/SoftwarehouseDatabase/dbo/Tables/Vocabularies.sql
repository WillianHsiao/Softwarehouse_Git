CREATE TABLE [dbo].[Vocabularies] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [SaveTime]     DATETIME         NOT NULL,
    [IsRemembered] BIT              NOT NULL,
    CONSTRAINT [PK_dbo.Vocabularies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

