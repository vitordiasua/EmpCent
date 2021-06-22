create proc insertEmpresa(
	@nome				varchar(50),
	@descricao			varchar(30),
	@localizacao		varchar(100))
as
	begin
	begin transaction
		insert into [projeto].[Empresa] (nome, localizacao, descricao)
		values (@nome, @descricao, @localizacao)
	commit;
	end

--Example
--exec insertEmpresa 'EmpTeste', 'teste teste', 'SeTeste'
