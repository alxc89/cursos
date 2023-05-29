SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] as [Categoria],
    [Categoria].[Nome]
FROM 
    [Curso]
     /*O INNER JOIN é utilizado para juntar de uma tabela que também esteja em outra, para isso é utilizado o ON para relacionar uma tabela a outra a partir de uma coluna, 
       sempre se possível utilizar PK com FK das tabelas relacionadas.*/
    INNER JOIN [Categoria] 
        ON [Curso].[CategoriaId] = [Categoria].[Id]