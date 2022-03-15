CREATE DATABASE BDServico
GO

USE BDServico
GO

CREATE TABLE LimiteCliente(
	codigoCliente INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	nomeCliente VARCHAR (200) NOT NULL,
	valorLimite FLOAT NOT NULL,
)
GO

INSERT INTO LimiteCliente(nomeCliente, valorLimite)
VALUES
	('Maria', 1500),
	('João', 4500),
	('Laura', 40000),
	('Pedro', 650),
	('Carlos', 100),
	('Miguel', 1863),
	('Paloma', 7320),
	('Jorge', 402),
	('Luiz', 4812),
	('Rafael', 893)
GO