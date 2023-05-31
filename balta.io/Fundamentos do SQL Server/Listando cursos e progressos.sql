DECLARE @StudentId UNIQUEIDENTIFIER = 'd2ea654e-084f-4a14-a5d6-777fbcf5dfef'
SELECT 
    [Course].[Title] AS [Course],
    [Student].[Name] AS [Student],
    [StudentCourse].[Progress],
    [StudentCourse].[LastUpdateDate]
FROM 
    [Course]
    LEFT JOIN [StudentCourse] ON [StudentCourse].[CourseId] = [Course].[Id]
    LEFT JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]