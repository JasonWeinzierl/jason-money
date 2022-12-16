CREATE PROCEDURE [accounts].[AccountGroup_GetById]
	@id INT
AS
BEGIN
	SELECT	[Id]
			, [Name]
	FROM	[accounts].[AccountGroup_View]
	WHERE	[Id] = @id;
END;
