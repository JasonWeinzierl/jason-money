CREATE PROCEDURE [accounts].[AccountGroup_Update]
	@groupUid UNIQUEIDENTIFIER,
    @name VARCHAR(4000)
AS
BEGIN;
    SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_groupId INT = (SELECT [Id] FROM [accounts].[AccountGroup] WHERE [Uid] = @groupUid);
    IF @_groupId IS NULL
    BEGIN;
        RETURN 0;
    END;

    EXEC    [accounts].[_SetGroupRevision] @_groupId, @name;

    EXEC    [accounts].[AccountGroup_GetByUid] @groupUid;
END;
