--create database Weltenretter2
--go
--use Weltenretter2
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
--	constraint fk_bedrohung_aggressor foreign key (aggressor_id) references Aggressor (aggressor_id) on delete cascade on update cascade	
--)
--insert into Held values (4711,'Sven', 'IT')
--insert into Aggressor values (666,'Aggressor1','SPC')
--insert into Bedrohung values(1,'WE',1,4711,666)
--select * from Bedrohung
--select * from Aggressor
select * from Bedrohung
--delete from Bedrohung where bedrohung_id = 1

--insert into Aggressor values(2,'Russi','richte Hand')
--update Bedrohung
--set aggressor_id = 2 where bedrohung_id =1