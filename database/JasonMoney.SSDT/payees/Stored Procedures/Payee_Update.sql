CREATE PROCEDURE [payees].[Payee_Update]
	@id BIGINT,
	@payerAccountId UNIQUEIDENTIFIER,
	@name NVARCHAR(MAX)
AS
BEGIN;
	EXEC	[payees].[_SetPayeeRevision] @id, @payerAccountId, @name;

	EXEC	[payees].[Payee_GetById] @id;
END;
