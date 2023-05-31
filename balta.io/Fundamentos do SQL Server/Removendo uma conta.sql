CREATE OR ALTER PROCEDURE spStudentProgress(@StudentId UNIQUEIDENTIFIER)
AS
SELECT 
    [Student].[Name] AS [Student],
    [Course].[Title] AS [Course],
    [StudentCourse].[Progress],
    [StudentCourse].[LastUpdateDate]
FROM 
    [StudentCourse]
    INNER JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]
    INNER JOIN [Course] ON [StudentCourse].[CourseId] = [Course].[Id]
WHERE
    [StudentCourse].[StudentId] = @StudentId
    AND [StudentCourse].[Progress] < 100
    AND [StudentCourse].[Progress] > 0
ORDER BY
    [StudentCourse].[LastUpdateDate] DESC

GO

CREATE OR ALTER PROCEDURE spDeleteStudent(@StudentId UNIQUEIDENTIFIER)
AS
BEGIN TRANSACTION
    DELETE FROM
        [StudentCourse]
    WHERE 
        [StudentId] = @StudentId

    DELETE FROM
        [Student]
    WHERE 
        [Id] = @StudentId
COMMIT

--Executando a procedure
EXEC spStudentProgress 'd2ea654e-084f-4a14-a5d6-777fbcf5dfef'
EXEC spDeleteStudent 'd2ea654e-084f-4a14-a5d6-777fbcf5dfef'