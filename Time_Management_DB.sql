USE master

IF EXISTS(SELECT * FROM sys.databases WHERE name = 'Time_Management')

DROP DATABASE Time_Management
CREATE Database Time_Management;
USE Time_Management;

--PARENT ENTITIES
CREATE TABLE Modules(
Module_Code VARCHAR(10) NOT NULL,
Module_Name VARCHAR(40) NOT NULL,
Credits INT NOT NULL,
Class_hours_per_week INT NOT NULL,
PRIMARY KEY (Module_Code)
);

CREATE TABLE Students(
StudentNr INT IDENTITY(1,2010) NOT NULL,
Name VARCHAR(10) NOT NULL,
Surname VARCHAR(20) NOT NULL,
Email VARCHAR(50) NOT NULL,
Password VARCHAR(15) NOT NULL,
PRIMARY KEY (StudentNr)
);

CREATE TABLE Study_Hours(
Hours_spent INT NOT NULL,
Study_Hour_required INT NOT NULL,
Remain_hours INT NOT NULL,
Module_Code VARCHAR(10) NOT NULL REFERENCES Modules(Module_Code),
PRIMARY KEY(Module_Code)
);

DROP TABLE Study_Hours;
DROP TABLE Students;
DROP TABLE Modules;

SELECT * FROM Students;
SELECT * FROM Modules;
SELECT * FROM Study_Hours;