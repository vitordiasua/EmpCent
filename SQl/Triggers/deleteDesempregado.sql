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



--Example
--delete from projeto.Desempregado where numRegisto=3
