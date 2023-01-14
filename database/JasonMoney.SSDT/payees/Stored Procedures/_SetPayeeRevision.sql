CREATE PROCEDURE [payees].[_SetPayeeRevision]
	@payeeId BIGINT,
	@name NVARCHAR(MAX)
AS
BEGIN;
	INSERT INTO
			[payees].[PayeeRevision]
			([PayeeId], [Name])
	VALUES	(@payeeId, @name);
END;
