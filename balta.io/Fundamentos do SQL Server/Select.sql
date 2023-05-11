--Exemplo de SELECT utilizando TOP 2, onde só trará 2 registros da base
SELECT TOP 2
    [Id], [Nome]
FROM [Curso]

--Exemplo de SELECT utilizando distinct, o distinct é utilizado para não trazer dados repetidos.
SELECT DISTINCT TOP 100
    [Nome]
FROM [Categoria]