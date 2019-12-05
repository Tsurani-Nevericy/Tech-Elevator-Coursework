SELECT ALL name FROM city;
SELECT DISTINCT name FROM city;

-- The name and population of all cities in the USA with a population of greater than 1 million people

SELECT name, population FROM city WHERE countrycode = 'USA' AND population > 1000000;

-- The name and population of all cities in China with a population of greater than 1 million people

SELECT code FROM country WHERE name = 'China';

SELECT name, population FROM city WHERE countrycode = 'CHN' AND population > 1000000;

SELECT name, population FROM city
WHERE countrycode = (SELECT code FROM country WHERE name = 'China') AND population > 1000000;


-- The name and region of all countries in North or South America

SELECT name, region FROM country
WHERE continent IN ('North America', 'South America');
  
-- The name, continent, and head of state of all countries whose form of government is a monarchy

SELECT DISTINCT governmentform FROM country;

SELECT name, continent, headofstate, governmentform FROM country WHERE governmentform LIKE '%Monarchy%';

-- The name, country code, and population of all cities with a population less than one thousand people

SELECT name, countrycode, population FROM city WHERE population < 1000;

-- The name and region of all countries in North or South America except for countries in the Caribbean

SELECT name, region FROM country WHERE continent IN ('North America', 'South America') AND region <> 'Caribbean';

-- The name, population, and GNP of all countries with a GNP greater than $1 trillion dollars and a population of less than 1 billion people

SELECT name, population, gnp FROM country WHERE gnp > 1000000 AND population < 1000000000;

-- The name and population of all cities in Texas that have a population of greater than 1 million people

SELECT name, population FROM city WHERE district = 'Texas' AND population > 1000000;

-- The name and average life expectancy of all countries in southern-ish regions

SELECT DISTINCT region FROM country;
SELECT name, lifeexpectancy FROM country WHERE region LIKE '%South%';

-- The name and average life expectancy of all countries in southern regions for which an average life expectancy has been provided (i.e. not equal to null)

SELECT name, lifeexpectancy FROM country
WHERE region LIKE '%South%' AND lifeexpectancy IS NOT NULL;


-- The name, continent, GNP, and average life expectancy of all countries in Africa or Asia that have an average life expectancy of at least 50 years and a GNP between $1 million and $100 million dollars
SELECT name, continent, gnp, lifeexpectancy
FROM country
WHERE (continent = 'Africa' OR continent = 'Asia') AND lifeexpectancy >= 50 AND gnp BETWEEN 1 AND 100;