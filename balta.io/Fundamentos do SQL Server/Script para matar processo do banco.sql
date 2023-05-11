USE [master];

DECLARE @kill VARCHAR(8000) = '';
SELECT @kill = @kill + 'kill ' + CONVERT(VARCHAR(5), SESSION_ID) + ';'
FROM SYS.dm_exec_sessions
WHERE database_id = db_id('Curso')
DROP DATABASE [Curso]

EXEC(@kill)
DROP DATABASE [Curso]