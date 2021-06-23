create trigger deleteHabilitacaoAcademica
	on projeto.Habilitacoes_Academicas
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Area_Habilitacoes where idDados in (select idDados from deleted);
		delete from projeto.Habilitacoes_Academicas where idDados in (select idDados from deleted);
	end