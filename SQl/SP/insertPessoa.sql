create proc insertPessoa(
			@primeiroNome				varchar(20),
			@nomesMeio					varchar(50),
			@ultimoNome					varchar(30),
			@dataNascimento				date,
			@telefone					char(9),
			@sexo						char(1),
			@email						nvarchar(254),
			@numRegisto					int OUTPUT)
as
	begin
	begin transaction
			insert into [projeto].[Pessoa] (primeiroNome, nomesMeio, ultimoNome, dataNascimento, telefone, sexo, email)
			values (@primeiroNome, @nomesMeio, @ultimoNome, @dataNascimento, @telefone, @sexo, @email)
	commit;

	select @numRegisto=numRegisto from projeto.Pessoa where email=@email;
	end

--Example
--declare @teste int;
--exec insertPessoa 'Marisa', 'TEste', 'Batata', '2021-01-01', '968574123', 1, 'teste@gg.com', @teste Output;
--print(@teste)