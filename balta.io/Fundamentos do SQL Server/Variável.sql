CREATE OR ALTER PROCEDURE [spListCourse] 
    @Category NVARCHAR(60) --Parâmetro da procedure
AS 
    DECLARE @CategoryId INT --Declaração de uma variável
    SET @CategoryId = (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Nome] = @Category) --Atribuindo valor a variável

    SELECT TOP 100
        *
    FROM 
        [Curso]
    WHERE [CategoriaId] = @CategoryId


EXEC [spListCourse] 'Backend'
EXEC [spListCourse] 'Frontend'
EXEC [spListCourse] 'Flutter' --Executando uma varíavel.