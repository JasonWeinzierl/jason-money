CREATE PROCEDURE [accounts].[Account_Insert]
	@accountUid UNIQUEIDENTIFIER,

	@name VARCHAR(4000),
	@groupUid UNIQUEIDENTIFIER NULL,
	@bankSwift CHAR(11) NULL,
	@externalId VARCHAR(MAX) NULL,
	@description VARCHAR(MAX) NULL
AS
BEGIN;
	SET XACT_ABORT, NOCOUNT ON;
    
    DECLARE @_groupId INT = NULL;
    IF @groupUid IS NOT NULL
    BEGIN;
        SELECT @_groupId = [Id] FROM [accounts].[AccountGroup] WHERE [Uid] = @groupUid;
	    IF @_groupId IS NULL
	    BEGIN
		    ;THROW 50002, 'The group does not exist.', 1;
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
				[accounts].[Account]
				([Uid])
		VALUES	(@accountUid);

        DECLARE @_accountId INT = SCOPE_IDENTITY();

		EXEC	[accounts].[_SetAccountRevision] @_accountId, @name, @_groupId, @bankSwift, @externalId, @description;

		EXEC	[accounts].[Account_GetByUid] @accountUid;


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
