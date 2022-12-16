CREATE PROCEDURE [entries].[Entry_Insert]
	@accountId UNIQUEIDENTIFIER,
	@payeeId BIGINT NULL,
	@transferAccountId UNIQUEIDENTIFIER NULL,
	@date DATETIMEOFFSET,
	@isCleared BIT,
	@isActive BIT,
	@transactions [entries].[EntryTransactionRequest] READONLY
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON;

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
		DEFAULT VALUES;

		DECLARE @_entryId BIGINT = SCOPE_IDENTITY();

		EXEC	[entries].[_SetEntryRevision] @_entryId, @accountId, @payeeId, @transferAccountId, @date, @transactions;
		EXEC	[entries].[_SetEntryStatus] @_entryId, @date, @isCleared, @isActive;

		EXEC	[entries].[EntryTransaction_GetByEntryId] @_entryId;

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
