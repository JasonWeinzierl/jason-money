CREATE TABLE [entries].[EntryStatusChange]
(
	[Id] BIGINT IDENTITY(1,1) CONSTRAINT PK_EntryStatusChange PRIMARY KEY,
	[DateChanged] DATETIMEOFFSET NOT NULL CONSTRAINT DF_EntryStatusChange_DateChanged DEFAULT SYSDATETIMEOFFSET(),
	[EntryId] BIGINT NOT NULL,

	[Date] DATETIMEOFFSET NOT NULL,
	[IsCleared] BIT NOT NULL CONSTRAINT DF_EntryStatusChange_IsCleared DEFAULT 0,
	[IsActive] BIT NOT NULL CONSTRAINT DF_EntryStatusChange_IsDeleted DEFAULT 1,

	CONSTRAINT FK_EntryStatusChange_Entry FOREIGN KEY ([EntryId])
		REFERENCES [entries].[Entry] ([Id])
			ON DELETE CASCADE,
);
