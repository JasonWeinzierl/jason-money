﻿CREATE TABLE [payees].[PayeeRevision]
(
	[Id] BIGINT IDENTITY(1,1) CONSTRAINT PK_PayeeRevision PRIMARY KEY,
	[DateRevised] DATETIMEOFFSET NOT NULL CONSTRAINT DF_PayeeRevision_DateRevised DEFAULT SYSDATETIMEOFFSET(),
	[PayeeId] BIGINT NOT NULL,

	[PayerAccountId] UNIQUEIDENTIFIER NOT NULL,

	[Name] NVARCHAR(MAX) NOT NULL,

	CONSTRAINT FK_PayeeRevision_Payee FOREIGN KEY ([PayeeId])
		REFERENCES [payees].[Payee] ([Id])
			ON DELETE CASCADE,
	CONSTRAINT FK_PayeeRevision_PayerAccountId FOREIGN KEY ([PayerAccountId])
		REFERENCES [accounts].[Account] ([Id])
			ON DELETE CASCADE,
);
