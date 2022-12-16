CREATE PROCEDURE [payees].[Payee_GetById]
	@id BIGINT
AS
BEGIN;
	SELECT	[Id]
			, [PayerAccountId]
			, [Name]
	FROM	[payees].[Payee_View]
	WHERE	[Id] = @id;
END;
