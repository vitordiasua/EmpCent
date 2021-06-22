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
			RAISERROR('Tipo de Contrato não existe',16,1);
		end
	end

--Example
--exec insertEmprego 'Teste', 2, 'Aveiraaa', 7, 2,3, 2000, 3, 'Teste', 'tete'
