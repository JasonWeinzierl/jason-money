CREATE PROCEDURE [accounts].[Account_Insert]
	@id UNIQUEIDENTIFIER,

	@name NVARCHAR(4000),
	@groupId INT NULL,
	@bankSwift CHAR(11) NULL,
	@externalId NVARCHAR(MAX) NULL,
	@currencyCode CHAR(3),
	@description NVARCHAR(MAX) NULL
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
				[accounts].[Account]
				([Id])
		VALUES	(@id);

		EXEC	[accounts].[_SetAccountRevision] @id, @name, @groupId, @bankSwift, @externalId, @currencyCode, @description;

		EXEC	[accounts].[Account_GetById] @id;

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
