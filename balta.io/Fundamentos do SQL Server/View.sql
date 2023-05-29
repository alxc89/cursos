CREATE OR ALTER VIEW vwContagemCursosCategoria AS
    SELECT TOP 100
        [Categoria].[Nome] AS [Categoria],
        COUNT([Curso].[CategoriaId]) AS [Cursos]
    FROM 
        [Categoria]
        INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
    GROUP BY [Curso].[CategoriaId], [Categoria].[Nome]
    HAVING 
        COUNT([Curso].[CategoriaId]) > 1
/*
  A view é criar para armazenar uma consulta no banco dados, uma observação importante, não utilizar ORDER BY, que provavelmente retornará erro, 
  e quando necessário realizar um select nessa é feito conforme exemplo abaixo:
  SELECT * FROM vwContagemCursosCategoria WHERE [Cursos] = 2
*/