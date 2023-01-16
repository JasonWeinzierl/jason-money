CREATE TABLE [accounts].[AccountGroupRevision]
(
	[Id] INT IDENTITY(1,1) CONSTRAINT PK_AccountGroupRevision PRIMARY KEY,
	[DateRevision] DATETIMEOFFSET NOT NULL CONSTRAINT DF_AccountGroupRevision_DateRevision DEFAULT SYSDATETIMEOFFSET(),
	[GroupId] INT NOT NULL,

	[Name] VARCHAR(4000) NOT NULL,

	CONSTRAINT FK_AccountGroupRevision_AccountGroup FOREIGN KEY ([GroupId])
		REFERENCES [accounts].[AccountGroup] ([Id])
			ON DELETE CASCADE,
);
