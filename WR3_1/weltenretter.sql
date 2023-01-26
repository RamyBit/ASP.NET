--create database Weltenretter
--go
--use Weltenretter
--go
--create table Held (
--	held_id integer not null,
--	name char(20) not null,
--	beruf char(20) not null,
--	constraint pk_held primary key(held_id) 
--)

--create table Aggressor (
--	aggressor_id integer not null,
--	name char(20) not null,
--	spezialitaet char(20) not null,
--	constraint pk_aggressor primary key(aggressor_id) 
--)

--create table Bedrohung (
--	bedrohung_id int not null,
--	name char(20) not null,
--	akut bit not null,
--	held_id integer,
--	aggressor_id integer,
--	constraint pk_bedrohung primary key (bedrohung_id),
--	constraint fk_bedrohung_held foreign key (held_id) references Held (held_id) on delete cascade on update cascade,
--	constraint fk_bedrohung_aggressor foreign key (aggressor_id) references Aggressor (aggressor_id)	
--)


--insert into held values(1,'Bodo Brettschneider', 'Hausmeister')
--select * from held

