create proc insertHabilitacaoAcademica(
		@numRegisto				int,
		@nomeCurso				varchar(150),
		@estabelecimentoEnsino	varchar(200),
		@idNivelHabilitacao		smallint,
		@anoConclusao			smallint,
		@notaFinal				smallint)
as
	set nocount on
	begin
		if exists(select numRegisto from [projeto].[Desempregado] where numRegisto = @numRegisto)
			begin
				if exists(select idNivel from [projeto].[Nivel_Habilitacao] where idNivel = @idNivelHabilitacao)
					begin
						begin transaction
							insert into [projeto].[Habilitacoes_Academicas] (numRegisto, nomeCurso, estabelecimentoEnsino, idNivelHabilitacao, anoConclusao, notaFinal)
							values (@numRegisto, @nomeCurso, @estabelecimentoEnsino, @idNivelHabilitacao, @anoConclusao, @notaFinal)
						commit
					end
				else
					begin
						raiserror('Nivel de Habilitação não existe',16,2)
					end
			end
		else
			begin
				raiserror('Desempregado não existe',16,1)
			end
	end

--Example
--exec insertHabilitacaoAcademica 11, 'Curso teste', 'uni teste', 7, 2003, 10

select * from projeto.Desempregado
select * from projeto.Habilitacoes_Academicas
