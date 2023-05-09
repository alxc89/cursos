ALTER TABLE [Aluno] 
    ADD [Document] NVARCHAR(11) --Alterando uma tabela incluindo um novo campo.

ALTER TABLE [Aluno] 
    DROP COLUMN [Document] -- Alterando uma tabela excluindo um campo especifico

ALTER TABLE [Aluno] 
    ALTER COLUMN [Document] CHAR(11) -- Alterando a tabela, alterando o tipo de dado de um campo especifico