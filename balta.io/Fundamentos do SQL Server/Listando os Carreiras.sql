CREATE OR ALTER VIEW vwCareer AS
SELECT 
    [Id],
    [Career].[Title],
    [Url],
    COUNT([Id])AS Total
FROM 
    [Career]
    INNER JOIN [CareerItem] ON [CareerItem].[CareerId] = [Career].[Id]
GROUP BY
    [Career].[Id],
    [Career].[Title], 
    [Url]