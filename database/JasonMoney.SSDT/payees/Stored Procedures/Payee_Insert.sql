CREATE PROCEDURE [payees].[Payee_Insert]
	@payerAccountId UNIQUEIDENTIFIER,
	@name NVARCHAR(MAX)
AS
BEGIN;
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
				[payees].[Payee]
		DEFAULT VALUES;

		DECLARE @_payeeId BIGINT = SCOPE_IDENTITY();

		EXEC	[payees].[_SetPayeeRevision] @_payeeId, @payerAccountId, @name;

		EXEC	[payees].[Payee_GetById] @_payeeId;

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
