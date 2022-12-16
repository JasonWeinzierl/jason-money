CREATE PROCEDURE [entries].[Entry_UpdateStatus]
	@id BIGINT,
	@date DATETIMEOFFSET,
	@isCleared BIT,
	@isActive BIT
AS
BEGIN
		EXEC	[entries].[_SetEntryStatus] @id, @date, @isCleared, @isActive;

		EXEC	[entries].[EntryTransaction_GetByEntryId] @id;
END;
