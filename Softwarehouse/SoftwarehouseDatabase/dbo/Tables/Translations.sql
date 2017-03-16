CREATE TABLE [dbo].[Translations] (
    [Id]           UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    [VocabularyId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_dbo.Translations] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Translations_dbo.Vocabularies_VocabularyId] FOREIGN KEY ([VocabularyId]) REFERENCES [dbo].[Vocabularies] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_VocabularyId]
    ON [dbo].[Translations]([VocabularyId] ASC);

