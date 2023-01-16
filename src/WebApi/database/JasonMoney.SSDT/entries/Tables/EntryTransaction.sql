CREATE TABLE [entries].[EntryTransaction]
(
	[Id] BIGINT IDENTITY(1,1) CONSTRAINT PK_EntryTransaction PRIMARY KEY,
	[EntryRevisionId] BIGINT NOT NULL,
	[CategoryId] INT NULL,
	
	[Amount] MONEY NOT NULL,
	[Memo] VARCHAR(MAX) NULL,

	CONSTRAINT FK_EntryTransaction_EntryRevision FOREIGN KEY ([EntryRevisionId])
		REFERENCES [entries].[EntryRevision] ([Id])
			ON DELETE CASCADE,
	CONSTRAINT FK_EntryTransaction_Category FOREIGN KEY ([CategoryId])
		REFERENCES [categories].[Category] ([Id])
			ON DELETE SET NULL,
);
