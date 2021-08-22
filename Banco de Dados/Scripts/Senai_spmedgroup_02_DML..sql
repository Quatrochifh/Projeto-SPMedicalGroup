USE Medical;
GO
--------------------------------- DML ---------------------------------

INSERT INTO tipoUsuario (PerfisDeUsuario)
VALUES		('Administrador'),('M�dico'),('Paciente');
GO

INSERT INTO Usuario (IDTipoUsuario, Email, Senha, NomeUsu)
VALUES	(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123','Ricardo Lemos'),(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle456','Roberto Possarle'),
(2, 'helena.souza@spmedicalgroup.com.br', 'helena789', 'Helena Strada'),(3, 'ligia@gmail.com', 'ligia123','Ligia'),(3, 'alexandre@gmail.com', 'alexandre456','Alexandre'),
(3, 'fernando@gmail.com', 'fernando789','Fernando'),(3, 'henrique@gmail.com', 'henrique987','Henrique'),(3, 'joao@gmail.com', 'joao654','Jo�o'),(3, 'bruno@gmail.com', 'bruno123','Bruno'),
(3, 'mariana@outlook.com', 'mariana987','Mariana'),(1, 'adm@spmedicalgroup.com.br', 'adm4545','Adiministra��o');
GO


INSERT INTO Especialidade (NomeEspecialidade)
VALUES	('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia de M�o'),
('Cirurgia do Aparelho Digestivo'),('Cirurgia Geral'),('Cirurgia Pedi�trica'),('Cirurgia Pl�stica'),('Cirurgia Tor�cica'),
('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria');
GO

INSERT INTO Clinica (CNPJ, Endere�o, NomeClinica, Abertura,Fechamento, RazaoSocial)
VALUES		('86400902000130', 'Av. Bar�o Limeira, 532, S�o Paulo, SP' , 'Clinica Possarle ','07:30', '23:00', 'SP M�dical Group');
GO


INSERT INTO Medico (IDUsuario, IDEspecialidade, IDClinica, NomeMedico,CRM)
VALUES	(1, 2, 1,'Ricardo Lemos','54356-SP'),(2, 17, 1, 'Roberto Possarle' ,'53852-SP') ,(3, 16, 1, 'Helena Strada' ,'65463-SP');
GO



INSERT INTO Paciente (IDUsuario, NomePac, RG, CPF, Endere�o, DataNasc, Telefone)
VALUES	(4, 'Ligia', '435225435','94839859000', 'Rua Estado de Israel 240,�S�o Paulo, Estado de S�o Paulo, 04022-000', '03/10/1983', '1134567654'),
(5, 'Alexandre', '326543457','73556944057', 'Av. Paulista, 1578 - Bela Vista, S�o Paulo - SP, 01310-200', '03/07/2001', '11987656543'),
(6, 'Fernando', '546365253','16839338002', 'Av. Ibirapuera - Indian�polis, 2927,  S�o Paulo - SP, 04029-200', '10/10/1978', '11972084453'),
(7, 'Henrique', '543663625','14332654765', 'R. Vit�ria, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '13/10/1985', '1134566543'),
(8, 'Jo�o', '325444441','91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeir�o Pires - SP, 09405-380', '27/08/1975', '1176566377'),
(9, 'Bruno', '545662667','79799299004', 'Alameda dos Arapan�s, 945 - Indian�polis, S�o Paulo - SP, 04524-001', '21/03/1972', '11954368769'),
(10, 'Mariana','545662668','13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', '05/03/2018', NULL)
;
GO

INSERT INTO Situacao (QualSituacao)
VALUES	('Realizada'),('Cancelada'),('Agendada');
GO


INSERT INTO Consulta (IDMedico, IDPaciente, IDSituacao, DataConsulta, DescricaoConsulta)
VALUES (3, 24, 1, '20/04/2020', 'Dores abdominais '),(2, 19, 2, '01/06/2021', 'Diz que esta com vontade de tirar a propria vida'),
(2, 20, 1, '02/07/2021', 'Paciente completamente triste'),(2, 19, 1, '02/06/2018', 'Esta com depress�o profunda'),
(1, 21, 2, '02/07/2021', ''),(3, 24, 3, '03/08/2020', 'Machucou a cabe�a'),(1, 21, 3, '09/03/2020', '');
GO



