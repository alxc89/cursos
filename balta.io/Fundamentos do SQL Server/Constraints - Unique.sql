DROP TABLE [Aluno]
GO
CREATE TABLE [Aluno] (
    [Id] INT NOT NULL UNIQUE, -- Unique para garantir valor único.
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL UNIQUE,
    [Nascimento] DATETIME NULL,
    [ACTIVE] BIT
)
GO