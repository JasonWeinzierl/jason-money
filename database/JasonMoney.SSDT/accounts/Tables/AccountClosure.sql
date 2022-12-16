CREATE TABLE [accounts].[AccountClosure]
(
	[Id] INT IDENTITY(1,1) CONSTRAINT PK_AccountClosure PRIMARY KEY,
	[AccountId] UNIQUEIDENTIFIER CONSTRAINT UK_AccountClosure_AccountId UNIQUE,
	[DateClosed] DATETIMEOFFSET NOT NULL,

	CONSTRAINT FK_AccountClosure_Account FOREIGN KEY ([AccountId])
		REFERENCES [accounts].[Account] ([Id])
			ON DELETE CASCADE,
);
