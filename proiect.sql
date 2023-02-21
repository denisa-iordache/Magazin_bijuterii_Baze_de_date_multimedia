--CREARE TABELE
drop table clienti;
create table clienti(id number not null, nume varchar2(50), username varchar2(10), parola varchar2(20), 
wishlist  varchar2(255));

alter table clienti add unique(username);

CREATE SEQUENCE autoinc_seq;
drop sequence autoinc_seq;
CREATE OR REPLACE TRIGGER autoinc_trg 
BEFORE INSERT ON clienti 
FOR EACH ROW
WHEN (new.id IS NULL)
BEGIN
  SELECT autoinc_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
/
drop trigger autoinc_trg;

drop table produse;
create table produse (id number not null, descriere varchar2(255), pret number, inStoc varchar2(2), 
img ORDImage, img_semn ORDImageSignature);
CREATE SEQUENCE autoincprod_seq;
drop sequence autoincprod_seq;
CREATE OR REPLACE TRIGGER autoincprod_trg 
BEFORE INSERT ON produse
FOR EACH ROW
WHEN (new.id IS NULL)
BEGIN
  SELECT autoincprod_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
/
drop trigger autoincprod_trg;

--INSERARE CLIENT
create or replace procedure psinserareclient (vnume in varchar2, vusername in varchar2, vparola in varchar2)
is
begin
insert into clienti (nume, username, parola, wishlist)
values (vnume, vusername, vparola, null);
end;
/

--AFISARE CLIENT
create or replace procedure preadclient(vusername in varchar2, vparola in varchar2, flux out varchar2)
is
client varchar2(10);
begin
select username into client from clienti where username=vusername and parola=vparola;
flux:=client;
end;
/

--INSERARE PRODUS CA ADMIN
create or replace procedure psinserareprodus (vdescriere in varchar2, vpret number, vInStoc varchar2, fis in BLOB)
is
begin
insert into produse(descriere, pret, inStoc, img, img_semn) values (vdescriere,vpret,vInStoc, ORDImage(fis,1), ORDImageSignature.init());
end;
/

--AFISARE PRODUS DUPA DESCRIERE
create or replace procedure preadprodus(vdescriere in varchar2, flux out BLOB)
is
obj ORDImage;
begin
select img into obj from produse where lower(descriere)=vdescriere;
flux:=obj.getcontent();
end;
/

create or replace procedure preadprodusdescriere(vdescriere in varchar2, flux out varchar2)
is
descriere1 varchar2(255);
begin
select descriere || ', cu pretul ' || pret || 'lei, este in stoc: ' ||inStoc into descriere1 from produse where lower(descriere) = vdescriere;
flux:=descriere1;
end;
/

--AFISARE PRODUS DUPA IMAGINE DE REFERINTA
--Generare semnaturi
create or replace procedure psgensemnprod
is
mysig ORDImageSignature; --semnatura
myimg ORDImage; --stocheaza temporar imaginea
begin
--parcurg toata tabela
for x in (select id from produse)
loop
    select S.img, S.img_semn into myimg, mysig from produse S where S.id  = x.id for update; --acum am imaginea curenta in myimg
    mysig.generatesignature(myimg); --si ii generez semnatura
    update produse S
    set S.img_semn = mysig where S.id = x.id; --actualizez semnatura
end loop;
end;
/
--Cautare dupa semnaturi
create or replace procedure psregasireprodus(fis in BLOB, vdetalii out varchar2)
is
scor number; --valoarea numerica intre 0 si 100 (ce returneaza evaluateScore)
myimg ORDImage; --imagine curenta de stocat 
mysign ORDImageSignature; --si semnatura ei
qimg ORDImage; --imaginea de cautat
qsign ORDImageSignature; --si semnatura acesteia
mymin number; --tuplul care genereaza cel mai mic scor
descriere1 varchar2(255);
begin
qimg := ORDImage(fis, 1); --incarc imaginea
qimg.setproperties;
qsign := ORDImageSignature.init(); --initializez
DBMS_LOB.CREATETEMPORARY(qsign.signature, TRUE); -- si aloc spatiu pentru semnatura imaginii de cautat deoarece e un blob
qsign.generateSignature(qimg); --generez semnatura pentru imaginea de cautat si o stochez in qsemn
mymin := 100;
--parcurg tabela pentru a vedea care e imaginea cu scorul minim
for x in (select id from produse)
loop
    select S.img_semn, S.descriere || ', cu pretul ' || pret || 'lei, este in stoc: ' ||inStoc into mysign, descriere1 from produse S where S.id = x.id;
    scor := ORDImageSignature.evaluateScore(qsign, mysign, 'color=' || 1 || ' texture=' || 1 || ' shape=' || 1 || ' location=' || 1 || ''); --trebuie '' la final pt a nu astepta sa inchid sirul deschis(deci nu l ia ca si caracter special, il interpreteaza ca si apostrof), trebuie spatiu ca sa nu se concateneze chestiile intre ele
    if scor < mymin then 
        mymin := scor;
        vdetalii := lower(descriere1);
    end if;
end loop;
end;
/

alter table clienti add wishlist varchar2(255);

--INSERARE PRODUS WISHLIST
create or replace procedure psinserarewish (vuser in varchar2, vdescriere in varchar2)
is
begin
update clienti set wishlist = wishlist || ',' || vdescriere where username=vuser;
end;
/

--AFISARE PRODUSE DE PE SITE
create or replace procedure preadproduse(vid in number, flux out BLOB)
is
obj ORDImage;
begin
select img into obj from produse where id=vid;
flux:=obj.getcontent();
end;
/

--AFISARE PRODUSE WISHLIST
create or replace procedure preadprodusewish(vuser in varchar2, wish out varchar2)
is
str varchar2(255);
begin
select wishlist into str from clienti where username=vuser;
wish:=str;
end;
/

--ADAUGARE VIDEO PREZENTARE LA PRODUSE
alter table produse add videoPrezentare ORDVideo;

--INSERARE VIDEO PENTRU PRODUS
create or replace procedure psinserarevideoprodus (vdescriere in varchar2, fis in BLOB)
is
begin
update produse set videoPrezentare=ORDVideo(fis,1) where lower(descriere)=vdescriere;
--insert into produse(descriere, pret, inStoc, img, img_semn) values (vdescriere,vpret,vInStoc, ORDImage(fis,1), ORDImageSignature.init());
end;
/

--AFISARE VIDEO PRODUS DUPA DESCRIERE
create or replace procedure preadvideoprodus(vdescriere in varchar2, flux out BLOB)
is
obj ORDVideo;
begin
select videoPrezentare into obj from produse where lower(descriere)=vdescriere;
flux:=obj.getcontent();
end;
/

--PRELUCRARE IMAGINI
create or replace procedure psgrayscale(vdescriere in varchar2, flux out BLOB)
is
obj ORDImage;
obj2 ORDImage;
begin
select img into obj from produse where lower(descriere)=vdescriere for update;
obj.process('mirror');
update produse set img=obj where lower(descriere)=vdescriere;
select img into obj2 from produse where lower(descriere)=vdescriere;
flux:=obj2.getcontent();
end;
/

create or replace procedure psflip(vdescriere in varchar2, flux out BLOB)
is
obj ORDImage;
obj2 ORDImage;
begin
select img into obj from produse where lower(descriere)=vdescriere for update;
obj.process('flip');
update produse set img=obj where lower(descriere)=vdescriere;
select img into obj2 from produse where lower(descriere)=vdescriere;
flux:=obj2.getcontent();
end;
/

--PRELUARE IMAGINI DIN HTTP
declare
obj ordimage;
ctx raw(64):=null;
begin
insert into produse(descriere, pret, inStoc, img, img_semn) values('imagine de pe site web',65,'Nu',ORDImage.init(),ORDImageSignature.init());
select img into obj from produse where descriere='imagine de pe site web' for update;
obj.importfrom(ctx,'http','http://static.glami.ro/img/500x500t/', '221686794.jpg');
update produse set img=obj where descriere='imagine de pe site web';
commit;
end;
/
create or replace procedure psinserareprodushttp (vdescriere in varchar2, vpret number, vInStoc varchar2, cale varchar2, imaginehttp varchar2)
is
obj ORDImage;
ctx raw(64):=null;
begin
insert into produse(descriere, pret, inStoc, img, img_semn) values (vdescriere,vpret,vInStoc, ORDImage.init(),ORDImageSignature.init());
select img into obj from produse where descriere=vdescriere for update;
obj.importfrom(ctx,'http',cale, imaginehttp);
update produse set img=obj where descriere=vdescriere;
end;
/

--PRELUARE NR DE INREG DIN TABELA PRODUSE
create or replace procedure psnumberrowsproduse(nr out integer)
is
obj integer;
begin
select count(*) into obj from produse;
nr:=obj;
end;
/

select * from clienti
select * from produse