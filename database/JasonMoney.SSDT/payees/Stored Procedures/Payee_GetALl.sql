CREATE PROCEDURE [payees].[Payee_GetAll]
AS
BEGIN;
	SELECT	[Uid]
            , [Id]
			, [Name]
	FROM	[payees].[Payee_View]
    ORDER BY
            [Name];
END;
