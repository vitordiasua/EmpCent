create trigger deleteRecrutador
	on projeto.Recrutador
	instead of delete
as
	begin
		set nocount on;
		
		declare @numRegisto as int;
		declare @idEmpresa as int;
		
		select @numRegisto=numRegisto, @idEmpresa=idEmpresa from deleted;
		
		if exists(select numRegisto from projeto.Recrutador where not numRegisto = @numRegisto and idEmpresa = @idEmpresa)
			begin
				declare @tempRecrutador as int;
				select @tempRecrutador=numRegisto from projeto.Recrutador where not numRegisto = @numRegisto and idEmpresa = @idEmpresa;

				update projeto.Oferta set idRecrutador = @tempRecrutador where idRecrutador = @numRegisto
			end
		else
			begin
				update projeto.Oferta set idRecrutador = null where idRecrutador = @numRegisto
			end
		
		delete from projeto.Recrutador where numRegisto = @numRegisto
		delete from projeto.Pessoa where numRegisto = @numRegisto

	end


