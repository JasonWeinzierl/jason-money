CREATE PROCEDURE [categories].[Category_GetById]
	@id INT
AS
BEGIN
	SELECT	[Id]
			, [AccountId]
			, [Name]
			, [Subname]
	FROM	[categories].[Category_View]
	WHERE	[Id] = @id;
END;
