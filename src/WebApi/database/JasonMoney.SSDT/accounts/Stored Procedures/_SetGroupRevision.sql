CREATE PROCEDURE [accounts].[_SetGroupRevision]
	@groupId INT,
	@name VARCHAR(4000)
AS
BEGIN
	INSERT INTO
			[accounts].[AccountGroupRevision]
			([GroupId], [Name])
	VALUES	(@groupId, @name);
END;
