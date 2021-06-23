CREATE FUNCTION projeto.RecolherInfoDeOferta ( @idOferta INT)  RETURNS Table
AS
	RETURN (SELECT *
            FROM(SELECT idOferta, titulo, numVagas, Oferta.localizacao, dataPublicacao, idRecrutador, nivelHabilitacao, nome, Empresa.localizacao AS empLocal, descricao 
                 FROM projeto.Oferta JOIN projeto.Empresa ON Oferta.idEmpresa = Empresa.idEmpresa 
                 WHERE Oferta.idOferta = @idOferta) AS ofEmp
            JOIN  projeto.Nivel_Habilitacao ON ofEmp.nivelHabilitacao = projeto.Nivel_Habilitacao.idNivel)
GO