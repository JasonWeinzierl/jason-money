CREATE TABLE [entries].[EntryTransaction]
(
	[Id] BIGINT IDENTITY(1,1) CONSTRAINT PK_EntryTransaction PRIMARY KEY,
	[EntryRevisionId] BIGINT NOT NULL,
	[CategoryId] INT NULL,
	
	[Amount] MONEY NOT NULL,
	[CurrencyCode] CHAR(3) NOT NULL,
	[Memo] NVARCHAR(MAX) NULL,

	CONSTRAINT FK_EntryTransaction_EntryRevision FOREIGN KEY ([EntryRevisionId])
		REFERENCES [entries].[EntryRevision] ([Id])
			ON DELETE CASCADE,
	CONSTRAINT FK_EntryTransaction_Category FOREIGN KEY ([CategoryId])
		REFERENCES [categories].[Category] ([Id])
			ON DELETE SET NULL,
);

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ISO 4217',
    @level0type = N'SCHEMA',
    @level0name = N'entries',
    @level1type = N'TABLE',
    @level1name = N'EntryTransaction',
    @level2type = N'COLUMN',
    @level2name = N'CurrencyCode'