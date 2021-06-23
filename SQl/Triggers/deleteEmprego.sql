create trigger deleteEmprego
	on projeto.Emprego
	instead of delete
as
	begin
		set nocount on
		delete from projeto.Emprego where idOferta in (select idOferta from deleted)
		delete from projeto.Oferta where idOferta in (select idOferta from deleted)
	end