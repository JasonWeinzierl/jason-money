CREATE PROCEDURE [entries].[_SetEntryStatus]
	@entryId BIGINT,
	@isCleared BIT,
	@isActive BIT
AS
BEGIN
	INSERT INTO
			[entries].[EntryStatusChange]
			([EntryId], [IsCleared], [IsActive])
	VALUES	(@entryId, @isCleared, @isActive);
END;
