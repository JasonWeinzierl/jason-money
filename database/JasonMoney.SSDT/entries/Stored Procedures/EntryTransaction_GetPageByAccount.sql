CREATE PROCEDURE [entries].[EntryTransaction_GetPageByAccount]
	@accountId UNIQUEIDENTIFIER,
	@skip INT,
	@take INT
AS
BEGIN
	SELECT	[EntryId]
			, [Date]
			, et.[AccountId]

			, [PayeeId]
			, p.[Name] AS PayeeName

			, [TransferAccountId]
			
			, [StatusDate]
			, [IsCleared]
			, [IsActive]

			, [CategoryId]
			, c.[AccountId] AS CategoryAccountId
			, c.[Name] AS CategoryName
			, c.[Subname] AS CategorySubname

			, [TransactionId]
			, [Amount]
			, [CurrencyCode]
			, [Memo]
	FROM	[entries].[EntryTransaction_View] et LEFT JOIN
			[categories].[Category_View] c ON c.[Id] = et.[CategoryId] LEFT JOIN
			[payees].[Payee_View] p ON p.[Id] = et.[PayeeId]
	WHERE	et.[AccountId] = @accountId
			OR et.[TransferAccountId] = @accountId
	ORDER BY [Date]
	OFFSET @skip ROWS
	FETCH NEXT @take ROWS ONLY;
END;
