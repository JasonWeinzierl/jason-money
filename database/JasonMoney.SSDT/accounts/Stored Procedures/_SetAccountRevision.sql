﻿CREATE PROCEDURE [accounts].[_SetAccountRevision]
	@id UNIQUEIDENTIFIER,

	@name NVARCHAR(4000),
	@groupId INT NULL,
	@bankSwift CHAR(11) NULL,
	@externalId NVARCHAR(MAX) NULL,
	@currencyCode CHAR(3),
	@description NVARCHAR(MAX) NULL
AS
BEGIN
	INSERT INTO
			[accounts].[AccountRevision]
			([AccountId], [Name], [GroupId], [BankSwift], [ExternalId], [CurrencyCode], [Description])
	VALUES	(@id, @name, @groupId, @bankSwift, @externalId, @currencyCode, @description);
END;
