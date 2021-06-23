CREATE FUNCTION projeto.RecolherRecrutadores (@nomeEmpresa VARCHAR(50)) RETURNS Table
AS
	RETURN (SELECT Pessoa.numRegisto, primeiroNome, nomesMeio, ultimoNome, dataNascimento, telefone, sexo, idade, email, metodoDeSelecao
			FROM projeto.Pessoa JOIN projeto.Recrutador ON Pessoa.numRegisto = Recrutador.numRegisto
			WHERE idEmpresa = (SELECT idEmpresa 
							   FROM projeto.Empresa		
							   WHERE Empresa.nome = @nomeEmpresa))
GO