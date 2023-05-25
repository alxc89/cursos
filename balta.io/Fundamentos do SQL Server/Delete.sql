SELECT *
  FROM [Categoria]


--BEGIN TRANSACTION abre uma transação no banco de dados, e no fim é colocado COMMIT para persistir os dados no banco, ou ROLLBACK para não persistir os dados
BEGIN TRANSACTION
    DELETE FROM 
        [Categoria]
    WHERE
        [Id] = 3
SELECT *
  FROM [Categoria]
ROLLBACK