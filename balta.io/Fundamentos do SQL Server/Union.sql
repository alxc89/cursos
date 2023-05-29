    SELECT TOP 100
        [Id], [Nome]
    FROM 
        [Curso]
UNION --É utilizado para unir as tabelas, as colunas que serão mostradas tem que ter os mesmos tipos de dados, caso uma das tabelas não tenha o mesmo tipo de dados, ex: inteiro e varchar, retornará erro
    SELECT TOP 100
        [Id], [Nome] 
    FROM 
        [Categoria]

    SELECT TOP 100
        [Id], [Nome]
    FROM 
        [Curso]
UNION ALL --O UNION ALL é bem parecido ao UNION, a diferença é que ele tenta realizar um distinct dos dados para não retornar informação repetida.
    SELECT TOP 100
        [Id], [Nome] 
    FROM 
        [Categoria]