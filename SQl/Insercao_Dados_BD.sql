use p6g5;
go

--Inser�ao dados em Lingua
insert into projeto.Lingua (nomeLingua) values 
('Afar'),
('Afric�ner'),
('Alban�s'),
('Alem�o'),
('Am�rico'),
('�rabe'),
('Arm�nio'),
('Azeri'),
('Bielorusso'),
('Bengali'),
('Bislama'),
('B�snio'),
('B�lgaro'),
('Canar�'),
('Cazaque'),
('Catal�o'),
('Checo'),
('Chin�s Mandarim'),
('Cingal�s'),
('Coreano'),
('Croata'),
('Curdo'),
('Dinamarqu�s'),
('Dari'),
('Dhiveli'),
('Dzongkha'),
('Eslovaco'),
('Esloveno'),
('Espanhol'),
('Estoniano'),
('Fijiano'),
('Filipino'),
('Finland�s'),
('Franc�s'),
('Fr�sio Ocidental'),
('Georgiano'),
('Grego'),
('Guarani'),
('Criolo Haitiano'),
('Hebreu'),
('Hindi'),
('Fiji Hindi'),
('Hiri Motu'),
('H�ngaro'),
('Indon�sio'),
('Ingl�s'),
('Irland�s'),
('Italiano'),
('Japon�s'),
('Laociano'),
('Latim'),
('Let�o'),
('Lituano'),
('Maced�nio'),
('Malaio'),
('Malaiala'),
('Maori'),
('Marata'),
('Mold�vio'),
('Mongol'),
('Neerland�s'),
('Ndebele'),
('Nepal�s'),
('Soto Setentrional'),
('Noruegu�s'),
('Ori�'),
('Pachto'),
('Palauense'),
('Persa'),
('Polon�s'),
('Portugu�s'),
('Punjabi'),
('Quemer'),
('Quichua'),
('Quirguiz'),
('Romeno'),
('Romanche'),
('Russo'),
('S�rvio'),
('Somali'),
('Soto'),
('Sua�li'),
('Su�zi'),
('Sueco'),
('Tajique'),
('T�mil'),
('T�tum'),
('Tai'),
('Tok Pisin'),
('Tsonga'),
('Tsuana'),
('Turco'),
('Turcomeno'),
('Ucraniano'),
('Uzbeque'),
('Venda'),
('Vietnamita'),
('Xhosa'),
('Zulu');

--Inser�ao dados em Nacionalidade
insert into projeto.Nacionalidade (nomeNacionalidade) values
('Portuguesa'),
('Filipina'),
('Sul-Africano'),
('Zimbabweano'),
('Namibiana'),
('Boliviano'),
('Brasileiro'),
('Chileno'),
('Colombiano'),
('Costarriquenho'),
('Cubano'),
('Dominicano'),
('Equatoriano'),
('Salvadorenho'),
('Granadino'),
('Guatemalteco'),
('Guian�s'),
('Guianense'),
('Haitiano'),
('Hondurenho'),
('Jamaicano'),
('Mexicano'),
('Nicaraguense'),
('Panamenho'),
('Paraguaio'),
('Peruano'),
('Portorriquenho'),
('Dominicana'),
('S�o-cristovense'),
('S�o-vicentino'),
('Santa-lucense'),
('Surinam�s'),
('Trindadense'),
('Uruguaio'),
('Venezuelano'),
('Alem�'),
('Austr�aco'),
('Belga'),
('Croata'),
('Dinamarqu�s'),
('Antiguano'),
('Argentino'),
('Bahamense'),
('Barbadense'),
('Belizenho'),
('Eslovaco'),
('Esloveno'),
('Espanhol'),
('Franc�s'),
('Grego'),
('H�ngaro'),
('Irland�s'),
('Italiano'),
('Noruego'),
('Holand�s'),
('Polon�s'),
('Ingl�s'),
('Gal�s'),
('Escoc�s'),
('Romeno'),
('Russo'),
('S�rvio'),
('Sueco'),
('Su��o'),
('Turco'),
('Ucraniano'),
('Americano'),
('Canadense'),
('Angolano'),
('Mo�ambicano'),
('Sul-africano'),
('Zimbabuense'),
('Arg�lia'),
('Comorense'),
('Eg�pcio'),
('L�bio'),
('Marroquino'),
('Gan�s'),
('Queniano'),
('Ruand�s'),
('Ugandense'),
('Bechuano'),
('Marfinense'),
('Camaronense'),
('Nigeriano'),
('Somali'),
('Australiano'),
('Neozeland�s'),
('Afeg�o'),
('Saudita'),
('Armeno'),
('Bangladesh'),
('Chin�s'),
('Norte-coreano'),
('Sul-coreano'),
('Indiano'),
('Indon�sio'),
('Iraquiano'),
('Iraniano'),
('Israelita'),
('Japon�s'),
('Malaio'),
('Nepal�s'),
('Omanense'),
('Paquistan�s'),
('Palestino'),
('Qatarense'),
('S�rio'),
('Cingal�s'),
('Tailand�s'),
('Timorense'),
('�rabe'),
('Vietnamita'),
('Iemenita');

--Insercao dados em Nivel_Habilitacao
insert into projeto.Nivel_Habilitacao (descricaoNivel) values 
('N�o sabe ler/escrever'),
('Ler-escrever s/grau ensino'),
('4� Ano'),
('6� Ano'),
('9� Ano'),
('11� Ano'),
('12� Ano'),
('Ensino P�s-Secund�rio'),
('Bacherelato'),
('Licenciatura'),
('Mestrado'),
('Doutoramento');

--Insercao dados em Nivel_Lingua
insert into projeto.Nivel_Lingua (descricaoNivel) values
('Mau'),
('Suficiente'),
('Bom'),
('Muito Bom'),
('Excelente');

--Insercao Dados em Empresa
insert into projeto.Empresa (nome, localizacao, descricao) values
('Clothesy', 'Porto', 'Empresa de distribui��o e venda de roupas'),
('Foodition', 'Braga', 'Empresa de venda de comida'),
('Techine', 'Lisboa', 'Empresa de venda de produtos de inform�tica'),
('Housleek', 'Castelo Branco', 'Empresa de fabrico de mobili�rio'),
('ToysLab', 'Bragan�a', 'Empresa de distribui��o e venda de brinquedos'),
('Mototype', 'Set�bal', 'Empresa de venda de carros'),
('Diviness', 'Viseu', 'Empresa de distribui��o e venda de produtos de beleza'),
('Clother', 'Leiria', 'Empresa de venda de roupas'),
('Gamest', 'Aveiro', 'Empresa de desenvolvimento de jogos online'),
('HyperShoes', 'Guarda', 'Empresa de fabrico e distribui��o de sapatos');

--Insercao dados em Tipo_Contrato
insert into projeto.Tipo_Contrato (descricaoTipoContrato) values
('Contrato a termo certo'),
('Contrato sem termo'),
('Contrato a termo incerto'),
('Contrato de muito curta dura��o'),
('Contrato de presta��o de servi�os'),
('Contrato de trabalho tempor�rio'),
('Contrato de trabalho a tempo parcial');

--Insercao dados em Pessoa
insert into projeto.Pessoa (primeiroNome, nomesMeio, ultimoNome, dataNascimento, telefone, sexo, email) values
('Ana', 'Mendes da Silva', 'Rocha', '1970-05-21', 956352451, 1, 'anamdsrocha@gmail.com'),
('Rodrigo', 'Andr� Gomes', 'Costa', '1982-04-23', 968745987, 0, 'rodrigoagcosta@gmail.com'),
('Pedro', 'Bola', 'Antunes', '1995-06-02', 986532147, 0, 'pedrobantunes95@gmail.com'),
('Gon�alo', 'Melo', 'Matos', '1996-01-01', 986525143, 0, 'goncalommatos96@gmail.com'),
('Marta', 'Catarina de Lemos', 'Lopes', '1980-05-28', 935625412, 1, 'martacllopes@gmail.com'),
('Isabel', 'Marina Santos', 'Bastos', '1999-06-03', 965874123, 1, 'isabelmsbastos@gmail.com'),
('Camila', 'Vilela', 'Guedes', '1965-06-08', 925468753, 1, 'camilaviguedes@gmail.com'),
('Afonso', 'Antumes', 'Pinto', '1974-03-25',965896541, 0, 'afonsoapinto@gmail.com'),
('Augusto', 'Fernandes', 'Gomes', '1980-03-31', 936542587, 0, 'augustofgomes@gmail.com'),
('Filipe', 'Dante', 'Portas', '1970-04-20', 936363564,0, 'fdportas@sapo.pt'),
('Estev�o', 'F�bio Domingues', 'Santos', '1969-04-20', 925487546, 0, 'estefds@hotmail.com'),
('Lorenzo', 'Donatello', 'Ferrari', '1986-12-01', 939291789, 0, 'lorenzodferrari@gmail.com'),
('Diego', 'Garcia', 'Lopez', '1956-08-04', 934578963,0,'diegoglopez@gmail.com'),
('Luis', 'Mateus Garcia', 'Lima', '1955-07-21', 968975214, 0,'luismglima@gmail.com');

--Insercao dados em Recrutador
insert into projeto.Recrutador (numRegisto, metodoDeSelecao, idEmpresa) values
(2,'Fa�o mais perguntas sobre passadas experiencias que testes', 6),
(10, 'Fa�o mais testes sobre potencias problemas',3),
(7, 'Prefiro fazer entrevistas presencias com alguns testes', 9); 

--Insercao dados em Desempregado
insert into projeto.Desempregado (numRegisto, idLinguaMaterna, rua, codigoPostal, localidade, descricao, idNacionalidade) values
(1,71,'Rua das Flores','3810-153','Santa Maria','Boa capacidade de comunica��o e pr�via experi�ncia de vendas',1),
(3,71,'Rua da Prata','3820-144','Almeirim','Gosto de programar e j� fiz alguns jogos b�sicos',1),
(4,71,'Rua do Rei','3841-255','S�o Bernardo','Excelente capacidade de vendas e muito conhecimento de carros',1),
(5,71,'Rua Rainha Isabel','3810-178','Cacia','Boa profissionalidade e autonomia, assim como vasta experiencia em sapatos',1),
(6,71,'Rua da Agrinha','3865-965','Albufeira','Construo mobili�rio como hobby e sou extremamente profissional',1),
(8,71,'Rua do Touro','3865-745','Aliviada','Excelente capacidade de comunica��o e venda, e muita experiencia no ramo de vendas',1),
(9,71,'Rua Vasco da Gama','3845-456','Mal Lavado','J� trabalhei em bastantes lojas de venda de produtos de beleza',1),
(11,71,'Rua Mendes da Costa','3891-123','Vergas','Excelente profissionalismo e capacidade de comunica��o',1),
(12,48,'Rua Direita','3802-325','Nariz','Vasta experiencia com computadores e sobre os seus componentes',53),
(13,29,'Rua Central','3819-445','Alc�ntara','J� fui a algumas competi��es de cozinha, assim como j� trabalhei em bastantes restaurantes',48),
(14,71,'Rua da Mar�','3876-854','Esmoriz','Adoro design e moda, e j� trabalhei em algumas revendedoras de roupa',1);

--Insercao dados em Categoria_Emprego
insert into projeto.Categoria_Emprego (nomeCategoria) values
('Inform�tica'),
('Restaura��o'),
('Vendas'),
('Contabilidade'),
('Juridica'),
('Medicina'),
('Ensino'),
('Engenharia'),
('Marketing'),
('Seguros'),
('Design'),
('Gest�o'),
('Manufa��o');

--Insercao dados em Desempregado_Fala_Lingua
insert into projeto.Desempregado_Fala_Lingua (numRegisto, idLingua, nivelLeitura, nivelEscrita, nivelOral) values
(3, 46, 4, 3, 4),
(4, 46, 5, 5, 5),
(4, 29, 3, 2, 3),
(5, 46, 4, 4, 3),
(6, 46, 5, 4, 4),
(6, 34, 4, 4, 3),
(8, 49, 4, 4, 4),
(12, 46, 4, 4, 3),
(12, 29, 4, 2, 3),
(13, 71, 4, 4, 3);

--Insercao dados em Habilitacaoes_Academicas
insert into projeto.Habilitacoes_Academicas (numRegisto, nomeCurso, estabelecimentoEnsino, idNivelHabilitacao, anoConclusao, notaFinal) values
(1, 'Licenciatura Gest�o Comercial e Vendas', 'Instituto Superior Novas Profiss�es', 10, 1992, 16),
(3, 'Licenciatura Engenharia Inform�tica', 'Universidade de Aveiro',10, 2019, 18),
(4, 'Licenciatura Gest�o Comercial', 'Universidade de Aveiro', 10, 2019, 13),
(5, 'Licenciatura Engenharia Materiais', 'Faculdade de Engenharia Universidade do Porto', 10, 2001, 15),
(5, 'Mestrado Engenharia Materiais', 'Faculdade de Engenharia Universidade do Porto', 11, 2004, 16),
(6, 'Licenciatura Engenharia Madeiras', 'Escola Superior de Tecnologia e Gest�o de Viseu', 10, 2020, 14),
(8, 'Humanidades', 'Escola D. Martim de Alves', 7, 1992, 16),
(9, '9� Ano', 'Escola Eb 2 3 de Mal Lavado', 5, 1993, 4),
(11,'6� Ano', ' Escola Eb 2 de Vergas', 4, 1980, 3),
(12, 'Bachelor in Computer Engineering', 'International Telematic University UNINETTUNO', 9, 2004, 18),
(12, 'Masters Degree in Computer Engineering', 'International Telematic University UNINETTUNO', 11, 2007, 15),
(13, 'Degree in Gastronomy', 'Universidad Europea del Atl�ntico', 10, 1979, 17),
(14, 'Ci�ncias e Tecnologias', 'Escola Principal de Esmoriz', 7, 1973, 14);

--Insercao dados em Experencias_Trabalho 
insert into projeto.Experiencias_Trabalho (numRegisto, titulo, dataInicio, dataFim, localizacao, empresa) values
(1,'Vendedora em loja de roupa', '2000-05-23', '2015-06-15', 'Amarante', 'Zippy'),
(5,'Trabalhadora em f�brica de sapatos', '2000-04-01', '2012-09-19', 'Felgueiras', 'Codizo'),
(8,'Caixa de Supermercado','1995-11-30', '2005-09-12', 'Matadu�os', 'Pingo Doce'),
(8,'Gerente de Supermercado', '2005-09-13', '2020-08-24', 'Matadu�os', 'Pingo Doce'),
(9,'Vendedor em loja de produtos de beleza', '2000-12-01', '2014-07-25', 'Albufeira', 'Sweet Care'),
(11,'Empregado de Mesa', '1990-09-10', '2012-10-15', 'Vergas', '9 Delicias'),
(12,'Vendedor em loja de Componentes Inform�ticos', '2004-10-13', '2016-05-18', 'Porto', 'Info+'),
(13,'Cozinheiro', '1975-10-26', '2002-03-09', 'Lisboa', 'Restaurante Comeria'),
(14,'Designer de Roupa', '1970-09-12', '2003-07-14', 'Braga', 'Moda e Fashion');


--Insercao Dados em Area_Habilitacoes
insert into projeto.Area_Habilitacoes (idDados, numRegisto, idCategoria) values
(1, 1, 3),
(1, 1, 12),
(2, 3, 1),
(2, 3, 8),
(3, 4, 8),
(3, 4, 12),
(4, 5, 8),
(5, 5, 8),
(6, 6, 8),
(10, 12, 1),
(10, 12, 8),
(11, 12, 1),
(11, 12, 8),
(12, 13, 2);

--Insercao Dados em Area_Experiencias_Trabalho
insert into projeto.Area_Experiencias_Trabalho (idDados, numRegisto, idCategoria) values
(1, 1, 3),
(2, 5, 13),
(4, 8, 12),
(5, 9, 3),
(7, 12, 3),
(8, 13, 2),
(9, 14, 11);

--Insercao Dados em Desempregado_Experiente_Categoria
insert into projeto.Desempregado_Experiente_Categoria (numRegisto, idCategoria) values
(1, 3),
(1, 12),
(3, 1),
(3, 8),
(4, 8),
(4, 12),
(5, 8),
(5, 13),
(6, 8),
(8, 12),
(9, 3),
(12, 1),
(12, 3),
(12, 8),
(13, 2),
(14, 11);

--Insercao Dados em Oferta
insert into projeto.Oferta (titulo, numVagas, localizacao, dataPublicacao, idEmpresa, idRecrutador, nivelHabilitacao) values
('Vendedor de Carros',1,'Setubal', '2021-05-21', 6, 2, 7),
('Desenvolvedor Junior de Jogos',2,'Aveiro', '2021-03-04', 9, 7, 11),
('Programador em Java',1,'Lisboa', '2021-02-25', 3, 10, 10),
('Est�gio de Programador em Python', 1, 'Lisboa','2021-04-20', 3, 10, 7);

--Insercao Dados em Estagio
insert into projeto.Estagio (idOferta, duracao, observacoes) values
(4, 6, 'Est�gio para programador em python para trabalhar com AI e Machine Learning');

--Insercao Dados em Emprego
insert into projeto.Emprego (idOferta, salario, tipoContrato, experienciaNecessaria, descricaoEmprego) values
(1,1200,2,'2 anos de experiencia em vendas','Realizar vendas de carros'),
(2,1500,1,Null,'Desenvolver um jogo em Unity'),
(3,2300,3,'5 anos de experiencia com java','Desenvolver programas para a plataforma da empresa');

--Insercao Dados em Area_Oferta
insert into projeto.Area_Oferta (idOferta, idCategoria) values
(1, 3),
(2, 1),
(3, 1),
(4, 1);

--Insercao Dados em Desempregado_Candidato_Oferta
insert into projeto.Desempregado_Candidato_Oferta (idOferta, numRegisto) values
(1, 1),
(2, 3),
(2, 12),
(3, 12),
(1, 3);


select * from projeto.Habilitacoes_Academicas
select projeto.Desempregado.numRegisto, nomeCategoria, idade,  from projeto.Desempregado join projeto.Pessoa on projeto.Pessoa.numRegisto = projeto.Desempregado.numRegisto join projeto.Area_Habilitacoes on projeto.Desempregado.numRegisto = projeto.Area_Habilitacoes.numRegisto join projeto.Categoria_Emprego on projeto.Area_Habilitacoes.idCategoria = projeto.Categoria_Emprego.idCategoria
select * from projeto.Oferta

--select * from projeto.Lingua where nomeLingua = 'Japon�s'

--select * from projeto.Nivel_Habilitacao