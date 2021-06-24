CREATE FUNCTION projeto.RecolherEmpregosdeRecrutador( @email NVARCHAR(254) ) RETURNS Table
AS
	RETURN (SELECT Oferta.idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, Oferta.idEmpresa, idRecrutador,nivelHabilitacao, salario, tipoContrato, experienciaNecessaria, descricaoEmprego
            FROM (projeto.Oferta JOIN projeto.Emprego ON Oferta.idOferta = Emprego.idOferta) JOIN projeto.Pessoa ON Pessoa.numRegisto = Oferta.idRecrutador
            WHERE email = @email)
GO

