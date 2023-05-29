SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] as [Categoria],
    [Categoria].[Nome]
FROM 
    [Curso]
    /*O LEFT JOIN é utilizado para juntar uma tabela a outra, e sempre será pego todos os itens da tabela da esquerda, da primeira tabela, que no caso do exemplo será a tabela [Curso],
      se não existir na tabela da direita, será trago o valor nullo*/
    LEFT JOIN [Categoria] 
        ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] as [Categoria],
    [Categoria].[Nome]
FROM 
    [Curso]
    /*O RIGHT JOIN é utilizado para juntar uma tabela a outra, e sempre será pego todos os itens da tabela da direita, que no caso do exemplo será a tabela [Categoria],
      se não existir na tabela da esquerda, será trago o valor nullo*/
    RIGHT JOIN [Categoria] 
        ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] as [Categoria],
    [Categoria].[Nome]
FROM 
    [Curso]
    /*O FULL JOIN sempre vai trazer tudo das duas tabelas, vai juntar as duas praticamente*/
    FULL JOIN [Categoria] 
        ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] as [Categoria],
    [Categoria].[Nome]
FROM 
    [Curso]
    /*O FULL OUTER JOIN sempre vai trazer tudo das duas tabelas, vai juntar as duas praticamente*/
    FULL OUTER JOIN [Categoria] 
        ON [Curso].[CategoriaId] = [Categoria].[Id]