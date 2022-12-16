CREATE TABLE [categories].[CategoryRevision]
(
	[Id] INT IDENTITY(1,1) CONSTRAINT PK_CategoryRevision PRIMARY KEY,
	[DateRevised] DATETIMEOFFSET NOT NULL CONSTRAINT DF_CategoryRevision_DateRevised DEFAULT SYSDATETIMEOFFSET(),
	[CategoryId] INT NOT NULL,
	[AccountId] UNIQUEIDENTIFIER NOT NULL,
	
	[Name] NVARCHAR(4000) NOT NULL,
	[Subname] NVARCHAR(4000) NULL,

	CONSTRAINT FK_CategoryRevision_Category FOREIGN KEY ([CategoryId])
		REFERENCES [categories].[Category] ([Id])
			ON DELETE CASCADE,
	CONSTRAINT FK_CategoryRevision_Account FOREIGN KEY ([AccountId])
		REFERENCES [accounts].[Account] ([Id])
			ON DELETE CASCADE,
);
