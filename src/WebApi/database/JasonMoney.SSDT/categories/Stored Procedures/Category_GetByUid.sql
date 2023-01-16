CREATE PROCEDURE [categories].[Category_GetByUid]
	@categoryUid UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Uid]
			, [Id]
			, [Name]
			, [Subname]
	FROM	[categories].[Category_View]
	WHERE	[Uid] = @categoryUid;
END;
