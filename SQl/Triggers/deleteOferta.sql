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