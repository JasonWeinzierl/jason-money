CREATE PROCEDURE [accounts].[Account_Update]
	@id UNIQUEIDENTIFIER,

	@name NVARCHAR(4000),
	@groupId INT NULL,
	@bankSwift CHAR(11) NULL,
	@externalId NVARCHAR(MAX) NULL,
	@currencyCode CHAR(3),
	@description NVARCHAR(MAX) NULL
AS
BEGIN
	EXEC	[accounts].[_SetAccountRevision] @id, @name, @groupId, @bankSwift, @externalId, @currencyCode, @description;

	EXEC	[accounts].[Account_GetById] @id;
END;
