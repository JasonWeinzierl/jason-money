CREATE PROCEDURE [accounts].[AccountGroup_GetAll]
AS
BEGIN;
    SELECT  [Uid]
            , [Id]
            , [Name]
    FROM    [accounts].[AccountGroup_View];
END;
