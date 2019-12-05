-- ORDERING RESULTS

-- Populations of all countries in descending order

SELECT name, population
FROM country
ORDER BY population DESC;



--Names of countries and continents in ascending order

SELECT name, continent
FROM country
ORDER BY continent, name;


-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

SELECT name, population
FROM city
WHERE countrycode = 'USA'
ORDER BY name ASC, population DESC;

--Countries sorted by form of govt., region, and gnp

SELECT name, governmentform, region, gnp
FROM country
ORDER BY governmentform, region, gnp DESC;



-- LIMITING RESULTS

-- The 10 largest countries in the world

SELECT name, surfacearea
FROM country
ORDER BY surfacearea DESC OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;

SELECT TOP 10 name, surfacearea
FROM country
ORDER BY surfacearea DESC;


-- The name and average life expectancy of the countries with the 10 highest life expectancies.


SELECT TOP 10 name, lifeexpectancy
FROM country
ORDER BY lifeexpectancy DESC;




-- Limiting results allows rows to be returned in 'limited' clusters,where LIMIT says how many, and OFFSET (optional) specifies the number of rows to skip

SELECT name, lifeexpectancy
FROM country
ORDER BY lifeexpectancy DESC
OFFSET 20 ROWS FETCH NEXT 10 ROWS ONLY;




-- CONCATENATING OUTPUTS

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

SELECT (language + ' is spoken in the country with code ' + countrycode) AS sentence
FROM countrylanguage;


-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city

SELECT (name + ', ' + district) AS city_state
FROM city
WHERE district IN ('California', 'Oregon', 'Washington')
ORDER BY district, name;



-- AGGREGATE FUNCTIONS

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.



-- Counts the number of rows in the city table

SELECT COUNT(name)
FROM city;


-- Also counts the number of rows in the city table

SELECT COUNT(population)
FROM city;

SELECT COUNT(name)
FROM country;

SELECT COUNT(lifeexpectancy)
FROM country;

SELECT COUNT(*)
FROM country;

-- Average Life Expectancy in the World

SELECT AVG(lifeexpectancy) AS average_life
FROM country;

SELECT ROUND(AVG(lifeexpectancy), 2) AS average_life
FROM country;


-- Total population in Ohio

SELECT SUM(population) AS total_pop
FROM city
WHERE district = 'Ohio';


-- The surface area of the smallest country in the world

SELECT MIN(surfacearea)
FROM country;

SELECT MAX(surfacearea)
FROM country;


-- The number of countries who declared independence in 1991

SELECT COUNT(*)
FROM country
WHERE indepyear = 1991;


-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

SELECT SUM(population) AS total_pop, AVG(population) AS average_pop, COUNT(*) AS row_count
FROM city;

 --https://docs.microsoft.com/en-us/sql/t-sql/functions/mathematical-functions-transact-sql


-- Gets the MIN population and the MAX population from the city table.

SELECT MIN(population) AS minimum, MAX(population) AS maximum FROM city;


-- GROUP BY

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.

SELECT countrycode, MIN(population) AS min_pop, MAX(population) as max_pop
FROM city
GROUP BY countrycode;

-- Count the number of countries where each language is spoken, ordered from most countries to least

SELECT language, COUNT(countrycode) AS country_count
FROM countrylanguage
GROUP BY language
ORDER BY country_count DESC;


-- Average life expectancy of each continent ordered from highest to lowest

SELECT continent, AVG(lifeexpectancy) AS "Average Life Expectancy"
FROM country
GROUP BY continent
ORDER BY "Average Life Expectancy" DESC;



-- Exclude Antarctica from consideration for average life expectancy

SELECT continent, AVG(lifeexpectancy) AS "Average Life Expectancy"
FROM country
WHERE lifeexpectancy IS NOT NULL
GROUP BY continent
ORDER BY "Average Life Expectancy" DESC;


-- Sum of the population of cities in each state in the USA ordered by state name

SELECT district, SUM(population) AS total_pop
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district;



-- The average population of cities in each state in the USA ordered by state name

SELECT district, AVG(population) AS avg_pop
FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district;

SELECT district, AVG(population) AS avg_pop
FROM city
WHERE countrycode = 'USA'
GROUP BY district
HAVING AVG(population) > 300000
ORDER BY avg_pop DESC;

SELECT name, COUNT(*)
FROM city
GROUP BY name
HAVING COUNT(*) > 1
ORDER BY COUNT(*) DESC, name ASC;


-- SUBQUERIES
-- Find the names of cities under a given government leader

SELECT DISTINCT headofstate FROM country;

SELECT name
FROM city
WHERE countrycode IN (SELECT code FROM country WHERE headofstate = 'Beatrix');


-- Find the names of cities whose country they belong to has not declared independence yet

SELECT name
FROM city
WHERE countrycode IN (SELECT code FROM country WHERE indepyear IS NULL);














