CREATE PROCEDURE [entries].[_SetEntryStatus]
	@id BIGINT,
	@date DATETIMEOFFSET,
	@isCleared BIT,
	@isActive BIT
AS
BEGIN
	INSERT INTO
			[entries].[EntryStatusChange]
			([EntryId], [Date], [IsCleared], [IsActive])
	VALUES	(@id, @date, @isCleared, @isActive);
END;
