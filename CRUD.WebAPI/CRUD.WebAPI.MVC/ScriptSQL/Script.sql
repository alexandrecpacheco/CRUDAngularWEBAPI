use CRUDChallenge
GO 
IF OBJECT_ID('DBO.Profissoes') IS NOT NULL
BEGIN 
	INSERT INTO Profissoes (Profession) VALUES ('Programador')
	INSERT INTO Profissoes (Profession) VALUES ('Analista')
	INSERT INTO Profissoes (Profession) VALUES ('Gerente')
	INSERT INTO Profissoes (Profession) VALUES ('Estagiario')
	INSERT INTO Profissoes (Profession) VALUES ('QA')
	PRINT 'PROFISSOES INCLUIDAS COM SUCESSO'
END
ELSE
BEGIN
	PRINT 'PROFISSOES JA EXISTEM'
END

