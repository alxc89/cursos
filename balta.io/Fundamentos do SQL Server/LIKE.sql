--LIKE 'Fundamentos%' começa com Fundamentos
SELECT TOP 100
    *
FROM 
    [Curso]
WHERE
    [Nome]  LIKE 'Fundamentos%'

--LIKE '%Fundamentos' começa com Fundamentos
SELECT TOP 100
    *
FROM 
    [Curso]
WHERE
    [Nome]  LIKE '%Fundamentos'

--LIKE '%Fundamentos%' contém Fundamentos
SELECT TOP 100
    *
FROM 
    [Curso]
WHERE
    [Nome]  LIKE '%Fundamentos%'