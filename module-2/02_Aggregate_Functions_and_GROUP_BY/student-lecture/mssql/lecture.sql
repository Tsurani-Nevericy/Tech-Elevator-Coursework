-- ORDERING RESULTS
select * from country;
select * from city;
-- Populations of all countries in descending order
select name, population
from country
order by population desc;

select name, population
from country
order by population asc;



--Names of countries and continents in ascending order
select name, continent 
from country 
order by continent asc;

select name, continent 
from country 
order by continent, name;



-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)
select name, population
from city
where countrycode = 'USA'
order by name asc, population desc;

select name, governmentform, region, gnp
from country
order by governmentform asc, region asc, gnp desc;




-- LIMITING RESULTS

-- The 10 largest countries in the world
select name, surfacearea
from country
order by surfacearea desc offset 0 rows fetch next 10 rows only;

select top 10 name, surfacearea
from country
order by surfacearea desc;




-- The name and average life expectancy of the countries with the 10 highest life expectancies.
select top 10 name, lifeexpectancy
from country
where lifeexpectancy is not null
order by lifeexpectancy desc;






-- Limiting results allows rows to be returned in 'limited' clusters,where LIMIT says how many, and OFFSET (optional) specifies the number of rows to skip

select name, lifeexpectancy
from country
order by lifeexpectancy desc
offset 20 rows fetch next 10 rows only;



-- CONCATENATING OUTPUTS

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.
select (language + ' is spoken in the country with code ' + countrycode) as sentence
from countrylanguage;



-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
select name, district 
from city
where district in ('California', 'Orgeon', 'Washington')
order by district, name;

select (name+', '+district) as city_state 
from city
where district in ('California', 'Orgeon', 'Washington')
order by district, name;






-- AGGREGATE FUNCTIONS

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.



-- Counts the number of rows in the city table
select count(name)
from city;


-- Also counts the number of rows in the city table
select count(population)
from city;

select count(name)
from country;

select count(lifeexpectancy)
from country;

select count(*)
from country;

-- Average Life Expectancy in the World
select avg(lifeexpectancy)
from country;


-- Total population in Ohio
select sum(population)
from city
where district = 'Ohio';



-- The surface area of the smallest country in the world
select min(surfacearea)
from country;

select top 1 name, surfacearea
from country
order by surfacearea asc;




-- The number of countries who declared independence in 1991
select count(name)
from country
where indepyear = '1991';

select name, indepyear
from country
where indepyear = '1991';



-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.
select count(name) as num_rows, sum(population) as total_pop, avg(population) as avg_pop
from city;


-- Gets the MIN population and the MAX population from the city table.
select min(population) as min_pop, max(population) as max_pop
from city;


-- GROUP BY

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
select countrycode, min(population) as min_pop, max(population) as max_pop
from city
group by countrycode;




-- Count the number of countries where each language is spoken, ordered from most countries to least
select language, count(countrycode) as num_country
from countrylanguage
group by language
order by num_country desc;




-- Average life expectancy of each continent ordered from highest to lowest
select continent, avg(lifeexpectancy) as avg_le
from country
group by continent
order by avg_le desc;




-- Exclude Antarctica from consideration for average life expectancy
select continent, avg(lifeexpectancy) as avg_le
from country
where lifeexpectancy is not null
group by continent
order by avg_le desc;





-- Sum of the population of cities in each state in the USA ordered by state name
select district, sum(population) as pop_sum
from city
where countrycode = 'USA'
group by district
order by district asc;



-- The average population of cities in each state in the USA ordered by state name
select district, avg(population) as pop_avg
from city
where countrycode = 'USA'
group by district
having avg(population) > 300000
order by district asc;

select name, count(*)
from city
group by name
having count(*) > 1
order by count (*) desc, name asc;


-- SUBQUERIES
-- Find the names of cities under a given government leader
select distinct headofstate from country where headofstate is not null and headofstate != '';

select district, name 
from city
where countrycode in (select code from country where headofstate = 'Beatrix');


-- Find the names of cities whose country they belong to has not declared independence yet
select * from city;
select * from country;

select name
from city
where countrycode in (select code from country where indepyear is null);

















