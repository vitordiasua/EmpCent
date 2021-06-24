CREATE FUNCTION projeto.RecolherEstagiosDeEmpresa ( @nome VARCHAR(50) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, duracao, observacoes
			FROM (projeto.Oferta JOIN projeto.Estagio ON Oferta.idOferta = Estagio.idOferta) JOIN projeto.Empresa ON Oferta.idEmpresa = Empresa.idEmpresa
			WHERE nome = @nome)
GO