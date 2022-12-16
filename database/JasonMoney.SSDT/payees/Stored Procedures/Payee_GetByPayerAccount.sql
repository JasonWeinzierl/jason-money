CREATE PROCEDURE [payees].[Payee_GetByPayerAccount]
	@accountId UNIQUEIDENTIFIER
AS
BEGIN;
	SELECT	[Id]
			, [PayerAccountId]
			, [Name]
	FROM	[payees].[Payee_View]
	WHERE	[PayerAccountId] = @accountId;
END;
