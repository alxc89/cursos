DROP TABLE [Aluno]
CREATE TABLE [Aluno] (
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Nascimento] DATETIME NULL,
    [ACTIVE] BIT
)

GO

ALTER TABLE [Aluno]
    ALTER COLUMN [ACTIVE] BIT NOT NULL