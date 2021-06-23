CREATE FUNCTION projeto.RecolherOfertasDeRecrutador ( @email NVARCHAR(254) ) RETURNS Table
AS
	RETURN (SELECT *
            FROM projeto.Oferta JOIN projeto.Pessoa ON Pessoa.numRegisto = Oferta.idRecrutador
            WHERE email = @email)
GO