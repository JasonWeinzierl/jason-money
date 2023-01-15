CREATE PROCEDURE [accounts].[AccountGroup_Update]
	@groupUid UNIQUEIDENTIFIER,
    @name NVARCHAR(4000)
AS
BEGIN;
    SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_groupId INT = (SELECT [Id] FROM [accounts].[AccountGroup] WHERE [Uid] = @groupUid);
    IF @_groupId IS NULL
    BEGIN
        ;THROW 50002, 'The account group does not exist.', 1;
    END;

    EXEC    [accounts].[_SetGroupRevision] @_groupId, @name;

    EXEC    [accounts].[AccountGroup_GetByUid] @groupUid;
END;
