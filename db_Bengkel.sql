drop table karyawan cascade constraints purge;
drop table service cascade constraints purge;
drop table barang cascade constraints purge;
drop table alat cascade constraints purge;
drop table customer cascade constraints purge;
drop table h_transaksi cascade constraints purge;
drop table d_transaksi cascade constraints purge;

create table karyawan
(
	id_karyawan varchar2(6) primary key,
	nama_karyawan varchar2(100),
	dob_karyawan date,
	spesialis varchar2(15),
	tgl_join date,
	jabatan varchar2 (15)
);

create table service
(
	id_service varchar2(6) primary key,
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
	id_alat varchar2(6) primary key,
	nama_alat varchar2(20),
	banyak_alat number (3),
	kondisi varchar2(1)
);

create table customer
(
	id_customer varchar2(6) primary key,
	nama_customer varchar2(20),
	langganan number,
	role_customer varchar2(1)
);

create table bengkelCust
(
	id_customer varchar2(6) ,
	nama_bengkel varchar2(20),
	alamat varchar2(100),
	foreign key (id_customer) references customer(id_customer)
);

create table h_transaksi
(
	id_transaksi varchar2(8) primary key,
	id_customer varchar2(6),
	total number,
	tgl_transaksi date,
	foreign key (id_customer) references customer(id_customer)
);

create table d_transaksi
(
	id_transaksi varchar2(8),
	id_serba varchar2(6),
	jumlah number,
	subtotal number,
	foreign key (id_transaksi) references h_transaksi(id_transaksi)
);

--spesialis: mesin, cuci, ban, penjualan, management

insert into karyawan values('KAR001','Greg Abbot',to_date('14-12-1963','DD-MM-YYYY'),'MESIN', to_date('14-12-2017','DD-MM-YYYY'),'MONTIR'); --done
insert into karyawan values('KAR002','Alex Ferguson',to_date('31-12-1941','DD-MM-YYYY'),'MESIN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR003','Arsene Wenger',to_date('22-10-1949','DD-MM-YYYY'),'BAN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR004','Josep Guardiola',to_date('18-01-1971','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR005','Maurizio Sarri',to_date('10-01-1959','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR006','Jurgen Klopp',to_date('16-06-1967','DD-MM-YYYY'),'MESIN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR007','Mauricio Pochettino',to_date('02-03-1972','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'KASIR');
insert into karyawan values('KAR008','Ernesto Valverde',to_date('09-02-1964','DD-MM-YYYY'),'MANAGEMENT',to_date('14-12-2017','DD-MM-YYYY'),'MANAGER');
insert into karyawan values('KAR009','Santiago Solari',to_date('08-10-1976','DD-MM-YYYY'),'MANAGEMENT',to_date('14-12-2017','DD-MM-YYYY'),'MANAGER');
insert into karyawan values('KAR010','Diego Simeone',to_date('28-04-1970','DD-MM-YYYY'),'BAN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR011','Pablo Machin',to_date('07-04-1975','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR012','Marcelino Toral',to_date('14-08-1965','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR013','Massimiliano Allegri',to_date('11-08-1967','DD-MM-YYYY'),'CUCI',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR014','Gennaro Gattuso',to_date('09-01-1978','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'MARKETING');
insert into karyawan values('KAR015','Luciano Spalletti',to_date('03-07-1959','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'MARKETING');
insert into karyawan values('KAR016','Carlo Ancelotti',to_date('10-06-1959','DD-MM-YYYY'),'MESIN',to_date('14-12-2017','DD-MM-YYYY'),'MONTIR');
insert into karyawan values('KAR017','Eusebio Di Francesco',to_date('08-09-1969','DD-MM-YYYY'),'PENJUALAN',to_date('14-12-2017','DD-MM-YYYY'),'KASIR');

insert into bengkelCust values('CUST001','ABADI','Petemon no 61');
insert into bengkelCust values('CUST004','JAYA','Dharmahusada no 12');
insert into bengkelCust values('CUST005','KUDA CEPAT','Mulyosari no 69');
insert into bengkelCust values('CUST006','RODA PUTAR','Merr no 52');
insert into bengkelCust values('CUST012','INUL','Ngagel Jaya Tengah no 17');
insert into bengkelCust values('CUST013','DANGDUT','Pucang Anom no 81');
insert into bengkelCust values('CUST014','HANTU','Pacar Keling no 120');

insert into alat values('ALT001','OBENG',11,'B'); --done
insert into alat values('ALT002','TANG',8,'B');
insert into alat values('ALT003','KUNCI INGGRIS',8,'B');
insert into alat values('ALT004','BOR',7,'B');
insert into alat values('ALT005','PALU',10,'B');
insert into alat values('ALT006','SOLDER',7,'B');

insert into customer values('CUST001','Greg Gerard',1,'P'); --done
insert into customer values('CUST002','Alex Situmorang',1,'B');
insert into customer values('CUST003','Aris Liantono',1,'B');
insert into customer values('CUST004','Josep Tedja',1,'P');
insert into customer values('CUST005','Mariawati',1,'P');
insert into customer values('CUST006','Jessica Natania',1,'P');
insert into customer values('CUST007','Maureen Kusumo',1,'B');
insert into customer values('CUST008','Ernes Glenn',1,'B');
insert into customer values('CUST009','Santiago Uno',1,'B');
insert into customer values('CUST010','Diego Costa',1,'B');
insert into customer values('CUST011','Patrick',1,'B');
insert into customer values('CUST012','Marcelino Ivan',1,'P');
insert into customer values('CUST013','Adam Levine',1,'P');
insert into customer values('CUST014','Gentar Utama',1,'P');

insert into service values('SER001','CUCI MOBIL',30000,0,20); --durasi-durasi diganti
insert into service values('SER002','TAMBAL BAN',35000,0,30);
insert into service values('SER003','GANTI BAN',150000,0,30);
insert into service values('SER004','GANTI MESIN',450000,3,30);
insert into service values('SER005','SERVICE MESIN',450000,2,30);
insert into service values('SER006','GANTI OLI',130000,1,0);
insert into service values('SER007','CAT MOBIL',400000,2,30);
insert into service values('SER008','PASANG AKSESORIS',200000,1,10);

insert into barang values('BAR001','Ban Lightyear',50000,55000,45000,100);
insert into barang values('BAR002','Ban Bridge',55000,60500,49500,100);
insert into barang values('BAR003','Oli TOP 1',35000,38500,31500,100);
insert into barang values('BAR004','Oli Yamalube',40000,44000,36000,100);
insert into barang values('BAR005','Oli Repsol Matic',38000,41800,34200,100);
insert into barang values('BAR006','Ban Michelin',52000,57200,47800,100);
insert into barang values('BAR007','Ban FDR',43000,47300,38700,100);
insert into barang values('BAR008','Busi Motor',15000,16500,13500,100);
insert into barang values('BAR009','Rantai Motor',60000,66000,54000,100);

insert into h_transaksi values('TRANS001','CUST001',50000000,to_date('10-07-2017','DD-MM-YYYY')); --ganti semua hehe
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
