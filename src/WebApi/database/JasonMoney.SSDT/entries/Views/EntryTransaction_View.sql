CREATE VIEW [entries].[EntryTransaction_View]
AS
WITH LatestEntryRevision AS (
	SELECT	MAX([Id]) AS RevisionId
	FROM	[entries].[EntryRevision]
	GROUP BY
			[EntryId]
),
LatestEntryStatusChange AS (
	SELECT	MAX([Id]) AS StatusChangeId
	FROM	[entries].[EntryStatusChange]
	GROUP BY
			[EntryId]
)
SELECT	[e].[Uid] AS EntryUid
        , [e].[Id] AS EntryId
		, [rev].[Date]
		, [rev].[AccountId]
		, [rev].[PayeeId]
		, [rev].[TransferAccountId]

		, [sc].[IsCleared]
		, [sc].[IsActive]

		, [t].[Id] AS TransactionId
		, [t].[CategoryId]
		, [t].[Amount]
		, [t].[Memo]
FROM	[entries].[Entry] e JOIN
		[entries].[EntryRevision] rev ON rev.[EntryId] = e.[Id] JOIN
		LatestEntryRevision latestRev ON latestRev.RevisionId = rev.[Id] JOIN
		[entries].[EntryTransaction] t ON t.[EntryRevisionId] = rev.[Id] JOIN

		[entries].[EntryStatusChange] sc ON sc.[EntryId] = e.[Id] JOIN
		LatestEntryStatusChange latestSc ON latestSc.StatusChangeId = sc.[Id];
