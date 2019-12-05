-- Switch to the system (aka master) database
USE master;
GO

IF EXISTS(select * from sys.databases where name='ArtGallery')
DROP DATABASE ArtGallery;
GO

-- Create a new Art Gallery Database
CREATE DATABASE ArtGallery;
GO

-- Switch to the ArtGallery Database
USE ArtGallery
GO

-- Begin a TRANSACTION that must complete with no errors
BEGIN TRANSACTION;

CREATE TABLE customer (
	customerId INT IDENTITY(1,1),
	name VARCHAR(64) NOT NULL,
	address VARCHAR(100) NOT NULL,

	CONSTRAINT pk_customer PRIMARY KEY (customerId)
);

CREATE TABLE phone (
	phoneId INT IDENTITY,
	customerId INT NOT NULL,
	number VARCHAR(15) NOT NULL,
	type VARCHAR(6) NOT NULL,
	otherDescription VARCHAR(100),

	CONSTRAINT pk_phone PRIMARY KEY (phoneId),
	CONSTRAINT fk_phone_customer FOREIGN KEY (customerId) REFERENCES customer (customerId),
	CONSTRAINT chk_type CHECK (type IN ('Home', 'Work', 'Mobile', 'Other')),
	CONSTRAINT chk_otherDescription CHECK (
		(type = 'Other' AND otherDescription IS NOT NULL)
		OR
		(type <> 'Other' AND otherDescription IS NULL)
	)
);


CREATE TABLE artist (
	artistId INT IDENTITY,
	firstName VARCHAR(64) NOT NULL,
	lastName VARCHAR(64) NOT NULL,

	CONSTRAINT pk_artist PRIMARY KEY (artistId)
);

CREATE TABLE art (
	artCode VARCHAR(10),
	title VARCHAR(64) NOT NULL,
	artistId int NOT NULL,

	CONSTRAINT pk_art PRIMARY KEY (artCode),
	CONSTRAINT fk_art_artist FOREIGN KEY (artistId) REFERENCES artist(artistId)
);

CREATE TABLE customer_purchases (
	customerId INT NOT NULL,
	artCode VARCHAR(10) NOT NULL,
	purchaseDate DATE NOT NULL,
	price MONEY NOT NULL,

	CONSTRAINT pk_customer_purchases PRIMARY KEY (customerId, artCode, purchaseDate),
	CONSTRAINT fk_customer_purchases_customer FOREIGN KEY (customerId) REFERENCES customer (customerId),
	CONSTRAINT fk_customer_purchases_art FOREIGN KEY (artCode) REFERENCES art (artCode),
	
);




INSERT INTO customer (name, address)
VALUES ('David P-C', '1776 Mentor Avenue, Norwood, OH 45212');

INSERT INTO phone (customerId, number, type)
VALUES ((SELECT customerId FROM customer WHERE name = 'David P-C'),
		 '555-1212', 'Home');

INSERT INTO phone (customerId, number, type, otherDescription)
VALUES ((SELECT customerId FROM customer WHERE name = 'David P-C'),
		 '555-1212', 'Other', 'At Tech Elevator');

UPDATE phone
SET type = 'Work', otherDescription = NULL
WHERE phoneId =
	(SELECT phoneId FROM phone JOIN customer ON customer.customerId = phone.customerId
	 WHERE customer.name = 'David P-C' AND phone.type = 'Other');

COMMIT;