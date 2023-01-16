CREATE PROCEDURE [accounts].[Account_GetAll]
AS
BEGIN
	SELECT	a.[Uid]
            , a.[Id]

			, a.[Name]
            
            , g.[Uid] AS GroupUid
			, a.[GroupId]
			, g.[Name] AS GroupName

			, a.[BankSwift]
			, a.[ExternalId]
			, a.[Description]
	FROM	[accounts].[Account_View] a LEFT JOIN
			[accounts].[AccountGroup_View] g ON g.[Id] = a.[GroupId]
	ORDER BY a.[Name];
END;
