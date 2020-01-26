
create database ArtikelDatabase;
 
use ArtikelDatabase;

create table Artikel(
	id int primary key auto_increment,
    ArtikelnNummer varchar(200),
    Bezeichnung varchar(500),
    Menge int ,
    Erledigt bool);

insert into Artikel (ArtikelnNummer,Bezeichnung,Menge, Erledigt  ) value("1a","SPORTSTECH Laufband",2 , false);
insert into Artikel (ArtikelnNummer,Bezeichnung,Menge , Erledigt) value("2a","Hyperextension Rückentrainer",4 , false);
insert into Artikel (ArtikelnNummer,Bezeichnung,Menge, Erledigt) value("3a","SPORTSTECH Bauchtrainer",6 , false);
insert into Artikel (ArtikelnNummer,Bezeichnung,Menge, Erledigt  ) value("4a","Kraftstation SlimBeam Schwarz",2 , false);
insert into Artikel (ArtikelnNummer,Bezeichnung,Menge , Erledigt) value("5a","Trainingsbank Set Profi ",4 , false);
insert into Artikel (ArtikelnNummer,Bezeichnung,Menge, Erledigt) value("6a","WaterRower Rudergerät",6 , false);
insert into Artikel (ArtikelnNummer,Bezeichnung,Menge, Erledigt) value("100"," Bauchtrainer",6 , true);

select * from Artikel;

select * from Artikel where Erledigt= false;

select * from Artikel where Erledigt= true;

 

 

 