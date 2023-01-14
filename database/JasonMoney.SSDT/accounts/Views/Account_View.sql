CREATE VIEW [accounts].[Account_View]
AS
WITH LatestAccountRevision AS (
	SELECT	MAX([Id]) AS RevisionId
	FROM	[accounts].[AccountRevision]
	GROUP BY
			[AccountId]
)
SELECT	[a].[Uid]
        , [a].[Id]
		, [rev].[Name]
		, [rev].[GroupId]
		, [rev].[BankSwift]
		, [rev].[ExternalId]
		, [rev].[CurrencyCode]
		, [rev].[Description]
FROM	[accounts].[Account] a JOIN
		[accounts].[AccountRevision] rev ON rev.[AccountId] = a.[Id] JOIN
		LatestAccountRevision latestRev ON latestRev.RevisionId = rev.[Id] LEFT JOIN
		[accounts].[AccountClosure] c ON c.[AccountId] = a.[Id]
WHERE	c.[DateClosed] IS NULL;
