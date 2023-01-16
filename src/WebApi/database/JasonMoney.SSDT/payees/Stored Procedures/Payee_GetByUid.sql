CREATE PROCEDURE [payees].[Payee_GetByUid]
	@payeeUid UNIQUEIDENTIFIER
AS
BEGIN;
	SELECT	[Uid]
            , [Id]
			, [Name]
	FROM	[payees].[Payee_View]
	WHERE	[Uid] = @payeeUid;
END;
