CREATE TYPE [entries].[EntryTransactionRequest] AS TABLE
(
	[CategoryId] INT NULL,
	[Amount] MONEY NOT NULL,
	[CurrencyCode] CHAR(3) NOT NULL,
	[Memo] NVARCHAR(MAX) NULL
);
