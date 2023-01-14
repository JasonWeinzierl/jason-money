CREATE PROCEDURE [accounts].[AccountGroup_GetByUid]
	@groupUid UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Id]
			, [Name]
	FROM	[accounts].[AccountGroup_View]
	WHERE	[Uid] = @groupUid;
END;
