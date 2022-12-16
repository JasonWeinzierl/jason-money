CREATE PROCEDURE [categories].[_SetCategoryRevision]
	@id INT,
	@accountId UNIQUEIDENTIFIER,
	
	@name NVARCHAR(4000),
	@subname NVARCHAR(4000) NULL
AS
BEGIN
	INSERT INTO
			[categories].[CategoryRevision]
			([CategoryId], [AccountId], [Name], [Subname])
	VALUES	(@id, @accountId, @name, @subname);
END;
