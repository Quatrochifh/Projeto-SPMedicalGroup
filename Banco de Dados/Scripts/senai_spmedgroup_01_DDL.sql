CREATE DATABASE Medical_Senai; 
GO

USE Medical_Senai;
GO

--------------------------------- DDL ---------------------------------

CREATE TABLE tipoUsuario
(
	IDTipoUsuario INT PRIMARY KEY IDENTITY,
	PerfisDeUsuario VARCHAR(50) NOT NULL
);
GO --Tabela Criada

CREATE TABLE Especialidade
(
		IDEspecialidade INT PRIMARY KEY IDENTITY,
		NomeEspecialidade VARCHAR (100) UNIQUE NOT NULL
);
GO --Tabela Criada

--DROP TABLE Usuario;

CREATE TABLE Usuario
(
		idUsuario INT PRIMARY KEY IDENTITY,
		IDTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(IDTipoUsuario),
		Email VARCHAR (100) UNIQUE NOT NULL,
		Senha VARCHAR (50) NOT NULL,
		NomeUsu VARCHAR (50) NOT NULL
);
GO --Tabela Criada


--DROP TABLE Consulta;
--DROP TABLE Medico;
--DROP TABLE Clinica;


CREATE TABLE Clinica
(
		IDClinica INT PRIMARY KEY IDENTITY,
		CNPJ CHAR(14) UNIQUE NOT NULL,
		Endereço VARCHAR (50) UNIQUE NOT NULL,
		NomeClinica VARCHAR (50) UNIQUE NOT NULL,
		Abertura TIME NOT NULL,
		Fechamento  TIME NOT NULL,
		RazaoSocial VARCHAR (50) UNIQUE NOT NULL
);
GO --Tabela Criada


CREATE TABLE Medico
(
		iDMedico INT PRIMARY KEY IDENTITY,
		IDUsuario INT FOREIGN KEY REFERENCES Usuario (IDUsuario),
		IDEspecialidade INT FOREIGN KEY REFERENCES Especialidade (IDEspecialidade),
		IDClinica INT FOREIGN KEY REFERENCES Clinica (IDClinica),
		NomeMedico VARCHAR (50) NOT NULL,
		CRM VARCHAR (10) UNIQUE NOT NULL
);
GO --Tabela Criada

CREATE TABLE Paciente
(
		IDPaciente INT PRIMARY KEY IDENTITY,
		IDUsuario INT FOREIGN KEY REFERENCES Usuario(IDUsuario),
		NomePac VARCHAR(50) NOT NULL,
		RG CHAR(9) UNIQUE NOT NULL,
		CPF CHAR (11) UNIQUE NOT NULL,
		Endereço VARCHAR (100) UNIQUE NOT NULL,
		DataNasc DATE NOT NULL,
		Telefone VARCHAR(11),	
)
GO--Tabela Criada

SELECT * FROM Paciente

CREATE TABLE Situacao
(
		IDSituacao INT PRIMARY KEY IDENTITY,
		QualSituacao VARCHAR (70) NOT NULL
);
GO--Tabela Criada

CREATE TABLE Consulta
(
	IDConsulta INT PRIMARY KEY IDENTITY,
	IDMedico INT FOREIGN KEY REFERENCES Medico(iDMedico),
	IDPaciente INT FOREIGN KEY REFERENCES Paciente(IDPaciente),
	IDSituacao INT FOREIGN KEY REFERENCES Situacao(IDSituacao),
	DataConsulta DATE NOT NULL,
	DescricaoConsulta VARCHAR (500) default ('Não apresenta uma descrição dos sintomas')
);
GO--Tabela Criada