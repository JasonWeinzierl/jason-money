CREATE PROCEDURE [payees].[Payee_Update]
	@payeeUid UNIQUEIDENTIFIER,
	@name VARCHAR(MAX)
AS
BEGIN;
	SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_payeeId BIGINT = (SELECT [Id] FROM [payees].[Payee] WHERE [Uid] = @payeeUid);
    IF @_payeeId IS NULL
    BEGIN;
        RETURN 0;
	END;

	EXEC    [payees].[_SetPayeeRevision] @_payeeId, @name;

	EXEC	[payees].[Payee_GetByUid] @payeeUid;
END;
