CREATE PROCEDURE [entries].[Entry_UpdateStatus]
	@entryUid UNIQUEIDENTIFIER,
	@date DATETIMEOFFSET,
	@isCleared BIT,
	@isActive BIT
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_entryId INT = (SELECT [Id] FROM [entries].[Entry] WHERE [Uid] = @entryUid);
    IF @_entryId IS NULL
    BEGIN
		;THROW 50002, 'The entry does not exist', 1;
	END;

	EXEC	[entries].[_SetEntryStatus] @_entryId, @date, @isCleared, @isActive;

	EXEC	[entries].[EntryTransaction_GetByEntryUid] @entryUid;
END;
