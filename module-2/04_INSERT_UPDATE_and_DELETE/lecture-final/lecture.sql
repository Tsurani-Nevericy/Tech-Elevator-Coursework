-- INSERT

-- 1. Add Klingon as a spoken language in the USA

SELECT * FROM countrylanguage WHERE countrycode = 'USA';

INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'Klingon', 0, 0.0001);


-- 2. Add Klingon as a spoken language in Great Britain

SELECT * FROM countrylanguage WHERE language = 'English' AND isofficial = 1;

INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('GBR', 'Klingon', 0, 0.001);

SELECT * FROM countrylanguage WHERE countrycode = 'GBR';

SELECT * FROM countrylanguage WHERE language = 'Klingon';

INSERT INTO countrylanguage
VALUES ('CAN', 'Klingon', 0, 0.001);




-- UPDATE

-- 1. Update the capital of the USA to Houston

SELECT id FROM city WHERE name = 'Houston';

UPDATE country
SET capital = (SELECT id FROM city WHERE name = 'Houston')
WHERE code = 'USA';

SELECT * FROM country WHERE code = 'USA';


-- 2. Update the capital of the USA to Washington DC and the head of state

SELECT id FROM city WHERE name = 'Washington';

UPDATE country
SET capital = (SELECT id FROM city WHERE name = 'Washington'),
    headofstate = 'Mickey Mouse'
WHERE code = 'USA';

-- 3. Add $$ to names of cities in countries with GNP of a trillion or more dollars

SELECT code FROM country WHERE gnp > 1000000;

UPDATE city
SET name = '$$' + name + '$$'
WHERE countrycode IN (SELECT code FROM country WHERE gnp > 1000000);

UPDATE city
SET name = TRIM('$' from name)
WHERE countrycode IN (SELECT code FROM country WHERE gnp > 1000000);

SELECT * FROM city;


-- DELETE

-- 1. Delete English as a spoken language in the USA

DELETE FROM countrylanguage
WHERE language = 'English' AND countrycode = 'USA';


-- 2. Delete all occurrences of the Klingon language 

DELETE FROM countrylanguage
WHERE language = 'Klingon';



-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.

INSERT INTO countrylanguage (language, isofficial, percentage)
VALUES ('Elvish', 1, 50);

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('ZZZ', 'Elvish', 1, 50);

-- 3. Try deleting the country USA. What happens?

DELETE FROM country
WHERE code = 'USA';

-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA

INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'English', 1, 87);

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'

UPDATE country
SET continent = 'Outer Space'
WHERE code = 'USA';


-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.

BEGIN TRANSACTION;

DELETE FROM countrylanguage;

SELECT * FROM countrylanguage;

ROLLBACK; --or COMMIT


-- 2. Try updating all of the cities to be in the USA and roll it back

BEGIN TRANSACTION;

UPDATE city
SET countrycode = 'USA';

SELECT * FROM city;

ROLLBACK;


-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.