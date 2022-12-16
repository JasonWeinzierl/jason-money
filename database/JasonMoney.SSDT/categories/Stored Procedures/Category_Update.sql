CREATE PROCEDURE [categories].[Category_Update]
	@id INT,
	@accountId UNIQUEIDENTIFIER,
	
	@name NVARCHAR(4000),
	@subname NVARCHAR(4000) NULL
AS
BEGIN
	EXEC	[categories].[_SetCategoryRevision] @id, @accountId, @name, @subname;

	EXEC	[categories].[Category_GetById] @id;
END;
