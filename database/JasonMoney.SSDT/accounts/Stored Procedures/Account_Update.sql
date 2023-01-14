CREATE PROCEDURE [accounts].[Account_Update]
	@accountUid UNIQUEIDENTIFIER,

	@name NVARCHAR(4000),
	@groupUid UNIQUEIDENTIFIER NULL,
	@bankSwift CHAR(11) NULL,
	@externalId NVARCHAR(MAX) NULL,
	@currencyCode CHAR(3),
	@description NVARCHAR(MAX) NULL
AS
BEGIN
    SET XACT_ABORT, NOCOUNT ON;
    
    DECLARE @_accountId INT = (SELECT [Id] FROM [accounts].[Account] WHERE [Uid] = @accountUid);
    IF @_accountId IS NULL
    BEGIN
		;THROW 50002, 'The account does not exist', 1;
	END;

    DECLARE @_groupId INT = NULL;
    IF @groupUid IS NOT NULL
    BEGIN;
        SELECT @_groupId = [Id] FROM [accounts].[AccountGroup] WHERE [Uid] = @groupUid;
	    IF @_groupId IS NULL
	    BEGIN
		    ;THROW 50002, 'The group does not exist.', 1;
	    END;
    END;

	EXEC	[accounts].[_SetAccountRevision] @_accountId, @name, @_groupId, @bankSwift, @externalId, @currencyCode, @description;

	EXEC	[accounts].[Account_GetByUid] @accountUid;

END;
