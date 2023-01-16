CREATE PROCEDURE [accounts].[AccountGroup_Insert]
    @groupUid UNIQUEIDENTIFIER,
    @name NVARCHAR(4000)
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
                [accounts].[AccountGroup]
                ([Uid])
        VALUES  (@groupUid);

        DECLARE @_groupId INT = SCOPE_IDENTITY();

        EXEC    [accounts].[_SetGroupRevision] @_groupId, @name;

        EXEC    [accounts].[AccountGroup_GetByUid] @groupUid;


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
