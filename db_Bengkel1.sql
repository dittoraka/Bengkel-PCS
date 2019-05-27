drop table karyawan cascade constraints purge;
drop table service cascade constraints purge;
drop table barang cascade constraints purge;
drop table alat cascade constraints purge;
drop table bengkelCust cascade constraints purge;
drop table customer cascade constraints purge;
drop table h_transaksi cascade constraints purge;
drop table d_transaksi cascade constraints purge;

create table karyawan
(
	id_karyawan varchar2(8) primary key,
	nama_karyawan varchar2(100),
	password_karyawan varchar2(20),
	dob_karyawan date,
	spesialis varchar2(15),
	tgl_join date,
	jabatan varchar2 (15)
);

create table service
(
	id_service varchar2(8) primary key,
	nama_service varchar2(30),
	harga_service number (7),
	durasi_service_jam number (2),
	durasi_service_menit number (2)
);

create table barang
(
	id_barang varchar2(6) primary key,
	nama_barang varchar2(20),
	harga_asli number(7),
	harga_customer number (7),
	harga_bengkel number(7),
	stock number(3)
);

create table alat
(
	id_alat varchar2(8) primary key,
	nama_alat varchar2(20),
	banyak_alat number (3),
	kondisi varchar2(1)
);

create table customer
(
	id_customer varchar2(8) primary key,
	nama_customer varchar2(20),
	langganan number,
	role_customer varchar2(1)
);

create table h_transaksi
(
	id_transaksi varchar2(8) primary key,
	id_customer varchar2(8),
	total number,
	tgl_transaksi date,
	foreign key (id_customer) references customer(id_customer)
);

create table d_transaksi
(
	id_transaksi varchar2(8),
	id_serba varchar2(8),
	jumlah number,
	subtotal number,
	foreign key (id_transaksi) references h_transaksi(id_transaksi)
);

create or replace trigger AutoIDBar
before insert on barang
for each row
declare
	temp varchar2(8);
	angka number;
begin
	select substr(max(id_barang),4,3)+1 into temp from barang;
	if (temp is null) then
	temp:=1;
	end if;
	:new.id_barang := 'BAR'||lpad(temp,3,'0');
end;
/
show err;

create or replace trigger AutoIDKar
before insert on karyawan
for each row
declare
	temp varchar2(8);
	angka number;
begin
	select substr(max(id_karyawan),4,3)+1 into temp from karyawan;
	if (temp is null) then
	temp:=1;
	end if;
	:new.id_karyawan := 'KAR'||lpad(temp,3,'0');
end;
/
show err;

create or replace trigger AutoIDCus
before insert on customer
for each row
declare
	temp varchar2(8);
	angka number;
begin
	select substr(max(id_customer),5,3)+1 into temp from customer;
	if (temp is null) then
	temp:=1;
	end if;
	:new.id_customer := 'CUST'||lpad(temp,3,'0');
end;
/
show err;

create or replace trigger AutoIDAla
before insert on alat
for each row
declare
	temp varchar2(8);
	angka number;
begin
	select substr(max(id_alat),4,3)+1 into temp from alat;
	if (temp is null) then
	temp:=1;
	end if;
	:new.id_alat := 'ALT'||lpad(temp,3,'0');
end;
/
show err;

create or replace trigger AutoIDSer
before insert on Service
for each row
declare
	temp varchar2(8);
	angka number;
begin
	select substr(max(id_service),4,3)+1 into temp from service;
	if (temp is null) then
	temp:=1;
	end if;
	:new.id_service := 'SER'||lpad(temp,3,'0');
end;
/
show err;

create or replace trigger AutoIDTrans
before insert on h_trans
for each row
declare
	temp varchar2(8);
	angka number;
begin
	select substr(max(id_transaksi),6,3)+1 into temp from h_trans;
	if (temp is null) then
	temp:=1;
	end if;
	:new.id_transaksi := 'TRANS'||lpad(temp,3,'0');
end;
/
show err;

--spesialis: mesin, cuci, ban, penjualan, management

insert into karyawan values('','Greg Abbot',123,to_date('14-12-1963','DD-MM-YYYY'),'MESIN', to_date('14-12-2017','DD-MM-YYYY'),'MONTIR'); 
--done
insert into karyawan values('','Alex Ferguson',123,to_date('31-12-1941','DD-MM-YYYY'),'MESIN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Arsene Wenger',123,to_date('22-10-1949','DD-MM-YYYY'),'BAN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Josep Guardiola',123,to_date('18-01-1971','DD-MM-YYYY'),'GUDANG',to_date('14-12-2017','DD-MM-YYYY'),'GUDANG');
insert into karyawan values('','Maurizio Sarri',123,to_date('10-01-1959','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Jurgen Klopp',123,to_date('16-06-1967','DD-MM-YYYY'),'MESIN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Mauricio Pochettino',123,to_date('02-03-1972','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'KASIR');
insert into karyawan values('','Ernesto Valverde',123,to_date('09-02-1964','DD-MM-YYYY'),'MANAGEMENT',to_date('14-12-2017','DD-MM-YYYY'),'MANAGER');
insert into karyawan values('','Santiago Solari',123,to_date('08-10-1976','DD-MM-YYYY'),'GUDANG',to_date('14-12-2017','DD-MM-YYYY'),'GUDANG');
insert into karyawan values('','Diego Simeone',123,to_date('28-04-1970','DD-MM-YYYY'),'BAN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Pablo Machin',123,to_date('07-04-1975','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Marcelino Toral',123,to_date('14-08-1965','DD-MM-YYYY'),'GUDANG',to_date('14-12-2017','DD-MM-YYYY'),'GUDANG');
insert into karyawan values('','Massimiliano Allegri',123,to_date('11-08-1967','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Gennaro Gattuso',123,to_date('09-01-1978','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'KASIR');
insert into karyawan values('','Luciano Spalletti',123,to_date('03-07-1959','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'KASIR');
insert into karyawan values('','Carlo Ancelotti',123,to_date('10-06-1959','DD-MM-YYYY'),'MESIN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('','Eusebio Di Francesco',123,to_date('08-09-1969','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'KASIR');

insert into alat values('','OBENG',11,'B'); 
--done
insert into alat values('','TANG',8,'B');
insert into alat values('','KUNCI INGGRIS',8,'B');
insert into alat values('','BOR',7,'B');
insert into alat values('','PALU',10,'B');
insert into alat values('','SOLDER',7,'B');

insert into customer values('','Greg Gerard',1,'P'); 
--done
insert into customer values('','Alex Situmorang',1,'B');
insert into customer values('','Aris Liantono',1,'B');
insert into customer values('','Josep Tedja',1,'P');
insert into customer values('','Mariawati',1,'P');
insert into customer values('','Jessica Natania',1,'P');
insert into customer values('','Maureen Kusumo',1,'B');
insert into customer values('','Ernes Glenn',1,'B');
insert into customer values('','Santiago Uno',1,'B');
insert into customer values('','Diego Costa',1,'B');
insert into customer values('','Patrick',1,'B');
insert into customer values('','Marcelino Ivan',1,'P');
insert into customer values('','Adam Levine',1,'P');
insert into customer values('','Gentar Utama',1,'P');

insert into service values('','CUCI MOBIL',30000,0,20); 
--durasi-durasi diganti
insert into service values('','TAMBAL BAN',35000,0,30);
insert into service values('','GANTI BAN',150000,0,30);
insert into service values('','GANTI MESIN',450000,3,30);
insert into service values('','SERVICE MESIN',450000,2,30);
insert into service values('','GANTI OLI',130000,1,0);
insert into service values('','CAT MOBIL',400000,2,30);
insert into service values('','PASANG AKSESORIS',200000,1,10);

insert into barang values('','Ban Lightyear',50000,55000,45000,100);
insert into barang values('','Ban Bridge',55000,60500,49500,100);
insert into barang values('','Oli TOP 1',35000,38500,31500,100);
insert into barang values('','Oli Yamalube',40000,44000,36000,100);
insert into barang values('','Oli Repsol Matic',38000,41800,34200,100);
insert into barang values('','Ban Michelin',52000,57200,47800,100);
insert into barang values('','Ban FDR',43000,47300,38700,100);
insert into barang values('','Busi Motor',15000,16500,13500,100);
insert into barang values('','Rantai Motor',60000,66000,54000,100);

insert into h_transaksi values('TRANS001','CUST001',50000000,to_date('10-07-2017','DD-MM-YYYY')); 
--ganti semua hehe
insert into h_transaksi values('TRANS002','CUST002',70000000,to_date('09-08-2016','DD-MM-YYYY'));
insert into h_transaksi values('TRANS003','CUST003',20000000,to_date('09-08-2017','DD-MM-YYYY'));
insert into h_transaksi values('TRANS004','CUST004',55000000,to_date('09-08-2012','DD-MM-YYYY'));
insert into h_transaksi values('TRANS005','CUST005',40000000,to_date('09-08-2016','DD-MM-YYYY'));
insert into h_transaksi values('TRANS006','CUST006',5500000,to_date('01-07-2008','DD-MM-YYYY'));
insert into h_transaksi values('TRANS007','CUST007',8000000,to_date('01-09-2015','DD-MM-YYYY'));
insert into h_transaksi values('TRANS008','CUST008',50000000,to_date('01-01-2018','DD-MM-YYYY'));
insert into h_transaksi values('TRANS009','CUST009',15000000,to_date('28-07-2015','DD-MM-YYYY'));
insert into h_transaksi values('TRANS010','CUST010',90000000,to_date('06-01-2018','DD-MM-YYYY'));
insert into h_transaksi values('TRANS011','CUST011',15000000,to_date('12-06-2016','DD-MM-YYYY'));
insert into h_transaksi values('TRANS012','CUST012',40000000,to_date('27-08-2012','DD-MM-YYYY'));
insert into h_transaksi values('TRANS013','CUST013',20000000,to_date('01-07-2014','DD-MM-YYYY'));
insert into h_transaksi values('TRANS014','CUST014',150000000,to_date('09-04-2017','DD-MM-YYYY'));

insert into d_transaksi values('TRANS001','SER001',1,50000000);
insert into d_transaksi values('TRANS002','SER001',1,70000000);
insert into d_transaksi values('TRANS003','SER001',1,20000000);
insert into d_transaksi values('TRANS004','SER001',1,55000000);
insert into d_transaksi values('TRANS005','BAR001',2,40000000);
insert into d_transaksi values('TRANS006','BAR001',3,5500000);
insert into d_transaksi values('TRANS007','SER001',1,8000000);
insert into d_transaksi values('TRANS008','BAR001',4,50000000);
insert into d_transaksi values('TRANS009','SER001',1,15000000);
insert into d_transaksi values('TRANS010','BAR002',5,90000000);
insert into d_transaksi values('TRANS011','BAR001',2,15000000);
insert into d_transaksi values('TRANS012','BAR001',3,40000000);
insert into d_transaksi values('TRANS013','SER001',1,20000000);
insert into d_transaksi values('TRANS014','SER001',1,2500000);

commit;

