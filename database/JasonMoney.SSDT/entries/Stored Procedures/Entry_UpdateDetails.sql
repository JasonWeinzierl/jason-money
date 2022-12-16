CREATE PROCEDURE [entries].[Entry_UpdateDetails]
	@id BIGINT,
	@accountId UNIQUEIDENTIFIER,
	@payeeId BIGINT NULL,
	@transferAccountId UNIQUEIDENTIFIER NULL,
	@date DATETIMEOFFSET,
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

		EXEC	[entries].[_SetEntryRevision] @id, @accountId, @payeeId, @transferAccountId, @date, @transactions;

		EXEC	[entries].[EntryTransaction_GetByEntryId] @id;

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
