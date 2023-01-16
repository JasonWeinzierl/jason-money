CREATE PROCEDURE [payees].[_SetPayeeRevision]
	@payeeId BIGINT,
	@name VARCHAR(MAX)
AS
BEGIN;
	INSERT INTO
			[payees].[PayeeRevision]
			([PayeeId], [Name])
	VALUES	(@payeeId, @name);
END;
