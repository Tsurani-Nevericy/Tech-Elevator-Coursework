-- Display all the films and their language

SELECT film.title, language.name
FROM film
JOIN language ON language.language_id = film.language_id;


-- Display all the films and in English


SELECT film.title, language.name
FROM film
JOIN language ON language.language_id = film.language_id
WHERE language.name = 'English';

-- Display all the films with their category

SELECT f.title, cat.name
FROM film AS f
JOIN film_category AS fc ON f.film_id = fc.film_id
JOIN category AS cat ON fc.category_id = cat.category_id
ORDER BY cat.name;

-- Display all the films with a category of Horror

SELECT f.title, cat.name
FROM film AS f
JOIN film_category AS fc ON f.film_id = fc.film_id
JOIN category AS cat ON fc.category_id = cat.category_id
WHERE cat.name = 'Horror';

-- Display all the films with a category of Horror and title that begins with the letter F

SELECT f.title, cat.name
FROM film AS f
JOIN film_category AS fc ON f.film_id = fc.film_id
JOIN category AS cat ON fc.category_id = cat.category_id
WHERE cat.name = 'Horror' AND f.title LIKE 'F%';


-- Who acted in what together?
SELECT film.film_id, fa1.actor_id, fa2.actor_id
FROM film
JOIN film_actor AS fa1 ON film.film_id = fa1.film_id
JOIN film_actor AS fa2 ON film.film_id = fa2.film_id AND fa1.actor_id < fa2.actor_id
ORDER BY film.film_id;

SELECT film.title,
	   actor1.first_name + ' ' + actor1.last_name AS first_actor,
	   actor2.first_name + ' ' + actor2.last_name AS second_actor
FROM film
JOIN film_actor AS fa1 ON film.film_id = fa1.film_id
JOIN film_actor AS fa2 ON film.film_id = fa2.film_id AND fa1.actor_id < fa2.actor_id
JOIN actor AS actor1 ON fa1.actor_id = actor1.actor_id
JOIN actor AS actor2 ON fa2.actor_id = actor2.actor_id
ORDER BY film.film_id;


-- How many times have two actors appeared together?

SELECT COUNT(*) AS joint_appearances,
	   actor1.first_name + ' ' + actor1.last_name AS first_actor,
	   actor2.first_name + ' ' + actor2.last_name AS second_actor
FROM film
JOIN film_actor AS fa1 ON film.film_id = fa1.film_id
JOIN film_actor AS fa2 ON film.film_id = fa2.film_id AND fa1.actor_id < fa2.actor_id
JOIN actor AS actor1 ON fa1.actor_id = actor1.actor_id
JOIN actor AS actor2 ON fa2.actor_id = actor2.actor_id
GROUP BY (actor1.first_name + ' ' + actor1.last_name), (actor2.first_name + ' ' + actor2.last_name)
ORDER BY joint_appearances DESC;


-- What movies did the two most often acted together actors appear in together?

WITH top_actors AS
(
	SELECT TOP 1 actor1.actor_id AS id1,
		   actor2.actor_id AS id2
	FROM film
	JOIN film_actor AS fa1 ON film.film_id = fa1.film_id
	JOIN film_actor AS fa2 ON film.film_id = fa2.film_id AND fa1.actor_id < fa2.actor_id
	JOIN actor AS actor1 ON fa1.actor_id = actor1.actor_id
	JOIN actor AS actor2 ON fa2.actor_id = actor2.actor_id
	GROUP BY actor1.actor_id, actor2.actor_id
	ORDER BY COUNT(*) DESC
)
SELECT film.title
FROM film
JOIN film_actor AS fa1 ON fa1.film_id = film.film_id
JOIN film_actor AS fa2 ON fa2.film_id = film.film_id
WHERE fa1.actor_id = (SELECT id1 FROM top_actors)
AND fa2.actor_id = (SELECT id2 FROM top_actors);