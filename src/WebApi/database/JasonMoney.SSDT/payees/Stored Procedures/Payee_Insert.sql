CREATE PROCEDURE [payees].[Payee_Insert]
    @payeeUid UNIQUEIDENTIFIER,
	@name VARCHAR(MAX)
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
                ([Uid])
        VALUES (@payeeUid);

		DECLARE @_payeeId BIGINT = SCOPE_IDENTITY();

		EXEC	[payees].[_SetPayeeRevision] @_payeeId, @name;

		EXEC	[payees].[Payee_GetByUid] @payeeUid;


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
