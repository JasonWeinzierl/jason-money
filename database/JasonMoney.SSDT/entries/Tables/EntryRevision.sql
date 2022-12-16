CREATE TABLE [entries].[EntryRevision]
(
	[Id] BIGINT IDENTITY(1,1) CONSTRAINT PK_EntryRevision PRIMARY KEY,
	[DateRevised] DATETIMEOFFSET NOT NULL CONSTRAINT DF_EntryRevision_DateRevised DEFAULT SYSDATETIMEOFFSET(),
	[EntryId] BIGINT NOT NULL,

	[AccountId] UNIQUEIDENTIFIER NOT NULL,
	[PayeeId] BIGINT NULL,
	[TransferAccountId] UNIQUEIDENTIFIER NULL,

	[Date] DATETIMEOFFSET NOT NULL,

	CONSTRAINT FK_EntryRevision_Entry FOREIGN KEY ([EntryId])
		REFERENCES [entries].[Entry] ([Id])
			ON DELETE CASCADE,
	CONSTRAINT FK_EntryRevision_Account FOREIGN KEY ([AccountId])
		REFERENCES [accounts].[Account] ([Id])
			ON DELETE CASCADE,
	CONSTRAINT FK_EntryRevision_Payee FOREIGN KEY ([PayeeId])
		REFERENCES [payees].[Payee] ([Id])
			ON DELETE NO ACTION,
	CONSTRAINT FK_EntryRevision_Account_TransferAccountId FOREIGN KEY ([TransferAccountId])
		REFERENCES [accounts].[Account] ([Id])
			ON DELETE NO ACTION,
	CONSTRAINT CK_EntryRevision_Destinations_OneHasValue CHECK (
		CASE
			WHEN [PayeeId] IS NOT NULL
			THEN 1 ELSE 0
		END + CASE
			WHEN [TransferAccountId] IS NOT NULL
			THEN 1 ELSE 0
		END = 1),
	CONSTRAINT CK_EntryRevision_Accounts_NotEqual CHECK (
		[TransferAccountId] IS NULL
		OR [AccountId] <> [TransferAccountId]),
);
