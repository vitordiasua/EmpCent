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

--Example
--exec insertEstagio 'Teste', 2, 'Aveiraaa', 4, 2,3, 4, 'Te te te te te te'
