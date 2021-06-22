create proc insertDesempregado(
			@primeiroNome				varchar(20),
			@nomesMeio					varchar(50),
			@ultimoNome					varchar(30),
			@dataNascimento				date,
			@telefone					char(9),
			@sexo						char(1),
			@email						nvarchar(254),
			@idLinguaMaterna		smallint,
			@rua					varchar(30),
			@codigoPostal		nchar(8),
			@localidade			varchar(30),
			@descricao			varchar(200),
			@idNacionalidade		smallint)
as
	begin
	begin transaction
		declare @numReg int;
		exec insertPessoa @primeiroNome, @nomesMeio, @ultimoNome, @dataNascimento, @telefone, @sexo, @email, @numReg output;

		insert into [projeto].[Desempregado] (numRegisto, idLinguaMaterna, rua, codigoPostal, localidade, descricao, idNacionalidade)
			values (@numReg, @idLinguaMaterna, @rua, @codigoPostal, @localidade, @descricao, @idNacionalidade)
	commit;
	end

--Example
--exec insertDesempregado 'Marisa', 'TEste', 'Batata', '2021-01-01', '968574123', 1, 'teste@gg.com', 2, 'Rua teste', '0000-000', 'Teste', 'TEste dos testes' , 3