DELETE FROM [Student]
DELETE FROM [StudentCourse]

SELECT * FROM [Student]
SELECT * FROM [StudentCourse]
SELECT * FROM [Course]

DECLARE @studentId UNIQUEIDENTIFIER = (SELECT NEWID())
INSERT INTO 
    [Student]
VALUES (
    @studentId,
    'Alex',
    'alex@teste.com.br',
    '9999999',
    '17991999999',
    '1989-01-01',
    GETDATE()
)

INSERT INTO
    [StudentCourse]
VALUES (
    '5f5a33f8-4ff3-7e10-cc6e-3fa000000000',
    'd2ea654e-084f-4a14-a5d6-777fbcf5dfef',
    50,
    0,
    CONVERT(DATETIME, '2021-05-30', 121),
    GETDATE()
)