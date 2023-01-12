USE tempdb
SET DATEFORMAT dmy
GO 

create table tblUsers(
userType nvarchar(5) ,
mail nvarchar(50) PRIMARY KEY,
password nvarchar(50));


create table tblFlights(
flightNum nvarchar(5) PRIMARY KEY,
destination nvarchar(50) ,
origin nvarchar(50),
flightDate nvarchar(10) ,
flightTime nvarchar(5) ,
price int ,
availableSeats int);
 

create table tblBooked(
mail nvarchar(50),
flightNum nvarchar(5),
chairsNum int
PRIMARY KEY(mail, flightNum));


create table tblUsersDet(
mail nvarchar(50) PRIMARY KEY,
passportNum nvarchar(8),
fname nvarchar(20),
lname nvarchar(20),
addres nvarchar(50),
Country nvarchar(20),
zip int,
cardname nvarchar(20),
creditCard nvarchar (20),
expDate nvarchar(5),
cvc int);


----------------------------INSERTS----------------------------

INSERT INTO tblUsers VALUES ('admin' , 'orb@gmail.com' , 'Aa123456')
INSERT INTO tblFlights VALUES ('AV120', 'Thailand', 'Israel', '2023-02-12', '23:34', '750', 500);
INSERT INTO tblFlights VALUES ('AV121', 'Thailand', 'Israel', '2022-03-01', '23:34', '750', 500);
INSERT INTO tblFlights VALUES ('AV122', 'Thailand', 'Israel', '2023-01-13', '23:34', '750', 500);

INSERT INTO tblFlights VALUES ('AV123', 'London', 'Israel', '2023-01-13', '10:34', '750', 500);
INSERT INTO tblFlights VALUES ('AV124', 'London', 'Israel', '2023-01-30', '23:34', '750', 500);

INSERT INTO tblFlights VALUES ('AV125', 'France', 'Israel', '2023-02-01', '10:20', '500', 250);
INSERT INTO tblFlights VALUES ('AV126', 'Israel', 'France', '2023-01-30', '21:00', '500', 250);

INSERT INTO tblFlights VALUES ('AV127', 'Israel', 'United Kingdom', '2023-01-30', '21:00', '600', 750);
INSERT INTO tblFlights VALUES ('AV128', 'United Kingdom', 'Israel', '2023-01-13', '08:00', '600', 750);
INSERT INTO tblFlights VALUES ('AV129', 'United Kingdom', 'Israel', '2023-11-13', '18:20', '600', 550);

INSERT INTO tblFlights VALUES ('AV130', 'Israel', 'Italy', '2023-01-30', '11:00', '500', 250);
INSERT INTO tblFlights VALUES ('AV131', 'Israel', 'Italy', '2023-01-12', '15:45', '500', 500);
INSERT INTO tblFlights VALUES ('AV132', 'Italy', 'Israel', '2023-01-30', '19:00', '500', 250);

INSERT INTO tblUsersDet VALUES ('orb@gmail.com' , '12345678' , 'Or', 'Bonker', 'Sesame Street ,Dimona', 'Israel', 1111111, 'Or Card', 12345678 , '12/24', 123)

UPDATE tblFlights
SET availableSeats = 120
WHERE flightNum = 'AV120';

----------------------------Admin Use----------------------------


---------addding user---------
-- INSERT INTO tblUsers VALUES ('user type' , 'mail' , 'password')


---------adding flight---------
--INSERT INTO tblFlights VALUES ('flight num', 'destination', 'origin', 'date', 'time', 'price', availableSeats);


---------aditing num of seats---------
--UPDATE <table name>
--SET <field name> = <value>
--WHERE <condition>

