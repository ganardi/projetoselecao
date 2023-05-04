--Banco locahost
--"Host=localhost;Username=postgres;Password=admin;Database=postgres";
--script table criada
create table tablecep(
cep varchar(200),
logradouro varchar(200),
complemento varchar(200),
bairro varchar(200),
localidade varchar(200),
uf varchar(200),
ibge varchar(200),
gia varchar(200),
ddd varchar(200),
siafi varchar(200),
origem varchar(200)
)


select * from tablecep


