create proc insertOferta(
	@titulo					varchar(40),
	@numVagas				smallint,
	@localizacao			varchar(40),
	@idEmpresa				int,
	@idRecrutador			int,
	@nivelHabilitacao		smallint,
	@idOferta				int OUTPUT)
as
	begin
	if exists(select idEmpresa from [projeto].[Empresa] where idEmpresa = @idEmpresa) 
		begin
			if exists(select numRegisto from [projeto].[Recrutador] where numRegisto = @idRecrutador)
				begin
					if exists(select idNivel from [projeto].[Nivel_Habilitacao] where idNivel = @nivelHabilitacao)
						begin
							declare @dataPublicacao as date
							set @dataPublicacao = cast(getdate() as date)
							begin transaction
								insert into [projeto].[Oferta] (titulo, numVagas, localizacao, dataPublicacao, idEmpresa, idRecrutador, nivelHabilitacao)
								values (@titulo, @numVagas, @localizacao, @dataPublicacao, @idEmpresa, @idRecrutador, @nivelHabilitacao)

								select @idOferta=idOferta from projeto.Oferta where titulo=@titulo and numVagas = @numVagas and localizacao = @localizacao;
							commit;
						end
					else
						begin
							RAISERROR('Nivel de habilitacao nao existe',16,3);
						end
				end
			else
				begin
					RAISERROR('Recrutador nao existe',16,2);
				end
		end
	else
		begin
			RAISERROR('Empresa nao existe',16,1);
		end
	end
go

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
go

create proc insertEmprego(
	@titulo					varchar(40),
	@numVagas				smallint,
	@localizacao			varchar(40),
	@idEmpresa				int,
	@idRecrutador			int,
	@nivelHabilitacao		smallint,
	@salario					smallint,
	@tipoContrato			smallint,
	@experienciaNecessaria	varchar(100),
	@descricaoEmprego		varchar(150))
as
	begin
	if exists(select idTipoContrato from [projeto].[Tipo_Contrato] where idTipoContrato = @tipoContrato)
		begin
			begin transaction
				declare @idOferta int;
				exec insertOferta @titulo, @numVagas, @localizacao, @idEmpresa, @idRecrutador, @nivelHabilitacao, @idOferta output;

				if @idOferta is not null
					begin
						insert into [projeto].[Emprego] (idOferta, salario, tipoContrato, experienciaNecessaria, descricaoEmprego)
						values (@idOferta, @salario, @tipoContrato, @experienciaNecessaria, @descricaoEmprego)
					end
			commit;
		end
	else
		begin
			RAISERROR('Tipo de Contrato nao existe',16,1);
		end
	end
go

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
go

create proc insertEmpresa(
	@nome				varchar(50),
	@descricao			varchar(30),
	@localizacao		varchar(100))
as
	begin
	begin transaction
		insert into [projeto].[Empresa] (nome, localizacao, descricao)
		values (@nome, @descricao, @localizacao)
	commit;
	end
go

create proc insertExperienciaTrabalho(
	@numRegisto					int,
	@titulo						varchar(80),
	@dataInicio					date,
	@dataFim					date,
	@localizacao				varchar(30),
	@empresa					varchar(80))
as
	begin
		if exists(select numRegisto from [projeto].[Desempregado] where numRegisto = @numRegisto)
			begin
				begin transaction
					insert into [projeto].[Experiencias_Trabalho] (numRegisto, titulo, dataFim, dataInicio, localizacao, empresa)
					values (@numRegisto, @titulo, @dataFim, @dataInicio, @localizacao, @empresa)
				commit
			end
		else
			begin
				raiserror('Desempregado nao existe',16,1)
			end
	end
go

create proc insertEstagio(
	@titulo					varchar(40),
	@numVagas				smallint,
	@localizacao			varchar(40),
	@idEmpresa				int,
	@idRecrutador			int,
	@nivelHabilitacao		smallint,
	@duracao				smallint,
	@observacoes			varchar(150))
as
	begin
	begin transaction
		declare @idOferta int;
		exec insertOferta @titulo, @numVagas, @localizacao, @idEmpresa, @idRecrutador, @nivelHabilitacao, @idOferta output;

		if @idOferta is not null
			begin
				insert into [projeto].[Estagio] (idOferta, duracao, observacoes)
				values (@idOferta, @duracao, @observacoes)
			end
	commit;
	end
go

create proc insertHabilitacaoAcademica(
		@numRegisto				int,
		@nomeCurso				varchar(150),
		@estabelecimentoEnsino	varchar(200),
		@idNivelHabilitacao		smallint,
		@anoConclusao			smallint,
		@notaFinal				smallint)
as
	set nocount on
	begin
		if exists(select numRegisto from [projeto].[Desempregado] where numRegisto = @numRegisto)
			begin
				if exists(select idNivel from [projeto].[Nivel_Habilitacao] where idNivel = @idNivelHabilitacao)
					begin
						begin transaction
							insert into [projeto].[Habilitacoes_Academicas] (numRegisto, nomeCurso, estabelecimentoEnsino, idNivelHabilitacao, anoConclusao, notaFinal)
							values (@numRegisto, @nomeCurso, @estabelecimentoEnsino, @idNivelHabilitacao, @anoConclusao, @notaFinal)
						commit
					end
				else
					begin
						raiserror('Nivel de Habilitacao nao existe',16,2)
					end
			end
		else
			begin
				raiserror('Desempregado nao existe',16,1)
			end
	end
go




