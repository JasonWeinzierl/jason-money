CREATE PROCEDURE [accounts].[_SetAccountRevision]
	@accountId INT,

	@name VARCHAR(4000),
	@groupId INT NULL,
	@bankSwift CHAR(11) NULL,
	@externalId VARCHAR(MAX) NULL,
	@description VARCHAR(MAX) NULL
AS
BEGIN
	INSERT INTO
			[accounts].[AccountRevision]
			([AccountId], [Name], [GroupId], [BankSwift], [ExternalId], [Description])
	VALUES	(@accountId, @name, @groupId, @bankSwift, @externalId, @description);
END;
