CREATE PROCEDURE [accounts].[AccountGroup_GetByUid]
	@groupUid UNIQUEIDENTIFIER
AS
BEGIN;
	SELECT	[Uid]
            , [Id]
			, [Name]
	FROM	[accounts].[AccountGroup_View]
	WHERE	[Uid] = @groupUid;
END;
