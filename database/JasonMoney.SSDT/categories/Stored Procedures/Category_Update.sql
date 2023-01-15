CREATE PROCEDURE [categories].[Category_Update]
	@categoryUid UNIQUEIDENTIFIER,
	
	@name NVARCHAR(4000),
	@subname NVARCHAR(4000) NULL
AS
BEGIN
	SET XACT_ABORT, NOCOUNT ON;

    DECLARE @_categoryId INT = (SELECT [Id] FROM [categories].[Category] WHERE [Uid] = @categoryUid);
    IF @_categoryId IS NULL
    BEGIN;
        RETURN 0;
	END;

	EXEC	[categories].[_SetCategoryRevision] @_categoryId, @name, @subname;

	EXEC	[categories].[Category_GetByUid] @categoryUid;

END;
