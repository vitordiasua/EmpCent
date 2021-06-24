create trigger deleteEstagio
	on projeto.Estagio
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Estagio where idOferta in (select idOferta from deleted)
		delete from projeto.Oferta where idOferta in (select idOferta from deleted)
	end
go

create trigger deleteEmprego
	on projeto.Emprego
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Emprego where idOferta in (select idOferta from deleted)
		delete from projeto.Oferta where idOferta in (select idOferta from deleted)
	end
go

create trigger deleteEmpresa
	on projeto.Empresa
	instead of delete
as
	begin
		set nocount on;
		delete from projeto.Recrutador where idEmpresa in (select idEmpresa from deleted);
		delete from projeto.Oferta where idEmpresa in (select idEmpresa from deleted);
		delete from projeto.Empresa where idEmpresa in (select idEmpresa from deleted);
	end
go

create trigger deleteDesempregado
	on projeto.Desempregado
	instead of delete
as
	begin
		set nocount on;
		delete from projeto.Desempregado_Fala_Lingua where numRegisto in (select numRegisto from deleted);
		delete from projeto.Habilitacoes_Academicas where numRegisto in (select numRegisto from deleted);
		delete from projeto.Experiencias_Trabalho where numRegisto in (select numRegisto from deleted);
		delete from projeto.Desempregado_Candidato_Oferta where numRegisto in (select numRegisto from deleted);
		delete from projeto.Desempregado_Experiente_Categoria where numRegisto in (select numRegisto from deleted);
		delete from projeto.Desempregado where numRegisto in (select numRegisto from deleted);
		delete from projeto.Pessoa where numRegisto in (select numRegisto from deleted);
	end
go

create trigger deleteExperienciaTrabalho
	on projeto.Experiencias_Trabalho
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Area_Experiencias_Trabalho where idDados in (select idDados from deleted);
		delete from projeto.Experiencias_Trabalho where idDados in (select idDados from deleted);
	end
go

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
				select @tempRecrutador=numRegisto from projeto.Recrutador 
				where not numRegisto = @numRegisto and idEmpresa = @idEmpresa;

				update projeto.Oferta set idRecrutador = @tempRecrutador where idRecrutador = @numRegisto
			end
		else
			begin
				update projeto.Oferta set idRecrutador = null where idRecrutador = @numRegisto
			end
		
		delete from projeto.Recrutador where numRegisto = @numRegisto
		delete from projeto.Pessoa where numRegisto = @numRegisto

	end
go

create trigger deleteOferta
	on projeto.Oferta
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Desempregado_Candidato_Oferta where idOferta in (select idOferta from deleted)
		delete from projeto.Area_Oferta where idOferta in (select idOferta from deleted)
		delete from projeto.Oferta where idOferta in (select idOferta from deleted)
	end
go

create trigger deleteHabilitacaoAcademica
	on projeto.Habilitacoes_Academicas
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Area_Habilitacoes where idDados in (select idDados from deleted);
		delete from projeto.Habilitacoes_Academicas where idDados in (select idDados from deleted);
	end