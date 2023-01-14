CREATE PROCEDURE [entries].[EntryTransaction_GetByEntryUid]
	@entryUid UNIQUEIDENTIFIER
AS
BEGIN
	SELECT	et.[EntryUid]
            , et.[EntryId]
			, et.[Date]
            , a.[Uid] AS AccountUid

            , p.[Uid] AS PayeeUid
			, et.[PayeeId]
			, p.[Name] AS PayeeName

            , atransfer.[Uid] AS TransferAccountUid

			, et.[StatusDate]
			, et.[IsCleared]
			, et.[IsActive]
			
			, et.[CategoryId]
			, c.[Name] AS CategoryName
			, c.[Subname] AS CategorySubname

			, et.[TransactionId]
			, et.[Amount]
			, et.[CurrencyCode]
			, et.[Memo]
	FROM	[entries].[EntryTransaction_View] et JOIN
            [accounts].[Account] a ON a.[Id] = et.[AccountId] LEFT JOIN
			[categories].[Category_View] c ON c.[Id] = et.[CategoryId] LEFT JOIN
			[payees].[Payee_View] p ON p.[Id] = et.[PayeeId] LEFT JOIN
            [accounts].[Account] atransfer ON atransfer.[Id] = et.[TransferAccountId]
	WHERE	[EntryUid] = @entryUid;
END;
