CREATE PROCEDURE [entries].[Entry_Insert]
    @entryUid UNIQUEIDENTIFIER,
	@accountUid UNIQUEIDENTIFIER,
	@payeeUid UNIQUEIDENTIFIER NULL,
	@transferAccountUid UNIQUEIDENTIFIER NULL,
	@date DATETIMEOFFSET,
	@isCleared BIT,
	@isActive BIT,
	@transactions [entries].[EntryTransactionRequest] READONLY
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_accountId INT = (SELECT [Id] FROM [accounts].[Account] WHERE [Uid] = @accountUid);
    IF @_accountId IS NULL
    BEGIN
		;THROW 50002, 'The account does not exist', 1;
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
    
    DECLARE @_transferAccountId INT = NULL;
    IF @transferAccountUid IS NOT NULL
    BEGIN;
        SELECT @_transferAccountId = [Id] FROM [accounts].[Account] WHERE [Uid] = @transferAccountUid;
        IF @_transferAccountId IS NULL
        BEGIN
		    ;THROW 50002, 'The transfer account does not exist', 1;
	    END;
    END;

	DECLARE @_inNestedTransaction BIT;

	BEGIN TRY
	
		IF	@@TRANCOUNT = 0
		BEGIN
			SET	@_inNestedTransaction = 0;
			BEGIN TRANSACTION;
		END
		ELSE
		BEGIN
			SET @_inNestedTransaction = 1;
		END;


		INSERT INTO
				[entries].[Entry]
                ([Uid])
        VALUES  (@entryUid);
        
	    DECLARE @_entryId BIGINT = SCOPE_IDENTITY();

		EXEC	[entries].[_SetEntryRevision] @_entryId, @_accountId, @_payeeId, @_transferAccountId, @date, @transactions;
		EXEC	[entries].[_SetEntryStatus] @_entryId, @isCleared, @isActive;

		EXEC	[entries].[EntryTransaction_GetByEntryUid] @entryUid;


		IF	@@TRANCOUNT > 0
			AND @_inNestedTransaction = 0
		BEGIN
			COMMIT TRANSACTION;
		END;

	END TRY
	BEGIN CATCH
		
		IF	@@TRANCOUNT > 0
			AND @_inNestedTransaction = 0
		BEGIN
			ROLLBACK TRANSACTION;
		END;

		THROW;

	END CATCH;
END;
