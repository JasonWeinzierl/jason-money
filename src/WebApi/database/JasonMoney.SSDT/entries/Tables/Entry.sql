﻿CREATE TABLE [entries].[Entry]
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Entry PRIMARY KEY,
    [Uid] UNIQUEIDENTIFIER NOT NULL CONSTRAINT UK_Entry_Uid UNIQUE,
    [DateCreated] DATETIMEOFFSET NOT NULL CONSTRAINT DF_Entry_DateCreated DEFAULT SYSDATETIMEOFFSET(),
);
