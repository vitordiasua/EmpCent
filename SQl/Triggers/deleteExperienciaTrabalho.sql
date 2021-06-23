create trigger deleteExperienciaTrabalho
	on projeto.Experiencias_Trabalho
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Area_Experiencias_Trabalho where idDados in (select idDados from deleted);
		delete from projeto.Experiencias_Trabalho where idDados in (select idDados from deleted);
	end