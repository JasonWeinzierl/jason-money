CREATE PROCEDURE [entries].[_SetEntryRevision]
	@id BIGINT,
	@accountId UNIQUEIDENTIFIER,
	@payeeId BIGINT NULL,
	@transferAccountId UNIQUEIDENTIFIER NULL,
	@date DATETIMEOFFSET,
	@transactions [entries].[EntryTransactionRequest] READONLY
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON;

	IF (SELECT COUNT(*) FROM @transactions) <= 0
	BEGIN
		;THROW 50001, 'An entry must have at least one transaction.', 1;
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
				[entries].[EntryRevision]
				([EntryId], [AccountId], [PayeeId], [TransferAccountId], [Date])
		VALUES	(@id, @accountId, @payeeId, @transferAccountId, @date);

		DECLARE	@_entryRevisionId BIGINT = SCOPE_IDENTITY();

		INSERT INTO
				[entries].[EntryTransaction]
				([EntryRevisionId], [CategoryId], [Amount], [CurrencyCode], [Memo])
		SELECT	@_entryRevisionId AS [EntryRevisionId]
				, [CategoryId]
				, [Amount]
				, [CurrencyCode]
				, [Memo]
		FROM	@transactions;

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
