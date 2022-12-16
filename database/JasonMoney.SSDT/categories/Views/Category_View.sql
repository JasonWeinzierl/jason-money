CREATE VIEW [categories].[Category_View]
AS
WITH LatestCategoryRevision AS (
	SELECT	MAX([Id]) AS RevisionId
	FROM	[categories].[CategoryRevision]
	GROUP BY
			[CategoryId]
)
SELECT	[c].[Id]
		, [rev].[AccountId]
		, [rev].[Name]
		, [rev].[Subname]
FROM	[categories].[Category] c JOIN
		[categories].[CategoryRevision] rev ON rev.[CategoryId] = c.[Id] JOIN
		LatestCategoryRevision latestRev ON latestRev.RevisionId = rev.[Id];
