CREATE DATABASE [Cursos]
GO
USE [Cursos]
GO
CREATE TABLE [Categoria]
(
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id]) --Chave primaria simples
)
GO
CREATE TABLE [Curso]
(
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,

    --Exemplo de Chave primaria simples
    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    --Exemplo de chave estrangeira, e referenciando a tabela e seu respectivo campo.
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])
        REFERENCES [Categoria]([Id])
)
GO

--Começa aqui--

INSERT INTO [Categoria]([Nome]) VALUES('Backend')
INSERT INTO [Categoria]([Nome]) VALUES('Frontend')
INSERT INTO [Categoria]([Nome]) VALUES('Mobile')
GO
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos de C#', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos OOP', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Angular', 2)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Flutter', 3)
--Exemplo com forma resumida, os campos para serem inseridos precisam seguir a ordem que está na tabela.
INSERT INTO [Curso] VALUES('Flutter e SQLit', 3)