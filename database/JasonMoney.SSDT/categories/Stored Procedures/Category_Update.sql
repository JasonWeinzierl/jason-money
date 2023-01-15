CREATE PROCEDURE [categories].[Category_Update]
	@categoryUid UNIQUEIDENTIFIER,
	
	@name NVARCHAR(4000),
	@subname NVARCHAR(4000) NULL
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_categoryId INT = (SELECT [Id] FROM [categories].[Category] WHERE [Uid] = @categoryUid);
    IF @_categoryId IS NULL
    BEGIN
		;THROW 50002, 'The category does not exist.', 1;
	END;

	EXEC	[categories].[_SetCategoryRevision] @_categoryId, @name, @subname;

	EXEC	[categories].[Category_GetByUid] @categoryUid;

END;
