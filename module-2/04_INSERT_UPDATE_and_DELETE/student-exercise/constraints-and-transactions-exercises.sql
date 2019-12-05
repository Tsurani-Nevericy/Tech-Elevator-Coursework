-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
begin transaction;

insert into actor(first_name, last_name)
values ('HAMPTON', 'AVENUE');
insert into actor(first_name, last_name)
values ('LISA', 'BYWAY');

commit;

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.
begin transaction;

insert into film(title, description, release_year, language_id, length)
values ('EUCLIDEAN PI', 'The epic story of Euclid as a pizza delivery boy in ancient Greece', 2008, 1, 198);

commit;

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.
begin transaction;

insert into film_actor (film_id, actor_id)
values (
	(select film_id from film where title = 'EUCLIDEAN PI'),
	(select actor_id from actor where first_name + ' ' + last_name = 'HAMPTON AVENUE')
);
insert into film_actor (film_id, actor_id)
values (
	(select film_id from film where title = 'EUCLIDEAN PI'),
	(select actor_id from actor where first_name + ' ' + last_name = 'LISA BYWAY')
);

commit;

-- 4. Add Mathmagical to the category table.
begin transaction;

insert into category (name)
values ('Mathmagical');

commit;

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
begin transaction;

insert into film_category (film_id, category_id)
values (
	(select film_id from film where title = 'EUCLIDEAN PI'),
	(select category_id from category where name = 'Mathmagical')
	);
insert into film_category (film_id, category_id)
values (
	(select film_id from film where title = 'EGG IGBY'),
	(select category_id from category where name = 'Mathmagical')
	);
insert into film_category (film_id, category_id)
values (
	(select film_id from film where title = 'KARATE MOON'),
	(select category_id from category where name = 'Mathmagical')
	);
insert into film_category (film_id, category_id)
values (
	(select film_id from film where title = 'RANDOM GO'),
	(select category_id from category where name = 'Mathmagical')
	);
insert into film_category (film_id, category_id)
values (
	(select film_id from film where title = 'YOUNG LANGUAGE'),
	(select category_id from category where name = 'Mathmagical')
	);

commit;

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)
begin transaction;

update film
set rating = 'G'
where film_id in 
(
	(select film_id from film_category where category_id in
	(select category_id from category where name = 'Mathmagical'))
);

commit;

-- 7. Add a copy of "Euclidean PI" to all the stores.
begin transaction;

insert into inventory(film_id, store_id)
values (
(select film_id from film where title = 'EUCLIDEAN PI'), 1);
insert into inventory(film_id, store_id)
values (
(select film_id from film where title = 'EUCLIDEAN PI'), 2);

commit;

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
begin transaction;

delete from film
where film_id = (select film_id from film where title = 'EUCLIDEAN PI');
--delete from inventory where film_id = (select film_id from film where title = 'EUCLIDEAN PI');

commit;

-- It did not succeed because film_actor table uses the film_id from the film table as a foreign key and deleting Euclidean Pi from film would violate the foreign key constraint on film_actor.

-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
begin transaction;

delete from category
where name = 'Mathmagical';

commit;

-- It did not succeed because film_category table uses the category_id from the category table as a foreign key and deleting Mathmagical from category would violate the foreign key constraint on film_category.

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
begin transaction;

delete from film_category
where category_id in (select category_id from category where name = 'Mathmagical');

commit;

-- It succeeds because film_category is not required to have a value that corresponds to Mathmagical even if another table relies on it existing in film_category.

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
begin transaction;

delete from category
where name = 'Mathmagical';

commit;

-- It succeeds because film_category's foreign key for Mathmagical no longer exists so it will not violate the foreign key constraint.

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.
begin transaction;

--Must remove the two actors in the film before film can be deleted because they are using the film_id key.
delete from film_actor
where film_id in (select film_id from film where title = 'EUCLIDEAN PI');

--Must remove the copies of Euclidean Pi from the all the stores because they are using the film_id key.
delete from inventory
where film_id in (select film_id from film where title = 'EUCLIDEAN PI');

--Now Succeeds because nothing is using film_id as a foreign key anymore.
delete from film
where title = 'EUCLIDEAN PI';

commit;
