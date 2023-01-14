CREATE PROCEDURE [entries].[Entry_UpdateDetails]
	@entryUid UNIQUEIDENTIFIER,
	@accountUid UNIQUEIDENTIFIER,
	@payeeUid UNIQUEIDENTIFIER NULL,
	@transferAccountUid UNIQUEIDENTIFIER NULL,
	@date DATETIMEOFFSET,
	@transactions [entries].[EntryTransactionRequest] READONLY
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_entryId INT = (SELECT [Id] FROM [entries].[Entry] WHERE [Uid] = @entryUid);
    IF @_entryId IS NULL
    BEGIN
		;THROW 50002, 'The entry does not exist', 1;
	END;

    DECLARE @_payeeId BIGINT = NULL;
    IF @payeeUid IS NOT NULL
    BEGIN;
        SELECT @_payeeId = [Id] FROM [payees].[Payee] WHERE [Uid] = @payeeUid;
        IF @_payeeId IS NULL
        BEGIN
		    ;THROW 50002, 'The payee does not exist', 1;
	    END;
    END;

    DECLARE @_accountId INT = (SELECT [Id] FROM [accounts].[Account] WHERE [Uid] = @accountUid);
    IF @_accountId IS NULL
    BEGIN
		;THROW 50002, 'The account does not exist', 1;
	END;
    
    DECLARE @_transferAccountId INT = NULL;
    IF @transferAccountUid IS NOT NULL
    BEGIN;
        SELECT @_transferAccountId = [Id] FROM [accounts].[Account] WHERE [Uid] = @transferAccountUid;
        IF @_transferAccountId IS NULL
        BEGIN
		    ;THROW 50002, 'The transfer account does not exist', 1;
	    END;
    END;

	EXEC	[entries].[_SetEntryRevision] @_entryId, @_accountId, @_payeeId, @_transferAccountId, @date, @transactions;

	EXEC	[entries].[EntryTransaction_GetByEntryUid] @entryUid;
END;
