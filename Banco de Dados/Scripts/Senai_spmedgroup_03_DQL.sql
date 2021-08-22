USE Medical;
GO
--------------------------------- DQL ---------------------------------


SELECT * FROM tipoUsuario;
SELECT * FROM Usuario;
SELECT * FROM Especialidade;
SELECT * FROM Clinica;
SELECT * FROM Medico;
SELECT * FROM Paciente;
SELECT * FROM Situacao;
SELECT * FROM Consulta;


------Algumas Listagens-----

--Aqui est�o todos os paciente do sistema
SELECT NomeUsu 'Nome do Paciente', Email , PerfisDeUsuario 'Tipo do usu�rio',CPF
FROM Usuario u
INNER JOIN Paciente p
ON u.IDUsuario = p.IDUsuario
INNER JOIN tipoUsuario ti
ON ti.IDTipoUsuario = u.IDTipoUsuario
GO

--Listagem dos pacientes cadastrados no sistema sendo seu Telefone, Cpf, E endere�o
SELECT NomeUsu 'Nome do Paciente', Email, Telefone, CPF, Endere�o
FROM Usuario u
INNER JOIN Paciente
ON u.IDUsuario = Paciente.IDUsuario
GO
--Estes s�o os medicos todos os m�dicos cadastrados
SELECT * FROM Usuario u
INNER JOIN Medico m
ON u.IDUsuario = m.IDUsuario
GO


--ELE REALIZA A CONTAGEM DE MEDICOS PRESENTE NA AR�A INDICADA
CREATE FUNCTION MedicosArea(@IDEspecialidade VARCHAR(100))
RETURNS INT 
AS
BEGIN 
DECLARE @Quantos AS INT
SET @Quantos = 
(
SELECT COUNT(NomeMedico) FROM Medico 
INNER JOIN Especialidade
ON Medico.IDEspecialidade = Especialidade.IDEspecialidade
WHERE Especialidade.NomeEspecialidade = @IDEspecialidade 
)
RETURN @Quantos
END 


SELECT Quantos_medicos_Psiquiatria = dbo.MedicosArea('Psiquiatria'); 
