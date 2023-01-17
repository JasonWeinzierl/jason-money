CREATE VIEW [accounts].[AccountGroup_View]
AS
WITH LatestGroupRevision AS (
	SELECT	MAX([Id]) AS RevisionId
	FROM	[accounts].[AccountGroupRevision]
	GROUP BY
			[GroupId]
)
SELECT	g.[Uid]
        , g.[Id]
		, rev.[Name]
FROM	[accounts].[AccountGroup] g JOIN
		[accounts].[AccountGroupRevision] rev ON rev.[GroupId] = g.[Id] JOIN
		LatestGroupRevision latestRev ON latestRev.RevisionId = rev.[Id];
