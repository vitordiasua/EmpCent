create unique index IxEmail_Pessoa on projeto.Pessoa(email);

create index IxIdEmpresa_Oferta on projeto.Oferta (idEmpresa);

create index IxIdRecrutador_Oferta on projeto.Oferta (idRecrutador);

create index IxIdEmpresa_Recrutador on projeto.Recrutador (idEmpresa);