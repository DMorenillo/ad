CREATE TABLE categoria (
    id bigint  AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(50) not null UNIQUE
    );
insert into categoria (nombre) values ('categoria 1');
insert into categoria (nombre) values ('categoria 2');
insert into categoria (nombre) values ('categoria 3');
