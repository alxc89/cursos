DROP TABLE [Aluno]
GO
CREATE TABLE [Aluno] (
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATETIME NULL,
    [ACTIVE] BIT NOT NULL DEFAULT(0),

    --Exemplo sem nomear a constraint   
    --PRIMARY KEY([Id]) --Informando qual é a chave primaria.
    --Exemplo chave composta: 
    --PRIMARY KEY([Id], [Email])
    --Exemplo Nomeando a constraint
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),

    --Exemplo Nomeando uma UNIQUE
    CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email])
)
GO

--Exemplo com alter table
ALTER TABLE [Aluno]
    ADD PRIMARY KEY([Id])
GO
--Exemplo de como Dropar CONSTRAINT
ALTER TABLE [Aluno]
    DROP CONSTRAINT [PK_Aluno]