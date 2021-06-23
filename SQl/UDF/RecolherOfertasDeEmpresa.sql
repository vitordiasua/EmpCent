CREATE FUNCTION projeto.RecolherOfertasDeEmpresa ( @nome VARCHAR(50) ) RETURNS Table
AS
	RETURN (SELECT idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao 
			FROM projeto.Oferta JOIN projeto.Empresa ON Oferta.idEmpresa = Empresa.idEmpresa
			WHERE nome = @nome)
GO