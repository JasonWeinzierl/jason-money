CREATE VIEW [accounts].[AccountGroup_View]
AS
WITH LatestGroupName AS (
	SELECT	[GroupId]
			, MAX([Id]) AS [NameId]
	FROM	[accounts].[AccountGroupRevision]
	GROUP BY
			[GroupId]
)
SELECT	g.[Uid]
        , g.[Id]
		, rev.[Name]
FROM	[accounts].[AccountGroup] g JOIN
		[accounts].[AccountGroupRevision] rev ON rev.[GroupId] = g.[Id] JOIN
		LatestGroupName latestN ON latestN.NameId = rev.[Id];
