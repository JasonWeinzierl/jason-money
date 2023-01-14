CREATE PROCEDURE [entries].[_SetEntryStatus]
	@entryId BIGINT,
	@date DATETIMEOFFSET,
	@isCleared BIT,
	@isActive BIT
AS
BEGIN
	INSERT INTO
			[entries].[EntryStatusChange]
			([EntryId], [Date], [IsCleared], [IsActive])
	VALUES	(@entryId, @date, @isCleared, @isActive);
END;
