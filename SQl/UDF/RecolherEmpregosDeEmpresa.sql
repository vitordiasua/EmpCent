CREATE FUNCTION projeto.RecolherEmpregosDeEmpresa ( @nome VARCHAR(50) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, salario, tipoContrato, experienciaNecessaria, descricaoEmprego
			FROM (projeto.Oferta JOIN projeto.Emprego ON Oferta.idOferta = Emprego.idOferta) JOIN projeto.Empresa ON Oferta.idEmpresa = Empresa.idEmpresa
			WHERE nome = @nome)
GO