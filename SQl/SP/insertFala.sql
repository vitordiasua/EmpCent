create proc insertFala(
	@numRegisto				int,
	@nomeLingua				varchar(30),
	@nivelLeitura			smallint,
	@nivelEscrita			smallint,
	@nivelOral				smallint)
as
	begin
		declare @idLingua int;

		select @idLingua=idLingua from projeto.Lingua where nomeLingua=@nomeLingua;
		begin transaction
			insert into [projeto].[Desempregado_Fala_Lingua] (numRegisto, idLingua, nivelLeitura, nivelEscrita, nivelOral)
			values (@numRegisto, @idLingua, @nivelLeitura, @nivelEscrita, @nivelOral)
		commit;
	end