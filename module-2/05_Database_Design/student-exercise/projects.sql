USE master;
GO

IF EXISTS(select * from sys.databases where name='projectsdatabase')
DROP DATABASE projectsdatabase;
GO

CREATE DATABASE projectsdatabase;
GO

USE projectsdatabase 
GO

BEGIN TRANSACTION;

CREATE TABLE employee (
	employeenumber integer identity NOT NULL,
	jobtitle varchar(64) NOT NULL,
	lastname varchar(32) NOT NULL,
	firstname varchar(32) NOT NULL,
	gender varchar(8) NOT NULL,
	dateofbirth date NOT NULL,
	dateofhire date NOT NULL,
	department integer NOT NULL,

	CONSTRAINT pk_employee PRIMARY KEY (employeenumber),
	CONSTRAINT ck_gender CHECK (gender IN ('Male', 'Female'))
);

CREATE TABLE department (
	departmentnumber integer identity  NOT NULL,
	name varchar(64) UNIQUE NOT NULL,

	CONSTRAINT pk_department PRIMARY KEY (departmentnumber)
);

CREATE TABLE project (
	projectnumber integer identity  NOT NULL,
	name varchar(64) UNIQUE NOT NULL,
	startdate date not null,
	CONSTRAINT pk_project_project_id PRIMARY KEY (projectnumber)
);

CREATE TABLE project_employee (	
	project_id integer NOT NULL,
	employee_id integer NOT NULL,
	CONSTRAINT pk_project_employee PRIMARY KEY (project_id, employee_id)
);

ALTER TABLE employee ADD CONSTRAINT fk_employee_department FOREIGN KEY (department) REFERENCES department(departmentnumber);

INSERT INTO department (name) 
VALUES ('Department of One');
INSERT INTO department (name) 
VALUES ('Department of Dos');
INSERT INTO department (name) 
VALUES ('Department of Trois');
INSERT INTO department (name) 
VALUES ('Department of Vier');

INSERT INTO project (name, startdate) 
VALUES ('Project Eins', '2011-01-01');
INSERT INTO project (name, startdate) 
VALUES ('Project Two', '2012-02-02');
INSERT INTO project (name, startdate) 
VALUES ('Project Tres', '2013-03-03');
INSERT INTO project (name, startdate) 
VALUES ('Project Quatre', '2014-04-04');


INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Head One', 'Mamma', 'Joe', 'Male', '1970-03-10', '2002-01-01', 1);
INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Sub-One', 'Normous', 'Dixie', 'Female', '1975-08-10', '2002-02-02', 1);
INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Head Dos', 'Wang', 'Caesar', 'Male', '1980-05-02', '2002-03-03', 2);
INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Sub-Dos', 'Butts', 'Seymour', 'Male', '1985-11-06', '2002-04-04', 2);
INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Head Trois', 'Handy', 'Anita', 'Female', '1972-10-03', '2002-05-05', 3);
INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Sub-Trois', 'Upisass', 'Janet', 'Female', '1977-11-10', '2002-06-06', 3);
INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Head Vier', 'Jyna', 'Ava', 'Female', '1982-11-05', '2002-07-07', 4);
INSERT INTO employee (jobtitle, lastname, firstname, gender, dateofbirth, dateofhire, department)
VALUES ('Sub-Vier', 'Jass', 'Hugh', 'Male', '1987-10-08', '2002-08-08', 4);

INSERT INTO project_employee (project_id, employee_id) 
VALUES (1, 1);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (2, 1);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (2, 2);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (3, 2);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (3, 3);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (3, 4);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (4, 5);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (4, 6);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (4, 7);
INSERT INTO project_employee (project_id, employee_id) 
VALUES (4, 8);

COMMIT TRANSACTION;