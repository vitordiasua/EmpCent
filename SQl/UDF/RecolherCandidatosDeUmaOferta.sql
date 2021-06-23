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