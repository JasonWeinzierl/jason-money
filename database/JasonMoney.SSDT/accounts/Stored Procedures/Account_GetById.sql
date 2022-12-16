CREATE PROCEDURE [accounts].[Account_GetById]
	@id UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	a.[Id]

			, a.[Name]

			, a.[GroupId]
			, g.[Name] AS GroupName

			, a.[BankSwift]
			, a.[ExternalId]
			, a.[CurrencyCode]
			, a.[Description]
	FROM	[accounts].[Account_View] a JOIN
			[accounts].[AccountGroup_View] g ON g.[Id] = a.[GroupId]
	WHERE	a.[Id] = @id;
END;
