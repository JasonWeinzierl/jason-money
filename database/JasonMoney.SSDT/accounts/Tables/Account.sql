CREATE TABLE [accounts].[Account]
(
	[Id] UNIQUEIDENTIFIER NOT NULL CONSTRAINT PK_Account PRIMARY KEY,
	--CONSTRAINT CK_Account_Slug_Alphanumeric CHECK (dbo.IsAlphanumeric([Slug]) = 1),
);
