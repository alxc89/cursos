--Blocos de ifs para facilitar o DROP da tabelas
if(exists(SELECT top 1 * FROM SYS.tables WHERE SYS.tables.name = 'Curso'))
    DROP TABLE [Curso]
GO
if(exists(SELECT top 1 * FROM SYS.tables WHERE SYS.tables.name = 'Categoria'))
    DROP TABLE [Categoria]
GO
if(exists(SELECT top 1 * FROM SYS.tables WHERE SYS.tables.name = 'ProgressoCurso'))
    DROP TABLE [ProgressoCurso]
GO
CREATE TABLE [Categoria]
(
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id]) --Chave primaria simples
)
GO
CREATE TABLE [Curso]
(
    [Id] INT NOT NULL IDENTITY(1, 1), -- Ou UNIQUEIDENTIFIER NOT NULL
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,

    --Exemplo de Chave primaria simples
    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    --Exemplo de chave estrangeira, e referenciando a tabela e seu respectivo campo.
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])
        REFERENCES [Categoria]([Id])
)
GO
CREATE TABLE [ProgressoCurso]
(
    [AlunoId] INT NOT NULL,
    [CursoId] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE()),
    --Exemplo de Chave primaria composta.
    CONSTRAINT PK_ProgressoCurso PRIMARY KEY([AlunoId], [CursoId])
)
GO

