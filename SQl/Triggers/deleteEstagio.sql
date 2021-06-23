create trigger deleteEstagio
	on projeto.Estagio
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Estagio where idOferta in (select idOferta from deleted)
		delete from projeto.Oferta where idOferta in (select idOferta from deleted)
	end