CREATE VIEW [payees].[Payee_View]
AS
WITH LatestPayeeRevision AS (
	SELECT	MAX([Id]) AS RevisionId
	FROM	[payees].[PayeeRevision]
	GROUP BY
			[PayeeId]
)
SELECT	[p].[Id]
		, [rev].[PayerAccountId]
		, [rev].[Name]
FROM	[payees].[Payee] p JOIN
		[payees].[PayeeRevision] rev ON rev.[PayeeId] = p.[Id] JOIN
		LatestPayeeRevision latestRev ON latestRev.RevisionId = rev.[Id];
