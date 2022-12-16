CREATE PROCEDURE [accounts].[Account_Delete]
	@id UNIQUEIDENTIFIER,
	@dateClosed DATETIMEOFFSET
AS
BEGIN
	INSERT INTO
			[accounts].[AccountClosure]
			([AccountId], [DateClosed])
	VALUES	(@id, @dateClosed);
END;
