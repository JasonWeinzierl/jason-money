CREATE PROCEDURE [categories].[Category_GetByAccount]
	@accountId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	[Id]
			, [AccountId]
			, [Name]
			, [Subname]
	FROM	[categories].[Category_View]
	WHERE	[AccountId] = @accountId;
END;
