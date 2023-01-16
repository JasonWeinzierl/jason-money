CREATE TABLE [accounts].[AccountRevision]
(
	[Id] INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_AccountRevision PRIMARY KEY,
	[DateRevised] DATETIMEOFFSET NOT NULL CONSTRAINT DF_AccountRevision_DateRevised DEFAULT SYSDATETIMEOFFSET(),
	[AccountId] INT NOT NULL,

	[Name] NVARCHAR(4000) NOT NULL,
	[GroupId] INT NULL,
	[BankSwift] CHAR(11) NULL,
	[ExternalId] NVARCHAR(MAX) NULL,
	[Description] NVARCHAR(MAX) NULL,

	CONSTRAINT FK_AccountRevision_Account FOREIGN KEY ([AccountId])
        REFERENCES [accounts].[Account] ([Id])
            ON DELETE CASCADE,
    CONSTRAINT FK_AccountRevision_AccountGroup FOREIGN KEY ([GroupId])
        REFERENCES [accounts].[AccountGroup] ([Id])
            ON DELETE SET NULL,
);

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ISO 9362',
    @level0type = N'SCHEMA',
    @level0name = N'accounts',
    @level1type = N'TABLE',
    @level1name = N'AccountRevision',
    @level2type = N'COLUMN',
    @level2name = N'BankSwift'