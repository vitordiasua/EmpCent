--create schema projeto;

create table projeto.Pessoa(
	numRegisto			int Identity(1,1), --talvez por default 'user' para quando se apaga um user da base de dados dar-se update para o default para continuar com cenas guardadas, nao sei o quao util seria
	primeiroNome		varchar(20),
	nomesMeio			varchar(50),
	ultimoNome			varchar(30),
	dataNascimento		date,
	telefone			char(9),
	sexo				char(1),
	idade				as (0 + Convert(Char(8),getdate(),112) - Convert(Char(8),dataNascimento,112)) / 10000,
	email				nvarchar(254)

	Constraint PK_Pessoa
		primary key (numRegisto));

create table projeto.Lingua(
	idLingua			smallint Identity(1,1),
	nomeLingua			varchar(50)
	Constraint PK_Lingua
		primary key (idLingua));

create table projeto.Nacionalidade(
	idNacionalidade		smallint Identity(1,1),
	nomeNacionalidade	varchar(50)
	Constraint PK_Nacionalidade
		primary key (idNacionalidade));

create table projeto.Desempregado(
	numRegisto			int,
	idLinguaMaterna		smallint,
	curriculo			varbinary(max),
	rua					varchar(30),
	codigoPostal		nchar(8) check (codigoPostal like '____-___'),
	localidade			varchar(30),
	descricao			varchar(200),
	idNacionalidade		smallint,
	Constraint PK_Desempregado
		primary key (numRegisto),
	Constraint FK_Pessoa
		foreign key (numRegisto) references projeto.Pessoa (numRegisto),
	Constraint FK_LinguaMaterna
		foreign key (idLinguaMaterna) references projeto.Lingua (idLingua),
	Constraint FK_Nacionalidade
		foreign key (idNacionalidade) references projeto.Nacionalidade (idNacionalidade));

create table projeto.Nivel_Lingua(
	idNivel				smallint Identity(1,1),
	descricaoNivel		varchar(50),
	Constraint PK_Nivel_Lingua
		primary key (idNivel))

create table projeto.Empresa(
	idEmpresa			int Identity(1,1),
	nome				varchar(50),
	localizacao			varchar(30),
	descricao			varchar(100),
	Constraint PK_Empresa
		primary key (idEmpresa))

create table projeto.Recrutador(
	numRegisto			int,
	metodoDeSelecao		varchar(100),
	idEmpresa			int,
	Constraint PK_Recrutador
		primary key (numRegisto),
	Constraint FK_Pessoa_Recrutador
		foreign key (numRegisto) references projeto.Pessoa (numRegisto),
	Constraint FK_Empresa
		foreign key (idEmpresa) references projeto.Empresa (idEmpresa))

create table projeto.Categoria_Emprego(
	idCategoria			smallint Identity(1,1),
	nomeCategoria		varchar(50),
	Constraint PK_Categoria_Emprego
		primary key (idCategoria))

create table projeto.Nivel_Habilitacao(
	idNivel				smallint Identity(1,1),
	descricaoNivel		varchar(50),
	Constraint PK_Nivel_Habilitacao
		primary key (idNivel))

create table projeto.Habilitacoes_Academicas(
	idDados					int Identity(1,1),
	numRegisto				int,
	nomeCurso				varchar(150),
	estabelecimentoEnsino	varchar(200),
	idNivelHabilitacao		smallint,
	anoConclusao			smallint,
	notaFinal				smallint,
	Constraint PK_Habilitacoes_Academicas
		primary key (idDados, numRegisto),
	Constraint FK_Desempregado
		foreign key (numRegisto) references projeto.Desempregado(numRegisto),
	Constraint FK_Nivel_Habilitacao
		foreign key (idNivelHabilitacao) references projeto.Nivel_Habilitacao (idNivel))

create table projeto.Experiencias_Trabalho(
	idDados					int Identity(1,1),
	numRegisto				int,
	titulo					varchar(80),
	dataFim					date,
	dataInicio				date,
	duracao					as datediff(month,dataInicio, dataFim),
	localizacao				varchar(30),
	empresa					varchar(80),
	Constraint PK_Experiencias_Trabalho
		primary key (idDados, numRegisto),
	Constraint FK_Desempregado_Experiencias_Trabalho
		foreign key (numRegisto) references projeto.Desempregado(numRegisto))

create table projeto.Desempregado_Fala_Lingua(
	numRegisto				int,
	idLingua				smallint,
	certificado				varbinary(max),
	nivelLeitura			smallint,
	nivelEscrita			smallint,
	nivelOral				smallint,
	Constraint PK_Desempregado_Fala_Lingua
		primary key (numRegisto,idLingua),
	Constraint FK_Desempregado_Fala_Lingua
		foreign key (numRegisto) references projeto.Desempregado(numRegisto),
	Constraint Fk_Lingua
		foreign key (idLingua) references projeto.Lingua(idLingua),
	Constraint FK_Leitura
		foreign key (nivelLeitura) references projeto.Nivel_Lingua(idNivel),
	Constraint FK_Escrita
		foreign key (nivelEscrita) references projeto.Nivel_Lingua(idNivel),
	Constraint FK_Oral
		foreign key (nivelOral) references projeto.Nivel_Lingua(idNivel))

create table projeto.Area_Habilitacoes(
	idDados					int,
	idCategoria				smallint,
	numRegisto				int,
	Constraint PK_Area_Habilitacoes
		primary key (idDados, numRegisto, idCategoria),
	Constraint FK_Habilitacoes_Academicas
		foreign key (idDados,numRegisto) references projeto.Habilitacoes_Academicas(idDados, numRegisto),
	Constraint FK_Categoria_Emprego
		foreign key (idCategoria) references projeto.Categoria_Emprego(idCategoria))

create table projeto.Area_Experiencias_Trabalho(
	idDados					int,
	idCategoria				smallint,
	numRegisto				int,
	Constraint PK_Area_Habilitacoes_Experiencias_Trabalho
		primary key (idDados, numRegisto, idCategoria),
	Constraint FK_Experiencias_Trabalho
		foreign key (idDados,numRegisto) references projeto.Experiencias_Trabalho(idDados, numRegisto),
	Constraint FK_Categoria_Emprego_Area_Experiencias_Trabalho
		foreign key (idCategoria) references projeto.Categoria_Emprego(idCategoria))

create table projeto.Desempregado_Experiente_Categoria(
	numRegisto				int,
	idCategoria				smallint,
	Constraint PK_Desempregado_Experiente_Categoria
		primary key (numRegisto, idCategoria),
	Constraint FK_Desempregado_Experiente
		foreign key (numRegisto) references projeto.Desempregado(numRegisto),
	Constraint FK_Categoria_Emprego_Experiente
		foreign key (idCategoria) references projeto.Categoria_Emprego(idCategoria))

create table projeto.Oferta(
	idOferta				int Identity(1,1),
	titulo					varchar(40),
	numVagas				smallint,
	localizacao				varchar(40),
	dataPublicacao			date,
	idEmpresa				int,
	idRecrutador			int,
	nivelHabilitacao		smallint,
	Constraint PK_Oferta
		primary key (idOferta),
	Constraint FK_Empresa_Oferta
		foreign key (idEmpresa) references projeto.Empresa (idEmpresa),
	Constraint FK_Recrutador_Oferta
		foreign key (idRecrutador) references projeto.Recrutador (numRegisto),
	Constraint FK_Nivel_Habilitacao_Oferta
		foreign key (nivelHabilitacao) references projeto.Nivel_Habilitacao (idNivel))

create table projeto.Estagio(
	idOferta				int,
	duracao					smallint,
	observacoes				varchar(150),
	Constraint PK_Estagio
		primary key (idOferta),
	Constraint FK_Oferta
		foreign key (idOferta) references projeto.Oferta (idOferta))

create table projeto.Tipo_Contrato(
	idTipoContrato			smallint Identity(1,1),
	descricaoTipoContrato	varchar(50),
	Constraint PK_Tipo_Contrato
		primary key (idTipoContrato))

create table projeto.Emprego(
	idOferta				int,
	salario					smallint,
	tipoContrato			smallint,
	experienciaNecessaria	varchar(100),
	descricaoEmprego		varchar(150),
	Constraint PK_Emprego
		primary key (idOferta),
	Constraint FK_Oferta_Emprego
		foreign key (idOferta) references projeto.Oferta (idOferta),
	Constraint FK_Tipo_Contrato_Emprego
		foreign key (tipoContrato) references projeto.Tipo_Contrato (idTipoContrato))

create table projeto.Teste(
	idTeste					int Identity(1,1),
	idOferta				int,
	Constraint PK_Teste
		primary key (idOferta, idTeste))

create table projeto.Pergunta(
	idPergunta				int Identity(1,1),
	idTeste					int,
	idOferta				int,
	descricao				varchar(50),
	Constraint PK_Pergunta
		primary key (idOferta, idTeste, idPergunta),
	Constraint FK_Teste
		foreign key (idOferta, idTeste) references projeto.Teste (idOferta, idTeste))

create table projeto.Resposta(
	idResposta				int Identity(1,1),
	idPergunta				int,
	idTeste					int,
	idOferta				int,
	descricao				varchar(150),
	Constraint PK_Resposta
		primary key (idOferta, idTeste, idPergunta, idResposta),
	Constraint FK_Pergunta
		foreign key (idOferta, idTeste, idPergunta) references projeto.Pergunta (idOferta, idTeste, idPergunta))

create table projeto.Area_Oferta(
	idOferta				int,
	idCategoria				smallint,
	Constraint PK_Area_Oferta
		primary key(idOferta, idCategoria),
	Constraint FK_Area_Oferta
		foreign key (idOferta) references projeto.Oferta (idOferta),
	Constraint FK_Area_Oferta_Categoria
		foreign key (idCategoria) references projeto.Categoria_Emprego (idCategoria))
	

create table projeto.Desempregado_Candidato_Oferta(
	idOferta				int,
	numRegisto				int,
	Constraint PK_Desempregado_Candidato_Oferta
		primary key(idOferta, numRegisto),
	Constraint FK_Desempregado_Candidato_Oferta_Oferta
		foreign key (idOferta) references projeto.Oferta (idOferta),
	Constraint FK_Desempregado_Candidato_Oferta_Desempregado
		foreign key (numRegisto) references projeto.Desempregado (numRegisto))
