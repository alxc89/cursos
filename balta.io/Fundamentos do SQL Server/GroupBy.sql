SELECT TOP 100
    [Categoria].[Nome] AS [Categoria],
    COUNT([Curso].[CategoriaId]) AS [Cursos]
FROM 
    [Categoria]
    INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
GROUP BY [Curso].[CategoriaId], [Categoria].[Nome]
/*GROUP BY é utilizado para agrupar dados, no exemplo dado, foi realizado a conta de todos os cursos de cada categoria.
  Nesse caso foi obrigatório utilizar o GROUP BY, porque o COUNT() agrupa informações, é uma função de agregação, 
  nesse exemplo, para cada coluna que queira mostrar no select, é obrigatório colocar no GROUP BY.
*/