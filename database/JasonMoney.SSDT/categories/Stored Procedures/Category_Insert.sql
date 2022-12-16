CREATE PROCEDURE [categories].[Category_Insert]
	@accountId UNIQUEIDENTIFIER,
	
	@name NVARCHAR(4000),
	@subname NVARCHAR(4000) NULL
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
				[categories].[Category]
		DEFAULT VALUES;

		DECLARE @_categoryId INT = SCOPE_IDENTITY();

		EXEC	[categories].[_SetCategoryRevision] @_categoryId, @accountId, @name, @subname;

		EXEC	[categories].[Category_GetById] @_categoryId;

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
