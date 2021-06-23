CREATE FUNCTION projeto.RecolherCandidaturasDeDesempregado ( @email NVARCHAR(254) ) RETURNS Table
AS
	RETURN (SELECT Client.idOferta, numRegisto,email,titulo,numVagas,localizacao,dataPublicacao,idEmpresa,idRecrutador,nivelHabilitacao
            FROM ( SELECT idOferta, Pessoa.numRegisto, email
            FROM projeto.Desempregado_Candidato_Oferta JOIN projeto.Pessoa ON Pessoa.numRegisto = Desempregado_Candidato_Oferta.numRegisto) AS Client JOIN projeto.Oferta ON Client.idOferta = Oferta.idOferta
            WHERE email = @email)
GO