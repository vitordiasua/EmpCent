CREATE FUNCTION projeto.RecolherEstagiosdeRecrutador( @email NVARCHAR(254) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, duracao, observacoes
            FROM (projeto.Oferta JOIN projeto.Estagio ON Oferta.idOferta = Estagio.idOferta) JOIN projeto.Pessoa ON Pessoa.numRegisto = Oferta.idRecrutador
            WHERE email = @email)
GO

