Create Database DNASerial
use DNASerial

CREATE TABLE "AssemblyLineInformation" (
	"Line No."	INT IDENTITY(1,1) PRIMARY KEY,
	"Location"	nvarchar(100),
	"Label Path"  nvarchar (250) NOT NULL
);

CREATE TABLE "ItemMaster" (
	"Item Model Number"	nvarchar(50) primary key,
	"Description"	nvarchar(100),
	"UPC Code"	nvarchar(100),
	"Label Name"	nvarchar(50),
	"Engine Serial No. Identifier"	nvarchar(100)

);

CREATE TABLE "Serial No. Tracker" (
	"Serial No."	nvarchar(100) primary key,
	"Production Date/Time"	datetime,
	"Location"	nvarchar(50),
	"Assembly Line No." integer,
	"Item Model Number"	nvarchar(100),
	"Engine Serial No."	nvarchar(80),
	foreign key ("Assembly Line No.") references AssemblyLineInformation("Line No.")
);


