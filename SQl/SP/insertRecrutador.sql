create proc insertRecrutador(
			@primeiroNome				varchar(20),
			@nomesMeio					varchar(50),
			@ultimoNome					varchar(30),
			@dataNascimento				date,
			@telefone					char(9),
			@sexo						char(1),
			@email						nvarchar(254),
			@metodoDeSelecao	varchar(100),
			@idEmpresa			int)
as
	begin
	begin transaction
		declare @numReg int;
		exec insertPessoa @primeiroNome, @nomesMeio, @ultimoNome, @dataNascimento, @telefone, @sexo, @email, @numReg output;

		insert into [projeto].[Recrutador] (numRegisto, metodoDeSelecao, idEmpresa)
			values (@numReg, @metodoDeSelecao, @idEmpresa)
	commit;
	end
--Example
--exec insertRecrutador 'Marisa', 'TEste', 'Batata', '2021-01-01', '968574123', 1, 'teste@gg.com', 'Faço testes', 2