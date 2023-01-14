CREATE PROCEDURE [accounts].[Account_Delete]
	@accountUid UNIQUEIDENTIFIER,
	@dateClosed DATETIMEOFFSET
AS
BEGIN
	INSERT INTO
			[accounts].[AccountClosure]
			([AccountId], [DateClosed])
    SELECT  [Id]
            , @dateClosed
    FROM    [accounts].[Account]
    WHERE   [Uid] = @accountUid;
END;
