CREATE TYPE [entries].[EntryTransactionRequest] AS TABLE
(
	[CategoryUid] UNIQUEIDENTIFIER NULL,
	[Amount] MONEY NOT NULL,
	[Memo] NVARCHAR(MAX) NULL
);
