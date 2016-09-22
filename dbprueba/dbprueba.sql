CREATE TABLE categoria (
    id bigint  AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) not null UNIQUE
    );
insert into categoria (nombre) values ('categoria 1');
insert into categoria (nombre) values ('categoria 2');
insert into categoria (nombre) values ('categoria 3');

create table articulo (
id bigint auto_increment primary key,
nombre varchar (50) not null unique,
precio decimal (10,2),
categoria bigint
);

alter table articulo add foreign key (categoria) references categoria (id);

insert into articulo (nombre, precio, categoria) values ('articulo 1', 1,1);
insert into articulo (nombre, precio, categoria) values ('articulo 2', 2,2);
insert into articulo (nombre, precio) values ('articulo 3', 3);
insert into articulo (nombre) values ('articulo 4');
