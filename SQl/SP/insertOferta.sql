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

--Example
--declare @idOferta int;
--exec insertOferta 'Teste', 2, 'Aveiraaa', 3, 2,3, @idOferta output;
--print(@idOferta)
