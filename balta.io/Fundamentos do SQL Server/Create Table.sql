USE [Curso] --Seta qual banco vai ser rodado as instruções SQL.
CREATE TABLE [Aluno](
    [Id] INT,
    [Nome] NVARCHAR(80),
    [Nascimento] DATETIME,
    [Active] BIT,
) --Script para criação da tabela, com seus campos e tipos de dados.
GO --Segue para outra instrução, salvando a anterior.