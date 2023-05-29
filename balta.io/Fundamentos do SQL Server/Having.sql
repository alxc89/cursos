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
 Após a declaração do GROUP BY, não é possível utilizar a cláusula WHERE, mas podemos utilizar o HAVING, que resumindo seria, 
 todos os dados agrupados e que contém o que está escrito no HAVING
*/