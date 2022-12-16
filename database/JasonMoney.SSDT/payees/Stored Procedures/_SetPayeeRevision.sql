CREATE PROCEDURE [payees].[_SetPayeeRevision]
	@id BIGINT,
	@payerAccountId UNIQUEIDENTIFIER,
	@name NVARCHAR(MAX)
AS
BEGIN;
	INSERT INTO
			[payees].[PayeeRevision]
			([PayeeId], [PayerAccountId], [Name])
	VALUES	(@id, @payerAccountId, @name);
END;
