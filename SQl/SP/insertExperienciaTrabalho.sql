create proc insertExperienciaTrabalho(
	@numRegisto					int,
	@titulo						varchar(80),
	@dataInicio					date,
	@dataFim					date,
	@localizacao				varchar(30),
	@empresa					varchar(80))
as
	begin
		if exists(select numRegisto from [projeto].[Desempregado] where numRegisto = @numRegisto)
			begin
				begin transaction
					insert into [projeto].[Experiencias_Trabalho] (numRegisto, titulo, dataFim, dataInicio, localizacao, empresa)
					values (@numRegisto, @titulo, @dataFim, @dataInicio, @localizacao, @empresa)
				commit
			end
		else
			begin
				raiserror('Desempregado n�o existe',16,1)
			end
	end

--Example
--exec insertExperienciaTrabalho 11, 'Teste', '2004-06-03', '2007-08-21', 'Elvas', 'testeComp'

