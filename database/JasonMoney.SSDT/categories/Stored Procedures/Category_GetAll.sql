CREATE PROCEDURE [categories].[Category_GetAll]
AS
BEGIN
	SELECT	[Uid]
            , [Id]
			, [Name]
			, [Subname]
	FROM	[categories].[Category_View]
    ORDER BY
            [Name]
            , [Subname];
END;
