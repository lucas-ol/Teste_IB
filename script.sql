CREATE DATABASE [testeIB];
go
use [testeIB]
go
CREATE TABLE [dbo].[brand](
	id int primary key IDENTITY NOT NULL,
	nome nvarchar(20) NOT NULL,
);

create unique index  ix_brand_nome on [brand](nome);

CREATE TABLE patrimony(
	id int primary key IDENTITY,
	nome nvarchar(20) not null,
	MarcaId int not null,
	descricao nvarchar(50) NULL,
	numeroTombo int not null,
	constraint FK_Brand_MarcaId foreign key (MarcaId) references brand(id)
)
