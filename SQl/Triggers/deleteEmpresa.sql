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