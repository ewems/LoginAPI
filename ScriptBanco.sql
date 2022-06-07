CREATE DATABASE CADASTRO
GO

USE CADASTRO
GO

CREATE TABLE USUARIO 
(
	NOME VARCHAR(50) ,
	DTNASC SMALLDATETIME,
	CPF VARCHAR(11) PRIMARY KEY,
	NATURAL VARCHAR(20), 
	UF VARCHAR(2),
	TEL VARCHAR(11),
	EMAIL VARCHAR(50),

	CONSTRAINT USUARIO_NOME_CONTEUDO CHECK (NOME NOT LIKE '%[^a-z ]%'),
	CONSTRAINT USUARIO_DTNASC CHECK (ISDATE(DTNASC) = 1),
	CONSTRAINT USUARIO_CPF_CONTEUDO CHECK (CPF NOT LIKE '%[^0-9]%'),
	CONSTRAINT USUARIO_CPF_TAMANHO CHECK (LEN(CPF) = 11),
	CONSTRAINT USUARIO_NATURAL_CONTEUDO CHECK (NATURAL NOT LIKE '%[^a-z ]%'),
	CONSTRAINT USUARIO_UF_CONTEUDO CHECK 
	(
		UF IN ('AC','AL','AM','AP','BA','CE','DF','ES','GO','MA','MG','MS','MT',
			   'PA','PB','PE','PI','PR','RJ','RN','RR','RS','SC','SE','SP','TO')
	),
	CONSTRAINT USUARIO_TEL_CONTEUDO CHECK (TEL NOT LIKE '%[^0-9]%'),
	CONSTRAINT USUARIO_TEL_TAMANHO CHECK (LEN(TEL) IN (10,11)),
	CONSTRAINT USUARIO_EMAIL_CONTEUDO CHECK 
	( 
		(EMAIL NOT LIKE '%[^a-z0-9.@]%') AND 
		(LEFT(EMAIL,1) <> '@') AND 
		(RIGHT(EMAIL,1) <> '.') AND 
		(CHARINDEX('.',EMAIL,CHARINDEX('@',EMAIL)) - CHARINDEX('@',EMAIL) > 1) AND 
		(LEN(EMAIL) - LEN(REPLACE(EMAIL,'@','')) = 1)	AND 
		(CHARINDEX('.',REVERSE(EMAIL)) >= 3) AND 
		(CHARINDEX('.@',EMAIL) = 0) AND 
		(CHARINDEX('..',EMAIL) = 0)
	)

)
GO

CREATE TABLE LOGIN
(
	CODUSU INT IDENTITY,
	USERNAME VARCHAR(15),
	PASSWORD VARCHAR(15),
	CPF VARCHAR(11) PRIMARY KEY,
	CONSTRAINT FK_CPF FOREIGN KEY (CPF) REFERENCES USUARIO(CPF),

	CONSTRAINT UK_USERNAME UNIQUE(USERNAME),
	CONSTRAINT LOGIN_USERNAME_CONTEUDO CHECK (USERNAME NOT LIKE '%[^a-z0-9.]%'),
	CONSTRAINT LOGIN_USERNAME_TAMANHO CHECK (LEN(USERNAME) > 5),
	CONSTRAINT LOGIN_PASSWORD_CONTEUDO CHECK (PASSWORD NOT LIKE '%[^a-z0-9.!@]%'),
	CONSTRAINT LOGIN_PASSWORD_TAMANHO CHECK (LEN(PASSWORD) > 7)
)
GO

CREATE PROCEDURE cadastraUSUARIO_V1 
	@NOME VARCHAR(51),
	@DTNASC SMALLDATETIME,
	@CPF VARCHAR(12),
	@NATURAL VARCHAR(21),
	@UF VARCHAR(3),
	@TEL VARCHAR(12),
	@EMAIL VARCHAR(51),
	@USERNAME VARCHAR(16),
	@PASSWORD VARCHAR(16)

WITH ENCRYPTION

	AS BEGIN

		INSERT INTO USUARIO (NOME,DTNASC,CPF,NATURAL,UF,TEL,EMAIL) VALUES (@NOME,@DTNASC,@CPF,@NATURAL,@UF,@TEL,@EMAIL)

		INSERT INTO LOGIN (USERNAME,PASSWORD,CPF) VALUES (@USERNAME,@PASSWORD,@CPF)

		IF (SELECT COUNT (@CPF) FROM LOGIN) = 0
		BEGIN
			DELETE FROM USUARIO WHERE CPF = @CPF
		END

	END
GO

CREATE PROCEDURE verificaLOGIN_V1
	@USERNAME VARCHAR(15),
	@PASSWORD VARCHAR(15),
	@ERRO INT OUTPUT 

	WITH ENCRYPTION

	AS BEGIN

		DECLARE @QTD INT

		SET @ERRO = 0
		SET @QTD = (SELECT COUNT(*) FROM LOGIN WHERE USERNAME = @USERNAME)
	
		IF @QTD = 0
		BEGIN
			SET @ERRO = 1
			RETURN
		END


		IF @PASSWORD != (SELECT PASSWORD FROM LOGIN WHERE USERNAME = @USERNAME)
		BEGIN
			SET @ERRO = 2
			RETURN
		END

	END
GO

