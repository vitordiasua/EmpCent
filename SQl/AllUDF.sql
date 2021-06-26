CREATE FUNCTION projeto.RecolherRecrutadores (@nomeEmpresa VARCHAR(50)) RETURNS Table
AS
	RETURN (SELECT Pessoa.numRegisto, primeiroNome, nomesMeio, ultimoNome, dataNascimento, telefone, sexo, idade, email, metodoDeSelecao
			FROM projeto.Pessoa JOIN projeto.Recrutador ON Pessoa.numRegisto = Recrutador.numRegisto
			WHERE idEmpresa = (SELECT idEmpresa 
							   FROM projeto.Empresa		
							   WHERE Empresa.nome = @nomeEmpresa))
GO

CREATE FUNCTION projeto.RecolherCandidaturasDeDesempregado ( @email NVARCHAR(254) ) RETURNS Table
AS
	RETURN (SELECT Client.idOferta, numRegisto,email,titulo,numVagas,localizacao,dataPublicacao,idEmpresa,idRecrutador,nivelHabilitacao
            FROM ( SELECT idOferta, Pessoa.numRegisto, email
            FROM projeto.Desempregado_Candidato_Oferta JOIN projeto.Pessoa ON Pessoa.numRegisto = Desempregado_Candidato_Oferta.numRegisto) AS Client JOIN projeto.Oferta ON Client.idOferta = Oferta.idOferta
            WHERE email = @email)
GO

CREATE FUNCTION projeto.RecolherEmpregosdeRecrutador( @email NVARCHAR(254) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, salario, tipoContrato, experienciaNecessaria, descricaoEmprego
            FROM (projeto.Oferta JOIN projeto.Emprego ON Oferta.idOferta = Emprego.idOferta) JOIN projeto.Pessoa ON Pessoa.numRegisto = Oferta.idRecrutador
            WHERE email = @email)
GO

CREATE FUNCTION projeto.RecolherInfoDeOferta ( @idOferta INT)  RETURNS Table
AS
	RETURN (SELECT *
            FROM(SELECT idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, idRecrutador, nivelHabilitacao, nome, Empresa.localizacao AS empLocal, descricao 
                 FROM projeto.Oferta JOIN projeto.Empresa ON Oferta.idEmpresa = Empresa.idEmpresa 
                 WHERE Oferta.idOferta = @idOferta) AS ofEmp
            JOIN  projeto.Nivel_Habilitacao ON ofEmp.nivelHabilitacao = projeto.Nivel_Habilitacao.idNivel)
GO

CREATE FUNCTION projeto.RecolherEstagiosdeRecrutador( @email NVARCHAR(254) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, duracao, observacoes
            FROM (projeto.Oferta JOIN projeto.Estagio ON Oferta.idOferta = Estagio.idOferta) JOIN projeto.Pessoa ON Pessoa.numRegisto = Oferta.idRecrutador
            WHERE email = @email)
GO

CREATE FUNCTION projeto.RecolherCandidatosDeUmaOferta ( @idOferta INT) RETURNS Table
AS
	RETURN (SELECT plusLanguage.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, rua , codigoPostal, localidade, descricao, nomeLingua, nomeNacionalidade
            FROM ( SELECT Desempregado_Candidato_Oferta.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, rua , codigoPostal, localidade, descricao, nomeLingua, idNacionalidade
                   FROM (projeto.Desempregado_Candidato_Oferta JOIN ( SELECT Pessoa.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, idLinguaMaterna, rua , codigoPostal, localidade, descricao, idNacionalidade
                                                                      FROM projeto.Pessoa JOIN projeto.Desempregado ON Pessoa.numRegisto = Desempregado.numRegisto) AS Candidate ON Desempregado_Candidato_Oferta.numRegisto = Candidate.numRegisto )
						JOIN projeto.Lingua ON idLinguaMaterna = idLingua
                        WHERE idOferta = @idOferta ) AS plusLanguage 
            JOIN projeto.Nacionalidade ON plusLanguage.idNacionalidade = Nacionalidade.idNacionalidade )
GO

CREATE FUNCTION projeto.RecolherCandidatosDeUmaOferta ( @idOferta INT) RETURNS Table
AS
	RETURN (SELECT plusLanguage.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, rua , codigoPostal, localidade, descricao, nomeLingua, nomeNacionalidade
            FROM ( SELECT Desempregado_Candidato_Oferta.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, rua , codigoPostal, localidade, descricao, nomeLingua, idNacionalidade
                   FROM (projeto.Desempregado_Candidato_Oferta JOIN ( SELECT Pessoa.numRegisto, primeiroNome,nomesMeio,ultimoNome,dataNascimento,telefone,sexo, idade, email, idLinguaMaterna, rua , codigoPostal, localidade, descricao, idNacionalidade
                                                                      FROM projeto.Pessoa JOIN projeto.Desempregado ON Pessoa.numRegisto = Desempregado.numRegisto) AS Candidate ON Desempregado_Candidato_Oferta.numRegisto = Candidate.numRegisto )
						JOIN projeto.Lingua ON idLinguaMaterna = idLingua
                        WHERE idOferta = @idOferta ) AS plusLanguage 
            JOIN projeto.Nacionalidade ON plusLanguage.idNacionalidade = Nacionalidade.idNacionalidade )
GO

CREATE FUNCTION projeto.RecolherEmpregosDeEmpresa ( @nome VARCHAR(50) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, salario, tipoContrato, experienciaNecessaria, descricaoEmprego
			FROM (projeto.Oferta JOIN projeto.Emprego ON Oferta.idOferta = Emprego.idOferta) JOIN projeto.Empresa ON Oferta.idEmpresa = Empresa.idEmpresa
			WHERE nome = @nome)
GO

CREATE FUNCTION projeto.RecolherEstagiosDeEmpresa ( @nome VARCHAR(50) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, duracao, observacoes
			FROM (projeto.Oferta JOIN projeto.Estagio ON Oferta.idOferta = Estagio.idOferta) JOIN projeto.Empresa ON Oferta.idEmpresa = Empresa.idEmpresa
			WHERE nome = @nome)
GO