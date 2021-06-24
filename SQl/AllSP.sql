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

create proc updatePessoa(
			@primeiroNome				varchar(20),
			@nomesMeio					varchar(50),
			@ultimoNome					varchar(30),
			@dataNascimento				date,
			@telefone					char(9),
			@sexo						char(1),
			@oldemail					nvarchar(254),
			@email						nvarchar(254),
			@numRegisto					int OUTPUT)
as
	begin
	select @numRegisto = numRegisto from projeto.Pessoa where email=@oldemail;
	begin transaction
			update [projeto].[Pessoa] set primeiroNome = @primeiroNome, nomesMeio = @nomesMeio, ultimoNome = @ultimoNome, dataNascimento = @dataNascimento, telefone = @telefone, sexo = @sexo, email = @email
			where numRegisto = @numRegisto;
	commit;
	end
go

create proc insertDesempregado(
			@primeiroNome				varchar(20),
			@nomesMeio					varchar(50),
			@ultimoNome					varchar(30),
			@dataNascimento				date,
			@telefone					char(9),
			@sexo						char(1),
			@email						nvarchar(254),
			@idLinguaMaterna			smallint,
			@rua						varchar(30),
			@codigoPostal				nchar(8),
			@localidade					varchar(30),
			@descricao					varchar(200),
			@idNacionalidade			smallint,
			@numRegisto					int OUTPUT)
as
	begin
	begin transaction
		exec insertPessoa @primeiroNome, @nomesMeio, @ultimoNome, @dataNascimento, @telefone, @sexo, @email, @numRegisto output;

		insert into [projeto].[Desempregado] (numRegisto, idLinguaMaterna, rua, codigoPostal, localidade, descricao, idNacionalidade)
			values (@numRegisto, @idLinguaMaterna, @rua, @codigoPostal, @localidade, @descricao, @idNacionalidade)
	commit;
	end
go

create proc updateDesempregado(
			@primeiroNome				varchar(20),
			@nomesMeio					varchar(50),
			@ultimoNome					varchar(30),
			@dataNascimento				date,
			@telefone					char(9),
			@sexo						char(1),
			@email						nvarchar(254),
			@idLinguaMaterna			smallint,
			@rua						varchar(30),
			@codigoPostal				nchar(8),
			@localidade					varchar(30),
			@descricao					varchar(200),
			@idNacionalidade			smallint,
			@oldemail					nvarchar(254),
			@numRegisto					int OUTPUT)
as
	begin
	begin transaction
		exec updatePessoa @primeiroNome, @nomesMeio, @ultimoNome, @dataNascimento, @telefone, @sexo, @oldemail, @email, @numRegisto output;

		update [projeto].[Desempregado] 
		set	idLinguaMaterna = @idLinguaMaterna, rua = @rua, codigoPostal = @codigoPostal, localidade = @localidade, descricao = @descricao, idNacionalidade = @idNacionalidade
		where numRegisto = @numRegisto
	commit;
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

create proc insertUpdateExperienciaTrabalho(
	@numRegisto					int,
	@titulo						varchar(80),
	@dataInicio					date,
	@dataFim					date,
	@localizacao				varchar(30),
	@empresa					varchar(80),
	@idDados					int = null)
as
	begin
	set nocount on;
	if @idDados is null
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
	else
		begin
			if exists(select numRegisto from [projeto].[Desempregado] where numRegisto = @numRegisto)
				begin
					begin transaction
						update [projeto].[Experiencias_Trabalho]
						set  titulo = @titulo, dataFim= @dataFim, dataInicio=@dataInicio, localizacao=@localizacao, empresa=@empresa
						where numRegisto = @numRegisto and idDados = @idDados
					commit
				end
			else
				begin
					raiserror('Desempregado nao existe',16,1)
				end
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

create proc insertUpdateHabilitacaoAcademica(
		@numRegisto				int,
		@nomeCurso				varchar(150),
		@estabelecimentoEnsino	varchar(200),
		@idNivelHabilitacao		smallint,
		@anoConclusao			smallint,
		@notaFinal				smallint,
		@idDados				int = null)
as
	begin
	set nocount on
	if @idDados is null
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
	else
		begin
			if exists(select numRegisto from [projeto].[Desempregado] where numRegisto = @numRegisto)
					begin
						if exists(select idNivel from [projeto].[Nivel_Habilitacao] where idNivel = @idNivelHabilitacao)
							begin
								begin transaction
									update [projeto].[Habilitacoes_Academicas] 
									set nomeCurso = @nomeCurso, estabelecimentoEnsino = @estabelecimentoEnsino, idNivelHabilitacao = @idNivelHabilitacao, anoConclusao = @anoConclusao, notaFinal = @notaFinal
									where numRegisto = @numRegisto and idDados = @idDados
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
	end
go

create proc insertFala(
	@numRegisto				int,
	@nomeLingua				varchar(30),
	@nivelLeitura			smallint,
	@nivelEscrita			smallint,
	@nivelOral				smallint)
as
	begin
		declare @idLingua int;

		select @idLingua=idLingua from projeto.Lingua where nomeLingua=@nomeLingua;
		begin transaction
			insert into [projeto].[Desempregado_Fala_Lingua] (numRegisto, idLingua, nivelLeitura, nivelEscrita, nivelOral)
			values (@numRegisto, @idLingua, @nivelLeitura, @nivelEscrita, @nivelOral)
		commit;
	end
go

create proc insertUpdateFala(
	@numRegisto				int,
	@nomeLingua				varchar(30),
	@nivelLeitura			smallint,
	@nivelEscrita			smallint,
	@nivelOral				smallint)
as
	begin
		declare @idLingua int;

		select @idLingua=idLingua from projeto.Lingua where nomeLingua=@nomeLingua;
		if exists(select * from projeto.Desempregado_Fala_Lingua where numRegisto = @numRegisto and idLingua = @idLingua)
			begin
				begin transaction 
				update [projeto].[Desempregado_Fala_Lingua]
				set nivelLeitura = @nivelLeitura, nivelEscrita = @nivelEscrita, nivelOral = @nivelOral
				where numRegisto = @numRegisto and idLingua = @idLingua
				commit 
			end
		else
			begin
				begin transaction
				insert into [projeto].[Desempregado_Fala_Lingua] (numRegisto, idLingua, nivelLeitura, nivelEscrita, nivelOral)
				values (@numRegisto, @idLingua, @nivelLeitura, @nivelEscrita, @nivelOral)
				commit;
			end
	end
go

create proc insertCandidatura(
	@email			nvarchar(254),
	@idOferta		int)
as
	begin
		declare @numRegisto int;
		select @numRegisto=numRegisto from projeto.Pessoa where email = @email;

		begin transaction
			insert into [projeto].[Desempregado_Candidato_Oferta] (idOferta, numRegisto)
			values (@idOferta, @numRegisto);
		commit;
	end
go

create proc deleteCandidatura(
	@email			nvarchar(254),
	@idOferta		int)
as
	begin
		declare @numRegisto int;
		select @numRegisto=numRegisto from projeto.Pessoa where email = @email;

		begin transaction
			delete from [projeto].[Desempregado_Candidato_Oferta] where numRegisto = @numRegisto and idOferta = @idOferta;
		commit;
	end
go



