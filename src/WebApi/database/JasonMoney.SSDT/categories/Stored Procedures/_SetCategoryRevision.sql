CREATE PROCEDURE [categories].[_SetCategoryRevision]
	@categoryId INT,
	
	@name VARCHAR(4000),
	@subname VARCHAR(4000) NULL
AS
BEGIN
	INSERT INTO
			[categories].[CategoryRevision]
			([CategoryId], [Name], [Subname])
	VALUES	(@categoryId, @name, @subname);
END;
