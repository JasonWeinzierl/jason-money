CREATE TYPE [entries].[EntryTransactionRequest] AS TABLE
(
	[CategoryUid] UNIQUEIDENTIFIER NULL,
	[Amount] MONEY NOT NULL,
	[CurrencyCode] CHAR(3) NOT NULL,
	[Memo] NVARCHAR(MAX) NULL
);
